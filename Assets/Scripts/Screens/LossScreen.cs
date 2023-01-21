using System;
using UnityEngine;
using UnityEngine.UI;

namespace Screens
{
    public class LossScreen : Screen
    {
        [SerializeField] private Button _restartButton;

        public event Action onRestart;
        
        public override void Show()
        {
            base.Show();
            _restartButton.onClick.AddListener(OnRestartClick);
        }

        public override void Hide()
        {
            _restartButton.onClick.RemoveListener(OnRestartClick);
            base.Hide();
        }

        private void OnRestartClick()
        {
            onRestart?.Invoke();
        }
    }
}