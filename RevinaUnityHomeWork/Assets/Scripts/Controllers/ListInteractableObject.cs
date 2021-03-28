using System;
using System.Collections;
using Object = UnityEngine.Object;

namespace Geekbrains
{
    public class ListInteractableObject : IEnumerator, IEnumerable
    {
        private InteractiveObjects[] _interactiveObjects;
        private int _index = -1;
        private InteractiveObjects _current;

        public ListInteractableObject()
        {
            _interactiveObjects = Object.FindObjectsOfType<InteractiveObjects>();
        }

        public InteractiveObjects this[int index]
        {
            get => _interactiveObjects[index];
            set => _interactiveObjects[index] = value;
        }

        public int Length => _interactiveObjects.Length;

        public bool MoveNext()
        {
            if (_index == _interactiveObjects.Length -1)
            {
                Reset();
                return false;
            }
            _index++;
            return true;
        }

        public void Reset() => _index = -1;

        public IEnumerator GetEnumerator()
        {
            return this;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }


        public object Current => _interactiveObjects[_index];
    }
}