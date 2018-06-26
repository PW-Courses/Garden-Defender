using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour
{

	public float autoLoadNextLevelAfter;

	void Start()
	{
		if (autoLoadNextLevelAfter == 0) { 
			Debug.Log ("AutoLoad disabled");
		} else {
			Invoke ("LoadNextLevel", autoLoadNextLevelAfter);
		}
	}

	public void LoadLevel(string name)
	{
		Application.LoadLevel (name);
	}
	
	public void LoadNextLevel()
	{
		Application.LoadLevel (Application.loadedLevel + 1);
	}
	
	public void QuitGame()
	{
		Application.Quit ();
	}
}
