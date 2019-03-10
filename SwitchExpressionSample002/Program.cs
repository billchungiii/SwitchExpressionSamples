using System;
using System.Collections.Generic;

namespace SwitchExpressionSample002
{
    class Program
    {
        /// <summary>
        /// Sample for switch expressions with when
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            foreach (var shape in GetObjects())
            {
                var result = GetArea(shape);
                if (result != null)
                {
                    Console.WriteLine(result);
                }
                else
                {
                    Console.WriteLine("this is null");
                }
            }
        }

        /// <summary>
        /// 依據不同形狀，並且寬高/半徑必須大於零，設定不同面積計算方式
        /// 在 vs2019 preview 4.1 svc1 的時候，不能直接回傳 null，必須是 new double?() 或 default(double?)
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        static double? GetArea(object shape) => shape switch
        {
            Rectangle r when r.Width > 0 && r.Height > 0 => r.Width * r.Height,
            Circle c when c.Radius > 0 => Math.Pow(c.Radius, 2) * Math.PI,
            _ => default(double?),            
        };


        static double?  Test()
        {
            return null;
        }

        /// <summary>
        /// 建立物件的集合
        /// </summary>
        /// <returns></returns>
        static List<object> GetObjects() =>
            new List<object>
            {
                new Rectangle {Width = 0, Height = 10},
                new Rectangle {Width = 10, Height = -1},
                new Circle { Radius = 0 },
                new Circle { Radius = -2 },
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
