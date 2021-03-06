﻿using System;
using System.Collections.Generic;

namespace SwitchExpressionSample005
{
    /// <summary>
    /// Sample for switch expression with property pattern
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {


            foreach (var item in CreateList())
            {
                try
                {
                    Console.WriteLine(Calculate(item));
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        static double Calculate(Expression expression) => expression switch
        {

            { Operand: "+", X: var x, Y: var y } => x + y,
            { Operand: "-", X: var x, Y: var y } => x - y,
            { Operand: "*", X: var x, Y: var y } => x * y,
            { Operand: "/", Y: 0 } => double.NaN,
            { Operand: "/", X: var x, Y: var y } => x / y,
            { Operand: _ } => throw new ArgumentException("Operand should be one of +,-,*,/")
        };

        static List<Expression> CreateList() =>
            new List<Expression>
            {
                new Expression ("+", 1, 2.3),
                new Expression ("-", 14.5, 0.1),
                new Expression ("*", 8, 1.5),
                new Expression ("/", 9, 2),
                new Expression ("/", 10, 0),
                new Expression ("NotOperand", 10, 10),
            };
    }

    class Expression
    {
        public Expression(string operand, double x, double y)
        {
            Operand = operand;
            X = x;
            Y = y;
        }
        public string Operand { get; }
        public double X { get; }
        public double Y { get; }
    }
}
