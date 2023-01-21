using UnityEngine;

namespace Services.UserInput
{
    public abstract class InputSource : ScriptableObject
    {
        public abstract Vector2 GetMoveAxis();
    }
}