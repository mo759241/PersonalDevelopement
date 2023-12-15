using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace ExportView
{
    class Program
    {
        readonly private static string SAUCE_FILE_PATH = "customizations.xml";
        readonly private static string TEMPLETE_FILE_PATH = "ViewDefinition.xlsx";
        readonly private static string OUTPUT_FILE_PATH = "ViewDefinition_write.xlsx";
        readonly private static string VIEW_DEFINITION_SHEET_NAME = "Sheet1";
        readonly private static string VIEW_DEFINITION_INSERT_CELL = "B2";

        // シート名に使えない文字
        readonly private static string[] INVALID_CHARS_IN_WORKSHEET_NAME = { @"\", @"/", @"?", @"*", @"[", @"]" };

        public static void Main(string[] args)
        {
            // テンプレートファイルからExcelインスタンスを作成
            var excel = new Excel(TEMPLETE_FILE_PATH, VIEW_DEFINITION_SHEET_NAME);

            // ビュー定義のテーブル作成
            var viewDt = excel.CreateViewDefinitionTable();

            //読み込むxmlファイルを指定する
            XElement xml = XElement.Load(SAUCE_FILE_PATH);

            //Entitiesタグ内のテーブル名を取得する
            var entities = from item in
                                  (from item in xml.Elements("Entities")
                                   select item).First().Elements("Entity")
                           select item;

            //テーブル数分ループして、ビュー名、ビューの列名を取得してテーブルに出力する
            foreach (XElement entity in entities)
            {
                var entityName = entity.Element("Name").FirstAttribute.Value;

                var allQueries = (from item in entity.Elements("SavedQueries")
                                  select item);

                if (allQueries.Count() == 0)
                {
                    continue;
                }

                var savedQueries = from item in
                                          (from item in allQueries.First().Elements("savedqueries")
                                           select item).First().Elements("savedquery")
                                   select item;

                foreach (XElement savedQuery in savedQueries)
                {
                    var localizedName = (from item in
                                             (from item in savedQuery.Elements("LocalizedNames")
                                              select item).First().Elements("LocalizedName")
                                         select item).First().FirstAttribute.Value;

                    var queryType = (from item in savedQuery.Elements("querytype")
                                     select item).First().Value;

                    var layoutxml = from item in savedQuery.Elements("layoutxml")
                                    select item;
                    if (layoutxml.Count() == 0)
                    {
                        continue;
                    }

                    var cells = from item in
                                    (from item in
                                         (from item in layoutxml.First().Elements("grid")
                                          select item).First().Elements("row")
                                     select item).First().Elements("cell")
                                select item;

                    foreach (XElement cell in cells)
                    {
                        var fieldName = cell.FirstAttribute.Value;
                        // エンティティ定義テーブルに行追加してエンティティメタデータを設定
                        excel.AddRowToViewDefinitionTable(viewDt, entityName, queryType, localizedName, fieldName);
                    }
                }
            }
            // エンティティ定義シートにテーブルを出力
            excel.Worksheet.Cell(VIEW_DEFINITION_INSERT_CELL).InsertTable(viewDt);

            // Excelファイルを出力
            excel.ExcelSaveAs(OUTPUT_FILE_PATH);
        }
    }
}