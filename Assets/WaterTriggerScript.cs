using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterTriggerScript : MonoBehaviour 
{


	void OnParticleCollision(GameObject other)
	{

		transform.parent.GetComponent<WaterScript>().touchedByRain = true;
	}
}
