using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter(Collision other)
    {
        if (other.transform.CompareTag("Human") || other.transform.CompareTag("Player") || other.transform.CompareTag("Sheep"))
        {
            Destroy(other.gameObject);
        }
    }
}