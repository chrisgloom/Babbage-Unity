using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	public BoardManager boardscript;
	private int level = 3;

	// Use this for initialization
	void Awake () {
		boardscript = GetComponent<BoardManager> ();
		InitGame ();

	}
	void InitGame(){
		boardscript.SetupScene (level);
	}
}
