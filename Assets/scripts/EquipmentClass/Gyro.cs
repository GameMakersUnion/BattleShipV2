using UnityEngine;
using System.Collections;

public class Gyro : Equipment{

	void test(){
		this.Update();

	}


	public override void Update (){

		base.Update ();
		print ("this");
	}
	// Use this for initialization

}
