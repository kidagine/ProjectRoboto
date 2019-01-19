using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroling : MonoBehaviour
{
    public GameObject kamera;
    public float scrollSpeed = 0f;
    public static BackgroundScroling current;
    private bool verticalFirst = false;
    private bool verticalSecond = false;
    private bool verticalThird = false;
    private float verticalSpeed = 0f;
    private float yVelocity = 0.0F;

    private void Update()
    {
        GetComponent<Renderer>().material.mainTextureOffset = new Vector2((Time.time * scrollSpeed) % 1, (Time.time * verticalSpeed) % 1);
        if (Input.anyKey && verticalThird == false && PlayerHead.intro == false){
            verticalFirst = true; 
            verticalThird = true;
        }
        if (verticalFirst == true)
        {
            verticalSpeed = -2;
            StartCoroutine(StopFirst());
        }
        if (verticalSecond == true)
        {
            verticalSpeed = Mathf.Lerp(verticalSpeed, 0f, 0.05f);

            StartCoroutine(StopSecond());
            if (verticalSpeed <= 0)
            {
                PlayerHead.intro = true;
            }
        }
     
    }
            IEnumerator StopFirst()
            {
            yield return new WaitForSeconds(7f);
            verticalFirst = false;
            verticalSecond = true;
            yield return 0;
            }
            IEnumerator StopSecond()
            {
            yield return new WaitForSeconds(2f);
            verticalSecond = false;
            yield return 0;
            }
}
