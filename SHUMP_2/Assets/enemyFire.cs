using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class enemyFire : MonoBehaviour
{

    public GameObject missile;

    private int hp = 100; 
    
    // Start is called before the first frame update
    void Start()
    {
        
        
        
    }

    // Update is called once per frame
    void Update()
    {
        
        
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.CompareTag("Player"))
        {
            
            if (other.GetComponent<test>().hp == 1)
            {

                print("Player is going to die!");
                
                GetComponentInParent<enemybehaviour_Light>().playerDead = true;

            }

            Instantiate(missile, transform);
            
        }
        
    }
    
}
