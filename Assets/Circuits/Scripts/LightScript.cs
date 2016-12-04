using UnityEngine;
using System.Collections;

public class LightScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (this.GetComponent<Switch> ().on == true)
			GetComponent<SpriteRenderer> ().color = Color.green;
		
		else
			GetComponent<SpriteRenderer> ().color = Color.red;
	
	}
}
