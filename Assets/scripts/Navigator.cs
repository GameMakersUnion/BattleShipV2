using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Navigator : MonoBehaviour {
	public GameObject ship;
	public float shipthrust = 1;
	public float shipmoment = 1;
	public float powerunit = 1;
	public float shipmass = 1;
	private Rigidbody2D shiprigidbody;
    public List <Equipment> EquipmentList = new List <Equipment>();
	//private float acceleratetime = 1;
	//private int gyrocount;
	
	// Use this for initialization
	void Start () {
		ship = GameObject.Find("Ship");
		shiprigidbody = ship.GetComponent<Rigidbody2D> ();

		// this is the place holder values for equipment effects on ship class
		//shipthrust = 6;
		//shipmoment = 6;
		shipmass = 26;
		//int counter = 0;


		//shipthrust += counter;

		//counter = 0;



		shiprigidbody.mass = shipmass;

		//gyrocount = ship.GetComponent <Ship> ().gyroCount;
		//Vector3 up = gameObject.transform.up;
	}
	
	
	
	// Update is called once per frame
	void Update () {
		shipthrust = 1;
		shipmoment = 1;
		shipmass = 1;
		foreach ( Equipment e in EquipmentList) {
			
			//print (e);

			if (e is Thruster){
				shipthrust ++;
			}

			if (e is Gyro){
				shipmoment ++;
			}
			if (e is PowerSource){
				powerunit ++;
			}
		}

		float moverotation = Input.GetAxis ("Horizontal");
		float moveforward = Input.GetAxis ("Vertical");
		//float angularmomentum

		if (moverotation != 0) {
			shiprigidbody.angularVelocity += -moverotation * shipmoment / shipmass * 2;

			//shiprigidbody.AddTorque(ship.transform.up * moment * -moverotation, ForceMode2D.Force);
			ship.transform.localEulerAngles += new Vector3 (0, 0, -moverotation * shipmoment / shipmass * shipmass);
		}

		if ( shiprigidbody.angularVelocity < 0) {
			shiprigidbody.angularVelocity += shipmoment / shipmass;
		}

		if ( shiprigidbody.angularVelocity > 0) {
			shiprigidbody.angularVelocity -= shipmoment / shipmass;
		}


		//print (ship.transform.localEulerAngles);
		//print (shiprigidbody.angularVelocity);
		//print (ship.transform.up * shipthrust * moveforward + 100 * shipthrust);

		if (moveforward != 0) {
			shiprigidbody.AddForce(ship.transform.up * shipthrust * moveforward * 50);

		}

		
		/*if (Input.GetKeyDown (KeyCode.W)) {
			shiprigidbody.AddForce ( new Vector2 (0 ,thrust*acceleratetime));
			acceleratetime += 1;
		}
		if (Input.GetKeyDown(KeyCode.S)) {
			shiprigidbody.AddForce (new Vector2 (0, -thrust));
		}
		if (Input.GetKeyDown (KeyCode.A)) {
			shiprigidbody.AddForce (new Vector2 (-thrust, 0));
		}
		if (Input.GetKeyDown (KeyCode.D)){
			shiprigidbody.AddForce (new Vector2 (thrust, 0));
		}*/
	}
}
