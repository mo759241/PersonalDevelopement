using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter09_Practice
{
    interface IFailSoft
    {
        // 配列の長さを返すメソッド
        int Length { get; }

        // インデクサ
        int this[int index] { get; set; }
    }
}
