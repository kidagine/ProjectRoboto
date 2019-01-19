using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovementHead : MonoBehaviour {
   
	public CharacterControllerHead2D controller;
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

    
	CharacterControllerHead2D charactercontroller;
    Rigidbody2D rdd;
    // Update is called once per frame
    void Start()
    {
        
        runSpeedHidden = runSpeed;
        rdd = GetComponent<Rigidbody2D>();
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("yes");
    }
 
    void Update () {
        if (PlayerHealth.currentHealth <= -1)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        if (PlayerHealth.disableSpeed == true)
        {
            //speed
        }
        if(PlayerCameraManager.cameraTransitionPlayer == false)
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
        if (Input.GetKey(KeyCode.LeftShift))

        {
            horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed * 1.15f;
            animator.SetBool("IsRunning", true);
             
        }
        if (!Input.GetKey(KeyCode.LeftShift))
        {
            animator.SetBool("IsRunning", false);
            
        }

            animator.SetFloat("Speed",Mathf.Abs(horizontalMove));
  
        {
            if (Input.GetButtonDown("Jump")) 
            {
             
                jump = true;     
                animator.SetBool("IsJumping", true);
                falling = true; 
            }
            if ( falling == true)
            {
                

            }
                
        }
     
       
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
   
    public void OnLanding()
    {
        if (fallingDamage == true)
        {
            PlayerHealth.currentHealth -= 10;
            Debug.Log("falldamage");
            PlayerHealth.healthSlider.value = PlayerHealth.currentHealth;
            fallingDamage = false;
            GetComponent<CharacterController>().enabled = false; 
        }

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
