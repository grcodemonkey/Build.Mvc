﻿// -----------------------------------------------------------------------------
// Designed by geeks in Michigan.  Assembled by a compiler near you.
// -----------------------------------------------------------------------------
// 
// Copyright (c) 2011-2012 Jeremy Bell, Laurence Blackledge
// 
// Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:
// 
// The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
// 
// It is pitch black. You are likely to be eaten by a grue.
// 
using System;

namespace JetBrains.Annotations
{
    [AttributeUsage(AttributeTargets.Parameter)]
    internal class PathReferenceAttribute : Attribute
    {
        public PathReferenceAttribute()
        {
        }

        public PathReferenceAttribute([PathReference] string basePath)
        {
            BasePath = basePath;
        }

        public string BasePath { get; private set; }
    }

    [AttributeUsage(AttributeTargets.Parameter)]
    internal sealed class AspMvcModelTypeAttribute : Attribute
    {
    }

    [AttributeUsage(AttributeTargets.Parameter | AttributeTargets.Method)]
    internal sealed class AspMvcControllerAttribute : Attribute
    {
        public AspMvcControllerAttribute()
        {
        }

        public AspMvcControllerAttribute(string anonymousProperty)
        {
            AnonymousProperty = anonymousProperty;
        }

        public string AnonymousProperty { get; private set; }
    }

    [AttributeUsage(AttributeTargets.Parameter)]
    internal sealed class AspMvcMasterAttribute : Attribute
    {
    }

    [AttributeUsage(AttributeTargets.Parameter | AttributeTargets.Method)]
    internal sealed class AspMvcViewAttribute : PathReferenceAttribute
    {
    }

    [AttributeUsage(AttributeTargets.Parameter)]
    internal sealed class AspMvcAreaAttribute : PathReferenceAttribute
    {
        public AspMvcAreaAttribute()
        {
        }

        public AspMvcAreaAttribute(string anonymousProperty)
        {
            AnonymousProperty = anonymousProperty;
        }

        public string AnonymousProperty { get; private set; }
    }

    [AttributeUsage(AttributeTargets.Parameter | AttributeTargets.Method)]
    internal sealed class AspMvcActionAttribute : Attribute
    {
        public AspMvcActionAttribute()
        {
        }

        public AspMvcActionAttribute(string anonymousProperty)
        {
            AnonymousProperty = anonymousProperty;
        }

        public string AnonymousProperty { get; private set; }
    }

    [AttributeUsage(AttributeTargets.Parameter)]
    internal sealed class AspMvcTemplateAttribute : Attribute
    {
    }

}

/*
* Copyright 2007-2011 JetBrains s.r.o.
*
* Licensed under the Apache License, Version 2.0 (the "License");
* you may not use this file except in compliance with the License.
* You may obtain a copy of the License at
*
* http://www.apache.org/licenses/LICENSE-2.0
*
* Unless required by applicable law or agreed to in writing, software
* distributed under the License is distributed on an "AS IS" BASIS,
* WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
* See the License for the specific language governing permissions and
* limitations under the License.
*/