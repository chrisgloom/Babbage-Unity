using UnityEngine;
using System;
using System.Collections.Generic;
using Random = UnityEngine.Random;
using System.IO;

public class BoardManager : MonoBehaviour
{
	const int columns = 10;
	const int rows = 10;

	char[] rawReadIn;

	public GameObject[] floorTiles;
	private Transform boardHolder;


	//sets up the complete borough to be prefabbed
	void prefabMachine ()
	{
		GameObject toInstantiate, boroughObj = new GameObject();
		//Make a parent object named boroughObj and give it an instance of the boroughObj class
		boroughObj.name = "boroughObj";
		//adds an instance of the script to the boroughObj and then stores a reference in myBorInstance
		Borough myBorInstance = boroughObj.AddComponent <Borough>();
		//fill the name of the boroughInstance
		myBorInstance.borName = "BabbageHome";
		boardHolder = boroughObj.transform;


		int counter = 0;
		for (int x = 0; x < columns; x++) {
			for (int y = 0; y < rows; y++) {
				//use x and 0s to determine collider placement
				//isWall is used when adding vector2s to the dict
				bool isWall;
				//put this back to clockwiseArr if it breaks
				if (rawReadIn [counter] == 'x') {
					toInstantiate = floorTiles [1];
					isWall = true;
				} else {
					toInstantiate = floorTiles [0];
					isWall = false;
				}
				//add each node to borough's dict as a vector2 and node if it's not a wall

				GameObject instance = Instantiate (toInstantiate, new Vector3 (x, y, 0.0f), Quaternion.identity) as GameObject;
				//name of the object is its xy
				instance.name = String.Format("tile{0}{1}",instance.transform.position.x,instance.transform.position.y);
				instance.transform.SetParent (boardHolder);

				//runs if not a wall
				if (!isWall) {
					//try to do this adding the node that's going to sit on the prefab itself. Does that copy or store a reference?
					//Node addedNode = instance.AddComponent<Node>();
					//Debug.Log(String.Format ("testing {0}", new Vector2 (x, y)));
					//myBorInstance.myNodes.Add (new Vector2 (x, y), addedNode);
					myBorInstance.floorTiles.Add(new Vector2(x, y), true);
				}

				counter++;
			}
		}
	
	}

	void letsReadAFile ()
	{
		try {   // Open the text file using a stream reader.
			using (StreamReader myStreamReader = new StreamReader ("/Users/Gloom/Code/BabbageAttempt/Assets/test.txt")) {
				// Read the stream to a string, and write the string to the console.
				String inputAsString = myStreamReader.ReadToEnd ();
				//Get rid of newline characters
				inputAsString = inputAsString.Replace (Environment.NewLine, string.Empty);
				//convert string to char array
				rawReadIn = inputAsString.ToCharArray ();

			}
		} catch (Exception e) {
			Debug.Log ("The file could not be read:");
			Debug.Log (e.Message);
		}
	}


	//Level param is vestigial code from a tutorial -- not currently used
	public void SetupScene (int level)
	{
		letsReadAFile ();
		prefabMachine ();
	}
}
