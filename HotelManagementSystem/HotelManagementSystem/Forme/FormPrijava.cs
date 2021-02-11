using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HotelManagementSystem.DomainModel;
using Neo4jClient;
using Neo4jClient.Cypher;

namespace HotelManagementSystem.Forme
{
    public partial class FormPrijava : Form
    {
        public GraphClient client;
        public FormPrijava()
        {
            InitializeComponent();
        }

        private void btnPronadjiRez_Click(object sender, EventArgs e)
        {
            pregledRezListView.Items.Clear();
            PopuniPodacima();
           }
        public void PopuniPodacima()
        {
 Dictionary<string, object> queryDict = new Dictionary<string, object>();

            var query = new Neo4jClient.Cypher.CypherQuery("match(n:Gost{email:'"+textBox1.Text+"'})-[r:REZERVACIJA {aktivna:'true'}]->(s:Prostorija)  return r ",
                                                           queryDict, CypherResultMode.Set);

            List<Rezervacija> rezervacije = ((IRawGraphClient)client).ExecuteGetCypherResults<Rezervacija>(query).ToList();

            var query1 = new Neo4jClient.Cypher.CypherQuery("match(n:Gost{email:'" + textBox1.Text + "'})-[r:REZERVACIJA {aktivna:'true'}]->(s:Prostorija)  return n ",
                                                          queryDict, CypherResultMode.Set);

            List<Gost> gosti = ((IRawGraphClient)client).ExecuteGetCypherResults<Gost>(query1).ToList();

            var query2 = new Neo4jClient.Cypher.CypherQuery("match(n:Gost{email:'" + textBox1.Text + "'})-[r:REZERVACIJA {aktivna:'true'}]->(s:Prostorija)  return s ",
                                                         queryDict, CypherResultMode.Set);

            List<Prostorija> prostorije = ((IRawGraphClient)client).ExecuteGetCypherResults<Prostorija>(query2).ToList();

            var query3 = new Neo4jClient.Cypher.CypherQuery("match(n:Gost)-[r:REZERVACIJA{aktivna:'true'}]->(s:Prostorija) return ID(n)",
                                                           queryDict, CypherResultMode.Set);

            List<String> listaID = ((IRawGraphClient)client).ExecuteGetCypherResults<String>(query3).ToList();


            for (int i = 0; i < rezervacije.Count; i++)
            {
                gosti[i].idGosta = listaID[i].ToString();
                rezervacije[i].gost = gosti[i];
                rezervacije[i].prostorija = prostorije[i];
            }
            //List<Soba> sobeZaBrisanje = new List<Soba>(); 

            //listaGostijuPregledGostiju = gosti;
          //  listaRezervacija = rezervacije;
            foreach (Rezervacija r in rezervacije)
            {
                ListViewItem item = new ListViewItem(new string[] { r.gost.idGosta, r.gost.ime, r.gost.prezime, r.prostorija.brojProstorije.ToString(), r.gost.brojTelefona, r.gost.email, r.gost.dokument,r.datumOd.ToString("dd/MM/yyyy"),r.datumDo.ToString("dd/MM/yyyy"),r.datumRezervacije.ToString("dd/MM/yyyy") });

                pregledRezListView.Items.Add(item);

            }
            pregledRezListView.Refresh();


        }
        public void PopuniPodacimaPrijavljeneGoste()
        {
            Dictionary<string, object> queryDict = new Dictionary<string, object>();

            var query = new Neo4jClient.Cypher.CypherQuery("match(n:Gost{email:'" + txtPrijavljeniEmail.Text + "'})-[r:PRIJAVA {aktivna:'true'}]->(s:Prostorija)  return r ",
                                                           queryDict, CypherResultMode.Set);

            List<Prijava> prijave = ((IRawGraphClient)client).ExecuteGetCypherResults<Prijava>(query).ToList();

            var query1 = new Neo4jClient.Cypher.CypherQuery("match(n:Gost{email:'" + txtPrijavljeniEmail.Text + "'})-[r:PRIJAVA {aktivna:'true'} ]->(s:Prostorija)  return n ",
                                                          queryDict, CypherResultMode.Set);

            List<Gost> gosti = ((IRawGraphClient)client).ExecuteGetCypherResults<Gost>(query1).ToList();

            var query2 = new Neo4jClient.Cypher.CypherQuery("match(n:Gost{email:'" + txtPrijavljeniEmail.Text + "'})-[r:PRIJAVA {aktivna:'true'}]->(s:Prostorija)  return s ",
                                                         queryDict, CypherResultMode.Set);

            List<Prostorija> prostorije = ((IRawGraphClient)client).ExecuteGetCypherResults<Prostorija>(query2).ToList();

            var query3 = new Neo4jClient.Cypher.CypherQuery("match(n:Gost)-[r:PRIJAVA {aktivna:'true'}]->(s:Prostorija) return ID(n)",

                                                           queryDict, CypherResultMode.Set);

            List<String> listaID = ((IRawGraphClient)client).ExecuteGetCypherResults<String>(query3).ToList();


            for (int i = 0; i < prijave.Count; i++)
            {
                gosti[i].idGosta = listaID[i].ToString();
                prijave[i].gost = gosti[i];
                prijave[i].prostorija = prostorije[i];
            }
            //List<Soba> sobeZaBrisanje = new List<Soba>(); 

            //listaGostijuPregledGostiju = gosti;
            //  listaRezervacija = rezervacije;
            foreach (Prijava r in prijave)
            {
                ListViewItem item = new ListViewItem(new string[] { r.gost.idGosta, r.gost.ime, r.gost.prezime, r.prostorija.brojProstorije.ToString(), r.gost.brojTelefona, r.gost.email, r.gost.dokument, r.datumOd.ToString("dd/MM/yyyy"), r.datumDo.ToString("dd/MM/yyyy"), r.datumPrijave.ToString("dd/MM/yyyy") });

                lvlPrijava.Items.Add(item);

            }
            lvlPrijava.Refresh();

        }
        private void btnPrijavi_Click(object sender, EventArgs e)
        {
            
            if (pregledRezListView.SelectedItems.Count == 0)
            {
                MessageBox.Show("Morate izabrati rezervaciju.");
                return;
            }
            int br = 0;

            string ime = pregledRezListView.SelectedItems[br].SubItems[1].Text;
            string prezime = pregledRezListView.SelectedItems[br].SubItems[2].Text;
            string brojProst = pregledRezListView.SelectedItems[br].SubItems[3].Text;
        //    string telefon = pregledRezListView.SelectedItems[br].SubItems[4].Text;
          //  string email = pregledRezListView.SelectedItems[br].SubItems[5].Text;
            string dokument = pregledRezListView.SelectedItems[br].SubItems[6].Text;
          //  MessageBox.Show(pregledRezListView.SelectedItems[br].SubItems[7].Text);
            DateTime datumod = DateTime.ParseExact(pregledRezListView.SelectedItems[br].SubItems[7].Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            DateTime datumdo = DateTime.ParseExact(pregledRezListView.SelectedItems[br].SubItems[8].Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            DateTime datumrez = DateTime.ParseExact(pregledRezListView.SelectedItems[br].SubItems[9].Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
           // DateTime datumdo =Convert.ToDateTime( pregledRezListView.SelectedItems[br].SubItems[8].Text);
           // DateTime datumrez=Convert.ToDateTime( pregledRezListView.SelectedItems[br].SubItems[9].Text);
            DateTime datumprijave = DateTime.Today;
            

           var query1 = new Neo4jClient.Cypher.CypherQuery("match (a:Gost),(b:Prostorija  ) WHERE a.dokument = '" 
                                           + dokument + "' AND  b.brojProstorije = '" + brojProst
                                                      + "' CREATE (a)-[r:PRIJAVA{datumOd: date({day:" +datumod.Day
                                                      + ", month: " + datumod.Month + ", year: " + datumod.Year 
                                                      + " }), datumDo: date({day:" + datumdo.Day
                                                      + ", month: " +datumdo.Month + ", year: " + datumdo.Year 
                                                      + " }),datumRezervacije:date({day:" + datumrez.Day + ",month:" 
                                     + datumrez.Month + ",year:" + datumrez.Year + "}),datumPrijave:date({day:" 
                                   + datumprijave.Day + ",month:" + datumprijave.Month + ",year:" + datumprijave.Year 
                                                       + "}),aktivna:'true' }]->(b) return r",
                                                     new Dictionary<string, object>(), CypherResultMode.Set);

            ((IRawGraphClient)client).ExecuteCypher(query1);

            Dictionary<string, object> queryDict = new Dictionary<string, object>();
            var query2 = new Neo4jClient.Cypher.CypherQuery("match(n:Gost{email:'" + textBox1.Text + "'})-[r:REZERVACIJA {aktivna:'true'}]->(s:Prostorija {brojProstorije:'" + brojProst + "'}) SET r.aktivna='false' return r ", queryDict, CypherResultMode.Set);
            ((IRawGraphClient)client).ExecuteCypher(query2);
            if (query1!=null && query2!=null)
             MessageBox.Show("Uspesno ste prijavili gosta.");

           // this.Close();
        }

        private void btnOdjava_Click(object sender, EventArgs e)
        {
            if (lvlPrijava.SelectedItems.Count == 0)
            {
                MessageBox.Show("Morate izabrati prijavu.");
                return;
            }
            int br = 0;// lvlPrijava.SelectedIndices[0];//pregledRezListView.FocusedItem.Index;

             int ocena = Convert.ToInt32(comboBox1.SelectedItem);
          
            string brojProst = lvlPrijava.SelectedItems[br].SubItems[3].Text;
            string dokument = lvlPrijava.SelectedItems[br].SubItems[6].Text;
            DateTime datumod = DateTime.ParseExact(lvlPrijava.SelectedItems[br].SubItems[7].Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);//Convert.ToDateTime(lvlPrijava.SelectedItems[br].SubItems[7].Text);
            DateTime datumdo = DateTime.ParseExact(lvlPrijava.SelectedItems[br].SubItems[8].Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);//Convert.ToDateTime(lvlPrijava.SelectedItems[br].SubItems[8].Text);
            DateTime datumOdjave = DateTime.Today;
            string licno = "false", uslovi = "false", osoblje = "false";
            
            int b1 = 0, b2 = 0, b3 = 0;
            if (cmbOdjava.SelectedItem.Equals("Licni razlozi"))// .Checked)
            {
                licno = "true";
                b1++;
            }
            if (cmbOdjava.SelectedItem.Equals("Neprofesionalno osoblje"))
            {
                osoblje = "true";
                b2++;
            }
            if (cmbOdjava.SelectedItem.Equals("Losi uslovi"))
            {
                uslovi = "true";
                b3++;
            }
            
            if ((b1 == 0) && (b2 == 0) && (b3 == 0))
            {
                MessageBox.Show("Izaberite razlog ranijeg odjavljivanja.");
                return;
            }


          

            var query1 = new Neo4jClient.Cypher.CypherQuery("match (a:Gost),(b:Prostorija  ) WHERE a.dokument = '" + dokument + "'  AND  b.brojProstorije = '" + brojProst 
                + "' CREATE (a)-[r:ODJAVA{datumOd: date({day:" + datumod.Day
                    + ", month: " + datumod.Month + ", year: " + datumod.Year + " }), datumDo: date({day:" + datumdo.Day
                    + ", month: " + datumdo.Month + ", year: " + datumdo.Year + " }),datumOdjave:date({day:" + datumOdjave.Day + ",month:" + datumOdjave.Month + ",year:" + datumOdjave.Year + "}),ocena:"+ocena+", uslovi:'"+uslovi+"',licno:'"+licno+"',osoblje:'" +osoblje+"',komentar:'"+txtKomentar.Text+"'}]->(b) return r",
                                                          new Dictionary<string, object>(), CypherResultMode.Set);
            ((IRawGraphClient)client).ExecuteCypher(query1);


            //match(n: Gost{ email: 'sa'})-[r: REZERVACIJA{ aktivna: 'true'} ]->(s: Prostorija) set r.aktivna = 'false'  return r
            Dictionary<string, object> queryDict = new Dictionary<string, object>();

            var query2 = new Neo4jClient.Cypher.CypherQuery("match(n:Gost{email:'" + txtPrijavljeniEmail.Text + "'})-[r:REZERVACIJA {aktivna:'true'}]->(s:Prostorija {brojProstorije:'"+brojProst+"'}) SET r.aktivna='false' return r ", queryDict, CypherResultMode.Set);
            var query3 = new Neo4jClient.Cypher.CypherQuery("match(n:Gost{email:'" + txtPrijavljeniEmail.Text + "'})-[r:PRIJAVA {aktivna:'true'}]->(s:Prostorija {brojProstorije:'"+brojProst+"'}) SET r.aktivna='false' return r ", queryDict, CypherResultMode.Set);

            ((IRawGraphClient)client).ExecuteCypher(query2);
            ((IRawGraphClient)client).ExecuteCypher(query3);

            if (query1 != null && query2 != null && query3 != null)
                MessageBox.Show("Uspesno ste odjavili gosta.");
        }

        private void btnPronadjiPrijave_Click(object sender, EventArgs e)
        {
            lvlPrijava.Items.Clear();
            PopuniPodacimaPrijavljeneGoste();
        }

        private void FormPrijava_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawRectangle(new Pen(Color.White, 5),
                            this.DisplayRectangle);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
