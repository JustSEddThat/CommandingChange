using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class GameController : MonoBehaviour 
{



    public float maxSpeed = 5f;
    private GameObject start;
    public GameObject rain;
    public GameObject sun;
    public GameObject snow;
	public static WeatherState weather; 
	public AudioSource sfxSource;
	public AudioClip WERChange;
	public AudioClip sunWER, rainWER, iceWER;

	//For scoring
	private float time;
	public Text timeText;
	private float weatherChanges;
	private string level;
	private AudioSource weatherAudio;


    void Start()
    {
        start = GameObject.FindGameObjectWithTag("StartMenu");
		if(start != null)
			start.SetActive(false);
		weather = WeatherState.Sunny;
        rain.SetActive(false);
        snow.SetActive(false);

		weatherAudio = GameObject.FindGameObjectWithTag ("Weather").GetComponent<AudioSource>();
		level = SceneManager.GetActiveScene ().name;




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
			{
				weather = WeatherState.Cold;
				weatherAudio.clip = iceWER;
			} 
			else if (weather == WeatherState.Cold) 
			{
				weather = WeatherState.Sunny;
				weatherAudio.clip = sunWER;
			} 
			else 
			{
				weather = WeatherState.Rain;
				weatherAudio.clip = rainWER;
			}

			weatherAudio.Play ();
			weatherChanges++;

			sfxSource.clip = WERChange;
			sfxSource.Play ();
        }

        if (Input.GetKeyDown(KeyCode.R))
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
		
		if (Input.GetKeyDown (KeyCode.P))
		{
			start.SetActive (true);
			Time.timeScale = 0;
		}      
    }

	void FixedUpdate()
	{
		time += Time.deltaTime;
		timeText.text = Mathf.Round (time)+ " seconds";

		if (start.activeSelf)
		if (Input.GetKey (KeyCode.Alpha0))
		if(Input.GetKeyUp(KeyCode.A))
			SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex + 1);
	}




}



