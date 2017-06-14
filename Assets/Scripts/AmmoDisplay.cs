using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AmmoDisplay : MonoBehaviour {

	Text text;
	WeaponManager wm;

	// Use this for initialization
	void Start () {
		text = GetComponent<Text> ();
		wm = GameObject.Find ("Player").GetComponent<WeaponManager> ();
	}

	// Update is called once per frame
	void Update () {
		text.text = wm.currentAmmo[wm.currentGun] + " | " + wm.totalAmmo [wm.currentGun];
	}
}
