using UnityEngine;
using UnityEngine.UI;

namespace Shipov_Asteroids
{
    public sealed class ScoreUI
    {
        private Canvas _scoreCanvas;

        private Text _scoreText;
        public Text CanvasText { get; private set; }

        public ScoreUI(Canvas canvas)
        {
            _scoreCanvas = canvas;
            _scoreText = _scoreCanvas.GetComponentInChildren<Text>();
        }

        public void HideScore()
        {
            _scoreText.gameObject.SetActive(false);
        }

        public void ShowScore()
        {
            _scoreText.gameObject.SetActive(true);
        }
    }
}
