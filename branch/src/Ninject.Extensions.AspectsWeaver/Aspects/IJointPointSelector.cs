﻿// #region License
// // 
// // Author: Tomas Fabian <fabian.frameworks@gmail.com>
// // Copyright (c) 2013, Tomas Fabian
// // 
// // Licensed under the Apache License, Version 2.0.
// // See the file LICENSE.txt for details.
// // 

using System;

namespace Ninject.Extensions.AspectsWeaver.Aspects
{
    public interface IJointPointSelector
    {
        bool IsJointPoint(Type type, System.Reflection.MethodInfo method);
    }
}