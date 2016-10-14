using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class NPC_Instance : MonoBehaviour {
	//Beginnings of a character class
	string NPCname, currentBorough;
	//These are to be used for a pokemon-like npc wander within a fixed area
	public int roamX, roamY;
	float waitTime = 2f;

	bool timeDone;
	public float speed = 2f;



	enum MoveState {
		Turn,
		Wait,
		walkDirection
	};

	enum WhereWalk{
		Up,
		Down,
		Left,
		Right
	}

	//Executes when script loads
	void Awake(){
		timeDone = false;
	}


	//Called every frame
	void Update () {
		wander ();
	}

	void goTo(){
		//get a reference to the pathing script and then call the function with the coords
	}

	//if time is done, make a move
	void wander(){

		MoveState myState;
		WhereWalk myWalk;


		if (timeDone) {
			myState = (MoveState)Random.Range (0, 3);
			switch (myState) {
			case(MoveState.Turn):
				//debug.Log ("turn got called");
				timeDone = false;
				break;
			case(MoveState.Wait):
				//debug.Log ("wait got called");
				timeDone = false;
				break;
			case(MoveState.walkDirection):
				//debug.Log ("walk got called");
				//walk to a new adjacent random tile
				myWalk = (WhereWalk)Random.Range (0, 4);
				randomWalkDir (myWalk);
				timeDone = false;
				break;
			default:
				break;
			}
		} else {
			//lower the time
			if (waitTime <= 0f) {
				timeDone = true;
				//This should be changed to a constant instead of a literal
				waitTime = 2f;
			} else {
				timeDone = false;
				waitTime -= Time.deltaTime;
				//debug.Log (waitTime);
			}
		}
	}
	void randomWalkDir(WhereWalk myWalk){
		switch(myWalk) {
		case(WhereWalk.Up):
			//iswalkable() should check for collisions + if in wander range
			if (isWalkable (0f, 1f)) {
				StartCoroutine (moveLerp (0f, 1f));
			}
			break;
		case(WhereWalk.Down):
			if (isWalkable (0f, -1f)) {
				StartCoroutine (moveLerp (0f, -1f));
			}
			break;
		case(WhereWalk.Left):
			if (isWalkable (1f, 0f)) {
				StartCoroutine (moveLerp (1f, 0f));
			}
			break;
		case(WhereWalk.Right):
			if (isWalkable (-1f, 0)) {
				StartCoroutine (moveLerp (-1f, 0));
			}
			break;
		default:
			break;
		}

	}

	bool isWalkable(float xAdd, float yAdd){
		Vector3 fromHere = new Vector3 (transform.position.x + xAdd, transform.position.y + yAdd, transform.position.z + 1f);
		Vector3 toHere = new Vector3 (transform.position.x + xAdd, transform.position.y + yAdd, transform.position.z - 1f);
		//debug.DrawLine( fromHere, toHere, Color.red, 4f);
		if (Physics2D.Linecast(fromHere, toHere)) {
			//debug.Log ("can't move");
			return false;
		} else {
			return true;
		}

	}

	IEnumerator moveLerp(float xAdd, float yAdd){
		Vector3 storedPos = transform.position;
		float iter = 0f;
		while (iter < 1f) {
			iter += Time.deltaTime * speed;
			transform.position = Vector2.Lerp (storedPos, new Vector2 (storedPos.x + xAdd, storedPos.y + yAdd), iter);
			yield return new WaitForEndOfFrame ();
		}
	}

}
