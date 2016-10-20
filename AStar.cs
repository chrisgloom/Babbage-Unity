using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AStar : MonoBehaviour {
	GameObject boroughOb;
	Borough homeBorough;
	public Dictionary<Vector2, bool> allTiles = new Dictionary<Vector2, bool> ();


	// Use this for initialization
	void Start () {
		boroughOb = GameObject.Find ("boroughObj");
		homeBorough = boroughOb.GetComponent<Borough> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void pathfind(Vector2 start, Vector2 target){
		//Node startingNode = homeBorough.myNodes [start];
		//Node targetNode = homeBorough.myNodes [target];


	}
}
