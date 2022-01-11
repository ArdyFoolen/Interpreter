using System;

namespace PostfixInterpreter
{
    public interface Expression
    {
        int Interpret();
    }
}
