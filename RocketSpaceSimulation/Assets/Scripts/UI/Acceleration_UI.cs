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
        currentSpeed = 4.990f;
    }

    public void TenX()
    {
        currentSpeed = 9.999f;
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
        if (currentSpeed == 4.990f)
        {
            Time.timeScale = 4.999f;
        }
        if (currentSpeed == 9.999f)
        {
            Time.timeScale = 9.999f;
        }
    }
}
