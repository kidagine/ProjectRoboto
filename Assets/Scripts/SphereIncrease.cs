using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SphereIncrease : MonoBehaviour {
    public float fallDelay = 0.05f;

    public Material otherMaterial;
    bool destroyself = false;
    bool sphere = false;
    Transform target;

    // Use this for initialization
    void Start () {
        target = GameObject.Find("Power").transform;
        Renderer rend = GetComponent<Renderer>();
        rend.material.shader = Shader.Find("_Color");
        rend.material.SetColor("_Color", Color.green);
    
    }

    // Update is called once per frame
    void Update() {
        if (PlayerHead.sphereIncrease == true)
        {
            transform.localScale += new Vector3(1F, 1F, 0);
            StartCoroutine(Fall());
            gameObject.transform.rotation = target.transform.rotation;
        }

	}
    IEnumerator Fall()
    {
        yield return new WaitForSeconds(fallDelay);
        transform.localScale -= new Vector3(1F, 1F, 0);
        PlayerHead.sphereIncrease = false;
        StartCoroutine(DestroySphere());
        yield return 0;
    }
    IEnumerator DestroySphere()
    {
        yield return new WaitForSeconds(0.1f);
        Destroy(gameObject);
        yield return 0;
    }
}
