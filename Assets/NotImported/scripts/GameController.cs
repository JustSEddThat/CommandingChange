using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
public class GameController : MonoBehaviour 
{

    public float maxSpeed = 5f;
    private GameObject start;
    public GameObject rain;
    public GameObject sun;
    public GameObject snow;
	public static WeatherState weather; 


    void Start()
    {
        start = GameObject.FindGameObjectWithTag("StartMenu");
        start.SetActive(false);
		weather = WeatherState.Sunny;
        rain.SetActive(false);
        snow.SetActive(false);
    }

    void Update()
    {
        switch(weather)
        {
            case WeatherState.Rain:
                rain.SetActive(true);
                sun.SetActive(false);
                snow.SetActive(false);
                break;
            case WeatherState.Cold:
                snow.SetActive(true);
                rain.SetActive(false);
                sun.SetActive(false);
                break;
            case WeatherState.Sunny:
                rain.SetActive(false);
                snow.SetActive(false);
                sun.SetActive(true);
                break;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (weather == WeatherState.Rain)
                weather = WeatherState.Cold;
            else if (weather == WeatherState.Cold)
                weather = WeatherState.Sunny;
            else
                weather = WeatherState.Rain;
        }

        if (Input.GetKeyDown(KeyCode.R))
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        if (Input.GetKeyDown(KeyCode.P))
            start.SetActive(true);
            
    }


}

