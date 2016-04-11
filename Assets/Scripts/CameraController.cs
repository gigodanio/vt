using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CameraController : MonoBehaviour {

	public float speedCam = 3000;
	public float speedZoom = 4000;
	public float altitude = 1;  //1..10
	public bool camAutoMoving = false;
	public GameObject camFocusTarget;
	public Sector selectedSector = null;
	public int cameraMode = 0;  //0: Galactic
								//1: Systeme
								//2: Planet
								//3: Ship
								//4: Station
	public Bounds currentCamBound;
	public Bounds galacticCamBound;
	public Bounds systemCamBound;
	public Vector3 galacticCamPos;

	// Use this for initialization
	void Start () {
		galacticCamBound = new Bounds(new Vector3(0,600,0),new Vector3(2000,1000,1200));
		currentCamBound = galacticCamBound;
	}
	
	// Update is called once per frame
	void Update () {
		float movDrG = Input.GetAxis ("Horizontal");
		float movHB = Input.GetAxis ("Vertical");
		float zoom = -Input.GetAxis ("Mouse ScrollWheel");
		Vector3 posCam;
		Ray mousePointing;
		RaycastHit[] starSelected;

		// Selection systeme avec la souris
		if (Input.GetMouseButtonDown (0)) {
			RaycastHit starHit;
			mousePointing = GetComponent<Camera>().ScreenPointToRay(Input.mousePosition) ;
			GameObject.Find ("DebugLine2").GetComponent <Text> ().text = mousePointing.ToString();
			if (Physics.Raycast(mousePointing,2000))
			{
				Vector3 starhitpos;
				starSelected = Physics.RaycastAll(mousePointing,2000);
			    starHit = starSelected[0];
				GameObject.Find ("DebugLine2").GetComponent <Text> ().text =starHit.collider.gameObject.name + "length" + starSelected.Length;
				SetFocus(starHit.collider.gameObject) ;
				galacticCamPos = transform.position;
				starhitpos = starHit.collider.gameObject.transform.position;
				systemCamBound = new Bounds(new Vector3(starhitpos.x,starhitpos.y + 6,starhitpos.z),new Vector3(6,8,6));
				currentCamBound = systemCamBound;
			} else
				GameObject.Find ("DebugLine2").GetComponent <Text> ().text ="Pointing nowhere";

		}

		// Gestion touche "TAB"
		if (Input.GetKeyDown(KeyCode.Tab)) {
			// mode vue galactique -> retour vue last sector
			if ( (cameraMode == 0) && (selectedSector!=null) ) {
				SetFocus(selectedSector.objSect);
				currentCamBound = systemCamBound;
			}
			// mode vue system -> retour vue galactique
			else if (cameraMode == 1) {
				SetFocus(null);
				currentCamBound = galacticCamBound;
			}			
	    }

		// translation et zoom camera
		if (!camAutoMoving) {
			posCam = currentCamBound.ClosestPoint(new Vector3((movDrG * Time.deltaTime * speedCam * transform.position.y) + transform.position.x,
			                                                   (zoom * Time.deltaTime * speedZoom * transform.position.y) + transform.position.y,
			                                                   (movHB * Time.deltaTime * speedCam * transform.position.y) + transform.position.z));

			transform.position = posCam;
			if (cameraMode == 0) galacticCamPos = posCam;
		} 
		// mouvements automatisés
		else {
			Vector3 target;
			if (camFocusTarget!=null) {
				target = camFocusTarget.transform.position;
				target.y += 2F;
				target.z -= 1F;
			}
			else {
				target = galacticCamPos ;
			}
			transform.position = Vector3.MoveTowards(transform.position,target,Time.deltaTime*1000);
			if (transform.position == target) camAutoMoving = false;
		}
		altitude = transform.position.y / 100F;
	}

	void SetFocus(GameObject obj) {
		camAutoMoving = true;
		camFocusTarget = obj;
		if (obj != null) {
			selectedSector = obj.GetComponent<SectorScript> ().sectorAttached;
			cameraMode = 1;
		}
		else {
			cameraMode = 0;
		}
	}
}
