﻿using System;
using System.Threading;

namespace Manualfac
{
    // Since it is critical to get concrete value of whether the instance has been disposed.
    // We should make sure that the value should always be the latest while read from any
    // CPU core.
    // TODO: Ensure get latest value of IsDisposed.
    public class Disposable : IDisposable
    {
        const int HaveBeenDisposed = 1;
        int disposedStatus;

        public void Dispose()
        {
            var exchange = Interlocked.Exchange(ref disposedStatus, HaveBeenDisposed);
            if (HaveBeenDisposed == exchange)
            {
                return;
            }
            disposedStatus = HaveBeenDisposed;

            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
        }

        protected bool IsDisposed
        {
            get
            {
                Interlocked.MemoryBarrier();
                return disposedStatus == HaveBeenDisposed;
            }
        }
    }
}