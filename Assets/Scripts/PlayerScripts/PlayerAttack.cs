using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EZCameraShake;
public class PlayerAttack : MonoBehaviour {

    private bool attack;
    private float timeBtwAttack;
    public float startTimeBtwAttack;

    
    public Transform attackPos;
    public LayerMask whatIsEnemy;
    public Animator playerAnim;
    private float attackRange = 1.2f;
    public int damage;

    Rigidbody2D rdd;

    static public bool isAttacking = false;
    void Start()
    {
        rdd = GetComponent<Rigidbody2D>();
        playerAnim = GetComponent<Animator>();
    }
    void Update() {

        if (attack == true )
        {
          
        }

        if (timeBtwAttack <= 0)
        {

            if (Input.GetKey("j") || Input.GetKeyDown("joystick button 2"))
            {
               
                StartCoroutine(enableRange());
                playerAnim.SetBool("Attack", true);
            }
        }
        else
        {
            timeBtwAttack -= Time.deltaTime;
        }
    }
       
        IEnumerator enableMove()
        {
        yield return new WaitForSeconds(0.52f);
        playerAnim.SetBool("Attack", false);
        rdd.constraints = RigidbodyConstraints2D.None;
        rdd.constraints = RigidbodyConstraints2D.FreezeRotation;
        yield return 0;
        }
    IEnumerator enableRange()
    {
        yield return new WaitForSeconds(0.05f);
        EnableAttack();
        yield return 0;
    }



    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPos.position, attackRange);
    }
    void EnableAttack()
    {
        PlayerMovement.runSpeedHidden = 2;
        isAttacking = true;
        rdd.constraints = RigidbodyConstraints2D.FreezePositionX;
        StartCoroutine(enableMove());
        Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPos.position, attackRange, whatIsEnemy);
        for (int i = 0; i < enemiesToDamage.Length; i++)
        {
            enemiesToDamage[i].GetComponent<Enemy>().TakeDamage(damage);
        }
        timeBtwAttack = startTimeBtwAttack;

    }


} 
    

