using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraCompare : MonoBehaviour {

	public static NonVCMove closestCamera = null;
	public static VCmove closestVC = null;
	// Update is called once per frame
	void Update () {
		FindClosestCamera();
		FindClosestVR();
	}

	void FindClosestCamera()
	{
		float distanceToClosestCamera = Mathf.Infinity;

		NonVCMove[] allCameras = GameObject.FindObjectsOfType<NonVCMove>();

		foreach (NonVCMove currentCamera in allCameras)
		{
			float distanceToCamera = (currentCamera.transform.position - this.transform.position).sqrMagnitude;
			if (distanceToCamera < distanceToClosestCamera)
			{
				distanceToClosestCamera = distanceToCamera;
				closestCamera = currentCamera;
			}
		}
		Debug.DrawLine(this.transform.position, closestCamera.transform.position);
	}

	void FindClosestVR()
	{
		float distanceToClosestCamera = Mathf.Infinity;

		VCmove[] allCameras = GameObject.FindObjectsOfType<VCmove>();

		foreach (VCmove currentCamera in allCameras)
		{
			float distanceToCamera = (currentCamera.transform.position - this.transform.position).sqrMagnitude;
			if (distanceToCamera < distanceToClosestCamera)
			{
				distanceToClosestCamera = distanceToCamera;
				closestVC = currentCamera;
			}
		}
		Debug.DrawLine(this.transform.position, closestVC.transform.position);
	}
}
