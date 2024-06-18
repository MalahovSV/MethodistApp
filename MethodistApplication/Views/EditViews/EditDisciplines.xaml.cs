using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.IO; 
using IronXL;
using System.Data;
using Microsoft.Office.Interop.Excel;

namespace MethodistApplication.Views.EditViews
{
    /// <summary>
    /// Логика взаимодействия для EditDisciplines.xaml
    /// </summary>
    public partial class EditDisciplines : System.Windows.Window
    {
        private protected string _filePath;

        public EditDisciplines()
        {
            InitializeComponent();
        }

        public bool OpenFileDialog()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                _filePath = openFileDialog.FileName;
                return true;
            }
            return false;
        }

        private void ImportButton_Click(object sender, RoutedEventArgs e)
        {
            if (OpenFileDialog())
            {
                //Create COM Objects.
                Microsoft.Office.Interop.Excel.Application excelApp = new Microsoft.Office.Interop.Excel.Application();


                if (excelApp == null)
                {
                    MessageBox.Show("Excel is not installed!!");
                    return;
                }

                Workbook excelBook = excelApp.Workbooks.Open(_filePath);
                _Worksheet excelSheet = excelBook.Sheets[1];
                Microsoft.Office.Interop.Excel.Range excelRange = excelSheet.UsedRange;

                int rows = excelRange.Rows.Count;
                int cols = excelRange.Columns.Count;

                System.Data.DataTable dataTable = new System.Data.DataTable();
                dataTable.Columns.Add("Дисциплина"); //3 col
                dataTable.Columns.Add("Индекс группы");      //4 col
                dataTable.Columns.Add("Количество часов");   //30 col

                for (int i = 8; i <= rows; i++)
                {
                    /*for (int j = 1; j <= cols; j++)
                    {
                        //write the console
                        if (excelRange.Cells[i, j] != null && excelRange.Cells[i, j].Value2 != null)
                            MessageBox.Show(excelRange.Cells[i, j].Value2.ToString() + "\t");
                    }*/
                    if (excelRange.Cells[i, 3] != null && excelRange.Cells[i, 3].Value2 != null)
                    {
                        if (excelRange.Cells[i, 4].Value2.ToString().Contains(","))
                        {
                            var _temp = excelRange.Cells[i, 4].Value2.ToString();
                            var splitStr = _temp.Split(',');
                            foreach(string str in splitStr)
                            {

                                dataTable.Rows.Add(
                                    excelRange.Cells[i, 3].Value2.ToString(),
                                    str.Trim(),
                                    excelRange.Cells[i, 30].Value2.ToString());
                            }
                        }
                        else
                        {
                            dataTable.Rows.Add(
                                    excelRange.Cells[i, 3].Value2.ToString(),
                                    excelRange.Cells[i, 4].Value2.ToString(),
                                    excelRange.Cells[i, 30].Value2.ToString());
                        }
                    }
                }
                
                DisciplinesDataGrid.ItemsSource = dataTable.AsDataView();
                excelApp.Quit();
                System.Runtime.InteropServices.Marshal.ReleaseComObject(excelApp);

            }
            else
            {
                MessageBox.Show("Произошла одна или несколько ошибок", "Ошибка пути файла");
            }

        }
    }
}
