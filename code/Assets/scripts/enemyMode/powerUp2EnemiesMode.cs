//include name spaces.
using UnityEngine;
using System.Collections;
//================================================================================================================================================
public class powerUp2EnemiesMode : MonoBehaviour 
{
	gameControllerModeEnemies controller;
	//================================================================================================================================================
	void Start()
	{//we need the object controller to find the object in the game that hold the class that we want no access in.
		controller= GameObject.Find ("gameController").GetComponent< gameControllerModeEnemies > ();
	}
	//================================================================================================================================================
	void OnTriggerEnter(Collider other) 
	{
		if (other.tag == "bolt" ) 
		{
			Destroy (gameObject);
			Destroy (other.gameObject);
			if(controller.health+25<=100)
				controller.health+=25;
			else
				controller.health=100;
			//controller.health+=25;
			controller.guiManger.healthBar[0].value=controller.health;
		}
		else if(other.tag == "Player" ) 
		{
			Destroy (gameObject);
			if(controller.health+25<=100)
				controller.health+=25;
			else
				controller.health=100;
			controller.guiManger.healthBar[0].value=controller.health;
		}
	}
}