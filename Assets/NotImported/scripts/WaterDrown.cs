using UnityEngine;
using System.Collections;

public class WaterDrown : MonoBehaviour 
{

	// Use this for initialization
	void Start () 
    {
	
	}
	
	// Update is called once per frame
	void Update () 
    {
	
	}

    void OnTriggerStay2D(Collider2D other)
    {
      //  if (other.CompareTag("Player") && GameController.weather == WeatherState.Cold)
        //    other.gameObject.GetComponent<PlayerScript>().isFrozen = true;
    }


}
