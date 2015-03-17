using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using Common;
using System.Data;
using System.Windows.Forms;

namespace agra_gui
{
    class ExportToExcel
    {
        public static System.Windows.Forms.SaveFileDialog saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
        public static void writeCSV(String[][] data)
        {
            saveFileDialog1.FileName = "export";
            saveFileDialog1.Filter = "csv files (*.csv)|*.csv";

            if (saveFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK
                && saveFileDialog1.FileName.Length > 0)
            {
                StringBuilder sbCSV = new StringBuilder();
                int intColCount = data.Length;
                for (int y = 0; y<data.Length;y++){
                    for (int x =0; x < data[y].Length;x++){
                        sbCSV.Append(data[y][x]);
                        if (x != data[y].Length-1)
                        {
                            sbCSV.Append(",");
                        }
                    }
                    sbCSV.AppendLine();
                }

                //foreach (DataGridViewRow dr in data)
                //{
                //        for (int x = 0; x < intColCount; x++)
                //        {
                //            if (dr.Cells[x] != null && dr.Cells[x].Value != null)
                //            {
                //                sbCSV.Append(dr.Cells[x].Value.ToString());
                //                if ((x + 1) != intColCount)
                //                {
                //                    sbCSV.Append(",");
                //                }
                //            }
                //        }
                //        sbCSV.Append("\n");
                //}
                FileHelper.saveText(saveFileDialog1.FileName, sbCSV.ToString());
            }
            
        }

        //public static void Export2Excel(String[][] data, bool csvOverride, bool split)
        //{
        //    if (data == null || data.Length <= 0)
        //    {
        //        return;
        //    }


        //    Excel.Application xlApp;
        //    Excel.Workbook xlWorkBook;
        //    Excel.Worksheet xlWorkSheet;
        //    object misValue = System.Reflection.Missing.Value;
        //    Excel.Range chartRange;

        //    Type objClassType = Type.GetTypeFromProgID("Excel.Application");
        //    object objApp_Late = Activator.CreateInstance(objClassType);
        //    xlApp = (Excel.Application)objApp_Late;
        //    xlWorkBook = xlApp.Workbooks.Add(misValue);
        //    xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);

        //    //add data 
        //    xlWorkSheet.Cells[4, 2] = "";
        //    xlWorkSheet.Cells[4, 3] = "Student1";
        //    xlWorkSheet.Cells[4, 4] = "Student2";
        //    xlWorkSheet.Cells[4, 5] = "Student3";

        //    xlWorkSheet.Cells[5, 2] = "Term1";
        //    xlWorkSheet.Cells[5, 3] = "80";
        //    xlWorkSheet.Cells[5, 4] = "65";
        //    xlWorkSheet.Cells[5, 5] = "45";

        //    xlWorkSheet.Cells[6, 2] = "Term2";
        //    xlWorkSheet.Cells[6, 3] = "78";
        //    xlWorkSheet.Cells[6, 4] = "72";
        //    xlWorkSheet.Cells[6, 5] = "60";

        //    xlWorkSheet.Cells[7, 2] = "Term3";
        //    xlWorkSheet.Cells[7, 3] = "82";
        //    xlWorkSheet.Cells[7, 4] = "80";
        //    xlWorkSheet.Cells[7, 5] = "65";

        //    xlWorkSheet.Cells[8, 2] = "Term4";
        //    xlWorkSheet.Cells[8, 3] = "75";
        //    xlWorkSheet.Cells[8, 4] = "82";
        //    xlWorkSheet.Cells[8, 5] = "68";

        //    xlWorkSheet.Cells[9, 2] = "Total";
        //    xlWorkSheet.Cells[9, 3] = "315";
        //    xlWorkSheet.Cells[9, 4] = "299";
        //    xlWorkSheet.Cells[9, 5] = "238";

        //    xlWorkSheet.get_Range("b2", "e3").Merge(false);

        //    chartRange = xlWorkSheet.get_Range("b2", "e3");
        //    chartRange.FormulaR1C1 = "MARK LIST";
        //    chartRange.HorizontalAlignment = 3;
        //    chartRange.VerticalAlignment = 3;

        //    chartRange = xlWorkSheet.get_Range("b4", "e4");
        //    chartRange.Font.Bold = true;
        //    chartRange = xlWorkSheet.get_Range("b9", "e9");
        //    chartRange.Font.Bold = true;

        //    chartRange = xlWorkSheet.get_Range("b2", "e9");
        //    chartRange.BorderAround(Excel.XlLineStyle.xlContinuous, Excel.XlBorderWeight.xlMedium, Excel.XlColorIndex.xlColorIndexAutomatic, Excel.XlColorIndex.xlColorIndexAutomatic);

        //}

        #region Export to Excel
        public static void Export2Excel(String[][] data, bool csvOverride, bool split)
        {
            if (data == null || data.Length <= 0)
            {
                return;
            }
            object objApp_Late;
            object objBook_Late;
            object objBooks_Late;
            object objSheets_Late;
            object objSheet_Late;
            //object objRange_Late;
            object[] Parameters;
            //string[] headers = new string[data.Length];
            //string[] columns = new string[data.Length];

            //int i = 0;
            //int c = 0;

            //for (c = 0; c < data.Length; c++)
            //{
            //    headers[c] = datagridview.Rows[0].Cells[c].OwningColumn.Name.ToString();
            //    i = c + 65;
            //    columns[c] = Convert.ToString((char)i);
            //}

            try
            {
                // Get the class type and instantiate Excel.
                Type objClassType;
                objClassType = Type.GetTypeFromProgID("Excel.Application");
                if (objClassType == null || csvOverride)
                {
                    Logging.log("No Excel found on system, exporting in csv");
                    writeCSV(data);
                    return;
                }

                objApp_Late = Activator.CreateInstance(objClassType);
                //Get the workbooks collection.
                objBooks_Late = objApp_Late.GetType().InvokeMember("Workbooks",
                BindingFlags.GetProperty, null, objApp_Late, null);
                //Add a new workbook.
                objBook_Late = objBooks_Late.GetType().InvokeMember("Add",
                BindingFlags.InvokeMethod, null, objBooks_Late, null);
                //Get the worksheets collection.
                objSheets_Late = objBook_Late.GetType().InvokeMember("Worksheets",
                BindingFlags.GetProperty, null, objBook_Late, null);
                //Get the first worksheet.
                Parameters = new Object[1];
                Parameters[0] = 1;
                objSheet_Late = objSheets_Late.GetType().InvokeMember("Item",
                BindingFlags.GetProperty, null, objSheets_Late, Parameters);


                for (int y = 0; y < data.Length; y++)
                {
                    for (int x = 0; x < data[y].Length; x++)
                    {
                        Parameters = new Object[2];
                        Parameters[0] = Convert.ToString((char)(65 + y)) + Convert.ToString(x + 1);
                        Parameters[1] = Missing.Value;
                        object objRange_Late = objSheet_Late.GetType().InvokeMember("Range",BindingFlags.GetProperty, null, objSheet_Late, Parameters);
                        object objFont = objRange_Late.GetType().InvokeMember("Font",BindingFlags.GetProperty, null, objRange_Late, null);
                        Parameters = new Object[1];
                        Parameters[0] = "10";
                        objFont.GetType().InvokeMember("Size", BindingFlags.SetProperty, null, objFont, Parameters);
                        Parameters = new Object[1];
                        Parameters[0] = "Arial";
                        objFont.GetType().InvokeMember("Name", BindingFlags.SetProperty, null, objFont, Parameters);
                        //Parameters = new Object[1];
                        //Parameters[0] = 10;
                        //objFont.GetType().InvokeMember("Size",
                        //   BindingFlags.GetProperty, null, objFont, Parameters);
                        //object objDisplayFormat = objSheet_Late.GetType().InvokeMember("DisplayFormat",
                        //   BindingFlags.GetProperty, null, objSheet_Late, null);
                        //object objStyle

                        Parameters = new Object[1];
                        Parameters[0] = data[y][x];
                        objRange_Late.GetType().InvokeMember("Value", BindingFlags.SetProperty,
                        null, objRange_Late, Parameters);
                    }
                }

                //if (captions)
                //{
                //    headerAdjust = 2;
                //    // Create the headers in the first row of the sheet
                //    for (c = 0; c < datagridview.ColumnCount; c++)
                //    {
                //        //Get a range object that contains cell.
                //        Parameters = new Object[2];
                //        Parameters[0] = columns[c] + "1";
                //        Parameters[1] = Missing.Value;
                //        objRange_Late = objSheet_Late.GetType().InvokeMember("Range",
                //        BindingFlags.GetProperty, null, objSheet_Late, Parameters);
                //        //Write Headers in cell.
                //        Parameters = new Object[1];
                //        Parameters[0] = headers[c];
                //        objRange_Late.GetType().InvokeMember("Value", BindingFlags.SetProperty,
                //        null, objRange_Late, Parameters);
                //    }
                //}

                // Now add the data from the grid to the sheet starting in row 2 if it has headings
                //if (split){//data grid writtern out into 3 blocks
                //    int setCount = 3;
                //    int rowCountForSet = Convert.ToInt32(Math.Round((double)datagridview.Rows.Count / (double)setCount, 0, MidpointRounding.AwayFromZero));
                //    int excelRowIndex = 1;
                //    int excelColumIndex = 1;

                //    for (int setIndex = 0; setIndex < setCount; setIndex++)
                //    {
                //        excelRowIndex = 1;
                //        for (int ib = setIndex * rowCountForSet; ib < (setIndex * rowCountForSet) + rowCountForSet; ib++)
                //        {
                //            excelColumIndex = (setIndex * datagridview.Columns.Count) + 1;
                //            for (int cb = 0; cb < datagridview.ColumnCount; cb++)
                //            {
                //                //Get a range object that contains cell.
                //                Parameters = new Object[2];
                //                Parameters[0] = columns[excelColumIndex] + Convert.ToString(excelRowIndex + headerAdjust);
                //                Parameters[1] = Missing.Value;
                //                objRange_Late = objSheet_Late.GetType().InvokeMember("Range",
                //                BindingFlags.GetProperty, null, objSheet_Late, Parameters);
                //                //Write Headers in cell.
                //                Parameters = new Object[1];
                //                Parameters[0] = datagridview.Rows[ib].Cells[cb].Value.ToString();
                //                objRange_Late.GetType().InvokeMember("Value", BindingFlags.SetProperty,
                //                null, objRange_Late, Parameters);
                //                excelColumIndex++;
                //            }
                //            excelRowIndex++;
                //        }
                //    }
                //}else{//normal write out of columns in datagrid
                //for (i = 0; i < datagridview.RowCount; i++)
                //{
                //    for (c = 0; c < datagridview.ColumnCount; c++)
                //    {
                //        //Get a range object that contains cell.
                //        Parameters = new Object[2];
                //        Parameters[0] = columns[c] + Convert.ToString(i + headerAdjust);
                //        Parameters[1] = Missing.Value;
                //        objRange_Late = objSheet_Late.GetType().InvokeMember("Range",
                //        BindingFlags.GetProperty, null, objSheet_Late, Parameters);
                //        //Write Headers in cell.
                //        Parameters = new Object[1];
                //        Parameters[0] = datagridview.Rows[i].Cells[headers[c]].Value.ToString();
                //        objRange_Late.GetType().InvokeMember("Value", BindingFlags.SetProperty,
                //        null, objRange_Late, Parameters);
                //    }
                //}
                //}

                //Return control of Excel to the user.
                Parameters = new Object[1];
                Parameters[0] = true;
                objApp_Late.GetType().InvokeMember("Visible", BindingFlags.SetProperty,
                null, objApp_Late, Parameters);
                objApp_Late.GetType().InvokeMember("UserControl", BindingFlags.SetProperty,
                null, objApp_Late, Parameters);
            }
            catch (Exception theException)
            {
                String errorMessage;
                errorMessage = "Error: ";
                errorMessage = String.Concat(errorMessage, theException.Message);
                errorMessage = String.Concat(errorMessage, " Line: ");
                errorMessage = String.Concat(errorMessage, theException.Source);

                //MessageBox.Show(errorMessage, "Error");
            }
        }
        #endregion
    }
}
