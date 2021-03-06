﻿using UnityEngine;
using System.Collections;

public class Switch : MonoBehaviour 
{
	public bool on = false;
	public bool output = false;
	public bool switchStart = false;
	public CircuitsController cc;
	public bool isWire;
	//public bool isNotGate;
	//public bool isAndGate;
	//public bool isOrGate;
	public bool rotate;


	void Start()
	{
		cc = GameObject.FindGameObjectWithTag ("GameController").GetComponent<CircuitsController>();

	}
		
	void FixedUpdate()
	{
		if (isWire) 
		{
			if (on)
				output = true;
			else
				output = false;
		}

		/*if (isNotGate) 
		{
			if (on)
				output = false;
			else
				output = true;
		}*/


	}


	void OnTriggerStay2D(Collider2D other)
	{
		
		if ((this.gameObject.tag == "Wire") && (other.gameObject.tag == ("OutputOfGate") || other.gameObject.tag == ("Start")))
			this.GetComponent<Switch> ().on = other.GetComponent<Switch> ().on;


		if (this.gameObject.tag == "InputOfGate" && (other.gameObject.tag == ("Wire")))
			this.GetComponent<Switch> ().on = other.GetComponent<Switch> ().on;
		
					

			/*if (other.gameObject == null && isNotGate)
				on = false;*/
		

	}

	void OnTriggerExit2D(Collider2D other)
	{
		GameObject[] wires;

		wires = GameObject.FindGameObjectsWithTag ("Wire");

		foreach (GameObject wire in wires)
			wire.GetComponent<Switch> ().on = false;

		GameObject[] innputs;

		innputs = GameObject.FindGameObjectsWithTag ("InputOfGate");

		foreach (GameObject innput in innputs)
			innput.GetComponent<Switch> ().on = false;
				

		/*GameObject[] nots;

		nots = GameObject.FindGameObjectsWithTag ("Not");

		foreach (GameObject not in nots) {
			not.GetComponent<Switch> ().on = false;
			not.GetComponent<Switch> ().output = true;

		}*/



	}

}
