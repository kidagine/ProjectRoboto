using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallScript : MonoBehaviour
{
    private Rigidbody2D rg2d;
    public float fallDelay;
    bool start = false;
    // Use this for initialization
    void Start()
    {
        rg2d = GetComponent<Rigidbody2D>();
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            start = true;
        }
    }
    void Update()
    {
        if (start == true)
        {
            StartCoroutine(Fall());
        }
    }
        // Update is called once per frame
        IEnumerator Fall() {
            yield return new WaitForSeconds(fallDelay);
        rg2d.isKinematic = false;
        yield return 0;
        }
    }
