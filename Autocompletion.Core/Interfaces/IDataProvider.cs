using System;
using System.Collections.Generic;
using System.Text;

namespace Autocompletion.Core.Interfaces
{
    public interface IDataProvider
    {
        IDictionary<string, int> Data { get; }
    }
}
