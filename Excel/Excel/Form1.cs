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

                xlApp = new Excel1.Application();


                xlWB = xlApp.Workbooks.Add(Missing.Value);


                xlSheet = xlWB.ActiveSheet;


                CreateTable();


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

        public void CreateTable() {

            string[] headers = new string[] {
                "Kód",
                "Eladó",
                "Oldal",
                "Kerület",
                "Lift",
                "Szobaszám",
                "Alapterület (nm)",
                "Ár",
                "Négyzetméter ár"
            };

            for (int i = 0; i < headers.Length; i++)
            {
                xlSheet.Cells[1, i + 1] = headers[i];
            }

            object[,] values = new object[Flats.Count, headers.Length];

            int counter = 0;
            foreach (Flat flat in Flats)
            {
                values[counter, 0] = flat.Code;
                values[counter, 1] = flat.Vendor;
                values[counter, 2] = flat.Side;
                values[counter, 3] = flat.District;
                values[counter, 4] = flat.Elevator;
                values[counter, 5] = flat.NumberOfRooms;
                values[counter, 6] = flat.FloorArea;
                values[counter, 7] = flat.Price;
                values[counter, 8] = "=GetCell(counter+1,5)/GetCell(counter+1,7)";

                counter++;
            }

            xlSheet.get_Range(
             GetCell(2, 1),
             GetCell(1 + values.GetLength(0), values.GetLength(1))).Value2 = values;

            int lastRowID = xlSheet.UsedRange.Rows.Count;

            Excel1.Range headerRange = xlSheet.get_Range(GetCell(1, 1), GetCell(1, headers.Length));
            Excel1.Range sheetRange = xlSheet.get_Range(GetCell(1, 1), GetCell(lastRowID, headers.Length));
            Excel1.Range firstcolumnRange = xlSheet.get_Range(GetCell(2, 1), GetCell(counter, 1));
            Excel1.Range lastcolumnRange = xlSheet.get_Range(GetCell(2, headers.Length), GetCell(counter, headers.Length));

            headerRange.Font.Bold = true;
            headerRange.VerticalAlignment = Excel1.XlVAlign.xlVAlignCenter;
            headerRange.HorizontalAlignment = Excel1.XlHAlign.xlHAlignCenter;
            headerRange.EntireColumn.AutoFit();
            headerRange.RowHeight = 40;
            headerRange.Interior.Color = Color.LightBlue;
            headerRange.BorderAround2(Excel1.XlLineStyle.xlContinuous, Excel1.XlBorderWeight.xlThick);

            sheetRange.BorderAround2(Excel1.XlLineStyle.xlContinuous, Excel1.XlBorderWeight.xlThick);
            firstcolumnRange.Font.Bold = true;
            firstcolumnRange.Interior.Color = Color.LightYellow;
            lastcolumnRange.Interior.Color = Color.LightGreen;





        }

        

           
        

        private string GetCell(int x, int y)
        {
            string ExcelCoordinate = "";
            int dividend = y;
            int modulo;

            while (dividend > 0)
            {
                modulo = (dividend - 1) % 26;
                ExcelCoordinate = Convert.ToChar(65 + modulo).ToString() + ExcelCoordinate;
                dividend = (int)((dividend - modulo) / 26);
            }
            ExcelCoordinate += x.ToString();

            return ExcelCoordinate;
        }
    }
}
