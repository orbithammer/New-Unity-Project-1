using UnityEngine;
using System.Collections;

public class PlantRemover : MonoBehaviour {
	public int hardiness = 1; //ammount of damage required to destory the plant
	int damage = 0; //accumulated hit damage

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void Terminator (int newDamage) {
		damage += newDamage; //add more damage from
		if (damage > hardiness)
			Destroy (gameObject);
	}
}
