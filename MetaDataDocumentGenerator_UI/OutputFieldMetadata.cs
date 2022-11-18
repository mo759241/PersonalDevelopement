using Microsoft.Xrm.Sdk.Messages;
using Microsoft.Xrm.Sdk.Metadata;
using Microsoft.Xrm.Tooling.Connector;
using System.Collections.Generic;

namespace MetaDataDocumentGenerator_UI
{
    public class OutputFieldMetadata
    {
        public OutputFieldMetadata(AttributeMetadata attributeMetadata)
        {
            // 表示名
            DisplayName = attributeMetadata.DisplayName.UserLocalizedLabel?.Label;
            // 物理名
            LogicalName = attributeMetadata.LogicalName;
            // スキーマ名
            SchemaName = attributeMetadata.SchemaName;
            // 必須/推奨/任意
            RequiredLevel = Const.TranRequiredLevel[attributeMetadata.RequiredLevel.Value.ToString()];
            // 説明
            Description = attributeMetadata.Description.UserLocalizedLabel?.Label;
            // データの種類
            AttributeType = Const.TranAttributeType[attributeMetadata.AttributeTypeName.Value.Replace("Type", "")];
            // AttributeTypeName = attributeMetadata.AttributeTypeName.Value.Replace("Type", "");
            // オートナンバーの形式
            AutoNumberFormat = attributeMetadata.AutoNumberFormat;
            // 計算/ロールアップ
            SourceType = attributeMetadata.SourceType != null ?
                         Const.TranSourceType[attributeMetadata.SourceType] :
                         null;
            // 検索可能
            IsSearchable = Const.TranValidInvalid[attributeMetadata.IsSearchable];
            // フィールドセキュリティの有効化
            IsSecured = Const.TranYesNo[attributeMetadata.IsSecured];
            // 監査の有効化
            IsAuditEnabled = Const.TranValidInvalid[attributeMetadata.IsAuditEnabled.Value];
            // カスタム/標準
            IsCustomAttributes = Const.TranIsCustom[attributeMetadata.IsCustomAttribute];
        }
        public OutputFieldMetadata(AttributeMetadata attributeMetadata, BigIntAttributeMetadata typeAttributeMetadata) : this(attributeMetadata)
        {
            // 最大値
            MaxValue = typeAttributeMetadata.MaxValue.ToString();
            // 最小値
            MinValue = typeAttributeMetadata.MinValue.ToString();
        }
        public OutputFieldMetadata(AttributeMetadata attributeMetadata, BooleanAttributeMetadata typeAttributeMetadata) : this(attributeMetadata)
        {
            var boolOption = typeAttributeMetadata.OptionSet;
            // 既定値
            DefaultValue = (bool)typeAttributeMetadata.DefaultValue ?
                            boolOption.TrueOption.Label.UserLocalizedLabel.Label :
                            boolOption.FalseOption.Label.UserLocalizedLabel.Label; ;
            // ラベル
            OptionSet = typeAttributeMetadata.OptionSet.FalseOption.Label.UserLocalizedLabel.Label +
                        "/" +
                        typeAttributeMetadata.OptionSet.TrueOption.Label.UserLocalizedLabel.Label;
            // FormulaDefinition = typeAttributeMetadata.FormulaDefinition;
        }
        public OutputFieldMetadata(AttributeMetadata attributeMetadata, DateTimeAttributeMetadata typeAttributeMetadata) : this(attributeMetadata)
        {
            // 日付の動作
            DateTimeBehavior = Const.TranDateTimeBehavior[typeAttributeMetadata.DateTimeBehavior.Value];
            // FormulaDefinition = typeAttributeMetadata.FormulaDefinition;
            // 
            // Format = typeAttributeMetadata.Format.ToString();
            // データの種類　※ 日付と時刻 or 日付のみ はAttributeTypeではなくFormatに格納される
            AttributeType = Const.TranAttributeType[typeAttributeMetadata.Format.ToString()];
            // IMEモード
            ImeMode = Const.TranImeMode[typeAttributeMetadata.ImeMode.ToString()];
        }
        public OutputFieldMetadata(AttributeMetadata attributeMetadata, DecimalAttributeMetadata typeAttributeMetadata) : this(attributeMetadata)
        {
            //FormulaDefinition = typeAttributeMetadata.FormulaDefinition;
            // 最大値
            MaxValue = typeAttributeMetadata.MaxValue.ToString();
            // 最小値
            MinValue = typeAttributeMetadata.MinValue.ToString();
            // IMEモード
            ImeMode = Const.TranImeMode[typeAttributeMetadata.ImeMode.ToString()];
        }
        public OutputFieldMetadata(AttributeMetadata attributeMetadata, DoubleAttributeMetadata typeAttributeMetadata) : this(attributeMetadata)
        {
            // 最大値
            MaxValue = typeAttributeMetadata.MaxValue.ToString();
            // 最小値
            MinValue = typeAttributeMetadata.MinValue.ToString();
            // 小数点以下の表示桁数
            Precision = typeAttributeMetadata.Precision.ToString();
            // IMEモード
            ImeMode = Const.TranImeMode[typeAttributeMetadata.ImeMode.ToString()];
        }
        public OutputFieldMetadata(AttributeMetadata attributeMetadata, EntityNameAttributeMetadata typeAttributeMetadata) : this(attributeMetadata)
        { }
        public OutputFieldMetadata(AttributeMetadata attributeMetadata, IntegerAttributeMetadata typeAttributeMetadata) : this(attributeMetadata)
        {
            // Format = typeAttributeMetadata.Format.ToString();
            // タイムゾーンや言語等、通常の整数でない場合ははAttributeTypeではなくFormatに格納される
            if (!Equals(typeAttributeMetadata.Format.ToString(), "None"))
            {
                AttributeType = Const.TranAttributeType[typeAttributeMetadata.Format.ToString()];
            }
            // 最大値
            MaxValue = typeAttributeMetadata.MaxValue.ToString();
            // 最小値
            MinValue = typeAttributeMetadata.MinValue.ToString();
            //FormulaDefinition = typeAttributeMetadata.FormulaDefinition;
        }
        public OutputFieldMetadata(AttributeMetadata attributeMetadata, LookupAttributeMetadata typeAttributeMetadata, CrmServiceClient svc) : this(attributeMetadata)
        {
            // 関連エンティティの表示名
            var targetEntityDisplayNames = GetTargetEntitiesDisplayName(svc, typeAttributeMetadata.Targets);
            var listCount = targetEntityDisplayNames.Count;
            for (var i = 0; i < listCount; i++)
            {
                Targets += targetEntityDisplayNames[i];
                if (i != listCount - 1)
                {
                    Targets += "/";
                }
            }
            // Format = typeAttributeMetadata.Format.ToString();
        }
        public OutputFieldMetadata(AttributeMetadata attributeMetadata, ManagedPropertyAttributeMetadata typeAttributeMetadata) : this(attributeMetadata)
        { }
        public OutputFieldMetadata(AttributeMetadata attributeMetadata, MemoAttributeMetadata typeAttributeMetadata) : this(attributeMetadata)
        {
            // 最大桁数
            MaxLength = typeAttributeMetadata.MaxLength.ToString();
            // Format = typeAttributeMetadata.Format.ToString();
            // IMEモード
            ImeMode = Const.TranImeMode[typeAttributeMetadata.ImeMode.ToString()];
        }
        public OutputFieldMetadata(AttributeMetadata attributeMetadata, MoneyAttributeMetadata typeAttributeMetadata) : this(attributeMetadata)
        {
            // 既定の通貨
            IsBaseCurrency = Const.TranYesNo[typeAttributeMetadata.IsBaseCurrency];
            // 最大値
            MaxValue = typeAttributeMetadata.MaxValue.ToString();
            // 最小値
            MinValue = typeAttributeMetadata.MinValue.ToString();
            // 小数点以下の表示桁数
            Precision = typeAttributeMetadata.Precision.ToString();
            // 精度のソース
            PrecisionSouce = Const.TranPrecisionSouce[typeAttributeMetadata.PrecisionSource];
            //FormulaDefinition = typeAttributeMetadata.FormulaDefinition;
            // IMEモード
            ImeMode = Const.TranImeMode[typeAttributeMetadata.ImeMode.ToString()];
        }
        public OutputFieldMetadata(AttributeMetadata attributeMetadata, PicklistAttributeMetadata typeAttributeMetadata) : this(attributeMetadata)
        {
            //var childPicklistLogicalNames = typeAttributeMetadata.ChildPicklistLogicalNames;
            //if (childPicklistLogicalNames != null)
            //{
            //    for (var i = 0; i < childPicklistLogicalNames.Count; i++)
            //    {
            //        ChildPicklistLogicalNames += childPicklistLogicalNames[i];
            //        if (i != childPicklistLogicalNames.Count - 1)
            //        {
            //            ChildPicklistLogicalNames += "/";
            //        }
            //    }
            //}
            //else
            //{
            //    ChildPicklistLogicalNames = null;
            //}
            //ParentPicklistLogicalName = typeAttributeMetadata.ParentPicklistLogicalName;
            // グローバルオプションセット名
            OptionSet = typeAttributeMetadata.OptionSet.DisplayName.UserLocalizedLabel.Label;
            // 既定値
            DefaultValue = GetDefaultValue(typeAttributeMetadata.DefaultFormValue, typeAttributeMetadata.OptionSet);
            //FormulaDefinition = typeAttributeMetadata.FormulaDefinition;
        }

        public OutputFieldMetadata(AttributeMetadata attributeMetadata, StateAttributeMetadata typeAttributeMetadata) : this(attributeMetadata)
        {
            // 既定値
            DefaultValue = GetDefaultValue(typeAttributeMetadata.DefaultFormValue, typeAttributeMetadata.OptionSet);
            // オプションセットの表示名
            OptionSet = typeAttributeMetadata.OptionSet.DisplayName.UserLocalizedLabel.Label;
        }
        public OutputFieldMetadata(AttributeMetadata attributeMetadata, StatusAttributeMetadata typeAttributeMetadata) : this(attributeMetadata)
        {
            // 既定値
            DefaultValue = GetDefaultValue(typeAttributeMetadata.DefaultFormValue, typeAttributeMetadata.OptionSet);
            // オプションセットの表示名
            OptionSet = typeAttributeMetadata.OptionSet.DisplayName.UserLocalizedLabel.Label;
        }
        public OutputFieldMetadata(AttributeMetadata attributeMetadata, StringAttributeMetadata typeAttributeMetadata) : this(attributeMetadata)
        {
            // 最大桁数
            MaxLength = typeAttributeMetadata.DatabaseLength.ToString();
            // Format = typeAttributeMetadata.Format.ToString();
            // テキスト以外の場合はAttributeTypeではなくFormatNameに格納される（テキストの場合はFormatNameにも"テキスト"が格納されるため、無条件でFormantNameを出力する）
            AttributeType = Const.TranAttributeType[typeAttributeMetadata.FormatName.Value];
            //FormatName = typeAttributeMetadata.FormatName.Value;
            //FormulaDefinition = typeAttributeMetadata.FormulaDefinition;
            ImeMode = Const.TranImeMode[typeAttributeMetadata.ImeMode.ToString()];

        }
        //public OutputFieldMetadata(AttributeMetadata attributeMetadata, UniqueIdentifierAttributeMetadata typeAttributeMetadata) : this(attributeMetadata)
        //{
        //}

        /// <summary>
        /// オプションセットの既定値を取得
        /// </summary>
        /// <param name="defaultFormValue"></param>
        /// <param name="optionSetMetadata"></param>
        /// <returns>オプションセットの既定値</returns>
        private string GetDefaultValue(int? defaultFormValue, OptionSetMetadata optionSetMetadata)
        {
            if (defaultFormValue != null && defaultFormValue > -1)
            {
                var optionMetadata = new List<OptionMetadata>(optionSetMetadata.Options).
                FindAll(option => option.Value == defaultFormValue);
                var optionLabel = optionMetadata.Count != 0 ?
                                  optionMetadata[0] :
                                  null;
                return optionLabel?.Label.UserLocalizedLabel.Label;
            }
            else
            {
                return null;
            }

        }

        /// <summary>
        /// 指定したエンティティの表示名を取得する（複数エンティティもOK）
        /// </summary>
        /// <param name="svc">CRM Service Client</param>
        /// <param name="targets">ターゲットエンティティ</param>
        /// <returns>エンティティの表示名リスト</returns>
        private static List<string> GetTargetEntitiesDisplayName(CrmServiceClient svc, string[] targets)
        {
            var targetEntitiesDisplayNames = new List<string>();
            foreach (var target in targets)
            {
                RetrieveEntityRequest retrieveEntityRequest = new RetrieveEntityRequest
                {
                    EntityFilters = EntityFilters.All,
                    LogicalName = target
                };
                RetrieveEntityResponse retrieveEntityResponse = (RetrieveEntityResponse)svc.Execute(retrieveEntityRequest);
                targetEntitiesDisplayNames.Add(retrieveEntityResponse.EntityMetadata.DisplayName.UserLocalizedLabel.Label);
            }
            return targetEntitiesDisplayNames;
        }

        public string DisplayName { get; set; }
        public string LogicalName { get; set; }
        public string SchemaName { get; set; }
        public string RequiredLevel { get; set; }
        public string Description { get; set; }
        public string AttributeType { get; set; }
        public string AttributeTypeName { get; set; }
        public string AutoNumberFormat { get; set; }
        public string Targets { get; set; }
        public string OptionSet { get; set; }
        public string DefaultValue { get; set; }
        public string DateTimeBehavior { get; set; }
        public string MaxLength { get; set; }
        public string MinValue { get; set; }
        public string MaxValue { get; set; }
        public string Precision { get; set; }
        public string PrecisionSouce { get; set; }
        public string SourceType { get; set; }
        public string IsSearchable { get; set; }
        public string IsSecured { get; set; }
        public string IsAuditEnabled { get; set; }
        public string IsCustomAttributes { get; set; }
        //public string FormulaDefinition { get; set; }

        public string Format { get; set; }
        public string FormatName { get; set; }
        public string ImeMode { get; set; }
        public string IsBaseCurrency { get; set; }
        public string ParentPicklistLogicalName { get; set; }
        public string ChildPicklistLogicalNames { get; set; }

    }
}
