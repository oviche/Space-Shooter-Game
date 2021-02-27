// include namespaces
using UnityEngine;
using System.Collections;
using UnityEngine.UI;
//================================================================================================================================================
public class player : MonoBehaviour {
	public Boundary boundary;
	public Motion motion;
	public FireSpeed fireSpeed;
	public GameObject shot;
	public Transform[] shotSpawn;
	//================================================================================================================================================
	void fire()
	{
		fireSpeed.nextFire = Time.time + fireSpeed.fireRate;//make different time bettween shoots
		Instantiate (shot, shotSpawn[0].position, shotSpawn[0].rotation);//create fire
		GetComponent<AudioSource>().Play();// play music
		
		if (PowerUps.powerUpCounter== 1)
			Instantiate (shot, shotSpawn[1].position, shotSpawn[1].rotation);
		//make player 1 shot with two bullets at a time
		else if (PowerUps.powerUpCounter >= 2) {
			Instantiate (shot, shotSpawn[1].position, shotSpawn[1].rotation);
			Instantiate (shot, shotSpawn[2].position, shotSpawn[2].rotation);
			//make player 1 shot with theree bullets at a time
		}
	}
	//================================================================================================================================================
	void move ()
	{
		float moveHorizontal = Input.GetAxis ("Horizontal");//get input to move horizontal
		float moveVertical = Input.GetAxis ("Vertical");//get input to move vertical
		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);//the new positions values
		GetComponent<Rigidbody> ().velocity = movement * motion.speed;//velcity of the player
		GetComponent<Rigidbody> ().position = new Vector3 (
			Mathf.Clamp (GetComponent<Rigidbody> ().position.x, boundary.xMin, boundary.xMax),
			0.0f,
			Mathf.Clamp (GetComponent<Rigidbody> ().position.z, boundary.zMin, boundary.zMax)
			);
		//make the position of the player not exide the boundary 
		GetComponent<Rigidbody> ().rotation = Quaternion.Euler (0.0f,0.0f, (GetComponent<Rigidbody> ().velocity.x) * -motion.tilt );
		//make the playe rotate when he move right or left
	}
	//================================================================================================================================================
	void Start ()
	{
		fireSpeed.nextFire = 0;
	}
	//================================================================================================================================================
	void Update()
	{
		if (Time.timeScale!=0&&Input.GetButton ("Fire1") && Time.time > fireSpeed.nextFire) {//to fire 
			fire ();
		}
	}
	//================================================================================================================================================
	void FixedUpdate()// fixed update function is better than Update as it move the bodies smoothly.
	{
		move ();//to move the body
	}
}