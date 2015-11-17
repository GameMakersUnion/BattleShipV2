using UnityEngine;
using System.Collections;

public abstract class Equipment : MonoBehaviour
{
	public bool Powered;
	public Color DefaultColor;

	public virtual void Start () {
		DefaultColor = gameObject.GetComponent <SpriteRenderer> ().color;
	}
	
	// Update is called once per frame
	public virtual void Update () {
		if (this.Powered == true) {
			gameObject.GetComponent <SpriteRenderer> ().color = DefaultColor;
		} else {
			Color c = new Color (DefaultColor.r * 0.5f, DefaultColor.g * 0.5f, DefaultColor.b * 0.5f);
			gameObject.GetComponent <SpriteRenderer> ().color = c;
		}
	}
}
