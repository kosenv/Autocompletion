using Autocompletion.Core.Models;
using System.Collections.Generic;

namespace Autocompletion.Core.Interfaces
{
    public interface ISearcherAutocompletion
    {
        void UpdateData();

        IEnumerable<AutocompletionItem> SearchAutocompletion(string value);
    }
}
