using UnityEngine;
using System.Collections;

public class Shooter : MonoBehaviour
{

	public GameObject projectile, projectileParent, gun;
	private Animator animator;
	private Spawner myLaneSpawner;


	void Start()
	{	
		animator = GetComponent<Animator> ();

		
		projectileParent = GameObject.Find ("Projectiles");

		if (projectileParent == null) {
			projectileParent = new GameObject ("Projectiles");
		}


		SetMyLaneSpawner ();
		//print (myLaneSpawner);
	}


	void Update()
	{
		if (IsAttackerAheadInLane ()) {
			animator.SetBool ("isAttacking", true);
		} else {
			animator.SetBool ("isAttacking", false);
		}
	}


	// Look thru all spawnerts ,and set mylanespawner if found;
	void SetMyLaneSpawner()
	{
		Spawner[] spawnerArray = FindObjectsOfType<Spawner> ();

		foreach (Spawner spawner in spawnerArray) {
			if (spawner.transform.position.y == transform.position.y) {
				myLaneSpawner = spawner;
				return;
			}
		}

		Debug.LogError (name + " can't find spawner in his lane!");
	}

	private void Fire()
	{
		GameObject newProjectile = Instantiate (projectile) as GameObject;
		newProjectile.transform.parent = projectileParent.transform;
		newProjectile.transform.position = gun.transform.position;
	}

	bool IsAttackerAheadInLane()
	{
		//exit if no attackers in lane
		if (myLaneSpawner.transform.childCount <= 0) {
			return false;
		} 


		//if there are attackers, are they ahead?
		foreach (Transform attacker in myLaneSpawner.transform) {
			if (attacker.transform.position.x > transform.position.x && attacker.transform.position.x <= 10f) {
				return true;
			}
		}

		//attacker in lane but behind us.
		return false;
	}
}






















