using UnityEditor;
using UnityEngine;

namespace Geekbrains
{
    [CustomEditor(typeof(MyScript))]
    public class TestBehaviourEditor : Editor
    {
        private bool _isPressButtonOk;

        public override void OnInspectorGUI()
        {
            // DrawDefaultInspector();
            MyScript testTarget = (MyScript)target;

            testTarget.count = EditorGUILayout.IntSlider(testTarget.count, 1, 5);
            testTarget.countTwo = EditorGUILayout.IntSlider(testTarget.countTwo, 1, 5);
            testTarget.offset = EditorGUILayout.IntSlider(testTarget.offset, 3, 8);

            testTarget.obj = EditorGUILayout.ObjectField("Object", testTarget.obj, typeof(GameObject), false) as GameObject;
            testTarget.objTwo = EditorGUILayout.ObjectField("Object", testTarget.objTwo, typeof(GameObject), false) as GameObject;

            var isPressButton = GUILayout.Button("Create object", EditorStyles.miniButtonLeft);

            _isPressButtonOk = GUILayout.Toggle(_isPressButtonOk, "Ok");

            if (isPressButton)
            {
                testTarget.CreateObj();
                _isPressButtonOk = true;
            }

            if (_isPressButtonOk)
            {
                testTarget.Test = EditorGUILayout.Slider(testTarget.Test, 10, 50);
                EditorGUILayout.HelpBox("You pressed button", MessageType.Warning);

                var isPressAddButton = GUILayout.Button("Add Component",
                   EditorStyles.miniButtonLeft);
                var isPressRemoveButton = GUILayout.Button("Remove Component",
                   EditorStyles.miniButtonLeft);
                if (isPressAddButton)
                {
                    testTarget.AddComponent();
                }
                if (isPressRemoveButton)
                {
                    testTarget.RemoveComponent();
                }
            }
        }
    }

}
