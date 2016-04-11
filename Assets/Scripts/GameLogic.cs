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
	public GameObject spriteSect;
	public GameObject[] planet;
	public int nbPlanets = 0;


	public Sector(string name,Vector3 pos,int nbplanets = 0) {
		GameObject strlght;

		Sectors = new List<Sector> ();
		Name = name;
		nbPlanets = nbplanets;

		//spawn base object of sector
		objSect = new GameObject("GO "+ name);
		objSect.AddComponent<SphereCollider> ();
		objSect.AddComponent<SectorScript>();
		objSect.GetComponent<Transform>().SetParent(GameObject.Find("StarsSystem").transform,false);
		objSect.GetComponent<Transform> ().position = pos;

		// Create Sprite for star rendering
		spriteSect = new GameObject ("Sprite " + name);
		spriteSect.AddComponent<SpriteRenderer>();
		spriteSect.GetComponent<SpriteRenderer>().sprite = GameObject.Find ("SpriteModel").GetComponent <SpriteRenderer > ().sprite;
		spriteSect.GetComponent<Transform> ().SetParent(objSect.transform,false);

		// Create light for sector
		strlght = new GameObject ("Light " + name);
		strlght.AddComponent<Light> ();
		strlght.GetComponent<Light> ().type = LightType.Point;
		strlght.GetComponent<Light> ().range = 10;
		strlght.GetComponent<Transform> ().SetParent(objSect.transform,false);

		//Add planets
		if (nbplanets != 0) {
			planet = new GameObject[nbplanets];
			for (int i = 0; i<nbplanets; i++) {
				planet[i] = GameObject.CreatePrimitive(PrimitiveType.Sphere);
				planet[i].name = name + "Planet " + i;
				planet[i].GetComponent<Transform>().position = new Vector3(Random.Range(-5,5),0,Random.Range(-5,5));
				planet[i].GetComponent<Transform>().SetParent(objSect.transform,false);
			}
		}
	}
}