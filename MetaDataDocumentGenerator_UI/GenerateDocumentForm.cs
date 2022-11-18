using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Messages;
using Microsoft.Xrm.Sdk.Metadata;
using Microsoft.Xrm.Tooling.Connector;

namespace MetaDataDocumentGenerator_UI
{
    public partial class GenerateDocumentForm : Form
    {
        readonly private static string TEMPLETE_FILE_PATH = "01_フィールド定義書.xlsx";
        readonly private static string ENTITY_DEFINITION_SHEET_NAME = "エンティティ一覧";
        readonly private static string ENTITY_DEFINITION_INSERT_CELL = "A5";
        readonly private static string FIELD_DEFINITION_INSERT_CELL = "B6";
        // シート名に使えない文字
        readonly private static string[] INVALID_CHARS_IN_WORKSHEET_NAME = { @"\", @"/", @"?", @"*", @"[", @"]" };

        private static string TargetSolution { get; set; }
        private static int ProgressPercent { get; set; }


        public GenerateDocumentForm(string solutionLogicalName)
        {
            InitializeComponent();
            TargetSolution = solutionLogicalName;
        }

        private void OpenFileBrowseDialog_Click(object sender, EventArgs e)
        {
            if (OutputFileBrowserDialog.ShowDialog(this) == DialogResult.OK)
            {
                FolderPath.Text = OutputFileBrowserDialog.SelectedPath;
            }
        }

        private void GenerateDoument_Click(object sender, EventArgs e)
        {
            try
            {
                Helper.StartProgressBar();

                using (var context = new MyContext(Helper.orgSvc))
                {
                    // エクスポート対象のソリューション情報を取得
                    var solQuery = from sol in context.SolutionSet
                                   where sol.UniqueName == TargetSolution
                                   select new Solution()
                                   {
                                       SolutionId = sol.Id,
                                   };

                    var solution = solQuery.FirstOrDefault();

                    // エクスポート対象ソリューションに含まれるエンティティを取得
                    var solComponentQuery = from solComponent in context.SolutionComponentSet
                                            where solComponent.SolutionId.Id == solution.Id &&
                                                  solComponent.ComponentType.Value == 1 // エンティティ
                                            select solComponent;
                    var targetEntities = solComponentQuery.ToList();

                    ProgressPercent = 10;
                    Helper.UpdateProgressBar(ProgressPercent);
                    var progressPercentDiff = 90 / targetEntities.Count();

                    // テンプレートファイルからExcelインスタンスを作成
                    var excel = new Excel(TEMPLETE_FILE_PATH, ENTITY_DEFINITION_SHEET_NAME);
                    try
                    {
                        // エンティティ定義のテーブル作成
                        var entityDt = excel.CreateEntityDefinitionTable();

                        // エンティティごとにエンティティ定義とフィールド定義を出力
                        foreach (var targetEntity in targetEntities)
                        {
                            // エンティティのメタデータを取得
                            RetrieveEntityRequest retrieveEntityRequest = new RetrieveEntityRequest
                            {
                                EntityFilters = EntityFilters.All,
                                MetadataId = (Guid)targetEntity.ObjectId
                            };
                            RetrieveEntityResponse retrieveEntityResponse = (RetrieveEntityResponse)Helper.Svc.Execute(retrieveEntityRequest);
                            EntityMetadata entityMetadata = retrieveEntityResponse.EntityMetadata;
                            OutputEntityMetadata outputEntityMetadata = new OutputEntityMetadata(entityMetadata);

                            // エンティティ定義テーブルに行追加してエンティティメタデータを設定
                            excel.AddRowToEntityDefinitionTable(entityDt, outputEntityMetadata);

                            // フィールド定義のシートを作成（シート名＝エンティティ表示名）
                            var fieldSheetName = entityMetadata.DisplayName.UserLocalizedLabel.Label;
                            foreach (var invalidChar in INVALID_CHARS_IN_WORKSHEET_NAME)
                            {
                                fieldSheetName = fieldSheetName.Replace(invalidChar, "");
                            }
                            var fieldSheet = excel.Workbook.Worksheets.Add(fieldSheetName);

                            // フィールド定義のテーブル作成
                            var fieldDt = excel.CreateFieldDefinitionTable();
                            var attributeMetadatas = entityMetadata.Attributes;
                            // フィールドごとにフィールド定義を出力
                            for (var i = 0; i < attributeMetadatas.Length; i++)
                            {
                                var attributeType = attributeMetadatas[i].AttributeType.Value;
                                OutputFieldMetadata outputFieldMetadata = null;

                                // データ型によって取得できるメタデータが異なるため分岐処理
                                switch (attributeType)
                                {
                                    case AttributeTypeCode.BigInt:
                                        BigIntAttributeMetadata bigIntAttributeMetadata = (BigIntAttributeMetadata)attributeMetadatas[i];
                                        outputFieldMetadata = new OutputFieldMetadata(attributeMetadatas[i], bigIntAttributeMetadata);
                                        break;
                                    case AttributeTypeCode.Boolean:
                                        BooleanAttributeMetadata booleanAttributeMetadata = (BooleanAttributeMetadata)attributeMetadatas[i];
                                        outputFieldMetadata = new OutputFieldMetadata(attributeMetadatas[i], booleanAttributeMetadata);
                                        break;
                                    case AttributeTypeCode.DateTime:
                                        DateTimeAttributeMetadata dateTimeAttributeMetadata = (DateTimeAttributeMetadata)attributeMetadatas[i];
                                        outputFieldMetadata = new OutputFieldMetadata(attributeMetadatas[i], dateTimeAttributeMetadata);
                                        break;
                                    case AttributeTypeCode.Decimal:
                                        DecimalAttributeMetadata decimalAttributeMetadata = (DecimalAttributeMetadata)attributeMetadatas[i];
                                        outputFieldMetadata = new OutputFieldMetadata(attributeMetadatas[i], decimalAttributeMetadata);
                                        break;
                                    case AttributeTypeCode.Double:
                                        DoubleAttributeMetadata doubleAttributeMetadata = (DoubleAttributeMetadata)attributeMetadatas[i];
                                        outputFieldMetadata = new OutputFieldMetadata(attributeMetadatas[i], doubleAttributeMetadata);
                                        break;
                                    case AttributeTypeCode.EntityName:
                                        EntityNameAttributeMetadata entityNameAttributeMetadata = (EntityNameAttributeMetadata)attributeMetadatas[i];
                                        outputFieldMetadata = new OutputFieldMetadata(entityNameAttributeMetadata);
                                        break;
                                    case AttributeTypeCode.Integer:
                                        IntegerAttributeMetadata integerAttributeMetadata = (IntegerAttributeMetadata)attributeMetadatas[i];
                                        outputFieldMetadata = new OutputFieldMetadata(attributeMetadatas[i], integerAttributeMetadata);
                                        break;
                                    case AttributeTypeCode.Lookup:
                                        LookupAttributeMetadata lookupAttributeMetadata = (LookupAttributeMetadata)attributeMetadatas[i];
                                        outputFieldMetadata = new OutputFieldMetadata(attributeMetadatas[i], lookupAttributeMetadata, Helper.Svc);
                                        break;
                                    case AttributeTypeCode.ManagedProperty:
                                        ManagedPropertyAttributeMetadata managedPropertyAttributeMetadata = (ManagedPropertyAttributeMetadata)attributeMetadatas[i];
                                        outputFieldMetadata = new OutputFieldMetadata(managedPropertyAttributeMetadata);
                                        break;
                                    case AttributeTypeCode.Memo:
                                        MemoAttributeMetadata memoAttributeMetadata = (MemoAttributeMetadata)attributeMetadatas[i];
                                        outputFieldMetadata = new OutputFieldMetadata(attributeMetadatas[i], memoAttributeMetadata);
                                        break;
                                    case AttributeTypeCode.Money:
                                        MoneyAttributeMetadata moneyAttributeMetadata = (MoneyAttributeMetadata)attributeMetadatas[i];
                                        outputFieldMetadata = new OutputFieldMetadata(attributeMetadatas[i], moneyAttributeMetadata);
                                        break;
                                    case AttributeTypeCode.Picklist:
                                        PicklistAttributeMetadata picklistAttributeMetadata = (PicklistAttributeMetadata)attributeMetadatas[i];
                                        outputFieldMetadata = new OutputFieldMetadata(attributeMetadatas[i], picklistAttributeMetadata);
                                        break;
                                    case AttributeTypeCode.State:
                                        StateAttributeMetadata stateAttributeMetadata = (StateAttributeMetadata)attributeMetadatas[i];
                                        outputFieldMetadata = new OutputFieldMetadata(attributeMetadatas[i], stateAttributeMetadata);
                                        break;
                                    case AttributeTypeCode.Status:
                                        StatusAttributeMetadata statusAttributeMetadata = (StatusAttributeMetadata)attributeMetadatas[i];
                                        outputFieldMetadata = new OutputFieldMetadata(attributeMetadatas[i], statusAttributeMetadata);
                                        break;
                                    case AttributeTypeCode.String:
                                        StringAttributeMetadata stringAttributeMetadata = (StringAttributeMetadata)attributeMetadatas[i];
                                        outputFieldMetadata = new OutputFieldMetadata(attributeMetadatas[i], stringAttributeMetadata);
                                        break;
                                    //case AttributeTypeCode.Uniqueidentifier:
                                    //    UniqueIdentifierAttributeMetadata uniqueIdentifierAttributeMetadata = (UniqueIdentifierAttributeMetadata)attributeMetadatas[i];
                                    //    outputFieldMetadata = new OutputFieldMetadata(uniqueIdentifierAttributeMetadata);
                                    //    break;
                                    default:
                                        AttributeMetadata attributeMetadata = attributeMetadatas[i];
                                        outputFieldMetadata = new OutputFieldMetadata(attributeMetadata);
                                        break;
                                }

                                Helper.UpdateProgressBar(ProgressPercent + progressPercentDiff);

                                // フィールド定義テーブルに行追加してフィールドメタデータを設定
                                if (IsAllowAddingFieldDefinitionTable(AutoGenerateFieldOutputFg.Checked, outputFieldMetadata))
                                {
                                    excel.AddRowToFieldDefinitionTable(fieldDt, outputFieldMetadata);
                                }
                                else
                                {
                                    continue;
                                }
                            }

                            // フィールド定義シートにテーブルを出力 
                            fieldSheet.Cell(FIELD_DEFINITION_INSERT_CELL).InsertTable(fieldDt);
                        }

                        // エンティティ定義シートにテーブルを出力
                        excel.Worksheet.Cell(ENTITY_DEFINITION_INSERT_CELL).InsertTable(entityDt);

                        // テンプレートシートを削除
                        excel.ExcelSheetDelete(excel);

                        // Excelファイルを出力
                        var fullFilePath = FolderPath.Text + @"\" + OutputFileName.Text + ".xlsx";
                        excel.ExcelSaveAs(fullFilePath);
                    }
                    finally
                    {
                        Helper.CloseProgressBar();
                        Close();
                        excel.Dispose();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        /// <summary>
        /// フィールド定義テーブルにメタデータを追加するかどうかの判定
        /// </summary>
        /// <param name="outputFieldMetadata"></param>
        /// <param name="autoGenerateFieldOutputFg"></param>
        /// <returns>追加する/追加しない(true/false)</returns>
        private static bool IsAllowAddingFieldDefinitionTable(bool autoGenerateFieldOutputFg, OutputFieldMetadata outputFieldMetadata)
        {
            // 下記のフラグがtrueの場合は内部的なフィールドを含む全てのフィールドを出力
            if (autoGenerateFieldOutputFg)
            {
                return true;
            }
            // 表示名が設定されていない内部的なフィールドや出力しないデータ型として設定したフィールドは出力しない
            else if (string.IsNullOrWhiteSpace(outputFieldMetadata.DisplayName) ||
                     Const.NonOutputAttributeType.Contains(outputFieldMetadata.AttributeType))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
