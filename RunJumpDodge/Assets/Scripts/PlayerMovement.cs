using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //vector3 for moveVelocity
    private Vector3 mV;
    //referencing the player controller
    private CharacterController playerController;
    //player speed
    public float playerSpeed = 6.0f;
    //vertical jump velocity
    private float vertVelo = 15f;
    //gravity
    private float gravity = 15f;
    //players jump power
    private float jumpPower = 15f;
    //is the player grounder? true/false
    private bool isGrounded;
    //setting a groundcheck
    public Transform groundCheck;
    //distance from the ground
    public float groundDist = 0.4f;
    //allowing access for the laymask to interact with code
    public LayerMask mask;

    // Start is called before the first frame update
    void Start()
    {
        //getting reference/component for the character controller on the player
        playerController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        //calling function
        moveGravity();
    }

    void moveGravity()
    {
        //creating a invisible sphere to check for the ground and checks the distance
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDist, mask);

        //resetting this every frame
        mV = Vector3.zero;

        //checking if the player is grounded
        if (playerController.isGrounded == false)
        {
            //if the player isn't grounded then apply physics
            mV += Physics.gravity;

            //checking if the player jumps and is grounded
            if(Input.GetKeyDown(KeyCode.Space) && isGrounded)
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
    public void IncreasedSpeed(int increaseSpeed)
    {
        playerSpeed = 6.0f + increaseSpeed;
    }

}
