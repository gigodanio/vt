using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CanvasRTDriver : MonoBehaviour {

	// Use this for initialization
	void Start () {
		RectTransform rect;
		transform.SetParent (GameObject.Find ("Main Camera").GetComponent<Transform> ());
		rect = GetComponent<RectTransform> ();
		rect.anchoredPosition3D = new Vector3 (-0.26F, 0, 0.33F);
		transform.rotation = new Quaternion(0, 0, 0, 0);
		transform.Rotate(new Vector3(0,-20,0));
		transform.localScale = new Vector3(0.0001F,0.0001F,1);
	}
	
	// Update is called once per frame
	void Update () {
		GameObject.Find ("DebugLine3").GetComponent <Text>().text = GetComponent<Transform>().rotation.ToString();


		/*Vector3 scl;
		Quaternion rot;
		RectTransform rect;
		Transform trf = GetComponent<Transform>();
		rect = GetComponent<RectTransform> ();
		rot = trf.rotation;
		rot.Set (0, 0, 0, 0);
		scl = rect.localScale;
		scl.x = 0.001F;
		scl.y = 0.001F;*/

	}
}
