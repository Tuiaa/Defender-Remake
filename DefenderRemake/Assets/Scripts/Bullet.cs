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
}
