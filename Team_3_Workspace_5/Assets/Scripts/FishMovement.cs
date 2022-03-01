using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishMovement : MonoBehaviour
{
    float moveSpeed;
    // Start is called before the first frame update
    void Start()
    {
        moveSpeed = Random.Range(1, 2);
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position += gameObject.transform.forward * moveSpeed * Time.deltaTime;
        if (Vector3.Distance(GameObject.FindGameObjectWithTag("Player").transform.position, transform.position) > 50)
        {
            Destroy(gameObject);
            SpawnFishScript.fishCount--;
        }
    }
}
