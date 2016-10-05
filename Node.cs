using UnityEngine;
using System.Collections.Generic;
using System.Collections;


public class Node : MonoBehaviour {

	public Vector2 myCoords;
	public bool walkable;
	public List<Node> neighbors=new List<Node>();

	List<Node> GetNeighbors(){
		//GetComponent<BoxCollider2D>().enabled=false;
		List<Node> myNeigbors = new List<Node>();
		RaycastHit2D upBuddy = Physics2D.Raycast(myCoords, Vector2.up, 1f);
		RaycastHit2D leftBuddy = Physics2D.Raycast(myCoords, Vector2.left, 1f);
		RaycastHit2D rightBuddy = Physics2D.Raycast(myCoords, Vector2.right, 1f);
		RaycastHit2D downBuddy = Physics2D.Raycast(myCoords, Vector2.down, 1f);

		if (upBuddy.collider != null){
			myNeigbors.Add (upBuddy.transform.GetComponent <Node>());
		}

		if (downBuddy.collider != null){
			myNeigbors.Add (downBuddy.transform.GetComponent <Node>());
		}

		if (leftBuddy.collider != null){
			myNeigbors.Add (leftBuddy.transform.GetComponent <Node>());
		}

		if (rightBuddy.collider != null){
			myNeigbors.Add (rightBuddy.transform.GetComponent <Node>());
		}
		//GetComponent<BoxCollider2D>().enabled=true;
		return myNeigbors;
	}

	void Start(){
		myCoords = transform.position;
		neighbors = GetNeighbors ();



			}

}
