using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;

public class Manager : MonoBehaviour
{

	public HullSpawner hullSpawner;
	public BlockSpawner blockSpawner;
	public Navigator navigator;
	public PowerEditor powerEditor;
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
			hullSpawner.gameObject.SetActive (true);
			blockSpawner.gameObject.SetActive (false);
			navigator.gameObject.SetActive (false);
			powerEditor.gameObject.SetActive (false);
		} else if (Input.GetKeyDown (KeyCode.B)) {

			hullSpawner.gameObject.SetActive (false);
			blockSpawner.gameObject.SetActive (true);
			navigator.gameObject.SetActive (false);
			powerEditor.gameObject.SetActive (false);
		} else if (Input.GetKeyDown (KeyCode.N)) {

			hullSpawner.gameObject.SetActive (false);
			blockSpawner.gameObject.SetActive (false);
			navigator.gameObject.SetActive (true);
			powerEditor.gameObject.SetActive (false);
		} else if (Input.GetKeyDown (KeyCode.P)) {
		
			hullSpawner.gameObject.SetActive (false);
			blockSpawner.gameObject.SetActive (false);
			navigator.gameObject.SetActive (false);
			powerEditor.gameObject.SetActive (true);
		}
	}
}
