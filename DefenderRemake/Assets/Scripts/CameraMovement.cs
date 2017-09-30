using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {

    [SerializeField]
    private GameObject _player;

    private void Update()
    {
        float x = _player.transform.position.x;

        transform.position = new Vector3(x, transform.position.y, transform.position.z);
    }
}
