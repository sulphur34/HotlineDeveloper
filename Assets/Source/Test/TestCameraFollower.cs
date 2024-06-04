using System;
using UnityEngine;

public class TestCameraFollower : MonoBehaviour
{
    [SerializeField] private float _overviewRange = 30;
    [SerializeField] private float _lerpRate = 0.5f;
    
    private Transform _transform;
    private Camera _camera;

    private void Awake()
    {
        _transform = transform;
        _camera = Camera.main;
    }

    private void Update()
    {
        Vector3 playerPosition = new Vector3(transform.position.x, _camera.transform.position.y, transform.position.z);

        Vector3 mouseposition = Input.mousePosition;
        mouseposition.z = _camera.nearClipPlane + _overviewRange;
        Vector3 mouseWorldPoint = _camera.ScreenToWorldPoint(mouseposition);
        mouseWorldPoint.y = _camera.transform.position.y;

        Debug.Log(mouseWorldPoint + " - " + playerPosition);

        _camera.transform.position = Vector3.Lerp(playerPosition, mouseWorldPoint, _lerpRate);
    }
}