using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Neo4jClient.Cypher;
using HotelManagementSystem.DomainModel;
using Neo4jClient;


namespace HotelManagementSystem.Forme
{
    public partial class FormPopust : Form
    {
        public GraphClient client;
     //   public Gost gost;
        public FormPopust()
        {
            InitializeComponent();
            //NadjiSvePrijaveGosta(this.gost);
        }
        public FormPopust(Gost g)
        {

            InitializeComponent();
           
            NadjiSvePrijaveGosta(g);
        }
        public void NadjiSvePrijaveGosta(Gost gost)
        {
            /* Dictionary<string, object> queryDict = new Dictionary<string, object>();

             var query = new Neo4jClient.Cypher.CypherQuery("match(n:Gost{email:'" + gost.email + "'})-[r:ODJAVA ]->(s:Prostorija)  return r ",
                                                            queryDict, CypherResultMode.Set);
             MessageBox.Show(query.QueryText);
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
             lvPopust.Refresh();*/

            Dictionary<string, object> queryDict = new Dictionary<string, object>();

            var query = new Neo4jClient.Cypher.CypherQuery("match(n:Gost{email:'"+gost.email+"'})-[r:REZERVACIJA]->(s:Prostorija)  return r ",
                                                           queryDict, CypherResultMode.Set);

            List<Rezervacija> rezervacije = ((IRawGraphClient)client).ExecuteGetCypherResults<Rezervacija>(query).ToList();

            var query1 = new Neo4jClient.Cypher.CypherQuery("match(n:Gost{email:'"+gost.email + "'})-[r:REZERVACIJA]->(s:Prostorija)  return n ",
                                                          queryDict, CypherResultMode.Set);

            List<Gost> gosti = ((IRawGraphClient)client).ExecuteGetCypherResults<Gost>(query1).ToList();

            var query2 = new Neo4jClient.Cypher.CypherQuery("match(n:Gost{email:'"+gost.email + "'})-[r:REZERVACIJA]->(s:Prostorija)  return s ",
                                                         queryDict, CypherResultMode.Set);

            List<Prostorija> prostorije = ((IRawGraphClient)client).ExecuteGetCypherResults<Prostorija>(query2).ToList();

            var query3 = new Neo4jClient.Cypher.CypherQuery("match(n:Gost{email:'"+gost.email + "'})-[r:REZERVACIJA]->(s:Prostorija) return ID(n)",
                                                           queryDict, CypherResultMode.Set);

            List<String> listaID = ((IRawGraphClient)client).ExecuteGetCypherResults<String>(query3).ToList();


            for (int i = 0; i < rezervacije.Count; i++)
            {
                gosti[i].idGosta = listaID[i].ToString();
                rezervacije[i].gost = gosti[i];
                rezervacije[i].prostorija = prostorije[i];
            }
            foreach (Rezervacija r in rezervacije)
            {
                string licno = "ne", osoblje = "ne", uslovi = "ne";
                //if (r.licno.Equals("true"))
                //    licno = "da";
                //if (r.osoblje.Equals("true"))
                //    osoblje = "da";
                //if (r.uslovi.Equals("true"))
                //    uslovi = "da";
                ListViewItem item = new ListViewItem(new string[] { r.gost.idGosta, r.gost.ime, r.gost.prezime, r.prostorija.brojProstorije.ToString(), r.gost.brojTelefona, r.gost.email, r.gost.dokument, r.datumOd.ToString("dd/MM/yyyy"), r.datumDo.ToString("dd/MM/yyyy"), r.datumRezervacije.ToString("dd/MM/yyyy"), licno, osoblje, uslovi });

                lvPopust.Items.Add(item);

            }
            lvPopust.Refresh();

        }
        private void FormPopust_Load(object sender, EventArgs e)
        {
           
           // NadjiSvePrijaveGosta(this.gost);
        }
    }
}
