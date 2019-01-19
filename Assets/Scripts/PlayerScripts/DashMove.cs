    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashMove : MonoBehaviour
{

    private Rigidbody2D rb;
    public float dashSpeed;
    private float dashTime;
    public float startDashTime;
    private int direction;
    public static bool isReset;
   

    public BoxCollider2D player;
    public GameObject dashEffect;
    public Animator animator;



    // Use this for initialization
    void Start()
    {

        isReset = true;
        player = GetComponent<BoxCollider2D>();
        rb = GetComponent<Rigidbody2D>();
        dashTime = startDashTime;
    }
    void Update()
    {
     
        if (direction == 0)
        {
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                if (isReset == true)
                {
                    Instantiate(dashEffect, transform.position, Quaternion.identity);
                    direction = 1;
                    player.size = new Vector2(1f, .5f);
                    isReset = false;
                }
            }
            else if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                if (isReset == true)
                {
                    Instantiate(dashEffect, transform.position, Quaternion.identity);
                    direction = 2;
                    player.size = new Vector2(1f, .5f);
                    isReset = false;
                }
            }
            else if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                if (isReset == true)
                {
                    Instantiate(dashEffect, transform.position, Quaternion.identity);
                    direction = 3;
                    player.size = new Vector2(.5f, 1f);
                    isReset = false;
                }
            }
            else if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                if (isReset == true)
                {
                    Instantiate(dashEffect, transform.position, Quaternion.identity);
                    direction = 4;
                    player.size = new Vector2(.5f, 1f);
                    isReset = false;
                }
            }
        }
        else
        {
            if (dashTime <= 0)
            {
                player.size = new Vector2(1f, 1f);
                direction = 0;
                dashTime = startDashTime;
                rb.velocity = Vector2.zero;
            }
            else
            {
                dashTime -= Time.deltaTime;

                if (direction == 1)
                {
                    rb.velocity = Vector2.left * dashSpeed;
                    Debug.Log("error");
                }
                else if (direction == 2)
                {
                    rb.velocity = Vector2.right * dashSpeed;
                }
                else if (direction == 3)
                {
                    rb.velocity = Vector2.up * dashSpeed;
                }
                else if (direction == 4)
                {
                    rb.velocity = Vector2.down * dashSpeed;
                }



            }
        }
    }
}




