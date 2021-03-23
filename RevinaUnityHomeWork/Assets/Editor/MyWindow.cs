using UnityEditor;
using UnityEngine;

namespace Geekbrains
{
    public class MyWindow : EditorWindow
    {
        //Create Boosters

        public static GameObject ObjectInstantiate;
        public static GameObject ObjectInstantiateTwo;
        public string _nameObject = "Test_Item_1";
        public string _nameTwoObject = "Test_Item_2";
        public bool _groupEnabled;
        public bool _randomColor = true;
        public int _countObject = 1;
        public float _radius = 10;

        private void OnGUI()
        {
            GUILayout.Label("Settings", EditorStyles.boldLabel);
            ObjectInstantiate = EditorGUILayout.ObjectField("Object", ObjectInstantiate, typeof(GameObject), true) as GameObject;
            ObjectInstantiateTwo = EditorGUILayout.ObjectField("Object", ObjectInstantiateTwo, typeof(GameObject), true) as GameObject;
            _nameObject = EditorGUILayout.TextField("Name", _nameObject);
            _nameTwoObject = EditorGUILayout.TextField("Name2", _nameTwoObject);
            _groupEnabled = EditorGUILayout.BeginToggleGroup("Advanced settings", _groupEnabled);
            _randomColor = EditorGUILayout.Toggle("Random color", _randomColor);
            _countObject = EditorGUILayout.IntSlider("Quantity objects", _countObject, 1, 20);
            _radius = EditorGUILayout.Slider("Radius", _radius, 5, 15);
            EditorGUILayout.EndToggleGroup();

            var button = GUILayout.Button("Create objects");
            if (button)
            {
                if (ObjectInstantiate & ObjectInstantiateTwo)
                {
                    GameObject root = new GameObject("TestingWindow");
                    for (int i = 0; i < _countObject; i++)
                    {
                        float angle = i * Mathf.PI * 2 / _countObject;
                        Vector3 pos = new Vector3(Mathf.Cos(angle), 0, Mathf.Sin(angle)) * _radius;
                        GameObject temp = Instantiate(ObjectInstantiate, pos, Quaternion.identity);
                        GameObject tempTwo = Instantiate(ObjectInstantiateTwo, pos, Quaternion.identity);
                        temp.name = _nameObject + "(" + i + ")";
                        tempTwo.name = _nameTwoObject + "(" + i + ")";
                        temp.transform.parent = root.transform;
                        var tempRenderer = temp.GetComponent<Renderer>();
                        if (tempRenderer && _randomColor)
                        {
                            tempRenderer.material.color = Random.ColorHSV();
                        }
                    }
                }
            }
        }
    }
}
