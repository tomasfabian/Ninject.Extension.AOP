﻿// #region License
// // 
// // Author: Tomas Fabian <fabian.frameworks@gmail.com>
// // Copyright (c) 2013, Fabian
// // 
// // Licensed under the Apache License, Version 2.0.
// // See the file LICENSE.txt for details.
// // 
using Castle.DynamicProxy;
using System;
using System.Linq.Expressions;
using System.Reflection;
using Ninject.Extensions.AOP.Aspects;
using Ninject.Extensions.AOP.Helpers;

namespace Ninject.Extensions.AOP.Selectors
{
    public class PropertyInterceptorSelector<T> : IAllowInterceptionSelector
    {
        private readonly string propertyName;

        public PropertyInterceptorSelector(Expression<Func<T, object>> propertyExpression)
        {
            this.propertyName = propertyExpression.GetPropertyName();
        }

        public IInterceptor[] SelectInterceptors(Type type, MethodInfo method, IInterceptor[] interceptors)
        {
            if (IsGetter(method))
            {
                return interceptors;
            }

            return InterceptionAspect.EmptyInterceptors;
        }

        private const string SetPrefix = "set_";

        private bool IsSetter(MethodInfo methodInfo)
        {
            return CheckProperty(methodInfo, SetPrefix);
        }

        private const string GetPrefix = "get_";

        private bool IsGetter(MethodInfo methodInfo)
        {
            return CheckProperty(methodInfo, GetPrefix);
        }

        private bool CheckProperty(MethodInfo methodInfo, string prefix)
        {
            return methodInfo.Name == (prefix + propertyName) && methodInfo.IsSpecialName && methodInfo.Name.StartsWith(prefix, StringComparison.Ordinal);
        }
    }
}
