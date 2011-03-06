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
using System.Collections.Specialized;
using System.IO;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace EasyMVC.Filters
{
	public class AutoRouteHandler : MvcRouteHandler
	{
		protected override System.Web.IHttpHandler GetHttpHandler(System.Web.Routing.RequestContext requestContext)
		{
			string action = requestContext.RouteData.GetRequiredString("action");
			string targetFormat;
			if (TryGetFormat(action, out targetFormat))
			{
				string url = requestContext.HttpContext.Request.Url.ToString().Replace("." + targetFormat, "");
				string querystring = ConvertDictionaryToString(requestContext.HttpContext.Request.QueryString);

				var context = new HttpContextWrapper(new HttpContext(new HttpRequest("", url, querystring), new HttpResponse(new StringWriter())));

				requestContext.RouteData = RouteTable.Routes.GetRouteData(context);
				requestContext.RouteData.Values.Add("format", targetFormat);
			}

			return base.GetHttpHandler(requestContext);
		}

		private string ConvertDictionaryToString(NameValueCollection queryString)
		{
			StringBuilder output = new StringBuilder();
			bool first = true;
			foreach (var item in queryString.AllKeys)
			{
				output.AppendFormat("{0}{1}={2}", first ? String.Empty : "&", item, queryString[item]);
				first = false;
			}
			return output.ToString();
		}

		private bool TryGetFormat(string controllerName, out string format)
		{
			int lastDotPosition = controllerName.LastIndexOf('.');
			if (lastDotPosition > -1)
			{
				format = controllerName.Substring(lastDotPosition + 1);
				return true;
			}

			format = String.Empty;
			return false;
		}


	}
}
