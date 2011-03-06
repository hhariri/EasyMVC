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

using System.Reflection;
using System.Web.Routing;
using EasyMVC.Infrastructure;
using EasyMVC.Routing;
using Machine.Specifications;

namespace EasyMVC.Specs.Specs
{
    [Subject(typeof(RouteGenerator), "given assembly")]
    public class when_generating_rest_routing_based_on_verbs
    {
        Establish context = () =>
        {
            routeGenerator = new RouteGenerator();

            routes = new RouteCollection();

            assembly = Assembly.GetExecutingAssembly();
        };

        Because of = () => routeGenerator.GenerateRoutesFromAssembly(assembly, routes);

        It should_return_routing_collection_with_rest_routes = () => routes.Count.ShouldEqual(13);

        static RouteCollection routes;
        static RouteGenerator routeGenerator;
        static Assembly assembly;

    }


    [Subject(typeof(RouteGenerator), "given assembly")]
    public class when_generating_rest_routing_based_on_verbs_filtered_by_namespaces
    {
        Establish context = () =>
        {
            IControllerFinderConfiguration controllerFinderConfiguration = new DefaultControllerFinderConfiguration();

            controllerFinderConfiguration.Namespaces.Add("EasyMVC.Specs.Helpers.SpecificNamespace");

            routes = new RouteCollection();

            routeGenerator = new RouteGenerator(new VerbRouting(), new ControllerFinder(controllerFinderConfiguration), new ActionFinder());

            assembly = Assembly.GetExecutingAssembly();
        };

        Because of = () => routeGenerator.GenerateRoutesFromAssembly(assembly, routes);

        It should_return_routing_collection_with_rest_routes = () => routes.Count.ShouldEqual(2);

        static RouteCollection routes;
        static RouteGenerator routeGenerator;
        static Assembly assembly;

    }

    [Subject(typeof(RouteGenerator), "given assembly")]
    public class when_generating_rest_routing_based_on_conventions
    {
        Establish context = () =>
        { 
            routes = new RouteCollection();

            routeGenerator = new RouteGenerator();

            
            assembly = Assembly.GetExecutingAssembly();
        };

        Because of = () => routeGenerator.GenerateRoutesFromAssembly(assembly, routes);

        It should_return_routing_collection_with_rest_routes = () => routes.Count.ShouldEqual(13);
 
        static RouteCollection routes;
        static RouteGenerator routeGenerator;
        static Assembly assembly;

    }


}