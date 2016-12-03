using UnityEngine;
using System.Collections;

public class CircuitsController : MonoBehaviour 
{
	public GameObject selected;

	public int whichInArray;

	public GameObject[] selectArray;


	public void Deselect()
	{
		selected = null;

	}

	public void Delete()
	{
		Destroy (selected.gameObject);

	}

	public void SelectDown()
	{
		if (whichInArray > 0) 
		{
			whichInArray--;

		}
		else 
		{
			whichInArray = selectArray.Length -1;
		}

	}

	public void SelectUp()
	{
		if (whichInArray < selectArray.Length -1) 
		{
			whichInArray++;

		}
		else 
		{
			whichInArray = 0;
		}

	}
}
