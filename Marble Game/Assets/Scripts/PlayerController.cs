﻿using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody _rb;

    public float Speed = 10;
    public GameObject Camera;

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Quaternion cameraAngle = Quaternion.AngleAxis(Camera.transform.eulerAngles.y, Vector3.up);

        Vector3 movement = cameraAngle * new Vector3(moveHorizontal, 0, moveVertical);

        _rb.AddForce(movement * Speed);
    }
}
