using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
 *      PLAYER CONTROLLER
 *      - If player dies its renderer flashes and collider is
 *        not enabled before player has respawned
 */
public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private GameObject _deathImage;

    private Renderer _playerRenderer;
    private Collider2D _playerCollider;

    private void Awake()
    {
        _playerRenderer = gameObject.GetComponent<Renderer>();
        _playerCollider = gameObject.GetComponent<Collider2D>();

        if (_deathImage != null)
        {
            _deathImage.SetActive(false);
        }
        GameManager.PlayerHasDied += OnPlayerHasDied;
    }

    private void OnPlayerHasDied()
    {
        if (_playerRenderer != null)
        {
            _playerRenderer.enabled = false;
        }

        if (_deathImage != null)
        {
            _deathImage.SetActive(true);
        }

        StartCoroutine(Respawn());
    }

    private IEnumerator Respawn()
    {
        for (int i = 0; i < 5; i++)
        {
            if (_playerRenderer != null && _playerCollider != null)
            {
                _playerRenderer.enabled = false;
                _playerCollider.enabled = false;
                yield return new WaitForSeconds(0.1f);
                _playerRenderer.enabled = true;
                yield return new WaitForSeconds(0.1f);
            }
        }
        if (_deathImage != null)
        {
            _deathImage.SetActive(false);
        }

        if (_playerRenderer != null && _playerCollider != null)
        {
            _playerRenderer.enabled = true;
            _playerCollider.enabled = true;
        }
    }
}
