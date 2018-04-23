using UnityEngine;
using System.Collections;

public class DSRotatingItem : MonoBehaviour {
	public bool rotateY = false; //Rotate X or Y Axis
	public float rotationSpeed = 12f;
	public float rotateAngleX = 0f;
	public float rotateAngleZ = 0f;

	
	float rotation = 0F;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		rotation += rotationSpeed * Time.deltaTime;
		if(!rotateY)transform.localEulerAngles = new Vector3(rotation, 0,0 );
		else transform.localEulerAngles = new Vector3(rotateAngleX,rotation,rotateAngleZ);

	}
}
