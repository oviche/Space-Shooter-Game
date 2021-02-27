//include name spaces.
using UnityEngine;
using System.Collections;
//============================================================================================================================================================
public class playerModeEnemies : MonoBehaviour {
	public Boundary boundary;// Boundary  struct
	public Motion motion;// Motion struct
	public FireSpeed fireSpeed;//FireSpeed struct
	public GameObject shot;
	public Transform[] shotSpawn;//handle the positions of fire and put it from inspictor
	public gameControllerModeEnemies controller;//access class
	public GameObject playerExplosion;//explosion
	//============================================================================================================================================================
	void OnTriggerEnter(Collider other) {
		if (other.tag == "boltEnemy") { // if bullet of enemy hit player
			Destroy (other.gameObject);//destroy enemy bullet 
			controller.decreaseHealth (controller.enemies.enemyDamage);//decrease health of player
	
			if ((controller.health - controller.enemies.enemyDamage) <= 0) {
				Destroy (gameObject);//destroy enemy
				Instantiate (playerExplosion, other.transform.position, other.transform.rotation);//explosion appear
				controller.decreaseHealth (controller.enemies.enemyDamage);// decrease health bar
				controller.loseWindow ();// lose screen appear
			}
			if(PowerUps.powerUpCounter>0)
			PowerUps.powerUpCounter--;
		}
	}
	//============================================================================================================================================================
	void fire(){
		fireSpeed.nextFire = Time.time + fireSpeed.fireRate;//time between each bullet 
		Instantiate (shot, shotSpawn[0].position, shotSpawn[0].rotation);
		GetComponent<AudioSource>().Play();
		if (PowerUps.powerUpCounter == 1) {//player shot with 2 bullets at a time
			Instantiate (shot, shotSpawn[1].position, shotSpawn[1].rotation);
		}
		else if (PowerUps.powerUpCounter >= 2) {//player shot with 3 bullets at a time
			Instantiate (shot, shotSpawn[1].position, shotSpawn[1].rotation);
			Instantiate (shot, shotSpawn[2].position, shotSpawn[2].rotation);
			}

	}
	//============================================================================================================================================================
	void move (){//get move from input and make it not exide the boundary
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");
		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);
		GetComponent<Rigidbody> ().velocity = movement * motion.speed;
		GetComponent<Rigidbody> ().position = new Vector3 (
			Mathf.Clamp (GetComponent<Rigidbody> ().position.x, boundary.xMin, boundary.xMax),
			0.0f,
			Mathf.Clamp (GetComponent<Rigidbody> ().position.z, boundary.zMin, boundary.zMax)
			);
		
		GetComponent<Rigidbody> ().rotation = Quaternion.Euler (0.0f,0.0f, (GetComponent<Rigidbody> ().velocity.x) * -motion.tilt );
		//when player move left the right side rotate up and when move right side left side rotate up
	}
	//============================================================================================================================================================
	void Start (){
		fireSpeed.nextFire = 0;//initialize value
	}
	//============================================================================================================================================================
	void Update() {
		if (Time.timeScale!=0&&Input.GetButton ("Fire1") && Time.time > fireSpeed.nextFire) {//fire
			fire ();
		}
	}
	//============================================================================================================================================================
	void FixedUpdate()
	{//motion of player
		move ();
	}
}