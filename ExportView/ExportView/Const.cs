using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExportView
{

    public static class Const
    {
        readonly public static Dictionary<string, string> TranViewType = new Dictionary<string, string>()
                                                                 {
                                                                     { "0", "共有ビュー" },
                                                                     { "1", "高度な検索ビュー" },
                                                                     { "2", "関連ビュー"},
                                                                     { "4", "簡易検索ビュー"},
                                                                     { "64", "検索ダイアログビュー"},
                                                                     { "-", "-"}
                                                                 };
    }

}
