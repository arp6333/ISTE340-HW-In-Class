using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CookComputing.XmlRpc;
using System.IO;
using System.Xml;
using System.Net;

namespace ISTE340ConsumeServices
{
    [XmlRpcUrl("http://alvin.ist.rit.edu:8100")]
    public interface IBeers : IXmlRpcProxy
    {
        [XmlRpcMethod("beer.getBeers")]
        string[] getBeers();
    }
    public partial class frmServices : Form
    {
        public void frmServices_Load(object sender, EventArgs e)
        {

        }

        public frmServices()
        {
            InitializeComponent();
        }

        private void btnXMLRPC_Click(object sender, EventArgs e)
        {
            IBeers proxy = XmlRpcProxyGen.Create<IBeers>();
            string[] beers = proxy.getBeers();
            cmbXMLRPC.Items.Clear();
            for (int i = 0; i < beers.Length; i++)
            {
                cmbXMLRPC.Items.Add(beers[i]);
            }
        }

        private void btnSOAP_Click(object sender, EventArgs e)
        {
            serviceBeer.BeerClient bc = new serviceBeer.BeerClient();
            string[] beers = bc.getBeers();
            cmbSOAP.Items.Clear();
            for (int i = 0; i < beers.Length; i++)
            {
                cmbSOAP.Items.Add(beers[i]);
            }
        }
        private void btnREST_Click(object sender, EventArgs e)
        {
            //List<string> beers = new List<string>();
            string uri =
           "http://simon.ist.rit.edu:8080/BeerService/resources/Services/Beers";
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(uri);
            req.Method = "GET"; // get method request on the above web request
            try
            {
                HttpWebResponse res = (HttpWebResponse)req.GetResponse();

                //converts the response into a usable stream
                Stream str = res.GetResponseStream();
                // reads the stream as an XML object
                XmlReader xr = XmlReader.Create(str);
                while (xr.Read())
                {
                    if (xr.Value != "") cmbREST.Items.Add(xr.Value);
                }
                res.Close();
            }
            catch (Exception ex)
            {
                Console.Write("Error");
            }
        }
    }
}
