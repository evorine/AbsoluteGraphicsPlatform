﻿using Castle.DynamicProxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace NextPlatform.Core
{
    public class ComponentInterceptor : IInterceptor
    {
        public void Intercept(IInvocation invocation)
        {
            invocation.Proceed();

            var property = getProperty(invocation.MethodInvocationTarget);
            var attribute = property?.CustomAttributes?.FirstOrDefault(x => x.AttributeType == typeof(ComponentPropertyAttribute));
            if (attribute != null)
            {
                var onChangeMethod = invocation.MethodInvocationTarget.DeclaringType.GetMethod("PropertyChanged", BindingFlags.NonPublic | BindingFlags.Instance);
                var value = property.GetValue(invocation.InvocationTarget);
                onChangeMethod.Invoke(invocation.InvocationTarget, new object[] { property, value });
            }
        }

        private PropertyInfo getProperty(MethodInfo setterMethod)
        {
            return setterMethod.DeclaringType.GetProperties()?.FirstOrDefault(x => x.SetMethod == setterMethod);
        }
    }
}