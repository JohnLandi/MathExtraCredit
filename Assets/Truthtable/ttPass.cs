using UnityEngine;
using System.Collections;

public class ttPass : MonoBehaviour {
	public bool b2pass;
	public ttGM gm;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnCollisionEnter2D(Collision2D other){
		if (other.transform.tag == "ttPlayer") {
//			gm.recieve (b2pass);

		}
	}
}
