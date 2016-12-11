using UnityEngine;
using System.Collections;

public class GateOutput : MonoBehaviour {

	public GameObject input1;
	public GameObject input2;
	public GameObject output;
	public bool doubleInput = false;

	public bool and = false;
	public bool or = false;
	public bool not = false;
	public bool nand = false;
	public bool nor = false;
	public bool eor = false;
	public bool enor = false;

	// Use this for initialization
	void Start () 
	{
		
	
	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{
		if (and) 
		{
			if (input1.GetComponent<Switch> ().output == true && input2.GetComponent<Switch> ().output == true) {
				output.GetComponent<Switch> ().on = true;
				output.GetComponent<Switch> ().output = true;
			} else {
				output.GetComponent<Switch> ().on = false;
				output.GetComponent<Switch> ().output = false;
			}

		}

		if (or) 
		{
			if (input1.GetComponent<Switch> ().output == true || input2.GetComponent<Switch> ().output == true) {
				output.GetComponent<Switch> ().on = true;
				output.GetComponent<Switch> ().output = true;
			}
			else {
				output.GetComponent<Switch> ().on = false;
				output.GetComponent<Switch> ().output = false;
			}

		}

		if (not) 
		{
			if (input1.GetComponent<Switch> ().output == true) {
				output.GetComponent<Switch> ().on = false;
				output.GetComponent<Switch> ().output = false;
			} else {
				output.GetComponent<Switch> ().output = true;
				output.GetComponent<Switch> ().on = true;
			}

		}

		if (nand) 
		{
			if (input1.GetComponent<Switch> ().output == true && input2.GetComponent<Switch> ().output == true) {
				output.GetComponent<Switch> ().on = false;
				output.GetComponent<Switch> ().output = false;
			} else {
				output.GetComponent<Switch> ().on = true;
				output.GetComponent<Switch> ().output = true;
			}

		}

		if (nor) 
		{
			if (input1.GetComponent<Switch> ().output == true || input2.GetComponent<Switch> ().output == true) {
				output.GetComponent<Switch> ().on = false;
				output.GetComponent<Switch> ().output = false;
			}
			else {
				output.GetComponent<Switch> ().on = true;
				output.GetComponent<Switch> ().output = true;
			}

		}

		if (eor) 
		{
			if ((input1.GetComponent<Switch> ().output == true && input2.GetComponent<Switch> ().output == false) || (input1.GetComponent<Switch> ().output == false && input2.GetComponent<Switch> ().output == true)) {
				output.GetComponent<Switch> ().on = true;
				output.GetComponent<Switch> ().output = true;
			}
			else {
				output.GetComponent<Switch> ().on = false;
				output.GetComponent<Switch> ().output = false;
			}

		}

		if (enor) 
		{
			if ((input1.GetComponent<Switch> ().output == true && input2.GetComponent<Switch> ().output == false) || (input1.GetComponent<Switch> ().output == false && input2.GetComponent<Switch> ().output == true)) {
				output.GetComponent<Switch> ().on = false;
				output.GetComponent<Switch> ().output = false;
			}
			else {
				output.GetComponent<Switch> ().on = true;
				output.GetComponent<Switch> ().output = true;
			}

		}


	}

}
