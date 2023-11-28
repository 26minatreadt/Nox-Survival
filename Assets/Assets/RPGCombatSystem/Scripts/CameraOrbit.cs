using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraOrbit : MonoBehaviour
{
	public Transform refCamera;
	public Vector3 offsetCamera = new Vector3(0, 0.5f, 0);
	public float distance = 2.5f;
	public float xSpeed = 400.0f;
	public float ySpeed = 80.0f;
	public float yMinLimit = -20f;
	public float yMaxLimit = 80f;
	private float x = 0.0f;
	private float y = .0f;
	public bool zoom;
	public float zoomSpeed = 120.0f;

	void Start()
	{
		Cursor.lockState = CursorLockMode.Locked;
		Cursor.visible = false;

		Vector3 angles = transform.eulerAngles;
		x = angles.y;
		y = angles.x;
	}

	void LateUpdate()
	{
		if (refCamera)
		{
			//Rotates the camera
			x += (float)(Input.GetAxis("Mouse X") * xSpeed * Time.deltaTime);

			if (zoom)
			{
				distance += (float)(Input.GetAxis("Mouse Y"));
			}
			else
			{
				y -= (float)(Input.GetAxis("Mouse Y") * zoomSpeed * Time.deltaTime);
			}
			y = ClampAngle(y, yMinLimit, yMaxLimit);//This communicates with the function below and delimits the limits of the camera
			Quaternion rotation = Quaternion.Euler(y, x, 0);
			Vector3 position = rotation * new Vector3(0.0f, 0.0f, -distance) + (refCamera.position + offsetCamera);
			transform.rotation = rotation;
			transform.position = position;

			//Here begins the code that is responsible for bringing the camera closer by detecting the wall
			float dist = distance + 1.0f; // distance to the camera + 1.0 so the camera doesnt jump 1 unit in if it hits someting far out
			Vector3 targetPosition = (refCamera.position + offsetCamera); // get the position the camera should be.
			Ray ray = new Ray(targetPosition, transform.position - targetPosition);// get a ray in space from the target to the camera.
			RaycastHit hit;
			// read from the taret to the targetPosition;
			if (Physics.Raycast(ray, out hit, dist))
			{
				if (hit.transform.tag != "Player" && hit.transform.tag != "Weapon" && hit.transform.tag != "Enemy")
				{
					// store the distance;
					dist = hit.distance - 1.0f;
				}
			}
			// check if the distance is greater than the max camera distance;
			if (dist > distance) dist = distance;
			// check if the distance is less than zero... if it is.. it is zero.
			if (dist < 0.0f) dist = 0.0f;
			// set the new position based off of the calculations above.
			transform.position = ray.GetPoint(dist);

			//////
		}
	}

	//This code is in charge of controlling the limits of the camera up and down
	private float ClampAngle(float angle, float min, float max)
	{
		if (angle < -360)
		{
			angle += 360;
		}
		if (angle > 360)
		{
			angle -= 360;
		}
		return Mathf.Clamp((float)(angle), (float)(min), (float)(max));
	}
}
