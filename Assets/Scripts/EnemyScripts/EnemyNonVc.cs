using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyNonVc : MonoBehaviour {

    private bool check = true;
    public bool headDeath;
    private bool facingRight = true;

    public int health;
	public float speed;

    public bool daze;
    public Animator anim;

	private Vector3 startingPos;
    private Rigidbody2D rdd;
    private Collider2D col;
    private Renderer rend;
	private Collider2D enemyCollider;

	void Start() {
		enemyCollider = GetComponent<Collider2D>();
		rdd = GetComponent<Rigidbody2D>();
		rend = GetComponent<Renderer>();
		startingPos = transform.position;
		speed = 1;
    }

    // Update is called once per frame
    void Update() {
        if (health <= 0 && check || headDeath == true && check)
        {            
            rdd.constraints = RigidbodyConstraints2D.FreezeAll;
			Invoke("KillEnemy", 0.1f);
            check = false;
        }
            transform.Translate(Vector2.right * speed * Time.deltaTime);

		if (PlayerCameraManager.cameraTransitionPlayer == true)
		{
			Destroy(gameObject);
		}
	}

	void OnCollisionEnter2D(Collision2D other)
	{
		if (other.gameObject.tag == "Wall")
			Flip();
	}

	void Flip(){
        if (speed > 0)
            speed = -1;
        else if (speed < 0)
            speed = 1;

        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
    public void TakeDamage(int damage){
        health -= damage;
    }
    public void Hurt()
    {
        Destroy(gameObject);
    }
	public void KillEnemy()
	{
		enemyCollider.isTrigger = true;
		speed = 0;
		anim.SetBool("Death", true);
		rdd.constraints = RigidbodyConstraints2D.FreezePositionY | RigidbodyConstraints2D.FreezePositionX;
		transform.position = new Vector2(transform.position.x, transform.position.y +0.5f);
		Destroy(gameObject, 0.5f);
	}
    } 

