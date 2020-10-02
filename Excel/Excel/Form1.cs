using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel1 = Microsoft.Office.Interop.Excel;
using System.Reflection;

namespace Excel
{
    public partial class Form1 : Form
    {
        RealEstateEntities context = new RealEstateEntities();
        List<Flat> Flats;

        Excel1.Application xlApp;
        Excel1.Workbook xlWB;
        Excel1.Worksheet xlSheet;
        public Form1()
        {
            InitializeComponent();
            LoadData();
            CreateExcel();
        }

        public void LoadData() {
            Flats = context.Flats.ToList();
        }

        public void CreateExcel() {

            try
            {
                
               // xlApp = new Excel.Application();

               
                xlWB = xlApp.Workbooks.Add(Missing.Value);

                
                xlSheet = xlWB.ActiveSheet;

                
                //CreateTable(); 

               
                xlApp.Visible = true;
                xlApp.UserControl = true;
            }
            catch (Exception ex) 
            {
                string errMsg = string.Format("Error: {0}\nLine: {1}", ex.Message, ex.Source);
                MessageBox.Show(errMsg, "Error");

                
                xlWB.Close(false, Type.Missing, Type.Missing);
                xlApp.Quit();
                xlWB = null;
                xlApp = null;
            }

        }
    }
}
