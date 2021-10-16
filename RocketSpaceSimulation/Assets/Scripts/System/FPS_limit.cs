using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPS_limit : MonoBehaviour
{
    void Start()
    {
        QualitySettings.vSyncCount = 1;
    }
}
