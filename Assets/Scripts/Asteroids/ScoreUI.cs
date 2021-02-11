using UnityEngine;
using UnityEngine.UI;

namespace Shipov_Asteroids
{
    public sealed class ScoreUI
    {
        private float _currentScore = 0;
        private Canvas _scoreCanvas;
        private ScoreInterpretator _scoreInterpretator;

        private Text _scoreText;
        public Text CanvasText { get; private set; }

        public ScoreUI(Canvas canvas, ScoreInterpretator interpretator)
        {
            _scoreCanvas = canvas;
            _scoreText = _scoreCanvas.GetComponentInChildren<Text>();
            _scoreInterpretator = interpretator;
        }

        public void HideScore()
        {
            _scoreText.gameObject.SetActive(false);
        }

        public void ShowScore()
        {
            _scoreText.gameObject.SetActive(true);
        }

        public void AddScore(float value)
        {
            _currentScore += value;
            _scoreText.text = _currentScore.ToString();
            _scoreText.text = _scoreInterpretator.ConvertValue(_scoreText.text);
        }
    }
}
