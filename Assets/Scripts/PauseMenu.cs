using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class PauseMenu : MonoBehaviour {


	private bool pauseOn = false;
	private GameObject normalPanel;
	private GameObject pausePanel;

	void Awake()
	{
		normalPanel = GameObject.Find ("Canvas").transform.Find ("PauseButton").gameObject;
		pausePanel = GameObject.Find ("Canvas").transform.Find ("PauseInButton").gameObject;
	}
		

	public void ActivePauseButton()
	{
		if (!pauseOn) 
		{
			Time.timeScale = 0f;
			pausePanel.SetActive (true);
			normalPanel.SetActive (false);

		} 

		else 
		{
			Time.timeScale = 1.0f;
			pausePanel.SetActive (false);
			normalPanel.SetActive (true);
		}

		pauseOn = !pauseOn;
	}

	public void MenuButton()
	{
		Time.timeScale = 1.0f;
		SceneManager.LoadScene ("Title");
	}

	public void ExitButton()
	{
		PlayerPrefs.DeleteAll ();
		System.Diagnostics.Process.GetCurrentProcess ().Kill ();
	}
}
