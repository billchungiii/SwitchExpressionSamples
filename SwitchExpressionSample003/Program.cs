using System;
using System.Collections.Generic;

namespace SwitchExpressionSample003
{
    /// <summary>
    /// Sample for switch expression with tuple pattern
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            foreach (var item in CreateList ())
            {
                Console.WriteLine(Eat(item.Item1 , item.Item2));
            }
        }


        static List<ValueTuple<Role, Role>> CreateList() => new List<(Role, Role)>
        {
            (Role.狼, Role.羊),
            (Role.狼, Role.大白菜),
            (Role.狼, Role.農夫),
            (Role.農夫, Role.羊),
            (Role.農夫, Role.大白菜),
            (Role.農夫, Role.狼),
            (Role.羊, Role.農夫),
            (Role.羊, Role.大白菜),
            (Role.羊, Role.狼),
        };

        static bool Eat(Role role1, Role role2) => (role1, role2) switch
        {
            (Role.狼, Role.羊) => true,
            (Role.羊, Role.狼) => true,
            (Role.羊, Role.大白菜) => true,
            (Role.大白菜, Role.羊) => true,
            (_, _) => false
        };
    }

    public enum Role
    {
        農夫,
        狼,
        羊,
        大白菜
    }
}
