using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace ExportView
{
    class Program
    {
        readonly private static string SAUCE_FILE_PATH = @"customizations.xml";
        readonly private static string TEMPLETE_FILE_PATH = @"ViewDefinition.xlsx";
        readonly private static string OUTPUT_FILE_PATH = @"Excel\ViewDefinition_write.xlsx";
        readonly private static string VIEW_DEFINITION_SHEET_NAME = @"Sheet1";
        readonly private static string VIEW_DEFINITION_INSERT_CELL = @"B2";

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

            //ビューの種類格納用
            var viewTypeCode = "";

            //ビュー名格納用
            var viewName = "";

            //ビューの種類格納用
            var queryType = "";

            //フィールド物理名格納用
            var fieldNamePhysical = "";

            //フィールド表示名格納用
            var fieldNameDisplay = "";

            //備考
            var description = "";

            //ソート順の格納用配列
            string[] sort = { "", "", "" };

            //テーブル数分ループ
            foreach (XElement entity in entities)
            {
                //テーブル名の取得
                var entityName = entity.Element("Name").FirstAttribute.Value;

                //ビューの取得
                var savedQueries = from item in entity.Descendants("savedquery")
                                   select item;

                if (savedQueries.Count() == 0)
                {
                    viewTypeCode = "-";
                    viewName = "-";
                    fieldNamePhysical = "-";
                    fieldNameDisplay = "-";
                    description = "対象のクエリ無し";
                    sort = new string[] { "", "", "" };

                    //ビューが存在しない場合はテーブル名のみ出力
                    excel.AddRowToViewDefinitionTable(viewDt, entityName, viewTypeCode, viewName, fieldNamePhysical, fieldNameDisplay, description, sort);
                }

                //ビューの数分ループ
                foreach (XElement savedQuery in savedQueries)
                {
                    string[,] sortFields = { { "", "0", "" }, { "", "1", "" }, { "", "2", "" } };

                    //ビュー名の取得
                    viewName = (from item in savedQuery.Descendants("LocalizedName")
                                select item).FirstOrDefault(e => e.Attribute("languagecode")?.Value == "1041")?.Attribute("description").Value;

                    //ビューの種類の取得
                    viewTypeCode = (from item in savedQuery.Elements("querytype")
                                    select item).FirstOrDefault().Value;

                    //ビューの列（簡易検索ビューの場合は検索列）を取得
                    IEnumerable<XElement> fields;
                    string fieldNameAttribute;

                    if (Equals(queryType, "4"))
                    {
                        //検索列の取得
                        var quickFindFieldsFilter = (from item in savedQuery.Descendants("filter")
                                                     select item).FirstOrDefault(e => e.Attribute("isquickfindfields")?.Value == "1");
                        fields = from item in quickFindFieldsFilter.Descendants("condition")
                                 select item;

                        //ビュー列名が格納されているプロパティ名
                        fieldNameAttribute = "attribute";
                    }
                    else
                    {
                        //ソート順の取得
                        var orders = from item in savedQuery.Descendants("order")
                                     select item;
                        var count = 0;
                        foreach (XElement order in orders)
                        {
                            if (count > 2)
                            {
                                description = "ソート列が4つ以上存在";
                                break;
                            }

                            sortFields[count, 0] = order.Attribute("attribute").Value;
                            sortFields[count, 2] = order.Attribute("descending").Value;
                            count++;
                        }

                        //ビュー列の取得
                        fields = from item in savedQuery.Descendants("cell")
                                 select item;

                        //ビュー列名が格納されているプロパティ名
                        fieldNameAttribute = "name";
                    }

                    //フィールドが存在しない場合は対象フィールドなしとして出力（原則あり得ないパターン）
                    if (fields.Count() == 0)
                    {
                        fieldNamePhysical = "-";
                        fieldNameDisplay = "-";
                        description = "対象フィールド無し";
                        sort = new string[] { "", "", "" };

                        excel.AddRowToViewDefinitionTable(viewDt, entityName, viewTypeCode, viewName, fieldNamePhysical, fieldNameDisplay, description, sort);
                    }

                    //ビュー列の数分ループ
                    foreach (XElement field in fields)
                    {
                        sort = new string[] { "", "", "" };
                        //ビュー列名の取得
                        fieldNamePhysical = field.Attribute(fieldNameAttribute).Value;

                        var entityInfo = (from item in entity.Descendants("EntityInfo")
                                          select item).First();
                        var attributes = from item in entityInfo.Descendants("attribute")
                                         select item;
                        fieldNameDisplay = "該当なし";
                        foreach (var attribute in attributes)
                        {
                            fieldNameDisplay = "該当なし";
                            var fieldNamePhysical_cp = (from item in attribute.Descendants("LogicalName")
                                                        select item).First().Value;
                            if (Equals(fieldNamePhysical_cp, fieldNamePhysical))
                            {
                                fieldNameDisplay = (from item in attribute.Descendants("displayname")
                                                    select item).FirstOrDefault(e => e.Attribute("languagecode")?.Value == "1041")?.Attribute("description").Value;
                                break;
                            }
                        }

                        //取得したソート順にフィールドが存在する場合はsort変数にソート情報を設定
                        for (var i = 0; i < sort.Length; i++)
                        {
                            if (Equals(sortFields[i, 0], fieldNamePhysical))
                                sort[int.Parse(sortFields[i, 1])] = Equals(sortFields[i, 2], "false") ? "▲" : "▼";
                        }

                        description = "";
                        // ビュー定義テーブルに行追加
                        excel.AddRowToViewDefinitionTable(viewDt, entityName, viewTypeCode, viewName, fieldNamePhysical, fieldNameDisplay, description, sort);
                    }
                }
            }
            // Excelのシートにビュー定義テーブルを出力
            excel.Worksheet.Cell(VIEW_DEFINITION_INSERT_CELL).InsertTable(viewDt);

            // Excelファイルを出力
            excel.ExcelSaveAs(OUTPUT_FILE_PATH);
        }
    }
}