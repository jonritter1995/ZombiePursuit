using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeIn : MonoBehaviour {

	private ArrayList fadeInItems;

	// Use this for initialization
	void Start () {
		fadeInItems = new ArrayList ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void FixedUpdate() {
		foreach (MaskableGraphic mg in fadeInItems) {
			mg.color = new Color (mg.color.r, mg.color.g, mg.color.b, mg.color.a + .005f);
		}
	}

	public void AddToFadeList(MaskableGraphic mg) {
		fadeInItems.Add (mg);
	}

	public void RemoveFromFadeList(MaskableGraphic mg) {
		fadeInItems.Remove (mg);
	}
}
