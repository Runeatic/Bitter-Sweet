using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
	GameObject[] menuObjects;
	GameObject[] pauseObjects;
	GameObject[] creditObjects;
	GameObject[] dialogueObjects;

	void Start()
	{
		Time.timeScale = 0;
		menuObjects = GameObject.FindGameObjectsWithTag("Main Menu");
		creditObjects = GameObject.FindGameObjectsWithTag("Credits");
		pauseObjects = GameObject.FindGameObjectsWithTag("Pause Menu");
		dialogueObjects = GameObject.FindGameObjectsWithTag("Dialogue");
		hideCredits();
		hidePauseMenu();
		hideDialogue();
	}

	void Update()
	{
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			Application.Quit();
			Debug.Log("booooooop");
		}
	}

	public void LoadLevel()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
	}

	public void Quit()
	{
		Application.Quit();
		Debug.Log("booooooop");
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

	public void showPauseMenu()
	{
		foreach (GameObject g in pauseObjects)
		{
			g.SetActive(true);
		}
	}

	public void hidePauseMenu()
	{
		foreach (GameObject g in pauseObjects)
		{
			g.SetActive(false);
		}
	}

	public void showDialogue()
    {
		foreach (GameObject g in dialogueObjects)
        {
			g.SetActive(true);
        }
    }

	public void hideDialogue()
	{
		foreach (GameObject g in dialogueObjects)
        {
			g.SetActive(false);
        }
	}
}
