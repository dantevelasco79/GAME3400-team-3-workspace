using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FogManager : MonoBehaviour
{
    public GameObject player;
    public Color normalColor;
    public Color targetColor;

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
        if (Vector3.Distance(player.transform.position, transform.position) < 600)
        {
            RenderSettings.fogColor = Color.Lerp(normalColor, targetColor, (600f - Vector3.Distance(player.transform.position, transform.position)) / 600f);
        }
        else
        {
            RenderSettings.fogColor = normalColor;
        }
    }
}
