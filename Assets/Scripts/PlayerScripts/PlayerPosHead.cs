    using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerPosHead : MonoBehaviour {

	private GameMaster gm;
	private Collider2D playerCollider;
	private bool death;

	public int attackDamage = 1000;
	public GameObject die;
	public float fallDelay = 1.5f;
	public GameObject skeleton;
	public GameObject homunculus;
	public Animator transitionAnim;
	public AudioSource deathSound;
	public static bool killPlayerHead;
	public static bool checkEnemySpawn;

	Rigidbody2D rdd;
	GameObject player;
	GameObject playerHead;
	PlayerHealth playerHealth;
	Animator anim;


	private void Awake()
	{
		skeleton.SetActive(false);
		homunculus.SetActive(false);
		rdd = GetComponent<Rigidbody2D>();
		playerHead = GameObject.FindGameObjectWithTag("PlayerHead");
		playerCollider = GetComponent<Collider2D>();
		anim = GetComponent<Animator>();
	}

	void Start () {
        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
        transform.position = gm.lastCheckPointPos;
        PlayerHealth playerHealth = die.GetComponent<PlayerHealth>();
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Spikes")
			isDead();
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
    void Update () {
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

