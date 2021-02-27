//include name spaces.
using UnityEngine;
using System.Collections;
//================================================================================================================================================
public class player2ModeVs : MonoBehaviour 
{
	public static float player2loscounter = 0;

	public Boundary boundary;
	public Motion motion;
	public FireSpeed fireSpeed;
	public GameObject shot;
	public Transform[] shotSpawn;

	public static int powerUp1Counter=0;
	public GameObject playerExplosion;
	public GameObject NormalExplosion;
	gameControllerModeVs controller;
	//================================================================================================================================================
	void fire()
	{
		fireSpeed.nextFire = Time.time + fireSpeed.fireRate;
		Instantiate (shot, shotSpawn[0].position, shotSpawn[0].rotation);
		GetComponent<AudioSource>().Play();
		
		if (powerUp1Counter == 1) 
			Instantiate (shot, shotSpawn[1].position, shotSpawn[1].rotation);
		else if (powerUp1Counter >= 2) {
			Instantiate (shot, shotSpawn[1].position, shotSpawn[1].rotation);
			Instantiate (shot, shotSpawn[2].position, shotSpawn[2].rotation);
		                               }
	}
	//================================================================================================================================================
	void move ()
	{
		float moveHorizontal = Input.GetAxis ("Horizontal2");
		float moveVertical = Input.GetAxis ("Vertical2");
		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);
		GetComponent<Rigidbody> ().velocity = movement * motion.speed;
		GetComponent<Rigidbody> ().position = new Vector3 (
			Mathf.Clamp (GetComponent<Rigidbody> ().position.x, boundary.xMin, boundary.xMax),
			0.0f,
			Mathf.Clamp (GetComponent<Rigidbody> ().position.z, boundary.zMin, boundary.zMax)
			);
    }
	//================================================================================================================================================
	void OnTriggerEnter(Collider other) {
		if (other.tag == "bolt" ) {
			Destroy (other.gameObject);
			controller.decreaseHealth(2,controller.playerDamage);
			Instantiate (NormalExplosion, other.transform.position, other.transform.rotation);
			if(gameControllerModeVs.health[1]-controller.playerDamage<=0){
				Destroy (gameObject);
				Instantiate (playerExplosion, other.transform.position, other.transform.rotation);
				player2loscounter++;
				
				if (player2loscounter == 1){gameControllerModeVs.round++;        Application.LoadLevel("Vs");}
				
				if (player2loscounter == 2){
					gameControllerModeVs.round=1;

					Application.LoadLevel("Wvs1");
					player2loscounter=0;
				}//win player2 screen
			                                                             }
		                          } 
		else if (other.tag == "asteroid1" ) {
			Destroy (other.gameObject);
		
			controller.decreaseHealth(2,controller.hazards.asteroidsDamage[0]);
			Instantiate (NormalExplosion, other.transform.position, other.transform.rotation);
			if(gameControllerModeVs.health[1]-controller.hazards.asteroidsDamage[0]<=0){
				Destroy (gameObject);
				Instantiate (playerExplosion, other.transform.position, other.transform.rotation);
				player2loscounter++;
				
				if (player2loscounter == 1){   gameControllerModeVs.round++; Application.LoadLevel("Vs");}

				if (player2loscounter == 2){
					gameControllerModeVs.round=1;

					Application.LoadLevel("Wvs1");
					player2loscounter=0;
				}//win player2 screen
			                                                                           }
		
		                                     }
		else if (other.tag == "asteroid2" ) {
			Destroy (other.gameObject);

			controller.decreaseHealth(2,controller.hazards.asteroidsDamage[1]);
			Instantiate (NormalExplosion, other.transform.position, other.transform.rotation);
			if(gameControllerModeVs.health[1]-controller.hazards.asteroidsDamage[1]<=0){
				Destroy (gameObject);
				Instantiate (playerExplosion, other.transform.position, other.transform.rotation);
				player2loscounter++;
				
				if (player2loscounter == 1){ gameControllerModeVs.round++;       Application.LoadLevel("Vs");}
		
				
				if (player2loscounter == 2){
					gameControllerModeVs.round=1;

					Application.LoadLevel("Wvs1");
					player2loscounter=0;
				}//win player2 screen
			                                                                           }
		
		                                    }
		else if (other.tag == "asteroid3" ) {
			Destroy (other.gameObject);
		
			controller.decreaseHealth(2,controller.hazards.asteroidsDamage[1]);
			Instantiate (NormalExplosion, other.transform.position, other.transform.rotation);
			if(gameControllerModeVs.health[1]-controller.hazards.asteroidsDamage[1]<=0){
				Destroy (gameObject);
				Instantiate (playerExplosion, other.transform.position, other.transform.rotation);
				player2loscounter++;
				
				if (player2loscounter == 1){ gameControllerModeVs.round++; Application.LoadLevel("Vs");}
				
				if (player2loscounter == 2){
					gameControllerModeVs.round=1;
					Application.LoadLevel("Wvs1");
					player2loscounter=0;
				}//win player2 screen
			                                                                           }
		
		                                   }
		else if (other.tag == "powerUp1" ) {
			Destroy (other.gameObject);
			powerUp1Counter++;
		
		                                   }
		else if (other.tag == "powerUp2" ) {
			Destroy (other.gameObject);
			if(gameControllerModeVs.health[1]+15<=100)
				gameControllerModeVs.health[1]+=15;
			else
				gameControllerModeVs.health[1]=100;
			controller.guiManger.healthBar[1].value =  gameControllerModeVs.health[1];
		                                   }
		else if (other.tag == "powerUp3" ) {
			Destroy (other.gameObject);
			if(gameControllerModeVs.health[1]+25<=100)
				gameControllerModeVs.health[1]+=25;
			else
				gameControllerModeVs.health[1]=25;
			controller.guiManger.healthBar[1].value =  gameControllerModeVs.health[1];
		                                   }
	                                         }
	//================================================================================================================================================
	void Start (){
		fireSpeed.nextFire = 0;
	             }
	//================================================================================================================================================
	void Update() {
		if (controller==null)
			controller = GameObject.Find ("gameController").GetComponent<gameControllerModeVs> ();
		if (Time.timeScale!=0&&Input.GetButton ("Fire2") && Time.time > fireSpeed.nextFire) 
			fire ();
	              }
	//================================================================================================================================================
	void OnDisable() 
	{
		powerUp1Counter = 0;
	}
	//================================================================================================================================================
	void FixedUpdate()
	{
		move ();
	}
}