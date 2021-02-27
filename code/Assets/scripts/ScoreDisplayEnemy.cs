// include namespaces
using UnityEngine;
using System.Collections;
using UnityEngine.UI;
//================================================================================================================================================
public class ScoreDisplayEnemy : MonoBehaviour 
{
	void Start () 
	{//to put in the text the score in string then reset it in the first time.
		Text myText = GetComponent<Text> ();
		myText.text = gameControllerModeEnemies.Score.ToString ();
		gameController.ResetScore ();
	}
}