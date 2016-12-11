using UnityEngine;
using System.Collections;

public class ttPlayer : MonoBehaviour {
	public float movespeed;
	private Rigidbody2D RB;
	public float jumph;
	// Use this for initialization
	void Start () {
		RB = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		float hAxis = Input.GetAxis ("Horizontal");
		move (hAxis);
		if(Input.GetKeyDown(KeyCode.Space))
			GetComponent<Rigidbody2D> ().velocity = new Vector2 (GetComponent<Rigidbody2D> ().velocity.x, jumph);
	}
	void move(float ms){
		RB.velocity = new Vector2(ms*movespeed, RB.velocity.y);
	}
}
