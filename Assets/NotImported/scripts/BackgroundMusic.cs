﻿using UnityEngine;
using System.Collections;

public class BackgroundMusic : MonoBehaviour 
{
    public static BackgroundMusic instance = null;
    void Awake()
    {
        DontDestroyOnLoad(gameObject);
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);
    }
	// Use this for initialization
	void Start () 
    {
        
	}
	
	// Update is called once per frame
	void Update () 
    {
	
	}
}
