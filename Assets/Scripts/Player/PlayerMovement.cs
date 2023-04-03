using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody _rigidbody;
    private Player _player;

    public float movementSpeed; 
    public float jumpForce;
    public bool grounded;

    void Start()
    {
        _player = GetComponent<Player>();
        _rigidbody = GetComponent<Rigidbody>();
    }
    
    void FixedUpdate()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        
        _rigidbody.velocity = new Vector3(
            Input.GetAxis("Horizontal") * movementSpeed * Time.deltaTime * 2, 
            _rigidbody.velocity.y, 
            Input.GetAxis("Vertical") * movementSpeed * Time.deltaTime * 2);

    }

    void Update()
    {

            if(Input.GetButtonDown("Jump") && grounded)
            {
                _rigidbody.velocity = new Vector3(0,jumpForce,0);
            }
            else if(Input.GetKeyDown(KeyCode.Space) && grounded)
            {
                _rigidbody.velocity = new Vector3(0,jumpForce,0);
            }
    }
}