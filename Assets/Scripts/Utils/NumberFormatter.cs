using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumberFormatter
{
    private static char REGEX = ',';

    public string ChangeNumberFormat(int number)
    {
        return ChangeNumberFormat((long) number);
    }

    public string ChangeNumberFormat(string number)
    {
        return ChangeNumberFormat(long.Parse(number));
    }

    public string ChangeNumberFormat(long number)
    {
        string result = string.Empty;
        char[] num = Reverse(number.ToString().ToCharArray());

        for (int i = 0; i < num.Length; i++)
        {
            result += num[i];

            if (i % 3 == 2 && i != num.Length - 1)
            {
                result += REGEX;
            }
        }

        return new string(Reverse(result.ToCharArray()));
    }

    public long ChangeFormatToLong(string text)
    {
        string result = "";
        string[] values = text.Split(',');

        for (int i = 0; i < values.Length; i++)
        {
            result += values[i];
        }

        return long.Parse(result);
    }

    private char[] Reverse(char[] c)
    {
        char[] result = new char[c.Length];

        for (int i = c.Length - 1; i >= 0; i--)
        {
            result[c.Length - 1 - i] = c[i];
        }

        return result;
    }
}