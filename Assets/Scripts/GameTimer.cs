using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameTimer : MonoBehaviour {

	public float levelSeconds = 100;

	private LevelManager levelManager;
	private Slider slider;
	private AudioSource audioSource;
	private bool isEndOfLevel = false;
	private GameObject winLabel;


	// Use this for initialization
	void Start () {
		levelManager = FindObjectOfType<LevelManager>();
		audioSource = GetComponent<AudioSource>();
		slider = GetComponent<Slider>();

		winLabel = GameObject.Find ("LevelCompletedText");
		if (!winLabel) {Debug.LogWarning ("Please create LevelCompleted object after beating a level");}
		winLabel.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {

		slider.value = Time.timeSinceLevelLoad / levelSeconds;

		bool timeIsUp = (Time.timeSinceLevelLoad >= levelSeconds);
		if (timeIsUp && !isEndOfLevel)
		{
			DestroyAllTaggedObjects();
			isEndOfLevel = true;
			winLabel.SetActive(true);
			audioSource.Play();
			Invoke ("LoadNextLevel", audioSource.clip.length);
		}
	}

	void DestroyAllTaggedObjects()
	{
		GameObject[] attackersWithTagsDestroyOnWin = GameObject.FindGameObjectsWithTag("destroyOnWin");

		foreach (GameObject attacker in attackersWithTagsDestroyOnWin)
		{
			Destroy(attacker);
		}
	}


	void LoadNextLevel()
	{
		levelManager.LoadNextLevel();
	}
}
