//include name spaces.
using UnityEngine;
using System.Collections;
using UnityEngine.UI;
//==========================================================================================================================
public class destroyByContactEnemyMode : MonoBehaviour 
{
	public GameObject explosion;
	public GameObject playerExplosion;
	private gameControllerModeEnemies control;
	public int score;//score of destroy the hazard
	//==========================================================================================================================
	void OnTriggerEnter(Collider other) {
		if (other.tag == "bolt") {// player when hit the rock by bolt
			Destroy (gameObject);//destroy the rock
			Destroy (other.gameObject);//destroy the bolt
			control.UpdateScore(score);// control this is calling from gamecontroller the updating the score when destroy rocks
			Instantiate (explosion, transform.position, transform.rotation);//make the animation of explosion appear in the sameplace of the player position 

		} else if (other.tag == "Player" && (control.health-control.hazards.asteroidsDamage[0]) <= 0) {//if the rock hit the player and can destroy him
			Destroy (gameObject);
			Destroy (other.gameObject);
			Instantiate (playerExplosion, other.transform.position, other.transform.rotation);
			control.decreaseHealth(score);

			control.loseWindow();
		} else if(other.tag == "Player"){//if the rock hit the player but can't destroy him
			Destroy (gameObject);
			Instantiate (explosion, transform.position, transform.rotation);
			control.health=control.health-control.hazards.asteroidsDamage[0];
			control.decreaseHealth(score);
			control.UpdateScore(score);
			if(PowerUps.powerUpCounter>0)
			PowerUps.powerUpCounter--;
		}
	}
	//==========================================================================================================================
	void Start()
	{//make an object to hold the class from other object in the game to can access it.
		GameObject gameControllerObject = GameObject.FindGameObjectWithTag ("gameControllerEnemy");
		control = gameControllerObject.GetComponent<gameControllerModeEnemies> ();
	}
}