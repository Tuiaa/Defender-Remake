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
    }

    void OnTriggerEnter2D(Collider2D col)
    {

    }
}
