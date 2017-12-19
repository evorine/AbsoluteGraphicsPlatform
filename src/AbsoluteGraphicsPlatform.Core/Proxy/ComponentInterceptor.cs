// Licensed under the MIT license.
// See the LICENSE file in the project root for more information.

using Castle.DynamicProxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace AbsoluteGraphicsPlatform.Proxy
{
    public class ComponentInterceptor : IInterceptor
    {
        public void Intercept(IInvocation invocation)
        {
            invocation.Proceed();

            var property = getProperty(invocation.MethodInvocationTarget);
            var onChangeMethod = invocation.MethodInvocationTarget.DeclaringType.GetMethod("PropertyChanged", BindingFlags.NonPublic | BindingFlags.Instance);
            var value = property.GetValue(invocation.InvocationTarget);
            onChangeMethod.Invoke(invocation.InvocationTarget, new object[] { property, value });
        }

        private PropertyInfo getProperty(MethodInfo setterMethod)
        {
            return setterMethod.DeclaringType.GetProperties()?.FirstOrDefault(x => x.SetMethod == setterMethod);
        }
    }
}
