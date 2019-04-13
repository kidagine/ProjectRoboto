    using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerPosHead : MonoBehaviour {

	public static bool IsPlayerHeadDead = false;

	private GameMaster gm;
	private Collider2D playerCollider;
	private bool death;
	private int knockbackTime = 1;

	[SerializeField] Vector2 launchPower;
	public PlayerMovementBasic playerMovementBasic;
	public int health = 3;
	public int attackDamage = 1000;
	public GameObject die;
	public float fallDelay = 1.5f;
	public GameObject prefabDeath;
	public Animator transitionAnim;
	public AudioSource deathSound;
	public static bool killPlayerHead;
	public static bool checkEnemySpawn;

	public Rigidbody2D rdd;
	private GameObject player;
	private GameObject playerHead;
	private PlayerHealth playerHealth;
	private Animator anim;

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
		//health--;
		float timer = 0;
		while (knockbackTime > timer)
		{
			timer += Time.deltaTime;
			rdd.AddForce(new Vector3(gameObject.transform.position.x - 1, -gameObject.transform.position.y * 50, transform.position.z));
		}
		if (health <= 0)
		{
			Instantiate(prefabDeath, transform.position, transform.rotation);
			Destroy(gameObject);
			IsPlayerHeadDead = true;
		}
	}
	
}

