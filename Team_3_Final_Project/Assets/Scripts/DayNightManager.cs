using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayNightManager : MonoBehaviour
{
    public Material day;
    public Material night;
    public Material rain;
    public Light light;

    public int weather;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (weather == 0){
            RenderSettings.skybox = day;
            light.intensity = 1.3f;
        } 
        else if (weather == 1){
            RenderSettings.skybox = rain;
            light.intensity = 0.8f;
        } 
        else {
            RenderSettings.skybox = night;
            light.intensity = 0f;
        }
    }
}
