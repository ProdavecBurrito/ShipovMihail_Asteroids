using System.Collections.Generic;
using UnityEditor;

namespace Shipov_NotAsteroidHW
{
    public class DictionaryToSerialize : Editor
    {
        private Dictionary<int, string> _dictionary = new Dictionary<int, string>()
        {
            { 1, "Kek" },
            { 2, "Lel" }
        };


        public Dictionary<int, string> GetDictionary => _dictionary;
    }
}
