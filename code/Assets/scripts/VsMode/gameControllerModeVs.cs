// include namespaces
using UnityEngine;
using System.Collections;
using UnityEngine.UI;
//================================================================================================================================================
public class gameControllerModeVs : MonoBehaviour 
{
	public AstroidManger astroidManger;
	public Asteroids hazards;
	public GameObject Panel;
	public  GUIManger guiManger;
	public PowerUps powerUps;
	static public float textlt=Time.time+2;
	public GameObject[] textlevel;
	[HideInInspector]public static short round=1;
	[HideInInspector]public float timeforfinish;
	public static int[] health={100,100};
	public int playerDamage;

	//================================================================================================================================================
	public void res(){
		Panel.SetActive (false);
		Time.timeScale = 1;
	}
	//================================================================================================================================================
	void pause (){//pause system
		if (Time.timeScale == 1) {
			Time.timeScale = 0;
			Panel.SetActive(true);
		} else {
			Time.timeScale = 1;
			Panel.SetActive(false);
			
		}
		
	}
//================================================================================================================================================
	public  void increaseHealthBar(int player)//to increase the health of player when he take a power up
	{
		if (player == 1)
			guiManger.healthBar[0].value= health[0];
		else guiManger.healthBar[1].value = health[1];
	}
//================================================================================================================================================
	public void decreaseHealth(int player,int damage)
	{
		if (player == 1) {
			health [0] -= damage;//decrease health of player 1
			guiManger.healthBar [0].value = health [0];//decrease health bar of player 1
			guiManger.damageImage [0].color = guiManger.flashColour [0];//to show the sprite window to flash light because of damage
			if(player1ModeVs.powerUp1Counter>0)
			player1ModeVs.powerUp1Counter--;          
		} 
		else {
			health[1] -= damage;//decrease health of player 2
			guiManger.healthBar[1].value =  health[1];//decrease health bar of player 2
			guiManger.damageImage[1].color = guiManger.flashColour[1];//to show the sprite window to flash light because of damage
			if(player2ModeVs.powerUp1Counter>0)
			player2ModeVs.powerUp1Counter--;    
		}
	}
//================================================================================================================================================
	void spawnWaves()
	{
		if (Time.time > astroidManger.nextAsteroidCreation) {// spawn rocks at rate between each one
			astroidManger.nextAsteroidCreation = Time.time + astroidManger.asteroidCreatingRate;//to shift the next time that the rock will spawn
			Vector3 spawnposition = new Vector3 (Random.Range (-astroidManger.asteroidMotion.x, astroidManger.asteroidMotion.x), astroidManger.asteroidMotion.y, astroidManger.asteroidMotion.z);
			//to create rocks' new position
			Quaternion spawnRotation = Quaternion.identity;// the fixed rotation position in the first
			Instantiate (hazards.asteroids [astroidManger.randomHazard], spawnposition, spawnRotation);
			// rocks created random position of random type
			astroidManger.randomHazard = Random.Range (0, 3);//change random value each spawn.
			astroidManger.currentAsteroid++; //increase the number of rocks that spawned by 1
		                                                    }
	}
//================================================================================================================================================
		void spawnPowerUp()
	{
		if ((astroidManger.currentAsteroid%15==0&&astroidManger.currentAsteroid!=0)) {
			Vector3 spawnPowerUpPosition = new Vector3 (Random.Range (-astroidManger.asteroidMotion.x, astroidManger.asteroidMotion.x), astroidManger.asteroidMotion.y, astroidManger.asteroidMotion.z);
			//to create power ups position
			Quaternion spawnPowerUpRotation = Quaternion.identity;// the fixed rotation position in the first
			Instantiate (powerUps.powerUp[powerUps.randomPowerUp], spawnPowerUpPosition, spawnPowerUpRotation);
			//power up appear in random position in randam range 
			astroidManger.currentAsteroid++;//increase the number of rocks that spawned by 1 to not spawn more power up together
			powerUps.randomPowerUp = Random.Range (0, 3);//change random value each spawn.
		                                                                             } 
	}
//================================================================================================================================================
	void Start()
	{ 	textlt=Time.time+2;

		timeforfinish = Time.time;
		Panel.SetActive (false);
		Time.timeScale=1;
		if (round == 1) {
			textlevel[0].SetActive (true);
			textlevel[1].SetActive (false);
 			textlevel[2].SetActive (false);
		}
		else if (round == 2) {
			textlt=Time.time+2;
			textlevel[1].SetActive (true);
			textlevel[0].SetActive (false);
			textlevel[2].SetActive (false);

		}
		else if (round == 3) {
			textlt=Time.time+2;
			textlevel[2].SetActive (true);
			textlevel[1].SetActive (false);
			textlevel[0].SetActive (false);


		}
		health[0]=100;
		health [1] = 100;
		astroidManger.currentAsteroid = 0;
		astroidManger.randomHazard = Random.Range (0, 3);
		powerUps.randomPowerUp = Random.Range (0, 3);
		astroidManger.nextAsteroidCreation = 2;//to make the creation wait for 2 seconds
	}
//================================================================================================================================================
	void Update() {
		Debug.Log (Time.time);
			spawnWaves ();
			spawnPowerUp();
		guiManger.damageImage[0].color = Color.Lerp (guiManger.damageImage[0].color,Color.clear,guiManger.flashSpeed*Time.deltaTime);
		//to clear the damage image from the screan by a flashspeed
		guiManger.damageImage[1].color = Color.Lerp (guiManger.damageImage[1].color,Color.clear,guiManger.flashSpeed*Time.deltaTime);
		//to clear the damage image from the screan by a flashspeed
		if (Input.GetKeyDown ("escape"))//to pause/repause the game if you press escape key
			pause ();

		if (Time.time > textlt) {
			if (round == 1) {
				textlevel [0].SetActive (false);
			} else if (round == 2) {

				textlevel [1].SetActive (false);


			} else if (round == 3) {

				textlevel [2].SetActive (false);


			}
		}
			
		Debug.Log (round);

	             }
//================================================================================================================================================
	void OnDisable() {
		player1ModeVs.powerUp1Counter = 0;//to reset the power up each level
		player2ModeVs.powerUp1Counter = 0;//to reset the power up each level
	                 }
}