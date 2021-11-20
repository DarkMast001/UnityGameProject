using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Acceleration_UI : MonoBehaviour
{
    protected float currentSpeed = 1.0f;

    public void OneX()
    {
        currentSpeed = 1.0f;
    }

    public void TwoX()
    {
        currentSpeed = 2.0f;
    }

    public void FiveX()
    {
        currentSpeed = 5.0f;
    }

    public void TenX()
    {
        currentSpeed = 10.1f;
    }

    private void Update()
    {
        if (currentSpeed == 1.0f)
        {
            Time.timeScale = 1.0f;
        }
        if (currentSpeed == 2.0f)
        {
            Time.timeScale = 2.0f;
        }
        if (currentSpeed == 5.0f)
        {
            Time.timeScale = 5.0f;
        }
        if (currentSpeed == 10.1f)
        {
            Time.timeScale = 10.1f;
        }
    }
}
