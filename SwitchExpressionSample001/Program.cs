using System;
using System.Collections.Generic;
using System.Drawing;

namespace SwitchExpressionSample001
{
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
        /// 依據不同形狀，設定不同面積計算方式
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        static double GetArea(object shape) => shape switch
        {
            Rectangle r   => r.Width * r.Height,            
            Circle c => Math.Pow(c.Radius, 2) * Math.PI,
            _ => -1,
        };



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
