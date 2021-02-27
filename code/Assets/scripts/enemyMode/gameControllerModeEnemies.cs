// include namespaces
using UnityEngine;
using System.Collections;
using UnityEngine.UI;
//================================================================================================================================================
public class gameControllerModeEnemies : MonoBehaviour 
{
	public GameObject textlevel;
	public float textlt=2f;
	public GameObject Panel;
	public GUIManger guiManger;
	public static int Score;
	[HideInInspector]public  int health;
	private int random;
	public PowerUps power_up;
	public Vector3 spawnMotion;
	public Enemies enemies;
	[HideInInspector]public static short level2=1;
	public AstroidManger astroidManger;
	public Asteroids hazards;
	[HideInInspector]public float timeforfinish;

	private enemySpawn control;
	private bool flag=true;
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
		} 
		  else {
			Time.timeScale = 1;
			Panel.SetActive(false);

		}
		
	}
	//================================================================================================================================================
	public void decreaseHealth(int damage){// take the damage and remove its value from health and decrease health bar
		health = health - damage;
		guiManger.healthBar[0].value =  health;
		guiManger.damageImage[0].color = guiManger.flashColour[0];
	}
	//================================================================================================================================================
	public void UpdateScore( int score){//update new score on screen
		Score += score;
		guiManger.ScoreText.text = "Score : " + Score;

	}
	//================================================================================================================================================
	public static void ResetScore(){// reset the score to zero
		Score = 0;
	}
	//================================================================================================================================================
	void spawnPowerUp(){//spawn power up 
		
		if (( enemies.enemiesDestroid==0||enemies.enemiesDestroid% random==0)&&enemies.enemiesDestroid!=0) {
			Vector3 spawnPowerUpPosition = new Vector3 (Random.Range (-spawnMotion.x, spawnMotion.x), spawnMotion.y, spawnMotion.z);
			Quaternion spawnPowerUpRotation = Quaternion.identity;
			Instantiate (power_up.powerUp[power_up.randomPowerUp], spawnPowerUpPosition, spawnPowerUpRotation);
			enemies.enemiesDestroid++;
			power_up.randomPowerUp=Random.Range (0, 2);
		} 
	}
	//===========================================================================================================================
public	void spawnWaves(){
		if (Time.time > astroidManger.nextAsteroidCreation && astroidManger.currentAsteroid < 50) {
			//to creat the rock after a fixed rate and the last one will be 50th
			astroidManger.currentAsteroid ++;//increase the number of rocks that spawned by 1
 			astroidManger.nextAsteroidCreation = Time.time + astroidManger.asteroidCreatingRate;//to shift the next time that the rock will spawn
			Vector3 spawnposition = new Vector3 (Random.Range (-astroidManger.asteroidMotion.x, astroidManger.asteroidMotion.x), astroidManger.asteroidMotion.y, astroidManger.asteroidMotion.z);
			//to create rocks' new position
			Quaternion spawnRotation = Quaternion.identity;// the fixed rotation position in the first
			Instantiate (hazards.asteroids [0], spawnposition, spawnRotation);// rocks created random position of random type
			timeforfinish = Time.time;//update the time for finish the game because it is still running
		} else if (astroidManger.currentAsteroid == 5)
			control.currentLoop++;
		//astroidManger.currentAsteroid++;

	}
	//================================================================================================================================================
	public void loseWindow(){//level manger of lose window
		
		if (level2 == 1)
			Application.LoadLevel ("Lenemies1");
		else if (level2 == 2)
			Application.LoadLevel ("Lenemies2");
		else if (level2 == 3)
			Application.LoadLevel ("Lenemies3");
		else if (level2 == 4) {
			Application.LoadLevel ("Lenemies4");
			
		}
	}
	//================================================================================================================================================
	void Start(){
		Panel.SetActive (false);
		Time.timeScale=1;
		//textlevel.SetActive (true);
		//flag = true;
		//timeforfinish = Time.time;
		random = Random.Range (4, 7); //specify range of random
		health = 100;
		Score = 0;
		UpdateScore (Score);
		enemies.enemiesDestroid = 0;
		GameObject gameControllerObject = GameObject.FindGameObjectWithTag ("enemySpawn");
		control = gameControllerObject.GetComponent<enemySpawn> ();
	}
	//================================================================================================================================================
	void Update() {
		Debug.Log (astroidManger.currentAsteroid);
		spawnPowerUp (); // generate power up at random time && place
		if (Input.GetKeyDown ("escape"))//if escape key pressed game paued
		{
			pause ();
		}
		guiManger.damageImage[0].color = Color.Lerp (guiManger.damageImage[0].color,Color.clear,guiManger.flashSpeed*Time.deltaTime);
		//if (Time.time > textlt&&flag)
			//textlevel.SetActive (false);
		//to remove the flash light from any damage happen
	}
	//================================================================================================================================================
	void OnDisable() {//to reset power up each level
		PowerUps.powerUpCounter = 0;
		flag = false;
	}
}