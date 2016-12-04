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


	void OnMouseUp()
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

			/*GameObject[] ends;

			ends = GameObject.FindGameObjectsWithTag ("End");

			foreach (GameObject end in ends)
				end.GetComponent<Switch> ().on = false;*/

			GameObject[] wires;

			wires = GameObject.FindGameObjectsWithTag ("Wire");

			foreach (GameObject wire in wires)
				wire.GetComponent<Switch> ().on = false;


		}

	}

}
