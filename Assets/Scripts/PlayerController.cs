using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //public 
    public float speed;
    public int turnSpeed;
    public ParticleSystem dirtPirticl;
    public bool onGround = true;
    public bool gameOver = false;

    //private
    private Animator playerAnym;
    
        //Declares WASD
    private float horizontalInput;
    private float forwardInput;

        //Declares Rigidbody
    private Rigidbody playerRb;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        playerAnym = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
            //Gets Axis for WASD
        horizontalInput = Input.GetAxis("Horizontal");
            transform.Rotate(Vector3.up, turnSpeed * horizontalInput * Time.deltaTime);
        forwardInput = Input.GetAxis("Vertical");
            transform.Translate(Vector3.forward * Time.deltaTime * speed * forwardInput);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Ground"))
        {
            onGround = true;
            dirtPirticl.Play();
        }
        else if(collision.gameObject.CompareTag("Obstacle"))
        {
            gameOver = true;

            dirtPirticl.Stop();
        }
        
        
    }




}
