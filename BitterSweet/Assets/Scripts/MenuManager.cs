using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
	GameObject[] menuObjects;
	GameObject[] pauseObjects;
	GameObject[] creditObjects;

	void Start()
	{
		Time.timeScale = 0;
		menuObjects = GameObject.FindGameObjectsWithTag("Main Menu");
		creditObjects = GameObject.FindGameObjectsWithTag("Credits");
		pauseObjects = GameObject.FindGameObjectsWithTag("Pause Menu");
		hideCredits();
	}

	//void Update()
	//{
	//	if (Input.GetKeyDown(KeyCode.Escape))
	//	{
	//		if (Time.timeScale == 1)
	//		{
	//			Time.timeScale = 0;
	//			showMenu();
	//		}
	//		else if (Time.timeScale == 0)
	//		{
	//			Debug.Log("game is go");
	//			Time.timeScale = 1;
	//			hideMenu();
	//		}
	//	}
	//}

	public void Quit()
	{
		Application.Quit();
	}

	public void showCredits()
	{
		foreach (GameObject g in creditObjects)
		{
			g.SetActive(true);
		}

		foreach (GameObject g in menuObjects)
		{
			g.SetActive(false);
		}
	}

	public void hideCredits()
	{
		foreach (GameObject g in creditObjects)
		{
			g.SetActive(false);
		}

		foreach (GameObject g in menuObjects)
		{
			g.SetActive(true);
		}
	}

	public void LoadLevel()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
	}
}
