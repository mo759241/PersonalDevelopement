using ClosedXML.Excel;
using System;
using System.Data;
using System.IO;

namespace ExportView
{
    public class Excel
    {
        public XLWorkbook Workbook { get; private set; }
        public IXLWorksheet Worksheet { get; private set; }
        public Excel(string openExcelFileName, string openSheetName)
        {
            string appPath = AppDomain.CurrentDomain.BaseDirectory;
            string excelPath = $@"{appPath}Excel\{openExcelFileName}";
            //Excelファイルの存在確認
            if (File.Exists(excelPath) == false)
                throw new FileNotFoundException();

            Workbook = new XLWorkbook(excelPath);
            if (Workbook.TryGetWorksheet(openSheetName, out IXLWorksheet openSheet))
            {
                Worksheet = openSheet;
            }
            else
            {
                throw new Exception("指定したシート名は存在しません");
            }
        }

        public Excel()
        {
            Workbook = new XLWorkbook();
            Worksheet = Workbook.Worksheets.Add("Sample Sheet");
        }

        public void ExcelSheetOpen(string openSheetName)
        {
            try
            {

                if (Workbook.TryGetWorksheet(openSheetName, out IXLWorksheet openSheet))
                {
                    Worksheet = openSheet;
                }
                else
                {
                    throw new Exception("指定したExcelのSheetが存在しません");
                }
            }
            catch
            {
                throw;
            }
        }

        public void ExcelSheetCopy(string originalSheetName, string copyToSheetName)
        {
            try
            {

                if (Workbook.TryGetWorksheet(originalSheetName, out IXLWorksheet openSheet))
                {
                    Worksheet = openSheet;
                    Worksheet.CopyTo(copyToSheetName);
                }
                else
                {
                    throw new Exception("指定したExcelのコピー元Sheetが存在しません");
                }
            }
            catch
            {
                throw;
            }
        }

        public void ExcelSheetDelete(Excel excel)
        {
            excel.Workbook.Worksheet("Sheet1").Delete();
        }

        public void CellWrite(int row, int column, object value)
        {
            //セルの取得
            var cell = Worksheet.Cell(row, column);
            //値の書き込み
            cell.Value = (XLCellValue)value;
        }
        public void ExcelSaveAs(Stream stream)
        {
            Workbook.SaveAs(stream);
        }
        public void ExcelSaveAs(string saveFilePath)
        {
            Workbook.SaveAs(saveFilePath);
        }
        public void Dispose()
        {
            Workbook.Dispose();
        }

        /// <summary>
        /// エンティティ定義テーブルの作成
        /// </summary>
        /// <returns>エンティティ定義要のテーブル</returns>
        public DataTable CreateViewDefinitionTable()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("No", typeof(int));
            dt.Columns.Add("テーブル名", typeof(string));
            dt.Columns.Add("ビュー名", typeof(string));
            dt.Columns.Add("種類", typeof(string));
            dt.Columns.Add("フィルター", typeof(string));
            dt.Columns.Add("フィールド名", typeof(string));

            return dt;
        }

        /// <summary>
        /// テーブルに行を追加
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="tableName"></param>
        /// <param name="viewType"></param>
        /// <param name="fieldName"></param>
        /// <returns>行追加後のテーブル</returns>
        public DataTable AddRowToViewDefinitionTable(DataTable dt, string tableName, string viewType, string viewName, string fieldName)
        {
            DataRow dr = dt.NewRow();
            dr["No"] = dt.Rows.Count + 1;
            dr["テーブル名"] = tableName;
            dr["ビュー名"] = viewName;
            dr["種類"] = Const.TranViewType[viewType];
            dr["フィルター"] = "";
            dr["フィールド名"] = fieldName;

            dt.Rows.Add(dr);

            Console.WriteLine(dt.Rows.Count + 1 + " - " + tableName + " - " + viewName + " - " + Const.TranViewType[viewType] + " - " + fieldName);

            return dt;
        }
    }
}