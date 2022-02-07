using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightAreaScript : MonoBehaviour
{
    public static int inLightCount;
    private GameObject playerCam;
    // Start is called before the first frame update
    void Start()
    {
        inLightCount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player") {
            inLightCount++;
            Debug.Log("Player has entered the light, current light count: " + inLightCount);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player") {
            inLightCount--;
            Debug.Log("Player has left the light, current light count: " + inLightCount);
        }
    }
}
