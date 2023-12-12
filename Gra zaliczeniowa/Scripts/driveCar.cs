using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class driveCar : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rightTireRB; 
    [SerializeField] private Rigidbody2D _leftTireRB; 
    [SerializeField] private Rigidbody2D _carRB; 
    [SerializeField] private float _speed = 150f;
    [SerializeField] private float _rotationSpeed = 300f;

    private float _moveInput;

    private void Update()
    {
        _moveInput = Input.GetAxisRaw("Horizontal");
    }


    private void FixedUpdate()
    {
        _rightTireRB.AddTorque(-_moveInput * _speed * Time.fixedDeltaTime); 
        _leftTireRB. AddTorque(-_moveInput * _speed * Time.fixedDeltaTime);
        _carRB. AddTorque(_moveInput * _rotationSpeed * Time.fixedDeltaTime);
    }
}