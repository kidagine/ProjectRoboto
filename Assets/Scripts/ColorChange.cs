using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ColorChange : MonoBehaviour
{

  

    private float resetTime;
    public float speed = 1.0f;

    float startTime;
    // Use this for initialization
    void Start()
    {
        startTime = Time.time;
      
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (DashMove.isReset == true)
            {
                float t = (Time.time - startTime) * speed;
           
            }
            
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (DashMove.isReset == true)
            {
                float t = (Time.time - startTime) * speed;
              
            }
            
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (DashMove.isReset == true)
            {
                float t = (Time.time - startTime) * speed;
             
            }
            
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            if (DashMove.isReset == true)
            {
                float t = (Time.time - startTime) * speed / 2;
              
            }
        }
        if (DashMove.isReset == false)
        {

            if (resetTime <= 1.5f)
            {
    
                resetTime += Time.deltaTime;
            }
            if (resetTime > 1.5f)
            {
                DashMove.isReset = true;
                Debug.Log("ready");
                resetTime = 0;
                float t = (Time.time - startTime) * speed;
              
            }
        }
    }
}