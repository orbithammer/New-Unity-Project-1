﻿using UnityEngine;
using System.Collections;

public class PotatoLauncher : MonoBehaviour {
	public GameObject projectile; //the projectile prefab
	public float speed = 20f; //give speed a default of 20
	internal float loadRate =0.5f; //how often a projectile can be fired
	float timeRemaining; //how much time before the next shot can happen

	// Use this for initialization
	void Start () {
	
	
	}
	
	// Update is called once per frame
	void Update () {
		timeRemaining -= Time.deltaTime; //
		//if the Fire1 button (default is left ctrl) is pressed...
		if (Input.GetButton ("Fire1") && timeRemaining < 0) {
			timeRemaining = loadRate; //reset the time remaining
			ShootProjectile (); //...shoot the projectile
		}
	}
	void ShootProjectile () {
		//create a clone of the projectile at the location & orientation of the script's parent
		GameObject potato = (GameObject) Instantiate (projectile, transform.position, transform.rotation);
		//add some force to send the projectile off in its forward direction
		potato.rigidbody.velocity = transform.TransformDirection (new Vector3 (0, 0, speed));
		audio.Play (); //play the default audio clip on this component's game object
	}
	void RewardTime () {
		if (loadRate > 0.1f)
			loadRate -= 0.1f; //decrease the loadRate by 0.1f
	}
}
