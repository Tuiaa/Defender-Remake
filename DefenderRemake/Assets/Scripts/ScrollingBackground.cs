using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingBackground : MonoBehaviour {

    [SerializeField]
    private GameObject _parentBackground;

    private Transform[] _backgrounds;
    private int _childCount = 0;

    private int _leftIndex;
    private int _rightIndex;
    private int _backgroundOffset = 25;

    private void Start()
    {
        InitializeList();
    }

    private void Update()
    {
        if(Input.GetKeyUp(KeyCode.A))
        {
            ScrollLeft();
        }

        if (Input.GetKeyUp(KeyCode.D))
        {
            ScrollRight();
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

    private void ScrollLeft()
    {
        int previousRight = _rightIndex;
        float newPosition = _backgrounds[_leftIndex].position.x - _backgroundOffset;
        _backgrounds[_rightIndex].position = new Vector3(newPosition, 0, 0);

        _leftIndex = _rightIndex;
        _rightIndex--;
        if(_rightIndex < 0)
        {
            _rightIndex = _childCount - 1;
        }
    }

    private void ScrollRight()
    {
        int previousLeft = _leftIndex;
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
