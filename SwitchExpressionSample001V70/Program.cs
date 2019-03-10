using System;
using System.Collections.Generic;

namespace SwitchExpressionSample001V70
{
    /// <summary>
    /// Sample for C# 7.x
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            foreach (var shape in GetObjects())
            {
                Console.WriteLine(GetArea(shape));
            }
        }

        /// <summary>
        /// 依據不同形狀，設定不同面積計算方式 (在 C# 7.x 的寫法)
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        static double GetArea(object shape)
        {
            switch (shape)
            {
                case Rectangle r :
                    return r.Width * r.Height;
                case Circle c:
                    return Math.Pow(c.Radius, 2) * Math.PI;
                default:
                    return -1;
            }
        }



        /// <summary>
        /// 建立物件的集合
        /// </summary>
        /// <returns></returns>
        static List<object> GetObjects() =>
            new List<object>
            {
                new Rectangle { Width = 5, Height =5 },
                new Rectangle { Width = 15, Height =5 },
                new Circle { Radius = 6 },
                new Rectangle { Width = 5, Height =5 },
                new Circle { Radius = 10 },
            };
    }

    class Rectangle
    {
        public double Width { get; set; }
        public double Height { get; set; }
    }

    class Circle
    {
        public double Radius { get; set; }
    }
}
