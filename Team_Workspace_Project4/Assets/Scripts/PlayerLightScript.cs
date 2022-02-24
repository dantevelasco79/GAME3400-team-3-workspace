using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLightScript : MonoBehaviour
{
    public Camera blackCam;
    private bool isLost;
    // Start is called before the first frame update
    void Start()
    {
        isLost = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (LightAreaScript.inLightCount == 0) {
            AudioListener.volume -= 0.001f;
            if (AudioListener.volume <= 0) {
                GameObject.FindGameObjectWithTag("MainCamera").SetActive(false);
                this.blackCam.gameObject.SetActive(true);
            }
        } else {
            AudioListener.volume = 1;
        }
    }
}
