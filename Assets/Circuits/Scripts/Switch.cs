using UnityEngine;
using System.Collections;

public class Switch : MonoBehaviour 
{
	public bool on = false;
	public bool switchStart = false;
	public CircuitsController cc;


	void Start()
	{
		cc = GameObject.FindGameObjectWithTag ("GameController").GetComponent<CircuitsController>();

	}


	void OnTriggerStay2D(Collider2D other)
	{
		Debug.Log ("ajb");


		if (other.gameObject.GetComponent<Switch> ().on == true) {
			on = true;

		}/* else
			on = false;*/

		if (on == true) 
		{
			other.gameObject.GetComponent<Switch>().on = true;

		}
		/*else
			other.gameObject.GetComponent<Switch>().on = false;*/


		/*if(!switchStart && other.gameObject == null)
			on = false;*/



	}

	void OnTriggerExit2D(Collider2D other)
	{
		GameObject[] wires;

		wires = GameObject.FindGameObjectsWithTag ("Wire");

		foreach (GameObject wire in wires)
		{
			wire.GetComponent<Switch> ().on = false;

		}

	}

}
