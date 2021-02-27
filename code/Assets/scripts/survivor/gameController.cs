//include name spaces.
using UnityEngine;
using System.Collections;
using UnityEngine.UI;
//===========================================================================================================================
public class gameController : MonoBehaviour {
	public static int Score;
	[HideInInspector]public int health;
	public AstroidManger astroidManger;
	public Asteroids hazards;
	public GUIManger guiManger;
	public PowerUps power_up;
	private float timeforfinish;
	private int random;
	public GameObject Panel;
	[HideInInspector]public static short level=1;
	//===========================================================================================================================
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
	//===========================================================================================================================
	public void decreaseHealth(){
		guiManger.healthBar[0].value =  guiManger.healthBar[0].value-hazards.asteroidsDamage[0];//decrease health of player
		guiManger.damageImage[0].color = guiManger.flashColour[0];//to show the sprite window to flash light because of damage
	                            }
	//===========================================================================================================================
	public void UpdateScore( int score){//to add the score of attacking rocks and add it to total score
		Score += score;
		guiManger.ScoreText.text = "Score : " + Score;
	                                   }
	//===========================================================================================================================
	public static void ResetScore(){//to reset the score after each level
		Score = 0;
	                               }
	//===========================================================================================================================
	public void winWindow(short level){//level manger for win
		if (level == 1)
		{gameController.level++;

			Application.LoadLevel ("survivor2");
		                }
		else if (level == 2) {
			gameController.level++;
			Application.LoadLevel ("survivor3");
		                     } 
		else if (level == 3) {
			gameController.level=1;
			Application.LoadLevel ("Wsurvivor3");

		                     }
	}
	//===========================================================================================================================
	public void loseWindow(){//level manger for lose
		if (level == 1) 
			Application.LoadLevel ("Lsurvivor1");
		else if (level == 2) 
			Application.LoadLevel ("Lsurvivor1");
		 else if (level == 3) 
			Application.LoadLevel ("Lsurvivor1");
	                        }
	//===========================================================================================================================
	void spawnWaves(){
		if (Time.time > astroidManger.nextAsteroidCreation && astroidManger.currentAsteroid <350) {//to creat the rock after a fixed rate and the last one will be 50th
			astroidManger.currentAsteroid ++;//increase the number of rocks that spawned by 1
			astroidManger.nextAsteroidCreation = Time.time + astroidManger.asteroidCreatingRate;//to shift the next time that the rock will spawn
			Vector3 spawnposition = new Vector3 (Random.Range (-astroidManger.asteroidMotion.x, astroidManger.asteroidMotion.x), astroidManger.asteroidMotion.y, astroidManger.asteroidMotion.z);
			//to create rocks' new position
			Quaternion spawnRotation = Quaternion.identity;// the fixed rotation position in the first
			Instantiate (hazards.asteroids [0], spawnposition, spawnRotation);// rocks created random position of random type
			timeforfinish = Time.time;//update the time for finish the game because it is still running
		} 
	}
	//===========================================================================================================================
		void spawnPowerUp(){
		if ((astroidManger.currentAsteroid%random==0&&astroidManger.currentAsteroid!=0)) {//the only number that will spawn power up is to be divisable by the random value
			Vector3 spawnPowerUpPosition = new Vector3 (Random.Range (-astroidManger.asteroidMotion.x, astroidManger.asteroidMotion.x), astroidManger.asteroidMotion.y, astroidManger.asteroidMotion.z);
			//to create power ups position
			Quaternion spawnPowerUpRotation = Quaternion.identity;// the fixed rotation position in the first
			Instantiate (power_up.powerUp[0], spawnPowerUpPosition, spawnPowerUpRotation);
			//power up appear in random position in randam range 
			astroidManger.currentAsteroid++;//increase the number of rocks that spawned by 1 to not spawn more power up together
		} 
	}
	//===========================================================================================================================
	void Start(){
		Panel.SetActive (false);

		Time.timeScale=1;
		random = Random.Range (15, 20);//the random value that the spawn will be divisable on it or no to create power up
		timeforfinish = Time.time;
		astroidManger.nextAsteroidCreation = 2;//to make the creation wait for 2 seconds
		health = 100;
		Score = 0;
		UpdateScore (Score);//to make the score updated 
	}
	//===========================================================================================================================
	void Update() {
		Debug.Log (level);
		if (health == 0) {
			loseWindow();
		}
		if (Time.time > timeforfinish + 6.0)// to check if the last spawn wave from 6 secondes or not  because if it stop the level will end
			winWindow (level); 
		else {
			spawnWaves ();
			spawnPowerUp();
		}
		if (Input.GetKeyDown ("escape"))//to pause/repause the game if you press escape key
			pause ();
		guiManger.damageImage[0].color = Color.Lerp (guiManger.damageImage[0].color,Color.clear,guiManger.flashSpeed*Time.deltaTime);
		//to clear the damage image from the screan by a flashspeed
	}
	//===========================================================================================================================
	void OnDisable() {
		PowerUps.powerUpCounter= 0;//to reset the power up each level
	}
}