using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;

public class Manager : MonoBehaviour {

  public GameObject HullSpawner;
  public GameObject BlockSpawner;
  public GameObject Navigator;



  private static Manager _instance;

  public static Manager instance {
    get {
      if (_instance != null) return _instance;
      _instance = GameObject.FindObjectOfType<Manager>();
      DontDestroyOnLoad(_instance.gameObject);
      return _instance;
    }
  }

  private void Awake() {
    if (_instance == null) {
      _instance = this;
      DontDestroyOnLoad(this);
    }
    else {
      if (this != _instance)
        Destroy(this.gameObject);
    }
  }

  public void AddBlock(GameObject BlockPrefab, Vector2 WorldPos, Transform parent) {
    var pt = new Point(WorldPos);
    if (pt.x == 0 && pt.y == 0) return;

    var go = Instantiate(BlockPrefab);
    go.transform.parent = parent;
    go.transform.position = WorldPos;

    if (ship.ContainsKey(pt)) {
      Destroy(ship[pt]);
    }
    ship[pt] = go;
    
  }

  public void RemoveBlock(Vector2 worldPos) {
    var pt = new Point(worldPos);
    if (pt.x == 0 && pt.y == 0) return;
    if (ship.ContainsKey(pt)) {
      Destroy(ship[pt]);
      ship.Remove(pt);
    }
  }

  public struct Point : IEquatable<Point> {
    public static readonly Point Zero = new Point(0,0);
    public int x, y;
    public Point(int x, int y) {
      this.x = x;
      this.y = y;
    }
    public Point(Vector2 src)
    {
       x = Mathf.FloorToInt(src.x);
       y = Mathf.FloorToInt(src.y);
    }
    
    public bool Equals(Point other) {
      return other.x == x && other.y == y;
    }
  }
  public Dictionary<Point, GameObject> ship = new Dictionary<Point, GameObject>();
	void Update () {
	  if (Input.GetKeyDown(KeyCode.H)) {
	    HullSpawner.SetActive(true);
      BlockSpawner.SetActive(false);
      Navigator.SetActive(false);
	  } else if (Input.GetKeyDown(KeyCode.B)) {

      HullSpawner.SetActive(false);
      BlockSpawner.SetActive(true);
      Navigator.SetActive(false);
    }
    else if (Input.GetKeyDown(KeyCode.N)) {

      HullSpawner.SetActive(false);
      BlockSpawner.SetActive(false);
      Navigator.SetActive(true);
    }
	}
}
