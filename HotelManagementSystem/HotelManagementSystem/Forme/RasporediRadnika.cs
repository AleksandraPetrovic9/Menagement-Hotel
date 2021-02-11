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
    public partial class RasporediRadnika : Form
    {
        public GraphClient client;
        public RasporediRadnika()
        {
            InitializeComponent();
        }
        private void vratiMajstore() {
            var query = new Neo4jClient.Cypher.CypherQuery("match(n:Radnik:Majstor)return n",
                                                            new Dictionary<string, object>(), CypherResultMode.Set);
            List<Radnik> majstori = ((IRawGraphClient)client).ExecuteGetCypherResults<Radnik>(query).ToList();
            var query1 = new Neo4jClient.Cypher.CypherQuery("match(n:Radnik:Sobarica)return n",
                                                          new Dictionary<string, object>(), CypherResultMode.Set);
            foreach (Radnik m in majstori)
            {
                m.zanimanje = "Majstor";
                ListViewItem item = new ListViewItem(new string[] { m.brojRadnika, m.ime, m.prezime, m.zanimanje });

                listView1.Items.Add(item);
               
            }
        }
        private void vratiMenadzere()
        {
            var query = new Neo4jClient.Cypher.CypherQuery("match(n:Radnik:Menadzer)return n",
                            new Dictionary<string, object>(), CypherResultMode.Set);
            List<Radnik> menadzeri = ((IRawGraphClient)client).ExecuteGetCypherResults<Radnik>(query).ToList();
            foreach (Radnik m in menadzeri)
            {
                m.zanimanje = "Menadzer";
                ListViewItem item = new ListViewItem(new string[] { m.brojRadnika, m.ime, m.prezime, m.zanimanje });

                listView1.Items.Add(item);
              
            }
        }
        private void vratiSobarice()
        {
            var query = new Neo4jClient.Cypher.CypherQuery("match(n:Radnik:Sobarica)return n",
                                                      new Dictionary<string, object>(), CypherResultMode.Set);
            List<Radnik> sobarice = ((IRawGraphClient)client).ExecuteGetCypherResults<Radnik>(query).ToList();
        
            foreach (Radnik m in sobarice)
            {
                m.zanimanje = "Sobarica";
                ListViewItem item = new ListViewItem(new string[] { m.brojRadnika, m.ime, m.prezime, m.zanimanje });

                listView1.Items.Add(item);
                
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void RasporediRadnika_Load(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            //  listView1.AllowColumnReorder = true;
            this.vratiMenadzere();
            this.vratiMajstore();
            this.vratiSobarice();
            listView1.Refresh();

        }

        

        private void button2_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            String radnik = comboBox1.Text;
            switch (radnik) {
                case "Majstor":
                    this.vratiMajstore(); break;
                case "Sobarica":
                    this.vratiSobarice();break;
                case "Menadzer":
                    this.vratiMenadzere();break;
                    }
            listView1.Refresh();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 0)
            {
                MessageBox.Show("Odaberite radnika cije zadatke zelite da izmenite.");
                return;
            }

            String brRadnika = listView1.SelectedItems[0].Text;
           

            UkloniZadatak zadajZadatak = new UkloniZadatak();
            zadajZadatak.client = client;
            zadajZadatak.brojRadnika = brRadnika;
            zadajZadatak.ShowDialog();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void RasporediRadnika_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawRectangle(new Pen(Color.White, 5),
                           this.DisplayRectangle);
        }
    }
}
