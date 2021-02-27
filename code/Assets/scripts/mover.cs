// include namespaces
using UnityEngine;
using System.Collections;
using UnityEngine.UI;
//================================================================================================================================================
public class mover : MonoBehaviour
{
	public float speed;

	void Start () {// this to move rocks or bullets from the enemy or the player with known speed
		GetComponent<Rigidbody> ().velocity = transform.forward * speed;
	}
}