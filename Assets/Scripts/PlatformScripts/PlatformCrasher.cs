using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformCrasher : MonoBehaviour {

	public int speed = 6;
	private Vector3 originalPos;
	private Vector3 currentPos;
	private bool checkPlayer = false;
	private bool restorePos = false;

	public PlayerPos playerPos;
	// Use this for initialization
	void Start()
	{
		originalPos = gameObject.transform.position;
	}
	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.tag != "VC" && gameObject.transform.position == originalPos)
		{
			Debug.Log(other);
			Debug.Log("error2");
			Debug.Log(checkPlayer);
			checkPlayer = true;
		}
	}

	void OnCollisionEnter2D(Collision2D other)
	{
		if (other.gameObject.CompareTag("VC"))
		{
			Debug.Log("eoororo");
			restorePos = true;
			checkPlayer = false;
		}
		else if (other.gameObject.CompareTag("Enemy"))
		{
			other.gameObject.GetComponent<Enemy>().KillEnemy();
		}
		else
		{
			other.gameObject.GetComponent<PlayerPos>().isDead();
		}
	}
	void turnPosToFalse()
	{
		restorePos = false;
	}
	// Update is called once per frame
	void Update () {
		if (checkPlayer == true)
		{
			transform.Translate(Vector2.down * speed * Time.deltaTime);
		}
		if (restorePos == true)
		{
			transform.position = Vector3.MoveTowards(transform.position, originalPos,0.1f);
			
		}
		if (gameObject.transform.position == originalPos)
		{
			restorePos = false;
		}


	}
}
