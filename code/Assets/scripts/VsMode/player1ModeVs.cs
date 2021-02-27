//include name spaces.
using UnityEngine;
using System.Collections;
//===============================================================================================================================================
public class player1ModeVs : MonoBehaviour
{
	public static float player1loscounter = 0f;

	public Boundary boundary;
	public Motion motion;

	public FireSpeed fireSpeed;
	public GameObject shot;
	public Transform[] shotSpawn;

	public static int powerUp1Counter=0;
	public GameObject playerExplosion;
	public GameObject NormalExplosion;
	gameControllerModeVs controller;
	private float time2;
	bool flag=false;
	//===============================================================================================================================================
	void fire()
	{
		fireSpeed.nextFire = Time.time + fireSpeed.fireRate;//make different time bettween shoots
		Instantiate (shot, shotSpawn[0].position, shotSpawn[0].rotation);//create fire
		GetComponent<AudioSource>().Play();// play music

		if (powerUp1Counter== 1) 
			Instantiate (shot, shotSpawn[1].position, shotSpawn[1].rotation);
		//make player 1 shot with two bullets at a time
		else if (powerUp1Counter >= 2) {
			Instantiate (shot, shotSpawn[1].position, shotSpawn[1].rotation);
			Instantiate (shot, shotSpawn[2].position, shotSpawn[2].rotation);
			//make player 1 shot with theree bullets at a time
			                                   }
	}
	//===============================================================================================================================================
	void move (){
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
	}
	//===============================================================================================================================================
	void OnTriggerEnter(Collider other) {
		if (other.tag == "bolt2" ) {//bullet from player 2 hit player 1
			Destroy (other.gameObject);//destroy bullet
			controller.decreaseHealth(1,controller.playerDamage);//decrease health of player 1
			Instantiate (NormalExplosion, other.transform.position, other.transform.rotation);//bullet explosion
			if(gameControllerModeVs.health[0]-controller.playerDamage<=0){//to check if the hit can destroy the player or not
				Destroy (gameObject);//destroy player1
				Instantiate (playerExplosion, other.transform.position, other.transform.rotation);//player explosion
				player1loscounter++;

				if (player1loscounter == 1){gameControllerModeVs.round++;   Application.LoadLevel("Vs");}

				if (player1loscounter == 2){
					gameControllerModeVs.round=1;
				Application.LoadLevel("Wvs2");
					player1loscounter=0;
				}//win player2 screen

			                                                             }
		                           } 
		else if (other.tag == "asteroid1" ) { // rocks hit player 1
			Destroy (other.gameObject);//destroy the rock
			controller.decreaseHealth(1,controller.hazards.asteroidsDamage[0]);//decrease health of player 1
			Instantiate (NormalExplosion, other.transform.position, other.transform.rotation);//explosion
			if(gameControllerModeVs.health[0]-controller.hazards.asteroidsDamage[0]<=0){//to check if the hit can destroy the player or not
				Destroy (gameObject);
				Instantiate (playerExplosion, other.transform.position, other.transform.rotation);
				player1loscounter++;
				
				if (player1loscounter == 1){ gameControllerModeVs.round++;        Application.LoadLevel("Vs");}
				
				if (player1loscounter == 2){
					//flag=true;
					gameControllerModeVs.round=1;

					Application.LoadLevel("Wvs2");
					//time2=Time.time;
					player1loscounter=0;
				}
			                                                                           }

		                                     }
		else if (other.tag == "asteroid2" ) {// rocks hit player 1
			Destroy (other.gameObject);
			controller.decreaseHealth(1,controller.hazards.asteroidsDamage[1]);
			Instantiate (NormalExplosion, other.transform.position, other.transform.rotation);
			if(gameControllerModeVs.health[0]-controller.hazards.asteroidsDamage[1]<=0){
				Destroy (gameObject);
				Instantiate (playerExplosion, other.transform.position, other.transform.rotation);
				player1loscounter++;
				
				if (player1loscounter == 1){gameControllerModeVs.round++;   Application.LoadLevel("Vs");}
				
				if (player1loscounter == 2){
					gameControllerModeVs.round=1;

					Application.LoadLevel("Wvs2");
					player1loscounter=0;
				}
			                                                                           }

		                                     }
		else if (other.tag == "asteroid3" ) {// rocks hit player 1
			Destroy (other.gameObject);
			controller.decreaseHealth(1,controller.hazards.asteroidsDamage[2]);
			Instantiate (NormalExplosion, other.transform.position, other.transform.rotation);
			if(gameControllerModeVs.health[0]-controller.hazards.asteroidsDamage[2]<=0){
				Destroy (gameObject);
				Instantiate (playerExplosion, other.transform.position, other.transform.rotation);
				player1loscounter++;
				
				if (player1loscounter == 1){gameControllerModeVs.round++;   Application.LoadLevel("Vs");}
				
				if (player1loscounter == 2){

					Application.LoadLevel("Wvs2");
					gameControllerModeVs.round=1;

					player1loscounter=0;
				}
			                                                                           }

		                                    }
		else if (other.tag == "powerUp1" ) {//to add the fire shot
			Destroy (other.gameObject);
			PowerUps.powerUpCounter++;
		                                   }
		else if (other.tag == "powerUp2" ) {//power up  2 increase health by 15 
			Destroy (other.gameObject);
			if(gameControllerModeVs.health[0]+15<=100)
			gameControllerModeVs.health[0]+=15;
			else
				gameControllerModeVs.health[0]=100;
			controller.guiManger.healthBar[0].value =  gameControllerModeVs.health[0];
		                                   }
		else if (other.tag == "powerUp3" ) {//power up  2 increase health by 25 
			Destroy (other.gameObject);
			if(gameControllerModeVs.health[0]+25<=100)
				gameControllerModeVs.health[0]+=25;
			else
				gameControllerModeVs.health[0]=100;
			controller.guiManger.healthBar[0].value =  gameControllerModeVs.health[0];
		                                   }
	}
	//===============================================================================================================================================
	void Start (){
		fireSpeed.nextFire = 0;
	}
	//===============================================================================================================================================
	void Update() 
	{
		if(flag==true&&Time.time>time2+2)
			Application.LoadLevel("Vs");
	
		if (controller==null) //we need the object controller to find the object in the game that hold the class that we want no access in.
			controller = GameObject.Find ("gameController").GetComponent<gameControllerModeVs> ();
		if (Time.timeScale!=0&&Input.GetButton ("Fire1") && Time.time > fireSpeed.nextFire) //to fire 
			fire();
	}
	//===============================================================================================================================================
	void FixedUpdate()// fixed update function is better than Update as it move the bodies smoothly.
	{
		move ();//to move the body
	}
	//===============================================================================================================================================
}