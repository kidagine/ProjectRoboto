using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerticalPlatform : MonoBehaviour {

    public float speed;
    private static bool collidedPlayer;
    private bool swapVertical;
    // Use this for initialization
    void Start()
    {

    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player") || other.gameObject.CompareTag("PlayerHead"))
            collidedPlayer = true;
        other.collider.transform.SetParent(transform);      
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Power"))
            swapVertical = true;
        
        if (other.gameObject.CompareTag("Power2"))
            swapVertical = false;
    }
    private void OnCollisionExit2D(Collision2D other)
    {
        other.collider.transform.SetParent(null);
    }
    // Update is called once per frame
    void Update()
    {
        if (collidedPlayer == true)
        {

            if (swapVertical == true)
                transform.Translate(Vector2.up * speed * Time.deltaTime);
            if (swapVertical == false)
                transform.Translate(Vector2.down * speed * Time.deltaTime);
        }
    }
}
