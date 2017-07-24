using System;
using System.Collections.Generic;

namespace Manualfac
{
    class Disposer : Disposable
    {
        #region Please implements the following methods

        /*
         * The disposer is used for disposing all disposable items added when it is disposed.
         */
        readonly List<object> items = new List<object>();
        public void AddItemsToDispose(object item)
        {
            if(item == null) throw new ArgumentNullException(nameof(item));
            items.Add(item);
        }

        protected override void Dispose(bool disposing)
        {
            if(disposing)
            {
                items.ForEach(item =>
                {
                    var disposableItem = item as IDisposable;
                    disposableItem?.Dispose();
                });
            }
            base.Dispose(disposing);
        }

        #endregion
    }
}