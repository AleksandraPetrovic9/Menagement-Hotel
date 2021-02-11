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

namespace HotelManagementSystem.Forme
{
    public partial class ZadajZadatak : Form
    {
        public GraphClient client;
        public String brojRadnika;
        public ZadajZadatak()
        {
            InitializeComponent();
        }

        private Bazen VratiBazen() {
            Dictionary<string, object> queryDict = new Dictionary<string, object>();
            queryDict.Add("brojProstorije", textBox1.Text);
            var query = new Neo4jClient.Cypher.CypherQuery("start n=node(*) where (n:Prostorija) and exists(n.brojProstorije) and n.brojProstorije =~ {brojProstorije} return n",
                                                           queryDict, CypherResultMode.Set);

            List<Bazen> prostor = ((IRawGraphClient)client).ExecuteGetCypherResults<Bazen>(query).ToList();
            if (prostor.Count != 0)
               return prostor[0];
            else
               return null;

            
        }
        private Sala VratiSalu() {
            Dictionary<string, object> queryDict = new Dictionary<string, object>();
            queryDict.Add("brojProstorije", textBox1.Text);
            var query = new Neo4jClient.Cypher.CypherQuery("start n=node(*) where (n:Prostorija) and exists(n.brojProstorije) and n.brojProstorije =~ {brojProstorije} return n",
                                                           queryDict, CypherResultMode.Set);

            List<Sala> prostor = ((IRawGraphClient)client).ExecuteGetCypherResults<Sala>(query).ToList();
            if (prostor.Count != 0)
                return prostor[0];
            else
                return null;
        }
        private Soba VratiSobu() {
            Dictionary<string, object> queryDict = new Dictionary<string, object>();
            queryDict.Add("brojProstorije", textBox1.Text);
            var query = new Neo4jClient.Cypher.CypherQuery("start n=node(*) where (n:Soba) and exists(n.brojProstorije) and n.brojProstorije =~ {brojProstorije} return n",
                                                           queryDict, CypherResultMode.Set);

            List<Soba> prostor = ((IRawGraphClient)client).ExecuteGetCypherResults<Soba>(query).ToList();

            if (prostor.Count != 0)
            {
                
                return prostor[0];
            }
            else
            {

               
                return null;
            }
        }
        private Zadatak CreateZadatak() {
            Zadatak z = new Zadatak();
            z.naziv = textBox3.Text;
            
            if (checkBox1.Checked)
               z.hitno = "da";
            else z.hitno = "ne";
            z.datum= dateTimePicker1.Value.Date;

            switch (comboBox1.Text)
            {
                case ("Bazen"):
                    z.prostorija = this.VratiBazen();
                    break;
                case ("Sala"):
                    z.prostorija = this.VratiSalu();
                    break;
                case ("Soba"):
                    z.prostorija = this.VratiSobu();
                    break;

            }
            Dictionary<string, object> queryDict = new Dictionary<string, object>();
            queryDict.Add("brojRadnika", brojRadnika);

            var query = new Neo4jClient.Cypher.CypherQuery("start n=node(*) where (n:Radnik) and exists(n.brojRadnika) and n.brojRadnika =~ {brojRadnika} return n",
                                                            queryDict, CypherResultMode.Set);
            
            List<Radnik> radnik = ((IRawGraphClient)client).ExecuteGetCypherResults<Radnik>(query).ToList();
            z.radnik = radnik[0];



            return z;
        }
        private void ZadajZadatak_Load(object sender, EventArgs e)
        {
            Dictionary<string, object> queryDict = new Dictionary<string, object>();
            queryDict.Add("brojRadnika", brojRadnika);

            var query = new Neo4jClient.Cypher.CypherQuery("start n=node(*) where (n:Radnik) and exists(n.brojRadnika) and n.brojRadnika =~ {brojRadnika} return n",
                                                            queryDict, CypherResultMode.Set);
            //ovde ne puca ni kada mu posaljem menadzera i sobaricu
            List<Radnik> radnik = ((IRawGraphClient)client).ExecuteGetCypherResults<Radnik>(query).ToList();
            textBoxIme.Text = radnik[0].ime;
            textBox2.Text = radnik[0].prezime;
        }

        private void buttonZadajZadatak_Click(object sender, EventArgs e)
        {
            
           Zadatak z= CreateZadatak();
            if (z.prostorija == null)
            {
                MessageBox.Show("Neispravan broj prostorije");
                return;
            }
           var query = new Neo4jClient.Cypher.CypherQuery("match (n:Radnik),(m:Prostorija) where n.brojRadnika='" + z.radnik.brojRadnika + "' and m.brojProstorije='" + z.prostorija.brojProstorije + "' create (n)-[r:ZADATAK{ naziv: '" + z.naziv + "' , hitno:'"+z.hitno+"',datum: date({ day:"+z.datum.Day+", month:"+z.datum.Month+", year:"+ z.datum.Year+"})}]->(m) return r.naziv",
               new Dictionary<string, object>(), CypherResultMode.Set);

             ((IRawGraphClient)client).ExecuteCypher(query);
            //textBox3.Text="";
            //textBox1.Text="";
            this.Close();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ZadajZadatak_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawRectangle(new Pen(Color.White, 5),
                           this.DisplayRectangle);
        }
    }
}                                             
