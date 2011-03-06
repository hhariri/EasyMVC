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
using System.Reflection;
using EasyMVC.Infrastructure;
using Machine.Specifications;

namespace EasyMVC.Specs.Specs
{
    [Subject(typeof(ControllerFinder), "given assembly of controllers")]
    public class when_getting_all_controllers
    {
        Establish context = () =>
        {
            controllerFinder = new ControllerFinder(new DefaultControllerFinderConfiguration());
        };

        Because of = () =>
        {
            controllers = controllerFinder.GetControllers(Assembly.GetExecutingAssembly());
        };

        It should_return_all_controllers = () => { controllers.Count.ShouldEqual(5); };

        static IList<Type> controllers;
        static IControllerFinder controllerFinder;
    }

    [Subject(typeof(ControllerFinder), "given assembly of controllers")]
    public class when_getting_all_controllers_filtered_by_namespaces
    {
        Establish context = () =>
        {
            IControllerFinderConfiguration controllerFinderConfiguration = new DefaultControllerFinderConfiguration();

            controllerFinderConfiguration.Namespaces.Add("EasyMVC.Specs.Helpers.SpecificNamespace");

            controllerFinder = new ControllerFinder(controllerFinderConfiguration);
        };

        Because of = () =>
        {
            controllers = controllerFinder.GetControllers(Assembly.GetExecutingAssembly());
        };

        It should_return_only_controllers_of_the_specificed_namespaces = () => { controllers.Count.ShouldEqual(1); };

        static IList<Type> controllers;
        static IControllerFinder controllerFinder;
    }

    [Subject(typeof(ControllerFinder), "given assembly of controllers")]
    public class when_getting_all_controllers_filtered_by_controller_names
    {
        Establish context = () =>
        {
            IControllerFinderConfiguration controllerFinderConfiguration = new DefaultControllerFinderConfiguration();

            controllerFinderConfiguration.Controllers.Add("ConventionController");

            controllerFinder = new ControllerFinder(controllerFinderConfiguration);
        };

        Because of = () =>
        {
            controllers = controllerFinder.GetControllers(Assembly.GetExecutingAssembly());
        };

        It should_return_only_controllers_of_the_specificed_controllers = () => { controllers.Count.ShouldEqual(1); };

        static IList<Type> controllers;
        static IControllerFinder controllerFinder;
    }




}