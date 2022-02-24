using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BlackCameraScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKeyDown) {
            SceneManager.LoadScene("SampleScene");
        }
    }
    void OnGUI()
    {
       GUI.Button(new Rect(200, 200, 300, 30), "You are lost. Press any key to retry.");
    }
}
