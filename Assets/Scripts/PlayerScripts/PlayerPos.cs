	using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerPos : MonoBehaviour
{


	public static bool IsPlayerDead = false;

	private GameMasterMain gm;

    public int attackDamage = 1000;
    public GameObject die;
    public float fallDelay = 1.5f;
	public GameObject prefabDeath;
    GameObject player;
    GameObject playerHead;
    PlayerHealth playerHealth;
    private bool death;
	private Collider2D playerCollider;

    private void Awake()
    {
        playerHead = GameObject.FindGameObjectWithTag("Player");
		playerCollider = GetComponent<Collider2D>();
    }

    void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GMmain").GetComponent<GameMasterMain>();
        transform.position = gm.lastCheckPointPosMain;
        PlayerHealth playerHealth = die.GetComponent<PlayerHealth>();
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Spikes")
			isDead();
    }
	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.tag == "KillPlayerHead")
			PlayerPosHead.killPlayerHead = true;
	}

	public void isDead()
	{
		Instantiate(prefabDeath, transform.position, transform.rotation);
		Destroy(gameObject);
		IsPlayerDead = true;
	}

}
