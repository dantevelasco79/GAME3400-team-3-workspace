using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    public int debugLevel = 0;
    public static int level;
    void Update()
    {
        level = debugLevel;
    }
}
