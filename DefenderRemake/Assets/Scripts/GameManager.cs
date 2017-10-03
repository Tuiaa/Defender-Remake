using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public enum DIRECTION { UP, DOWN, LEFT, RIGHT };

    [SerializeField]
    private GameObject _enemyPrefab;
    private float _timeToSpawnMoreEnemies;
    private int _enemyStartAmount = 3;

    private int _playerLivesLeft = 3;

    float _screenHeight;
    float _screenWidth;

    private void Start()
    {
        _timeToSpawnMoreEnemies = Time.time + 10;

        _screenHeight = Camera.main.orthographicSize * 2;
        _screenWidth = _screenHeight * Screen.width / Screen.height;

        for (int i = 0; i < _enemyStartAmount; i++)
        {
            GameObject enemy = Instantiate(_enemyPrefab);
            enemy.transform.position = FindSpawnLocation();
        }
    }

    private void Update()
    {

    }

    private Vector3 FindSpawnLocation()
    {
        DIRECTION randomDirection = (DIRECTION)(UnityEngine.Random.Range(0, Enum.GetNames(typeof(DIRECTION)).Length));
        float randomX = 0, randomY = 0;

        Vector3 randomCameraPos = Vector3.zero;
        Vector3 enemyPos = Vector3.zero;

        switch (randomDirection)
        {
            case DIRECTION.UP:
                randomX = UnityEngine.Random.Range(0.0f, 1.0f);
                randomY = 1;

                randomCameraPos = new Vector3(randomX, randomY, 0);
                enemyPos = Camera.main.ViewportToWorldPoint(randomCameraPos);

                enemyPos.y += 2;
                break;
            case DIRECTION.DOWN:
                randomX = UnityEngine.Random.Range(0.0f, 1.0f);
                randomY = 0;

                randomCameraPos = new Vector3(randomX, randomY, 0);
                enemyPos = Camera.main.ViewportToWorldPoint(randomCameraPos);

                enemyPos.y -= 2;
                break;
            case DIRECTION.LEFT:
                randomY = UnityEngine.Random.Range(0.0f, 1.0f);
                randomX = 0;

                randomCameraPos = new Vector3(randomX, randomY, 0);
                enemyPos = Camera.main.ViewportToWorldPoint(randomCameraPos);

                enemyPos.x -= 2;
                break;
            case DIRECTION.RIGHT:
                randomY = UnityEngine.Random.Range(0.0f, 1.0f);
                randomX = 1;

                randomCameraPos = new Vector3(randomX, randomY, 0);
                enemyPos = Camera.main.ViewportToWorldPoint(randomCameraPos);

                enemyPos.x += 2;
                break;
            default:
                Debug.LogWarning("This shouldn't happen");
                break;
        }
        return enemyPos;
    }

    private void OnPlayerDied()
    {
        Debug.Log("PlayerDied");
    }
}
