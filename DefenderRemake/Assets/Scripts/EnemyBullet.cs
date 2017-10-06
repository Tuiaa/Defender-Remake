using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 *      ENEMY BULLET
 *      - Bullet is destroyed after it's not visible to camera
 *      - If bullet hits player, player dies
 * 
 */
public class EnemyBullet : MonoBehaviour
{
    private Renderer _bulletRenderer;
    private GameObject _gameManager;

    void Awake()
    {
        _bulletRenderer = gameObject.GetComponent<Renderer>();
        _gameManager = GameObject.Find("GameManager");
    }

	void Update ()
    {
        if (!_bulletRenderer.isVisible)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            if (_gameManager != null)
            {
                _gameManager.GetComponent<GameManager>().PlayerDied();
            }
            Destroy(gameObject);
        }
    }
}
