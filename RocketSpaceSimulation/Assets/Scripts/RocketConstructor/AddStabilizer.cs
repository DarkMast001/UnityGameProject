using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AddStabilizer : MonoBehaviour
{
    public GameObject center;
    public GameObject sphere;
    public GameObject camera;
    public GameObject mainModule;

    public Selectable currentSelectable;

    public List<GameObject> spheres = new List<GameObject>();

    public Text btnText;

    private int clickCount = 1;
    private bool mode = false;

    Vector3 pointPos;

    private void Start()
    {
        center = mainModule.GetComponent<Shuttle_settings>().modules[0];
    }

    private void setSphere()
    {
        for(int i = 0; i < center.transform.childCount; i++)
        {
            if (center.transform.GetChild(i).name.Equals("Right") || center.transform.GetChild(i).name.Equals("Left")
                || center.transform.GetChild(i).name.Equals("Up") || center.transform.GetChild(i).name.Equals("Down"))
            {
                for(int j = 0; j < center.transform.GetChild(i).transform.childCount; j++)
                {
                    pointPos = center.transform.GetChild(i).transform.GetChild(j).position;
                    spheres.Add(Instantiate(sphere, pointPos, Quaternion.identity));
                }
            }
        }
    }

    private void removeSphere()
    {
        for (int i = 0; i < spheres.Count; i++)
        {
            Destroy(spheres[i]);
        }
        spheres.Clear();
    }

    public void addStabilizer()
    {
        clickCount++;
        if (clickCount % 2 == 0)
        {
            setSphere();
            mode = true;
            Destroy(camera.GetComponent<MouseMoveObject>());
            btnText.text = "Finish add";
        }
        else
        {
            mode = false;
            camera.AddComponent<MouseMoveObject>();
            removeSphere();
            btnText.text = "Add Stabilizer";
        }
    }

    private void Update()
    {
        if (mode)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.gameObject.tag == "StabilizatorPoint")
                {
                    Selectable selectable = hit.collider.gameObject.GetComponent<Selectable>();
                    if (selectable)
                    {
                        if (currentSelectable && currentSelectable != selectable)
                        {
                            currentSelectable.Deselect();
                            currentSelectable = null;
                        }
                        currentSelectable = selectable;
                        selectable.Select();
                    }
                    else
                    {
                        if (currentSelectable)
                        {
                            currentSelectable.Deselect();
                            currentSelectable = null;
                        }
                    }
                }
                else
                {
                    if (currentSelectable)
                    {
                        currentSelectable.Deselect();
                        currentSelectable = null;
                    }
                }
            }
        }
        if(currentSelectable && Input.GetMouseButtonDown(0))
        {

        }
    }
}
