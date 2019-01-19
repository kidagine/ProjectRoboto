using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : PlayerMovementBasic {
   
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

	
     
       
        if (fallDeath == true)
        {
            StartCoroutine(Fall());
            fallDeath = false;
        }
		if (Input.GetButtonDown("Crouch"))
		{
			crouch = true;
		} else if (Input.GetButtonUp("Crouch"))
		{
			crouch = false;
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
    public void OnCrouching(bool isCrouching)
    {
        animator.SetBool("IsCrouching", isCrouching);
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
