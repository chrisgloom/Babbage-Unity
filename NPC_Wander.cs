using UnityEngine;
using System.Collections;

public class NPC_Wander : MonoBehaviour {
	Rigidbody2D myBody;
	Vector2 movPos;
	Vector2 targetDown;
	MoveState myState;

	bool timeDone;

	void Awake(){
		timeDone = true;
	}

	enum MoveState {
		Turn,
		Wait,
		WalkForward,

	};

	// Use this for initialization
	void Start () {
		myBody = GetComponent<Rigidbody2D> ();
		StartCoroutine(waitup(targetDown));
	}

	void FixedUpdate () {
		if (timeDone) {
			myState = (MoveState)Random.Range (0, 2);
			switch (myState) {
			case(MoveState.Turn):
				//turn the sprite
				break;
			case(MoveState.Wait):
				//do nothing
				break;
			case(MoveState.WalkForward):
				//walk in a direction for an amount of time
				break;

			default:
				break;

			}
		}
	}

	IEnumerator waitup(Vector2 tar){
		while (true) {
			targetDown = new Vector2 (10f, 60f);
			movPos = Vector2.Lerp (transform.position, targetDown, Time.deltaTime * 20f);
			Debug.DrawLine (transform.position, targetDown, Color.green, 1000f);
			myBody.MovePosition (movPos);
			yield return new WaitForSeconds (7f);
			print ("fired off");
		}
	}
}
