//include name spaces.
using UnityEngine;
using System.Collections;
//================================================================================================================================================
public class powerUp3VSMode : MonoBehaviour 
{
	gameControllerModeVs controller;
	//================================================================================================================================================
	void Start()
	{//we need the object controller to find the object in the game that hold the class that we want no access in.
		controller= GameObject.Find ("gameController").GetComponent< gameControllerModeVs > ();
	}
	//================================================================================================================================================
	void OnTriggerEnter(Collider other) 
	{
		if (other.tag == "bolt" ) //if the power up hit the bolt from player two it will increase by 15
		{
			Destroy (gameObject);
			Destroy (other.gameObject);
			if(gameControllerModeVs.health[0]+15<=100)
				gameControllerModeVs.health[0]+=15;
			else
				gameControllerModeVs.health[0]=100;
			controller.increaseHealthBar(1);
		}
		else if(other.tag == "bolt2" ) //if the power up hit the bolt from player one it will increase by 15
		{
			Destroy (gameObject);
			Destroy (other.gameObject);
			if(gameControllerModeVs.health[1]+15<=100)
				gameControllerModeVs.health[1]+=15;
			else
				gameControllerModeVs.health[1]=100;
			controller.increaseHealthBar(2);
		}
	}
}