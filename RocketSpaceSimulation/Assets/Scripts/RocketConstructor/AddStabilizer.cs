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
    public GameObject stabilizer;
    public GameObject chooseEngine;

    public Selectable currentSelectable;

    public List<GameObject> spheres = new List<GameObject>();

    public Text btnText;

    private int clickCount = 1;
    private bool mode = false;
    private string engineName;
    public bool flag = false;
    private int bigCounter = 0;

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
                    spheres[bigCounter].tag = "StabilizatorPoint";
                    spheres[bigCounter].name = center.transform.GetChild(i).name;
                    bigCounter++;
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
                else if (hit.collider.gameObject.name.Contains("Engine") && !flag)
                {
                    chooseEngine = hit.collider.gameObject;
                    flag = true;
                    GameObject engineObj = hit.collider.gameObject;
                    for (int i = 0; i < engineObj.transform.childCount; i++)
                    {
                        if(engineObj.transform.GetChild(i).name.Equals("RightE") || engineObj.transform.GetChild(i).name.Equals("LeftE")
                            || engineObj.transform.GetChild(i).name.Equals("UpE") || engineObj.transform.GetChild(i).name.Equals("DownE"))
                        {
                            pointPos = engineObj.transform.GetChild(i).position;
                            spheres.Add(Instantiate(sphere, pointPos, Quaternion.identity));
                            spheres[bigCounter].tag = "StabilizatorPoint";
                            //print(engineObj.transform.GetChild(i).name);
                            spheres[bigCounter].name = engineObj.transform.GetChild(i).name;
                            bigCounter++;
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
        if (currentSelectable && Input.GetMouseButtonDown(0))
        {
            Vector3 tmp_vect = currentSelectable.transform.position;
            Destroy(currentSelectable.gameObject);
            spheres.Remove(currentSelectable.gameObject);
            GameObject tmp;
            print(currentSelectable.name);
            switch (currentSelectable.name)
            {
                case "Right":
                    tmp = Instantiate(stabilizer, tmp_vect, Quaternion.Euler(0, 90, 0));
                    tmp.tag = "Right";
                    tmp.GetComponent<FixedJoint>().connectedBody = center.GetComponent<Rigidbody>();
                    break;
                case "Left":
                    tmp = Instantiate(stabilizer, tmp_vect, Quaternion.Euler(0, -90, 0));
                    tmp.tag = "Left";
                    tmp.GetComponent<FixedJoint>().connectedBody = center.GetComponent<Rigidbody>();
                    break;
                case "Up":
                    tmp = Instantiate(stabilizer, tmp_vect, Quaternion.Euler(0, 0, 0));
                    tmp.tag = "Up";
                    tmp.GetComponent<FixedJoint>().connectedBody = center.GetComponent<Rigidbody>();
                    break;
                case "Down":
                    tmp = Instantiate(stabilizer, tmp_vect, Quaternion.Euler(0, -180, 0));
                    tmp.tag = "Down";
                    tmp.GetComponent<FixedJoint>().connectedBody = center.GetComponent<Rigidbody>();
                    break;

                case "RightE":
                    tmp = Instantiate(stabilizer, tmp_vect, Quaternion.Euler(0, 90, 0));
                    tmp.tag = "RightE";
                    tmp.GetComponent<FixedJoint>().connectedBody = chooseEngine.GetComponent<Rigidbody>();
                    break;
                case "LeftE":
                    tmp = Instantiate(stabilizer, tmp_vect, Quaternion.Euler(0, -90, 0));
                    tmp.tag = "LeftE";
                    tmp.GetComponent<FixedJoint>().connectedBody = chooseEngine.GetComponent<Rigidbody>();
                    break;
                case "UpE":
                    tmp = Instantiate(stabilizer, tmp_vect, Quaternion.Euler(0, 0, 0));
                    tmp.tag = "UpE";
                    tmp.GetComponent<FixedJoint>().connectedBody = chooseEngine.GetComponent<Rigidbody>();
                    break;
                case "DownE":
                    tmp = Instantiate(stabilizer, tmp_vect, Quaternion.Euler(0, -180, 0));
                    tmp.tag = "DownE";
                    tmp.GetComponent<FixedJoint>().connectedBody = chooseEngine.GetComponent<Rigidbody>();
                    break;
            }
        }
    }
}
