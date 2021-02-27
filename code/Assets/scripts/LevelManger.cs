// include namespaces
using UnityEngine;
using System.Collections;
using UnityEngine.UI;
//================================================================================================================================================
public class LevelManger : MonoBehaviour 
{
	public void LoadLevel(string name){//this function can call the other scene when i click on a buttom by sending it the name of the scene that you want.
		Time.timeScale = 1;
		gameControllerModeVs.round = 1;
		Application.LoadLevel (name);

	}
	public void QuitRequest(){//to quit from the game when you click on a buttom and call it .
		Application.Quit ();
	}
}