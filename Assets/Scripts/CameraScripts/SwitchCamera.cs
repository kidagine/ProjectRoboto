using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchCamera : MonoBehaviour
{
    private float time = 1;
    private bool stuff = true;
	// Use this for initialization
	void Start()
	{
		Invoke("SetCameraFirst", 0.2f);
	}
	void SetCameraFirst()
	{
		CameraCompare.closestCamera.gameObject.transform.GetChild(0).gameObject.SetActive(true);
	}

    void FixedUpdate()
    {

			if (PlayerCameraManager.VC == true && stuff || PlayerCameraManager.VcVertical == true && stuff)
			{
				Debug.Log("tetetest");
				CameraCompare.closestCamera.gameObject.transform.GetChild(0).gameObject.SetActive(false);
				CameraCompare.closestVC.gameObject.transform.GetChild(0).gameObject.SetActive(true);
				StartCoroutine(Transition());
			}
			if (PlayerCameraManager.VC == true && !stuff || PlayerCameraManager.VcVertical == true && !stuff)
			{
				Debug.Log("tetetest22");
				CameraCompare.closestCamera.gameObject.transform.GetChild(0).gameObject.SetActive(true);
				CameraCompare.closestVC.gameObject.transform.GetChild(0).gameObject.SetActive(false);
				StartCoroutine(Transition2());
			}
    }
    IEnumerator Transition()
    {
        yield return new WaitForSeconds(time);
        stuff = false;
        yield return 0;
    }
    IEnumerator Transition2()
    {
        yield return new WaitForSeconds(time);
        stuff = true;
        yield return 0;
    }
}
