using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerScript : MonoBehaviour 
{

    public float maxSpeed = 5f;
    public float jumpSpeed = 5f;
    public bool isFrozen = false;
  //  public float health;
    bool holding;
    public GameObject held;
    Rigidbody2D rb;
    private Animator anim;
  

	// Use this for initialization
	void Start () 
    {
        holding = false;
        rb = gameObject.GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
		Physics2D.IgnoreLayerCollision (4, 9);
	}
	
	// Update is called once per frame
	void FixedUpdate () 
    {
        rb.WakeUp();
        if(rb.velocity.magnitude > maxSpeed)
            rb.velocity = rb.velocity.normalized*maxSpeed;
		
		if (!isFrozen)
		{
			Vector3 movement = new Vector3 (Input.GetAxis ("Horizontal") / 8, 0);
			transform.position += movement;
		}


        if (Input.GetAxis("Horizontal") < 0)
            GetComponent<SpriteRenderer>().flipX = true;
        else if(Input.GetAxis("Horizontal") > 0)
            GetComponent<SpriteRenderer>().flipX = false;

        switch(GameController.weather)
        {
			case WeatherState.Rain:
				anim.SetTrigger ("Rainy");
				isFrozen = false;
                rb.constraints = RigidbodyConstraints2D.None;
                rb.constraints = RigidbodyConstraints2D.FreezeRotation;
                break;
            case WeatherState.Cold:
                anim.SetTrigger("Freezing");
                if (isFrozen)
                    rb.constraints = RigidbodyConstraints2D.FreezeAll;
                else
                {
                    rb.constraints = RigidbodyConstraints2D.None;
                    rb.constraints = RigidbodyConstraints2D.FreezeRotation;
                }
                break;
			case WeatherState.Sunny:
				anim.SetTrigger ("Hot");
				isFrozen = false;
                rb.constraints = RigidbodyConstraints2D.None;
                rb.constraints = RigidbodyConstraints2D.FreezeRotation;
                break; 
        }
        
        if (holding)
	        if (Input.GetKeyUp(KeyCode.H) || Vector2.Distance(gameObject.transform.position, held.transform.position) >= 1f)
	        {
					
	            held.transform.parent = null;
	            holding = false;
	        }


        if (Input.GetKeyDown(KeyCode.UpArrow) && GetComponentInChildren<CircleCollider2D>().IsTouchingLayers(1<<8)&& !holding)
            rb.AddForce(new Vector2(0, jumpSpeed/Time.deltaTime));
	}

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Box") && Input.GetKey(KeyCode.H))
        {
            print("touching and holding");
			if (transform.childCount == 2)
					transform.GetChild (1).transform.parent = null;
			
            other.gameObject.transform.parent = gameObject.transform;
            holding = true;
            held = other.gameObject;
        }
            
    }  
}
