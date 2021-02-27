// include namespaces
using UnityEngine;
using System.Collections;
using UnityEngine.UI;
//================================================================================================================================================
public class ScoreKeepe : MonoBehaviour {
	public static int score =0;
	private Text myText;
	//================================================================================================================================================
	public static void Reset(){//to reset the score in the text
		score = 0;
	}
	//================================================================================================================================================
	void Start () {
		myText = GetComponent<Text> ();//to access the text
		Reset ();
	}
	//================================================================================================================================================
	public void Score (int points){//function that take the points and add it to the score and to the text on the screen
		score += points;
		myText.text = score.ToString();
	}

}
