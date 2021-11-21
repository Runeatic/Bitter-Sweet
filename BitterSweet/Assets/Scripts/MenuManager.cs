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
	bool gamePaused;

	void Start()
	{
		menuObjects = GameObject.FindGameObjectsWithTag("Main Menu");
		creditObjects = GameObject.FindGameObjectsWithTag("Credits");
		pauseObjects = GameObject.FindGameObjectsWithTag("Pause Menu");
		dialogueObjects = GameObject.FindGameObjectsWithTag("Dialogue");
		hideCredits();
		hidePauseMenu();
		hideDialogue();
		gamePaused = true;
	}

	void Update()
	{
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			if (gamePaused == false)
			{
				hidePauseMenu();
				Debug.Log("p1");
			}
			else if (gamePaused == true)
			{
				showPauseMenu();
				Debug.Log("p2");
			}
		}
	}

	//Loads next level in build order
	public void loadLevel()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
	}

	//Exits game
	public void Quit()
	{
		Application.Quit();
		Debug.Log("booooooop");
	}

	//Main Menu Scene, displays credit UI elements
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

	//Main Menu Scene, hides credit UI elements
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

	//Gameplay Scenes, displays Pause Menu UI elements
	public void showPauseMenu()
	{
		Time.timeScale = 0;
		gamePaused = false;
		foreach (GameObject g in pauseObjects)
		{
			g.SetActive(true);
		}
	}

	//Gameplay Scenes, hides Pause Menu UI elements
	public void hidePauseMenu()
	{
		Time.timeScale = 1;
		gamePaused = true;
		foreach (GameObject g in pauseObjects)
		{
			g.SetActive(false);
		}
	}

	//Gameplay Scenes, shows Dialogue UI elements
	public void showDialogue()
    {
		Time.timeScale = 0;
		foreach (GameObject g in dialogueObjects)
        {
			g.SetActive(true);
        }
    }
	//Gameplay Scenes, hides Dialogue UI elements
	public void hideDialogue()
	{
		Time.timeScale = 1;
		foreach (GameObject g in dialogueObjects)
        {
			g.SetActive(false);
        }
	}
}
