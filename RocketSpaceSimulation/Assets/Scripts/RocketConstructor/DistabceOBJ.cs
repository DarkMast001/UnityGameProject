using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DistabceOBJ : MonoBehaviour
{
    public bool isConnected;
    public float distanceX;
    public float distanceY;
    public float distanceZ;

    public GameObject to_connect;
    GameObject nearest;
    public GameObject[] elements;
    GameObject mainShuttle;

    public bool isEngineHas = false;

    private void Start()
    {
        elements = GameObject.FindGameObjectsWithTag("Support");
        mainShuttle = GameObject.FindGameObjectWithTag("Main_shuttle");
    }

    GameObject FindNearestObj()
    {
        float distance = Mathf.Infinity;
        Vector3 position = transform.position;
        foreach(GameObject go in elements)
        {
            Vector3 diff = go.transform.position - position;
            float curDistance = diff.sqrMagnitude;
            if(curDistance < distance)
            {
                nearest = go;
                distance = curDistance;
            }
        }
        return nearest;
    }

    private void Update()
    {
        //transform.parent = mainShuttle.transform;
        to_connect = FindNearestObj();
        distanceX = transform.position.x - to_connect.transform.position.x;
        distanceY = transform.position.y - to_connect.transform.position.y;
        distanceZ = transform.position.z - to_connect.transform.position.z;
        isConnected = false;
        foreach (Transform child in GetComponentsInChildren<Transform>())
        {
            //print(child.name);
            if (child.name == "Engine_1(Clone)" || child.name == "Engine_2(Clone)")
            {
                isEngineHas = true;
                //print(1);
            }
        }
        if (distanceX > 0 && Mathf.Abs(distanceX) < 1.3 && Mathf.Abs(distanceY) < 0.5 && Mathf.Abs(distanceZ) < 0.5)
        {
            double newPosX = to_connect.transform.position.x;
            double newPosY = to_connect.transform.position.y;
            double newPosZ = to_connect.transform.position.z;
            transform.position = new Vector3((float)newPosX + 1, (float)newPosY, (float)newPosZ);
            transform.parent = to_connect.transform;
            isConnected = true;
        }
        if (distanceX < 0 && Mathf.Abs(distanceX) < 1.3 && Mathf.Abs(distanceY) < 0.5 && Mathf.Abs(distanceZ) < 0.5)
        {
            double newPosX = to_connect.transform.position.x;
            double newPosY = to_connect.transform.position.y;
            double newPosZ = to_connect.transform.position.z;
            transform.position = new Vector3((float)newPosX - 1, (float)newPosY, (float)newPosZ);
            transform.parent = to_connect.transform;
            isConnected = true;
        }

        if (distanceY > 0 && Mathf.Abs(distanceY) < 1.3 && Mathf.Abs(distanceX) < 0.5 && Mathf.Abs(distanceZ) < 0.5)
        {
            double newPosX = to_connect.transform.position.x;
            double newPosY = to_connect.transform.position.y;
            double newPosZ = to_connect.transform.position.z;
            transform.position = new Vector3((float)newPosX, (float)newPosY + 1, (float)newPosZ);
            transform.parent = to_connect.transform;
            isConnected = true;
        }
        if (distanceY < 0 && Mathf.Abs(distanceY) < 1.3 && Mathf.Abs(distanceX) < 0.5 && Mathf.Abs(distanceZ) < 0.5)
        {
            double newPosX = to_connect.transform.position.x;
            double newPosY = to_connect.transform.position.y;
            double newPosZ = to_connect.transform.position.z;
            transform.position = new Vector3((float)newPosX, (float)newPosY - 1, (float)newPosZ);
            transform.parent = to_connect.transform;
            isConnected = true;
        }

        if (distanceZ > 0 && Mathf.Abs(distanceZ) < 1.3 && Mathf.Abs(distanceY) < 0.5 && Mathf.Abs(distanceX) < 0.5)
        {
            double newPosX = to_connect.transform.position.x;
            double newPosY = to_connect.transform.position.y;
            double newPosZ = to_connect.transform.position.z;
            transform.position = new Vector3((float)newPosX, (float)newPosY, (float)newPosZ + 1);
            transform.parent = to_connect.transform;
            isConnected = true;
        }
        if (distanceZ < 0 && Mathf.Abs(distanceZ) < 1.3 && Mathf.Abs(distanceY) < 0.5 && Mathf.Abs(distanceX) < 0.5)
        {
            double newPosX = to_connect.transform.position.x;
            double newPosY = to_connect.transform.position.y;
            double newPosZ = to_connect.transform.position.z;
            transform.position = new Vector3((float)newPosX, (float)newPosY, (float)newPosZ - 1);
            transform.parent = to_connect.transform;
            isConnected = true;
        }
    }
}
