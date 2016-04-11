using UnityEngine;
using System.Collections;

public class GameCore : MonoBehaviour {

	Sector RootSector;

	// Use this for initialization
	void Start () {
		Sector sect;

		RootSector = new Sector ("First",new Vector3(0F, 0F, 0F));
		RootSector .objSect .SetActive (false);
		for (int i=0; i<100; i++) {
			sect = new Sector ("Star " + i, new Vector3(Random.Range(-1000F,800F), Random.Range(5F,40F), Random.Range(-600F,600F)), Random.Range(0,6));
			sect.objSect.GetComponent<SectorScript>().sectorAttached = sect ;
			sect.objSect.GetComponent<SectorScript>().sectorName = sect.Name;
			sect.objSect.GetComponent<SectorScript>().sectorNbPlanets = sect.nbPlanets;
			RootSector.Sectors.Add (sect);
		}
	}
	
	// Update is called once per frame
	void Update () {
		Transform sectT, camT;
		camT=GameObject .Find ("Main Camera").GetComponent <Transform >();
		foreach ( Sector sect in RootSector.Sectors  ) {
			sectT=sect.spriteSect.GetComponent <Transform >();
			sectT.LookAt (sectT.position + camT.rotation * Vector3 .forward , camT.rotation  * Vector3 .up ) ;
			sectT.localScale = new Vector3 (camT.position .y / 30, camT.position .y / 30, camT.position .y/ 30);
			sect.objSect.GetComponent<SphereCollider>().radius = camT.position .y / 30 * 1.28F;

		}
	}
}
