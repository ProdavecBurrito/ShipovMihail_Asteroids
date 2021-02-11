using UnityEditor;
using System.Collections.Generic;
using UnityEngine;

namespace Shipov_NotAsteroidHW
{
    public class DictionarySurrogate : EditorWindow
    {
        private DictionaryToSerialize toSerialize;

        private void OnGUI()
        {
            GUILayout.Label("Словарь", EditorStyles.boldLabel);

            foreach (KeyValuePair<int, string> item in toSerialize.GetDictionary)
            {
                EditorGUILayout.IntField(item.Key);
                EditorGUILayout.TextArea(item.Value);
            }
        }
    }
}
