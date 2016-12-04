using UnityEngine;
using System.Collections;

public class MouseDrag : MonoBehaviour 
{
	public CircuitsController cc;

	float distance = 10;

	void Start()
	{
		cc = GameObject.FindGameObjectWithTag ("GameController").GetComponent<CircuitsController>();

	}

	void Update()
	{


	}
		
	void OnMouseDrag()
	{
			Vector3 mousePosition = new Vector3 (Input.mousePosition.x, Input.mousePosition.y, distance);
			Vector3 objPosition = Camera.main.ScreenToWorldPoint (mousePosition);

			transform.position = objPosition;

	}

	void OnMouseUp()
	{
		/*if(cc.selected != null)
			cc.selected.GetComponent<SpriteRenderer>().color = Color.white;*/

		//Debug.Log ("Selected");
		cc.selected = this.gameObject;
		/*cc.selected.GetComponent<SpriteRenderer>().color = Color.yellow;*/

	}

}
