using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterScript : MonoBehaviour 
{
	// Children of Water Origin. WaterTop is child of Water GO

	// Make sure to adjust x position of waterCollider per level manually
	public GameObject water;
	private Sprite waterSprite;
	public Color32 waterColor;
	public Transform waterTop, waterCollider, waterLimit;

	public float colliderOffsetIncrement;
	private float colliderOffset;

	public bool touchedByRain;

	public Color32 iceColor;
	public Sprite iceSprite;

	// Use this for initialization
	void Start () 
	{
		waterSprite = water.GetComponent<SpriteRenderer> ().sprite;

	
	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{
		colliderOffset = waterTop.position.y - colliderOffsetIncrement;


		switch(GameController.weather)
		{

			case WeatherState.Rain:
				if (water.GetComponent<SpriteRenderer> ().sprite != waterSprite)
				{
					water.GetComponent<SpriteRenderer> ().sprite = waterSprite;
					water.GetComponent<SpriteRenderer> ().color = waterColor;
				}
					
				if (touchedByRain)
				{

					//Build Water Level up to the limit
					if (waterTop.position.y < waterLimit.position.y)
						water.transform.localScale = new Vector3 (water.transform.localScale.x, water.transform.localScale.y + .001f);

					if (waterCollider.position.y != colliderOffset)
						waterCollider.position = new Vector3 (waterCollider.position.x, colliderOffset);
				}

			waterCollider.gameObject.layer = 4;
				break;
			case WeatherState.Cold:
				if (water.GetComponent<SpriteRenderer> ().sprite != iceSprite)
				{
					water.GetComponent<SpriteRenderer> ().sprite = iceSprite;
					water.GetComponent<SpriteRenderer> ().color = iceColor;
				}
				if (waterCollider.position.y < waterTop.position.y - .55f)
					waterCollider.position = new Vector3 (waterCollider.position.x, waterCollider.position.y + .005f);
				waterCollider.gameObject.layer = 8;
				touchedByRain = false;
				break;
			case WeatherState.Sunny:
				if (water.GetComponent<SpriteRenderer> ().sprite != waterSprite)
				{
					water.GetComponent<SpriteRenderer> ().sprite = waterSprite;
					water.GetComponent<SpriteRenderer> ().color = waterColor;
				}
				if (waterTop.position.y > transform.position.y + .2f)
					water.transform.localScale = new Vector3 (water.transform.localScale.x, water.transform.localScale.y - .001f);

				if (waterCollider.position.y != colliderOffset)
					waterCollider.position = new Vector3 (waterCollider.position.x, colliderOffset);
				touchedByRain = false;
				waterCollider.gameObject.layer = 4;
				break; 
		}
	}

}
