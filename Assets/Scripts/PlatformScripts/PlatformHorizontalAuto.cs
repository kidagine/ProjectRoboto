using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformHorizontalAuto : MonoBehaviour {

	private int speed = 3;
	private bool collidedPlayer;

	private void OnCollisionEnter2D(Collision2D other)
	{
		if (other.gameObject.CompareTag("Player") || (other.gameObject.CompareTag("PlayerHead")))
		{
			collidedPlayer = true;
			other.collider.transform.SetParent(transform);
		}
		
	}
	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.tag == "Wall")
			Flip();
	}
		private void OnCollisionExit2D(Collision2D other)
	{
		if (collidedPlayer == true)
		other.collider.transform.SetParent(null);
	}
	void Flip()
	{
		if (speed > 0)
			speed = -3;
		else if (speed < 0)
			speed = 3;
	}
	void Update () {
		transform.Translate(Vector2.right * speed * Time.deltaTime);
		if (PlayerCameraManager.cameraTransitionPlayer == true)
		{
			Destroy(gameObject);
		}
	}
}
