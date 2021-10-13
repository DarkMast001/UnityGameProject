using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistabceOBJ : MonoBehaviour
{
    //public float distanceBetweenObjects;

    public bool isConnected;
    public float distanceX;
    public float distanceY;
    public float distanceZ;

    public GameObject to_connect;
    public GameObject attachable;



    public void Update()
    {
        //distanceBetweenObjects = Vector3.Distance(point1.transform.position, point2.transform.position);
        distanceX = attachable.transform.position.x - to_connect.transform.position.x;
        distanceY = attachable.transform.position.y - to_connect.transform.position.y;
        distanceZ = attachable.transform.position.z - to_connect.transform.position.z;
        isConnected = false;
        if (distanceX > 0 && Mathf.Abs(distanceX) < 1.3 && Mathf.Abs(distanceY) < 0.5 && Mathf.Abs(distanceZ) < 0.5)
        {
            double newPosX = to_connect.transform.position.x;
            double newPosY = to_connect.transform.position.y;
            double newPosZ = to_connect.transform.position.z;
            attachable.transform.position = new Vector3((float)newPosX + 1, (float)newPosY, (float)newPosZ);
            isConnected = true;
        }
        if (distanceX < 0 && Mathf.Abs(distanceX) < 1.3 && Mathf.Abs(distanceY) < 0.5 && Mathf.Abs(distanceZ) < 0.5)
        {
            double newPosX = to_connect.transform.position.x;
            double newPosY = to_connect.transform.position.y;
            double newPosZ = to_connect.transform.position.z;
            attachable.transform.position = new Vector3((float)newPosX - 1, (float)newPosY, (float)newPosZ);
            isConnected = true;
        }

        if (distanceY > 0 && Mathf.Abs(distanceY) < 1.3 && Mathf.Abs(distanceX) < 0.5 && Mathf.Abs(distanceZ) < 0.5)
        {
            double newPosX = to_connect.transform.position.x;
            double newPosY = to_connect.transform.position.y;
            double newPosZ = to_connect.transform.position.z;
            attachable.transform.position = new Vector3((float)newPosX, (float)newPosY + 1, (float)newPosZ);
            isConnected = true;
        }
        if (distanceY < 0 && Mathf.Abs(distanceY) < 1.3 && Mathf.Abs(distanceX) < 0.5 && Mathf.Abs(distanceZ) < 0.5)
        {
            double newPosX = to_connect.transform.position.x;
            double newPosY = to_connect.transform.position.y;
            double newPosZ = to_connect.transform.position.z;
            attachable.transform.position = new Vector3((float)newPosX, (float)newPosY - 1, (float)newPosZ);
            isConnected = true;
        }

        if (distanceZ > 0 && Mathf.Abs(distanceZ) < 1.3 && Mathf.Abs(distanceY) < 0.5 && Mathf.Abs(distanceX) < 0.5)
        {
            double newPosX = to_connect.transform.position.x;
            double newPosY = to_connect.transform.position.y;
            double newPosZ = to_connect.transform.position.z;
            attachable.transform.position = new Vector3((float)newPosX, (float)newPosY, (float)newPosZ + 1);
            isConnected = true;
        }
        if (distanceZ < 0 && Mathf.Abs(distanceZ) < 1.3 && Mathf.Abs(distanceY) < 0.5 && Mathf.Abs(distanceX) < 0.5)
        {
            double newPosX = to_connect.transform.position.x;
            double newPosY = to_connect.transform.position.y;
            double newPosZ = to_connect.transform.position.z;
            attachable.transform.position = new Vector3((float)newPosX, (float)newPosY, (float)newPosZ - 1);
            isConnected = true;
        }
    }
}
