// include namespaces
using UnityEngine;
using System.Collections;
using UnityEngine.UI;
//================================================================================================================================================
public  class powerUp : MonoBehaviour  
{
	void OnTriggerEnter(Collider other) {
		if (other.tag == "bolt" ) {//if the power up hit the bolt from player  it will increase the counter of it
			Destroy (gameObject);
			Destroy (other.gameObject);
			if(PowerUps.powerUpCounter<2)
			PowerUps.powerUpCounter++;}
		else if (other.tag == "Player"){//if the power up hit the  player himself it will increase the counter of it
			Destroy (gameObject);
			if(PowerUps.powerUpCounter<2)
			PowerUps.powerUpCounter++;
		}
                                       }
}