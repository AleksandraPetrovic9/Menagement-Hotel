using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Neo4jClient;
using HotelManagementSystem.DomainModel;
using Neo4jClient.Cypher;
using System.Windows.Forms.DataVisualization.Charting;

namespace HotelManagementSystem.Forme
{
    public partial class FormStatistika : Form
    {
        public GraphClient client;
        public FormStatistika()
        {
            InitializeComponent();
        }

        private void FormStatistika_Load(object sender, EventArgs e)
        {
            int prRezIPrijavilo = RezervisaloIPrijavilo();
            Title title = chartRezPrijavilo.Titles.Add("Koliki procenat gostiju se prijavio u hotel");
            title.ForeColor = System.Drawing.Color.FromArgb(255, 255, 255);
            chartRezPrijavilo.Series["Series1"].IsValueShownAsLabel = true;

            chartRezPrijavilo.Series["Series1"].Points.AddXY("Prijavljeni", prRezIPrijavilo);
            chartRezPrijavilo.Series["Series1"].Points.AddXY("Neprijavljeno", 100 - prRezIPrijavilo);
            //chartRezPrijavilo.Series["Series1"].Points[1].Color = Color.FromArgb(85, 66, 68);//

            Dictionary<string, float> hash = ProcenatOdjava();
            float osoblje, licno, uslovi, ocena;
            hash.TryGetValue("osoblje", out osoblje);
            hash.TryGetValue("licno", out licno);
            hash.TryGetValue("uslovi", out uslovi);
            hash.TryGetValue("ocena", out ocena);
            Title title1 = chartOdjava.Titles.Add("Razlog ranijeg odlaska gosta, u procentima");
            title1.ForeColor = System.Drawing.Color.FromArgb(255, 255, 255);
            chartOdjava.Series["Series1"].IsValueShownAsLabel = true;

            float ned = 100 - osoblje - licno - uslovi;
            chartOdjava.Series["Series1"].Points.AddXY("Osoblje", osoblje.ToString("n2"));
            chartOdjava.Series["Series1"].Points.AddXY("Licno", licno.ToString("n2"));
            chartOdjava.Series["Series1"].Points.AddXY("Uslovi", uslovi.ToString("n2"));
           // chartOdjava.Series["Series1"].Points.AddXY("Nedefinisano", ned.ToString("n2"));

           

            label1.Text = "Prosecna ocena koju su dali gosti koji su se na vreme odjavili:" + ocena.ToString("n2");


            //po mesecima
            Dictionary<string, int> hash1 = ProcenatPoMesecima();
            int jan = 0, feb = 0, mar = 0, apr = 0, maj = 0, jun = 0;
            int jul = 0, avg = 0, sep = 0, okt = 0, nov = 0, dec = 0;
            hash1.TryGetValue("jan", out jan);
            hash1.TryGetValue("feb", out feb);
            hash1.TryGetValue("mar", out mar);
            hash1.TryGetValue("apr", out apr);
            hash1.TryGetValue("maj", out maj);
            hash1.TryGetValue("jun", out jun);
            hash1.TryGetValue("jul", out jul);
            hash1.TryGetValue("avg", out avg);
            hash1.TryGetValue("sep", out sep);
            hash1.TryGetValue("okt", out okt);
            hash1.TryGetValue("nov", out nov);
            hash1.TryGetValue("dec", out dec);
            //Title title2 = chartPoMesecima.Titles.Add("Razlog ranijeg odlaska gosta, u procentima");
            //title2.ForeColor = System.Drawing.Color.FromArgb(255, 255, 255);
           // chartPoMesecima.Series["Series1"].IsValueShownAsLabel = true;

            chartPoMesecima.Series["Series1"].Points.AddXY("jan", jan);
            chartPoMesecima.Series["Series1"].Points.AddXY("feb", feb);
            chartPoMesecima.Series["Series1"].Points.AddXY("mar", mar);
            chartPoMesecima.Series["Series1"].Points.AddXY("apr", apr);
            chartPoMesecima.Series["Series1"].Points.AddXY("maj", maj);
            chartPoMesecima.Series["Series1"].Points.AddXY("jun", jun);
            chartPoMesecima.Series["Series1"].Points.AddXY("jul", jul);
            chartPoMesecima.Series["Series1"].Points.AddXY("avg", avg);
            chartPoMesecima.Series["Series1"].Points.AddXY("sep", sep);
            chartPoMesecima.Series["Series1"].Points.AddXY("okt", okt);
            chartPoMesecima.Series["Series1"].Points.AddXY("nov", nov);
            chartPoMesecima.Series["Series1"].Points.AddXY("dec", dec);

            chartPoMesecima.ChartAreas["ChartArea1"].AxisX.Interval = 1;




        }

        public int RezervisaloIPrijavilo()
        {

            Dictionary<string, object> queryDict = new Dictionary<string, object>();

            //var query = new Neo4jClient.Cypher.CypherQuery("MATCH (g:Gost )-[r:REZERVACIJA ]->(s:Prostorija) <-[p:PRIJAVA]->(gg: Gost) where r.datumOd=p.datumOd AND  r.datumDo=p.datumDo and g.email=gg.email    RETURN r ",
            //                                               queryDict, CypherResultMode.Set);

            //List<Rezervacija> rezervacije = ((IRawGraphClient)client).ExecuteGetCypherResults<Rezervacija>(query).ToList();

            //var query1 = new Neo4jClient.Cypher.CypherQuery("MATCH (g:Gost )-[r:REZERVACIJA ]->(s:Prostorija) <-[p:PRIJAVA]->(gg: Gost) where r.datumOd=p.datumOd AND  r.datumDo=p.datumDo and g.email=gg.email      return g ",
            //                                              queryDict, CypherResultMode.Set);

            //List<Gost> gosti = ((IRawGraphClient)client).ExecuteGetCypherResults<Gost>(query1).ToList();

            //var query2 = new Neo4jClient.Cypher.CypherQuery("MATCH (g:Gost )-[r:REZERVACIJA ]->(s:Prostorija) <-[p:PRIJAVA]->(gg: Gost) where r.datumOd=p.datumOd AND  r.datumDo=p.datumDo and g.email=gg.email   return s ",
            //                                             queryDict, CypherResultMode.Set);

            //List<Prostorija> prostorije = ((IRawGraphClient)client).ExecuteGetCypherResults<Prostorija>(query2).ToList();

            //var query3 = new Neo4jClient.Cypher.CypherQuery("MATCH (g:Gost )-[r:REZERVACIJA ]->(s:Prostorija) <-[p:PRIJAVA]->(gg: Gost) where r.datumOd=p.datumOd AND  r.datumDo=p.datumDo and g.email=gg.email return ID(g)",
            //                                               queryDict, CypherResultMode.Set);

            //List<String> listaID = ((IRawGraphClient)client).ExecuteGetCypherResults<String>(query3).ToList();


            //for (int i = 0; i < rezervacije.Count; i++)
            //{
            //    gosti[i].idGosta = listaID[i].ToString();
            //    rezervacije[i].gost = gosti[i];
            //    rezervacije[i].prostorija = prostorije[i];
            //}

            //da nadje sve prijave 
            var query4 = new Neo4jClient.Cypher.CypherQuery("MATCH (g:Gost )-[r:REZERVACIJA ]->(s:Prostorija) <-[p:PRIJAVA]->(gg: Gost) where r.datumOd=p.datumOd AND  r.datumDo=p.datumDo and g.email=gg.email    RETURN p ",
                                                           queryDict, CypherResultMode.Set);

            List<Prijava> prijave1 = ((IRawGraphClient)client).ExecuteGetCypherResults<Prijava>(query4).ToList();


            //var query5 = new Neo4jClient.Cypher.CypherQuery("match(n:Gost)-[r:PRIJAVA]->(s:Prostorija)  return n ",
            //                                                         queryDict, CypherResultMode.Set);

            //List<Gost> gosti1 = ((IRawGraphClient)client).ExecuteGetCypherResults<Gost>(query5).ToList();

            //var query6 = new Neo4jClient.Cypher.CypherQuery("match(n:Gost)-[r:PRIJAVA]->(s:Prostorija)  return s ",
            //                                             queryDict, CypherResultMode.Set);

            //List<Prostorija> prostorije1 = ((IRawGraphClient)client).ExecuteGetCypherResults<Prostorija>(query6).ToList();

            //var query7 = new Neo4jClient.Cypher.CypherQuery("match(n:Gost)-[r:PRIJAVA]->(s:Prostorija) return ID(n)",
            //                                               queryDict, CypherResultMode.Set);

            //List<String> listaID1 = ((IRawGraphClient)client).ExecuteGetCypherResults<String>(query7).ToList();


            //for (int i = 0; i < prijave1.Count; i++)
            //{
            //    gosti1[i].idGosta = listaID1[i].ToString();
            //    prijave1[i].gost = gosti1[i];
            //    prijave1[i].prostorija = prostorije1[i];
            //}
            //int br = 0;
            //   MessageBox.Show(prijave1.Count.ToString()+",rez:"+rezervacije.Count.ToString());
            //foreach (Rezervacija r in rezervacije)
            //{
            //    foreach (Prijava p in prijave1)
            //    {
            //        if (p.gost.email.Equals(r.gost.email))
            //            if (p.prostorija.brojProstorije.Equals(r.prostorija.brojProstorije))
            //                if (p.datumOd.ToString("dd/MM/yyyy").Equals(r.datumOd.ToString("dd/MM/yyyy")))
            //                    if (p.datumDo.ToString("dd/MM/yyyy").Equals(r.datumDo.ToString("dd/MM/yyyy")))
            //                        br++;


            //    }

            //}
            int ukupnoRezervacije = prijave1.Count();
          //  int procenatPrijavljenihRez = br * 100 / ukupnoRezervacije;
            
            return ukupnoRezervacije;
        }
        public Dictionary<string, float> ProcenatOdjava()
        {
            int[] niz = { 0, 0, 0, 0 };
            Dictionary<string, float> hash = new Dictionary<string, float>();

            Dictionary<string, object> queryDict = new Dictionary<string, object>();

            var query = new Neo4jClient.Cypher.CypherQuery("match(n:Gost)-[r:ODJAVA]->(s:Prostorija) " +
                "                                           where r.datumOdjave< r.datumDo  return r ",
                                                           queryDict, CypherResultMode.Set);

            List<Odjava> odjave = ((IRawGraphClient)client).ExecuteGetCypherResults<Odjava>(query).ToList();
            float uslovi = 0, licno = 0, osoblje = 0, ocena = 0, usloviBrojac = 0, ocenaBrojac = 0;


            var query1 = new Neo4jClient.Cypher.CypherQuery("match(n:Gost)-[r:ODJAVA]->(s:Prostorija) where r.datumOdjave< r.datumDo and r.uslovi=true return count(r) ",
                                                           queryDict, CypherResultMode.Set);

          //  String maxId = ((IRawGraphClient)client).ExecuteGetCypherResults<String>(query1).ToList().LastOrDefault();

           // MessageBox.Show(maxId);
            foreach (Odjava o in odjave)
            {
                //int result = DateTime.Compare(o.datumOdjave, o.datumDo);
                //string relationship;

                //if (result < 0)
                {
                    if (o.uslovi.Equals("true", StringComparison.OrdinalIgnoreCase))
                        uslovi++;
                    if (o.licno.Equals("true", StringComparison.OrdinalIgnoreCase))
                        licno++;
                    if (o.osoblje.Equals("true", StringComparison.OrdinalIgnoreCase))
                        osoblje++;

                    usloviBrojac++;
                    //relationship = "is earlier than"; 
                }
                //  else // (result == 0)
                {
                    if (o.ocena > 0)
                    {
                        ocena += o.ocena;
                        ocenaBrojac++;
                    }

                }



            }
           // MessageBox.Show("uslovi:"+uslovi.ToString());
            int ukupno = odjave.Count;
            float prUslovi = uslovi * 100 / (ukupno );
            float prLicno = licno * 100 / (ukupno);
            float prOsoblje = osoblje * 100 / (ukupno);

            float prOcena = ocena / ocenaBrojac;//ukupno

            //MessageBox.Show("UKUPNO:" + ukupno.ToString());
            //MessageBox.Show("PR USLOVI:" + prUslovi.ToString());
            //MessageBox.Show("PR OSOBLJE:" + prOsoblje.ToString());
            //MessageBox.Show("PR LICNO:" + prLicno.ToString());

            hash.Add("uslovi", prUslovi);
            hash.Add("licno", prLicno);
            hash.Add("osoblje", prOsoblje);
            hash.Add("ocena", prOcena);

            return hash;
        }


        public Dictionary<string, int> ProcenatPoMesecima()
        {
            Dictionary<string, int> hash = new Dictionary<string, int>();

            Dictionary<string, object> queryDict = new Dictionary<string, object>();

            var query = new Neo4jClient.Cypher.CypherQuery("match(n:Gost)-[r:PRIJAVA]->(s:Prostorija)  return r ",
                                                           queryDict, CypherResultMode.Set);

            List<Prijava> prijave = ((IRawGraphClient)client).ExecuteGetCypherResults<Prijava>(query).ToList();
            int jan = 0, feb = 0, mar = 0, apr = 0, maj = 0, jun = 0;
            int jul = 0, avg = 0, sep = 0, okt = 0, nov = 0, dec = 0;

            foreach (Prijava o in prijave)
            {
                if (o.datumPrijave.Month.Equals(1))
                    jan++;
                else if (o.datumOd.Month.Equals(2))
                    feb++;
                else if (o.datumOd.Month.Equals(3))
                    mar++;
                else if (o.datumOd.Month.Equals(4))
                    apr++;
                else if (o.datumOd.Month.Equals(5))
                    maj++;
                else if (o.datumOd.Month.Equals(5))
                    jun++;
                else if (o.datumOd.Month.Equals(7))
                    jul++;
                else if (o.datumOd.Month.Equals(8))
                    avg++;
                else if (o.datumOd.Month.Equals(9))
                    sep++;
                else if (o.datumOd.Month.Equals(10))
                    okt++;
                else if (o.datumOd.Month.Equals(11))
                    nov++;
                else if (o.datumOd.Month.Equals(12))
                    dec++;



            }
            int ukupno = prijave.Count;


            //MessageBox.Show("UKUPNO:" + ukupno.ToString());
            //MessageBox.Show("PR USLOVI:" + prUslovi.ToString());
            //MessageBox.Show("PR OSOBLJE:" + prOsoblje.ToString());
            //MessageBox.Show("PR LICNO:" + prLicno.ToString());

            hash.Add("jan", jan);
            hash.Add("feb", feb);
            hash.Add("mar", mar);
            hash.Add("apr", apr);
            hash.Add("jun", jun);
            hash.Add("jul", jul);
            hash.Add("avg", avg);
            hash.Add("sep", sep);
            hash.Add("okt", okt);
            hash.Add("nov", nov);
            hash.Add("dec", dec);

            return hash;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormStatistika_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawRectangle(new Pen(Color.White, 5),
                            this.DisplayRectangle);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormRanijeOdjavljivanje fro = new FormRanijeOdjavljivanje();
            fro.client = client;
            fro.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FormOtkazRezervacija fo = new FormOtkazRezervacija();
            fo.client = client;
            fo.ShowDialog();
        }
    }

    }
