using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter08_Practice
{
    abstract class Shape
    {
        // コンストラクタ
        public Shape(int w, int h)
        {
            Width = w;
            Height = h;
        }

        // 幅
        public int Width { get; protected set; }
        // 高さ
        public int Height { get; protected set; }

        /// <summary>
        /// 面積計算メソッド
        /// </summary>
        /// <returns></returns>
        public abstract int CalArea();
    }
}
