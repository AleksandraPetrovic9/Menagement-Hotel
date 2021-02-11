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
    public partial class IzmeniSobu : Form
    {
        public GraphClient client;
        public Soba soba;
        public Sala sala;
        public Restoran restoran;
        public Bazen bazen;
        public int prostorija;
        public IzmeniSobu()
        {
            InitializeComponent();
        }
        public IzmeniSobu(Soba s)
        {
            this.soba = s;
            this.prostorija = 1;
            InitializeComponent();
        }
        public IzmeniSobu(Sala s)
        {
            this.sala = s;
            this.prostorija = 2;
            InitializeComponent();
        }
        public IzmeniSobu(Restoran s)
        {
            this.restoran = s;
            this.prostorija = 3;
            InitializeComponent();
        }
        public IzmeniSobu(Bazen s)
        {
            this.bazen = s;
            this.prostorija = 4;
            InitializeComponent();
        }
        private void IzmeniSobu_Load(object sender, EventArgs e)
        {
            if (this.prostorija == 1)
            {
                txtTipBazena.Visible = false;
                lblTip.Visible = false;
                txtKapacitet.Visible = false;
                lblKapacitet.Visible = false;
                txtBrojSobe.Text = soba.brojProstorije;
                txtKrevet.Text = soba.brojKreveta;
                txtSprat.Text = soba.sprat;
                txtOpis.Text = soba.opis;
                txtTerasa.Text = soba.terasa;
                txtKlima.Text = soba.klima;
                txtTv.Text = soba.tv;
                txtCena.Text = soba.cena.ToString();
            }
            else if (this.prostorija == 2)
            {
                txtTipBazena.Visible = false;
                lblTip.Visible = false;
                txtKrevet.Visible = false;
                txtKlima.Visible = false;
                txtTerasa.Visible = false;
                txtTv.Visible = false;
                txtOpis.Visible = false;
                txtSprat.Visible = false;
                label2.Visible = false;
                label3.Visible = false;
                label4.Visible = false;
                label5.Visible = false;
                label6.Visible = false;
                label8.Visible = false;

                txtBrojSobe.Text = sala.brojProstorije;
                txtKapacitet.Text = sala.kapacitetSale.ToString();
                txtCena.Text = sala.cena.ToString();
            }
            else if (this.prostorija == 3)
            {
                txtTipBazena.Visible = false;
                lblTip.Visible = false;
                txtKrevet.Visible = false;
                txtKlima.Visible = false;
                txtTerasa.Visible = false;
                txtTv.Visible = false;
                txtOpis.Visible = false;
                txtSprat.Visible = false;
                label2.Visible = false;
                label3.Visible = false;
                label4.Visible = false;
                label5.Visible = false;
                label6.Visible = false;
                label8.Visible = false;

                txtBrojSobe.Text = restoran.brojProstorije;
                txtKapacitet.Text = restoran.kapacitetRestorana.ToString();
                txtCena.Text = restoran.cena.ToString();
            }
            else if (this.prostorija == 4)
            {

                txtKrevet.Visible = false;
                txtKlima.Visible = false;
                txtTerasa.Visible = false;
                txtTv.Visible = false;
                txtOpis.Visible = false;
                txtSprat.Visible = false;
                txtKapacitet.Visible = false;
                label2.Visible = false;
                label3.Visible = false;
                label4.Visible = false;
                label5.Visible = false;
                label6.Visible = false;
                label8.Visible = false;
                lblKapacitet.Visible = false;

                txtBrojSobe.Text = bazen.brojProstorije;
                txtTipBazena.Text = bazen.tip.ToString();
                txtCena.Text = bazen.cena.ToString();
            }
        }

        private void btnIzmeni_Click(object sender, EventArgs e)
        {
            if (this.soba != null)
            {
                this.soba.brojProstorije = txtBrojSobe.Text;
                this.soba.brojKreveta = txtKrevet.Text;
                this.soba.sprat = txtSprat.Text;
                this.soba.klima = txtKlima.Text;
                this.soba.tv = txtTv.Text;
                this.soba.terasa = txtTerasa.Text;
                this.soba.opis = txtOpis.Text;
                this.soba.cena = Int32.Parse(txtCena.Text);

                Dictionary<string, object> queryDict = new Dictionary<string, object>();

                queryDict.Add("brojProstorije", soba.brojProstorije);
                queryDict.Add("brojKreveta", soba.brojKreveta);
                queryDict.Add("sprat", soba.sprat);
                queryDict.Add("klima", soba.klima);
                queryDict.Add("tv", soba.tv);
                queryDict.Add("terasa", soba.terasa);
                queryDict.Add("opis", soba.opis);
                queryDict.Add("cena", soba.cena);
                queryDict.Add("idProstorije", soba.idProstorije);

                var query1 = new Neo4jClient.Cypher.CypherQuery("MATCH (n:Prostorija:Soba{brojProstorije:'"
                    + soba.brojProstorije
                    + "'}) SET n={brojProstorije:'" + soba.brojProstorije + "',brojKreveta:'"
                    + soba.brojKreveta + "',sprat:'" + soba.sprat + "',klima:'" + soba.klima + "',tv:'"
                    + soba.klima + "',cena:'" + soba.cena.ToString() + "',opis:'" + soba.opis + "',terasa:'"
                    + soba.terasa + "'} return n",
                    queryDict, CypherResultMode.Set);



                List<Soba> sobe = ((IRawGraphClient)client).ExecuteGetCypherResults<Soba>(query1).ToList();
            }
            else if (this.sala != null)
            {
                this.sala.brojProstorije = txtBrojSobe.Text;
                this.sala.kapacitetSale = Int32.Parse(txtKapacitet.Text);
                this.sala.cena = Int32.Parse(txtCena.Text);

                Dictionary<string, object> queryDict = new Dictionary<string, object>();

                queryDict.Add("brojProstorije", this.sala.brojProstorije);
                queryDict.Add("kapacitetSale", this.sala.kapacitetSale);
                queryDict.Add("cena", this.sala.cena);
                queryDict.Add("idProstorije", sala.idProstorije);

                var query1 = new Neo4jClient.Cypher.CypherQuery("MATCH (n:Prostorija:Sala{brojProstorije:'"
                    + sala.brojProstorije
                    + "'}) SET n={brojProstorije:'" + this.sala.brojProstorije + "',kapacitetSale:'"
                    + this.sala.kapacitetSale.ToString() + "',cena:'"
                    + this.sala.cena.ToString() + "'} return n",
                    queryDict, CypherResultMode.Set);



                List<Sala> sale = ((IRawGraphClient)client).ExecuteGetCypherResults<Sala>(query1).ToList();

            }
            else if (this.restoran != null)
            {
                this.restoran.brojProstorije = txtBrojSobe.Text;
                this.restoran.kapacitetRestorana = Int32.Parse(txtKapacitet.Text);
                this.restoran.cena = Int32.Parse(txtCena.Text);

                Dictionary<string, object> queryDict = new Dictionary<string, object>();

                queryDict.Add("brojProstorije", this.restoran.brojProstorije);
                queryDict.Add("kapacitetRestorana", this.restoran.kapacitetRestorana);
                queryDict.Add("cena", this.restoran.cena);
                queryDict.Add("idProstorije", restoran.idProstorije);

                var query1 = new Neo4jClient.Cypher.CypherQuery("MATCH (n:Prostorija:Restoran{brojProstorije:'"
                    + restoran.brojProstorije
                    + "'}) SET n={brojProstorije:'" + this.restoran.brojProstorije + "',kapacitetRestorana:'"
                    + this.restoran.kapacitetRestorana.ToString() + "',cena:'"
                    + this.restoran.cena.ToString() + "'} return n",
                    queryDict, CypherResultMode.Set);



                List<Restoran> restorani = ((IRawGraphClient)client).ExecuteGetCypherResults<Restoran>(query1).ToList();

            }
            else if (this.bazen != null)
            {
                this.bazen.brojProstorije = txtBrojSobe.Text;
                this.bazen.tip = txtKapacitet.Text;
                this.bazen.cena = Int32.Parse(txtCena.Text);

                Dictionary<string, object> queryDict = new Dictionary<string, object>();

                queryDict.Add("brojProstorije", this.bazen.brojProstorije);
                queryDict.Add("tip", this.bazen.tip);
                queryDict.Add("cena", this.bazen.cena);
                queryDict.Add("idProstorije", bazen.idProstorije);

                var query1 = new Neo4jClient.Cypher.CypherQuery("MATCH (n:Prostorija:Bazen{brojProstorije:'"
                    + bazen.brojProstorije
                    + "'}) SET n={brojProstorije:'" + this.bazen.brojProstorije + "',tip:'"
                    + this.bazen.tip + "',cena:'"
                    + this.bazen.cena.ToString() + "'} return n",
                    queryDict, CypherResultMode.Set);



                List<Bazen> bazeni = ((IRawGraphClient)client).ExecuteGetCypherResults<Bazen>(query1).ToList();

            }
            //  novaSoba
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnIzmeni_Click_1(object sender, EventArgs e)
        {
            if (this.soba != null)
            {
                this.soba.brojProstorije = txtBrojSobe.Text;
                this.soba.brojKreveta = txtKrevet.Text;
                this.soba.sprat = txtSprat.Text;
                this.soba.klima = txtKlima.Text;
                this.soba.tv = txtTv.Text;
                this.soba.terasa = txtTerasa.Text;
                this.soba.opis = txtOpis.Text;
                this.soba.cena = Int32.Parse(txtCena.Text);

                Dictionary<string, object> queryDict = new Dictionary<string, object>();

                queryDict.Add("brojProstorije", soba.brojProstorije);
                queryDict.Add("brojKreveta", soba.brojKreveta);
                queryDict.Add("sprat", soba.sprat);
                queryDict.Add("klima", soba.klima);
                queryDict.Add("tv", soba.tv);
                queryDict.Add("terasa", soba.terasa);
                queryDict.Add("opis", soba.opis);
                queryDict.Add("cena", soba.cena);
                queryDict.Add("idProstorije", soba.idProstorije);

                var query1 = new Neo4jClient.Cypher.CypherQuery("MATCH (n:Prostorija:Soba{brojProstorije:'"+ soba.brojProstorije
                                                            + "'}) SET n={brojProstorije:'" + soba.brojProstorije 
                                                            + "',brojKreveta:'"+ soba.brojKreveta + "',sprat:'" + soba.sprat 
                                                            + "',klima:'" + soba.klima 
                                                            + "',tv:'" + soba.klima + "',cena:'" + soba.cena.ToString() + 
                                                            "',opis:'" + soba.opis + "',terasa:'"+ soba.terasa + "'} return n",
                                                            queryDict, CypherResultMode.Set);



                List<Soba> sobe = ((IRawGraphClient)client).ExecuteGetCypherResults<Soba>(query1).ToList();
            }
            else if (this.sala != null)
            {
                this.sala.brojProstorije = txtBrojSobe.Text;
                this.sala.kapacitetSale = Int32.Parse(txtKapacitet.Text);
                this.sala.cena = Int32.Parse(txtCena.Text);

                Dictionary<string, object> queryDict = new Dictionary<string, object>();

                queryDict.Add("brojProstorije", this.sala.brojProstorije);
                queryDict.Add("kapacitetSale", this.sala.kapacitetSale);
                queryDict.Add("cena", this.sala.cena);
                queryDict.Add("idProstorije", sala.idProstorije);

                var query1 = new Neo4jClient.Cypher.CypherQuery("MATCH (n:Prostorija:Sala{brojProstorije:'"
                    + sala.brojProstorije
                    + "'}) SET n={brojProstorije:'" + this.sala.brojProstorije + "',kapacitetSale:'"
                    + this.sala.kapacitetSale.ToString() + "',cena:'"
                    + this.sala.cena.ToString() + "'} return n",
                    queryDict, CypherResultMode.Set);



                List<Sala> sale = ((IRawGraphClient)client).ExecuteGetCypherResults<Sala>(query1).ToList();

            }
            else if (this.restoran != null)
            {
                this.restoran.brojProstorije = txtBrojSobe.Text;
                this.restoran.kapacitetRestorana = Int32.Parse(txtKapacitet.Text);
                this.restoran.cena = Int32.Parse(txtCena.Text);

                Dictionary<string, object> queryDict = new Dictionary<string, object>();

                queryDict.Add("brojProstorije", this.restoran.brojProstorije);
                queryDict.Add("kapacitetRestorana", this.restoran.kapacitetRestorana);
                queryDict.Add("cena", this.restoran.cena);
                queryDict.Add("idProstorije", restoran.idProstorije);

                var query1 = new Neo4jClient.Cypher.CypherQuery("MATCH (n:Prostorija:Restoran{brojProstorije:'"
                    + restoran.brojProstorije
                    + "'}) SET n={brojProstorije:'" + this.restoran.brojProstorije + "',kapacitetRestorana:'"
                    + this.restoran.kapacitetRestorana.ToString() + "',cena:'"
                    + this.restoran.cena.ToString() + "'} return n",
                    queryDict, CypherResultMode.Set);



                List<Restoran> restorani = ((IRawGraphClient)client).ExecuteGetCypherResults<Restoran>(query1).ToList();

            }
            else if (this.bazen != null)
            {
                this.bazen.brojProstorije = txtBrojSobe.Text;
                this.bazen.tip = txtTipBazena.Text;
                this.bazen.cena = Int32.Parse(txtCena.Text);

                Dictionary<string, object> queryDict = new Dictionary<string, object>();

                queryDict.Add("brojProstorije", this.bazen.brojProstorije);
                queryDict.Add("tip", this.bazen.tip);
                queryDict.Add("cena", this.bazen.cena);
                queryDict.Add("idProstorije", bazen.idProstorije);

                var query1 = new Neo4jClient.Cypher.CypherQuery("MATCH (n:Prostorija:Bazen{brojProstorije:'"
                    + bazen.brojProstorije
                    + "'}) SET n={brojProstorije:'" + this.bazen.brojProstorije + "',tip:'"
                    + this.bazen.tip + "',cena:'"
                    + this.bazen.cena.ToString() + "'} return n",
                    queryDict, CypherResultMode.Set);



                List<Bazen> bazeni = ((IRawGraphClient)client).ExecuteGetCypherResults<Bazen>(query1).ToList();

            }
            //  novaSoba
            this.DialogResult = DialogResult.OK;
            this.Close();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void IzmeniSobu_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawRectangle(new Pen(Color.White, 5),
                           this.DisplayRectangle);
        }
    }
}
