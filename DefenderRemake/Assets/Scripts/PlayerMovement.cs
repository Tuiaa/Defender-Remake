using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    [SerializeField]
    private float _playerShipSpeedHorizontal = 25;
    [SerializeField]
    private float _playerShipSpeedVertical = 15;
    [SerializeField]
    private GameObject _background;

    private bool _goingToRight = false;
    private bool _goingToLeft = true;

    private void FixedUpdate()
    {
        if(_goingToLeft)
        {
            _background.transform.position += Vector3.right * _playerShipSpeedHorizontal * Time.deltaTime;
        }

        if (_goingToRight)
        {
            _background.transform.position += Vector3.left * _playerShipSpeedHorizontal * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.localScale = Vector3.one;
            _goingToLeft = true;
            _goingToRight = false;
        }
        if(Input.GetKey(KeyCode.RightArrow))
        {
            transform.localScale = new Vector3(-1, 1, 1);
            _goingToRight = true;
            _goingToLeft = false;
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.position += Vector3.up * _playerShipSpeedVertical * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.position += Vector3.down * _playerShipSpeedVertical * Time.deltaTime;
        }
    }
}
