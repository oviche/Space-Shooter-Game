//include name spaces.
using UnityEngine;
using System.Collections;
//============================================================================================================================================================
public class destroyByBoundary : MonoBehaviour 
{
	void OnTriggerExit(Collider other) {
		// destroy everythings exit the screen(trigger) to decrease area used in ram and make game faster and not to lag
		Destroy(other.gameObject);
	}
}