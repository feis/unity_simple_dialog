using UnityEngine;
using UnityEditor;
using UnityEditorInternal;

[CustomEditor(typeof(DialogMessageDataWithCustomEditor))]
public class DialogMessageDataCustomEditor : Editor
{
    private ReorderableList _reorderableList;

    private void OnEnable()
    {
        _reorderableList =
            new ReorderableList(
                serializedObject,
                serializedObject.FindProperty("Messages"))
            {
                drawHeaderCallback =
                    (rect) => {
                        EditorGUI.LabelField(rect, "Messages");
                    },

                drawElementCallback =
                    (rect, index, isActive, isFocused) =>
                    {
                        var element =
                            _reorderableList
                                .serializedProperty
                                .GetArrayElementAtIndex(index);

                        EditorGUI.PropertyField(
                            new Rect(
                                rect.x,
                                rect.y,
                                400,
                                EditorGUI.GetPropertyHeight(element, true)),
                            element,
                            GUIContent.none);
                    }
            };
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();
        _reorderableList.DoLayoutList();
        serializedObject.ApplyModifiedProperties();
    }
}
