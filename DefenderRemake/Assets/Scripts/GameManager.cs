using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
 *      GAME MANAGER
 *      - Handles enemy spawning, game over, player score... etc
 *      - Player gets more difficult with time
 *          - Each wave spawns more enemies
 */
public class GameManager : MonoBehaviour
{
    public enum DIRECTION { UP, DOWN, LEFT, RIGHT };

    public delegate void PlayerDeathEvent();
    public static PlayerDeathEvent PlayerHasDied;

    [SerializeField]
    private GameObject _background;
    private float _backgroundLength = 54.4f;
    [SerializeField]
    private GameObject _enemyPrefab;

    [Header("UI")]
    [SerializeField]
    private Text _scoreText;
    [SerializeField]
    private Text _playerLivesText;
    [SerializeField]
    private GameObject _gameOverPanel;
    [SerializeField]
    private Text _gameOverScoreText;
    
    private int _enemyStartAmount = 10;
    private int _difficulty = 0;
    private float _difficultyTimer = 20f;
    private float _difficultyTimerDefault = 20f;

    private int _playerScore = 0;
    private int _playerLivesLeft = 3;

    float _screenHeight;
    float _screenWidth;

    private void Awake()
    {
        if (_background != null)
        {
            _backgroundLength = _background.GetComponent<ScrollingBackground>().GetBackgroundOffset();
        }

        if (_gameOverPanel != null)
        {
            _gameOverPanel.SetActive(false);
        }

        _screenHeight = Camera.main.orthographicSize * 2;
        _screenWidth = _screenHeight * Screen.width / Screen.height;
    }

    private void Start()
    {
        SpawnEnemy(_enemyStartAmount);
    }

    private void Update()
    {
        if (_playerLivesLeft == -1)
        {
            GameOver();
        }

        _difficultyTimer -= Time.deltaTime;
        if (_difficultyTimer <= 0)
        {
            _difficulty += 2;
            SpawnEnemy(_difficulty);
            _difficultyTimer = _difficultyTimerDefault;
        }
    }

    public void SetPlayerScore(int score)
    {
        _playerScore += score;

        if (_scoreText != null)
        {
            _scoreText.text = GameStrings.SCORE_TEXT + _playerScore.ToString();
        }
    }

    public void PlayerDied()
    {
        _playerLivesLeft -= 1;
        if (_playerLivesText != null)
        {
            _playerLivesText.text = GameStrings.PLAYER_LIVES + _playerLivesLeft.ToString();
        }
        if (PlayerHasDied != null)
        {
            PlayerHasDied();
        }
    }

    private void SpawnEnemy(int enemyCount)
    {
        for (int i = 0; i < enemyCount; i++)
        {
            if (_enemyPrefab != null)
            {
                GameObject enemy = Instantiate(_enemyPrefab);
                enemy.transform.parent = _background.transform;
                enemy.transform.position = FindSpawnLocation();
            }
        }
    }

    private Vector3 FindSpawnLocation()
    {
        float randomX = UnityEngine.Random.Range(-_backgroundLength, _backgroundLength);
        float randomY = UnityEngine.Random.Range(-4.5f, 3.5f);

        Vector3 enemyPos = new Vector3(randomX, randomY, -0.1f);
        enemyPos.z = -0.1f;
        return enemyPos;
    }

    private void GameOver()
    {
        Time.timeScale = 0;

        if (_gameOverScoreText != null)
        {
            _gameOverScoreText.text = GameStrings.SCORE_TEXT + _playerScore.ToString();
        }
        if (_gameOverPanel != null)
        {
            _gameOverPanel.SetActive(true);
        }
    }
}
