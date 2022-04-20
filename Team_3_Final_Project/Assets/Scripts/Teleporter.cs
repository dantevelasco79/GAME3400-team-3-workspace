using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour
{
    public GameObject point1;
    public GameObject point2; 
    public GameObject player;
    public static float teleportBuffer = 0;
    // Start is called before the first frame update
    void Start()
    {
        if (player == null)
        {
            player = GameObject.FindWithTag("Player");
        }
        teleportBuffer = 0;
    }

    void Update() 
    {
        teleportBuffer += Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (teleportBuffer > 2f) {
            if (point1.Equals(this.gameObject))
            {
                player.transform.position = point2.transform.position;
            } 
            else 
            {
                player.transform.position = point1.transform.position;
            }
            teleportBuffer = 0;
        }
    }
}
