using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetaDataDocumentGenerator_UI
{
    public static class Const
    {
        readonly public static string[] NonOutputAttributeType = {
                                                                  "エンティティの名前",
                                                                  "関係者リスト",
                                                                  "マネージドプロパティ",
                                                                 };
        readonly public static Dictionary<bool?, string> TranIsActivity = new Dictionary<bool?, string>()
                                                                 {
                                                                     { true, "活動" } ,
                                                                     { false, "通常" }
                                                                 };
        readonly public static Dictionary<string, string> TranOwnershipType = new Dictionary<string, string>()
                                                                 {
                                                                     { "None", "-" } ,
                                                                     { "UserOwned", "ユーザーまたはチーム" } ,
                                                                     { "BusinessOwned", "部署" },
                                                                     { "OrganizationOwned", "組織" }
                                                                 };
        readonly public static Dictionary<string, string> TranRequiredLevel = new Dictionary<string, string>()
                                                                 {
                                                                     { "None", "任意" } ,
                                                                     { "Recommended","推奨" },
                                                                     { "ApplicationRequired", "必須" },
                                                                     { "SystemRequired", "システム要件" }
                                                                 };
        readonly public static Dictionary<string, string> TranDateTimeBehavior = new Dictionary<string, string>()
                                                                 {
                                                                     { "UserLocal", "ユーザーローカル" } ,
                                                                     { "DateOnly", "日付のみ" },
                                                                     { "TimeZoneIndependent", "タイムゾーン非依存" }
                                                                 };
        readonly public static Dictionary<int?, string> TranSourceType = new Dictionary<int?, string>()
                                                                 {
                                                                     { 0, null },
                                                                     { 1, "計算" },
                                                                     { 2,"ロールアップ"}
                                                                 };
        readonly public static Dictionary<bool?, string> TranYesNo = new Dictionary<bool?, string>()
                                                                 {
                                                                     { true, "はい" } ,
                                                                     { false, "いいえ" }
                                                                 };
        readonly public static Dictionary<bool?, string> TranPresenceAbsence = new Dictionary<bool?, string>()
                                                                 {
                                                                     { true, "あり" } ,
                                                                     { false, "なし" }
                                                                 };
        readonly public static Dictionary<bool?, string> TranValidInvalid = new Dictionary<bool?, string>()
                                                                 {
                                                                     { true, "有効" } ,
                                                                     { false, "無効" }
                                                                 };
        readonly public static Dictionary<string, string> TranImeMode = new Dictionary<string, string>()
                                                                 {
                                                                     { "Active", "アクティブ"} ,
                                                                     { "Inactive", "非アクティブ"},
                                                                     { "Disabled", "無効" },
                                                                     { "Auto","自動"}
                                                                 };
        readonly public static Dictionary<bool?, string> TranIsCustom = new Dictionary<bool?, string>()
                                                                 {
                                                                     { true, "カスタム"} ,
                                                                     { false, "標準"}
                                                                 };
        readonly public static Dictionary<int?, string> TranPrecisionSouce = new Dictionary<int?, string>()
                                                                 {
                                                                     { 0, "精度のプロパティ"} ,
                                                                     { 1, "価格の10進精度"},
                                                                     { 2, "通貨の精度"}
                                                                 };
        readonly public static Dictionary<string, string> TranAttributeType = new Dictionary<string, string>()
                                                                 {
                                                                     {"Text","テキスト"},
                                                                     {"TextArea","テキスト領域"},
                                                                     {"Email","メール"},
                                                                     {"Url","URL"},
                                                                     {"TickerSymbol","株式銘柄コード"},
                                                                     {"Phone","電話"},
                                                                     {"AutoNumber","オートナンバー"},
                                                                     {"Integer","整数"},
                                                                     {"Duration","期間"},
                                                                     {"TimeZone","タイムゾーン"},
                                                                     {"Language","言語"},
                                                                     {"DateAndTime","日時"},
                                                                     {"DateOnly","日付のみ"},
                                                                     {"Decimal","10進数"},
                                                                     {"Image","イメージ"},
                                                                     {"Boolean","はい/いいえ"},
                                                                     {"File","ファイル"},
                                                                     {"Customer","顧客"},
                                                                     {"Lookup","参照"},
                                                                     {"Picklist","選択肢"},
                                                                     {"MultiSelectPicklist","選択肢(複数)"},
                                                                     {"Money","通貨"},
                                                                     {"Double","浮動小数点数"},
                                                                     {"Memo","複数行テキスト"},
                                                                     {"Status","選択肢"},
                                                                     {"Uniqueidentifier","一意識別子"},
                                                                     {"EntityName","エンティティの名前"},
                                                                     {"BigInt","大きい整数"},
                                                                     {"State","選択肢"},
                                                                     {"Owner","所有者"},
                                                                     {"PartyList","関係者リスト"},
                                                                     {"CalendarRules","カレンダールール"},
                                                                     {"ManagedProperty","マネージドプロパティ"},
                                                                     {"Virtual","システムデータ"},
                                                                     {"String","-"},   // AttributeType="String"の場合は後続処理で書き換えられるが、例外回避のため暫定で"-"を設定
                                                                     {"DateTime","-"}, // AttributeType="DateTime"の場合は後続処理で書き換えられるが、例外回避のため暫定で"-"を設定
                                                                     {"Json","JSON"},
                                                                     {"PhoneticGuide","ルビ"},
                                                                     {"RichText","リッチテキスト"},
                                                                     {"VersionNumber","バージョン番号"},
                                                                 };
    }
}
