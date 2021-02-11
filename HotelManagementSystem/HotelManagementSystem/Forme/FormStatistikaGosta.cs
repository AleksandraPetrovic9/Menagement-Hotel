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
using System.Windows.Forms.DataVisualization.Charting;

namespace HotelManagementSystem.Forme
{
    public partial class FormStatistikaGosta : Form
    {
        public GraphClient client;
        public Gost gost;
        public FormStatistikaGosta(Gost g)
        {
            InitializeComponent();
            this.gost = g;
          //  MessageBox.Show(this.gost.ime);
        }
       
        public Dictionary<string,int> NadjiSvePrijaveGosta(Gost gost)
        {

            Dictionary<string, object> queryDict = new Dictionary<string, object>();

            var query = new Neo4jClient.Cypher.CypherQuery("match(n:Gost{email:'" + gost.email + "'})-[r:REZERVACIJA]->(s:Prostorija)  return r ",
                                                           queryDict, CypherResultMode.Set);

            List<Rezervacija> rezervacije = ((IRawGraphClient)client).ExecuteGetCypherResults<Rezervacija>(query).ToList();

            //var query1 = new Neo4jClient.Cypher.CypherQuery("match(n:Gost{email:'" + gost.email + "'})-[r:REZERVACIJA]->(s:Prostorija)  return n ",
            //                                              queryDict, CypherResultMode.Set);

            //List<Gost> gosti = ((IRawGraphClient)client).ExecuteGetCypherResults<Gost>(query1).ToList();

            //var query2 = new Neo4jClient.Cypher.CypherQuery("match(n:Gost{email:'" + gost.email + "'})-[r:REZERVACIJA]->(s:Prostorija)  return s ",
            //                                             queryDict, CypherResultMode.Set);

            //List<Prostorija> prostorije = ((IRawGraphClient)client).ExecuteGetCypherResults<Prostorija>(query2).ToList();

            //var query3 = new Neo4jClient.Cypher.CypherQuery("match(n:Gost{email:'" + gost.email + "'})-[r:REZERVACIJA]->(s:Prostorija) return ID(n)",
            //                                               queryDict, CypherResultMode.Set);

            //List<String> listaID = ((IRawGraphClient)client).ExecuteGetCypherResults<String>(query3).ToList();


            //for (int i = 0; i < rezervacije.Count; i++)
            //{
            //    gosti[i].idGosta = listaID[i].ToString();
            //    rezervacije[i].gost = gosti[i];
            //    rezervacije[i].prostorija = prostorije[i];
            //}

            ////da nadje sve prijave 
            var query4 = new Neo4jClient.Cypher.CypherQuery("MATCH (g:Gost )-[r:REZERVACIJA ]->(s:Prostorija) <-[p:PRIJAVA]->(gg: Gost) where g.email=gg.email and g.email='"+gost.email+"' and  r.datumOd=p.datumOd AND r.datumDo=p.datumDo  RETURN p ",
                                                          queryDict, CypherResultMode.Set);

            List<Prijava> prijave1 = ((IRawGraphClient)client).ExecuteGetCypherResults<Prijava>(query4).ToList();


            var query5 = new Neo4jClient.Cypher.CypherQuery("MATCH (g:Gost )-[r:REZERVACIJA ]->(s:Prostorija) <-[p:PRIJAVA]->(gg: Gost) where g.email=gg.email and g.email='" + gost.email + "' and  r.datumOd=p.datumOd AND r.datumDo=p.datumDo   return g ",
                                                                     queryDict, CypherResultMode.Set);

            List<Gost> gosti1 = ((IRawGraphClient)client).ExecuteGetCypherResults<Gost>(query5).ToList();

            var query6 = new Neo4jClient.Cypher.CypherQuery("MATCH (g:Gost )-[r:REZERVACIJA ]->(s:Prostorija) <-[p:PRIJAVA]->(gg: Gost) where g.email=gg.email and g.email='" + gost.email + "' and  r.datumOd=p.datumOd AND r.datumDo=p.datumDo  RETURN  s ",
                                                         queryDict, CypherResultMode.Set);

            List<Prostorija> prostorije1 = ((IRawGraphClient)client).ExecuteGetCypherResults<Prostorija>(query6).ToList();

            var query7 = new Neo4jClient.Cypher.CypherQuery("MATCH (g:Gost )-[r:REZERVACIJA ]->(s:Prostorija) <-[p:PRIJAVA]->(gg: Gost) where g.email=gg.email and g.email='" + gost.email + "' and  r.datumOd=p.datumOd AND r.datumDo=p.datumDo  RETURN  ID(g)",
                                                           queryDict, CypherResultMode.Set);

            List<String> listaID1 = ((IRawGraphClient)client).ExecuteGetCypherResults<String>(query7).ToList();


            for (int i = 0; i < prijave1.Count; i++)
            {
                gosti1[i].idGosta = listaID1[i].ToString();
                prijave1[i].gost = gosti1[i];
                prijave1[i].prostorija = prostorije1[i];
            }
            int br = 0;
            int troskovi = 0;
            //   MessageBox.Show(prijave1.Count.ToString()+",rez:"+rezervacije.Count.ToString());
            //foreach (Rezervacija r in rezervacije)
            //{
            foreach (Prijava p in prijave1)
            {
                //if (p.gost.email.Equals(r.gost.email))
                //    if (p.prostorija.brojProstorije.Equals(r.prostorija.brojProstorije))
                //        if (p.datumOd.ToString("dd/MM/yyyy").Equals(r.datumOd.ToString("dd/MM/yyyy")))
                //            if (p.datumDo.ToString("dd/MM/yyyy").Equals(r.datumDo.ToString("dd/MM/yyyy")))
                            {
                                br++;
                                troskovi += p.prostorija.cena * (GetWorkingDays(p.datumOd, p.datumDo));

                            }


                //    }

            }

            int ukupnoRezervacije = rezervacije.Count();
            int procenatPrijavljenihRez = prijave1.Count() * 100 / ukupnoRezervacije;
            //MessageBox.Show("UKUPNO REZ:" + ukupnoRezervacije.ToString());
            //MessageBox.Show("PROCENAT PRIJAVLJENIH:" + procenatPrijavljenihRez.ToString());
            //MessageBox.Show("prijava:" + prijave1.Count().ToString());
            Dictionary<string, int> hash = new Dictionary<string, int>();
            hash.Add("prosek", procenatPrijavljenihRez);
            hash.Add("troskovi", troskovi);
            return hash;

        }
        public Dictionary<string,string> ProsekBrojaDanaBoravka()
        {

            Dictionary<string, object> queryDict = new Dictionary<string, object>();

            var query = new Neo4jClient.Cypher.CypherQuery("match(n:Gost{email:'" + gost.email + "'})-[r:PRIJAVA]->(s:Prostorija)  return r ",
                                                           queryDict, CypherResultMode.Set);

            List<Prijava> prijave = ((IRawGraphClient)client).ExecuteGetCypherResults<Prijava>(query).ToList();

            var query1 = new Neo4jClient.Cypher.CypherQuery("match(n:Gost{email:'" + gost.email + "'})-[r:PRIJAVA]->(s:Prostorija)  return n ",
                                                          queryDict, CypherResultMode.Set);

            List<Gost> gosti = ((IRawGraphClient)client).ExecuteGetCypherResults<Gost>(query1).ToList();

            var query2 = new Neo4jClient.Cypher.CypherQuery("match(n:Gost{email:'" + gost.email + "'})-[r:PRIJAVA]->(s:Prostorija)  return s ",
                                                         queryDict, CypherResultMode.Set);

            List<Prostorija> prostorije = ((IRawGraphClient)client).ExecuteGetCypherResults<Prostorija>(query2).ToList();

            var query3 = new Neo4jClient.Cypher.CypherQuery("match(n:Gost{email:'" + gost.email + "'})-[r:PRIJAVA]->(s:Prostorija) return ID(n)",
                                                           queryDict, CypherResultMode.Set);

            List<String> listaID = ((IRawGraphClient)client).ExecuteGetCypherResults<String>(query3).ToList();


            for (int i = 0; i < prijave.Count; i++)
            {
                gosti[i].idGosta = listaID[i].ToString();
                prijave[i].gost = gosti[i];
                prijave[i].prostorija = prostorije[i];
            }

            //da nadje sve prijave 
            var query4 = new Neo4jClient.Cypher.CypherQuery("match(n:Gost{email:'" + gost.email + "'})-[r:ODJAVA]->(s:Prostorija)  return r ",
                                                           queryDict, CypherResultMode.Set);

            List<Odjava> odjave = ((IRawGraphClient)client).ExecuteGetCypherResults<Odjava>(query4).ToList();


            var query5 = new Neo4jClient.Cypher.CypherQuery("match(n:Gost{email:'" + gost.email + "'})-[r:ODJAVA]->(s:Prostorija)  return n ",
                                                                     queryDict, CypherResultMode.Set);

            List<Gost> gosti1 = ((IRawGraphClient)client).ExecuteGetCypherResults<Gost>(query5).ToList();

            var query6 = new Neo4jClient.Cypher.CypherQuery("match(n:Gost{email:'" + gost.email + "'})-[r:ODJAVA]->(s:Prostorija)  return s ",
                                                         queryDict, CypherResultMode.Set);

            List<Prostorija> prostorije1 = ((IRawGraphClient)client).ExecuteGetCypherResults<Prostorija>(query6).ToList();

            var query7 = new Neo4jClient.Cypher.CypherQuery("match(n:Gost{email:'" + gost.email + "'})-[r:ODJAVA]->(s:Prostorija) return ID(n)",
                                                           queryDict, CypherResultMode.Set);

            List<String> listaID1 = ((IRawGraphClient)client).ExecuteGetCypherResults<String>(query7).ToList();


            for (int i = 0; i < odjave.Count; i++)
            {
                gosti1[i].idGosta = listaID1[i].ToString();
                odjave[i].gost = gosti1[i];
                odjave[i].prostorija = prostorije1[i];
            }
            int br = 0;
            Dictionary<string, string> hash = new Dictionary<string, string>();
            int brojDana = 0;
            int k = 1;
            foreach (Prijava r in prijave)
            {
                foreach (Odjava p in odjave)
                {
                    if (p.gost.email.Equals(r.gost.email))
                        if (p.prostorija.brojProstorije.Equals(r.prostorija.brojProstorije))
                            if (p.datumOd.ToString("dd/MM/yyyy").Equals(r.datumOd.ToString("dd/MM/yyyy")))
                                if (p.datumDo.ToString("dd/MM/yyyy").Equals(r.datumDo.ToString("dd/MM/yyyy")))
                                {
                                    int result = DateTime.Compare(p.datumOdjave, r.datumDo);
                                    string relationship;

                                    if (result < 0)
                                    {

                                        br++;
                                       // MessageBox.Show("Ranije se odjavio");
                                        hash.Add("uslovi"+br.ToString(),  p.uslovi);
                                        //MessageBox.Show(hash["uslovi1"]);
                                        hash.Add("licno"+br.ToString(),  p.licno);
                                        hash.Add("osoblje"+br.ToString(),  p.osoblje);
                                        

                                    }

                                }
                                
                 //    TimeSpan difference = p.datumDo - p.datumOd;
                   //                 MessageBox.Show(difference.ToString());
                                    brojDana += GetWorkingDays(p.datumOd, p.datumDo);
                 
                                    k++;
                } 
               
            }

            brojDana /= k;
            hash.Add("dani", brojDana.ToString());
            return hash;
        }
        public int GetWorkingDays(DateTime from, DateTime to)
        {
            var totalDays = 0;
            for (var date = from; date <= to; date = date.AddDays(1))
            {
                if (date.DayOfWeek != DayOfWeek.Saturday
                    && date.DayOfWeek != DayOfWeek.Sunday)
                    totalDays++;
            }

            return totalDays;
        }
        private void FormPopust_Load(object sender, EventArgs e)
        {
           
          Dictionary<string,int> hash1= NadjiSvePrijaveGosta(this.gost);
            int procenat = hash1["prosek"];
            int troskovi = hash1["troskovi"];
            Title title = chartRezPrijavilo.Titles.Add("U procentima koliko puta je napravio rezervaciju i prijavio se  u hotel");
            title.ForeColor = System.Drawing.Color.FromArgb(255, 255, 255);
            chartRezPrijavilo.Series["Series1"].IsValueShownAsLabel = true;

            chartRezPrijavilo.Series["Series1"].Points.AddXY("Prijavljeni", procenat);
            chartRezPrijavilo.Series["Series1"].Points.AddXY("Neprijavljeno", 100 - procenat);


            Dictionary<string, string> hash = ProsekBrojaDanaBoravka();

            int br = hash.Count() / 3;
            //  MessageBox.Show(br.ToString() + " se odjavio ranije");
            label1.Text = "Gost se " + br.ToString() + " puta odjavio ranije.";
            label2.Text = "U proseku je proveo " + hash["dani"] + " dana u hotelu.";
            label3.Text = "Potrosio je " + troskovi.ToString() ;
          
            string uslovi = "ne", licno = "ne", osoblje = "ne";

            for (int i=1;i<=br;i++)
            {
                if (hash["uslovi" + br.ToString()].Equals("true"))
                    uslovi = "da";
                if (hash["osoblje" + br.ToString()].Equals("true"))
                    osoblje = "da";
                if (hash["licno" + br.ToString()].Equals("true"))
                    licno = "da";
                ListViewItem item = new ListViewItem(new string[] {licno,uslovi,osoblje});

                lvRazlog.Items.Add(item);

            }
            lvRazlog.Refresh();


        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormStatistikaGosta_Paint(object sender, PaintEventArgs e)
        {
           
                e.Graphics.DrawRectangle(new Pen(Color.White, 5),
                                this.DisplayRectangle);
            
        }
    }
}
