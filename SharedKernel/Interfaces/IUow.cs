using System;
using System.Collections.Generic;
using System.Text;

namespace SharedKernel.Interfaces
{
    public interface IUow : IDisposable
    {
        void Save();
    }
}
