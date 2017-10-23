using Autocompletion.Core.Interfaces;
using System.Collections.Generic;
using System.IO;

namespace Autocompletion.DataProvider
{
    public class FileDataProvider : IDataProvider
    {
        private readonly string fileName;

        public IDictionary<string, int> Data => LoadData();

        public FileDataProvider(string fileName)
        {
            this.fileName = fileName;
        }

        private IDictionary<string, int> LoadData()
        {
            var result = new SortedDictionary<string, int>();
            var userInputs = new SortedDictionary<string, int>();

            if (!File.Exists(fileName))
                return result;

            using (var streamReader = new StreamReader(fileName))
            {
                if (!int.TryParse(streamReader.ReadLine(), out int wordCount))
                    return result;

                for (int i = 0; i < wordCount; i++)
                {
                    var line = streamReader.ReadLine().Split(' ');
                    var word = line[0];

                    if (!int.TryParse(line[1], out int frequency))
                        continue;

                    result.Add(word, frequency);
                }
                
                if (!int.TryParse(streamReader.ReadLine(), out int userInputCount))
                    return result;
                
                for (int i = 0; i < userInputCount; i++)
                {
                    var line = streamReader.ReadLine();
                    if (userInputs.ContainsKey(line))
                        userInputs[line]++;
                    else
                        userInputs.Add(line, 1);
                } 
            }

            foreach (var userInput in userInputs)
            {
                if (result.ContainsKey(userInput.Key))
                    result[userInput.Key] += userInput.Value;
                else
                    result.Add(userInput.Key, userInput.Value);
            }

            return result;
        }
    }
}
