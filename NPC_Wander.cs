using UnityEngine;
using System.Collections;

public class NPC_Wander : MonoBehaviour {
	Rigidbody2D myBody;
	Vector2 movPos;
	Vector2 targetDown;

	// Use this for initialization
	void Start () {
		myBody = GetComponent<Rigidbody2D> ();
	}

	void FixedUpdate () {
		targetDown = new Vector2(10f,60f);
			movPos = Vector2.Lerp(transform.position, targetDown, Time.deltaTime * 1000f);
			Debug.DrawLine (transform.position, targetDown, Color.green, 1000f);
			myBody.MovePosition (movPos);
	
	}
}
