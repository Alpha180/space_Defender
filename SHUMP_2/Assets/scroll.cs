using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scroll : MonoBehaviour
{

    public int scroll_Speed;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
        transform.Translate(Vector2.down * scroll_Speed * Time.deltaTime);
        
    }

    private void OnTriggerExit2D(Collider2D other)
    {

        if (other.name == "resetScroll")
        {

            transform.position = new Vector3(0, 2.62f, 0);

        }

    }
    
}
