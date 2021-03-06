using UnityEngine;
using System.Collections;

public class SelectPortion: MonoBehaviour {
	
	public bool selected = false;
	public bool clicked = false;
	private Color opaque = new Color (1f, 1f, 1f, 1f);
	private Color semiTransparent = new Color(1f,1f,1f,0.3f);
	private Color Transparent = new Color (1f, 1f, 1f, 0f);
	//public float opacity = 0.0f;
	public Color c;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		GetComponent<SpriteRenderer> ().color = c;
		if (clicked)
		{
			c = opaque;
		}
		else if ((!clicked) && (selected))
		{
			c = semiTransparent;
		}
		else if((!selected)&&(!clicked))
		{
			c = Transparent;
		}
	}

	void OnMouseOver()
	{
		selected = true;
	}

	void OnMouseExit()
	{
		if (!clicked)
		{
			selected = false;
		}
	}

	void OnMouseUp()
	{
		if (!clicked)
		{
			clicked = true;
		}
		else
		{
			clicked = false;
		}

	}
}
