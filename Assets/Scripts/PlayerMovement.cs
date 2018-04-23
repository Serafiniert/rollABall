using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
	public float speed;
	public Text countText;
	public Text winText;

	private Rigidbody rb;
	private int count;
	public Vector3 teleportCords;

	public Transform cameraTransform;
	Vector3 cameraForward;
	Vector3 cameraRight;

	void Start ()
	{
		teleportCords = new Vector3 (-74.1f, 55.5f, 27f);
		Cursor.visible = false;
		rb = GetComponent<Rigidbody> ();
		count = 0;
		SetCountText ();
		winText.text = "";
	}

	void Update ()
	{
		if (Input.GetKeyDown ("r")) {
			RestartGame ();
		}
	}

	void FixedUpdate ()
	{
		cameraForward = cameraTransform.forward;
		cameraRight = cameraTransform.right;

		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		cameraForward *= moveVertical;
		cameraRight *= moveHorizontal;

		rb.AddForce ((cameraForward + cameraRight) * speed);
	}

	void OnTriggerEnter (Collider other)
	{
		switch (other.gameObject.tag) {
		case "Pick Up":
			other.gameObject.SetActive (false);
			count = count + 1;
			SetCountText ();
			break;
		case "Teleporter":
			rb.velocity = Vector3.zero;
			rb.angularVelocity = Vector3.zero; 
			gameObject.transform.position = teleportCords;
			break;
		}
	}

	void SetCountText ()
	{
		countText.text = "Count: " + count.ToString ();
		if (count >= 8) {
			winText.text = "You Win!";
		}
	}

	void RestartGame ()
	{
		SceneManager.LoadScene (SceneManager.GetActiveScene ().name);
	}
}