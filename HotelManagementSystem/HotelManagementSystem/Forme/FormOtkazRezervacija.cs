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
    public partial class FormOtkazRezervacija : Form
    {
        public GraphClient client;
        public FormOtkazRezervacija()
        {
            InitializeComponent();
        }

        private void FormOtkazRezervacija_Load(object sender, EventArgs e)
        {
           int br= OtkazaneRez();
            label1.Text = "Ukupan broj otkazanih rezervacije je " + br.ToString();
        }

        public int OtkazaneRez()
        {
            Dictionary<string, object> queryDict = new Dictionary<string, object>();

            var query = new Neo4jClient.Cypher.CypherQuery("MATCH (g:Gost )-[r:REZERVACIJA ]->(s:Prostorija)" +
                                                          " WHERE NOT(g: Gost) -[:PRIJAVA]->(s: Prostorija) " +
                                                           "AND  r.datumOd <=date({year:" + DateTime.Today.Year 
                                                        + ", month:" + DateTime.Today.Month 
                                                        + ",day:" + DateTime.Today.Day 
                                                        + "}) RETURN r ",
                                                           queryDict, CypherResultMode.Set);

            List<Rezervacija> rezervacije = ((IRawGraphClient)client).ExecuteGetCypherResults<Rezervacija>(query).ToList();

            var query1 = new Neo4jClient.Cypher.CypherQuery("MATCH (g:Gost )-[r:REZERVACIJA ]->(s:Prostorija) WHERE NOT(g: Gost) -[:PRIJAVA]->(s: Prostorija) AND  r.datumOd <=date({year:" + DateTime.Today.Year + ", month:" + DateTime.Today.Month + ",day:" + DateTime.Today.Day + "}) RETURN g ",
                                                          queryDict, CypherResultMode.Set);

            List<Gost> gosti = ((IRawGraphClient)client).ExecuteGetCypherResults<Gost>(query1).ToList();

            var query2 = new Neo4jClient.Cypher.CypherQuery("MATCH (g:Gost )-[r:REZERVACIJA ]->(s:Prostorija) WHERE NOT(g: Gost) -[:PRIJAVA]->(s: Prostorija) AND  r.datumOd <=date({year:" + DateTime.Today.Year + ", month:" + DateTime.Today.Month + ",day:" + DateTime.Today.Day + "}) RETURN s",
                                                         queryDict, CypherResultMode.Set);

            List<Prostorija> prostorije = ((IRawGraphClient)client).ExecuteGetCypherResults<Prostorija>(query2).ToList();

            var query3 = new Neo4jClient.Cypher.CypherQuery("MATCH (g:Gost )-[r:REZERVACIJA ]->(s:Prostorija) WHERE NOT(g: Gost) -[:PRIJAVA]->(s: Prostorija) AND  r.datumOd <=date({year:" + DateTime.Today.Year + ", month:" + DateTime.Today.Month + ",day:" + DateTime.Today.Day + "}) return ID(g)",
                                                           queryDict, CypherResultMode.Set);

            List<String> listaID = ((IRawGraphClient)client).ExecuteGetCypherResults<String>(query3).ToList();


            for (int i = 0; i < rezervacije.Count; i++)
            {
                gosti[i].idGosta = listaID[i].ToString();
                rezervacije[i].gost = gosti[i];
                rezervacije[i].prostorija = prostorije[i];
            }

            int br = 0;
          
            foreach (Rezervacija r in rezervacije)
            {
              //  int result = DateTime.Compare(r.datumOd, DateTime.Today);
               
               // if (result < 0)
                {
                    ListViewItem item = new ListViewItem(new string[] { r.gost.idGosta, r.gost.ime, r.gost.prezime, r.prostorija.brojProstorije.ToString(), r.gost.brojTelefona, r.gost.email, r.gost.dokument, r.datumOd.ToString("dd/MM/yyyy"), r.datumDo.ToString("dd/MM/yyyy"), r.datumRezervacije.ToString("dd/MM/yyyy") });

                    lvRez.Items.Add(item);
                    br++;

                }

            }
            lvRez.Refresh();
            return br;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormOtkazRezervacija_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawRectangle(new Pen(Color.White, 5),
                             this.DisplayRectangle);
        }
    }
}
