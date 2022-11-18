using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter09_Practice
{
    interface IVehicle
    {
        /// <summary>
        /// 走行距離を計算
        /// </summary>
        /// <returns>int 走行距離</returns>
        int Range();

        /// <summary>
        /// 必要な燃料量を計算
        /// </summary>
        /// <returns>int 必要な燃料量</returns>
        double FuelNeeded();

        // 定員
        int Passengers { get; set; }
        // 燃料容量
        int FuelCap { get; set; }
        // 燃費
        int Mpg { get; set; }
    }
}
