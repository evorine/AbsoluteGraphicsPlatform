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
    public class ComponentHook : IProxyGenerationHook
    {
        private PropertyInfo getProperty(MethodInfo setterMethod)
        {
            return setterMethod.DeclaringType.GetProperties()?.FirstOrDefault(x => x.SetMethod == setterMethod);
        }

        public bool ShouldInterceptMethod(Type type, MethodInfo methodInfo)
        {
            var property = getProperty(methodInfo);
            var attribute = property?.CustomAttributes?.FirstOrDefault(x => x.AttributeType == typeof(ComponentPropertyAttribute));
            return attribute != null;
        }

        public void NonProxyableMemberNotification(Type type, MemberInfo memberInfo)
        {
        }

        public void MethodsInspected()
        {
        }
    }
}
