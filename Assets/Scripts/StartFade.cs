using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartFade : MonoBehaviour
{

    public Image black;
    public Animator anim;
    void Start()
    {

    }
    void ForButton()
    {
            Destroy(gameObject);
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.anyKey)
        {
            ForButton();
        }
    }

    IEnumerator Fading()
    {
        anim.SetBool("Fade", true);
        yield return new WaitUntil(() => black.color.a == 1);

    }
}