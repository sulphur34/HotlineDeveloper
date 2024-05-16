using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestControl : MonoBehaviour
{
    private CharacterController _characterController;
    private Rigidbody _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _characterController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.W))
            MoveHorizontal(Vector3.forward);

        if (Input.GetKey(KeyCode.A))
            MoveHorizontal(Vector3.left);

        if (Input.GetKey(KeyCode.D))
            MoveHorizontal(Vector3.right);

        if (Input.GetKey(KeyCode.S))
            MoveHorizontal(Vector3.back);

        float mouseX = Input.GetAxis("Mouse X");

        RotateHorizontal(mouseX);

        Camera.main.transform.position =
            new Vector3(transform.position.x, Camera.main.transform.position.y, transform.position.z - 1);
    }

    public void RotateHorizontal(float direction)
    {
        transform.RotateAround(transform.position,transform.up,direction * 10);
    }

    public void MoveHorizontal(Vector3 direction)
    {
        _characterController.Move(direction * 0.5f * Time.deltaTime);
    }
}