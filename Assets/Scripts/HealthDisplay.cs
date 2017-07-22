using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthDisplay : MonoBehaviour {

	Player p;
	Transform t;

	// Use this for initialization
	void Start () {
		p = GameObject.Find ("Player").GetComponent<Player> ();
		t = GetComponent<Transform> ();
	}

	// Update is called once per frame
	void Update () {
		transform.localScale = new Vector3 (p.PercentHP () * 2.4f, transform.localScale.y, transform.localScale.z);
	}
}
