using UnityEngine;
using System.Collections.Generic;
using System.Collections;


//node gets pooped out by the actual algorithm

public class Node : MonoBehaviour {
	Vector2 mycoords;
	public Node parent;
	public Node child;
	public List<Node> neighbors=new List<Node>();

	public Node(){
	}

	public Node(Vector2 _mycoords){
		mycoords = _mycoords;
	}

	public Node(Node _parent){
		parent = _parent;
	}

}
