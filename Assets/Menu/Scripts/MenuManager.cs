using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
	public void toMainMenu()
	{
		SceneManager.LoadScene (0);

	}


	public void toCircuits()
	{
		SceneManager.LoadScene (1);

	}


	public void toVen()
	{
		SceneManager.LoadScene (2);

	}

	public void toTables()
	{
		SceneManager.LoadScene ("ttEnter");

	}


	public void Quit()
	{
		Application.Quit();

	}

}
