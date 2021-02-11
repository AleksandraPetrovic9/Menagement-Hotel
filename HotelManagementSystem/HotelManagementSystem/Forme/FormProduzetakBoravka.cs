using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Neo4jClient;
using HotelManagementSystem.DomainModel;
using Neo4jClient.Cypher;
using System.Globalization;

namespace HotelManagementSystem.Forme
{
    public partial class FormProduzetakBoravka : Form
    {
        public GraphClient client;
        public FormProduzetakBoravka()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Dictionary<string, object> queryDict = new Dictionary<string, object>();
            if (lvlPrijava.SelectedItems.Count == 0)
            {
                MessageBox.Show("Morate izabrati prijavu.");
                return;
            }

            int br = 0;

            string ime = lvlPrijava.SelectedItems[br].SubItems[1].Text;
            string prezime = lvlPrijava.SelectedItems[br].SubItems[2].Text;
            string brojProst = lvlPrijava.SelectedItems[br].SubItems[3].Text;
            //    string telefon = pregledRezListView.SelectedItems[br].SubItems[4].Text;
            //  string email = pregledRezListView.SelectedItems[br].SubItems[5].Text;
            string dokument = lvlPrijava.SelectedItems[br].SubItems[6].Text;
            //  MessageBox.Show(pregledRezListView.SelectedItems[br].SubItems[7].Text);
            DateTime datumod = DateTime.ParseExact(lvlPrijava.SelectedItems[br].SubItems[7].Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            DateTime datumdo = DateTime.ParseExact(lvlPrijava.SelectedItems[br].SubItems[8].Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            DateTime datumrez = DateTime.ParseExact(lvlPrijava.SelectedItems[br].SubItems[9].Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            // DateTime datumdo =Convert.ToDateTime( pregledRezListView.SelectedItems[br].SubItems[8].Text);
            // DateTime datumrez=Convert.ToDateTime( pregledRezListView.SelectedItems[br].SubItems[9].Text);
            DateTime datumprijave = DateTime.Today;
            DateTime produzetak = dtpProduzetak.Value;//.ToString("dd/MM/yyyy");


            /*match(n:Gost{dokument:'se'})-[r:PRIJAVA ]->(s:Prostorija{brojProstorije:'03'}) set r.datumDo='21/09/2020'  return r*/
            var query = new Neo4jClient.Cypher.CypherQuery("match(n:Gost{dokument:'" + dokument + "'})-[r:PRIJAVA]->(s:Prostorija{brojProstorije:'" + brojProst + "'}) set r.datumDo='" + produzetak + "'  return r ",
                                                                     queryDict, CypherResultMode.Set);

           ((IRawGraphClient)client).ExecuteCypher(query);
            if (query != null)
                MessageBox.Show("Uspesno ste produzili boravak gosta");
            lvlPrijava.Items.Clear();
            PopuniPodatke();
        
        
        }
        public void PopuniPodatke()
        {
            Dictionary<string, object> queryDict = new Dictionary<string, object>();
            if (txtGost.Text.Equals(""))
            {
                MessageBox.Show("Unesite e-mail gosta.");
                return;
            }
            var query = new Neo4jClient.Cypher.CypherQuery("match(n:Gost{email:'" + txtGost.Text + "'})-[r:PRIJAVA {aktivna:'true'}]->(s:Prostorija)  return r ",
                                                           queryDict, CypherResultMode.Set);

            List<Prijava> prijave = ((IRawGraphClient)client).ExecuteGetCypherResults<Prijava>(query).ToList();

            var query1 = new Neo4jClient.Cypher.CypherQuery("match(n:Gost{email:'" + txtGost.Text + "'})-[r:PRIJAVA {aktivna:'true'} ]->(s:Prostorija)  return n ",
                                                          queryDict, CypherResultMode.Set);

            List<Gost> gosti = ((IRawGraphClient)client).ExecuteGetCypherResults<Gost>(query1).ToList();

            var query2 = new Neo4jClient.Cypher.CypherQuery("match(n:Gost{email:'" + txtGost.Text + "'})-[r:PRIJAVA {aktivna:'true'}]->(s:Prostorija)  return s ",
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
        private void btnPronadjiRez_Click(object sender, EventArgs e)
        {
            lvlPrijava.Items.Clear();
            PopuniPodatke();
            lvlPrijava.Refresh();
           
        }
    }
}
