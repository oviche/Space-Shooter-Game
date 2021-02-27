//include name spaces.
using UnityEngine;
using System.Collections;
//===========================================================================================================================================
public class enemyFire : MonoBehaviour {

	public float shotspersecond = 1f;
	public FireSpeed fire_speed;
	public GameObject shot;
	public Transform shotSpawn;//place shots of enemy we define it from inspector
	public float speed;
	public int numberOfHits;
	public int MaxnumberOfHits=3;

	public  int score=10;
	gameControllerModeEnemies controller;//calling script to fire script to take functions or any thing from it !!
	public GameObject explosion;
	public GameObject playerExplosion;
	//===========================================================================================================================================
	void fire()
	{
		Instantiate (shot, shotSpawn.position, shotSpawn.rotation);// shots appear from the place which it created "shotspawn"
	}
	//===========================================================================================================================================
	void start ()
	{
		//we need the object controller to find the object in the game that hold the class that we want no access in.
		controller=GameObject.Find("gameController").GetComponent<gameControllerModeEnemies>();
		numberOfHits = 0;
	}
	//===========================================================================================================================================
	void OnTriggerEnter(Collider other) 
	{

		if ( other.tag == "Player") {// if player hit enemy
			Destroy (gameObject);// destroy enemy
			Destroy (other.gameObject);// destroy player

			controller.enemies.enemiesDestroid++;//increase the number of enemies that destroyed because we need to handle it with power up
			controller.UpdateScore (score);//  update new score
			Instantiate (playerExplosion, other.transform.position, other.transform.rotation);//explosion appear
			controller.decreaseHealth(100);
			controller.loseWindow(); //player lose
		                            }
		else if (other.tag == "bolt" ) 
		{// if bullet hit enemy

			Destroy (other.gameObject);//  destroy bullet
			numberOfHits++;//increase the hits by bullet
			if (numberOfHits == MaxnumberOfHits) {
				Destroy (gameObject);
				controller.UpdateScore (score);//update score
				controller.enemies.enemiesDestroid++;//increase the number of enemies that destroyed because we need to handle it with power up
				Instantiate (explosion, transform.position, transform.rotation);//explosion appear

			                                    } 
		}

	}
	//===========================================================================================================================================
	void Update()
	{
		float probabilty = Time.deltaTime * shotspersecond;
		if(Random.value<probabilty){fire();}// prevent the el bullets of enemy become st.line && create time between each bullet 
		if (controller==null) { //we need the object controller to find the object in the game that hold the class that we want no access in.
			controller = GameObject.Find ("gameController").GetComponent<gameControllerModeEnemies> ();

		                      }
   }
}