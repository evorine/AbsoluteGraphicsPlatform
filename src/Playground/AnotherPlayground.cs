﻿using AbsoluteGraphicsPlatform.DSS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Playground
{
    public static class AnotherPlayground
    {
        public static void Play()
        {
            Expression<Func<DSSValue, DSSValue, DSSValue>> multiplyExpression = (left, right) => left * right;

            var v1 = new DSSValue(7);
            var v2 = new DSSValue(3);

            var eV1 = Expression.Constant(v1);
            var eV2 = Expression.Constant(v2);

            
            var invokeExpression = Expression.Invoke(multiplyExpression, eV1, eV2);
            var lambdaExpression = invokeExpression.Expression as LambdaExpression;

            var compiled = lambdaExpression.Compile();
            var args = invokeExpression.Arguments.Select(x => x is ConstantExpression constant ? constant.Value : x).ToArray();
            var result = compiled.DynamicInvoke(args);
        }
    }
}
