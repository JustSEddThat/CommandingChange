using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterScript : MonoBehaviour 
{
	// Children of Water Origin. WaterTop is child of Water GO

	// Make sure to adjust x position of waterCollider per level manually
	public GameObject water;
	public Transform waterTop, waterCollider, waterLimit;

	public float colliderOffsetIncrement;
	private float colliderOffset;


	// Use this for initialization
	void Start () 
	{


	
	}
	
	// Update is called once per frame
	void Update () 
	{
		colliderOffset = waterTop.position.y - colliderOffsetIncrement;


		switch(GameController.weather)
		{

		case WeatherState.Rain:
			//Build Water Level up to the limit
			if (waterTop.position.y < waterLimit.position.y)
				water.transform.localScale = new Vector3 (water.transform.localScale.x, water.transform.localScale.y + .001f);

			if (waterCollider.position.y != colliderOffset)
				waterCollider.position = new Vector3 (waterCollider.position.x, colliderOffset);
			waterCollider.gameObject.layer = 4;
				break;
		case WeatherState.Cold:
			if (waterCollider.position.y < waterTop.position.y - .55f)
				waterCollider.position = new Vector3 (waterCollider.position.x, waterCollider.position.y + .005f);
			waterCollider.gameObject.layer = 8;
				break;
		case WeatherState.Sunny:
			if (waterTop.position.y > transform.position.y + .2f)
				water.transform.localScale = new Vector3 (water.transform.localScale.x, water.transform.localScale.y - .001f);

			if (waterCollider.position.y != colliderOffset)
				waterCollider.position = new Vector3 (waterCollider.position.x, colliderOffset);

			waterCollider.gameObject.layer = 4;
				break; 
		}
	}

}
