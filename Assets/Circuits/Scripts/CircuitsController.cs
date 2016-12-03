using UnityEngine;
using System.Collections;

public class CircuitsController : MonoBehaviour 
{
	public GameObject selected;

	public void Deselect()
	{
		selected = null;

	}

	public void Delete()
	{
		Destroy (selected.gameObject);

	}
}
