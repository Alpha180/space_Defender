using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attack : MonoBehaviour
{

    public int missileSpeed;

    private bool enemy; 
    
    // Start is called before the first frame update
    void Start()
    {

        if (transform.parent.CompareTag("Enemy"))
        {

            enemy = true;
            
        }
        
        transform.parent = null; 

    }

    // Update is called once per frame
    void Update()
    {

        transform.Translate(Vector2.up * missileSpeed * Time.deltaTime);

        transform.Translate(Vector2.up * missileSpeed * Time.deltaTime);


    }
    
}
