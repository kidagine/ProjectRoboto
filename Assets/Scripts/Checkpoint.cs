using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour{
    private GameMasterMain gmMain;
    private GameMaster gm;
    public Animator animator;
    public BoxCollider2D boxCollider;
    public GameObject other;
    void Start(){
    gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
    gmMain = GameObject.FindGameObjectWithTag("GMmain").GetComponent<GameMasterMain>();
    }
    void OnCollisionEnter2D(Collision2D  other){
        if (other.gameObject.tag == "Player"|| other.gameObject.tag == "PlayerHead") { 
            animator.SetTrigger("active");
            StartCoroutine(disableCol());
            if (CameraFollow.activateSecond == true) 
            gmMain.lastCheckPointPosMain = transform.position;
            gm.lastCheckPointPos = transform.position;
        }
    }
    IEnumerator disableCol(){
        yield return new WaitForSeconds(0.2f);
        Destroy(other);
        GetComponent<BoxCollider2D>().enabled = false;
        yield return 0; 
    }
}
