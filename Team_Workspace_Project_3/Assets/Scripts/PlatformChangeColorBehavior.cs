using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformChangeColorBehavior : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<Renderer>().material.SetColor("_Color", Color.red);
    }

    // Update is called once per frame
    void Update()
    {
        if (BossBehavior.state == 1)
        {
            gameObject.GetComponent<Renderer>().material.SetColor("_Color", Color.gray);
        }
        else if (BossBehavior.state == 2)
        {
            gameObject.GetComponent<Renderer>().material.SetColor("_Color", Color.blue);
        }
        else if (BossBehavior.state == 3)
        {
            gameObject.GetComponent<Renderer>().material.SetColor("_Color", Color.yellow);
        }
        else
        {
            gameObject.GetComponent<Renderer>().material.SetColor("_Color", Color.white);
        }
    }
}
