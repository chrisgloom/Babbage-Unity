using UnityEngine;
using System.Collections;
using System;

//This is the class that should be applied to the tiles at layout
//it needs to track coordinates probably using the point rather than vector two for comparability
public class Space  {
	Vector2 mycoords;
	bool walkable;

	public Space(Vector2 _mycoords, bool _walkable){
		mycoords = _mycoords;
		walkable = _walkable;
	}
}


//momentarily have forgotten why I wrote this class. Not deleting it just in case.
/*class Point:IComparable{
	int x, y;
	public Point (int _x, int _y){
		x = _x;
		y = _y;
	}
	public Point (Vector2 pCoords){
		x = (int)pCoords.x;
		y = (int)pCoords.y;
	}
	public Vector2 toVec2(){
		Vector2 tempVec = new Vector2 (x, y);
		return tempVec;
		}
	public int CompareTo(object someOb){
		Point comparedPoint = someOb as Point;
		if(x==comparedPoint.x && y==comparedPoint.y){


		}
		return 1;
	}
	}
*/


