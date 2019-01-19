using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHead : MonoBehaviour {
    private Enemy enemy;
    void Start () {
        Enemy enemy = gameObject.GetComponentInParent<Enemy>();
       
    }
	void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
            enemy.headDeath = true;
    }

}
