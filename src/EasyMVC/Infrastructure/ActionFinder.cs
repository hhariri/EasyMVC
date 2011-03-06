#region License
// Distributed under the BSD License
// =================================
// 
// Copyright (c) 2010-2011, Hadi Hariri and Project Contributors
// All rights reserved.
// 
// Redistribution and use in source and binary forms, with or without
// modification, are permitted provided that the following conditions are met:
//     * Redistributions of source code must retain the above copyright
//       notice, this list of conditions and the following disclaimer.
//     * Redistributions in binary form must reproduce the above copyright
//       notice, this list of conditions and the following disclaimer in the
//       documentation and/or other materials provided with the distribution.
//     * Neither the name of Hadi Hariri nor the
//       names of its contributors may be used to endorse or promote products
//       derived from this software without specific prior written permission.
// 
// THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS" AND
// ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE IMPLIED
// WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE
// DISCLAIMED. IN NO EVENT SHALL <COPYRIGHT HOLDER> BE LIABLE FOR ANY
// DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES
// (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES;
// LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND
// ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT
// (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE OF THIS
// SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.
// =============================================================
#endregion

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Web.Mvc;

namespace EasyMVC.Infrastructure
{
    public class ActionFinder : IActionFinder
    {
    
        static HttpVerbs GetActionVerbs(MethodInfo action)
        {
            if (action.GetCustomAttributes(typeof (HttpPostAttribute), false).Count() > 0)
            {
                return HttpVerbs.Post;
            }
            if (action.GetCustomAttributes(typeof (HttpDeleteAttribute), false).Count() > 0)
            {
                return HttpVerbs.Delete;
            }
            if (action.GetCustomAttributes(typeof (HttpPutAttribute), false).Count() > 0)
            {
                return HttpVerbs.Put;
            }
            return HttpVerbs.Get;
        }

        private static IList<ActionInfo> GetActions(Type controller)
        {
            MethodInfo[] methods = controller.GetMethods(BindingFlags.Public | BindingFlags.Instance);

            return methods.Where(
                m => m.ReturnType == typeof(ActionResult) || m.ReturnType.IsSubclassOf(typeof(ActionResult)))
                .Select(action => new ActionInfo
                {
                    Controller = controller.Name.Substring(0, controller.Name.IndexOf("Controller")),
                    Name = action.Name,
                    Parameters = action.GetParameters().Select(param => new ActionParam
                    {
                        Name = param.Name,
                        IsComplexType = !TypeDescriptor.
                          GetConverter(
                                     param.
                                         ParameterType)
                                 .CanConvertFrom(
                                     typeof(
                                         string))
                    }).ToList(),
                    Verb = GetActionVerbs(action)
                }).ToList();

        }

        public IList<ActionInfo> GetActions(IList<Type> controllers)
        {
            var actions = new List<ActionInfo>();

            foreach (var controller in controllers)
            {
                actions.AddRange(GetActions(controller));
            }

            return actions;

        }
    }
}