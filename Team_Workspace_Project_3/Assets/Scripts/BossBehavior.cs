using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBehavior : MonoBehaviour
{
    public GameObject player;
    //public static int state;
    public int trapActiveLength = 5; // how long trap will be active
    public int trapDormentLength = 5; // how long trap will be dorment
    private float countDown;
    public static bool trapActive;
    // Start is called before the first frame update
    void Start()
    {
        //state = 0;
        trapActive = false;
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.RotateAround(gameObject.transform.position, Vector3.up, Time.deltaTime * 10);
        if (!trapActive) 
        {
            if (countDown > 0)
            {
                countDown -= Time.deltaTime;
            } 
            else 
            {
                //state = Random.Range(1, 4);
                countDown = trapDormentLength;
                trapActive = true;
            }
        }
        else 
        {
            if (countDown > 0) 
            {
                countDown -= Time.deltaTime;
            }
            else
            {
                //state = 0;
                countDown = trapDormentLength;
                trapActive = false;
            }
        }
    }
}
