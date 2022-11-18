using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter09_Practice
{
    // 文字用キューのインターフェース
    public interface ICharQ
    {
        // 1文字をキューに追加する
        void Put(char ch);

        // 1文字キューから取り出す
        char Get();
    }
}
