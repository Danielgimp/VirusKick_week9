using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerMovement : MonoBehaviour
{
    public GameObject Player;

    [SerializeField] float horizontalSpeed = 20f;
    [SerializeField] float forwardSpeed = 20f;
    [SerializeField] float _jump = 10f;
    [SerializeField] float fallingSpeed = 2.5f;
    [SerializeField] float lowjump = 2f;
    
    private Rigidbody _rigidbody;
    //private PlayerCollision playerCollision;

    private bool isjump = false;  
    private bool _isGrounded;
    private Vector3 initLocation;
    private PlayerCollision playerCollision;


    float movement;
    // Start is called before the first frame update
    void Start()
    {
       initLocation = transform.position;
       _rigidbody = GetComponent<Rigidbody>();
       playerCollision = GetComponent<PlayerCollision>();
        GameManager.onGameStart += Reset;
    }

    private void Reset()
    {
        gameObject.SetActive(true);        
        transform.position = initLocation;
    }

    private void Update()
    {
        ReadInput();        
        _isGrounded = playerCollision.isGrounded;
        //Fall multiplier for jump
        ApplyFall();

    }
    // Update is called once per frame
    void FixedUpdate()
    {
        Jump();
        leftrightmovement();
    }

    private void ReadInput()
    {
        if (Input.GetKeyDown(KeyCode.Space)&&_isGrounded) // wait for the player to be on the ground and then can jump again
        {
            isjump = true;
        }

        movement = Input.GetAxis("Horizontal");     
    }

    private void leftrightmovement()
    {
        float step= movement * horizontalSpeed * Time.deltaTime;       
        float XPos = transform.localPosition.x + step;
        float YPos = transform.localPosition.y;       

        transform.localPosition = new Vector3(XPos, YPos, transform.localPosition.z);
    }

    private void ApplyFall()
    {
        if (_rigidbody.velocity.y < 0)  //
        {
           _rigidbody.velocity += Vector3.up * Physics.gravity.y * (fallingSpeed - 1) * Time.deltaTime; //long jump
        }
        else if (_rigidbody.velocity.y > 0 && !Input.GetKey(KeyCode.Space)) //regular jump
        {
            _rigidbody.velocity += Vector3.up * Physics.gravity.y * (lowjump - 1) * Time.deltaTime;
        }
    }
 
 

 

    private void MoveForward()
    {
        transform.Translate(Vector3.forward * forwardSpeed);  
    }
 

    private void Jump()
    {
        if (isjump)
        {
            _rigidbody.velocity = Vector3.up * _jump;   //_jump*(0,1,0) by rigidbody method.
            isjump = false;
        }
    }
}
