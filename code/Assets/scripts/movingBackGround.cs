// include namespaces
using UnityEngine;
using System.Collections;
using UnityEngine.UI;
//================================================================================================================================================
public class movingBackGround : MonoBehaviour 
{
	public float scrollSpeed;
	private Vector2 savedOffset;
	//================================================================================================================================================
	void Start () 
	{//to save the value of the texture before beginning of changing it.
		savedOffset = GetComponent<Renderer>().sharedMaterial.GetTextureOffset ("_MainTex");
	}
	//================================================================================================================================================
	void Update () 
	{
		float y = Mathf.Repeat (Time.time * scrollSpeed, 1);//repeat the y value of texture from 0 to 1 as to show it moving in the game
		Vector2 offset = new Vector2 (savedOffset.x, y);//save the new positsion
		GetComponent<Renderer>().sharedMaterial.SetTextureOffset ("_MainTex", offset);//background take the new position
	}
	//================================================================================================================================================
	void OnDisable () 
	{//to reset the value of the texture before the end of the game
		GetComponent<Renderer>().sharedMaterial.SetTextureOffset ("_MainTex", savedOffset);
	}
}