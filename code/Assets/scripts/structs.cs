// include namespaces
using UnityEngine;
using System.Collections;
using UnityEngine.UI;
//================================================================================================================================================
[System.Serializable]//to show the next struct or class in the inspector and changing variables' values.
public struct AstroidManger
{
	[HideInInspector] public float nextAsteroidCreation;// don't show in inspector  but shared by scripts
	[HideInInspector] public int currentAsteroid;// don't show in inspector  but shared by scripts
	[HideInInspector] public int randomHazard;// don't show in inspector  but shared by scripts
	public Vector3 asteroidMotion;//to put the three values of motion x y z
	public float asteroidCreatingRate;
}
//================================================================================================================================================
[System.Serializable]//to show the next struct or class in the inspector and changing variables' values.
public struct Asteroids
{
	public  GameObject [] asteroids;//to put the rocks bodies from the inspictor
	public int[] asteroidsDamage;//each one has a damage 
}
//================================================================================================================================================
[System.Serializable]//to show the next struct or class in the inspector and changing variables' values.
public struct GUIManger
{
	public  Slider[] healthBar;
	public Image[] damageImage;//the image that will appear when you hit
	public float flashSpeed;
	public Color[] flashColour;
	public GUIText ScoreText;
}
//================================================================================================================================================
[System.Serializable]//to show the next struct or class in the inspector and changing variables' values.
public struct PowerUps{
	public GameObject[] powerUp;// power ups that you will put from the inspictor
	[HideInInspector] public int randomPowerUp;// don't show in inspector  but shared by scripts
	[HideInInspector]public static float powerUpCounter=0;// don't show in inspector  but shared by scripts
}
//================================================================================================================================================
[System.Serializable]//to show the next struct or class in the inspector and changing variables' values.
public struct Enemies {
	public int enemyDamage;
	[HideInInspector] public short enemiesDestroid;// don't show in inspector  but shared by scripts
}
//================================================================================================================================================
[System.Serializable]//to show the next struct or class in the inspector and changing variables' values.
public struct Boundary {
	public float xMin,xMax,zMin,zMax;// values that the player can move in.
}
//================================================================================================================================================
[System.Serializable]//to show the next struct or class in the inspector and changing variables' values.
public struct Motion{
	public float speed,tilt;//speed and rotate of the body
}
//================================================================================================================================================
[System.Serializable]//to show the next struct or class in the inspector and changing variables' values.
public struct FireSpeed{
	public float fireRate ;
	public float nextFire;
}