using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;

public class Manager : MonoBehaviour
{

	public GameObject HullSpawner;
	public GameObject BlockSpawner;
	public Navigator navigator;
	public Ship ship;
	private static Manager _instance;


	public static Manager instance {
		get {
			if (_instance != null)
				return _instance;
			_instance = GameObject.FindObjectOfType<Manager> ();
			DontDestroyOnLoad (_instance.gameObject);
			return _instance;
		}
	}

	private void Awake ()
	{
		if (_instance == null) {
			_instance = this;
			DontDestroyOnLoad (this);
		} else {
			if (this != _instance)
				Destroy (this.gameObject);
		}
	}










	void Update ()
	{
		if (Input.GetKeyDown (KeyCode.H)) {
			HullSpawner.SetActive (true);
			BlockSpawner.SetActive (false);
			navigator.gameObject.SetActive (false);
		} else if (Input.GetKeyDown (KeyCode.B)) {

			HullSpawner.SetActive (false);
			BlockSpawner.SetActive (true);
			navigator.gameObject.SetActive (false);
		} else if (Input.GetKeyDown (KeyCode.N)) {

			HullSpawner.SetActive (false);
			BlockSpawner.SetActive (false);
			navigator.gameObject.SetActive (true);
		}
	}
}
