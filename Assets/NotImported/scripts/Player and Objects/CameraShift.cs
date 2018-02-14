using UnityEngine;
using System.Collections;

public class CameraShift : MonoBehaviour 
{
    
    public GameObject mCam;
    private Camera mCamCamera;
	// Use this for initialization
	void Start () 
    {
        mCamCamera = mCam.GetComponent<Camera>();
	}
	
	// Update is called once per frame
	void Update () 
    {
	
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.gameObject.CompareTag("Player"))
        {
            float camBarrier = mCam.transform.position.x + mCamCamera.orthographicSize;
            float dist = Vector2.Distance(transform.position, new Vector2(camBarrier, mCam.transform.position.y));
            Vector2.MoveTowards(mCam.transform.position, new Vector2(transform.position.x, transform.position.y + dist),10);
        }
           
    }
}
