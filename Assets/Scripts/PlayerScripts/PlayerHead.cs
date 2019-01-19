using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHead : MonoBehaviour
{

    public AudioSource walkSound;
    public AudioSource jumpSound;
    public CharacterControllerHead2D controller;
    public Animator animator;
    public GameObject player;
    public GameObject self;
    public GameObject power;
    public GameObject outerPower;
    public GameObject boarder;

    public float runSpeed = 20f;
    private float startTime = 0f;
    private float timer = 0;
    private float holdTime = 5.0f;
    private float horizontalMove = 0f;

    private bool cameraChange = false;
    private bool held = false;
    private bool jump = false;
    private bool crouch = false;
    private bool powerOne = false;

    public static bool intro = false;
    public static  bool tutorialDestroy = false;
    public static bool sphereIncrease = false;
    public static bool body = false;
    // Update is called once per frame
    void Awake()
    {
        boarder.SetActive(false);
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Power")
        {
            cameraChange = true;
        }
        if (intro == true)
            runSpeed = 20;
    }

    void OnCollisionExit2D(Collision2D col)
    {
        if (intro == true)
        runSpeed = 15;   
    }
    void Update()
    {
        if (CameraFollow.activateSecond == true)
            Destroy(gameObject);

        if (PlayerHealth.currentHealth <= -1){
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);}
        if (cameraChange == true)
        {
            powerOne = true;
            sphereIncrease = true;
            
            body = true;
            Destroy(self);
            Destroy(power);
            Destroy(outerPower);
        }
        if (PlayerCameraManager.cameraTransitionPlayer == false)
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));
        {
            if (Input.GetButtonDown("Jump"))
                
            startTime = Time.time;
                timer = startTime;
            if (Input.GetButton("Jump") && held == false)
            {
                timer += Time.deltaTime;
                    if (timer > (startTime + holdTime))
                    {
                     held = true;
                    tutorialDestroy = true;
                    jumpSound.Play();
                    jump = true;
                }
            }
        }
        if (Input.GetButtonDown("Crouch"))
            crouch = true;
        else if (Input.GetButtonUp("Crouch"))
            crouch = false;

    }
   
    public void OnLanding()
    {
        animator.SetBool("IsJumping", false);
    }
    public void OnCrouching(bool isCrouching)
    {
        animator.SetBool("IsCrouching", isCrouching);
    }
    void FixedUpdate()
    {
        // Move our character
        controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
        jump = false;
    }

    void playBoomSound()
    {
        jumpSound.Play();
    }
}



