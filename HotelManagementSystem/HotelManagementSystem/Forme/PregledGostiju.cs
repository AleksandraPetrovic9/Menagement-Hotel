using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HotelManagementSystem;
using Neo4jClient;
using HotelManagementSystem.DomainModel;
using Neo4jClient.Cypher;

namespace HotelManagementSystem.Forme
{
    public partial class PregledGostiju : Form
    {
        public GraphClient client;
      //  List<Rezervacija> listaRezervacija = new List<Rezervacija>();
        List<Prijava> listaPrijava = new List<Prijava>();
        public PregledGostiju()
        {
            InitializeComponent();
            filterComboBox.SelectedItem = filterComboBox.Items[0];
            //pregledGostijuListView.Refresh();

        }
        private void PopuniPodacima()
        {
            pregledGostijuListView.Items.Clear();

            Dictionary<string, object> queryDict = new Dictionary<string, object>();


            var query = new Neo4jClient.Cypher.CypherQuery("match(n:Gost)-[r:PRIJAVA{aktivna:'true'}]->(s:Prostorija) return n",
                                                            queryDict, CypherResultMode.Set);

            List<Gost> gosti = ((IRawGraphClient)client).ExecuteGetCypherResults<Gost>(query).ToList();

            var query1 = new Neo4jClient.Cypher.CypherQuery("match(n:Gost)-[r:PRIJAVA{aktivna:'true'}]->(s:Prostorija) return ID(n)",
                                                            queryDict, CypherResultMode.Set);

            List<String> listaID = ((IRawGraphClient)client).ExecuteGetCypherResults<String>(query1).ToList();

            var query2 = new Neo4jClient.Cypher.CypherQuery("match(n:Gost)-[r:PRIJAVA{aktivna:'true'}]->(s:Prostorija) return s",
                                                            queryDict, CypherResultMode.Set);
            List<Prostorija> sobe = ((IRawGraphClient)client).ExecuteGetCypherResults<Prostorija>(query2).ToList();

            var query3 = new Neo4jClient.Cypher.CypherQuery("match(n:Gost)-[r:PRIJAVA{aktivna:'true'}]->(s:Prostorija) return r",
                                                            queryDict, CypherResultMode.Set);

            List<Prijava> prijave = ((IRawGraphClient)client).ExecuteGetCypherResults<Prijava>(query3).ToList();


            for (int i = 0; i < prijave.Count; i++)
            {
                gosti[i].idGosta = listaID[i].ToString();
                prijave[i].gost = gosti[i];
                prijave[i].prostorija = sobe[i];
            }
            //List<Soba> sobeZaBrisanje = new List<Soba>(); 

            //listaGostijuPregledGostiju = gosti;
            listaPrijava = prijave;
            foreach (Prijava r in prijave)
            {
                ListViewItem item = new ListViewItem(new string[] { r.gost.idGosta, r.gost.ime, r.gost.prezime, r.prostorija.brojProstorije.ToString(), r.gost.brojTelefona, r.gost.email, r.gost.dokument });

                pregledGostijuListView.Items.Add(item);

            }
            pregledGostijuListView.Refresh();
        }
        private void PregledGostiju_Load(object sender, EventArgs e)
        {

            this.PopuniPodacima();


        }



        private void azurirajButton_Click(object sender, EventArgs e)
        {
            //Gost gostZaAzuriranje;
            if (pregledGostijuListView.SelectedItems.Count == 0)
            {
                MessageBox.Show("Odaberite gosta!");
                return;
            }
            if (pregledGostijuListView.SelectedItems.Count > 1)
            {
                MessageBox.Show("Odaberite samo jednog gosta!");
                return;
            }

            String id = pregledGostijuListView.SelectedItems[0].Text;
            //MessageBox.Show(id);
            //Gost gostZaAzuriranje = new Gost();
            foreach (Prijava r in listaPrijava.ToList())
            {
                if (r.gost.idGosta == id)
                {
                    AzuriranjeGosta azurirajForma = new AzuriranjeGosta(r, this);
                    azurirajForma.client = client;
                    if (azurirajForma.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        this.PopuniPodacima();
                    }
                }
            }



        }

        private void izbrisiButton_Click(object sender, EventArgs e)
        {
            Dictionary<string, object> queryDict = new Dictionary<string, object>();

            if (pregledGostijuListView.SelectedItems.Count == 0)
            {
                MessageBox.Show("Odaberite gosta!");
                return;
            }

          /*  foreach (ListViewItem item in pregledGostijuListView.SelectedItems)
            {
                MessageBox.Show(item.Text);
            }*/
            List<int> listaID = new List<int>();
            foreach (ListViewItem item in pregledGostijuListView.SelectedItems)
            {
                int id = Convert.ToInt32(item.Text);

                //obrisi gosta i rezervaciju/e detach

                var query = new Neo4jClient.Cypher.CypherQuery("match(n:Gost)-[r:PRIJAVA]->(s:Prostorija) WHERE ID(n)=" + id + " detach delete n", queryDict, CypherResultMode.Projection);
                ((IRawGraphClient)client).ExecuteCypher(query);
                //obrisi gosta/e 


            }

            this.PopuniPodacima();

        }
        private void Filtriraj()
        {
            pregledGostijuListView.Items.Clear();

            string filterListe = filterComboBox.SelectedItem.ToString();
            //pregledGostijuListView.Items.AddRange(Items.Where(i => string.IsNullOrEmpty(textBox1.Text) || i.Name.StartsWith(textBox1.Text))
            //            .Select(c => new ListViewItem(c.Name)).ToArray());

            this.FiltrirajPoParametru(filterListe);
        }

        private void FiltrirajPoParametru(string filterListe)
        {

            foreach (Prijava r in listaPrijava)
            {
                if (filterListe == "Ime")
                {
                    if (r.gost.ime.ToLower().Contains(textBoxFilter.Text.ToLower()))
                    {
                        ListViewItem item = new ListViewItem(new string[] { r.gost.idGosta, r.gost.ime, r.gost.prezime, r.prostorija.brojProstorije.ToString(), r.gost.brojTelefona, r.gost.email, r.gost.dokument });
                        pregledGostijuListView.Items.Add(item);
                    }
                }
                if (filterListe == "Prezime")
                {
                    if (r.gost.prezime.ToLower().Contains(textBoxFilter.Text.ToLower()))
                    {
                        ListViewItem item = new ListViewItem(new string[] { r.gost.idGosta, r.gost.ime, r.gost.prezime, r.prostorija.brojProstorije.ToString(), r.gost.brojTelefona, r.gost.email, r.gost.dokument });
                        pregledGostijuListView.Items.Add(item);
                    }
                }
                if (filterListe == "Broj prostorije")
                {
                    if (r.prostorija.brojProstorije.ToString().ToLower().Equals(textBoxFilter.Text.ToLower()))
                    {
                        ListViewItem item = new ListViewItem(new string[] { r.gost.idGosta, r.gost.ime, r.gost.prezime, r.prostorija.brojProstorije.ToString(), r.gost.brojTelefona, r.gost.email, r.gost.dokument });
                        pregledGostijuListView.Items.Add(item);
                    }
                }
                pregledGostijuListView.Refresh();
            }

        }
        private void textBoxFilter_KeyPress(object sender, KeyPressEventArgs e)
        {
            //this.Filtriraj();
        }

        private void textBoxFilter_TextChanged(object sender, EventArgs e)
        {
            this.Filtriraj();
        }

        private void izbrisiButton_Click_1(object sender, EventArgs e)
        {
            Dictionary<string, object> queryDict = new Dictionary<string, object>();

            if (pregledGostijuListView.SelectedItems.Count == 0)
            {
                MessageBox.Show("Odaberite gosta!");
                return;
            }

          /*  foreach (ListViewItem item in pregledGostijuListView.SelectedItems)
            {
                MessageBox.Show(item.Text);
            }*/
            List<int> listaID = new List<int>();
            foreach (ListViewItem item in pregledGostijuListView.SelectedItems)
            {
                int id = Convert.ToInt32(item.Text);

                //obrisi gosta i rezervaciju/e detach

                var query = new Neo4jClient.Cypher.CypherQuery("match(n:Gost)-[r:PRIJAVA]->(s:Prostorija) WHERE ID(n)=" + id + " detach delete n", queryDict, CypherResultMode.Projection);
                ((IRawGraphClient)client).ExecuteCypher(query);
                //obrisi gosta/e 


            }

            this.PopuniPodacima();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void PregledGostiju_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawRectangle(new Pen(Color.White, 5),
                           this.DisplayRectangle);
        }
    }
}
