using UnityEngine;
using System.Collections;

public class LoseCollider : MonoBehaviour {

	private LevelManager levelManager;

	void Start()
	{
		levelManager = GameObject.FindObjectOfType<LevelManager>();
	}
	void OnTriggerEnter2D (Collider2D collider)
	{
		print (collider.name + " entered lose collider");
		levelManager.LoadLevel("03b Lose");
	}
}
