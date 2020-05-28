using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Vector3 mV;
    private CharacterController playerController;

    public float playerSpeed = 6.0f;

    private float vertVelo = 15f;
    private float gravity = 15f;
    private float jumpPower = 15f;


    private Vector3 mD = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {
        //getting reference/component for the character controller on the player
        playerController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        moveGravity();
    }

    void moveGravity()
    {
        //resetting this every frame
        mV = Vector3.zero;

        //checking if the player is grounded
        if (playerController.isGrounded == false)
        {
            //if the player isn't grounded then apply physics
            mV += Physics.gravity;
            //checking if the player jumps
            if(Input.GetKeyDown(KeyCode.Space))
            {
                //setting the vertical velocity to the jump power
                vertVelo = jumpPower;
            }
            else
            {
                //taking gravity into account for the jump
                vertVelo -= gravity * Time.deltaTime;
            }
            //setting the axis of the vertical velocity then moving it with time
            Vector3 moveY = new Vector3(0, vertVelo, 0);
            playerController.Move(moveY * Time.deltaTime);

        }

        ///x,y,z
        //Left and right
        mV.x = Input.GetAxisRaw("Horizontal") * playerSpeed;


        //gravity
        playerController.Move(mV * Time.deltaTime);

        //forwards and back
        mV.z = playerSpeed;


        //making the player move fowards every second (not frame)
        playerController.Move((Vector3.forward * playerSpeed) * Time.deltaTime);
    }

    /// <summary>
    /// changing the player speed
    /// </summary>
    /// <param name="increaseSpeed"></param>
    public void IncreasedSpeed(float increaseSpeed)
    {
        playerSpeed = 5.0f + increaseSpeed;
    }

}
