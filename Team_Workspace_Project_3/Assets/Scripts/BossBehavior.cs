using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBehavior : MonoBehaviour
{
    public GameObject player; 
    GameObject[] platforms;
    int state;
    float counter;
    // Start is called before the first frame update
    void Start()
    {
        state = 0;
        platforms = GameObject.FindGameObjectsWithTag("Platform");
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.RotateAround(gameObject.transform.position, Vector3.up, Time.deltaTime * 10);
        foreach (GameObject platform in platforms) {
            if (state == 1) {
                platform.GetComponent<Material>().color = Color.gray;
            }else if (state == 2) {
                platform.GetComponent<Material>().color = Color.blue;
            } else if (state == 3) {
                platform.GetComponent<Material>().color = Color.yellow;
            } else {
                platform.GetComponent<Material>().color = Color.white;
            }
        }
        if (counter > 80) {
            state = Random.Range(1, 3);
            counter -= Time.deltaTime;
        } else if (counter > 0) {
            state = 0;
            counter -= Time.deltaTime;
        } else {
            counter = 10;
            state = 0;
        }
    }
}
