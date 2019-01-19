	using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerPos : MonoBehaviour
{

    private GameMasterMain gm;

    public int attackDamage = 1000;
    public GameObject die;
    public float fallDelay = 1.5f;
    public static bool playerDeath;
    Rigidbody2D rdd;
    public GameObject skeleton;
    public GameObject homunculus;
    GameObject player;
    GameObject playerHead;
    PlayerHealth playerHealth;
    Animator anim;
    public Animator transitionAnim;
    private bool death;
	private Collider2D playerCollider;

    private void Awake()
    {
        skeleton.SetActive(false);
        homunculus.SetActive(false);
        rdd = GetComponent<Rigidbody2D>();
        playerHead = GameObject.FindGameObjectWithTag("Player");
		playerCollider = GetComponent<Collider2D>();
        anim = GetComponent<Animator>();
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
		anim.SetBool("Death", true);
		death = true;
		playerCollider.enabled = false;
		StartCoroutine(Fall());
		StartCoroutine(LoadScene());
	}


    // Update is called once per frame
    void Update()
    {
        if (death == true)
        {
            GetComponent<PlayerMovement>().enabled = false;
            GetComponent<CharacterController2D>().enabled = false;
            rdd.constraints = RigidbodyConstraints2D.FreezePositionY | RigidbodyConstraints2D.FreezePositionX;
		}
    }
	IEnumerator Fall()
	{
		yield return new WaitForSeconds(fallDelay);
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
		yield return 0;
	}
	IEnumerator LoadScene()
    {
        yield return new WaitForSeconds(1);
        transitionAnim.SetTrigger("end");
        yield return new WaitForSeconds(1);
        skeleton.SetActive(true);
        homunculus.SetActive(true);
        yield return new WaitForSeconds(2.5f);
    }
}
