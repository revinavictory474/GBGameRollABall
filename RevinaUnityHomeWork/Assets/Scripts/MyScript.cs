using UnityEngine;

namespace Geekbrains
{
    public class MyScript : MonoBehaviour
    {
        public int offset = 3;
        public GameObject obj;
        public int count = 10;
        public GameObject objTwo;
        public int countTwo = 10;

        public float Test;
        private Transform _root;
        private Transform _rootTwo;

        private void Start()
        {
            CreateObj();
        }

        public void CreateObj()
        {
            _root = new GameObject("Root").transform;
            for (var i = 1; i <= count; i++)
            {
                Instantiate(obj, new Vector3(offset * i, 0, Random.Range(5,35)), Quaternion.identity, _root);

            }
            _rootTwo = new GameObject("RootTwo").transform;
            for (var j = 1; j <= countTwo; j++)
            {
                Instantiate(objTwo, new Vector3(Random.Range(5, 35), 0, offset * j), Quaternion.identity, _rootTwo);
            }

        }

        public void AddComponent()
        {
            gameObject.AddComponent<Rigidbody>();
            gameObject.AddComponent<MeshRenderer>();
            gameObject.AddComponent<BoxCollider>();
        }

        public void RemoveComponent()
        {
            DestroyImmediate(GetComponent<Rigidbody>());
            DestroyImmediate(GetComponent<MeshRenderer>());
            DestroyImmediate(GetComponent<BoxCollider>());
        }
    }

}
