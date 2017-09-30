using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    [SerializeField]
    private float _playerShipSpeed = 5;

    private void FixedUpdate()
    {
        if(Input.GetKey(KeyCode.LeftArrow))
        {
            transform.localScale = Vector3.one;
            transform.position += Vector3.left * _playerShipSpeed * Time.deltaTime;
        }
        if(Input.GetKey(KeyCode.RightArrow))
        {
            transform.localScale = new Vector3(-1, 1, 1);
            transform.position += Vector3.right * _playerShipSpeed * Time.deltaTime;
        }
    }
}
