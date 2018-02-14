using UnityEngine;
using System.Collections;

public class pressureButton : MonoBehaviour 
{
    public GameObject gate;

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Box")
        {
            Destroy(gate);
            Destroy(this.gameObject);  
        }
    }

}
