using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    const string PLAYER = "Player";

    [SerializeField]
    private float _speed = 0.1f;
    private GameObject _player;
    bool _moveCloser = true;
    bool _stopMoving = false;

    private void Start()
    {
        _player = GameObject.FindGameObjectWithTag(PLAYER);
    }

    private void Update()
    {
        float enemySpeed = _speed * Time.deltaTime;

        if (_moveCloser)
        {
            transform.position = Vector3.MoveTowards(transform.position, _player.transform.position, enemySpeed);
        }
        else
        {
            if (!_stopMoving) {
                if (transform.position.x > 0)
                {
                    if (transform.position.x < 3 && transform.position.x > -3)
                    {
                        Vector3 newPos = new Vector3(transform.position.x, transform.position.x + 4, 0f);
                        transform.position = Vector3.MoveTowards(transform.position, newPos, _speed * Time.deltaTime);
                        _stopMoving = true;
                    }
                        
                }
            }
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
       // Debug.Log("player triggered");
        if (col.gameObject.tag == PLAYER)
        {
            _moveCloser = false;
        }
    }
}
