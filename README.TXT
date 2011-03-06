Distributed under BSD License. See LICENSE.TXT for full license

[PLEASE NOTE THAT THIS HAS NOT BEEN TESTED IN FULL PRODUCTION YET. USE AT YOUR OWN WILL. IT'S STILL EVOLVING]


EasyMVC


Add some ReST flavors to MVC Applications:

Currently Support:

- Routing Based on Verbs

	Just Decorate your Actions with Verbs and use the VerbRouting to create your routes 

- Routing Based on Conventions

	Create conventions (or use Default ones) and use the ConventionRouting to create your routes

	Default Conventions are:

        public DefaultRouteConventions()
        {

            MapAction("List").ToRootPlural().ConstraintToVerb(HttpVerbs.Get);

            MapAction("Details").WithParameters(
                new List<ActionParam>() { new ActionParam() { IsComplexType = false, Name = "id" } }


                ).ToRoot().ConstraintToVerb(HttpVerbs.Get);

            MapAction("Delete").WithParameters(
                new List<ActionParam>() { new ActionParam() { IsComplexType = false, Name = "id" } }


                ).ToRoot().ConstraintToVerb(HttpVerbs.Delete);

            MapAction("Update").WithParameters(
                new List<ActionParam>() { new ActionParam() { IsComplexType = false, Name = "id" } }


                ).ToCustomUrl("/edit").ConstraintToVerb(HttpVerbs.Get);

            MapAction("Update").WithParameters(
                new List<ActionParam>()
                {
                    new ActionParam() { IsComplexType = false, Name = "id"},
                    new ActionParam() { IsComplexType = true, Name = "data"}
                }


                ).ToRoot().ConstraintToVerb(HttpVerbs.Put);

            MapAction("Create").WithNoParameters().ToCustomUrl("/new").ConstraintToVerb(HttpVerbs.Get);

            MapAction("Create").WithParameters(new List<ActionParam>()
                {
                    new ActionParam() { IsComplexType = true, Name = "data"}
                }).ToRoot().ConstraintToVerb(HttpVerbs.Post);
  
        }

- Controller Parsing

     You auto-route all controllers, based on namespaces or specific controllers (Pass in a ControllerParsingConfiguration)


Issue tracker is: http://youtrack.codebetter.com/issues/AREST



Generate ReST routes for your MVC Application automatically.

Create your controllers and set the correct verbs. Call the following in your RegisterRoutes:


            var routing ==> Either VerbRouting() or ConventionRouting()

            var routeGenerator = new RouteGenerator(routing);

            routeGenerator.GenerateRoutesFromAssemblyAssembly.GetExecutingAssembly(), routes));


like so:

        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

         
            var routeGenerator = new RestRouteGenerator();

            routeGenerator.GenerateRoutesFromAssemblyAssembly.GetExecutingAssembly(), routes));

            routes.MapRoute(
                "Default", // Route name
                "{controller}/{action}/{id}", // URL with parameters
                new { controller = "Home", action = "Index", id = UrlParameter.Optional } // Parameter defaults
            );
        }
      


AutoReST will do the rest (no pun intended)

You can now access your controllers use GET, PUT, DELETE, POST without any manual mapping.

