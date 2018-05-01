using UnityEngine;
using System.Collections;

public class pressureButton : MonoBehaviour 
{
    public GameObject gate;
	public AudioClip buttonSound;
	private AudioSource auSo;

	void Start()
	{
		auSo = GameObject.FindGameObjectWithTag("SFX").GetComponent<AudioSource> ();
		auSo.volume = .5f;
		auSo.clip = buttonSound;
	}

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Box")
        {
			auSo.Play ();
            Destroy(gate);
            Destroy(this.gameObject);  
        }
    }

}
