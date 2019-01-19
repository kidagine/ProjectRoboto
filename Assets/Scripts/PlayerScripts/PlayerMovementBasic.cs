using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovementBasic : MonoBehaviour {
   
	public CharacterController2D controller;
    public Animator animator;
    public GameObject boarder;

    public float runSpeed = 1f;
    public float verticalVelocity = 5f;

    static public float runSpeedHidden;
    static public bool fallDeath = false;
    static public bool falling = false;

    private float horizontalMove = 0f;
    private float runningMove = 0f;
    private float jumpTimes = 2;
    private bool jump = false;
    private  bool crouch = false;
    private bool powerOne = false;
    private bool fallingDamage = false;

    PlayerMovement playerMovement;
    CharacterController2D charactercontroller;
    Rigidbody2D rdd;
    // Update is called once per frame
    void Start()
    {
        runSpeedHidden = runSpeed;
        rdd = GetComponent<Rigidbody2D>();
    }
 
    void Update () {

		if (PlayerHealth.currentHealth <= -1)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
		//Horizontal camera transition
		if (PlayerCameraManager.transistionHorizontal == false)
		{
			horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
		}
		else if (PlayerCameraManager.transistionHorizontal == true)
		{
			if (horizontalMove <= 0)
				horizontalMove = -15;
			if (horizontalMove >= 0)
				horizontalMove = 15;
		}
		//Vertical camera transition
		if (PlayerCameraManager.transistionVertical == false)
		{
			rdd.drag = 0;
			rdd.constraints = RigidbodyConstraints2D.None | RigidbodyConstraints2D.FreezeRotation;
		}
		else if (PlayerCameraManager.transistionVertical == true)
		{
			Invoke("DelayVerticalTransition", 0f);
		}
		//
            animator.SetFloat("Speed",Mathf.Abs(horizontalMove));
  
        {
            if (Input.GetButtonDown("Jump")) 
            {
             
                jump = true;     
                animator.SetBool("IsJumping", true);
         
            }
			if (rdd.velocity.y != 0)
			{
				animator.SetBool("IsJumping", true);
			}
			else
			{
				animator.SetBool("IsJumping", false);
			}
                
        }

	}
	private void DelayVerticalTransition()
	{
		rdd.drag = 20;
		rdd.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation;
	}
    public void OnLanding()
    {
        rdd.gravityScale = 3f;
        animator.SetBool("IsJumping", false);
        falling = false;
        animator.SetBool("IsFalling", false);
    }

	void FixedUpdate ()
	{
		// Move our character
		controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
		jump = false;
	}

    IEnumerator Fall()
    {
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        yield return 0;
    }
}
