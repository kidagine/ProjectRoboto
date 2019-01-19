using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour{


    public float speed = 11f;
    private bool start = false;
    private SpriteRenderer sprite;
    public GameObject target;
    public GameObject power;
    public GameObject cam1, cam2;
    public Animator anim;
    public GameObject player;
    public GameObject playerHead;
    int counter = 0;
	// Use this for initialization
	void Start () {
        GameObject target = gameObject.GetComponent<GameObject>();
        sprite = GetComponent<SpriteRenderer>();
        Animator anim = gameObject.GetComponent<Animator>();
    }
    void OnCollisionEnter()
    {
        CameraFollow.activateSecond = true;
        Destroy(gameObject);
    }
    // Update is called once per frame
    void Update()
    {
        StartCoroutine(targetCheck());
        float dist = Mathf.Abs(transform.position.x - target.transform.position.x);
        if (dist <= 1)
        {
            followPlayer();
        }
    }
 
    void followPlayer(){
            Destroy(anim);

            if (counter <= 16){
            transform.localScale -= new Vector3(0.05F, 0.05F, 0.05F);           
            counter++;}
            transform.position += transform.forward * 5 * Time.deltaTime;            
        }
    private void OnCollisionEnter2D(Collision2D collision){
        if (collision.gameObject.CompareTag("PlayerHead")) {
                StartCoroutine(selfDestroy());
        }
    }
    IEnumerator targetCheck(){
        yield return new WaitForSeconds(10f);
        GameObject target = gameObject.GetComponent<GameObject>();
        yield return 0;
    }
    IEnumerator selfDestroy(){
        yield return new WaitForSeconds(0.1f);
        anim.SetBool("start", true);
        Destroy(power);
        cam1.SetActive(false);
		Debug.Log("ahahaha");
        cam2.SetActive(true);
        Destroy(gameObject);
        yield return 0;
    }
}

