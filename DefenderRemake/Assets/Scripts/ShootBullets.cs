using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 *      SHOOT MISSILES
 *      - Shoot with space or left mouse click
 *      -  Gets the direction player is facing
 */
public class ShootBullets : MonoBehaviour
{
    [SerializeField]
    private GameObject _bullet;
    [SerializeField]
    private float _bulletSpeed = 5;

    private PlayerMovement _playerMovement;

    private void Awake()
    {
        _playerMovement = gameObject.GetComponent<PlayerMovement>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        GameObject bullet = Instantiate(_bullet);
        Vector3 bulletPos = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, -0.1f);
        bullet.transform.position = bulletPos;

        if (_playerMovement.PlayerGoingToLeft())
        {
            bullet.GetComponent<Rigidbody2D>().velocity = Vector3.left * _bulletSpeed;
        }
        else
        {
            bullet.GetComponent<Rigidbody2D>().velocity = Vector3.right * _bulletSpeed;
        }
    }
}
