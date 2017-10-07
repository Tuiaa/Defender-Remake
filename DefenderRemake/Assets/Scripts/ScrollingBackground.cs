using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 *      SCROLLING BACKGROUND
 *      - Background is scrolling at the same speed as player moves
 *      - Background is warped back to start at the end of the picture
 */
public class ScrollingBackground : MonoBehaviour
{
    [SerializeField]
    private GameObject _player;
    private PlayerMovement _playerMovement;
    private float _playerSpeed;
    private float _backgroundOffset = 50f;

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
        // bool playerGoingToLeft = _playerMovement.PlayerGoingToLeft();
        MoveBackground(_playerMovement.PlayerGoingToLeft() ? GameManager.DIRECTION.LEFT : GameManager.DIRECTION.RIGHT);
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
                    gameObject.transform.position = new Vector2(-_backgroundOffset, 0);
                }
                break;

            case GameManager.DIRECTION.RIGHT:
                gameObject.transform.position += Vector3.left * _playerSpeed * Time.deltaTime;
                if (gameObject.transform.position.x < -_backgroundOffset)
                {
                    gameObject.transform.position = new Vector2(_backgroundOffset, 0);
                }
                break;
        }
    }
}