using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    [SerializeField]
    private GameObject _player;
    private PlayerMovement _playerMovement;

    private int _playerLivesLeft = 3;

    private void Start()
    {
        _playerMovement = _player.GetComponent<PlayerMovement>();
        
    }

    private void OnDestroy()
    {

    }

    private void OnPlayerDied()
    {
        Debug.Log("PlayerDied");
    }
}
