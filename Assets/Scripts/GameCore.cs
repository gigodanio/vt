using UnityEngine;
using System.Collections;

public class GameCore : MonoBehaviour {

	public Rect galacticSize;
	Sector RootSector;

	// Use this for initialization
	void Start () {
		Sector sect;
		RootSector = new Sector ("First", 0F, 0F);
		RootSector .objSect .SetActive (false);
		for (int i=0; i<100; i++) {
			sect = new Sector ("Star "+i, Random.Range(-1000F,800F), Random.Range(-600F,600F));
			RootSector.Sectors.Add (sect);
		}
	}
	
	// Update is called once per frame
	void Update () {
		Transform sectT, camT;
		camT=GameObject .Find ("Main Camera").GetComponent <Transform >();
		foreach ( Sector sect in RootSector.Sectors  ) {
			sectT=sect.objSect.GetComponent <Transform >();
			sectT.LookAt (sectT.position + camT.rotation * Vector3 .forward , camT.rotation  * Vector3 .up ) ;
			sectT.localScale = new Vector3 (camT.position .y / 30, camT.position .y / 30, camT.position .y/ 30);
			sect.objSect.GetComponent<SphereCollider>().radius = 1.28F;//camT.position .y / 30 * 1.28F ;

//			transform.LookAt(transform.position + m_Camera.transform.rotation * Vector3.forward,
//			                 m_Camera.transform.rotation * Vector3.up);
		}
	}
}
