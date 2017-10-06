using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public enum DIRECTION { UP, DOWN, LEFT, RIGHT };

    [SerializeField]
    private GameObject _background;
    [SerializeField]
    private GameObject _enemyPrefab;
    [SerializeField]
    private Text _scoreText;

    private float _backgroundLength;
    private float _timeToSpawnMoreEnemies;
    private int _enemyStartAmount = 10;

    private int _playerLivesLeft = 3;
    [SerializeField]
    private int _playerScore = 0;

    float _screenHeight;
    float _screenWidth;
    
    private void Awake()
    {
        if (_background != null)
        {
            _backgroundLength = _background.GetComponent<ScrollingBackground>().GetBackgroundOffset();
        }

        _screenHeight = Camera.main.orthographicSize * 2;
        _screenWidth = _screenHeight * Screen.width / Screen.height;
    }

    private void Start()
    {
        _timeToSpawnMoreEnemies = Time.time + 10;
        
        for (int i = 0; i < _enemyStartAmount; i++)
        {
            GameObject enemy = Instantiate(_enemyPrefab);
            enemy.transform.parent = _background.transform;
            enemy.transform.position = FindSpawnLocation();
        }
    }

    public void SetPlayerScore(int score)
    {
        _playerScore += score;
        _scoreText.text = "Score: " + _playerScore.ToString();
    }

    private Vector3 FindSpawnLocation()
    {
        DIRECTION randomDirection = (DIRECTION)(UnityEngine.Random.Range(0, Enum.GetNames(typeof(DIRECTION)).Length));
        
        float randomX = UnityEngine.Random.Range(-_backgroundLength, _backgroundLength);
        float randomY = UnityEngine.Random.Range(-4.5f, 3.2f);

        Vector3 enemyPos = new Vector3(randomX, randomY, -0.1f);

        /*switch (randomDirection)
        {
            case DIRECTION.UP:
                randomX = UnityEngine.Random.Range(-_backgroundLength, _backgroundLength);
                randomY = UnityEngine.Random.Range(-_backgroundLength, _backgroundLength);
                enemyPos = new Vector3(randomX, randomY, -0.1f);
                break;
            case DIRECTION.DOWN:
                randomX = UnityEngine.Random.Range(-_backgroundLength, _backgroundLength);
                randomY = 0;

                randomCameraPos = new Vector3(randomX, randomY, 0);
                //  enemyPos = Camera.main.ViewportToWorldPoint(randomCameraPos);
                enemyPos = randomCameraPos;
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
        }*/
        enemyPos.z = -0.1f;
        return enemyPos;
    }

    private void OnPlayerDied()
    {
        Debug.Log("PlayerDied");
    }
}
