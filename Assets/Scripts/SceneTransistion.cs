using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneTransistion : MonoBehaviour {

    public Animator transitionAnim;
    public string sceneName;
       void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
            transitionAnim.SetTrigger("end");
    }
        void OnTriggerEnter2D(Collider2D other)
        {
       
        StartCoroutine(LoadScene());
        }
	

    IEnumerator LoadScene()
    {
        transitionAnim.SetTrigger("end");
        yield return new WaitForSeconds(1.5f);
    
    }
}
