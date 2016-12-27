using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake_Csharp
{
    abstract class IModule
    {
        public abstract void Init();
        public abstract void Update();
        public abstract void Destroy();
    }

    class CModule : IModule, IDisposable
    {
        public override void Init()
        {
            throw new NotImplementedException();
        }
        public override void Update()
        {
            throw new NotImplementedException();
        }
        public override void Destroy()
        {
            Dispose();
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                // Free other state (managed objects).
            }
            // Free your own state (unmanaged objects).
            // Set large fields to null.
        }
        ~CModule()
        {
            Dispose(false);
        }
        // Use C# destructor syntax for finalization code.
    }
}
