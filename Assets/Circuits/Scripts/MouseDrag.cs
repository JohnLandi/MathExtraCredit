using UnityEngine;
using System.Collections;

public class MouseDrag : MonoBehaviour 
{
	public CircuitsController cc;

	void Start()
	{
		cc = GameObject.FindGameObjectWithTag ("GameController").GetComponent<CircuitsController>();

	}

	float distance = 10;

	void OnMouseDrag()
	{
		Vector3 mousePosition = new Vector3 (Input.mousePosition.x, Input.mousePosition.y, distance);
		Vector3 objPosition = Camera.main.ScreenToWorldPoint (mousePosition);

		transform.position = objPosition;

	}

	void OnMouseDown()
	{
		Debug.Log ("Selected");
		cc.selected = this.gameObject;


	}

}
