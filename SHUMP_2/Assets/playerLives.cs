using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerLives : MonoBehaviour
{

    public GameObject player;

    public GameObject life2;

    public GameObject life3; 
    
    private int lives = 3;

    public bool alive = true;

    private float respawnTime = 2.0f;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (!alive)
        {

            if (!GetComponent<AudioSource>().isPlaying) GetComponent<AudioSource>().Play();

            respawnTime -= Time.deltaTime;

            if (respawnTime <= 0.0f)
            {
                
                Instantiate(player);

                alive = true;

                lives--;

                if (lives == 2)
                {
                    
                    Destroy(life2);
                    
                }
                else if (lives == 1)
                {
                    
                    Destroy(life3);
                    
                }

                respawnTime = 2.0f;

            }

        }
        
    }
}
