using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Selectable : MonoBehaviour
{
    public Material nonCursor;
    public Material enterCursor;

    public void Select()
    {
        GetComponent<Renderer>().material = enterCursor;
    }

    public void Deselect()
    {
        GetComponent<Renderer>().material = nonCursor;
    }
}
