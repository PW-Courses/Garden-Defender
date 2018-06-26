using UnityEngine;
using System.Collections;

public class DefenderSpawner : MonoBehaviour {

	public Camera myCamera;
	private GameObject parent;
	private StarDisplay starDisplay;


	void Start()
	{	
		starDisplay = GameObject.FindObjectOfType<StarDisplay>();


		parent = GameObject.Find ("Defenders");
		if (parent == null)
		{
			parent = new GameObject("Defenders");
		}
	}


	void OnMouseDown()
	{
		//print (SnapToGrid (CalculateWorldPointOfMouseClick ()));
		if (Button.selectedDefender)
		{
			//Follow mouse position
			Vector2 rawPosition = CalculateWorldPointOfMouseClick();
			Vector2 roundedPosition = SnapToGrid(rawPosition);
			GameObject defender = Button.selectedDefender;

			//If enough stars 
			int defenderCost = defender.GetComponent<Defender>().starCost;
			if (starDisplay.UseStars (defenderCost) == StarDisplay.Status.SUCCESS)
			{
				//Spawn Defender on click
				GameObject newDefender = Instantiate (defender, roundedPosition, Quaternion.identity) as GameObject; //quat identity to 0 rotacji
				newDefender.transform.parent = parent.transform;
			} else {
				Debug.Log ("Insufficient stars to spawn");
			}

		}
	}

	Vector2 SnapToGrid (Vector2 rawWorldPos)
	{
		Vector2 roundedWorldPos = new Vector2((Mathf.RoundToInt(rawWorldPos.x)),
		                                  (Mathf.RoundToInt(rawWorldPos.y)));
		return roundedWorldPos;
	}


	Vector2 CalculateWorldPointOfMouseClick()
	{
		float mouseX = Input.mousePosition.x;
		float mouseY = Input.mousePosition.y;
		float distanceFromCamera = 10f; //whatever float works, its 2d so it doesnt matter

		Vector3 weirdTriplet = new Vector3 (mouseX,mouseY,distanceFromCamera);
		Vector2 worldPos = myCamera.ScreenToWorldPoint(weirdTriplet);

		return worldPos;
	}
}
