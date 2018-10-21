using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour {
	public static bool moveleft,moveright;
	private bool ground;
	private Rigidbody2D rigidbody;
	// Use this for initialization
	void Start () {
		moveleft=false;
		moveright=false;
		ground=false;
		rigidbody=GetComponent<Rigidbody2D>();
	}

	// Update is called once per frame
	void Update () {
			if(ground==true){
				rigidbody.velocity=new Vector2(0,10);
				ground=false;
			}
			if(Input.GetKey(KeyCode.A)){
					Debug.Log("LEFT");
					rigidbody.velocity=new Vector2(-7,rigidbody.velocity.y);
			}
			else if(Input.GetKey(KeyCode.D)){
				rigidbody.velocity=new Vector2(7,rigidbody.velocity.y);
			}
			else{
				rigidbody.velocity=new Vector2(0,rigidbody.velocity.y);
			}
	}
	void OnCollisionEnter2D(Collision2D collisionInfo)
	{
		if(collisionInfo.gameObject.tag=="ground"){
			Debug.Log("wrodked");
			ground=true;
		}
		if(collisionInfo.gameObject.tag=="enemy"){
			Application.LoadLevel(0);
		}
	}
	public static void moveLeft(){
		moveleft=true;
	}
	public static void stopLeft(){
		moveleft=false;
	}
		public static void moveRight(){
		moveright=true;
	}
	public static void stopRight(){
		moveright=false;
	}
}
