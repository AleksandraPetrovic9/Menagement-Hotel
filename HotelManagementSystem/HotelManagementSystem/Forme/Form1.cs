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
using HotelManagementSystem.Forme;

namespace HotelManagementSystem
{
    public partial class Form1 : Form
    {
        private GraphClient client;
     
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            client = new GraphClient(new Uri("http://localhost:7474/db/data"), "neo4j", "dbneo4j");
            try
            {
                client.Connect();
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int prostorija = 1;
            PregledSobe pregledSobe = new PregledSobe(prostorija);
            pregledSobe.client = client;
            pregledSobe.ShowDialog();
        }

        private void btnRezervacija_Click(object sender, EventArgs e)
        {
            DodajRezervaciju rezervacija = new DodajRezervaciju();
            rezervacija.client = client;
            rezervacija.ShowDialog();
        }

        private void btnRadnici_Click(object sender, EventArgs e)
        {
            RasporediRadnika rasporediRadnika = new RasporediRadnika();
            rasporediRadnika.client = client;
            rasporediRadnika.ShowDialog();
        }


        private void btnPregledGostiju_Click(object sender, EventArgs e)
        {
            PregledGostiju gosti = new PregledGostiju();
            gosti.client = client;
            gosti.ShowDialog();
            //String a = "Mihailo";
            //Dictionary<string, object> queryDict = new Dictionary<string, object>();
            //queryDict.Add("imeGosta", a);


            //var query = new Neo4jClient.Cypher.CypherQuery("MATCH (n:Gost {imeGosta:'" + a
            //                                   + "'}) return n", queryDict, CypherResultMode.Set);
            //var gost = ((IRawGraphClient)client).ExecuteGetCypherResults<Gost>(query);
        }

        private void btnPregledSale_Click(object sender, EventArgs e)
        {
            int prostorija = 2;
            PregledSobe pregledSobe = new PregledSobe(prostorija);
            pregledSobe.client = client;
            pregledSobe.ShowDialog();
        }

        private void btnPregledRestorana_Click(object sender, EventArgs e)
        {
            int prostorija = 3;
            PregledSobe pregledSobe = new PregledSobe(prostorija);
            pregledSobe.client = client;
            pregledSobe.ShowDialog();
        }

        private void btnPregledBazena_Click(object sender, EventArgs e)
        {
            int prostorija = 4;
            PregledSobe pregledSobe = new PregledSobe(prostorija);
            pregledSobe.client = client;
            pregledSobe.ShowDialog();

        }

        private void btnIzadji_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnPrijava_Click(object sender, EventArgs e)
        {
            FormPrijava prijava = new FormPrijava();
            prijava.client = client;
            prijava.ShowDialog();
        }

        private void btnStatistika_Click(object sender, EventArgs e)
        {
            FormStatistika fs = new FormStatistika();
            fs.client = client;
            fs.ShowDialog();

        }

        private void btnProduzetak_Click(object sender, EventArgs e)
        {
            FormProduzetakBoravka fpb = new FormProduzetakBoravka();
            fpb.client = client;
            fpb.ShowDialog();
        }
    }
}
