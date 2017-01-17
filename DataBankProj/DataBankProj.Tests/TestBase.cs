using System;
using System.IO;
using Ninject.MockingKernel.Moq;

namespace DataBankProj.Tests
{
    public abstract class TestBase : IDisposable
    {
        protected TestBase()
        {
            MockKernel = new MoqMockingKernel();
        }

        ~TestBase()
        {
            Dispose(false);
        }

        protected MoqMockingKernel MockKernel { get; }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                MockKernel.Dispose();
            }
        }
    }
}
