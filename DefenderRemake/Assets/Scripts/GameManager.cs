using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
 *      GAME MANAGER
 *      - Handles enemy spawning, game over, player score... etc
 *      - Game gets more difficult with time
 *          - Each wave spawns more enemies
 */
public class GameManager : MonoBehaviour
{
    public enum DIRECTION { UP, DOWN, LEFT, RIGHT };

    public delegate void PlayerDeathEvent();
    public static PlayerDeathEvent PlayerHasDied;

    public delegate void GamePausedEvent();
    public static GamePausedEvent GameIsPaused;

    [SerializeField]
    private GameObject _background;
    private float _backgroundLength = 50f;
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
    private int _difficulty = 1;
    private float _difficultyTimer = 15f;
    private float _difficultyTimerDefault = 20f;

    [SerializeField]
    private int _playerScore = 0;
    private int _playerLivesLeft = 3;

    private void Awake()
    {
        Time.timeScale = 1f;
        if (_background != null)
        {
            _backgroundLength = _background.GetComponent<ScrollingBackground>().GetBackgroundOffset();
        }

        if (_gameOverPanel != null)
        {
            _gameOverPanel.SetActive(false);
        }
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
            _difficulty += _difficulty;
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
                enemy.transform.localPosition = FindSpawnLocation();
            }
        }
    }

    private Vector3 FindSpawnLocation()
    {
        // Random Y pos is taken directly from background, should be calculated
        float randomY = UnityEngine.Random.Range(-3.5f, 2.5f);
        float randomX = UnityEngine.Random.Range(-_backgroundLength, _backgroundLength);

        Vector2 enemyPos = new Vector2(randomX, randomY);
        return enemyPos;
    }

    private void GameOver()
    {
        if (GameIsPaused != null)
        {
            GameIsPaused();
        }
        Time.timeScale = 0f;

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