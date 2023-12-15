using ClosedXML.Excel;
using System;
using System.Data;
using System.IO;

namespace MetaDataDocumentGenerator_UI
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
            excel.Workbook.Worksheet("フィールド定義").Delete();
        }

        public void CellWrite(int row, int column, object value)
        {
            //セルの取得
            var cell = Worksheet.Cell(row, column);
            //値の書き込み
            cell.Value = value;
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
        public DataTable CreateEntityDefinitionTable()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("No", typeof(int));
            dt.Columns.Add("エンティティ名", typeof(string));
            dt.Columns.Add("スキーマ名", typeof(string));
            dt.Columns.Add("標準/カスタム", typeof(string));
            dt.Columns.Add("通常/活動", typeof(string));
            dt.Columns.Add("企業形態", typeof(string));
            dt.Columns.Add("業務プロセス", typeof(string));
            dt.Columns.Add("活動", typeof(string));
            dt.Columns.Add("備考", typeof(string));
            dt.Columns.Add("変更履歴", typeof(string));

            return dt;
        }

        /// <summary>
        /// エンティティ定義用テーブルに行を追加
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="outputEntityMetadata"></param>
        /// <returns>エンティティ定義用テーブル</returns>
        public DataTable AddRowToEntityDefinitionTable(DataTable dt, OutputEntityMetadata outputEntityMetadata)
        {
            DataRow dr = dt.NewRow();
            dr["No"] = dt.Rows.Count + 1;
            dr["エンティティ名"] = outputEntityMetadata.DisplayName;
            dr["スキーマ名"] = outputEntityMetadata.SchemaName;
            dr["標準/カスタム"] = outputEntityMetadata.IsCustomEntity;
            dr["通常/活動"] = outputEntityMetadata.IsActivity;
            dr["企業形態"] = outputEntityMetadata.OwnershipType;
            dr["業務プロセス"] = outputEntityMetadata.IsBusinessProcessEnabled;
            dr["活動"] = outputEntityMetadata.HasActivitiesAndNotes;
            dr["備考"] = "";
            dr["変更履歴"] = "";

            dt.Rows.Add(dr);

            Console.WriteLine("【成功】エンティティ名：" + outputEntityMetadata.DisplayName + "(" + outputEntityMetadata.SchemaName + ")");

            return dt;
        }

        /// <summary>
        /// フィールド定義用のテーブルを作成
        /// </summary>
        /// <returns>フィールド定義用テーブル</returns>
        public DataTable CreateFieldDefinitionTable()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("#", typeof(int));
            dt.Columns.Add("表示名", typeof(string));
            dt.Columns.Add("用途/備考", typeof(string));
            dt.Columns.Add("スキーマ名", typeof(string));
            dt.Columns.Add("論理名", typeof(string));
            dt.Columns.Add("必須", typeof(string));
            dt.Columns.Add("データ型", typeof(string));
            dt.Columns.Add("書式", typeof(string));
            dt.Columns.Add("関連テーブル", typeof(string));
            dt.Columns.Add("オプションセット名", typeof(string));
            dt.Columns.Add("オプションセット項目", typeof(string));
            dt.Columns.Add("オプション既定値", typeof(string));
            dt.Columns.Add("タイムゾーン", typeof(string));
            dt.Columns.Add("最大の長さ", typeof(string));
            dt.Columns.Add("最小値", typeof(string));
            dt.Columns.Add("最大値", typeof(string));
            dt.Columns.Add("精度のソース", typeof(string));
            dt.Columns.Add("小数点以下の表示桁数", typeof(string));
            //dt.Columns.Add("IMEモード", typeof(string));
            //dt.Columns.Add("計算/ロールアップの式", typeof(string));
            dt.Columns.Add("種類", typeof(string));
            dt.Columns.Add("動作", typeof(string));
            //dt.Columns.Add("採番形式", typeof(string));
            //dt.Columns.Add("基本通貨", typeof(string));
            //dt.Columns.Add("検索可能", typeof(string));
            dt.Columns.Add("監査", typeof(string));
            dt.Columns.Add("セキュリティ", typeof(string));
            dt.Columns.Add("備考", typeof(string));

            //dt.Columns.Add("Format", typeof(string));
            //dt.Columns.Add("FormatName", typeof(string));
            //dt.Columns.Add("ParentPicklistLogicalName", typeof(string));
            //dt.Columns.Add("ChildPicklistLogicalNames", typeof(string));

            return dt;
        }

        /// <summary>
        /// フィールド定義用テーブルに行を追加
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="outputEntityMetadata"></param>
        /// <returns>フィールド定義用テーブル</returns>
        public DataTable AddRowToFieldDefinitionTable(DataTable dt, OutputFieldMetadata outputFieldMetadata)
        {
            DataRow dr = dt.NewRow();
            dr["#"] = dt.Rows.Count + 1;
            dr["表示名"] = outputFieldMetadata.DisplayName;
            dr["用途/備考"] = "";
            //dr["説明"] = outputFieldMetadata.Description;
            //dr["スキーマ名"] = outputFieldMetadata.SchemaName;
            dr["論理名"] = outputFieldMetadata.LogicalName;
            dr["必須"] = outputFieldMetadata.RequiredLevel;
            dr["データ型"] = outputFieldMetadata.AttributeType;
            dr["書式"] = outputFieldMetadata.AttributeType;
            dr["関連テーブル"] = outputFieldMetadata.Targets;
            dr["オプションセット名"] = outputFieldMetadata.OptionSet;
            dr["オプションセット項目"] = outputFieldMetadata.OptionSet;
            dr["オプション既定値"] = outputFieldMetadata.DefaultValue;
            dr["タイムゾーン"] = outputFieldMetadata.DateTimeBehavior;
            dr["最大の長さ"] = outputFieldMetadata.MaxLength;
            dr["最小値"] = outputFieldMetadata.MinValue;
            dr["最大値"] = outputFieldMetadata.MaxValue;
            dr["精度のソース"] = outputFieldMetadata.PrecisionSouce;
            dr["小数点以下の表示桁数"] = outputFieldMetadata.Precision;
            //dr["IMEモード"] = outputFieldMetadata.ImeMode;
            dr["種類"] = outputFieldMetadata.IsCustomAttributes;
            dr["動作"] = outputFieldMetadata.SourceType;
            //dr["計算/ロールアップの式"] = outputFieldMetadata.FormulaDefinition;
            //dr["採番形式"] = outputFieldMetadata.AutoNumberFormat;
            //dr["基本通貨"] = outputFieldMetadata.IsBaseCurrency;
            //dr["検索可能"] = outputFieldMetadata.IsSearchable;
            dr["監査"] = outputFieldMetadata.IsAuditEnabled;
            dr["セキュリティ"] = outputFieldMetadata.IsSecured;
            dr["備考"] = "";

            //dr["Format"] = outputFieldMetadata.Format;
            //dr["FormatName"] = outputFieldMetadata.FormatName;
            //dr["ParentPicklistLogicalName"] = outputFieldMetadata.ParentPicklistLogicalName;
            //dr["ChildPicklistLogicalNames"] = outputFieldMetadata.ChildPicklistLogicalNames;

            dt.Rows.Add(dr);

            Console.WriteLine("【成功】フィールド名：" + outputFieldMetadata.DisplayName + "(" + outputFieldMetadata.SchemaName + ")");

            return dt;
        }
    }
}