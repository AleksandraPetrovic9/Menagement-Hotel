using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HotelManagementSystem.DomainModel;
using Neo4jClient;
using Neo4jClient.Cypher;

namespace HotelManagementSystem
{
    public partial class PregledSobe : Form
    {
        public GraphClient client;
        public int prostorija;
        public bool izmeni
        {
            get { return izmeni; }
            set { izmeni = false; } 
        }
        public PregledSobe()
        {
            InitializeComponent();
        }
        public PregledSobe(int prostorija)
        {
            this.prostorija = prostorija;
            
            InitializeComponent();
        }

        private void PregledSobe_Load(object sender, EventArgs e)
        {
            if (prostorija == 1)
            {
                listView1.Columns.Add("Broj sobe");
                listView1.Columns.Add("Sprat");
                listView1.Columns.Add("Broj kreveta");
                listView1.Columns.Add("Cena nocenja");
                listView1.Columns.Add("Klima");
                listView1.Columns.Add("TV");
                listView1.Columns.Add("Terasa");
                this.ucitajSobe();
                label3.Visible = true;
                txtPoKlimi.Visible = true;
                btnObrisi.Text += " sobu";
                button1.Text += " sobu";
                btnIzmeni.Text += " sobu";
                label1.Text += "sobe";
                btnGostiZaSobu.Text += "sobe";

            }
            else if (prostorija == 2)
            {
                this.ucitajSale();
                label3.Visible = false;
                txtPoKlimi.Visible = false;
                btnObrisi.Text += " salu";
                button1.Text += " salu";
                btnIzmeni.Text += " salu";
                label1.Text += "sale";
                btnGostiZaSobu.Text += "sale";

                listView1.Columns.Add("Broj sale");
                listView1.Columns.Add("Kapacitet sale");
                listView1.Columns.Add("Cena sale");
            }
            else if (prostorija == 3)
            {
                this.ucitajRestorane();
                label3.Visible = false;
                txtPoKlimi.Visible = false;
                btnObrisi.Text += " restoran";
                button1.Text += " restoran";
                btnIzmeni.Text += " restoran";
                label1.Text += "restoran";
                btnGostiZaSobu.Text += "restoran";

                listView1.Columns.Add("Broj restorana");
                listView1.Columns.Add("Kapacitet restorana");
                listView1.Columns.Add("Cena restorana");
            }
            else if (prostorija == 4)
            {
                this.ucitajBazene();
                label3.Visible = false;
                txtPoKlimi.Visible = false;
                btnObrisi.Text += " bazen";
                button1.Text += " bazen";
                btnIzmeni.Text += " bazen";
                label1.Text += "bazen";
                btnGostiZaSobu.Text += "bazen";

                listView1.Columns.Add("Broj bazena");
                listView1.Columns.Add("Tip bazena");
                listView1.Columns.Add("Cena bazena");
            }
        }

        private void button1_Click(object sender, EventArgs e)//dodaj
        {
            DodajSobu dodajSobu = new DodajSobu(this.prostorija);
            dodajSobu.client = client;
            //  dodajSobu.ShowDialog();
            if (dodajSobu.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                if (this.prostorija == 1)
                    ucitajSobe();
                else if (this.prostorija == 2)
                    ucitajSale();
                else if (this.prostorija == 3)
                    ucitajRestorane();
                else if (this.prostorija == 4)
                    ucitajBazene();
            }

        }

        private void btnObrisi_Click(object sender, EventArgs e)
        {
            if(listView1.SelectedItems.Count==0)
            {
                MessageBox.Show("Odaberite sobu koju zelite da izbrisete.");
                return;
            }

            string brojProstorije = listView1.SelectedItems[0].SubItems[0].Text.ToString();

            Dictionary<string, object> queryDict = new Dictionary<string, object>();
            queryDict.Add("brojProstorije", brojProstorije);

            if (this.prostorija == 1)
            {
                var query = new Neo4jClient.Cypher.CypherQuery("start n=node(*) where (n:Soba) and exists(n.brojProstorije) " +
                                                                "and n.brojProstorije =~ {brojProstorije} detach delete n",
                                                              queryDict, CypherResultMode.Projection);

                List<Soba> sobe = ((IRawGraphClient)client).ExecuteGetCypherResults<Soba>(query).ToList();
                ucitajSobe();
            }
            else if (this.prostorija == 2)
            {
                var query = new Neo4jClient.Cypher.CypherQuery("start n=node(*) where (n:Sala) and exists(n.brojProstorije) and n.brojProstorije =~ {brojProstorije} detach delete n",
                                                             queryDict, CypherResultMode.Projection);

                List<Sala> sale = ((IRawGraphClient)client).ExecuteGetCypherResults<Sala>(query).ToList();
                ucitajSale();
            }
            else if (this.prostorija == 3)
            {
                var query = new Neo4jClient.Cypher.CypherQuery("start n=node(*) where (n:Restoran) and exists(n.brojProstorije) and n.brojProstorije =~ {brojProstorije} detach delete n",
                                                             queryDict, CypherResultMode.Projection);

                List<Restoran> sale = ((IRawGraphClient)client).ExecuteGetCypherResults<Restoran>(query).ToList();
                ucitajRestorane();
            }
            else if (this.prostorija == 4)
            {
                var query = new Neo4jClient.Cypher.CypherQuery("start n=node(*) where (n:Bazen) and exists(n.brojProstorije) and n.brojProstorije =~ {brojProstorije} detach delete n",
                                                             queryDict, CypherResultMode.Projection);

                List<Bazen> sale = ((IRawGraphClient)client).ExecuteGetCypherResults<Bazen>(query).ToList();
                ucitajBazene();
            }
        }

        private void btnIzmeni_Click(object sender, EventArgs e)
        {
            //izmeni = true;
            if (listView1.SelectedItems.Count == 0)
            {
                MessageBox.Show("Odaberite sobu koju zelite da izmenite.");
                return;
            }

            String brojProstorije = listView1.SelectedItems[0].Text;
       

            Dictionary<string, object> queryDict = new Dictionary<string, object>();
            queryDict.Add("brojProstorije", brojProstorije);
            Soba soba;
            Sala sala;
            Restoran restoran;
            Bazen bazen;
            IzmeniSobu izmeniprostoriju = null;

            if (this.prostorija == 1)
            {
                var query = new Neo4jClient.Cypher.CypherQuery("start n=node(*) where (n:Soba) and exists(n.brojProstorije) and n.brojProstorije =~ {brojProstorije} return n",
                                                              queryDict, CypherResultMode.Set);

                List<Soba> sobe = ((IRawGraphClient)client).ExecuteGetCypherResults<Soba>(query).ToList();

                soba = sobe.ElementAt(0);
                izmeniprostoriju = new IzmeniSobu(soba);
            }
            else if (this.prostorija == 2)
            {
                var query = new Neo4jClient.Cypher.CypherQuery("start n=node(*) where (n:Sala) and exists(n.brojProstorije) and n.brojProstorije =~ {brojProstorije} return n",
                                                             queryDict, CypherResultMode.Set);

                List<Sala> sale = ((IRawGraphClient)client).ExecuteGetCypherResults<Sala>(query).ToList();

                sala = sale.ElementAt(0);
                izmeniprostoriju = new IzmeniSobu(sala);
            }
            else if (this.prostorija == 3)
            {
                var query = new Neo4jClient.Cypher.CypherQuery("start n=node(*) where (n:Restoran) and exists(n.brojProstorije) and n.brojProstorije =~ {brojProstorije} return n",
                                                            queryDict, CypherResultMode.Set);

                List<Restoran> restorani = ((IRawGraphClient)client).ExecuteGetCypherResults<Restoran>(query).ToList();

                restoran = restorani.ElementAt(0);
                izmeniprostoriju = new IzmeniSobu(restoran);

            }
            else if (this.prostorija == 4)
            {
                var query = new Neo4jClient.Cypher.CypherQuery("start n=node(*) where (n:Bazen) and exists(n.brojProstorije) and n.brojProstorije =~ {brojProstorije} return n",
                                                           queryDict, CypherResultMode.Set);

                List<Bazen> bazeni = ((IRawGraphClient)client).ExecuteGetCypherResults<Bazen>(query).ToList();

                bazen = bazeni.ElementAt(0);
                izmeniprostoriju = new IzmeniSobu(bazen);
            }

            //   IzmeniSobu izmenisobu = new IzmeniSobu(s);
            izmeniprostoriju.client = client;
            //  izmenisobu.ShowDialog();
            if (izmeniprostoriju.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                if (this.prostorija == 1)
                    ucitajSobe();
                else if (this.prostorija == 2)
                    this.ucitajSale();
                else if (this.prostorija == 3)
                    this.ucitajRestorane();
                else if (this.prostorija == 4)
                    this.ucitajBazene();
            }
            }
     
     
      private void btnGostiZaSobu_Click(object sender, EventArgs e)
        {
            txtListaGostiju.Clear();
            string brojProstorije = txtGosti.Text;

            //  String cena = ".*" + txtPoCeni.Text + ".*";


            Dictionary<string, object> queryDict = new Dictionary<string, object>();
            queryDict.Add("brojProstorije", brojProstorije);

            var query = new Neo4jClient.Cypher.CypherQuery("match  (n:Prostorija:Soba { brojProstorije:'" + brojProstorije + "'})<--(gost) return gost",
                                                              queryDict, CypherResultMode.Set);
            if (prostorija == 1)
            {
                query = new Neo4jClient.Cypher.CypherQuery("match  (n:Prostorija:Soba { brojProstorije:'" + brojProstorije + "'})<-[r:REZERVACIJA]-(gost) return gost",
                                                            queryDict, CypherResultMode.Set);
                /*MATCH (n:Soba { brojSobe: '111' })-->(gost) RETURN gost*/
            }
            else if (prostorija == 2)
            {
                query = new Neo4jClient.Cypher.CypherQuery("match  (n:Prostorija:Sala { brojProstorije:'" + brojProstorije + "'})<-[r:REZERVACIJA]-(gost) return gost",
                                                              queryDict, CypherResultMode.Set);
            }
            else if (prostorija == 3)
            {
                query = new Neo4jClient.Cypher.CypherQuery("match  (n:Prostorija:Restoran { brojProstorije:'" + brojProstorije + "'})<-[r:REZERVACIJA]-(gost) return gost",
                                                              queryDict, CypherResultMode.Set);
            }
            else if (prostorija == 4)
            {
                query = new Neo4jClient.Cypher.CypherQuery("match  (n:Prostorija:Bazen { brojProstorije:'" + brojProstorije + "'})<-[r:REZERVACIJA]-(gost) return gost",
                                                              queryDict, CypherResultMode.Set);
            }
            List<Gost> gosti = ((IRawGraphClient)client).ExecuteGetCypherResults<Gost>(query).ToList();


            foreach (Gost g in gosti)
            {
                txtListaGostiju.Text += g.ime + " " + g.prezime + " " + "\r\n";
            }
        }

        private void txtPoCeni_TextChanged(object sender, EventArgs e)
        {
            String cena = ".*" + txtPoCeni.Text + ".*";


            Dictionary<string, object> queryDict = new Dictionary<string, object>();
            queryDict.Add("cena", cena);

            if (prostorija == 1)
            {
                var query = new Neo4jClient.Cypher.CypherQuery("start n=node(*) where (n:Prostorija:Soba) and exists(n.cena) and n.cena =~ {cena} return n",

                  queryDict, CypherResultMode.Set);

                List<Soba> sobe = ((IRawGraphClient)client).ExecuteGetCypherResults<Soba>(query).ToList();

                ucitajSobe(sobe);
            }
            else if (prostorija == 2)
            {
                var query = new Neo4jClient.Cypher.CypherQuery("start n=node(*) where (n:Prostorija:Sala) and exists(n.cena) and n.cena =~ {cena} return n",

                 queryDict, CypherResultMode.Set);

                List<Sala> sale = ((IRawGraphClient)client).ExecuteGetCypherResults<Sala>(query).ToList();

                ucitajSale(sale);

            }
            else if (prostorija == 3)
            {
                var query = new Neo4jClient.Cypher.CypherQuery("start n=node(*) where (n:Prostorija:Restoran) and exists(n.cena) and n.cena =~ {cena} return n",

                 queryDict, CypherResultMode.Set);

                List<Restoran> sale = ((IRawGraphClient)client).ExecuteGetCypherResults<Restoran>(query).ToList();

                ucitajRestorane(sale);

            }
            else if (prostorija == 4)
            {
                var query = new Neo4jClient.Cypher.CypherQuery("start n=node(*) where (n:Prostorija:Bazen) and exists(n.cena) and n.cena =~ {cena} return n",

                 queryDict, CypherResultMode.Set);

                List<Bazen> sale = ((IRawGraphClient)client).ExecuteGetCypherResults<Bazen>(query).ToList();

                ucitajBazene(sale);

            }
        }

        private void txtPoBrojuSobe_TextChanged(object sender, EventArgs e)
        {
            String brojProstorije = ".*" + txtPoBrojuSobe.Text + ".*";


            Dictionary<string, object> queryDict = new Dictionary<string, object>();
            queryDict.Add("brojProstorije", brojProstorije);

            /*   var query = new Neo4jClient.Cypher.CypherQuery("start n=node(*) where   (n:Soba) and exists(n.brojProstorije) and n.brojProstorije =~ {brojProstorije} return n",
                                                               queryDict, CypherResultMode.Set);
   */
            //  List<Soba> sobe = ((IRawGraphClient)client).ExecuteGetCypherResults<Soba>(query).ToList();

            if (this.prostorija == 1)
            {
                var query = new Neo4jClient.Cypher.CypherQuery("start n=node(*) where   (n:Soba) and exists(n.brojProstorije) and n.brojProstorije =~ {brojProstorije} return n",
                                                         queryDict, CypherResultMode.Set);

                List<Soba> sobe = ((IRawGraphClient)client).ExecuteGetCypherResults<Soba>(query).ToList();
                ucitajSobe(sobe);
            }
            else if (prostorija == 2)
            {
                var query = new Neo4jClient.Cypher.CypherQuery("start n=node(*) where   (n:Sala) and exists(n.brojProstorije) and n.brojProstorije =~ {brojProstorije} return n",
                                                         queryDict, CypherResultMode.Set);

                List<Sala> sale = ((IRawGraphClient)client).ExecuteGetCypherResults<Sala>(query).ToList();
                this.ucitajSale(sale);
            }
            else if (prostorija == 3)
            {
                var query = new Neo4jClient.Cypher.CypherQuery("start n=node(*) where   (n:Restoran) and exists(n.brojProstorije) and n.brojProstorije =~ {brojProstorije} return n",
                                                         queryDict, CypherResultMode.Set);

                List<Restoran> sale = ((IRawGraphClient)client).ExecuteGetCypherResults<Restoran>(query).ToList();
                this.ucitajRestorane(sale);
            }
            else if (prostorija == 4)
            {
                var query = new Neo4jClient.Cypher.CypherQuery("start n=node(*) where   (n:Bazen) and exists(n.brojProstorije) and n.brojProstorije =~ {brojProstorije} return n",
                                                         queryDict, CypherResultMode.Set);

                List<Bazen> sale = ((IRawGraphClient)client).ExecuteGetCypherResults<Bazen>(query).ToList();
                this.ucitajBazene(sale);
            }

        }

        private void txtPoKlimi_TextChanged(object sender, EventArgs e)
        {
            String klima = ".*" + txtPoKlimi.Text + ".*";


            Dictionary<string, object> queryDict = new Dictionary<string, object>();
            queryDict.Add("klima", klima);

            var query = new Neo4jClient.Cypher.CypherQuery("start n=node(*) where (n:Soba) and exists(n.klima) and n.klima =~ {klima} return n",
                                                            queryDict, CypherResultMode.Set);

            List<Soba> sobe = ((IRawGraphClient)client).ExecuteGetCypherResults<Soba>(query).ToList();
            ucitajSobe(sobe);

        }
        public void ucitajSobe()
        {

            var query = new Neo4jClient.Cypher.CypherQuery("match(n:Prostorija:Soba)return n",
                                                          new Dictionary<string, object>(), CypherResultMode.Set);
            List<Soba> sobe = ((IRawGraphClient)client).ExecuteGetCypherResults<Soba>(query).ToList();


            listView1.Items.Clear();
            foreach (Soba s in sobe)
            {

                ListViewItem item = new ListViewItem(new string[] { s.brojProstorije, s.sprat, s.brojKreveta, s.cena.ToString(), s.klima, s.tv, s.terasa });

                listView1.Items.Add(item);
                //  MessageBox.Show(s.sprat);


            }
            listView1.Refresh();

        }
        public void ucitajSale()
        {
            //  listView1.AllowColumnReorder = true;
            var query = new Neo4jClient.Cypher.CypherQuery("match(n:Prostorija:Sala)return n",
                                                            new Dictionary<string, object>(), CypherResultMode.Set);
            List<Sala> sale = ((IRawGraphClient)client).ExecuteGetCypherResults<Sala>(query).ToList();

            listView1.Items.Clear();
            foreach (Sala s in sale)
            {

                ListViewItem item = new ListViewItem(new string[] { s.brojProstorije, s.kapacitetSale.ToString(), s.cena.ToString() });

                listView1.Items.Add(item);
                //  MessageBox.Show(s.sprat);


            }
            listView1.Refresh();
        }
        public void ucitajSobe(List<Soba> sobe)
        {


            listView1.Items.Clear();
            foreach (Soba s in sobe)
            {
                ListViewItem item = new ListViewItem(new string[] { s.brojProstorije, s.sprat, s.brojKreveta, s.cena.ToString(), s.klima, s.tv, s.terasa });

                listView1.Items.Add(item);
                //  MessageBox.Show(s.sprat);


            }
            listView1.Refresh();
        }

        public void ucitajSale(List<Sala> sale)
        {


            listView1.Items.Clear();
            foreach (Sala s in sale)
            {
                ListViewItem item = new ListViewItem(new string[] { s.brojProstorije, s.kapacitetSale.ToString(), s.cena.ToString() });

                listView1.Items.Add(item);
                //  MessageBox.Show(s.sprat);


            }
            listView1.Refresh();

        }

        public void ucitajRestorane()
        {
            var query = new Neo4jClient.Cypher.CypherQuery("match(n:Prostorija:Restoran)return n",
                                                         new Dictionary<string, object>(), CypherResultMode.Set);
            List<Restoran> restorani = ((IRawGraphClient)client).ExecuteGetCypherResults<Restoran>(query).ToList();


            listView1.Items.Clear();
            foreach (Restoran s in restorani)
            {

                ListViewItem item = new ListViewItem(new string[] { s.brojProstorije, s.kapacitetRestorana.ToString(), s.cena.ToString() });

                listView1.Items.Add(item);
                //  MessageBox.Show(s.sprat);


            }
            listView1.Refresh();
        }
        public void ucitajRestorane(List<Restoran> restorani)
        {
            listView1.Items.Clear();
            foreach (Restoran s in restorani)
            {
                ListViewItem item = new ListViewItem(new string[] { s.brojProstorije, s.kapacitetRestorana.ToString(), s.cena.ToString() });

                listView1.Items.Add(item);
                //  MessageBox.Show(s.sprat);


            }
            listView1.Refresh();

        }


        public void ucitajBazene()
        {
            var query = new Neo4jClient.Cypher.CypherQuery("match(n:Prostorija:Bazen)return n",
                                                         new Dictionary<string, object>(), CypherResultMode.Set);
            List<Bazen> bazeni = ((IRawGraphClient)client).ExecuteGetCypherResults<Bazen>(query).ToList();


            listView1.Items.Clear();
            foreach (Bazen s in bazeni)
            {

                ListViewItem item = new ListViewItem(new string[] { s.brojProstorije, s.tip, s.cena.ToString() });

                listView1.Items.Add(item);
                //  MessageBox.Show(s.sprat);


            }
            listView1.Refresh();
        }
        public void ucitajBazene(List<Bazen> bazeni)
        {
            listView1.Items.Clear();
            foreach (Bazen s in bazeni)
            {
                ListViewItem item = new ListViewItem(new string[] { s.brojProstorije, s.tip, s.cena.ToString() });

                listView1.Items.Add(item);
                //  MessageBox.Show(s.sprat);


            }
            listView1.Refresh();

        }
       
        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void PregledSobe_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawRectangle(new Pen(Color.White, 5),
                           this.DisplayRectangle);
        }
    }
}
