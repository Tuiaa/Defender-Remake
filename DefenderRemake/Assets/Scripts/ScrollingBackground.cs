using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingBackground : MonoBehaviour
{
    [SerializeField]
    private GameObject _player;
    private PlayerMovement _playerMovement;

    private Transform[] _backgrounds;
    private int _childCount = 0;

    private int _leftIndex;
    private int _rightIndex;
    private int _backgroundOffset = 25;

    private void Start()
    {
        if (_player != null)
        {
            _playerMovement = _player.GetComponent<PlayerMovement>();
        }
        InitializeList();
    }

    private void Update()
    {
        bool playerGoingToLeft = _playerMovement._goingToLeft;

        if (playerGoingToLeft)
        {
            if(BackgroundVisibleToCamera(_leftIndex))
            {
                ScrollLeft();
            }
        }
        else
        {
            if(BackgroundVisibleToCamera(_rightIndex))
            {
                ScrollRight();
            }
        }
    }

    private void InitializeList()
    {
        _backgrounds = new Transform[transform.childCount];
        foreach (Transform child in transform)
        {
            _backgrounds[_childCount] = child;
            _childCount++;
        }

        _leftIndex = 0;
        _rightIndex = _childCount - 1;
    }

    private bool BackgroundVisibleToCamera(int index)
    {
        Vector3 screenPoint = Camera.main.WorldToViewportPoint(_backgrounds[index].position);
        return screenPoint.z > 0 && screenPoint.x > 0 && screenPoint.x < 1 && screenPoint.y > 0 && screenPoint.y < 1;
    }

    private void ScrollLeft()
    {
        float newPosition = _backgrounds[_leftIndex].position.x - _backgroundOffset;
        _backgrounds[_rightIndex].position = new Vector3(newPosition, 0, 0);

        _leftIndex = _rightIndex;
        _rightIndex--;
        if (_rightIndex < 0)
        {
            _rightIndex = _childCount - 1;
        }
    }

    private void ScrollRight()
    {
        float newPosition = _backgrounds[_rightIndex].position.x + _backgroundOffset;
        _backgrounds[_leftIndex].position = new Vector3(newPosition, 0, 0);

        _rightIndex = _leftIndex;
        _leftIndex++;
        if (_leftIndex == _backgrounds.Length)
        {
            _leftIndex = 0;
        }
    }
}
