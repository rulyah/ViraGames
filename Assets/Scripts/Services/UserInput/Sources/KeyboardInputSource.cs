using UnityEngine;

namespace Services.UserInput.Sources
{
    [CreateAssetMenu(fileName = "KeyboardInputSource", menuName = "Configs/Input/KeyboardInputSource")]
    public class KeyboardInputSource : InputSource
    {
        public override Vector2 GetMoveAxis()
        {
            return new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        }
    }
}