using System;
using UnityEngine;
using UnityEngine.UI;
using Screen = Screens.Screen;

namespace UI
{
    public class PauseScreen : Screen
    {
        [SerializeField] private Button _continueButton;
        [SerializeField] private Button _menuButton;

        public event Action onContinueClick;
        public event Action onMenuClick;
        public override void Show()
        {
            _continueButton.onClick.AddListener(OnContinueClick);
            _menuButton.onClick.AddListener(OnMenuClick);
            base.Show();
        }

        public override void Hide()
        {
            _continueButton.onClick.RemoveListener(OnContinueClick);
            _menuButton.onClick.RemoveListener(OnMenuClick);
            base.Hide();
        }

        private void OnContinueClick()
        {
            onContinueClick?.Invoke();
        }

        private void OnMenuClick()
        {
            onMenuClick?.Invoke();
        }
    }
}