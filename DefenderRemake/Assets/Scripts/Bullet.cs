using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 *      BULLET
 *      - Handles player's bullets
 */
public class Bullet : MonoBehaviour
{
    private GameObject _gameManager;
    private Renderer _bulletRenderer;

    private void Awake()
    {
        _gameManager = GameObject.FindGameObjectWithTag(GameStrings.GAME_MANAGER);
        _bulletRenderer = GetComponent<Renderer>();
    }

    void Update ()
    {
		if(!_bulletRenderer.isVisible)
        {
            Destroy(gameObject);
        }
	}

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == GameStrings.ENEMY)
        {
            if(_gameManager != null)
            {
                _gameManager.GetComponent<GameManager>().SetPlayerScore(100);
            }
            Destroy(col.gameObject);
            Destroy(gameObject);
        }
    }
}
