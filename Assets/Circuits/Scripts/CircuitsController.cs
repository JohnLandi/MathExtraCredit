using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CircuitsController : MonoBehaviour 
{
	public GameObject selected;

	public GameObject SpawnPosition;

	public int whichInArray;

	public GameObject[] selectArray;

	public string[] selectArrayText;

	public Text spawnText;

	public GameObject WireRotatorGO;
	public Slider WireRotater;


	void FixedUpdate()
	{
		updateSpawnText ();

		if (selected != null) {
			WireRotate ();
		}

	}

	public void Deselect()
	{
		if (selected != null)
		{
			selected.GetComponent<SpriteRenderer> ().color = Color.white;
			selected = null;
		}

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

	public void Create()
	{
		Instantiate(selectArray[whichInArray], SpawnPosition.transform.position, SpawnPosition.transform.rotation);

	}

	public void updateSpawnText()
	{
		if (spawnText) 
		{
			string hud = selectArrayText[whichInArray];
			spawnText.text = hud;
		}
	}

	public void WireRotate()
	{
		if (selected.gameObject.tag == "Wire" && selected.gameObject.GetComponent<Switch>().rotate == true) 
		{
			WireRotatorGO.SetActive (true);

			selected.transform.rotation = Quaternion.Euler (0, 0, WireRotater.value);

		}

		else
			WireRotatorGO.SetActive (false);



	}

	/*public void SelectedColor()
	{
		selected.GetComponent<SpriteRenderer>().color = Color.yellow;

	}*/
}
