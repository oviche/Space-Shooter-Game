//include name spaces.
using UnityEngine;
using System.Collections;
//===============================================================================================================================================
public class destroyByContactVSMode : MonoBehaviour
{
	public GameObject explosion;

	void OnTriggerEnter(Collider other) {
		
		if (other.tag == "bolt" || other.tag == "bolt2") {//bullet hit rocks 
			Destroy (gameObject);//destroy rocks
			Destroy (other.gameObject); //destroy bullet
			Instantiate (explosion, transform.position, transform.rotation); //explosion appear
		                                                 }
	                                   }	
}