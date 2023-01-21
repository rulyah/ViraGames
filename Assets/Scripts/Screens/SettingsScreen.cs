using System;
using UnityEngine;
using UnityEngine.UI;

namespace Screens
{
    public class SettingsScreen : Screen
    {
        [SerializeField] private Button _godModeButton;
        [SerializeField] private Button _closeScreenButton;
        
        private readonly Color _turnedOff = Color.red;
        private readonly Color _turnedOn = Color.green;

        public event Action onClose;
        public event Action onGodModeClick; 

        public override void Show()
        {
            base.Show();
            _godModeButton.onClick.AddListener(OnGodModeClick);
            _closeScreenButton.onClick.AddListener(OnCloseClick);
        }

        public override void Hide()
        {
            _godModeButton.onClick.RemoveListener(OnGodModeClick);
            _closeScreenButton.onClick.RemoveListener(OnCloseClick);
            base.Hide();
        }

        public void SetGodMode(bool isOn)
        {
            _godModeButton.image.color = isOn ? _turnedOn : _turnedOff;
        }

        private void OnGodModeClick()
        {
            onGodModeClick?.Invoke();
        }

        private void OnCloseClick()
        {
            onClose?.Invoke();
        }
    }
}