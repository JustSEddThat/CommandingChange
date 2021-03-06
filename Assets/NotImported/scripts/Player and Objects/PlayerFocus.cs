﻿using UnityEngine;
using System.Collections;

public class PlayerFocus : MonoBehaviour 
{
    public Transform player;
    public Transform left;
    public Transform right;

	// Use this for initialization
	void Start () 
    {
		// if no left and right boundaries for this level destroy script
		if (left == null && right == null)
			Destroy (this);
	}
	
	// Update is called once per frame
	void Update () 
    {
        Vector3 newPosition = transform.position;
        newPosition.x = player.position.x;
        newPosition.x = Mathf.Clamp(newPosition.x, left.position.x, right.position.x);
        transform.position = newPosition;
	}
}
