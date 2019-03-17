using Enemies;
using UnityEngine;
using UnityEngine.UI;

namespace General
{
    public class LevelTimer : MonoBehaviour
    {
        [Tooltip("Amount of seconds it will take to complete the level")]
        [SerializeField] private float levelTime = 10f;

        private Slider _slider;
        private EnemySpawner _enemySpawner;
        private Enemy _enemy;
        private Level _level;

        private bool _bTimeIsUp;
        private bool _bLevelIsFinished;
        private bool _bCallOneTime;

        private void Start()
        {
            _slider = GetComponent<Slider>();
            _enemySpawner = FindObjectOfType<EnemySpawner>();
            _level = FindObjectOfType<Level>();

            _bTimeIsUp = false;
            _bLevelIsFinished = false;
            _bCallOneTime = false;
        }

        private void Update()
        {
            if (!_bLevelIsFinished)
            {
                _slider.value = Time.timeSinceLevelLoad / levelTime;

                _bTimeIsUp = (Time.timeSinceLevelLoad >= levelTime);

                if (_bTimeIsUp)
                {
                    _enemySpawner.SetShouldSpawn(false);
                    _bLevelIsFinished = true;
                    _bCallOneTime = true;
                }
            }
            else if (_bCallOneTime)
            {
                _enemy = FindObjectOfType<Enemy>();

                if (_enemy == null && _bCallOneTime)
                {
                    _bCallOneTime = false;
                    _level.WonGame();
                }
            }
        }
    }
}
