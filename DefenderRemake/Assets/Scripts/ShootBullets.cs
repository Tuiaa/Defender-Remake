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
        bullet.transform.position = gameObject.transform.position;

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
