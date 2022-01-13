using System;

namespace RomanInterpreter
{
    public enum RomanEnum
    {
        Undefined,
        I = 1,
        V = 5,
        X = 10,
        L = 50,
        C = 100,
        D = 500,
        M = 1000
    }

    internal enum RomanOneEnum
    {
        I = 1,
        X = 10,
        C = 100,
        M = 1000
    }

    internal enum RomanFiveEnum
    {
        V = 5,
        L = 50,
        D = 500,
    }

    public interface IRoman
    {
        bool IsSmaller(INumberRoman roman);
        int Interpret();
    }
}
