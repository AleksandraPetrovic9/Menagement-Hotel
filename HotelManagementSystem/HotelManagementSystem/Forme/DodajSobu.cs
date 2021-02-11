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
    public partial class DodajSobu : Form
    {
        public GraphClient client;
        public int prostorija;
        public DodajSobu()
        {
            InitializeComponent();
        }
        public DodajSobu(int p)
        {
            this.prostorija = p;

            InitializeComponent();

        }
        private void DodajSobu_Load(object sender, EventArgs e)
        {
            if (this.prostorija == 1)
            {//dodavanje sobe

                lblBroj.Text += "sobe";
                lblKapacitet.Visible = false;
                txtKapacitet.Visible = false;
                lblTip.Visible = false;
                txtTipBazena.Visible = false;


            }
            else if (this.prostorija == 2)
            {
                lblBroj.Text += "sale";
                lblKapacitet.Text += "sale";
                lblTip.Visible = false;
                txtTipBazena.Visible = false;
                label2.Visible = false;
                label3.Visible = false;
                label4.Visible = false;
                label5.Visible = false;
                label6.Visible = false;
                label8.Visible = false;
                txtKlima.Visible = false;
                txtKrevet.Visible = false;
                txtOpis.Visible = false;
                txtSprat.Visible = false;
                txtTerasa.Visible = false;
                txtTv.Visible = false;
                lblTip.Visible = false;
                txtTipBazena.Visible = false;

            }
            else if (this.prostorija == 3)
            {
                lblBroj.Text += "restorana";
                lblKapacitet.Text += "restorana";
                lblTip.Visible = false;
                txtTipBazena.Visible = false;
                label2.Visible = false;
                label3.Visible = false;
                label4.Visible = false;
                label5.Visible = false;
                label6.Visible = false;
                label8.Visible = false;
                txtKlima.Visible = false;
                txtKrevet.Visible = false;
                txtOpis.Visible = false;
                txtSprat.Visible = false;
                txtTerasa.Visible = false;
                txtTv.Visible = false;

            }
            else if (this.prostorija == 4)
            {
                lblBroj.Text += "bazena";
                lblKapacitet.Visible = false;
                txtKapacitet.Visible = false;
                label2.Visible = false;
                label3.Visible = false;
                label4.Visible = false;
                label5.Visible = false;
                label6.Visible = false;
                label8.Visible = false;
                txtKlima.Visible = false;
                txtKrevet.Visible = false;
                txtOpis.Visible = false;
                txtSprat.Visible = false;
                txtTerasa.Visible = false;
                txtTv.Visible = false;

            }

        }

   /*     private void btnDodaj_Click(object sender, EventArgs e)
        {
            // MessageBox.Show(maxId().ToString());
            if (prostorija == 1)
            {
                Soba soba = this.kreirajSobu();
                string id = maxId();

                try
                {
                    int mId = Int32.Parse(id);
                    soba.idProstorije = (mId++).ToString();

                }
                catch (Exception exception)
                {
                    soba.idProstorije = "";
                }


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


                var query1 = new Neo4jClient.Cypher.CypherQuery("CREATE (n:Prostorija:Soba {brojProstorije:'" + soba.brojProstorije + "',brojKreveta:'"
                                                                + soba.brojKreveta + "',sprat:'" + soba.sprat
                                                                + "', klima:'" + soba.klima + "', tv:'" + soba.tv + "', terasa:'" + soba.terasa + "', cena:'" + soba.cena.ToString()
                                                                + "', opis:'" + soba.opis
                                                                + "'}) return n",
                                                                queryDict, CypherResultMode.Set);



                List<Soba> sobe = ((IRawGraphClient)client).ExecuteGetCypherResults<Soba>(query1).ToList();

                //this.DialogResult = DialogResult.OK;
                //this.Close();
            }
            else if (this.prostorija == 2)
            {
                Sala sala = this.kreirajSalu();
                string id = maxId();

                try
                {
                    int mId = Int32.Parse(id);
                    sala.idProstorije = (mId++).ToString();

                }
                catch (Exception exception)
                {
                    sala.idProstorije = "";
                }

                Dictionary<string, object> queryDict = new Dictionary<string, object>();

                queryDict.Add("brojProstorije", sala.brojProstorije);
                queryDict.Add("kapacitetSale", sala.kapacitetSale.ToString());
                queryDict.Add("cena", sala.cena.ToString());
                queryDict.Add("idProstorije", sala.idProstorije);


                var query1 = new Neo4jClient.Cypher.CypherQuery("CREATE (n:Prostorija:Sala {brojProstorije:'" + sala.brojProstorije + "',kapcitetSale:'"
                                                                + sala.kapacitetSale.ToString() + "', cena:'" + sala.cena.ToString()
                                                                + "'}) return n",
                                                                queryDict, CypherResultMode.Set);



                List<Sala> sale = ((IRawGraphClient)client).ExecuteGetCypherResults<Sala>(query1).ToList();

                //this.DialogResult = DialogResult.OK;
                //this.Close();
            }
            else if (this.prostorija == 3)
            {
                Restoran restoran = this.kreirajRestoran();
                string id = maxId();

                try
                {
                    int mId = Int32.Parse(id);
                    restoran.idProstorije = (mId++).ToString();

                }
                catch (Exception exception)
                {
                    restoran.idProstorije = "";
                }

                Dictionary<string, object> queryDict = new Dictionary<string, object>();

                queryDict.Add("brojProstorije", restoran.brojProstorije);
                queryDict.Add("kapacitetRestorana", restoran.kapacitetRestorana.ToString());
                queryDict.Add("cena", restoran.cena.ToString());
                queryDict.Add("idProstorije", restoran.idProstorije);


                var query1 = new Neo4jClient.Cypher.CypherQuery("CREATE (n:Prostorija:Restoran {brojProstorije:'" + restoran.brojProstorije + "',kapcitetRestorana:'"
                                                                + restoran.kapacitetRestorana.ToString() + "', cena:'" + restoran.cena.ToString()
                                                                + "'}) return n",
                                                                queryDict, CypherResultMode.Set);



                List<Restoran> restorani = ((IRawGraphClient)client).ExecuteGetCypherResults<Restoran>(query1).ToList();

                //this.DialogResult = DialogResult.OK;
                //this.Close();
            }
            else if (this.prostorija == 4)
            {
                Bazen bazen = this.kreirajBazen();
                string id = maxId();

                try
                {
                    int mId = Int32.Parse(id);
                    bazen.idProstorije = (mId++).ToString();

                }
                catch (Exception exception)
                {
                    bazen.idProstorije = "";
                }

                Dictionary<string, object> queryDict = new Dictionary<string, object>();

                queryDict.Add("brojProstorije", bazen.brojProstorije);
                queryDict.Add("tip", bazen.tip.ToString());
                queryDict.Add("cena", bazen.cena.ToString());
                queryDict.Add("idProstorije", bazen.idProstorije);


                var query1 = new Neo4jClient.Cypher.CypherQuery("CREATE (n:Prostorija:Bazen {brojProstorije:'" + bazen.brojProstorije + "',tip:'"
                                                                + bazen.tip.ToString() + "', cena:'" + bazen.cena.ToString()
                                                                + "'}) return n",
                                                                queryDict, CypherResultMode.Set);



                List<Bazen> bazeni = ((IRawGraphClient)client).ExecuteGetCypherResults<Bazen>(query1).ToList();

                //this.DialogResult = DialogResult.OK;
                //this.Close();
            }
            this.DialogResult = DialogResult.OK;
            this.Close();

            //PregledSobe ps = new PregledSobe();
            //ps.client = client;
            //ps.ucitajSobe();

        }*/
        private String maxId()
        {
            var query = new Neo4jClient.Cypher.CypherQuery("start n=node(*) where exists(n.id) return max(n.id)",
                                                            new Dictionary<string, object>(), CypherResultMode.Set);

            String maxId = ((IRawGraphClient)client).ExecuteGetCypherResults<String>(query).ToList().FirstOrDefault();

            return maxId;
        }
        private Soba kreirajSobu()
        {
            Soba s = new Soba();

            //TimeSpan unixtime =
            //    dateTimePicker1.Value.ToUniversalTime() - new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            s.brojProstorije = txtBrojSobe.Text.ToString();
            s.brojKreveta = txtKrevet.Text.ToString();
            s.sprat = txtSprat.Text.ToString();
            s.klima = txtKlima.Text.ToString();
            s.tv = txtTv.Text.ToString();
            s.terasa = txtTerasa.Text.ToString();
            s.opis = txtOpis.Text.ToString();
            s.cena = Int32.Parse(txtCena.Text);


            return s;
        }
        private Sala kreirajSalu()
        {
            Sala s = new Sala();

            //TimeSpan unixtime =
            //    dateTimePicker1.Value.ToUniversalTime() - new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            s.brojProstorije = txtBrojSobe.Text.ToString();
            s.kapacitetSale = Int32.Parse(txtKapacitet.Text);
            s.cena = Int32.Parse(txtCena.Text);


            return s;
        }
        private Restoran kreirajRestoran()
        {
            Restoran r = new Restoran();

            //TimeSpan unixtime =
            //    dateTimePicker1.Value.ToUniversalTime() - new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            r.brojProstorije = txtBrojSobe.Text.ToString();
            r.kapacitetRestorana = Int32.Parse(txtKapacitet.Text);
            r.cena = Int32.Parse(txtCena.Text);


            return r;
        }
        private Bazen kreirajBazen()
        {
            Bazen r = new Bazen();

            //TimeSpan unixtime =
            //    dateTimePicker1.Value.ToUniversalTime() - new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            r.brojProstorije = txtBrojSobe.Text.ToString();
            r.tip = txtTipBazena.Text;
            r.cena = Int32.Parse(txtCena.Text);


            return r;
        }

        private void btnDodaj_Click_1(object sender, EventArgs e)
        {
            if (prostorija == 1)
            {
                Soba soba = this.kreirajSobu();
                string id = maxId();

                try
                {
                    int mId = Int32.Parse(id);
                    soba.idProstorije = (mId++).ToString();

                }
                catch (Exception exception)
                {
                    soba.idProstorije = "";
                }


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


                var query1 = new Neo4jClient.Cypher.CypherQuery("CREATE (n:Prostorija:Soba {brojProstorije:'" + soba.brojProstorije
                                                            + "',brojKreveta:'" + soba.brojKreveta + "',sprat:'" + soba.sprat
                                                                + "', klima:'" + soba.klima + "', tv:'" + soba.tv 
                                                                + "', terasa:'" + soba.terasa + "', cena:'" + soba.cena.ToString()
                                                                + "', opis:'" + soba.opis
                                                                + "'}) return n",
                                                                queryDict, CypherResultMode.Set);



                List<Soba> sobe = ((IRawGraphClient)client).ExecuteGetCypherResults<Soba>(query1).ToList();

                //this.DialogResult = DialogResult.OK;
                //this.Close();
            }
            else if (this.prostorija == 2)
            {
                Sala sala = this.kreirajSalu();
                string id = maxId();

                try
                {
                    int mId = Int32.Parse(id);
                    sala.idProstorije = (mId++).ToString();

                }
                catch (Exception exception)
                {
                    sala.idProstorije = "";
                }

                Dictionary<string, object> queryDict = new Dictionary<string, object>();

                queryDict.Add("brojProstorije", sala.brojProstorije);
                queryDict.Add("kapacitetSale", sala.kapacitetSale.ToString());
                queryDict.Add("cena", sala.cena.ToString());
                queryDict.Add("idProstorije", sala.idProstorije);


                var query1 = new Neo4jClient.Cypher.CypherQuery("CREATE (n:Prostorija:Sala {brojProstorije:'" + sala.brojProstorije + "',kapacitetSale:'"
                                                                + sala.kapacitetSale.ToString() + "', cena:'" + sala.cena.ToString()
                                                                + "'}) return n",
                                                                queryDict, CypherResultMode.Set);



                List<Sala> sale = ((IRawGraphClient)client).ExecuteGetCypherResults<Sala>(query1).ToList();

                //this.DialogResult = DialogResult.OK;
                //this.Close();
            }
            else if (this.prostorija == 3)
            {
                Restoran restoran = this.kreirajRestoran();
                string id = maxId();

                try
                {
                    int mId = Int32.Parse(id);
                    restoran.idProstorije = (mId++).ToString();

                }
                catch (Exception exception)
                {
                    restoran.idProstorije = "";
                }

                Dictionary<string, object> queryDict = new Dictionary<string, object>();

                queryDict.Add("brojProstorije", restoran.brojProstorije);
                queryDict.Add("kapacitetRestorana", restoran.kapacitetRestorana.ToString());
                queryDict.Add("cena", restoran.cena.ToString());
                queryDict.Add("idProstorije", restoran.idProstorije);


                var query1 = new Neo4jClient.Cypher.CypherQuery("CREATE (n:Prostorija:Restoran {brojProstorije:'" + restoran.brojProstorije + "',kapacitetRestorana:'"
                                                                + restoran.kapacitetRestorana.ToString() + "', cena:'" + restoran.cena.ToString()
                                                                + "'}) return n",
                                                                queryDict, CypherResultMode.Set);



                List<Restoran> restorani = ((IRawGraphClient)client).ExecuteGetCypherResults<Restoran>(query1).ToList();

                //this.DialogResult = DialogResult.OK;
                //this.Close();
            }
            else if (this.prostorija == 4)
            {
                Bazen bazen = this.kreirajBazen();
                string id = maxId();

                try
                {
                    int mId = Int32.Parse(id);
                    bazen.idProstorije = (mId++).ToString();

                }
                catch (Exception exception)
                {
                    bazen.idProstorije = "";
                }

                Dictionary<string, object> queryDict = new Dictionary<string, object>();

                queryDict.Add("brojProstorije", bazen.brojProstorije);
                queryDict.Add("tip", bazen.tip.ToString());
                queryDict.Add("cena", bazen.cena.ToString());
                queryDict.Add("idProstorije", bazen.idProstorije);


                var query1 = new Neo4jClient.Cypher.CypherQuery("CREATE (n:Prostorija:Bazen {brojProstorije:'" + bazen.brojProstorije + "',tip:'"
                                                                + bazen.tip.ToString() + "', cena:'" + bazen.cena.ToString()
                                                                + "'}) return n",
                                                                queryDict, CypherResultMode.Set);



                List<Bazen> bazeni = ((IRawGraphClient)client).ExecuteGetCypherResults<Bazen>(query1).ToList();

                //this.DialogResult = DialogResult.OK;
                //this.Close();
            }
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void DodajSobu_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawRectangle(new Pen(Color.White, 5),
                            this.DisplayRectangle);
        }
    }
}
