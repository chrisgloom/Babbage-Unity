using UnityEngine;
using System;
using System.Collections.Generic;
using Random = UnityEngine.Random;
using System.IO;

public class BoardManager : MonoBehaviour {
	char[] iterateMe;
	char [,] holdMe = new char[10,10];
	char[] changedArr = new char[100];

	public int columns=10;
	public int rows=10;
	public GameObject [] floorTiles;
	private Transform boardHolder;


	//private List <Vector3> gridPositions = new List<Vector3>();

	//Makes a safe space to put blocking items into
	/*void InitialiseList(){
		gridPositions.Clear ();
		for (int x = 1; x < columns - 1; x++) {
			for (int y = 1; y < rows - 1; y++) {
				gridPositions.Add (new Vector3 (x, y, 0f));
			
			}
		
		}
	
	}
	*/

	//Lays out the floor tiles
	void BoardSetup(){
		GameObject toInstantiate;
		boardHolder = new GameObject ("board").transform;
		int counter = 0;
		for (int x = 0; x < columns; x++) {
			for (int y = 0; y < rows; y++) {
				//use x and 0s to determine collider placement
				if (changedArr [counter] == 'x') {
					toInstantiate = floorTiles [1];
				} else {
					toInstantiate = floorTiles [0];
				}
				GameObject instance = Instantiate (toInstantiate, new Vector3 (x*10, y*10, 0.0f), Quaternion.identity) as GameObject;
				instance.transform.SetParent(boardHolder);
				counter++;
			}
		}
	
	}
	/*
	 * Old tutorial code -- for deletion once I'm sure it's not needed
	 * 
	 * Vector3 RandomPosition(){
		int randomIndex = Random.Range (0, gridPositions.Count);
		Vector3 randomPosition = gridPositions [randomIndex];
		gridPositions.RemoveAt (randomIndex);
		return randomPosition;
	}
	void LayoutObjectAtRandom(GameObject[] tileArray,int min, int max){
		int objectCount = Random.Range (min, max+1);
		for (int i = 0; i < objectCount; i++) {
			//Choose a random tile prefab from the tiles array
			GameObject tileChoice= tileArray[Random.Range(0, tileArray.Length)];
			//Instantiate a random tile at a random position
			Instantiate(tileChoice, RandomPosition(), Quaternion.identity);
		}
	}*/

	void letsReadAFile(){
		try
		{   // Open the text file using a stream reader.
			using (StreamReader myStreamReader = new StreamReader("/Users/Gloom/Code/BabbageAttempt/Assets/test.txt"))
			{
				// Read the stream to a string, and write the string to the console.
				String line = myStreamReader.ReadToEnd();
				Debug.Log(line);
				//Get rid of newline characters
				line=line.Replace(Environment.NewLine, string.Empty);
				//make it an array
				iterateMe = line.ToCharArray();

			}
		}
		catch (Exception e)
		{
			Debug.Log("The file could not be read:");
			Debug.Log(e.Message);
		}
		//Wrangle the array
		int count = 0;
		for (int x = 0; x < columns; x++) {
			for (int y = 0; y < rows; y++) {
				//Debug.Log("iterate is");
				//Debug.Log (iterateMe [count]);
				holdMe [x, y] = iterateMe [count];
				count++;
			}
		}
		count = 0;
		for (int x = 0; x < columns; x++) {
			//In theory this loop should flip the array around correctly for laying out
			for (int y = rows-1; y >= 0; y--) {
				Debug.Log("changed gets");
				Debug.Log (holdMe [y, x]);

				//Debug.Log (y);
				//Debug.Log("x is:");
				//Debug.Log (x);
				changedArr [count] = holdMe [y, x];
				count++;
			}
		}
		Debug.Log (changedArr [0]);
		
	}


	//Level is vestigial code from a tutorial
	public void SetupScene(int level){
		letsReadAFile ();
		BoardSetup ();
		//InitialiseList ();
	}
}
