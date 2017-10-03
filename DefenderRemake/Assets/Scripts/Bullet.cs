using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    private Renderer _bulletRenderer;

    private void Awake()
    {
        _bulletRenderer = GetComponent<Renderer>();
    }

    void Update ()
    {
		if(!_bulletRenderer.isVisible)
        {
            Destroy(gameObject);
        }
	}

    void OntriggerEnter2D(Collider2D col)
    {
        Debug.Log("enemy triggered");
        if (col.gameObject.tag == "Enemy")
        {
            Destroy(col.gameObject);
            Destroy(gameObject);
        }
    }
}
