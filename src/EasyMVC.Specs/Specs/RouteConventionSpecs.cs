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
using EasyMVC.Routing;
using Machine.Specifications;

namespace EasyMVC.Specs.Specs
{

    [Subject(typeof(RouteConventions), "given default conventions")]
    public class when_getting_information_for_list_action: DefaultConventionsSpecs
    {
        Because of = () =>
        {
            url = conventionRouting.GetRouteUrl(listAction);
            controller = conventionRouting.GetRouteController(listAction);
            action = conventionRouting.GetRouteAction(listAction);
            verb = conventionRouting.GetRouteConstraint(listAction);

        };

        It should_return_url_as_plural_of_controller = () => url.ShouldEqual("Employees");

        It should_return_controller_as_name_of_controller = () => controller.ShouldEqual("Employee");

        It should_return_action_list = () => action.ShouldEqual("List");

        It should_return_verb_as_get = () => verb.ShouldEqual(HttpVerbs.Get);


        static string url;
        static string controller;
        static string action;
        static HttpVerbs verb;
    }

    [Subject(typeof(RouteConventions), "given default conventions")]
    public class when_getting_information_for_details_action: DefaultConventionsSpecs
    {
        Because of = () =>
        {
            url = conventionRouting.GetRouteUrl(detailsAction);
            controller = conventionRouting.GetRouteController(detailsAction);
            action = conventionRouting.GetRouteAction(detailsAction);
            verb = conventionRouting.GetRouteConstraint(detailsAction);

        };

        It should_return_url_as_controller_with_id_parameter = () => url.ShouldEqual("Employee/{id}");

        It should_return_controller_as_name_of_controller = () => controller.ShouldEqual("Employee");

        It should_return_action_Details = () => action.ShouldEqual("Details");

        It should_return_verb_as_get = () => verb.ShouldEqual(HttpVerbs.Get);


        static string url;
        static string controller;
        static string action;
        static HttpVerbs verb;
    }

    [Subject(typeof(RouteConventions), "given default conventions")]
    public class when_getting_information_for_Edit_display_action : DefaultConventionsSpecs
    {
        Because of = () =>
        {
            url = conventionRouting.GetRouteUrl(editDisplayAction);
            controller = conventionRouting.GetRouteController(editDisplayAction);
            action = conventionRouting.GetRouteAction(editDisplayAction);
            verb = conventionRouting.GetRouteConstraint(editDisplayAction);

        };

        It should_return_url_as_controller_with_id_parameter = () => url.ShouldEqual("Employee/edit/{id}");

        It should_return_controller_as_name_of_controller = () => controller.ShouldEqual("Employee");

        It should_return_action_Edit = () => action.ShouldEqual("Edit");

        It should_return_verb_as_Get = () => verb.ShouldEqual(HttpVerbs.Get);


        static string url;
        static string controller;
        static string action;
        static HttpVerbs verb;
    }

    [Subject(typeof(RouteConventions), "given default conventions")]
    public class when_getting_information_for_edit_action: DefaultConventionsSpecs
    {
        Because of = () =>
        {
            url = conventionRouting.GetRouteUrl(editAction);
            controller = conventionRouting.GetRouteController(editAction);
            action = conventionRouting.GetRouteAction(editAction);
            verb = conventionRouting.GetRouteConstraint(editAction);

        };

        It should_return_url_as_controller_with_id_parameter = () => url.ShouldEqual("Employee/{id}");

        It should_return_controller_as_name_of_controller = () => controller.ShouldEqual("Employee");

        It should_return_action_Edit = () => action.ShouldEqual("Edit");

        It should_return_verb_as_Put = () => verb.ShouldEqual(HttpVerbs.Put);


        static string url;
        static string controller;
        static string action;
        static HttpVerbs verb;
    }

    [Subject(typeof(RouteConventions), "given default conventions")]
    public class when_getting_information_for_create_display_action: DefaultConventionsSpecs
    {
        Because of = () =>
        {
            url = conventionRouting.GetRouteUrl(createDisplayAction);
            controller = conventionRouting.GetRouteController(createDisplayAction);
            action = conventionRouting.GetRouteAction(createDisplayAction);
            verb = conventionRouting.GetRouteConstraint(createDisplayAction);

        };

        It should_return_url_as_controller_with_id_parameter = () => url.ShouldEqual("Employee/new");

        It should_return_controller_as_name_of_controller = () => controller.ShouldEqual("Employee");

        It should_return_action_Create = () => action.ShouldEqual("Create");

        It should_return_verb_as_Get = () => verb.ShouldEqual(HttpVerbs.Get);


        static string url;
        static string controller;
        static string action;
        static HttpVerbs verb;
    }

    [Subject(typeof(RouteConventions), "given default conventions")]
    public class when_getting_information_for_create_action: DefaultConventionsSpecs
    {
        Because of = () =>
        {
            url = conventionRouting.GetRouteUrl(createAction);
            controller = conventionRouting.GetRouteController(createAction);
            action = conventionRouting.GetRouteAction(createAction);
            verb = conventionRouting.GetRouteConstraint(createAction);

        };

        It should_return_url_as_controller = () => url.ShouldEqual("Employee");

        It should_return_controller_as_name_of_controller = () => controller.ShouldEqual("Employee");

        It should_return_action_Create = () => action.ShouldEqual("Create");

        It should_return_verb_as_Post = () => verb.ShouldEqual(HttpVerbs.Post);


        static string url;
        static string controller;
        static string action;
        static HttpVerbs verb;
    }

    [Subject(typeof(RouteConventions), "given default conventions")]
    public class when_getting_information_for_delete_action: DefaultConventionsSpecs
    {
        Because of = () =>
        {
            url = conventionRouting.GetRouteUrl(deleteAction);
            controller = conventionRouting.GetRouteController(deleteAction);
            action = conventionRouting.GetRouteAction(deleteAction);
            verb = conventionRouting.GetRouteConstraint(deleteAction);

        };

        It should_return_url_as_controller_with_id_parameter = () => url.ShouldEqual("Employee/{id}");

        It should_return_controller_as_name_of_controller = () => controller.ShouldEqual("Employee");

        It should_return_action_Delete = () => action.ShouldEqual("Delete");

        It should_return_verb_as_get = () => verb.ShouldEqual(HttpVerbs.Delete);


        static string url;
        static string controller;
        static string action;
        static HttpVerbs verb;
    }


    [Subject(typeof(RouteConventions), "given default conventions")]
    public class when_getting_url_for_non_existent_action: DefaultConventionsSpecs
    {
 
        Because of = () =>
        {

            nonExistentAction = new ActionInfo() { Controller = "Employee", Name = "DoesNotExist" };

            exception = Catch.Exception(() => conventionRouting.GetRouteUrl(nonExistentAction));
            
        };

        It should_return_mapping_not_found_exception = () => exception.ShouldBeOfType<MappingException>();

        It should_return_exception_message_with_controller_action_and_parameters = () => exception.Message.ShouldEqual(
            String.Format(
                "Mapping for {0}.{1} with {2} parameters not found. Make sure you have your Conventions correctly in place",
                nonExistentAction.Controller, nonExistentAction.Name, 0));

        It should_return_actionInfo_with_correct_controller_and_action = () =>
        {
            var actionInfo = ((MappingException) exception).ActionInfo;
            
            actionInfo.Name.ShouldEqual("DoesNotExist");
            actionInfo.Controller.ShouldEqual("Employee");
        };
        static Exception exception;
        static ActionInfo nonExistentAction;
    }

    [Subject(typeof(RouteConventions), "given default conventions")]
    public class when_getting_url_for_action_with_mismatched_parameters: DefaultConventionsSpecs
    {
 
        Because of = () =>
        {

            var nonExistentAction = new ActionInfo() { Controller = "Employee", Name = "Update" };

            exception = Catch.Exception(() => conventionRouting.GetRouteUrl(nonExistentAction));

        };

        It should_return_mapping_not_found_exception = () =>
        {
            exception.ShouldBeOfType(typeof(MappingException));

            var actionInfo = ((MappingException)exception).ActionInfo;

            actionInfo.Name.ShouldEqual("Update");
            actionInfo.Controller.ShouldEqual("Employee");
        };
        static Exception exception;
    }

    [Subject(typeof(RouteConventions), "given default conventions")]
    public class when_getting_url_for_action_with_three_mappings_of_same_action_name
    {

        Establish context = () =>
        {

            var conventions = new RouteConventions();

            conventions.MapAction("Edit").WithParameters(
                new List<ActionParam>() { new ActionParam() { IsComplexType = false, Name = "id" } }


                ).ToCustomUrl("/edit").ConstraintToVerb(HttpVerbs.Get);

            conventions.MapAction("Edit").WithParameters(
                new List<ActionParam>() { new ActionParam() { IsComplexType = false, Name = "date" } }


                ).ToCustomUrl("/edit").ConstraintToVerb(HttpVerbs.Get);

            conventions.MapAction("Edit").WithParameters(
                new List<ActionParam>()
                {
                    new ActionParam() { IsComplexType = false, Name = "id"},
                    new ActionParam() { IsComplexType = true, Name = "data"}
                }


                ).ToRoot().ConstraintToVerb(HttpVerbs.Put);

            action = new ActionInfo()
            {
                Controller = "Employee",
                Name = "Edit",
                Parameters = new List<ActionParam>()
                                                   {

                                                       new ActionParam() {Name = "date"}
                                                   }
            };


            routingConvention = new ConventionRouting(conventions);

        };
        Because of = () =>
        {
            url = routingConvention.GetRouteUrl(action);
        };

        
        It should_return_mapping_not_found_exception = () =>
        {
            url.ShouldEqual("Employee/edit/{date}");
        };
        static Exception exception;
        static string url;
        static ConventionRouting routingConvention;
        static ActionInfo action;
    }


    public class DefaultConventionsSpecs
    {
        Establish context = () =>
        {
            conventionRouting = new ConventionRouting(new DefaultRouteConventions());

            listAction = new ActionInfo() { Controller = "Employee", Name = "List" };

            detailsAction = new ActionInfo()
            {
                Controller = "Employee",
                Name = "Details",
                Parameters = new List<ActionParam>()
                                                                                                       {
                              
                                                                                                           new ActionParam() { Name = "id"}
                                                                                                       }
            };

            deleteAction = new ActionInfo()
            {
                Controller = "Employee",
                Name = "Delete",
                Parameters = new List<ActionParam>()
                                                                                                       {
                              
                                                                                                           new ActionParam() { Name = "id"}
                                                                                                       }
            };
            editDisplayAction = new ActionInfo()
            {
                Controller = "Employee",
                Name = "Edit",
                Parameters = new List<ActionParam>()
                                                   {

                                                       new ActionParam() {Name = "id"}
                                                   }
            };

            editAction = new ActionInfo()
            {
                Controller = "Employee",
                Name = "Edit",
                Parameters = new List<ActionParam>()
                                            {

                                                new ActionParam()
                                                {Name = "id", IsComplexType = false},
                                                new ActionParam()
                                                {Name = "data", IsComplexType = true}
                                                                                                      
                                            }
            };

            createDisplayAction = new ActionInfo()
            {
                Controller = "Employee",
                Name = "Create"
            };

            createAction = new ActionInfo()
            {
                Controller = "Employee",
                Name = "Create",
                Parameters = new List<ActionParam>()
                                            {

                                                new ActionParam()
                                                {Name = "data", IsComplexType = true}
                                                                                                      
                                            }
            };

        };

        protected static ConventionRouting conventionRouting;
        protected static ActionInfo listAction;
        protected static ActionInfo detailsAction;
        protected static ActionInfo editDisplayAction;
        protected static ActionInfo editAction;
        protected static ActionInfo createDisplayAction;
        protected static ActionInfo createAction;
        protected static ActionInfo deleteAction;
    }



}