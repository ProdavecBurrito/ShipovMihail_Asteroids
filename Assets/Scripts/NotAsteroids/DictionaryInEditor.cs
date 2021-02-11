using UnityEditor;

namespace Shipov_NotAsteroidHW
{
    public class DictionaryInEditor
    {
        [MenuItem("Dictionary/Словарь")]
        private static void ShowDictionary()
        {
            EditorWindow.GetWindow(typeof(DictionarySurrogate), false);
        }
    }
}
