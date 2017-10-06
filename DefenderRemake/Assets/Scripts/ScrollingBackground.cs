using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingBackground : MonoBehaviour
{
    [SerializeField]
    private GameObject _player;
    private PlayerMovement _playerMovement;
    private float _playerSpeed;
    private float _backgroundOffset = 54.4f;

    private void Start()
    {
        if (_player != null)
        {
            _playerMovement = _player.GetComponent<PlayerMovement>();
            _playerSpeed = _playerMovement.GetPlayerHorizontalSpeed();
        }
    }

    private void Update()
    {
        bool playerGoingToLeft = _playerMovement._goingToLeft;

        if (playerGoingToLeft)
        {
            MoveBackground(GameManager.DIRECTION.LEFT);
        }
        else
        {
            MoveBackground(GameManager.DIRECTION.RIGHT);
        }
    }

    public float GetBackgroundOffset()
    {
        return _backgroundOffset;
    }

    private void MoveBackground(GameManager.DIRECTION direction)
    {
        switch (direction)
        {
            case GameManager.DIRECTION.LEFT:
                gameObject.transform.position += Vector3.right * _playerSpeed * Time.deltaTime;
                if (gameObject.transform.position.x > _backgroundOffset)
                {
                    gameObject.transform.position = new Vector3(-54.4f, 0, 0);
                }
                break;

            case GameManager.DIRECTION.RIGHT:
                gameObject.transform.position += Vector3.left * _playerSpeed * Time.deltaTime;
                if (gameObject.transform.position.x < -_backgroundOffset)
                {
                    gameObject.transform.position = new Vector3(54.4f, 0, 0);
                }
                break;
        }
    }
}
