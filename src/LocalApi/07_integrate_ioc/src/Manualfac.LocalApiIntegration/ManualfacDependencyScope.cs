using System;
using LocalApi;

namespace Manualfac.LocalApiIntegration
{
    class ManualfacDependencyScope : IDependencyScope
    {
        internal ManualfacDependencyScope(ILifetimeScope lifetimeScope)
        {
            LifeTimeScope = lifetimeScope;
        }

        ILifetimeScope LifeTimeScope { get; }

        #region Please implement the class

        /*
         * We should create a manualfac dependency scope so that we can integrate it
         * to LocalApi.
         * 
         * You can add a public/internal constructor and non-public fields if needed.
         */
        public void Dispose()
        {
           LifeTimeScope.Dispose();
        }

        public object GetService(Type type)
        {
            object resolved;
            LifeTimeScope.TryResolve(type, out resolved);
            return resolved;
        }

        #endregion
    }
}