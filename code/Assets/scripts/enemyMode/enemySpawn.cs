//include name spaces.
using UnityEngine;
using System.Collections;
//==============================================================================================================================================================	
public class enemySpawn : MonoBehaviour {
	public GameObject enemyPrefaps;
	public float width=15f;
	public float height=15f;
	public float speed=5.0f;
	private int direction =1;
	private float boundryRightedge=12f;
	private float boundryLeftedge=-12f;
	public int currentLoop=0;
	public int loops;
	public bool flag=false;
	private gameControllerModeEnemies control;
	//==============================================================================================================================================================	
	void Start () 
	{	
		GameObject gameControllerObject = GameObject.FindGameObjectWithTag ("gameControllerEnemy");
		control = gameControllerObject.GetComponent<gameControllerModeEnemies> ();

		//respawn ();//spawn enemies 
	}
	//==============================================================================================================================================================	
	void OnDrawGizmos()
	{//Draw rectangle on enemy formation
		float xmax,ymin,ymax,xmin;
		xmin = transform.position.x - 0.5f * width;  // (xmin,ymax)   ********************** (xmax,ymax) 
		xmax = transform.position.x + 0.5f * width;  //               *        #           *            
		ymin = transform.position.y - 0.5f * height; //               *                    *     
		ymax =transform.position.y + 0.5f * height;  // (xmin,ymin)   ********************** (xmax,ymin)
		Gizmos.DrawLine(new Vector3(xmin,0,ymin),new Vector3 (xmin,0,ymax));
		Gizmos.DrawLine(new Vector3(xmin,0,ymax),new Vector3 (xmax,0,ymax));
		Gizmos.DrawLine(new Vector3(xmax,0,ymax),new Vector3 (xmax,0,ymin));
		Gizmos.DrawLine(new Vector3(xmax,0,ymin),new Vector3 (xmin,0,ymin));
	}
	//==============================================================================================================================================================	
	public void winWindow()
	{// manage levels win screen

		if (gameControllerModeEnemies.level2 == 1) {
			gameControllerModeEnemies.level2++;
			Application.LoadLevel ("Wenemy1");
		} 
		else if (gameControllerModeEnemies.level2 == 2) {
			gameControllerModeEnemies.level2++;
			Application.LoadLevel ("Wenemy2");
		} 
		else if (gameControllerModeEnemies.level2 == 3) {
			gameControllerModeEnemies.level2++;
			Application.LoadLevel ("Wenemy3");
		}
		else if (gameControllerModeEnemies.level2 == 4) {
			Application.LoadLevel ("Wenemy4");
			gameControllerModeEnemies.level2 = 1;
		}
	}
	//==============================================================================================================================================================	
	void Update()
	{

		float formationRightedge =transform.position.x + 0.5f * width;
		float formationLeftedge=transform.position.x - 0.5f * width;
		if (formationRightedge > boundryRightedge) {
			direction=-1;}
		
		if (formationLeftedge <boundryLeftedge)
			direction=1;
		
		transform.position = new Vector3(Mathf.Clamp(transform.position.x+speed*direction*Time.deltaTime,boundryLeftedge,boundryRightedge), 0.0f,4.0f);
		if (isMySquadEmpty ()) {

			if (currentLoop < loops && currentLoop % 2 == 0) {	                              
				control.astroidManger.currentAsteroid = 0;
				if (Time.time > control.timeforfinish + 3) {
					respawn ();
					currentLoop++; 
				}
			} else if (currentLoop >= loops&&Time.time > control.timeforfinish + 3)
				winWindow ();
			else {
				if (Time.time > control.timeforfinish + 3||flag){
					control.spawnWaves ();
				flag=true;
				}
			}
		} else
			control.timeforfinish = Time.time;
	}
	//==============================================================================================================================================================	
	bool isMySquadEmpty()// return true if all enemies died else false
	{
		foreach (Transform position in transform) {// loop  on each position of enemy formation to check if enemies died or no
			if(position.childCount>0){
				return false;
			}
		}
		return true;
	}
	//==============================================================================================================================================================	
	void respawn()// appear enemies 
	{
		foreach (Transform position in transform) {// appear enemies on each position

			GameObject enemy = Instantiate (enemyPrefaps, position.transform.position, Quaternion.identity)as GameObject;
			//instanitate enemy in each position of enmy formation
			enemy.transform.parent = position;
		}
	}
	void OnDisable() {//to reset power up each level
		currentLoop = 0;
	}
}
