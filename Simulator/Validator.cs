using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Simulator;

public class Validator
{
    public static int Limiter(int value, int min, int max) 
    {
        if (value < min)
        {
            return min;
        }

        if (value > max)
        {
            return max;
        }

        return value;
    }

    public static string Shortener(string value)
    {
        value = value.Trim();

        if (value.Length > 25)
        {
            value = value.Substring(0, 25).TrimEnd();
        }

        if (value.Length < 3)
        {
            value = value.PadRight(3, '#');
        }

        if (char.IsLower(value[0]))
        {
            value = char.ToUpper(value[0]) + value.Substring(1);
        }

        return value;
    }
}
