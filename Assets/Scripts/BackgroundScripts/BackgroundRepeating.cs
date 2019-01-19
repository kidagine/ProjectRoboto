using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundRepeating : MonoBehaviour {

    private float groundHorizontalLenght = 23;
    public GameObject player;
    private Transform cam;
    private Vector3 previousCamPos;

    // Use this for initialization
    void Start()
    {

        cam = Camera.main.transform;

        previousCamPos = cam.position;
    }
    private void Awake () {
        player = GetComponent<GameObject>();
        
	}

    // Update is called once per frame
    void Update() {
        if (transform.position.x < -23  )
        {
            repositionBackground();
        }
	}

    private void repositionBackground()
    {
        Vector2 groundOffset = new Vector2(groundHorizontalLenght * 2f, 0);
        transform.position = (Vector2)transform.position + groundOffset;
    }
}
