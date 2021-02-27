//include name spaces.
using UnityEngine;
using System.Collections;
//================================================================================================================================================
public class powerUp1VSMode : MonoBehaviour
{
	void OnTriggerEnter(Collider other) 
	{
		if (other.tag == "bolt" ) {//if the power up hit the bolt from player one it will increase the counter of it
			Destroy (gameObject);
			Destroy (other.gameObject);
			if(player1ModeVs.powerUp1Counter<2)
			player1ModeVs.powerUp1Counter++;}
		else if(other.tag == "bolt2" ) {//if the power up hit the bolt from player two it will increase the counter of it
			Destroy (gameObject);
			Destroy (other.gameObject);
			if(player1ModeVs.powerUp1Counter<2)
			player2ModeVs.powerUp1Counter++;
                                      }
	}
}