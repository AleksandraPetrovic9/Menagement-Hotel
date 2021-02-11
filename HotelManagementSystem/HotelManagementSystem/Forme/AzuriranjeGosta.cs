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
using Neo4jClient.Cypher;
using Neo4jClient;
using Orient;
using Orient.Client;

namespace HotelManagementSystem.Forme
{
    public partial class AzuriranjeGosta : Form
    {
       // public Rezervacija rezervacijaZaProsledjivanje;
        public Prijava rezervacijaZaProsledjivanje;
        public GraphClient client;
        public PregledGostiju roditeljskaForma;
        public AzuriranjeGosta()
        {
            InitializeComponent();
        }

        public AzuriranjeGosta(Prijava r, PregledGostiju p)
        {
            InitializeComponent();
            rezervacijaZaProsledjivanje = r;
            roditeljskaForma = p;

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void AzuriranjeGosta_Load(object sender, EventArgs e)
        {

            textBox1.Text = rezervacijaZaProsledjivanje.gost.ime;
            textBox2.Text = rezervacijaZaProsledjivanje.gost.prezime;
            textBox3.Text = rezervacijaZaProsledjivanje.gost.email;
            textBox4.Text = rezervacijaZaProsledjivanje.gost.brojTelefona;
            textBox5.Text = rezervacijaZaProsledjivanje.gost.dokument;

            Dictionary<string, object> queryDict = new Dictionary<string, object>();
            Int32 idGostaZaProsledjivanje = Convert.ToInt32(rezervacijaZaProsledjivanje.gost.idGosta);
            var query1 = new Neo4jClient.Cypher.CypherQuery("match(s:Prostorija) return s", queryDict, CypherResultMode.Set);
            List<Prostorija> sobe = ((IRawGraphClient)client).ExecuteGetCypherResults<Prostorija>(query1).ToList();
            foreach (Prostorija s in sobe)
            {
                comboBox1.Items.Add(s.brojProstorije);
                if (s.brojProstorije == rezervacijaZaProsledjivanje.prostorija.brojProstorije)
                {
                    comboBox1.SelectedText = rezervacijaZaProsledjivanje.prostorija.brojProstorije;
                    comboBox1.SelectedItem = rezervacijaZaProsledjivanje.prostorija.brojProstorije;
                }
            }

            dateTimePicker1.Value = rezervacijaZaProsledjivanje.datumDo;

            // MessageBox.Show(comboBox1.SelectedValue.ToString());

        }

        private void azurirajButton_Click(object sender, EventArgs e)
        {
            //var query bla bla upit kao neo4j
            //gostZaProsledjivanje.idGosta=gostZaProsledjivanje.idGosta; znaci ID VEC POSTOJI PROSLEDJEN JE GOST U FORMU

            rezervacijaZaProsledjivanje.gost.ime = textBox1.Text;
            rezervacijaZaProsledjivanje.gost.prezime = textBox2.Text;
            rezervacijaZaProsledjivanje.gost.email = textBox3.Text;
            rezervacijaZaProsledjivanje.gost.brojTelefona = textBox4.Text;
            rezervacijaZaProsledjivanje.gost.dokument = textBox5.Text;
            rezervacijaZaProsledjivanje.prostorija.brojProstorije = comboBox1.SelectedItem.ToString();
            rezervacijaZaProsledjivanje.datumDo = dateTimePicker1.Value.Date;

            //MessageBox.Show(rezervacijaZaProsledjivanje.datumDo.ToString());

            // MessageBox.Show(rezervacijaZaProsledjivanje.gost.idGosta);
            Int32 idGostaZaProsledjivanje = Convert.ToInt32(rezervacijaZaProsledjivanje.gost.idGosta);

            String brojSobeGostaZaProsledjivanje = rezervacijaZaProsledjivanje.prostorija.brojProstorije.ToString();

            Dictionary<string, object> queryDict = new Dictionary<string, object>();
            //queryDict.Add("idGosta", gostZaProsledjivanje.idGosta);
            queryDict.Add("ime", rezervacijaZaProsledjivanje.gost.ime);
            queryDict.Add("prezime", rezervacijaZaProsledjivanje.gost.prezime);
            queryDict.Add("email", rezervacijaZaProsledjivanje.gost.email);
            queryDict.Add("brojTelefona", rezervacijaZaProsledjivanje.gost.brojTelefona);
            queryDict.Add("dokument", rezervacijaZaProsledjivanje.gost.dokument);
            //queryDict.Add("brojProstorije", rezervacijaZaProsledjivanje.prostorija.brojProstorije);



            //MessageBox.Show(queryString);

            //upit(queryString) je dobar prolazi u neo4j proverio sam

            var query = new Neo4jClient.Cypher.CypherQuery("match(n:Gost)-[r:PRIJAVA]->(s:Soba) WHERE ID(n)=" + idGostaZaProsledjivanje + ""
                + " set n.ime='" + rezervacijaZaProsledjivanje.gost.ime + "', n.prezime='" + rezervacijaZaProsledjivanje.gost.prezime + "', "
                + "  n.email='" + rezervacijaZaProsledjivanje.gost.email + "',  n.brojTelefona='" + rezervacijaZaProsledjivanje.gost.brojTelefona + "', "
                + "  n.dokument='" + rezervacijaZaProsledjivanje.gost.dokument + "' return n", queryDict, CypherResultMode.Set);

            //GET 
            //mi cemo ovde da dobijemo samo jednog gosta ustvari

            List<Gost> gost = ((IRawGraphClient)client).ExecuteGetCypherResults<Gost>(query).ToList();

            //GET 
            //mi cemo ovde da dobijemo samo jednu sobu ustvari
            var query1 = new Neo4jClient.Cypher.CypherQuery("match(n:Gost)-[r:PRIJAVA]->(s:Soba) WHERE ID(n)=" + idGostaZaProsledjivanje + " return s", queryDict, CypherResultMode.Set);

            List<Soba> soba = ((IRawGraphClient)client).ExecuteGetCypherResults<Soba>(query1).ToList();

            //brisanje rezervacije izmedju gosta i sobe -- 
            var query2 = new Neo4jClient.Cypher.CypherQuery("match(n:Gost)-[r:PRIJAVA]->(s:Soba) WHERE ID(n)=" + idGostaZaProsledjivanje + " delete r", queryDict, CypherResultMode.Set);


            ((IRawGraphClient)client).ExecuteCypher(query2);

            //kreiranje rezervacije
            var query3 = new Neo4jClient.Cypher.CypherQuery("match(g:Gost) WHERE ID(g)=" + idGostaZaProsledjivanje + ""
                 + " match(s:Soba) WHERE exists(s.brojProstorije) and s.brojProstorije='" + rezervacijaZaProsledjivanje.prostorija.brojProstorije + "' "
                 + " create (g)-[r:PRIJAVA {datumPrijave:'" + rezervacijaZaProsledjivanje.datumPrijave + "', datumOd:'" + rezervacijaZaProsledjivanje.datumOd.ToString() + "', "
                 + " datumDo:'" + rezervacijaZaProsledjivanje.datumDo.ToString() + "'}]->(s) return r", queryDict, CypherResultMode.Set);

            List<Prijava> rezervacije = ((IRawGraphClient)client).ExecuteGetCypherResults<Prijava>(query3).ToList();


            foreach (Prijava r in rezervacije)
            {
                r.gost = rezervacijaZaProsledjivanje.gost;
                r.prostorija = rezervacijaZaProsledjivanje.prostorija;
            }
            //dodeljivanje sobe i gosta rezervaciji


            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
            //ocisti textboxeve
            //ugasi dijalog


        }

        private void btnIzadji_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AzuriranjeGosta_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawRectangle(new Pen(Color.White, 5),
                            this.DisplayRectangle);
        }
    }
}
