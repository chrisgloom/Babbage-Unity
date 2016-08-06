using UnityEngine;
using System.Collections;

public class B_Walk : MonoBehaviour {
	Rigidbody2D mybody;
	public float speed=1.0f;
	public Vector3 destination;
	enum Facing {NORTH, SOUTH, EAST, WEST }
	SpriteRenderer mysprite;
	Animator myanim;
	public float diagonalTemper = 0.6f;


	// Use this for initialization
	void Start () {
		mybody = GetComponent<Rigidbody2D>();
		//Facing myFace = Facing.SOUTH;
		mysprite = GetComponent<SpriteRenderer> ();
		myanim = GetComponent<Animator> ();


	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.W) && Input.GetKey (KeyCode.D)) 
		{
			myanim.SetInteger ("state", 2);
			mysprite.flipX = false;
			mybody.AddForce((Vector2.right + Vector2.up) * speed * diagonalTemper);
		} 
		else if (Input.GetKey (KeyCode.A) && Input.GetKey (KeyCode.S)) 
		{
			myanim.SetInteger ("state", 0);
			mybody.AddForce((Vector2.down + Vector2.left) * speed * diagonalTemper);
		} 
		else if (Input.GetKey (KeyCode.S) && Input.GetKey (KeyCode.D)) 
		{
			mybody.AddForce((Vector2.down + Vector2.right) * speed * diagonalTemper);
		}
		else if (Input.GetKey (KeyCode.W) && Input.GetKey (KeyCode.A)) 
		{
			mybody.AddForce((Vector2.up + Vector2.left) * speed * diagonalTemper);
		}
		else if (Input.GetKey (KeyCode.W)) 
		{
			myanim.SetInteger ("state", 2);
			mysprite.flipX = false;
			//tr.Translate (Vector3.up);
			mybody.AddForce(Vector2.up * speed);
		}
		else if (Input.GetKey(KeyCode.S))
		{
			myanim.SetInteger ("state", 1);
			mysprite.flipX=false;
			//tr.Translate (Vector3.down);
			mybody.AddForce(Vector2.down * speed);
		}
		else if (Input.GetKey(KeyCode.A))
		{
			myanim.SetInteger ("state", 0);
			mysprite.flipX=false;
			//tr.Translate (Vector3.left);
			mybody.AddForce(Vector2.left * speed);
		}
		else if (Input.GetKey(KeyCode.D))
		{
			myanim.SetInteger ("state", 0);
			mysprite.flipX=true;
			//tr.Translate (Vector3.right);
			mybody.AddForce(Vector2.right * speed);
		}
	}
	void directionCheck(){
	
	}
}
	
