using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemybehaviour_Light : MonoBehaviour
{

    public Transform playerShip;

    public Rigidbody2D child;

    private GameObject enemySpawner; 
    
    private int hp = 4;

    public int speed = 3;

    public bool playerDead = false;
    
    // Start is called before the first frame update
    void Start()
    {

        enemySpawner = GameObject.Find("enemySpawner");
        
        playerShip = GameObject.Find("playerShip").transform;
        
        if (playerShip == null) playerDead = true;

    }

    // Update is called once per frame
    void Update()
    {

        transform.Translate(Vector2.up * speed * Time.deltaTime);
        
        if (playerDead)
        {

            playerShip = GameObject.Find("playerShip").transform;

            playerDead = false;

        }

        Vector3 direction = playerShip.position - transform.position;

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        GetComponent<Rigidbody2D>().rotation = angle - 90f;

        child.rotation = angle - 90f;

        if (hp == 0)
        {

            enemySpawner.GetComponent<spawner>().amount_Destroyed++; 
            
            Destroy(gameObject);
            
        }
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.CompareTag("PlayerMissile"))
        {

            GetComponent<AudioSource>().Play();
            
            hp--; 
            
            Destroy(other);

        }
        
    }
}
