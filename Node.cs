using UnityEngine;
using System.Collections.Generic;
using System.Collections;


public class Node : MonoBehaviour {

	public Vector2 myCoords;
	public bool walkable;
	public Node parent;
	public Node child;
	public List<Node> neighbors=new List<Node>();

	public Node(){
	}

	Node(bool _walkable){
		walkable = _walkable;
	}

	Node(Node _parent){
		parent = _parent;
	}

	//neighbors should happen outside the node itself

	void Start(){
		myCoords = transform.position;
			}

}
