using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private const string GAMEMANAGER = "GameManager";
    private GameObject _gameManager;
    private Renderer _bulletRenderer;

    private void Awake()
    {
        _gameManager = GameObject.FindGameObjectWithTag(GAMEMANAGER);
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
        Debug.Log("col triggered");
        if (col.gameObject.tag == "Enemy")
        {
            _gameManager.GetComponent<GameManager>().SetPlayerScore(100);
            Debug.Log("enemy tag found");
            Destroy(col.gameObject);
            Destroy(gameObject);
        }
    }
}
