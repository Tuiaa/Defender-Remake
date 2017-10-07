using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 *      ENEMY CONTROLLER
 *      - Enemies move towards player
 *      - When enemies get to the end of the background,
 *        they are moved to other end
 *      - Enemies fire bullets at randomly chosen frequency
 */
public class EnemyController : MonoBehaviour
{
    [SerializeField]
    private float _speed = 5f;
    [SerializeField]
    private float _bulletSpeed = 2f;

    private GameObject _player;
    private PlayerMovement _playerMovement;

    private Renderer _enemyRenderer;

    private float _shootTimer;
    private float _shootFrequency = 3f;

    private float _sinCurveMagnitude = 0.05f;
    private float _sinCurveFrequency = 5f;

    private Vector3 _previousDirection = Vector3.left;
    private bool _gamePaused = false;

    private void Start()
    {
        _player = GameObject.FindGameObjectWithTag(GameStrings.PLAYER);
        _playerMovement = _player.GetComponent<PlayerMovement>();
        _enemyRenderer = gameObject.GetComponent<Renderer>();
        
        // Randomize enemy movement & shooting
        _shootFrequency = Random.Range(3f, 8f);
        _sinCurveFrequency = Random.Range(3f, 6f);

        _shootTimer = _shootFrequency;
        GameManager.GameIsPaused += OnGameIsPaused;
    }

    private void Update()
    {
        if (!_gamePaused)
        {
            transform.localPosition += _previousDirection * Time.deltaTime * _speed;
            transform.localPosition += Vector3.up * Mathf.Sin(Time.time * _sinCurveFrequency) * _sinCurveMagnitude;

            // Change direction so enemies go towards player
            if (!_playerMovement.PlayerGoingToLeft())
            {
                _previousDirection = Vector3.left;

                if (gameObject.transform.localPosition.x < -54f)
                {
                    gameObject.transform.localPosition = new Vector3(60f, transform.position.y, 0);
                }
            }
            else
            {
                _previousDirection = Vector3.right;

                if (gameObject.transform.localPosition.x > 54f)
                {
                    gameObject.transform.localPosition = new Vector3(-60f, transform.position.y, 0);
                }
            }
            _shootTimer -= Time.deltaTime;
            if (_shootTimer <= 0)
            {
                Shoot();
            }
        }
    }

    private void Shoot()
    {
        if (_enemyRenderer.isVisible)
        {

            GameObject bullet = Instantiate(Resources.Load(GameStrings.ENEMY_BULLET, typeof(GameObject))) as GameObject;
            bullet.transform.parent = gameObject.transform;
            bullet.transform.position = gameObject.transform.position;

            Vector3 shootDirection = _player.transform.position - bullet.transform.position;
            shootDirection = shootDirection.normalized;
            
            bullet.GetComponent<Rigidbody2D>().velocity = shootDirection * _bulletSpeed;

            _shootTimer = _shootFrequency;
        }
    }

    private void OnGameIsPaused()
    {
        _gamePaused = true;
    }
}
