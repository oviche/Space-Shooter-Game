//include name spaces.
using UnityEngine;
using System.Collections;
//==========================================================================================================================
public class destroyByTime : MonoBehaviour 
{
	// to destroy the object after 1 sec.
	void Start () {
		Destroy (gameObject, 1);
	}
}