using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CameraController : MonoBehaviour {

	public float speedCam = 3000;
	public float speedZoom = 4000;
	public float altitude = 1;  //1..10
	public bool camAutoMoving = false;
	public GameObject camFocusTarget;
	public int cameraMode = 0;  //0: Galactic
								//1: Systeme
								//2: Planet
								//3: Ship
								//4: Station

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		float movDrG = Input.GetAxis ("Horizontal");
		float movHB = Input.GetAxis ("Vertical");
		float zoom = Input.GetAxis ("Mouse ScrollWheel");
		Vector3 posCam;
		Ray mousePointing;
		RaycastHit[] starSelected;

		if (Input.GetMouseButtonDown (0)) {
			RaycastHit starHit;
			mousePointing = GetComponent<Camera>().ScreenPointToRay(Input.mousePosition) ;
			GameObject.Find ("PointingDebug").GetComponent <Text> ().text = mousePointing.ToString();
			if (Physics.Raycast(mousePointing,2000))
			{
				starSelected = Physics.RaycastAll(mousePointing,2000);
			    starHit = starSelected[0];
				GameObject.Find ("PointingDebug2").GetComponent <Text> ().text =starHit.collider.gameObject.name + "length" + starSelected.Length;
				SetFocus(starHit.collider.gameObject) ;
			} else
				GameObject.Find ("PointingDebug2").GetComponent <Text> ().text ="Pointing nowhere";

		}

		if (!camAutoMoving) {
			transform.Translate (movDrG * Time.deltaTime * speedCam * transform.position.y, 0, movHB * Time.deltaTime * speedCam * transform.position.y, Space.World);
			posCam = transform.position;
			if (posCam.x > 800)
				posCam.x = 800; 
			if (posCam.x < -1000)
				posCam.x = -1000; 
			if (posCam.z > 600)
				posCam.z = 600; 
			if (posCam.z < -600)
				posCam.z = -600; 
			transform.position = posCam;
	
			if ((posCam.y > 1) && (zoom > 0)) {
				transform.Translate (0, 0, zoom * Time.deltaTime * speedZoom * posCam.y);
				posCam = transform.position;
			}
			if ((posCam.y < 1000) && (zoom < 0)) {
				transform.Translate (0, 0, zoom * Time.deltaTime * speedZoom * posCam.y);
				posCam = transform.position;
			}
			if (posCam.y > 1000)
				posCam.y = 1000; 
			if (posCam.y < 1)
				posCam.y = 1; 

			transform.position = posCam;
			altitude = posCam.y;
		} else {
			Vector3 target;
			target = camFocusTarget.transform.position;
			target.y += 2F;
			target.z -= 1F;
			transform.position = Vector3.MoveTowards(transform.position,target,Time.deltaTime*1000);
			if (transform.position == target) camAutoMoving = false;
		}
	}

	void SetFocus(GameObject obj) {
		camAutoMoving = true;
		camFocusTarget = obj;
	}
}
