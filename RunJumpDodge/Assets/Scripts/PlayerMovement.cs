using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Vector3 mV;
    private CharacterController playerController;

    public float playerSpeed = 6.0f;


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
}
