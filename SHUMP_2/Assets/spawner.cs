using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner : MonoBehaviour
{

    public GameObject light_Enemy;

    public GameObject spawn_One;

    public GameObject spawn_Two;
    
    public int wave = 1;

    public int amount_Destroyed = 0; 
    
    private float spawn_Time = 6f;

    public bool wave_Enable = true;
    
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        print("spawn_Time is currently");
        
        print(spawn_Time);

        if (wave < 5)
        {

            print("Before the reset");

            if (spawn_Time <= 0 && amount_Destroyed == 2 || amount_Destroyed == 6 || amount_Destroyed == 12)
            {
                
                spawn_Time = 6f;

                wave_Enable = true;

            }

            print("Before the spawn");
            
            print("spawn_Time is");
            
            print(spawn_Time);
            
            if (spawn_Time == 6f && wave_Enable)
            {

                for (int counter = 0; counter < wave + 1; counter++)
                {

                    Instantiate(light_Enemy, new Vector3(Random.Range(-20.0f, 20.0f), 
                        spawn_One.GetComponent<Transform>().position.y, spawn_One.GetComponent<Transform>().position.z), Quaternion.identity);

                    Instantiate(light_Enemy, new Vector3(Random.Range(-20.0f, 20.0f), 
                        spawn_Two.GetComponent<Transform>().position.y, spawn_Two.GetComponent<Transform>().position.z), Quaternion.identity);

                }

                wave++;

            }
            
            wave_Enable = false;

            print("Subtracting time");

            spawn_Time -= Time.deltaTime;

        }
/*
        if (!wave_Enable)
        {

            switch (amount_Destroyed)
            {

                case 2:

                    wave++;

                    wave_Enable = true;

                    break;

                case 6:

                    wave++;

                    wave_Enable = true;

                    break;

                case 12:

                    wave++;

                    wave_Enable = true;

                    break;

            }

        }*/

    }
    
}
