using UnityEditor;

namespace MergeSweetPals.Editor
{
    /// <summary>
    /// Utility class for deleting the EditorPrefs from within the editor.
    /// </summary>
    public class DeleteEditorPrefs
    {
        [MenuItem("Tools/Puzzle Match Kit/Delete EditorPrefs", false, 2)]
        public static void DeleteAllEditorPrefs()
        {
            EditorPrefs.DeleteAll();
        }
    }
}

