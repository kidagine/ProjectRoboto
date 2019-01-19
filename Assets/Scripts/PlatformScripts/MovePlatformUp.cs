using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlatformUp : MonoBehaviour {

    public float speed;
    private bool collidedPlayer;
	
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        collidedPlayer = true;
        other.collider.transform.SetParent(transform);
    }
    private void OnCollisionExit2D(Collision2D other)
    {
        other.collider.transform.SetParent(null);
    }
    // Update is called once per frame
    void Update () {
        if (collidedPlayer == true)
            transform.Translate(Vector2.up	 * speed * Time.deltaTime);
    }
}
