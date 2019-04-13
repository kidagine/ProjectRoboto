using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour {

	public Animator anim;

	void Update ()
	{
		if (PlayerPosHead.IsPlayerHeadDead || PlayerPos.IsPlayerDead)
		{
			anim.SetTrigger("end");
			Invoke("RestartScene", 2.5f);
		}
	}

	void RestartScene()
	{
		PlayerPosHead.IsPlayerHeadDead = false;
		PlayerPos.IsPlayerDead = false;
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}
}
