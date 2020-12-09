using UnityEngine;

namespace Shipov_Asteroids
{
    // Мне кажется, что у этого класса слишком много ответственности. Можно комментарий по этому поводу?
    internal sealed class InputController : IUpdate
    {
        private Ship _ship;
        private GameObject _playerPrefab;
        private Camera _camera;

        private float _vertical;
        private float _horizontal;

        private KeyCode _shootButton = KeyCode.Mouse0;
        private KeyCode _speedUp = KeyCode.LeftShift;

        public InputController(GameObject playerPrefab, Camera camera, Ship ship)
        {
            _playerPrefab = playerPrefab;
            _camera = camera;
            _ship = ship;
        }

        public void UpdateTick()
        {
            Motion();
            Shoot();
            SpeedUP();
        }

        private void Shoot()
        {
            if (Input.GetKeyDown(_shootButton))
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
            if (Input.GetKeyDown(_speedUp))
            {
                _ship.AddAcceleration();
            }

            if (Input.GetKeyUp(_speedUp))
            {
                _ship.RemoveAcceleration();
            }
        }
    }
}
