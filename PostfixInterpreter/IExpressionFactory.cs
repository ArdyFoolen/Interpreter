﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostfixInterpreter
{
    public interface IExpressionFactory
    {
        Expression Create(Expression first, Expression second);
    }
}
