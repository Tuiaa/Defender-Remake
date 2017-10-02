using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootMissiles : MonoBehaviour
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
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        GameObject bullet = Instantiate(_bullet);
        bullet.transform.position = gameObject.transform.position;

        if(_playerMovement._goingToLeft)
        {
            bullet.GetComponent<Rigidbody2D>().velocity = Vector3.left * _bulletSpeed;
        }
        else
        {
            bullet.GetComponent<Rigidbody2D>().velocity = Vector3.right * _bulletSpeed;
        }
    }
}
