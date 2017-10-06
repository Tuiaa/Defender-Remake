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

    private float magnitude = 0.05f;
    private float frequency = 5f;

    private Vector3 _previousDirection = Vector3.left;

    private void Start()
    {
        _player = GameObject.FindGameObjectWithTag(GameStrings.PLAYER);
        _playerMovement = _player.GetComponent<PlayerMovement>();
        _enemyRenderer = gameObject.GetComponent<Renderer>();

        _shootFrequency = Random.Range(3f, 8f);
        _shootTimer = _shootFrequency;
    }

    private void Update()
    {
        transform.localPosition += _previousDirection * Time.deltaTime * _speed;
        transform.localPosition = transform.localPosition + Vector3.up * Mathf.Sin(Time.time * frequency) * magnitude;

        // Change direction towards player
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

    private void Shoot()
    {
        if (_enemyRenderer.isVisible)
        {
            Vector3 shootDirection = _player.transform.position - transform.position;
            shootDirection = shootDirection.normalized;

            GameObject bullet = Instantiate(Resources.Load(GameStrings.ENEMY_BULLET, typeof(GameObject))) as GameObject;
            bullet.transform.position = transform.position;
            bullet.GetComponent<Rigidbody2D>().velocity = shootDirection * _bulletSpeed;

            _shootTimer = _shootFrequency;
        }
    }
}
