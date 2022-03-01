using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnFishScript : MonoBehaviour
{
    public static int fishCount;
    public GameObject fishPrefab;
    float nextSpawn;
    // Start is called before the first frame update
    void Start()
    {
        fishCount = 0;
        nextSpawn = Random.Range(0, 2f);
    }

    // Update is called once per frame
    void Update()
    {
        if (nextSpawn > 0) 
        {
            nextSpawn -= Time.deltaTime;
        }
        else
        {
            Vector2 pos2D = Random.insideUnitCircle * 30;
            Vector3 pos3D = new Vector3(pos2D.x, 0, pos2D.y);
            pos2D = Random.insideUnitCircle * 360;
            GameObject fish = Instantiate(fishPrefab, pos3D, new Quaternion());
            fish.transform.Rotate(new Vector3(0, Random.Range(0, 360f), 0));
            nextSpawn = Random.Range(0, 2f);
            fishCount++;
        }
    }
}
