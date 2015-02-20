using UnityEngine;
using System.Collections;

public class PlantVeggies : MonoBehaviour {
	public GameObject veggie; //the plant's prefab
	float minX; //variables to hold the object's bounding box location
	float minZ;
	public bool rotate; //flag to rotate the rows to match the bed
	public int rows = 6; //the number of rows to make
	public int collums = 6; //the number of collums to make
	float spacingX;
	float spacingZ;

	// Use this for initialization
	void Start () {
		//calculate box position
		minX = transform.position.x - transform.localScale.x / 2;
		minZ = transform.position.z - transform.localScale.z / 2;
		spacingX = transform.localScale.x / rows;
		spacingZ = transform.localScale.z / columns;
		PopulateBed (); //plant the veggies
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void PopulateBed {
		float y = transform.position.y; //ground level
		for (int x = 0; x < columns; x++) {
			for (int z = 0; z < rows; z++) {
				Vector3 pos = new Vector3(x * spacingX + minX, y, z * spacingZ + minZ);
				GameObject newVeggie = (GameObject) Instantiate(veggie, pos, Quaternion.identity);
			}
		}
	}
}
