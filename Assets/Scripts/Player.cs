using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor.Animations;

public class Player : Entity {

	private float percentHP;
	public AnimatorController[] weaponControllers;

	// Use this for initialization
	void Start () {
		entityAnim = GetComponent<Animator> ();
		percentHP = 1;
		entityAnim.runtimeAnimatorController = weaponControllers [0];
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public override void Damage(int damage) {
		base.Damage (damage);
		percentHP = (float)health / 100f;

		if (!dead) {
			particleAnim.Play ("damage");
		} 
	}

	public float PercentHP() {
		return percentHP;
	}

	public override void Kill() {
		base.Kill ();
		GetComponent<PlayerController> ().enabled = false;
		// show game over
		GameObject.Find("FadeIn Manager").GetComponent<FadeIn>().AddToFadeList((MaskableGraphic) GameObject.Find("Game Over").GetComponent<Text>());
		GameObject.Find("FadeIn Manager").GetComponent<FadeIn>().AddToFadeList((MaskableGraphic) GameObject.Find("Exit").GetComponent<Image>());
		GameObject.Find("FadeIn Manager").GetComponent<FadeIn>().AddToFadeList((MaskableGraphic) GameObject.Find("Exit").GetComponentInChildren<Text>());
	}

	public Animator GetAnimator() {
		return entityAnim;
	}

	public void SetGunController(int i) {
		entityAnim.runtimeAnimatorController = weaponControllers [i];
	}
}
