using UnityEngine;
using System.Collections;

public class Switch : MonoBehaviour 
{
	public bool on = false;
	public bool switchStart = false;


	void OnTriggerStay2D(Collider2D other)
	{
		Debug.Log ("ajb");


		if (other.gameObject.GetComponent<Switch>().on == true) 
		{
			on = true;

		}

		if (on == true) 
		{
			other.gameObject.GetComponent<Switch>().on = true;

		}

	}

	void OnTriggerExit2D(Collider2D other)
	{
		if(switchStart == false)
			on = false;


	}

}
