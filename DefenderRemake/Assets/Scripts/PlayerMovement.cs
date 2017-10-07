using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 *      PLAYER MOVEMENT
 *      - Moves player up/down depending on the y mouse position
 *      - Changes the left/right direction where player is moving
 *        depending on the x value of mouse position
 */
public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float _playerShipSpeedHorizontal = 25;
    [SerializeField]
    private GameObject _background;

    private bool _goingToLeft = true;

    private float _playerOffSetLowerScreen = 0.5f;
    private float _playerOffSetUpperScreen = 2f;

    private void Update()
    {
        CheckInputs();
    }

    public bool PlayerGoingToLeft()
    {
        return _goingToLeft;
    }

    public float GetPlayerHorizontalSpeed()
    {
        return _playerShipSpeedHorizontal;
    }

    private void CheckInputs()
    {

        float mouseRatioX = Input.mousePosition.x / Screen.width;
        float mouseRatioY = Input.mousePosition.y / Screen.height;

        Vector2 mousePos = new Vector2(mouseRatioX, mouseRatioY);
        mousePos = Camera.main.ViewportToWorldPoint(mousePos);

        // Move player up/down if mouse position is inside camera view
        if (mousePos.y > (Camera.main.ViewportToWorldPoint(Vector3.zero).y + _playerOffSetLowerScreen)
            && mousePos.y < (Camera.main.ViewportToWorldPoint(Vector3.up).y - _playerOffSetUpperScreen))
        {
            transform.position = new Vector2(0, mousePos.y);
        }
        Vector2 xPosOfMouse = new Vector2(0.5f, 0);

        // Player should go to right
        if (mousePos.x > Camera.main.ViewportToWorldPoint(xPosOfMouse).x)
        {
            transform.localScale = new Vector3(-1, 1, 1);
            _goingToLeft = false;
        }
        // Player should go to left
        if (mousePos.x < Camera.main.ViewportToWorldPoint(xPosOfMouse).x)
        {
            transform.localScale = Vector3.one;
            _goingToLeft = true;
        }
    }
}