using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
public class goalPickup : MonoBehaviour 
{
	public AudioClip goalSound;
	private AudioSource auSo;

	void Start()
	{
		auSo = gameObject.AddComponent<AudioSource> ();
		auSo.volume = .5f;
		auSo.clip = goalSound;
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            StartCoroutine(DelayLoad());
			auSo.Play ();
        }
    }



    IEnumerator DelayLoad()
    {
        yield return new WaitForSecondsRealtime(3f);
		if (SceneManager.GetActiveScene ().name.Equals ("5"))
			SceneManager.LoadScene ("Title");
		else
        	SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
    }

}
