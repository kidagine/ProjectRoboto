using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformEmitter : MonoBehaviour {

    public GameObject platform;
    public float interval = 1f;
    public Vector2 velocity;


    // Use this for initialization
    void Start()
    {
        StartCoroutine(ShootIt());
    }

    // Update is called once per frame
    void Update()
    {

    }
  
    IEnumerator ShootIt()
    {
        while (true)
        {

            yield return new WaitForSeconds(interval);

            GameObject plat = (GameObject)Instantiate(platform, transform.position, Quaternion.identity);

            plat.GetComponent<Rigidbody2D>().velocity = velocity;

        }


    }
}
