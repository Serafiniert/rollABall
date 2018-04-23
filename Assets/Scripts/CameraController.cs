using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour
{
	public float sensitivity = 5;
	public Transform target;
	public float targetDistance = 15;
	public Vector2 viewAngle = new Vector2 (20, 20);

	Vector3 currentRotation;

	float currentX;
	float currentY;

	void LateUpdate ()
	{
		currentX += Input.GetAxis ("Mouse X") * sensitivity;
		currentY -= Input.GetAxis ("Mouse Y") * sensitivity;

		if (Input.GetKey ("space")) {
			currentY = Mathf.Clamp (currentY, -30, 90);
		} else {
			currentY = Mathf.Clamp (currentY, viewAngle.x, viewAngle.y);
		}

		currentRotation = new Vector3 (currentY, currentX);
		transform.eulerAngles = currentRotation;

		transform.position = target.position - transform.forward * targetDistance;
	}
}