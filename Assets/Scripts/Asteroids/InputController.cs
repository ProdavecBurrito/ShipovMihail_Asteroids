using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Shipov_Asteroids
{
    internal sealed class InputController : IUpdate
    {
        private const float SCORE_VALUE = 100000.0f;

        private Ship _ship;
        private GameObject _playerPrefab;
        private Camera _camera;
        private ScoreUI _scoreText;

        private ICommand<ScoreUI> _tabKey;
        private ICommand<ScoreUI> _QKey;
        private List<ICommand<Text>> oldCommands = new List<ICommand<Text>>();

        private float _vertical;
        private float _horizontal;

        private KeyCode _addScore = KeyCode.E;
        private KeyCode _doNothingKey = KeyCode.Q;
        private KeyCode _scoreKey = KeyCode.Tab;
        private KeyCode _shootKey = KeyCode.Mouse0;
        private KeyCode _speedUpKey = KeyCode.LeftShift;

        public InputController(GameObject playerPrefab, Camera camera, Ship ship, ScoreUI text)
        {
            _tabKey = new ShowScore();
            _QKey = new DoNothing();
            _playerPrefab = playerPrefab;
            _camera = camera;
            _ship = ship;
            _scoreText = text;
        }

        public void UpdateTick()
        {
            Motion();
            Shoot();
            SpeedUP();
            DoNothing();
            ShowScore();
            ChangeScore();
        }

        private void DoNothing()
        {
            if(Input.GetKeyDown(_doNothingKey))
            {
                _QKey.Execute(_scoreText); // пустышка
            }
        }

        private void ShowScore()
        {
            if (Input.GetKeyDown(_scoreKey))
            {
                _tabKey.Execute(_scoreText);
            }
        }

        private void Shoot()
        {
            if (Input.GetKeyDown(_shootKey))
            {
                _ship.Shoot();
            }
        }

        private void Motion()
        {
            _vertical = Input.GetAxis("Vertical");
            _horizontal = Input.GetAxis("Horizontal");

            _ship.Move(_vertical, _horizontal, Time.deltaTime);

            var direction = Input.mousePosition - _camera.WorldToScreenPoint(_playerPrefab.transform.position);
            _ship.Rotation(direction);
        }

        private void SpeedUP()
        {
            if (Input.GetKeyDown(_speedUpKey))
            {
                _ship.AddAcceleration();
            }

            if (Input.GetKeyUp(_speedUpKey))
            {
                _ship.RemoveAcceleration();
            }
        }

        private void ChangeScore()
        {
            if (Input.GetKeyDown(_addScore))
            {
                _scoreText.AddScore(SCORE_VALUE);
            }
        }
    }
}
