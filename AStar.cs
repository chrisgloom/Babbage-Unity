using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AStar : MonoBehaviour {
	GameObject boroughOb;
	Borough homeBorough;
	public Dictionary<Vector2, bool> allTiles = new Dictionary<Vector2, bool> ();


	// Use this for initialization
	void Start () {
		//Where's the first borough
		boroughOb = GameObject.Find ("boroughObj");
		//Get it in here
		homeBorough = boroughOb.GetComponent<Borough> ();
		//add all the imported tiles to a gigantic tile object
		//for now since there's only one I'll just put the one in
		allTiles = homeBorough.floorTiles;
		//for (int i = 0; i < homeBorough.floorTiles.Count; i++) {
			//allTiles.Add(homeBorough.floorTiles[
			
		//}

	}
	
	// Update is called once per frame
	void Update () {
		
	}
	//walkability of the starting and ending nodes should be assessed before we get to this point
	void pathfind(Vector2 start, Vector2 target){
		Node startingNode = new Node (start);
		Node targetNode = new Node(target);



	}
}
