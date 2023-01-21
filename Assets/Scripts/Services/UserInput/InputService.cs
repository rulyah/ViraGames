using UnityEngine;

namespace Services.UserInput
{
    public class InputService : MonoBehaviour
    {
        [SerializeField] private InputSource[] _sources;

        private int _activeSourceIndex;
        public InputSource activeSource => _sources[_activeSourceIndex];

        public void SelectInputSource<T>() where T : InputSource
        {
            for (int i = 0; i < _sources.Length; i++)
            {
                if (_sources[i] is T)
                {
                    _activeSourceIndex = i;
                    return;
                }
            }
        }
    }
}