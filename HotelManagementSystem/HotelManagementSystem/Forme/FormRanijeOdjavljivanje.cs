using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Neo4jClient.Cypher;
using HotelManagementSystem.DomainModel;
using Neo4jClient;

namespace HotelManagementSystem.Forme
{
    public partial class FormRanijeOdjavljivanje : Form
    {
        public GraphClient client;
        public List<Odjava> listaOdjava;
        DateTime start, end;
        public FormRanijeOdjavljivanje()
        {
            InitializeComponent();
            listaOdjava = new List<Odjava>();
        }
        public void VratiSveGosteKojiSuSeRanijeOdjavili(DateTime start,DateTime end)
        {
            Dictionary<string, object> queryDict = new Dictionary<string, object>();

            var query = new Neo4jClient.Cypher.CypherQuery("match(n:Gost)-[r:ODJAVA ]->(s:Prostorija) "
                                                            +"where date({year:"+start.Year+ ", month: " +start.Month
                                                            +", day:"+start.Day
                                                            +"}) <=r.datumOdjave <=date({year:"+end.Year
                                                            +", month:"+end.Month+",day:"+end.Day+"}) return r ",
                                                           queryDict, CypherResultMode.Set);

            List<Odjava> odjave = ((IRawGraphClient)client).ExecuteGetCypherResults<Odjava>(query).ToList();

            var query1 = new Neo4jClient.Cypher.CypherQuery("match(n:Gost)-[r:ODJAVA ]->(s:Prostorija)  return n ",
                                                          queryDict, CypherResultMode.Set);

            List<Gost> gosti = ((IRawGraphClient)client).ExecuteGetCypherResults<Gost>(query1).ToList();

            var query2 = new Neo4jClient.Cypher.CypherQuery("match(n:Gost)-[r:ODJAVA ]->(s:Prostorija)  return s ",
                                                         queryDict, CypherResultMode.Set);

            List<Prostorija> prostorije = ((IRawGraphClient)client).ExecuteGetCypherResults<Prostorija>(query2).ToList();

            var query3 = new Neo4jClient.Cypher.CypherQuery("match(n:Gost)-[r:ODJAVA ]->(s:Prostorija) return ID(n)",

                                                           queryDict, CypherResultMode.Set);

            List<String> listaID = ((IRawGraphClient)client).ExecuteGetCypherResults<String>(query3).ToList();


            for (int i = 0; i < odjave.Count; i++)
            {
                gosti[i].idGosta = listaID[i].ToString();
                odjave[i].gost = gosti[i];
                odjave[i].prostorija = prostorije[i];
            }
            
            listaOdjava = odjave;
            foreach (Odjava r in odjave)
            {
               // int result1 = DateTime.Compare(r.datumOdjave, start);//da je datum odjave izmedju dva datuma
               // int result2 = DateTime.Compare(r.datumOdjave, end);
               // string relationship;

               //// if (result1 >= 0 && result2 <= 0)
                {
                    string licno = "ne", osoblje = "ne", uslovi = "ne";
                    if (r.licno.Equals("true"))
                        licno = "da";
                    if (r.osoblje.Equals("true"))
                        osoblje = "da";
                    if (r.uslovi.Equals("true"))
                        uslovi = "da";
                    ListViewItem item = new ListViewItem(new string[] { r.gost.idGosta, r.gost.ime, r.gost.prezime, r.prostorija.brojProstorije.ToString(), r.gost.brojTelefona, r.gost.email, r.gost.dokument, r.datumOd.ToString("dd/MM/yyyy"), r.datumDo.ToString("dd/MM/yyyy"), r.datumOdjave.ToString("dd/MM/yyyy"), licno, osoblje, uslovi });

                    lvOdjava.Items.Add(item);
                }
            }
            lvOdjava.Refresh();


        }
        public Dictionary<string,int> NadjiSveProstorijeZaLoseUslove()
        {
            List<Odjava> uslovi1 = new List<Odjava>();
            foreach(Odjava o in this.listaOdjava)
            {
                if (o.uslovi.Equals("true"))
                    uslovi1.Add(o);
            }


            List<Odjava> uslovi = uslovi1.OrderBy(o => o.prostorija.brojProstorije).ToList();

            Dictionary<string,int> lista = new Dictionary<string, int>();
          
            

               
               var count = 0;
               var cnt = 0;
                for(int i=0;i<uslovi.Count;i+=cnt)
                {
                    
                    var itm = uslovi.ElementAt(i).prostorija.brojProstorije;
                     cnt = uslovi.Count(j => j.prostorija.brojProstorije.Equals(itm, StringComparison.InvariantCultureIgnoreCase));
                 
                        count += cnt;


                    lista.Add("" + itm + "", cnt);
                   //MessageBox.Show(itm + " " + cnt.ToString());
                  // MessageBox.Show(count.ToString());
                        }

            return lista;
         
        }
        private void FormRanijeOdjavljivanje_Load(object sender, EventArgs e)
        {
            DateTime dt1 = new DateTime(2019,1,1);
            DateTime dt2 = new DateTime(2022,1,1);
            start = dt1;
            end = dt2;
            VratiSveGosteKojiSuSeRanijeOdjavili(dt1,dt2);
        }

        private void dtpDatumOd_ValueChanged(object sender, EventArgs e)
        {  DateTime start = dtpDatumOd.Value;
            DateTime end = dtpDatumDo.Value;
            lvOdjava.Items.Clear();

            int result1 = DateTime.Compare(start, end);//da je datum odjave izmedju dva datuma

            string relationship;

            if (result1 >= 0)
            {
                MessageBox.Show("Izaberite validne datume.");
            }
            else VratiSveGosteKojiSuSeRanijeOdjavili(start, end);


        }

        private void button1_Click(object sender, EventArgs e)
        {
            lvProstorije.Items.Clear();
            Dictionary<string, int> lista = NadjiSveProstorijeZaLoseUslove();

            Dictionary<string, object> queryDict = new Dictionary<string, object>();

            var query = new Neo4jClient.Cypher.CypherQuery("match (s:Prostorija)  return s ",
                                                           queryDict, CypherResultMode.Set);

            List<Prostorija> prostorije = ((IRawGraphClient)client).ExecuteGetCypherResults<Prostorija>(query).ToList();
        
        
            foreach(Prostorija i in prostorije)
            {
                if (lista.ContainsKey(i.brojProstorije))
                {
                    ListViewItem item = new ListViewItem(new string[] { i.brojProstorije, i.cena.ToString(), lista[i.brojProstorije].ToString() });

                    lvProstorije.Items.Add(item);
                }

            }
            lvProstorije.Refresh();


        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormRanijeOdjavljivanje_Paint(object sender, PaintEventArgs e)
        {
            {
                e.Graphics.DrawRectangle(new Pen(Color.White, 5),
                                this.DisplayRectangle);
            }
        }
        public void VratiSveGosteKojiSuSeRanijeOdjaili(string email)
        { 
           
            Dictionary<string, object> queryDict = new Dictionary<string, object>();
          //  string email = textBox1.Text;
            var query = new Neo4jClient.Cypher.CypherQuery("match(n:Gost)-[r:ODJAVA ]->(s:Prostorija) where n.email ='"+email+"'  return r ",
                                                           queryDict, CypherResultMode.Set);

            List<Odjava> odjave = ((IRawGraphClient)client).ExecuteGetCypherResults<Odjava>(query).ToList();

            var query1 = new Neo4jClient.Cypher.CypherQuery("match(n:Gost)-[r:ODJAVA ]->(s:Prostorija) where n.email ='"+email+"'  return n ",
                                                          queryDict, CypherResultMode.Set);

            List<Gost> gosti = ((IRawGraphClient)client).ExecuteGetCypherResults<Gost>(query1).ToList();

            var query2 = new Neo4jClient.Cypher.CypherQuery("match(n:Gost)-[r:ODJAVA ]->(s:Prostorija) where n.email ='"+email+"'  return s ",
                                                         queryDict, CypherResultMode.Set);

            List<Prostorija> prostorije = ((IRawGraphClient)client).ExecuteGetCypherResults<Prostorija>(query2).ToList();

            var query3 = new Neo4jClient.Cypher.CypherQuery("match(n:Gost)-[r:ODJAVA ]->(s:Prostorija) where n.email ='"+email+"' return  ID(n)",

                                                           queryDict, CypherResultMode.Set);

            List<String> listaID = ((IRawGraphClient)client).ExecuteGetCypherResults<String>(query3).ToList();


            for (int i = 0; i < odjave.Count; i++)
            {
                gosti[i].idGosta = listaID[i].ToString();
                odjave[i].gost = gosti[i];
                odjave[i].prostorija = prostorije[i];
            }

            listaOdjava = odjave;


            foreach (Odjava r in listaOdjava)
            {
                int result1 = DateTime.Compare(r.datumOdjave, start);
                int result2 = DateTime.Compare(r.datumOdjave, end);
                string relationship;

                if (result1 >= 0 && result2 <= 0 )
                {
                    string licno = "ne", osoblje = "ne", uslovi = "ne";
                    if (r.licno.Equals("true"))
                        licno = "da";
                    if (r.osoblje.Equals("true"))
                        osoblje = "da";
                    if (r.uslovi.Equals("true"))
                        uslovi = "da";
                    ListViewItem item = new ListViewItem(new string[] { r.gost.idGosta, r.gost.ime, r.gost.prezime, r.prostorija.brojProstorije.ToString(), r.gost.brojTelefona, r.gost.email, r.gost.dokument, r.datumOd.ToString("dd/MM/yyyy"), r.datumDo.ToString("dd/MM/yyyy"), r.datumOdjave.ToString("dd/MM/yyyy"), licno, osoblje, uslovi });

                    lvOdjava.Items.Add(item);
                }
            }
            lvOdjava.Refresh();

        }

        private void dtpDatumDo_ValueChanged(object sender, EventArgs e)
        {
            DateTime start = dtpDatumOd.Value;
            DateTime end = dtpDatumDo.Value;
            lvOdjava.Items.Clear();
            int result1 = DateTime.Compare(start, end);//da je datum odjave izmedju dva datuma
           
           

            if (result1 >= 0 )
            {
                MessageBox.Show("Izaberite validne datume.");
            }
            else VratiSveGosteKojiSuSeRanijeOdjavili(start, end);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text.Equals(""))
                VratiSveGosteKojiSuSeRanijeOdjavili(start,end);
            else
            {
                lvOdjava.Items.Clear();
                VratiSveGosteKojiSuSeRanijeOdjaili(textBox1.Text);
            }
        }
    }
}
