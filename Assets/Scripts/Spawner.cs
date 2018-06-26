using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {

	public GameObject[] attackerPrefabArray;


	void Update ()
	{
		foreach (GameObject thisAttacker in attackerPrefabArray)
		{
			if(isTimeToSpawn(thisAttacker)){
				Spawn (thisAttacker);
			}
		}
	}

	void Spawn (GameObject myGameObject)
	{
		GameObject myAttacker = Instantiate(myGameObject) as GameObject;
		myAttacker.transform.parent = this.transform;
		myAttacker.transform.position = this.transform.position;
	}

	bool isTimeToSpawn(GameObject attackerGameObject)
	{
		Attacker attacker = attackerGameObject.GetComponent<Attacker>();

		float meanSpawnDelay = attacker.spawnEverySeconds;
		float spawnsPerSecond = 1 / meanSpawnDelay;

		if (Time.deltaTime > meanSpawnDelay)
		{
			Debug.LogWarning ("Spawn rate capped by frame rate");
		} 

		float threshold = spawnsPerSecond * Time.deltaTime / 5;

		if (Random.value < threshold)
		{
			return true;
		} else {
			return false;
		}

	}

}



