using Microsoft.Xrm.Sdk.Metadata;

namespace MetaDataDocumentGenerator_UI
{
    public class OutputEntityMetadata
    {
        readonly private static string HAS_ACTIVITIES_AND_NOTES = "活動/メモ";
        readonly private static string HAS_ACTIVITIES = "活動";
        readonly private static string HAS_NOTES = "メモ";
        readonly private static string HAS_NOTHING = "-";
        public OutputEntityMetadata(EntityMetadata entityMetadata)
        {
            // エンティティメタデータの設定
            // 表示名
            DisplayName = entityMetadata.DisplayName.UserLocalizedLabel.Label;
            // 物理名
            LogicalName = entityMetadata.LogicalName;
            // スキーマ名
            SchemaName = entityMetadata.SchemaName;
            // カスタム/標準
            IsCustomEntity = Const.TranIsCustom[entityMetadata.IsCustomEntity];
            // 標準/活動
            IsActivity = Const.TranIsActivity[entityMetadata.IsActivity];
            // 企業形態
            OwnershipType = Const.TranOwnershipType[entityMetadata.OwnershipType.ToString()];
            // 業務プロセスフローの有無
            IsBusinessProcessEnabled = Const.TranPresenceAbsence[entityMetadata.IsBusinessProcessEnabled];
            // 活動が有効か
            var hasActivities = (bool)entityMetadata.HasActivities;
            // メモが有効か
            var hasNotes = (bool)entityMetadata.HasNotes;
            if (hasActivities)
            {
                if (hasNotes)
                {
                    HasActivitiesAndNotes = HAS_ACTIVITIES_AND_NOTES;
                }
                else
                {
                    HasActivitiesAndNotes = HAS_ACTIVITIES;
                }
            }
            else
            {
                if (hasNotes)
                {
                    HasActivitiesAndNotes = HAS_NOTES;
                }
                else
                {
                    HasActivitiesAndNotes = HAS_NOTHING;
                }
            }
        }

        public string DisplayName { get; set; }
        public string LogicalName { get; set; }
        public string SchemaName { get; set; }
        public string IsCustomEntity { get; set; }
        public string IsActivity { get; set; }
        public string OwnershipType { get; set; }
        public string IsBusinessProcessEnabled { get; set; }
        public string HasActivitiesAndNotes { get; set; }


    }
}