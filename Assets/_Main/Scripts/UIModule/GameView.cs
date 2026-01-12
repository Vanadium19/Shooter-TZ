using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UIModule
{
    public class GameView : MonoBehaviour
    {
        private const string WinText = "WIN!";
        private const string LoseText = "LOSE!";

        [SerializeField] private Button exitButton;
        [SerializeField] private Button restartButton;

        [SerializeField] private GameObject panel;
        [SerializeField] private TMP_Text result;
        [SerializeField] private Image background;

        [SerializeField] private Color winColor;
        [SerializeField] private Color loseColor;

        public event Action Restarted;
        public event Action Exited;

        private void OnEnable()
        {
            exitButton.onClick.AddListener(OnExitButtonClicked);
            restartButton.onClick.AddListener(OnRestartButtonClicked);
        }

        private void OnDisable()
        {
            exitButton.onClick.RemoveListener(OnExitButtonClicked);
            restartButton.onClick.RemoveListener(OnRestartButtonClicked);
        }

        public void ShowPanel(bool won)
        {
            panel.SetActive(true);
            background.color = won ? winColor : loseColor;
            result.text = won ? WinText : LoseText;
        }

        private void OnExitButtonClicked()
        {
            Exited?.Invoke();
        }

        private void OnRestartButtonClicked()
        {
            panel.SetActive(false);
            Restarted?.Invoke();
        }
    }
}