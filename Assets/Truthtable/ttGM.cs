using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class ttGM : MonoBehaviour {
	public Sprite tr, fa, and, disj, iof, ift, or;
	public float timer, points, score;
	public Text timerText, endtext;
	public Button tb, fb, eb;
	public GameObject leftS, rightS, mid;
	private int which = 1;
	private bool test1 , test2, answer ;
	public string show1, show2;
	// Use this for initialization
	void Start () {
		endtext.enabled = false;


		//leftS.GetComponent<SpriteRenderer> ().sprite = tr;
		//leftS.GetComponent<SpriteRenderer> ().sprite = fa;
		//rightS.GetComponent<SpriteRenderer> ().sprite = tr;
		//rightS.GetComponent<SpriteRenderer> ().sprite = fa;
		//mid.GetComponent<SpriteRenderer> ().sprite = and;
		diceroll();


	}
	void Update () {
		endtext.text = "Your score is: " + score.ToString ();
		timer -= Time.deltaTime;
		timerText.text = timer.ToString ("f0") +"  Points left: "+points.ToString()+"  score: "+score.ToString();
		//shift ();
		//Debug.Log (which);
		if (timer <= 0) {
			wrong ();
			diceroll ();
		}
		if (points <= 0) {
			tb.gameObject.SetActive (false);
			fb.gameObject.SetActive (false);
			leftS.SetActive (false);
			rightS.SetActive (false);
			mid.SetActive (false);
			eb.gameObject.SetActive (true);
			endtext.enabled = true;

		}

	}
	public void ansTrue(){
		answer = true;
		if (which == 1)
			andM (answer);
		else if (which == 2)
			orM (answer);
		else if (which == 3)
			itM (answer);
		else if (which == 4)
			iofM (answer);
		else
			disjM (answer);
	}
	public void ansFalse(){
		answer = false;
		if (which == 1)
			andM (answer);
		else if (which == 2)
			orM (answer);
		else if (which == 3)
			itM (answer);
		else if (which == 4)
			iofM (answer);
		else
			disjM (answer);
	}
	void shift(){
		which = Random.Range (1, 6);
	}
	void andM(bool input){
		if (test1 == true && test2 == true) {
			Debug.Log ("1");
			if (input == true)
				right ();
			else
				wrong ();
		}
		if (test1 == true && test2 == false) {
			Debug.Log ("2");
			if (input == true)
				wrong ();
			else
				right ();
		}
		if(test1 == false && test2 ==true){
			Debug.Log ("3");
			if (input == true)
				wrong ();
			else
				right ();
		}
		if(test1 == false && test2==false){
			Debug.Log ("4");
			if (input == true)
				wrong ();
			else
				right ();
		}
		diceroll (); 
	}
	void orM(bool input){	
		if (test1 == true && test2 == true) {
			Debug.Log ("1");
			if (input == true)
				right ();
			else
				wrong ();
		}
		if (test1 == true && test2 == false) {
			Debug.Log ("2");
			if (input == true)
				right ();
			else
				wrong ();
		}
		if(test1 == false && test2 ==true){
			Debug.Log ("3");
			if (input == true)
				right ();
			else
				wrong ();
		}
		if(test1 == false && test2==false){
			Debug.Log ("4");
			if (input == true)
				wrong ();
			else
				right ();
		}

		diceroll (); 
	}
	void itM(bool input){	
		if (test1 == true && test2 == true) {
			Debug.Log ("1");
			if (input == true)
				right ();
			else
				wrong ();
		}
		if (test1 == true && test2 == false) {
			Debug.Log ("2");
			if (input == true)
				wrong ();
			else
				right ();
		}
		if(test1 == false && test2 ==true){
			Debug.Log ("3");
			if (input == true)
				right ();
			else
				wrong ();
		}
		if(test1 == false && test2==false){
			Debug.Log ("4");
			if (input == true)
				right ();
			else
				wrong ();
		}

		diceroll (); 
	}
	void iofM(bool input){	
		if (test1 == true && test2 == true) {
			Debug.Log ("1");
			if (input == true)
				right ();
			else
				wrong ();
		}
		if (test1 == true && test2 == false) {
			Debug.Log ("2");
			if (input == true)
				wrong ();
			else
				right ();
		}
		if(test1 == false && test2 ==true){
			Debug.Log ("3");
			if (input == true)
				wrong ();
			else
				right ();
		}
		if(test1 == false && test2==false){
			Debug.Log ("4");
			if (input == true)
				right ();
			else
				wrong ();
		}

		diceroll (); 
	}
	void disjM(bool input){	
		if (test1 == true && test2 == true) {
			Debug.Log ("1");
			if (input == true)
				wrong ();
			else
				right ();
		}
		if (test1 == true && test2 == false) {
			Debug.Log ("2");
			if (input == true)
				right ();
			else
				wrong ();
		}
		if(test1 == false && test2 ==true){
			Debug.Log ("3");
			if (input == true)
				right ();
			else
				wrong ();
		}
		if(test1 == false && test2==false){
			Debug.Log ("4");
			if (input == true)
				wrong ();
			else
				right ();
		}

		diceroll (); 
	}


	void right(){
		timer = 7f;
		score++;
	//	diceroll ();

	}
	void wrong(){
		timer = 7f;
		points--;
	//	diceroll ();

	}
	void diceroll(){
		int dice = Random.Range (0, 100);

		if (dice > 50) {
			leftS.GetComponent<SpriteRenderer> ().sprite = tr;
			test1 = true;
		} else {
			leftS.GetComponent<SpriteRenderer> ().sprite = fa;
			test1 = false;

		}
		dice = Random.Range (0, 100);
		which = Random.Range (1, 6);

		if (dice > 50) {
			rightS.GetComponent<SpriteRenderer> ().sprite = tr;
			test2 = true;
		} else {
			rightS.GetComponent<SpriteRenderer> ().sprite = fa;
			test2 = false;
		}
		if (which == 1)
			mid.GetComponent<SpriteRenderer> ().sprite = and;

		if (which == 2)
			mid.GetComponent<SpriteRenderer> ().sprite = or;

		if (which == 3)
			mid.GetComponent<SpriteRenderer> ().sprite = ift;

		if (which == 4)
			mid.GetComponent<SpriteRenderer> ().sprite = iof;

		if (which == 5)
			mid.GetComponent<SpriteRenderer> ().sprite = disj;
		//leftS.GetComponent<SpriteRenderer> ().sprite = tr;
		//leftS.GetComponent<SpriteRenderer> ().sprite = fa;
		//rightS.GetComponent<SpriteRenderer> ().sprite = tr;
		//rightS.GetComponent<SpriteRenderer> ().sprite = fa;
	}
	public void gotot(){
		SceneManager.LoadScene ("Menu");
	}
}
