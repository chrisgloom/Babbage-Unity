using UnityEngine;
using System;
using System.Collections.Generic;
using Random = UnityEngine.Random;
using System.IO;

public class BoardManager : MonoBehaviour
{
	char[] rawReadIn;
	char[,] temporaryTwoD = new char[10, 10];
	char[] clockwiseArr = new char[100];

	public int columns = 10;
	public int rows = 10;

	public GameObject[] floorTiles;
	private Transform boardHolder;


	//Lays out the floor tiles
	void BoardSetup ()
	{
		GameObject toInstantiate;
		boardHolder = new GameObject ("board").transform;
		int counter = 0;
		for (int x = 0; x < columns; x++) {
			for (int y = 0; y < rows; y++) {
				//use x and 0s to determine collider placement
				if (clockwiseArr [counter] == 'x') {
					toInstantiate = floorTiles [1];
				} else {
					toInstantiate = floorTiles [0];
				}
				GameObject instance = Instantiate (toInstantiate, new Vector3 (x, y, 0.0f), Quaternion.identity) as GameObject;
				instance.transform.SetParent (boardHolder);
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
		//create a two dimensional array from original input
		int count = 0;
		for (int x = 0; x < columns; x++) {
			for (int y = 0; y < rows; y++) {
				temporaryTwoD [x, y] = rawReadIn [count];
				count++;
			}
		}
		count = 0;
		for (int x = 0; x < columns; x++) {
			//Read original input into new array rotated 90deg clockwise
			for (int y = rows - 1; y >= 0; y--) {
				clockwiseArr [count] = temporaryTwoD [y, x];
				count++;
			}
		}	
	}


	//Level param is vestigial code from a tutorial -- not currently used
	public void SetupScene (int level)
	{
		letsReadAFile ();
		BoardSetup ();
	}
}
