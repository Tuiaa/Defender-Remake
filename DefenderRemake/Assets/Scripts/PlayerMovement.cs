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
    private float _playerShipSpeedVertical = 15;
    [SerializeField]
    private GameObject _background;
    private bool _goingToLeft = true;

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

        Vector3 mousePos = new Vector3(mouseRatioX, mouseRatioY, 0f);
        mousePos = Camera.main.ViewportToWorldPoint(mousePos);

        // Move player up/down if mouse position is inside camera view
        if (mousePos.y > (Camera.main.ViewportToWorldPoint(Vector3.zero).y + 0.5f) && mousePos.y < (Camera.main.ViewportToWorldPoint(Vector3.up).y - 0.5f))
        {
            transform.position = new Vector3(0, mousePos.y, -0.1f);
        }
        Vector3 xPosOfMouse = new Vector3(0.5f, 0, 0);

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
