using UnityEngine;
using System.Collections;

public class CanvaMMDriver : MonoBehaviour {

	// Use this for initialization
	void Start () {
		RectTransform rect;
		transform.SetParent (GameObject.Find ("Main Camera").GetComponent<Transform> ());
		rect = GetComponent<RectTransform> ();
		rect.anchoredPosition3D = new Vector3 (0, 0, 0.33F);
		transform.rotation = new Quaternion(0, 0, 0, 0);
		//transform.Rotate(new Vector3(0,-20,0));
		transform.localScale = new Vector3(0.00018F,0.00018F,1);

	}
	
	// Update is called once per frame
	void Update () {

	}
}
