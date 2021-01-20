using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Shipov_Asteroids
{
    internal sealed class GameController : MonoBehaviour
    {
        [SerializeField] private List<IChainMember> _chainMembers;
        [SerializeField] private PlayerSO _playerSO;
        [SerializeField] private GameObject _playerPrefab;
        [SerializeField] private Canvas _scoreCanvas;
        [SerializeField] private Rigidbody2D _bullet;
        [SerializeField] private Transform _barrel;
        private Ship _ship;

       // private ScoreInterpretator _scoreInterpretator;
        private IChainMember _chainMember;
        private UpdatingObjects _updatingObjects;
        private InputController _inputController;
        private Camera _camera;
        private ScoreUI _scoreText;

        private IEnemyFactory asteroidFactory;


        private void Start()
        {
            //_scoreInterpretator = new ScoreInterpretator();
            _chainMembers = new List<IChainMember>();

            EnemyPool enemyPool = new EnemyPool(5);
            var enemy = enemyPool.GetEnemy("Asteroid");
            enemy.transform.position = Vector3.one;
            enemy.gameObject.SetActive(true);

            if(enemy is Asteroid asteroid)
            {
                asteroid.InitAsteroid();
            }

            _scoreCanvas = Instantiate(_scoreCanvas);
            _scoreText = new ScoreUI(_scoreCanvas, new ScoreInterpretator());
            _playerPrefab = Instantiate(_playerPrefab);
            _camera = _playerPrefab.GetComponentInChildren<Camera>();
            _barrel = _playerPrefab.GetComponentInChildren<Transform>().GetChild(0);
            var _moveTransform = new AccelerationMovement(_playerPrefab.transform, _playerSO.speed, _playerSO.acceleration);
            var _rotation = new ShipRotation(_playerPrefab.transform);
            var _shoot = new BaseShoot(_bullet, _barrel, _playerSO.force);
            _ship = new Ship(_moveTransform, _rotation, _shoot, _playerSO);
            _updatingObjects = new UpdatingObjects();
            _inputController = new InputController(_playerPrefab, _camera, _ship, _scoreText);

            _updatingObjects.AddUpdateObject(enemy as IUpdate);
            _updatingObjects.AddUpdateObject(_inputController);

            _chainMember = new BustSpeedChain(_ship);
            _chainMembers.Add(_chainMember);
            _chainMembers.Add(new ReduceSpeedChain(_ship));

            _chainMembers[0].Act();
            for (var i = 1; i < _chainMembers.Count; i++)
            {
                _chainMembers[i - 1].TransferToNext(_chainMembers[i]);
            }

            _updatingObjects.AddUpdateObject(_chainMember as BustSpeedChain);
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
