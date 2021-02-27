// include namespaces
using UnityEngine;
using System.Collections;
using UnityEngine.UI;
//================================================================================================================================================
public class randomRotation : MonoBehaviour 
{
	public float tumble;

	void Start () {
		GetComponent<Rigidbody> ().angularVelocity = Random.insideUnitSphere * tumble;
		//to rotate the body from it's center by a tumble value
	}
}