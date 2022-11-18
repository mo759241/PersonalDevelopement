using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter08_Practice
{
    abstract class TwoDShape
    {
        double private_width;
        double private_height;


        // デフォルトコンストラクタ
        public TwoDShape()
        {
            Width = Height = 0.0;
            Name = null;
        }

        // 全情報を引数として受け取るコンストラクタ
        public TwoDShape(double width, double height, string name)
        {
            Width = width;
            Height = height;
            Name = name;
        }

        // 幅＝高さのときのコンストラクタ
        public TwoDShape(double width, string name)
        {
            Width = Height = width;
            Name = name;
        }

        // オブジェクトをコピーするコンストラクタ
        public TwoDShape(TwoDShape twoDShape)
        {
            Width = twoDShape.Width;
            Height = twoDShape.Height;
            Name = twoDShape.Name;
        }

        public double Width
        {
            get { return private_width; }
            // 絶対値を取得
            set { private_width = value < 0 ? -value : value; }
        }

        public double Height
        {
            get { return private_height; }
            // 絶対値を取得
            set { private_height = value < 0 ? -value : value; }
        }

        public string Name { get; set; }

        public void ShowDimension()
        {
            Console.WriteLine("Width  = " + Width);
            Console.WriteLine("Height = " + Height);
        }

        /// <summary>
        /// 幅と高さを使用して面積を計算する。
        /// </summary>
        /// <returns></returns>
        public abstract double Area();

    }
}
