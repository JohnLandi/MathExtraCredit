using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.Events;

public class GameController: MonoBehaviour 
{
	private InputField iField;
	private string Text;
	private char[] letters;
	private string [] equations;
	private int numParen = 0;
	private string[] terms;
	private string[] TwoTags;
	private string[] ThreeTags;
	private string[] tags;
	private GameObject[] TwoSections;
	private GameObject[] ThreeSections;
	private GameObject[] sections;
	private GameObject[][] GlobalObjectHolder;
	private int GlobalNumArrays = 0;
	public int numCircles = 3;
	public Button btn;
	void Start()
	{
		
		iField = GameObject.Find ("InputField").GetComponent<InputField>();
		TwoTags = new string[]{ "A", "B", "AB", "ABC", "AC", "BC", "U" };
		ThreeTags = new string[]{ "A", "B", "C", "AB", "AC", "BC", "ABC", "U"};
		TwoSections = new GameObject[TwoTags.Length];
		ThreeSections = new GameObject[ThreeTags.Length];
		Button button = btn.GetComponent<Button> ();
		button.onClick.AddListener (TashOnClick);
		if (numCircles == 2)
		{
			tags = TwoTags;
			sections = TwoSections;
		}
		else
		if (numCircles == 3)
			{
				tags = ThreeTags;
				sections = ThreeSections;
			}
		for (int i = 0; i < tags.Length; i++)
		{
			sections [i] = GameObject.FindGameObjectWithTag (tags [i]);
			//Debug.Log (sections [i]);
		}
	}
	public void TashOnClick()
	{
		int ChangeY = 6;
		if (numCircles == 2)
		{
			numCircles = 3;
			GameObject.FindGameObjectWithTag ("C").transform.Translate (new Vector3 (0, -ChangeY, 0));
			GameObject.FindGameObjectWithTag ("EmptyC").transform.Translate (new Vector3 (0, -ChangeY, 0));
		}
		else
		if (numCircles == 3)
		{
			numCircles = 2;
				GameObject.FindGameObjectWithTag ("C").transform.Translate (new Vector3 (0, ChangeY, 0));
				GameObject.FindGameObjectWithTag ("EmptyC").transform.Translate (new Vector3 (0, ChangeY, 0));
		}
		
		
	}
	void Print(GameObject[] ob)
	{
		for (int j = 0; j < ob.Length; j++)
		{
			Debug.Log ("Object " + (j + 1) + ": " + ob [j]);
		}
	}

	public void EndEdit(string entry)
	{
		Debug.Log ("You entered " + entry);
		//Print (sections);
		Text = iField.text;
		letters = new char[Text.Length];
		for (int a = 0; a < Text.Length; a++)
		{
			if (!(Text [a].Equals (' ')))
			{
				letters [a] = Text [a];
			}
			//Debug.Log(letters[a]);
		}
		iField.text = "";
		SortEquations (letters);
		numParen = 0;
		GlobalNumArrays = 0;
		Debug.Log ("GlobalGameObjects: ");
		for (int go = 0; go < GlobalObjectHolder.Length; go++)
		{
			for (int g = 0; g < GlobalObjectHolder[go].Length; g++)
			{
				Debug.Log ("Index " + go + "x" + g + ": " + GlobalObjectHolder[go] [g]);
			}
		}

	}

	public void SortEquations(char[] array)
	{
		foreach (char c in array)
		{
			if (c.Equals ('('))
			{
				numParen++;
			}
		}

		equations = new string[numParen];
		Debug.Log ("Number of parentheses: " + numParen);
		int equationsIndex = 0;
		int beginIndex;
		for (int i = array.Length - 1; i >= 0; i--)
		{
			if (array [i].Equals ('('))
			{
				beginIndex = i + 1;
				for (int j = beginIndex; j < array.Length; j++)
				{
					if (array [j].Equals (')'))
					{
						array [j] = '\0';
						break;
					}
					else
					{
						if (!(array [j].Equals ('\0')))
						{
							equations [equationsIndex] += array [j];
							array [j] = '\0';
						}
					}

				}
				equationsIndex++;
				array [i] = '\0';
			}

		}
		GlobalObjectHolder = new GameObject[(equations.Length)][];
		Debug.Log("GOH length: " + GlobalObjectHolder.Length);
		//Print (sections);
		for (int a = 0; a < equations.Length; a++)
		{
			Debug.Log("Equation " + (a+1) + ": " + equations[a]);
			GameObject[] objectList = BreakUpTerms(equations[a]);
			Debug.Log("BrokenTerms List length: " + objectList.Length);
			for (int c = 0; c < objectList.Length; c++)
			{
				Debug.Log("Broken up terms for " + equations[a] + ": " + objectList[c]);
			}
		}

	}

	//Takes any given equation and breaks them up by the operator used in the given equation to split it up into 2 separate terms
	//If there is no operator found, it takes the given equation as is
	//Saves each array in global 2D gameobject array
	public GameObject[] BreakUpTerms(string s)
	{
		bool union = false;
		bool intersect = false;
		bool minus = false;
		GameObject[] compareTerms = new GameObject[sections.Length];
		char[] operators = new char[]{ '&', 'X', '-' };
		bool[] operations = new bool[]{union, intersect, minus};

		//Debug.Log ("S.length: " + s.Length);
		if (s.Length >= 3)
		{
			foreach (char c in s)
			{
				for (int j = 0; j < operators.Length; j++)
				{
					if (c.Equals (operators [j]))
					{
						terms = s.Split (operators [j]);
						operations [j] = true;
						for(int k = 0; k < terms.Length; k++)
						{
							Debug.Log("Term: " + terms[k]);
							Debug.Log ("Object list for term " + terms[k] + ": ");
							GameObject[] list = MakeObjectList (terms[k]);
							for (int l = 0; l < list.Length; l++)
							{
								Debug.Log (list[l].ToString());
							}

						}
						//compareTerms = PerformOperation (MakeObjectList (terms [0]), MakeObjectList(terms[1]), operators [j]);
					}
				}
			}
			for (int b = 0; b < operations.Length; b++)
			{
				if (operations[b] == true)
				{
					GameObject[] term1 = MakeObjectList (terms [0]);
					GameObject[] term2 = MakeObjectList (terms [1]);
					/*for (int c = 0; c < Mathf.Max (term1.Length, term2.Length); c++)
					{
						Debug.Log("Term1 item " + (c+1) + ": " + term1[c]);
						Debug.Log("Term2 item " + (c+1) + ": " + term2[c]);
					}*/

					compareTerms = PerformOperation (term1, term2, operators [b]);
					GlobalObjectHolder [GlobalNumArrays] = compareTerms;
					GlobalNumArrays++;
					Debug.Log (" Length = 3 GNA: " + GlobalNumArrays);
				}
			}


		}
		else
		{
			terms = new string[]{ s };
			if (s.Length == 1)
			{
				Debug.Log ("current string: " + s);
				bool IsOp = false;
				char op = operators[0];
				for (int c = 0; c < operators.Length; c++)
				{
					if (s [0].Equals (operators [c]))
					{
						IsOp = true;
						op = operators [c];
					}
				}
				if (IsOp == true)
				{
					Debug.Log ("GNA - 1: " + (GlobalNumArrays - 1));
					Debug.Log ("GNA - 2: " + (GlobalNumArrays - 2));
					compareTerms = PerformOperation (GlobalObjectHolder [1], GlobalObjectHolder [0], operators [op]);
					Debug.Log ("GNA - 1: " + (GlobalNumArrays - 1));
					Debug.Log ("GNA - 2: " + (GlobalNumArrays - 2));
					GlobalObjectHolder [GlobalNumArrays] = compareTerms;
					GlobalNumArrays++;
					Debug.Log ("IsOp GNA: " + GlobalNumArrays);
				}
				else
				{
					compareTerms = MakeObjectList (s);
					GlobalObjectHolder [GlobalNumArrays] = compareTerms;
					GlobalNumArrays++;
					Debug.Log (" NOT IsOp GNA: " + GlobalNumArrays);
				}
			}
			else if (s.Length == 2)
			{
				Debug.Log ("current string: " + s);
				compareTerms = MakeObjectList (s);
				GlobalObjectHolder [GlobalNumArrays] = compareTerms;
				GlobalNumArrays++;
				Debug.Log (" Length = 2 GNA: " + GlobalNumArrays);
			}
		}

		return compareTerms;

	}

	//returns a single game object array after performing the set operations (union, intersect, and subtraction)
	//returns the array without any null objects
	public GameObject[] PerformOperation(GameObject[] g1, GameObject[] g2, char c)
	{
		//Debug.Log (g2);
		//Debug.Log (g2 [0]);
		GameObject[] objects = new GameObject[g1.Length + g2.Length];
		GameObject[] resultingObjects;
		if (c.Equals ('&'))
		{
			int nextIndex = 0;
			for (int o = 0; o < g1.Length; o++)
			{
				objects [o] = g1 [o];
				nextIndex ++; // can also say 'nextIndex = o;'
			}
			for (int o = 0; o < g2.Length; o++)
			{
				//Debug.Log("Next Index = " + nextIndex);
				bool alreadyAdded = false;
				for (int p = 0; p < g1.Length; p++)
				{
					//Debug.Log ("g2[o]: " + g2 [o]);
					if (g2 [o].tag.Equals (objects[p].tag))
					{
						//Debug.Log ("Already added: " + g2 [o]);
						alreadyAdded = true;
					}
				}
				if (alreadyAdded == false)
				{
					Debug.Log ("Not already added: " + g2 [o]);
					objects [nextIndex] = g2 [o];
					nextIndex++;
				}
				else
				{
					Debug.Log ("Already added: " + g2 [o]);
				}
			}
		}
		else
		if (c.Equals ('X'))
		{
			int counterI = 0;
			for (int o = 0; o < g1.Length; o++)
			{
				for (int g = 0; g < g2.Length; g++)
				{
					if (g2[g].tag.Equals(g1[o].tag))
					{
						objects [counterI] = g1[o];
						counterI++;
					}
				}
			}
		}
		else
		if (c.Equals ('-'))
		{
			int counterM = 0;
			for (int g = 0; g < g1.Length; g++)
			{
				//Debug.Log ("G1 object: " + g1[g]);
				
				bool notMatched = true;
				for (int p = 0; p < g2.Length; p++)
				{
					//Debug.Log("G2 Object: " + g2[p]);
					if (g1[g].tag.Equals(g2[p].tag))
					{
						Debug.Log ("Removed: " + g1[g]);
						Debug.Log ("Because it was a copy of: " + g2[p]);
						notMatched = false;
					}
				}
				if (notMatched)
				{
					objects [counterM] = g1[g];
					Debug.Log ("Added: " + g1[g]);
					counterM++;
				}
			}
		}
		int numObjects = 0;
		//Debug.Log ("Objects Length: " + objects.Length);
		for (int o = 0; o < objects.Length; o++)
		{
			if (objects [o] != null)
			{
				numObjects++;
			}
		}
		resultingObjects = new GameObject[numObjects];
		Debug.Log ("Num Objects: " + numObjects);
		for (int o = 0; o < resultingObjects.Length; o++)
		{
				resultingObjects [o] = objects [o];
				Debug.Log ("Resulting List object in perform operation: " + resultingObjects [o]);
		}

		return resultingObjects;
	}

	//returns the array of game objects for each term in a given equation in between parentheses
	//Returns this array without any nulls at the end
	public GameObject[] MakeObjectList(string s)
	{
		bool notOperator = false;
		GameObject[] tempSections = new GameObject[sections.Length];
		//Print (TwoSections);
		int tempCounter = 0;

		foreach (char c in s)
		{
			if (c.Equals ('\''))
				notOperator = true;
		}
		if (notOperator == true)
		{
			for (int j = 0; j < sections.Length; j++)
			{
				//Debug.Log ("Checking: " + sections[j]);
				if ((sections [j].tag.Contains ((s [0].ToString ()))) == false)
				{
					tempSections [tempCounter] = sections [j];
					tempCounter++;
					//Debug.Log ("Added: " + sections [j]);
				}
				else
				{
					//Debug.Log ("Did not add: " + sections [j]);
				}
			}
		}
		else
		{
			for(int j = 0; j < sections.Length; j++)
			{
				//Debug.Log ("Checking: " + sections[j]);
				if ((sections [j].tag.Contains (s [0].ToString ())) == true)
				{
					tempSections [tempCounter] = sections [j];
					tempCounter++;
					//Debug.Log ("Added: " + sections [j]);
				}
				else
				{
					//Debug.Log ("Did not add: " + sections [j]);
				}
			}
		}
		int TotalNumObjects = 0;
		for (int j = 0; j < tempSections.Length; j++)
		{
			if (tempSections [j] != null)
			{
				TotalNumObjects++;
			}
		}
		GameObject[] objects = new GameObject[TotalNumObjects];
		for (int j = 0; j < objects.Length; j++)
		{
			objects [j] = tempSections [j];
		}
		return objects;
	}



}