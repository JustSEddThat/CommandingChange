using UnityEngine;
using System.Collections;

public class WaterLevel : MonoBehaviour 
{
	private float maxHeight;
	private Collider2D collide;

	public Vector3 origPos;
	public float max;
	public float colliderOrig;
    
	public float colliderNudge;
    public float colliderMax;
    
	int originalLayer;
    public Material frozen;
    public Material origional;

    void Start()
    {
        originalLayer = gameObject.layer;
        collide = GetComponent<Collider2D>();
        origPos = gameObject.transform.position;
        colliderOrig = GetComponent<Collider2D>().offset.y;
        colliderMax = colliderOrig + .5f;
		maxHeight = origPos.y + max;
    }

    void Update()
    {

        switch(GameController.weather)
        {
            case WeatherState.Rain:
                if (transform.position.y < maxHeight)
                    gameObject.transform.position += new Vector3(0, .01f, 0);
                if (transform.position.y > maxHeight || transform.position.y == maxHeight)
                    colliderMax += colliderNudge;
                break;
            case WeatherState.Cold:
                if (collide.offset.y < colliderMax)
                    collide.offset += new Vector2(0, .01f);
                if (collide.offset.y >= colliderMax)
                    gameObject.GetComponent<Water>().waterMode = Water.WaterMode.Reflective;
                gameObject.layer = 8;
                break;
            case WeatherState.Sunny:
                GetComponent<Water>().waterMode = Water.WaterMode.Refractive;
                gameObject.layer = originalLayer;
                while(collide.offset.y > colliderOrig)
                    collide.offset -= new Vector2(0, .01f);
                if (transform.position.y > origPos.y)
                    gameObject.transform.position -= new Vector3(0, .01f, 0);
                break; 
        }


        if (GetComponent<MeshRenderer>().material != frozen && GetComponent<Water>().waterMode == Water.WaterMode.Reflective)
            GetComponent<MeshRenderer>().material = new Material(frozen);
        else
            GetComponent<MeshRenderer>().material = new Material(origional);
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.layer == 9)
            Physics2D.IgnoreLayerCollision(4, 9);
    }
}

