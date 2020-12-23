using System.Collections.Generic;
using System.Runtime.Serialization;
using UnityEngine;

public class DictionarySurrogate 
{

    
    private Dictionary<int, GameObject> _dictionary = new Dictionary<int, GameObject>();

    public Dictionary<int, GameObject> ShowDictionary => _dictionary;
}
