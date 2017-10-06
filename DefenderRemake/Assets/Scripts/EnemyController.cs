using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 *      ENEMY CONTROLLER
 *      - Enemies move towards player
 *      - When enemies get to the end of the background,
 *        they are moved to other end
 * 
 */
public class EnemyController : MonoBehaviour
{
    const string PLAYER = "Player";

    [SerializeField]
    private float _speed = 5f;
    [SerializeField]
    private float _shootFrequency = 2f;

    private float _timer;
    private GameObject _player;
    private GameObject _bullet;

    private float _bulletSpeed = 5f;
    private PlayerMovement _playerMovement;

    private Renderer _enemyRenderer;

    private float magnitude = 0.05f;
    private float frequency = 5f;
    private Vector3 pos;
    private Vector3 axis;

    private Vector3 _previousDirection = Vector3.left;

    private void Start()
    {
        _player = GameObject.FindGameObjectWithTag(PLAYER);
        _playerMovement = _player.GetComponent<PlayerMovement>();
        _enemyRenderer = gameObject.GetComponent<Renderer>();

        _shootFrequency = Random.Range(2f, 8f);
        _timer = _shootFrequency;
    }

    private void Update()
    {
        pos = transform.localPosition;
        pos += _previousDirection * Time.deltaTime * _speed;
        axis = transform.up;
        transform.localPosition = pos + axis * Mathf.Sin(Time.time * frequency) * magnitude;

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
        
            _timer -= Time.deltaTime;
            if (_timer <= 0)
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

            GameObject bullet = Instantiate(Resources.Load("EnemyBullet", typeof(GameObject))) as GameObject;
            bullet.transform.position = transform.position;
            bullet.GetComponent<Rigidbody2D>().velocity = shootDirection * _bulletSpeed;

            _timer = _shootFrequency;
        }
    }
}
