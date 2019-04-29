using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuUI : MonoBehaviour
{
	public GameObject helpMenu;
	public GameObject panelMenu;

	private void Start()
	{
		panelMenu.SetActive(true);
		helpMenu.SetActive(false);
	}

	public void StartGame()
	{
		SceneManager.LoadScene("SampleScene");
	}

	public void Help()
	{
		panelMenu.SetActive(false);
		helpMenu.SetActive(true);
	}

	public void CloseHelp()
	{
		panelMenu.SetActive(true);
		helpMenu.SetActive(false);
	}

	public void Quit()
	{
		Application.Quit();
	}
}
