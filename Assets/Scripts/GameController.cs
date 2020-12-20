﻿using UnityEngine;

namespace Shipov_Asteroids
{
    internal sealed class GameController : MonoBehaviour
    {

        // В данный момент, вся инициализация проходит тут. Только пока что!)
        [SerializeField] private PlayerSO _playerSO;
        [SerializeField] private GameObject _playerPrefab;
        [SerializeField] private Rigidbody2D _bullet;
        [SerializeField] private Transform _barrel;
        private Ship _ship;

        private UpdatingObjects _updatingObjects;
        private InputController _inputController;
        private Camera _camera;

        IEnemyFactory asteroidFactory;


        private void Start()
        {
            ServiceLocator.AddService(new EnemyPool(5));
            var enemyPool = ServiceLocator.GetPull<EnemyPool>();

            var enemy = enemyPool.GetEnemy("Asteroid");
            enemy.transform.position = Vector3.one;
            enemy.gameObject.SetActive(true);

            if (enemy is Asteroid asteroid)
            {
                asteroid.InitAsteroid();
            }

            _playerPrefab = Instantiate(_playerPrefab);
            _camera = _playerPrefab.GetComponentInChildren<Camera>();
            _barrel = _playerPrefab.GetComponentInChildren<Transform>().GetChild(0); // На данный момент пришлось захардкодить
            var _moveTransform = new AccelerationMovement(_playerPrefab.transform, _playerSO.speed, _playerSO.acceleration);
            var _rotation = new ShipRotation(_playerPrefab.transform);
            var _shoot = new BaseShoot(_bullet, _barrel, _playerSO.force);
            _ship = new Ship(_moveTransform, _rotation, _shoot, _playerSO);
            _updatingObjects = new UpdatingObjects();
            _inputController = new InputController(_playerPrefab, _camera, _ship);

            _updatingObjects.AddUpdateObject(enemy as IUpdate);
            _updatingObjects.AddUpdateObject(_inputController);
        }

        private void Update()
        {
            for (int i = 0; i < _updatingObjects.Count; i++)
            {
                if (_updatingObjects == null)
                {
                    continue;
                }

                _updatingObjects[i].UpdateTick();
            }
        }

    }
}
