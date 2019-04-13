using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPush : MonoBehaviour {
    private bool moveVertical = true;
	private bool moveHorizontal = true;
	private float distanceHorizontal = 25.3f;
	private float distanceVertical = 10.3f;
    private float timeHorizontal = 1f;
	private float timeVertical = 1.5f;
	private float timez = 0f;
    // Update is called once per frame
    void FixedUpdate() {
		//Right
        if (PlayerCameraManager.transition && moveHorizontal == true)
        {
			PlayerCameraManager.VC = false;
			PlayerCameraManager.VcVertical = false;
			transform.Translate(Vector3.left * Time.deltaTime * 1.5f * distanceHorizontal);
            StartCoroutine(TransitionHorizontal());
        }
        else if (PlayerCameraManager.transition && moveHorizontal == false)
        {
			PlayerCameraManager.VC = false;
			PlayerCameraManager.VcVertical = false;
			transform.Translate(Vector3.right * Time.deltaTime * 1.5f * distanceHorizontal);
            StartCoroutine(TransitionHorizontal2());
        }
		//Left
        if (PlayerCameraManager.transitionLeft && moveHorizontal == true)
        {
			PlayerCameraManager.VC = false;
			PlayerCameraManager.VcVertical = false;
			transform.Translate(Vector3.right * Time.deltaTime * 1.5f * distanceHorizontal);
            StartCoroutine(TransitionHorizontal());
        }
        else if (PlayerCameraManager.transitionLeft && moveHorizontal == false)
        {
			PlayerCameraManager.VC = false;
			PlayerCameraManager.VcVertical = false;
			transform.Translate(Vector3.left * Time.deltaTime * 1.5f * distanceHorizontal);
            StartCoroutine(TransitionHorizontal2());
        }
		//Up
		if (PlayerCameraManager.transitionUp && moveVertical == true)
		{
			PlayerCameraManager.VC = false;
			PlayerCameraManager.VcVertical = false;
			transform.Translate(Vector3.down * Time.deltaTime * 1.8f * distanceVertical);
			StartCoroutine(TransitionVertical());
		}
		else if (PlayerCameraManager.transitionUp && moveVertical == false)
		{
			PlayerCameraManager.VC = false;
			PlayerCameraManager.VcVertical = false;
			transform.Translate(Vector3.up * Time.deltaTime * 1.8f * distanceVertical);
			StartCoroutine(TransitionVertical2());
		}
		//Down
		if (PlayerCameraManager.transitionDown && moveVertical == true)
		{
			PlayerCameraManager.VC = false;
			PlayerCameraManager.VcVertical = false;
			transform.Translate(Vector3.up * Time.deltaTime * 1.8f * distanceVertical);
			StartCoroutine(TransitionVertical());
		}
		else if (PlayerCameraManager.transitionDown && moveVertical == false)
		{
			PlayerCameraManager.VC = false;
			PlayerCameraManager.VcVertical = false;
			transform.Translate(Vector3.down * Time.deltaTime * 1.8f * distanceVertical);
			StartCoroutine(TransitionVertical2());
		}
	}
    IEnumerator TransitionVertical()
    {
        yield return new WaitForSeconds(timeVertical);
		moveVertical = false;
        yield return 0;
    }
    IEnumerator TransitionVertical2()
    {
        yield return new WaitForSeconds(timeVertical);
		moveVertical = true;
        yield return 0;
    }

	IEnumerator TransitionHorizontal()
	{
		yield return new WaitForSeconds(timeHorizontal);
		moveHorizontal = false;
		yield return 0;
	}
	IEnumerator TransitionHorizontal2()
	{
		yield return new WaitForSeconds(timeHorizontal);
		moveHorizontal = true;
		yield return 0;
	}
}
