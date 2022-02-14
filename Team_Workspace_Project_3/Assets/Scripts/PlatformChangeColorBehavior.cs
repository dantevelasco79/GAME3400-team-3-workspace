using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformChangeColorBehavior : MonoBehaviour
{
    private int state;
    // Start is called before the first frame update
    void Start()
    {
        state = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (BossBehavior.trapActive && state == 0) 
        {
            state = Random.Range(1, 4);
        }
        else if (!BossBehavior.trapActive && state != 0)
        {
            state = 0;
        }
        if (state == 1)
        {
            gameObject.GetComponent<Renderer>().material.SetColor("_Color", Color.green);
        }
        else if (state == 2)
        {
            gameObject.GetComponent<Renderer>().material.SetColor("_Color", Color.gray);
        }
        else if (state == 3)
        {
            gameObject.GetComponent<Renderer>().material.SetColor("_Color", Color.red);
        } 
        else
        {
            gameObject.GetComponent<Renderer>().material.SetColor("_Color", Color.white);
        }
    }
}
