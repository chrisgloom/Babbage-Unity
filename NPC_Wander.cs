using UnityEngine;
using System.Collections;

public class NPC_Wander : MonoBehaviour {
	Rigidbody2D myBody;
	Vector2 movPos;
	Vector2 targetDown;
	MoveState myState;
	WhereWalk myWalk;

	bool timeDone;
	float waitTime = 2f;

	void Awake(){
		timeDone = false;
	}

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

	// Use this for initialization
	void Start () {
		myBody = GetComponent<Rigidbody2D> ();
	}

	void FixedUpdate () {
		lookAlive ();
	}

	//if time is done, make a move
	void lookAlive(){
		if (timeDone) {
			myState = (MoveState)Random.Range (0, 3);
			switch (myState) {
				case(MoveState.Turn):
					Debug.Log ("turn got called");
					timeDone = false;
					break;
				case(MoveState.Wait):
					Debug.Log ("wait got called");
					//Stay where you are? Does this work?
					myBody.MovePosition (new Vector2(transform.position.x, transform.position.y));
					timeDone = false;
					break;
				case(MoveState.walkDirection):
					Debug.Log ("walk got called");
					//walk to a new adjacent random tile
					myWalk = (WhereWalk)Random.Range (0, 4);
					randomWalkDir ();
					timeDone = false;
					break;
				default:
					break;
			}
		} else {
			//lower the time
			if (waitTime <= 0f) {
				timeDone = true;
				waitTime = 2f;
			} else {
				timeDone = false;
				waitTime -= Time.deltaTime;
			}
		}
	}
	void randomWalkDir(){
		switch(myWalk) {
		case(WhereWalk.Up):
			myBody.MovePosition (new Vector2 (transform.position.x,transform.position.y + 10 ));
			break;
		case(WhereWalk.Down):
			myBody.MovePosition (new Vector2 (transform.position.x, transform.position.y - 10));
			break;
		case(WhereWalk.Left):
			myBody.MovePosition (new Vector2 (transform.position.x - 10, transform.position.y));
			break;
		case(WhereWalk.Right):
			myBody.MovePosition (new Vector2 (transform.position.x + 10,(transform.position.y)));
			break;
		default:
			break;
		}
	}

}
