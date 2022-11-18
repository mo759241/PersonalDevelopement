using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter08_Practice
{
    class Circle : TwoDShape
    {
        const double PI = 3.14;

        // デフォルトコンストラクタ
        public Circle() : base() { }

        // 直径がわかっているときのコンストラクタ
        public Circle(double width) : base(width, "Circle") { }

        // インスタンスをコピーするコンストラクタ
        public Circle(Circle circle) : base(circle) { }

        public override double Area()
        {
            return (Width / 2) * (Width / 2) * PI;
        }
    }
}
