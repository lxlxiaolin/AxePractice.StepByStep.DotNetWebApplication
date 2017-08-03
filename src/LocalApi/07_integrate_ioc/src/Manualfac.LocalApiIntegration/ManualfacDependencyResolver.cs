using System;
using LocalApi;

namespace Manualfac.LocalApiIntegration
{
    public class ManualfacDependencyResolver : IDependencyResolver
    {
        #region Please implement the following class

        /*
         * We should create a manualfac dependency resolver so that we can integrate it
         * to LocalApi.
         * 
         * You can add a public/internal constructor and non-public fields if needed.
         */

        public ManualfacDependencyResolver(Container rootScope)
        {
            Container = rootScope;
        }

        Container Container { get; }

        public void Dispose()
        {
            Container.Dispose();
        }

        public object GetService(Type type)
        {
            object resolved;
            Container.TryResolve(type, out resolved);
            return resolved;
        }

        public IDependencyScope BeginScope()
        {
            return new ManualfacDependencyScope(Container.BeginLifetimeScope());
        }

        #endregion
    }
}