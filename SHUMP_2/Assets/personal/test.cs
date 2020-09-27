using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SceneManagement;

public class test : MonoBehaviour
{

    public GameObject missile;

    public GameObject flames;

    public GameObject lines;

    public AudioSource playerHit;

    private GameObject lives;

    public int playerSpeed;

    public int hp = 4;

    private int flash_Amount = 10;

    private float flash = 0.1f;

    private float CD = 0.5f; 
    
    private bool hit = false;

    private bool hit_CD = false;

    private float rotateSpeed = 100f; 

    // Start is called before the first frame update
    void Start()
    {

        name = name.Replace("playerShip(Clone)", "playerShip"); 
        
        lives = GameObject.Find("Lives"); 

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey(KeyCode.Escape))
        {

            SceneManager.LoadScene("Game"); 

        }
        
        if (hit_CD && CD > 0f)
        {

            CD -= Time.deltaTime;

        }
        else
        {

            hit_CD = false;

            CD = 0.5f; 

        }
        
        if (hit && flash_Amount > 0)
        {

            GetComponent<SpriteRenderer>().enabled = false;

            flames.GetComponent<SpriteRenderer>().enabled = false;

            lines.GetComponent<SpriteRenderer>().enabled = false;

            flash -= Time.deltaTime;

            if (flash <= 0)
            {

                GetComponent<SpriteRenderer>().enabled = true;

                flames.GetComponent<SpriteRenderer>().enabled = true;

                lines.GetComponent<SpriteRenderer>().enabled = true;

                flash = 0.1f;

                flash_Amount--;

            }

            if (flash_Amount == 0)
            {

                hit = false;

                flash_Amount = 10;

                GetComponent<BoxCollider2D>().enabled = true;

            }

        }
        
        if (hp <= 0)
        {

            lives.GetComponent<playerLives>().alive = false;
            
            Destroy(gameObject);
            
        }

        if (Input.GetKey(KeyCode.W))
        {

            transform.Translate(Vector2.down * playerSpeed * (Time.deltaTime));

        }
        else if (Input.GetKey(KeyCode.S))
        {

            transform.Translate(Vector2.up * playerSpeed * (Time.deltaTime));

        }
        else if (Input.GetKey(KeyCode.A))
        {

            transform.Translate(Vector2.right * playerSpeed * (Time.deltaTime));

        }
        else if (Input.GetKey(KeyCode.D))
        {

            transform.Translate(Vector2.left * playerSpeed * (Time.deltaTime));

        }

        if (Input.GetKeyDown(KeyCode.X) && !hit_CD)
        {

            Instantiate(missile, transform);

            hit_CD = true;

        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            
            transform.Rotate(0, 0, Input.GetAxis("Horizontal") * -rotateSpeed * Time.deltaTime);
            
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            
            transform.Rotate(0, 0, Input.GetAxis("Horizontal") * -rotateSpeed * Time.deltaTime);
            
        }
            
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {

        //print("Hit by enemy!");
        
        if (other.CompareTag("EnemyAttack"))
        {

            Destroy(other);
            
            hp--;

            hit = true;
            
            playerHit.Play();

            GetComponent<BoxCollider2D>().enabled = false;

        }
        
    }
    
}
