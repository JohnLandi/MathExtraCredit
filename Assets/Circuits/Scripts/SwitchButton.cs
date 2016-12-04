using UnityEngine;
using System.Collections;

public class SwitchButton : MonoBehaviour {

	// Use this for initialization
	void Start () 
	{
		GetComponent<SpriteRenderer>().color = Color.red;
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		

	}


	void OnMouseDown()
	{
		if (this.gameObject.GetComponentInParent<Switch> ().on == false) 
		{
			GetComponent<SpriteRenderer> ().color = Color.green;
			this.gameObject.GetComponentInParent<Switch> ().on = true;

		} 
		else
		{
			GetComponent<SpriteRenderer> ().color = Color.red;
			this.gameObject.GetComponentInParent<Switch> ().on = false;

		}

	}

}
