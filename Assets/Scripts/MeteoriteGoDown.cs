using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EZCameraShake;

    public class MeteoriteGoDown : MonoBehaviour {
    public bool start = false;
    public float speed = 5f;
    public GameObject impact;
    public GameObject player;
    public GameObject up;
    public GameObject left;
    public GameObject right;
    public GameObject explosion;
    bool doubleCheck = true;
    public static bool check = false;
    public static bool spawn = false;
    private Rigidbody rigidbody;

    void Start () {
        rigidbody = GetComponent<Rigidbody>();

    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Power" && doubleCheck == true){
            Instantiate(impact, new Vector3(-5.52f,0f,-2f), transform.rotation = Quaternion.identity);
            Instantiate(explosion, new Vector3(-5.44f, -0.8437524f, 0f), transform.rotation = Quaternion.identity);
            doubleCheck = false;
            check = false;
            spawn = true;
        }
        Destroy(gameObject);
    }
    void Update()
    {
        if (PlayerHead.tutorialDestroy == true)
        {

        }
        if (Input.anyKey)
        {
            CameraShaker.Instance.ShakeOnce(4f, 4f, .1f, 1f);

            check = true;
            start = true;
        }
        if (start == true)
        {
            rigidbody.useGravity = true;
        }
    }
}