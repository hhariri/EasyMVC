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
using System.Web.Mvc;
using EasyMVC.Infrastructure;
using EasyMVC.Specs.Helpers;
using EasyMVC.Specs.Helpers.SpecificNamespace;
using Machine.Specifications;

namespace EasyMVC.Specs.Specs
{
    [Subject(typeof(ActionFinder),"given controller")]
    public class when_getting_a_list_of_actions_and_controller_has_no_actions
    {
        Establish context = () =>
        {
            actionFinder = new ActionFinder();
            controllerList = new List<Type> { typeof(ActionlessController) };
        };

        Because of = () =>
        {

            actions = actionFinder.GetActions(controllerList);
        };

        It should_return_0_actions = () => actions.Count.ShouldEqual(0);

        static IList<ActionInfo> actions;
        static IActionFinder actionFinder;
        static List<Type> controllerList;
    }

    [Subject(typeof(ActionFinder), "given controller")]
    public class when_getting_a_list_of_actions_and_controller_has_actions 
    {
        Establish context = () =>
        {
            actionFinder = new ActionFinder();

            controllerList = new List<Type> { typeof(ActionController) };
        };

        Because of = () =>
        {

            actions = actionFinder.GetActions(controllerList);
        };

        It should_return_all_actions_of_the_controller = () =>
        {
            actions.Count.ShouldEqual(5);
            actions[0].Name.ShouldEqual("Create");
            actions[0].Verb.ShouldEqual(HttpVerbs.Get);
            actions[1].Name.ShouldEqual("Create");
            actions[1].Verb.ShouldEqual(HttpVerbs.Post);
            actions[2].Name.ShouldEqual("Delete");
            actions[2].Verb.ShouldEqual(HttpVerbs.Delete);
            actions[3].Name.ShouldEqual("Edit");
            actions[3].Verb.ShouldEqual(HttpVerbs.Get);
            actions[4].Name.ShouldEqual("Edit");
            actions[4].Verb.ShouldEqual(HttpVerbs.Put);
        };

        static IList<ActionInfo> actions;
        static IActionFinder actionFinder;
        static List<Type> controllerList;
    }

    [Subject(typeof(ActionFinder), "given controller")]
    public class when_getting_actions_with_a_complex_parameter
    {
        Establish context = () =>
        {
            actionFinder = new ActionFinder();

            controllerList = new List<Type> { typeof(ThirdController) };
        };

        Because of = () =>
        {
            actions = actionFinder.GetActions(controllerList);
        };

        It should_contains_a_list_of_parameters_with_IsComplexType_set_to_true_for_the_complex_parameter = () => actions[1].Parameters[0].IsComplexType.ShouldBeTrue();


        static IList<ActionInfo> actions;
        static IActionFinder actionFinder;
        static List<Type> controllerList;
    }

}