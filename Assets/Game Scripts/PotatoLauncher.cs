using UnityEngine;
using System.Collections;

public class PotatoLauncher : MonoBehaviour {
	public GameObject projectile; //the projectile prefab
	public float speed = 20f; //give speed a default of 20

	// Use this for initialization
	void Start () {
		
	
	}
	
	// Update is called once per frame
	void Update () {
		//if the Fire1 button (default is left ctrl) is pressed...
		if (Input.GetButton ("Fire1")) {
			ShootProjectile (); //...shoot the projectile
		}
	
	}
}
