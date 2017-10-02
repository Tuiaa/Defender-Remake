using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float _playerShipSpeedHorizontal = 25;
    [SerializeField]
    private float _playerShipSpeedVertical = 15;
    [SerializeField]
    private GameObject _background;
    
    public bool _goingToLeft = true;

    private void Update()
    {
        if(_goingToLeft)
        {
            _background.transform.position += Vector3.right * _playerShipSpeedHorizontal * Time.deltaTime;
        }

        if (!_goingToLeft)
        {
            _background.transform.position += Vector3.left * _playerShipSpeedHorizontal * Time.deltaTime;
        }

        CheckInputs();
    }

    private void CheckInputs()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.localScale = Vector3.one;
            _goingToLeft = true;
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.localScale = new Vector3(-1, 1, 1);
            _goingToLeft = false;
        }

        if (Input.GetKey(KeyCode.UpArrow))
        {
            if(transform.position.y < (Camera.main.ViewportToWorldPoint(Vector3.up).y - 0.5f))
            {
                transform.position += Vector3.up * _playerShipSpeedVertical * Time.deltaTime;
            }
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            if (transform.position.y > (Camera.main.ViewportToWorldPoint(Vector3.zero).y + 0.5f))
            {
                transform.position += Vector3.down * _playerShipSpeedVertical * Time.deltaTime;
            }
        }
    }
}
