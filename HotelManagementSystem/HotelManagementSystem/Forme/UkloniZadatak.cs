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
    public partial class UkloniZadatak : Form
    {
        public String brojRadnika;
        public GraphClient client;
        public UkloniZadatak()
        {
            InitializeComponent();
        }

        private void UkloniZadatak_Load(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            this.PrikaziZadatke();
            listView1.Refresh();

        }
        /*                        var query = new Neo4jClient.Cypher.CypherQuery("MATCH(n) -[r: REZERVACIJA]->(a:Soba) where r.datumOd >= date({ day:  " + datumOd.Day + ", month: " + datumOd.Month + ", year: " + datumOd.Year + "})  and r.datumOd <=  date({ day:  " + datumDo.Day + ", month: " + datumDo.Month + ", year: " + datumDo.Year + "}) or (r.datumDo >=  date({ day: " + datumOd.Day + ", month: " + datumOd.Month + ", year: " + datumOd.Year + "})  and r.datumDo <=  date({ day:  " + datumDo.Day + ", month: " + datumDo.Month + ", year: " + datumDo.Year + "}) ) return a",
                                                                        queryDict, CypherResultMode.Set);

*/
        private void PrikaziZadatkeDatum(DateTime datumP)
        {
            Dictionary<string, object> queryDict = new Dictionary<string, object>();
            queryDict.Add("brojRadnika", brojRadnika);

            var query = new Neo4jClient.Cypher.CypherQuery("start n=node(*) where (n:Radnik) and exists(n.brojRadnika) and n.brojRadnika =~ {brojRadnika} return n",
                                                            queryDict, CypherResultMode.Set);
            //ovde ne puca ni kada mu posaljem menadzera i sobaricu
            List<Radnik> radnik = ((IRawGraphClient)client).ExecuteGetCypherResults<Radnik>(query).ToList();
            label2.Text = "" + radnik[0].ime + " " + radnik[0].prezime + "";
            //promeni r.ime i u bazi
            var query1 = new Neo4jClient.Cypher.CypherQuery("match(n:Radnik {brojRadnika : '" + brojRadnika + "'})-[r:ZADATAK]->(p:Prostorija) where r.datum=date({ day:  " + datumP.Day + ", month: " + datumP.Month + ", year: " + datumP.Year + "}) return r.naziv", queryDict, CypherResultMode.Set);

            List<String> zadaci = ((IRawGraphClient)client).ExecuteGetCypherResults<String>(query1).ToList();

            var query2 = new Neo4jClient.Cypher.CypherQuery("match(n:Radnik {brojRadnika : '" + brojRadnika + "'})-[r:ZADATAK]->(p:Prostorija) where r.datum=date({ day:  " + datumP.Day + ", month: " + datumP.Month + ", year: " + datumP.Year + "}) return p.brojProstorije", queryDict, CypherResultMode.Set);

            List<String> sobe = ((IRawGraphClient)client).ExecuteGetCypherResults<String>(query2).ToList();
            var query3 = new Neo4jClient.Cypher.CypherQuery("match(n:Radnik {brojRadnika : '" + brojRadnika + "'})-[r:ZADATAK]->(p:Prostorija) where r.datum=date({ day:  " + datumP.Day + ", month: " + datumP.Month + ", year: " + datumP.Year + "}) return r.hitno", queryDict, CypherResultMode.Set);

            List<String> hitno = ((IRawGraphClient)client).ExecuteGetCypherResults<String>(query3).ToList();
            var query4 = new Neo4jClient.Cypher.CypherQuery("match(n:Radnik {brojRadnika : '" + brojRadnika + "'})-[r:ZADATAK]->(p:Prostorija) where r.datum=date({ day:  " + datumP.Day + ", month: " + datumP.Month + ", year: " + datumP.Year + "}) return r.datum", queryDict, CypherResultMode.Set);

            List<String> datum = ((IRawGraphClient)client).ExecuteGetCypherResults<String>(query4).ToList();

            for (int i = 0; i < zadaci.Count; i++)
            {

                ListViewItem item = new ListViewItem(new string[] { sobe[i], zadaci[i], hitno[i], datum[i] });

                listView1.Items.Add(item);
            }

        }
        private void PrikaziZadatke()
        {
            Dictionary<string, object> queryDict = new Dictionary<string, object>();
            queryDict.Add("brojRadnika", brojRadnika);

            var query = new Neo4jClient.Cypher.CypherQuery("start n=node(*) where (n:Radnik) and exists(n.brojRadnika) and n.brojRadnika =~ {brojRadnika} return n",
                                                            queryDict, CypherResultMode.Set);
            //ovde ne puca ni kada mu posaljem menadzera i sobaricu
            List<Radnik> radnik = ((IRawGraphClient)client).ExecuteGetCypherResults<Radnik>(query).ToList();
            label2.Text = "" + radnik[0].ime + " " + radnik[0].prezime + "";
            //promeni r.ime i u bazi
           
            var query1 = new Neo4jClient.Cypher.CypherQuery("match(n:Radnik {brojRadnika : '" + brojRadnika + "'})-[r:ZADATAK]->(p:Prostorija) return r.naziv", queryDict, CypherResultMode.Set);

            List<String> zadaci = ((IRawGraphClient)client).ExecuteGetCypherResults<String>(query1).ToList();

            var query2 = new Neo4jClient.Cypher.CypherQuery("match(n:Radnik {brojRadnika : '" + brojRadnika + "'})-[r:ZADATAK]->(p:Prostorija) return p.brojProstorije", queryDict, CypherResultMode.Set);

            List<String> sobe = ((IRawGraphClient)client).ExecuteGetCypherResults<String>(query2).ToList();
            var query3 = new Neo4jClient.Cypher.CypherQuery("match(n:Radnik {brojRadnika : '" + brojRadnika + "'})-[r:ZADATAK]->(p:Prostorija) return r.hitno", queryDict, CypherResultMode.Set);

            List<String> hitno = ((IRawGraphClient)client).ExecuteGetCypherResults<String>(query3).ToList();
            var query4 = new Neo4jClient.Cypher.CypherQuery("match(n:Radnik {brojRadnika : '" + brojRadnika + "'})-[r:ZADATAK]->(p:Prostorija) return r.datum", queryDict, CypherResultMode.Set);

            List<String> datum = ((IRawGraphClient)client).ExecuteGetCypherResults<String>(query4).ToList();

            for (int i = 0; i < zadaci.Count; i++)
            {

                ListViewItem item = new ListViewItem(new string[] { sobe[i], zadaci[i], hitno[i], datum[i] });

                listView1.Items.Add(item);
            }
        }
        private void PrikaziZadatke(String hitnost)
        {
            Dictionary<string, object> queryDict = new Dictionary<string, object>();
            queryDict.Add("brojRadnika", brojRadnika);

            var query = new Neo4jClient.Cypher.CypherQuery("start n=node(*) where (n:Radnik) and exists(n.brojRadnika) and n.brojRadnika =~ {brojRadnika} return n",
                                                            queryDict, CypherResultMode.Set);
            //ovde ne puca ni kada mu posaljem menadzera i sobaricu
            List<Radnik> radnik = ((IRawGraphClient)client).ExecuteGetCypherResults<Radnik>(query).ToList();
            label2.Text = "" + radnik[0].ime + " " + radnik[0].prezime + "";
            //promeni r.ime i u bazi
            var query1 = new Neo4jClient.Cypher.CypherQuery("match(n:Radnik {brojRadnika : '" + brojRadnika + "'})-[r:ZADATAK]->(p:Prostorija) where r.hitno='" + hitnost + "'return r.naziv", queryDict, CypherResultMode.Set);

            List<String> zadaci = ((IRawGraphClient)client).ExecuteGetCypherResults<String>(query1).ToList();

            var query2 = new Neo4jClient.Cypher.CypherQuery("match(n:Radnik {brojRadnika : '" + brojRadnika + "'})-[r:ZADATAK]->(p:Prostorija) where r.hitno='" + hitnost + "'return p.brojProstorije", queryDict, CypherResultMode.Set);

            List<String> sobe = ((IRawGraphClient)client).ExecuteGetCypherResults<String>(query2).ToList();
            var query3 = new Neo4jClient.Cypher.CypherQuery("match(n:Radnik {brojRadnika : '" + brojRadnika + "'})-[r:ZADATAK]->(p:Prostorija) where r.hitno='" + hitnost + "' return r.hitno", queryDict, CypherResultMode.Set);

            List<String> hitno = ((IRawGraphClient)client).ExecuteGetCypherResults<String>(query3).ToList();
            var query4 = new Neo4jClient.Cypher.CypherQuery("match(n:Radnik {brojRadnika : '" + brojRadnika + "'})-[r:ZADATAK]->(p:Prostorija) where r.hitno='" + hitnost + "'return r.datum", queryDict, CypherResultMode.Set);

            List<String> datum = ((IRawGraphClient)client).ExecuteGetCypherResults<String>(query4).ToList();

            for (int i = 0; i < zadaci.Count; i++)
            {

                ListViewItem item = new ListViewItem(new string[] { sobe[i], zadaci[i], hitno[i], datum[i] });

                listView1.Items.Add(item);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 0)
            {
                MessageBox.Show("Odaberite zadatak koji zelite da uklonite.");
                return;
            }

            String brSobe = listView1.SelectedItems[0].SubItems[0].Text;
            String zadatak = listView1.SelectedItems[0].SubItems[1].Text;
            var query2 = new Neo4jClient.Cypher.CypherQuery("match(n:Radnik {brojRadnika : '" + brojRadnika + "'})-[r:ZADATAK{naziv:'" + zadatak + "'}]->(p:Prostorija{brojProstorije:'" + brSobe + "'}) delete r", new Dictionary<string, object>(), CypherResultMode.Set);
            ((IRawGraphClient)client).ExecuteCypher(query2);

            listView1.Items.Clear();
            this.PrikaziZadatke();
            listView1.Refresh();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            ZadajZadatak zadajZadatak = new ZadajZadatak();
            zadajZadatak.client = client;
            zadajZadatak.brojRadnika = brojRadnika;
            zadajZadatak.ShowDialog();

            listView1.Items.Clear();
            this.PrikaziZadatke();
            listView1.Refresh();
        }



        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

            listView1.Items.Clear();
            if (checkBox1.Checked == true)
                this.PrikaziZadatke("da");
            else
                this.PrikaziZadatke();
            listView1.Refresh();

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            DateTime datum = dateTimePicker1.Value.Date;

            listView1.Items.Clear();
            this.PrikaziZadatkeDatum(datum);
            listView1.Refresh();

        }

        private void checkBox1_CheckedChanged_1(object sender, EventArgs e)
        {

            listView1.Items.Clear();
            if (checkBox1.Checked == true)
                this.PrikaziZadatke("da");
            else
                this.PrikaziZadatke();
            listView1.Refresh();
        }

        private void dateTimePicker1_ValueChanged_1(object sender, EventArgs e)
        {

            DateTime datum = dateTimePicker1.Value.Date;

            listView1.Items.Clear();
            this.PrikaziZadatkeDatum(datum);
            listView1.Refresh();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void UkloniZadatak_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawRectangle(new Pen(Color.White, 5),
                           this.DisplayRectangle);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
         
                this.PrikaziZadatke();
            listView1.Refresh();

        }
    }
}
