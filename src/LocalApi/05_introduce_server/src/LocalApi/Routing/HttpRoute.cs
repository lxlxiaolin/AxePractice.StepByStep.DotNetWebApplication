using System;
using System.CodeDom.Compiler;
using System.Net.Http;
using Microsoft.CSharp;

namespace LocalApi.Routing
{
    public class HttpRoute
    {
        public HttpRoute(string controllerName, string actionName, HttpMethod methodConstraint) : 
            this(controllerName, actionName, methodConstraint, null)
        {
        }

        #region Please modifies the following code to pass the test

        /*
         * You can add non-public helper method for help, but you cannot change public
         * interfaces.
         */

        public HttpRoute(string controllerName, string actionName, HttpMethod methodConstraint, string uriTemplate)
        {
            if(controllerName == null) { throw new ArgumentNullException(nameof(controllerName)); }
            if(actionName == null) { throw new ArgumentNullException(nameof(actionName)); }
            if(methodConstraint == null) { throw new ArgumentNullException(nameof(methodConstraint)); }
            if(uriTemplate == null) { throw new ArgumentException(nameof(controllerName)); }

            CodeDomProvider provider = new CSharpCodeProvider();
            if(!provider.IsValidIdentifier(controllerName))
            {
                throw new ArgumentException();
            }
            if(!provider.IsValidIdentifier(actionName))
            {
                throw new ArgumentException();
            }
            ControllerName = controllerName;
            ActionName = actionName;
            MethodConstraint = methodConstraint;
            UriTemplate = uriTemplate;
        }

        #endregion

        public string ControllerName { get; }
        public string ActionName { get; }
        public HttpMethod MethodConstraint { get; }
        public string UriTemplate { get; }

        public bool IsMatch(Uri uri, HttpMethod method)
        {
            if (uri == null) { throw new ArgumentNullException(nameof(uri)); }
            if (method == null) { throw new ArgumentNullException(nameof(method)); }
            string path = uri.AbsolutePath.TrimStart('/');
            return path.Equals(UriTemplate, StringComparison.OrdinalIgnoreCase) &&
                   method == MethodConstraint;
        }
    }
}