using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameLogic : MonoBehaviour {

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}


public class Sector {
	public List<Sector> Sectors;
	public string Name;
	public GameObject objSect;


	public Sector(string name="noname",float x = 0F, float z = 0F) {
		SpriteRenderer sprt;
		Transform trfm;
		//Rect rect = new Rect(0,0,1,1);
		//Vector2 v2 = new Vector2(0.5F, 0.5F); 
		Sectors = new List<Sector> ();
		Name = name;
		//spawn object
		objSect = new GameObject("GO "+ name);
		//Add Components
		sprt = objSect.AddComponent<SpriteRenderer>();
		objSect.AddComponent<SphereCollider> ();
		trfm = objSect.GetComponent<Transform> ();
		trfm.SetParent(GameObject.Find("StarsSystem").transform,false);
		trfm.position = new Vector3 (x, 10F, z);
		sprt.sprite = GameObject.Find ("SpriteModel").GetComponent <SpriteRenderer > ().sprite;
	}
}