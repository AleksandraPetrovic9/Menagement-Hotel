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
    public partial class DodajRezervaciju : Form
    {
        public GraphClient client;
        public List<Gost> gosti; //dodala sam da ne bih dva puta pisala isti upit
        String prostorija = "";
        public DodajRezervaciju()
        {
            InitializeComponent();
            cmbProstorija.Text = "Izaberite prostoriju";
            cmbProstorija.Items.Insert(0, "Soba");
            cmbProstorija.Items.Insert(1, "Konferencijska sala");
            cmbProstorija.Items.Insert(2, "Restoran");
            cmbProstorija.Items.Insert(3, "Bazen");
            gosti = new List<Gost>();

            dgvProstorije.ForeColor = Color.Black;
        }

        private Soba vratiSobu(String brojSobe)
        {
            //var query1 = new Neo4jClient.Cypher.CypherQuery("match(n:Prostorija:Soba) where n.brojProstorije = " + brojSobe + " return n",
            //                                                          new Dictionary<string, object>(), CypherResultMode.Set);
            //List<Soba> soba = ((IRawGraphClient)client).ExecuteGetCypherResults<Soba>(query1).ToList();

            //return soba[0];
            Dictionary<string, object> queryDict = new Dictionary<string, object>();
            queryDict.Add("brojProstorije", brojSobe);
            var query = new Neo4jClient.Cypher.CypherQuery("start n=node(*) where (n:Prostorija) and exists(n.brojProstorije) and n.brojProstorije =~ {brojProstorije} return n",
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
        private void btnDodajGoste_Click(object sender, EventArgs e)
        {

            DodavanjeGosta gost = new DodavanjeGosta();
            gost.client = client;
            gost.ShowDialog();
            Gost g = gost.vratiGosta();
            if (g == null)
                return;
            else
            {
                gosti.Add(g);
                //lvGosti.Items.Add(g.imeGosta, g.prezimeGosta, g.dokumentIdentifikacije);
                ListViewItem lvi = new ListViewItem(g.ime);
                //lvi.text = g.imeGosta;
                lvi.SubItems.Add(g.prezime);
                lvi.SubItems.Add(g.dokument);
                lvi.SubItems.Add(g.email);
                lvi.SubItems.Add(g.brojTelefona);

                lvGosti.Items.Add(lvi);
            }
        }

        private void btnZapamtiRezervaciju_Click(object sender, EventArgs e)
        {
            if (dgvProstorije.SelectedRows.Count == 0)
            {
                MessageBox.Show("Morate izabrati prostoriju.");
                return;
            }

            foreach (Gost g in gosti)
            {
                // MessageBox.Show(g.idGosta);
                Rezervacija r = new Rezervacija();
                r.datumDo = dtpDatumDo.Value;
                r.datumOd = dtpDatumOd.Value;
              //  r.ukupnaCena = lblCena.Text;
                String brojSobe = dgvProstorije.SelectedRows[0].Cells[0].Value.ToString();
                r.prostorija = vratiSobu(brojSobe);

                if (lblPopust.Equals("")) 
                r.ukupnaCena = lblCena.Text;
                else
                    r.ukupnaCena = lblPopust.Text;

                DateTime today = DateTime.Today;
               // MessageBox.Show("b: Prostorija:"+ prostorija );
                //where (n:Soba) and exists(n.brojProstorije)
                var query1 = new Neo4jClient.Cypher.CypherQuery("match (a:Gost),(b:Prostorija:"+ prostorija
                    +" ) WHERE a.dokument = '" + g.dokument + "'  AND  b.brojProstorije = '" + brojSobe 
                    + "' CREATE (a)-[r:REZERVACIJA{datumOd: date({day:" + r.datumOd.Day
                    + ", month: " + r.datumOd.Month + ", year: " + r.datumOd.Year + " }), datumDo: date({day:"
                    + r.datumDo.Day+ ", month: " + r.datumDo.Month + ", year: " + r.datumDo.Year 
                    + " }),datumRezervacije:date({day:"+today.Day+",month:"+today.Month+",year:"+today.Year
                    +"}), ukupnaCena: '" + r.ukupnaCena + "',aktivna:'true' }]->(b) return r",
                                                          new Dictionary<string, object>(), CypherResultMode.Set);
                ((IRawGraphClient)client).ExecuteCypher(query1);

            }
            this.Close();
        }

        private void btnIzracunajCenu_Click(object sender, EventArgs e)
        {
            if (dgvProstorije.SelectedRows.Count != 1)
            {
                MessageBox.Show("Mozete izabrati samo jednu prostoriju");
                return;
            }
            DataGridViewRow row = dgvProstorije.SelectedRows[0];
            float cena = float.Parse(row.Cells[2].Value.ToString());
            int brojdana = new TimeSpan(dtpDatumDo.Value.Date.Ticks - dtpDatumOd.Value.Date.Ticks).Days;
            lblCena.Text = ((brojdana+1) * cena).ToString();
        }

        private void dgvProstorije_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnIzadji_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void DodajRezervaciju_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawRectangle(new Pen(Color.White, 5),
                            this.DisplayRectangle);
        }

        private void cmbProstorija_SelectedIndexChanged(object sender, EventArgs e)
        {
            dgvProstorije.Rows.Clear();
            //pamti kao broj
            String filter = cmbProstorija.SelectedIndex.ToString();
            if (filter == "-1")
            {
                MessageBox.Show("Izaberite filter");
                return;
            }

            switch (filter)
            {
                case "0":
                    {
                        prostorija = "Soba";
                        DateTime datumOd = dtpDatumOd.Value.Date;
                        DateTime datumDo = dtpDatumDo.Value.Date;
                        //MessageBox.Show(datumDo);
                        Dictionary<string, object> queryDict = new Dictionary<string, object>();
                        queryDict.Add("datumOd", dtpDatumOd.Value);
                        queryDict.Add("datumDo", dtpDatumDo.Value);

                        var query = new Neo4jClient.Cypher.CypherQuery("MATCH(n) -[r: REZERVACIJA]->(a:Prostorija:Soba) where r.datumOd >= date({ day:  " + datumOd.Day + ", month: " + datumOd.Month + ", year: " + datumOd.Year + "})  and r.datumOd <=  date({ day:  " + datumDo.Day + ", month: " + datumDo.Month + ", year: " + datumDo.Year + "}) or (r.datumDo >=  date({ day: " + datumOd.Day + ", month: " + datumOd.Month + ", year: " + datumOd.Year + "})  and r.datumDo <=  date({ day:  " + datumDo.Day + ", month: " + datumDo.Month + ", year: " + datumDo.Year + "}) ) return a",
                                                                        queryDict, CypherResultMode.Set);

                        List<Soba> sobe = ((IRawGraphClient)client).ExecuteGetCypherResults<Soba>(query).ToList();

                        var query1 = new Neo4jClient.Cypher.CypherQuery("match(n:Prostorija:Soba)return n",
                                                                      new Dictionary<string, object>(), CypherResultMode.Set);
                        List<Soba> sveSobe = ((IRawGraphClient)client).ExecuteGetCypherResults<Soba>(query1).ToList();


                        foreach (Soba a in sobe)
                        {
                          // MessageBox.Show(a.brojProstorije);
                            if(sveSobe.Exists(x => x.brojProstorije == a.brojProstorije))
                            {
                                var s = sveSobe.Where(x => x.brojProstorije == a.brojProstorije).ToList();
                                sveSobe.Remove(s.First());
                            }
                        }

                        dgvProstorije.ColumnCount = 7;
                        dgvProstorije.Columns[0].Name = "Broj sobe";
                        dgvProstorije.Columns[1].Name = "Broj kreveta";
                        dgvProstorije.Columns[2].Name = "Cena nocenja";
                        dgvProstorije.Columns[3].Name = "Klima";
                        dgvProstorije.Columns[4].Name = "TV";
                        dgvProstorije.Columns[5].Name = "Terasa";
                        dgvProstorije.Columns[6].Name = "Opis";
                       

                        foreach (Soba a in sveSobe)
                        {
                            
                            string[] row = new string[] { a.brojProstorije.ToString(), a.brojKreveta.ToString(),
                            a.cena.ToString(), a.klima, a.tv, a.terasa, a.opis};
                            dgvProstorije.Rows.Add(row);
                        }

                        //MessageBox.Show(dgvProstorije.Rows[0].Cells[7].Value.ToString());
                    }
                    break;
                case "1":
                    {
                        prostorija = "Sala";
                        DateTime datumOd = dtpDatumOd.Value.Date;
                        DateTime datumDo = dtpDatumDo.Value.Date;
                        //MessageBox.Show("sala");
                        Dictionary<string, object> queryDict = new Dictionary<string, object>();
                        queryDict.Add("datumOd", dtpDatumOd.Value);
                        queryDict.Add("datumDo", dtpDatumDo.Value);

                        var query = new Neo4jClient.Cypher.CypherQuery("MATCH(n) -[r: REZERVACIJA]->(a:Sala) where r.datumOd >= date({ day:  "
                            + datumOd.Day + ", month: " + datumOd.Month + ", year: " + datumOd.Year
                            + "})  and r.datumOd <=  date({ day:  " + datumDo.Day + ", month: "
                            + datumDo.Month + ", year: " + datumDo.Year + "}) or (r.datumDo >=  date({ day: "
                            + datumOd.Day + ", month: " + datumOd.Month + ", year: " + datumOd.Year
                            + "})  and r.datumDo <=  date({ day:  " + datumDo.Day + ", month: "
                            + datumDo.Month + ", year: " + datumDo.Year + "}) ) return a",
                                                                        queryDict, CypherResultMode.Set);

                        List<Sala> sale = ((IRawGraphClient)client).ExecuteGetCypherResults<Sala>(query).ToList();

                        var query1 = new Neo4jClient.Cypher.CypherQuery("match(n:Prostorija:Sala)return n",
                                                                      new Dictionary<string, object>(), CypherResultMode.Set);
                        List<Sala> sveSale = ((IRawGraphClient)client).ExecuteGetCypherResults<Sala>(query1).ToList();

                        foreach (Sala a in sale)
                        {
                            
                            if (sveSale.Exists(x => x.brojProstorije == a.brojProstorije))
                            {
                                var s = sveSale.Where(x => x.brojProstorije == a.brojProstorije).ToList();
                                sveSale.Remove(s.First());
                            }
                        }

                        dgvProstorije.ColumnCount = 7;
                        dgvProstorije.Columns[0].Name = "Broj sale";
                        dgvProstorije.Columns[1].Name = "Kapacitet";
                        dgvProstorije.Columns[2].Name = "Cena ";
                      
                        foreach (Sala a in sveSale)
                        {
                            
                            string[] row = new string[] { a.brojProstorije.ToString(), a.kapacitetSale.ToString(),
                            a.cena.ToString()};
                            dgvProstorije.Rows.Add(row);
                        }


                    }
                    break;
                case "2":
                    {
                        prostorija = "Restoran";
                        DateTime datumOd = dtpDatumOd.Value.Date;
                        DateTime datumDo = dtpDatumDo.Value.Date;
                        //MessageBox.Show("sala");
                        Dictionary<string, object> queryDict = new Dictionary<string, object>();
                        queryDict.Add("datumOd", dtpDatumOd.Value);
                        queryDict.Add("datumDo", dtpDatumDo.Value);

                        var query = new Neo4jClient.Cypher.CypherQuery("MATCH(n) -[r: REZERVACIJA]->(a:Restoran) where r.datumOd >= date({ day:  "
                            + datumOd.Day + ", month: " + datumOd.Month + ", year: " + datumOd.Year
                            + "})  and r.datumOd <=  date({ day:  " + datumDo.Day + ", month: "
                            + datumDo.Month + ", year: " + datumDo.Year + "}) or (r.datumDo >=  date({ day: "
                            + datumOd.Day + ", month: " + datumOd.Month + ", year: " + datumOd.Year
                            + "})  and r.datumDo <=  date({ day:  " + datumDo.Day + ", month: "
                            + datumDo.Month + ", year: " + datumDo.Year + "}) ) return a",
                                                                        queryDict, CypherResultMode.Set);

                        List<Restoran> restorani = ((IRawGraphClient)client).ExecuteGetCypherResults<Restoran>(query).ToList();

                        var query1 = new Neo4jClient.Cypher.CypherQuery("match(n:Prostorija:Restoran)return n",
                                                                      new Dictionary<string, object>(), CypherResultMode.Set);
                        List<Restoran> sviRestorani = ((IRawGraphClient)client).ExecuteGetCypherResults<Restoran>(query1).ToList();

                        foreach (Restoran a in restorani)
                        {

                            if (sviRestorani.Exists(x => x.brojProstorije == a.brojProstorije))
                            {
                                var s = sviRestorani.Where(x => x.brojProstorije == a.brojProstorije).ToList();
                                sviRestorani.Remove(s.First());
                            }
                        }

                        dgvProstorije.ColumnCount = 7;
                        dgvProstorije.Columns[0].Name = "Broj restorana";
                        dgvProstorije.Columns[1].Name = "Kapacitet";
                        dgvProstorije.Columns[2].Name = "Cena ";
                       
                        foreach (Restoran a in sviRestorani)
                        {
                            
                            string[] row = new string[] { a.brojProstorije.ToString(), a.kapacitetRestorana.ToString(),
                            a.cena.ToString()};
                            dgvProstorije.Rows.Add(row);
                        }

                    }
                    break;
                case "3":
                    {
                        prostorija = "Bazen";
                        DateTime datumOd = dtpDatumOd.Value.Date;
                        DateTime datumDo = dtpDatumDo.Value.Date;
                       
                        Dictionary<string, object> queryDict = new Dictionary<string, object>();
                        queryDict.Add("datumOd", dtpDatumOd.Value);
                        queryDict.Add("datumDo", dtpDatumDo.Value);

                        var query = new Neo4jClient.Cypher.CypherQuery("MATCH(n) -[r: REZERVACIJA]->(a:Bazen) where r.datumOd >= date({ day:  "
                            + datumOd.Day + ", month: " + datumOd.Month + ", year: " + datumOd.Year
                            + "})  and r.datumOd <=  date({ day:  " + datumDo.Day + ", month: "
                            + datumDo.Month + ", year: " + datumDo.Year + "}) or (r.datumDo >=  date({ day: "
                            + datumOd.Day + ", month: " + datumOd.Month + ", year: " + datumOd.Year
                            + "})  and r.datumDo <=  date({ day:  " + datumDo.Day + ", month: "
                            + datumDo.Month + ", year: " + datumDo.Year + "}) ) return a",
                                                                        queryDict, CypherResultMode.Set);

                        List<Bazen> bazeni = ((IRawGraphClient)client).ExecuteGetCypherResults<Bazen>(query).ToList();

                        var query1 = new Neo4jClient.Cypher.CypherQuery("match(n:Prostorija:Bazen)return n",
                                                                      new Dictionary<string, object>(), CypherResultMode.Set);
                        List<Bazen> sviBazeni = ((IRawGraphClient)client).ExecuteGetCypherResults<Bazen>(query1).ToList();

                        foreach (Bazen a in bazeni)
                        {

                            if (sviBazeni.Exists(x => x.brojProstorije == a.brojProstorije))
                            {
                                var s = sviBazeni.Where(x => x.brojProstorije == a.brojProstorije).ToList();
                                sviBazeni.Remove(s.First());
                            }
                        }

                        dgvProstorije.ColumnCount = 7;
                        dgvProstorije.Columns[0].Name = "Broj bazena";
                        dgvProstorije.Columns[1].Name = "Tip";
                        dgvProstorije.Columns[2].Name = "Cena ";

                        foreach (Bazen a in sviBazeni)
                        {
                            string[] row = new string[] { a.brojProstorije.ToString(), a.tip.ToString(),
                            a.cena.ToString()};
                            dgvProstorije.Rows.Add(row);
                        }

                    }
                    break;
                default:
                    break;

            }
        }



        public void NadjiSvePrijaveGosta(Gost gost)
        {
             Dictionary<string, object> queryDict = new Dictionary<string, object>();

             var query = new Neo4jClient.Cypher.CypherQuery("match(n:Gost{email:'" + gost.email 
                                                          + "'})-[r:ODJAVA ]->(s:Prostorija)  return r ",
                                                            queryDict, CypherResultMode.Set);
            
             List<Odjava> odjave = ((IRawGraphClient)client).ExecuteGetCypherResults<Odjava>(query).ToList();

             var query1 = new Neo4jClient.Cypher.CypherQuery("match(n:Gost{email:'" + gost.email + "'})-[r:ODJAVA ]->(s:Prostorija)  return n ",
                                                           queryDict, CypherResultMode.Set);

             List<Gost> gosti = ((IRawGraphClient)client).ExecuteGetCypherResults<Gost>(query1).ToList();

             var query2 = new Neo4jClient.Cypher.CypherQuery("match(n:Gost{email:'" + gost.email + "'})-[r:ODJAVA ]->(s:Prostorija)  return s ",
                                                          queryDict, CypherResultMode.Set);

             List<Prostorija> prostorije = ((IRawGraphClient)client).ExecuteGetCypherResults<Prostorija>(query2).ToList();

             var query3 = new Neo4jClient.Cypher.CypherQuery("match(n:Gost)-[r:ODJAVA ]->(s:Prostorija) return ID(n)",

                                                            queryDict, CypherResultMode.Set);

             List<String> listaID = ((IRawGraphClient)client).ExecuteGetCypherResults<String>(query3).ToList();


             for (int i = 0; i < odjave.Count; i++)
             {
                 gosti[i].idGosta = listaID[i].ToString();
                 odjave[i].gost = gosti[i];
                 odjave[i].prostorija = prostorije[i];
             }
             //List<Soba> sobeZaBrisanje = new List<Soba>(); 

             //listaGostijuPregledGostiju = gosti;
             //  listaRezervacija = rezervacije;
             foreach (Odjava r in odjave)
             {
                 string licno = "ne", osoblje = "ne", uslovi = "ne";
                 if (r.licno.Equals("true"))
                     licno = "da";
                 if (r.osoblje.Equals("true"))
                     osoblje = "da";
                 if (r.uslovi.Equals("true"))
                     uslovi = "da";
                 ListViewItem item = new ListViewItem(new string[] { r.gost.idGosta, r.gost.ime, r.gost.prezime, r.prostorija.brojProstorije.ToString(), r.gost.brojTelefona, r.gost.email, r.gost.dokument, r.datumOd.ToString("dd/MM/yyyy"), r.datumDo.ToString("dd/MM/yyyy"), r.datumOdjave.ToString("dd/MM/yyyy"),licno,osoblje,uslovi });

                 lvPopust.Items.Add(item);

             }
             lvPopust.Refresh();


        }

        private void btnPopust_Click(object sender, EventArgs e)
        {
           
           
            if (lvGosti.SelectedItems.Count == 0)
            {
                MessageBox.Show("Morate izabrati gosta.");
                return;
            }
            Gost gost = new Gost();
            string ime = lvGosti.SelectedItems[0].SubItems[0].Text;
            string prezime = lvGosti.SelectedItems[0].SubItems[1].Text;
            string dok = lvGosti.SelectedItems[0].SubItems[2].Text;
            string email = lvGosti.SelectedItems[0].SubItems[3].Text;
            string tel = lvGosti.SelectedItems[0].SubItems[4].Text;
          //  MessageBox.Show(ime + prezime + dok + email);
            gost.ime = ime;
            gost.prezime = prezime;
            gost.dokument = dok;
            gost.email = email; 
            gost.brojTelefona = tel;
            NadjiSvePrijaveGosta(gost);
            //FormPopust fp = new FormPopust(gost);
            ////fp.gost = gost;
            //fp.client = client;
            //fp.ShowDialog();
        }

        private void btnOstvariPopust_Click(object sender, EventArgs e)
        {
            int cena = Convert.ToInt32(lblCena.Text);
            cena = cena * 90 / 100;
            lblPopust.Text = cena.ToString();
        }

        private void DodajRezervaciju_Load(object sender, EventArgs e)
        {

        }

        private void btnPopust_MouseHover(object sender, EventArgs e)
        {
            toolTip1.Show("Kliknite ako zelite da vidite ranije rezervacije gosta.",btnPopust);
        }

        private void btnStatistika_Click(object sender, EventArgs e)
        {
            if (lvGosti.SelectedItems.Count == 0)
            {
                MessageBox.Show("Morate izabrati gosta.");
                return;
            }
            Gost gost = new Gost();
            string ime = lvGosti.SelectedItems[0].SubItems[0].Text;
            string prezime = lvGosti.SelectedItems[0].SubItems[1].Text;
            string dok = lvGosti.SelectedItems[0].SubItems[2].Text;
            string email = lvGosti.SelectedItems[0].SubItems[3].Text;
            string tel = lvGosti.SelectedItems[0].SubItems[4].Text;
            //  MessageBox.Show(ime + prezime + dok + email);
            gost.ime = ime;
            gost.prezime = prezime;
            gost.dokument = dok;
            gost.email = email;
            gost.brojTelefona = tel;

            FormStatistikaGosta fsg = new FormStatistikaGosta(gost);
            fsg.client = client;
            fsg.ShowDialog();

            //FormPopust fp = new FormPopust(gost);
            ////fp.gost = gost;
            //fp.client = client;
            //fp.ShowDialog();
        }
    }
}
