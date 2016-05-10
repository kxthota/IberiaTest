using OfficeOpenXml;
using OfficeOpenXml.Drawing;
using OfficeOpenXml.Style;
using System.Data;
using System.Drawing;
using System.IO;

public static class Helper
{
    public static void GenerateExcel2007(DataTable p_dsSrc)
    {
        string p_strPath = "TestResults.xlsx";
        //Create excel file on physical disk    
        FileInfo newFile = new FileInfo(p_strPath);
        using (ExcelPackage objExcelPackage = new ExcelPackage(newFile))
        {
            DataTable dtSrc = p_dsSrc;
            
            //Create the worksheet    
            if (!File.Exists(p_strPath))
            {
                ExcelWorksheet objWorksheet = objExcelPackage.Workbook.Worksheets.Add(dtSrc.TableName);
                FileStream objFileStrm = File.Create(p_strPath);
                objFileStrm.Close();
                //Load the datatable into the sheet, starting from cell A1. Print the column names on row 1    
                objWorksheet.Cells["A1"].LoadFromDataTable(dtSrc, true);
                objWorksheet.Cells.Style.Font.SetFromFont(new Font("Calibri", 10));
                objWorksheet.Cells.AutoFitColumns();
                //Format the header    
                using (ExcelRange objRange = objWorksheet.Cells["A1:XFD1"])
                {
                    objRange.Style.Font.Bold = true;
                    objRange.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    objRange.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                    objRange.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    objRange.Style.Fill.BackgroundColor.SetColor(Color.Firebrick);
                }
                File.WriteAllBytes(p_strPath, objExcelPackage.GetAsByteArray());
                //}
            }
            else
            {
                ExcelWorksheet objWorksheet = objExcelPackage.Workbook.Worksheets[dtSrc.TableName];
                foreach (DataRow dr in dtSrc.Rows)
                {
                    objWorksheet.InsertRow(2, 1);
                    objWorksheet.Cells["A2"].Value = dr["Component"];
                    objWorksheet.Cells["B2"].Value = dr["TestName"];
                    objWorksheet.Cells["C2"].Value = dr["Objective"];
                    objWorksheet.Cells["D2"].Value = dr["Responsible tester"];
                    objWorksheet.Cells["E2"].Value = dr["Date of Execution"];
                    objWorksheet.Cells["F2"].Value = dr["Status"];
                    objWorksheet.Cells["G2"].Value = dr["TestType"];
                }
                objExcelPackage.Save();
            }
            //Write it back to the client    
            //if (File.Exists(p_strPath))
            //File.Delete(p_strPath);

            //if (!File.Exists(p_strPath))
            //{
            //    //Create excel file on physical disk    
            //    FileStream objFileStrm = File.Create(p_strPath);
            //    objFileStrm.Close();
            //    //Write content to excel file  
            //    File.WriteAllBytes(p_strPath, objExcelPackage.GetAsByteArray());
            //}
            //else
            //{
            //    File.AppendAllText(p_strPath, objExcelPackage.get);
            //}
          
        }
    }
}