using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseMoveObject : MonoBehaviour
{
    GameObject Shuttle_settings;

    public Transform target;
    public Transform exception_target;

    private Vector3 offset;
    private float distance;

    private void Start()
    {
        Shuttle_settings = GameObject.FindGameObjectWithTag("Center");
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                target = hit.transform;
                offset = target.position - hit.point;
                distance = hit.distance;
                if(target != exception_target)
                {
                    target.tag = "Untagged";
                    target.gameObject.AddComponent(typeof(DistabceOBJ));
                }
            }
        }
        if (Input.GetMouseButton(0) && !Input.GetMouseButtonDown(0) && target != null && target != exception_target)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            target.position = ray.origin + ray.direction * distance + offset;
            if (Input.GetKey(KeyCode.Delete) && target != exception_target)
            {
                // Destroy(target.gameObject);
                if (Shuttle_settings.GetComponent<Shuttle_settings>().engines.Contains(transform.gameObject))
                {
                    Shuttle_settings.GetComponent<Shuttle_settings>().engines.Remove(target.gameObject);
                    Destroy(target.gameObject);
                }
                else if (Shuttle_settings.GetComponent<Shuttle_settings>().modules.Contains(transform.gameObject))
                {
                    Shuttle_settings.GetComponent<Shuttle_settings>().modules.Remove(target.gameObject);
                    Destroy(target.gameObject);
                }
            }
        }
        if (Input.GetMouseButtonUp(0) && target != exception_target)
        {
            Destroy(target.GetComponent<DistabceOBJ>());
            target.tag = "Support";
            target = null;
        }
    }
}
