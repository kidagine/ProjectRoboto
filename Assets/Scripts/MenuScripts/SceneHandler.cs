﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneHandler : MonoBehaviour
{
	void Awake()
	{
		DontDestroyOnLoad(gameObject);
	}
	public void SaveScene()
	{
		int activeScene = SceneManager.GetActiveScene().buildIndex;

		PlayerPrefs.SetInt("ActiveScene", activeScene);
	}

	public void LoadScene()
	{
		int activeScene = PlayerPrefs.GetInt("ActiveScene");

		SceneManager.LoadScene(activeScene);
	}
}
