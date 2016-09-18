using UnityEngine;
using System.Collections.Generic;
using System.Collections;


public class Node : MonoBehaviour {

	public Vector2 myCoords;
	public bool walkable;
	public List<Node> neighbors=new List<Node>();

}
