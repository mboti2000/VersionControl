using MNB.Entities;
using MNB.MNBserviceReference;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace MNB
{
    public partial class Form1 : Form
    {
        BindingList<RateData> Rates = new BindingList<RateData>();
        public string result;
        
        
        public Form1()
        {
            InitializeComponent();

            dataGridView1.DataSource = Rates;
            getCurrencyRates();
            processXML();
        }

        public void getCurrencyRates() { 

            var mnbService = new MNBArfolyamServiceSoapClient();

            var request = new GetExchangeRatesRequestBody(){

                currencyNames = "Euro",
                startDate = "2020-01-01",
                endDate = "2020-06-30"

            };

            var response = mnbService.GetExchangeRates(request);
             
           result = response.GetExchangeRatesResult;
        }

        public void processXML() {

            var xml = new XmlDocument();
            xml.LoadXml(result);

            foreach (XmlElement el in xml.DocumentElement)
            {
                RateData rd = new RateData();
                Rates.Add(rd);

                rd.Date = DateTime.Parse(el.GetAttribute("date"));

                var firstChild = (XmlElement)el.ChildNodes[0];
                rd.Currency = firstChild.GetAttribute("curr");

                var currUnit = Decimal.Parse(firstChild.GetAttribute("unit"));
                var unitValue = Decimal.Parse(firstChild.InnerText);
                if (currUnit!=0) {
                    rd.Value = unitValue / currUnit;
                }
                


            }
        }
    }
}
