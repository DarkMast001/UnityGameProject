using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotateAround : MonoBehaviour 
{
	public Transform target;
	public Vector3 offset;
	public float sensitivity = 3; // чувствительность мышки
	public float limit_up = 80; // ограничение вращения по Y вверх
	public float limit_down = 10; // ограничение вращения по Y вниз
	public float zoom = 0.25f; // чувствительность при увеличении, колесиком мышки
	public float zoomMax = 20; // макс. увеличение
	public float zoomMin = 3; // мин. увеличение
	private float X, Y;

	void Start () 
	{
		//limit_up = Mathf.Abs(limit_up);
		if(limit_up > 90) limit_up = 90;
		offset = new Vector3(offset.x, offset.y, -Mathf.Abs(zoomMax)/2);
		transform.position = target.position + offset;
	}

	void Update ()
	{
        if(Input.GetAxis("Mouse ScrollWheel") > 0) offset.z += zoom;
        else if(Input.GetAxis("Mouse ScrollWheel") < 0) offset.z -= zoom;
        offset.z = Mathf.Clamp(offset.z, -Mathf.Abs(zoomMax), -Mathf.Abs(zoomMin));

		if (Input.GetMouseButton(2)) //&& Input.GetMouseButton(1))
		{
			X = transform.localEulerAngles.y + Input.GetAxis("Mouse X") * sensitivity;
			Y += Input.GetAxis("Mouse Y") * sensitivity;
		}
		Y = Mathf.Clamp(Y, -limit_up, -limit_down);
		transform.localEulerAngles = new Vector3(-Y, X, 0);
		transform.position = transform.localRotation * offset + target.position;
	}
}