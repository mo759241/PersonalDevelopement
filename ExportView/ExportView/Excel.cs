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
            dt.Columns.Add("フィールド物理名", typeof(string));
            dt.Columns.Add("フィールド表示名", typeof(string));
            dt.Columns.Add("ソート１", typeof(string));
            dt.Columns.Add("ソート２", typeof(string));
            dt.Columns.Add("ソート３", typeof(string));
            dt.Columns.Add("備考", typeof(string));

            return dt;
        }

        /// <summary>
        /// テーブルに行を追加
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="tableName"></param>
        /// <param name="viewType"></param>
        /// <param name="viewName"></param>
        /// <param name="fieldName"></param>
        /// <param name="description"></param>
        /// <param name="sort"></param>
        /// <returns>行追加後のテーブル</returns>
        public DataTable AddRowToViewDefinitionTable(DataTable dt, string tableName, string viewTypeCode, string viewName, string fieldNamePhysical, string fieldNameDisplay, string description, string[] sort)
        {
            DataRow dr = dt.NewRow();
            dr["No"] = dt.Rows.Count + 1;
            dr["テーブル名"] = tableName;
            dr["ビュー名"] = viewName;
            string viewType = Const.TranViewType.TryGetValue(viewTypeCode, out string value)
                                ? Const.TranViewType[viewTypeCode]
                                : "-";
            dr["種類"] = viewType;
            dr["フィルター"] = "";
            dr["フィールド物理名"] = fieldNamePhysical;
            dr["フィールド表示名"] = fieldNameDisplay;
            dr["ソート１"] = sort[0];
            dr["ソート２"] = sort[1];
            dr["ソート３"] = sort[2];
            dr["備考"] = description;

            dt.Rows.Add(dr);

            Console.WriteLine(dt.Rows.Count + 1 + " - " + tableName + " - " + viewName + " - " + viewType + " - " + fieldNamePhysical + "(" + fieldNameDisplay + ") - " + description + "ソート１：" + sort[0] + "ソート２：" + sort[1] + "ソート３：" + sort[2]);

            return dt;
        }
    }
}