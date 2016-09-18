using UnityEngine;
using System.Collections;

public class Borough : MonoBehaviour {
	float x_bounds, y_bounds;
	string name;
	public GameObject myObject;


	// Use this for initialization
	void Start () {
		//This should find where the borough has been placed and then store that value
		Instantiate (myObject, new Vector3 (10, 10, 0.0f), Quaternion.identity);
		x_bounds = transform.position.x;
		y_bounds = transform.position.y;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
