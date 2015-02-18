using UnityEngine;
using System.Collections;

public class VariablesTest : MonoBehaviour {

	public int legs = 4; // number of legs, will need to calculate speed
	public float earLength =2.5f;
	public string description = "";
	public bool isWarmBlooded;
	public GameObject favoriteFood;
	public Camera theView;
	public VariablesTest myCustomScript;

	// Use this for initialization
	void Start () {
		if (legs == 1) {
			Debug.Log ("The " + gameObject.name + " has " + legs + " leg.");
		} else {
			Debug.Log ("The " + gameObject.name + " has " + legs + " legs.");
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
