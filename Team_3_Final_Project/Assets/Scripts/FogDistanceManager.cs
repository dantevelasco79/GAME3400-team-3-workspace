using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FogDistanceManager : MonoBehaviour
{
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        if (player == null)
        {
            player = GameObject.FindWithTag("Player");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(player.transform.position, transform.position) < 200 + PlayerData.level * 10)
        {
            RenderSettings.fogDensity = 0.005f;
        }
        else
        {
            RenderSettings.fogDensity = 0.005f * (1 + (Vector3.Distance(player.transform.position, transform.position) - 199 - PlayerData.level * 10) * 0.02f);
        }
    }
}
