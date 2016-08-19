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
	public float speed = 5f;

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

	void Update () {
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
			//iswalkable() should check for collisions + if in wander range
			StartCoroutine (slowLerp (0f, 10f));
			break;
		case(WhereWalk.Down):
			StartCoroutine (slowLerp (0f, -10f));
			break;
		case(WhereWalk.Left):
			StartCoroutine (slowLerp (10f, 0f));
			break;
		case(WhereWalk.Right):
			StartCoroutine (slowLerp (-10f, 0));
			break;
		default:
			break;
		}

	}

	IEnumerator slowLerp(float xAdd, float yAdd){
		Vector3 storedPos = transform.position;
		float iter = 0f;
		while (iter < 1f) {
			iter += Time.deltaTime * speed;
			transform.position = Vector2.Lerp (storedPos, new Vector2 (storedPos.x + xAdd, storedPos.y + yAdd), iter);
			yield return new WaitForEndOfFrame ();
		}
	}

}
