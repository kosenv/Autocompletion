using Autocompletion.Core.Interfaces;
using Autocompletion.Core.Models;
using System.Collections.Generic;
using System.Linq;

namespace Autocompletion.Searchers
{
    public class DictionarySearcher : ISearcherAutocompletion
    {
        private IDictionary<string, int> _dictionary;
        private readonly IDataProvider _dataProvider;

        public DictionarySearcher(IDataProvider dataProvider)
        {
            _dataProvider = dataProvider;
            UpdateData();
        }

        public void UpdateData()
        {
            _dictionary = _dataProvider.Data;
        }

        public IEnumerable<AutocompletionItem> SearchAutocompletion(string value)
        {
            return _dictionary?
                    .Where(d => d.Key.StartsWith(value))
                    .OrderByDescending(d => d.Value)
                    .Take(10)
                    .Select(d => new AutocompletionItem {
                        Word = d.Key,
                        Frequency = d.Value
                    })
                    .ToArray();
        }
    }
}
