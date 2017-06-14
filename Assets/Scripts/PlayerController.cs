using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;


public class PlayerController : MonoBehaviour {

	private Transform playerTransform;
	private Rigidbody2D playerBody;
	private Transform cameraTransform;
	public float maxSpeed;

	// Use this for initialization
	void Start () {
		playerTransform = GetComponent<Transform> ();
		playerBody = GetComponent<Rigidbody2D> ();
		cameraTransform = Camera.main.GetComponent<Transform> ();
	}
	
	// Update is called once per frame
	void Update () {

		float xAim, yAim;
		xAim = CrossPlatformInputManager.GetAxis ("aim_h");
		yAim = CrossPlatformInputManager.GetAxis ("aim_v");

		if (xAim != 0 && yAim != 0) {
			Vector3 pos = new Vector3 (playerTransform.position.x + xAim, playerTransform.position.y + yAim, 0);
			playerTransform.right = pos - playerTransform.position;
		}
	}

	void FixedUpdate() {
		
		float x, y;
		y = (CrossPlatformInputManager.GetAxis ("move_v") * maxSpeed);
		x = (CrossPlatformInputManager.GetAxis ("move_h") * maxSpeed);
		Vector2 move = new Vector3 (x, y);

		playerBody.velocity = Vector2.ClampMagnitude(move, maxSpeed);
		cameraTransform.position = new Vector3 (playerTransform.position.x, playerTransform.position.y, -10);
	}
}
