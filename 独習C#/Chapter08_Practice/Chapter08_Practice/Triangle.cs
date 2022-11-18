using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter08_Practice
{
    class Triangle : TwoDShape
    {
        string Style { get; set; }

        // デフォルトコンストラクタ
        public Triangle()
        {
            Style = "null";
        }

        // スタイル、幅、高さを引数に持つコンストラクタ
        public Triangle(string style, double width, double height) : base(width, height, "Triangle")
        {
            Style = style;
        }

        // 幅＝高さの場合のコンストラクタ
        public Triangle(double width) : base(width, "Triangle")
        {
            Style = "isosceles";
        }

        // インスタンスをコピーするコンストラクタ
        public Triangle(Triangle triangle) : base(triangle)
        {
            Style = triangle.Style;
        }

        public override double Area()
        {
            return Width * Height / 2;
        }

        public void ShowStyle(string style)
        {
            Console.WriteLine("Triangle is " + style);
        }
    }
}
