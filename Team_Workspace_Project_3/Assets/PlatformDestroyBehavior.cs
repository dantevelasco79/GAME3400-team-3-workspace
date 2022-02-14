using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformDestroyBehavior : MonoBehaviour
{
    public float secondUntilDestroy = 2;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("DestroyPlatform", secondUntilDestroy);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void DestroyPlatform()
    {
        Destroy(gameObject);
    }
}
