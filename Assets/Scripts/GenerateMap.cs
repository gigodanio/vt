using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System.Collections;

public class GenerateMap : MonoBehaviour {

	public int minStar = 50;
	public int maxStar = 1000;
	public int minPlanet = 1;
	public int maxPlanet = 20;
	public int nbStarGenerateMap = 100;
	public int nbPlanetMax = 6;
	// Set in Unity Interface
	public GameObject starSlider, starInput;
	public GameObject planetSlider, planetInput;
	public GameObject gameCore;

	// Use this for initialization
	void Start () {
		RectTransform rect;
		transform.SetParent (GameObject.Find ("Main Camera").GetComponent<Transform> ());
		rect = GetComponent<RectTransform> ();
		rect.anchoredPosition3D = new Vector3 (0, 0, 0.33F);
		transform.rotation = new Quaternion(0, 0, 0, 0);
		transform.localScale = new Vector3(0.00018F,0.00018F,1);


		gameObject.SetActive (false);

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	// Open New Game Interface ( obj = Canvas Main Menu who must be disabled )
	public void OpenNewGameInterface (GameObject obj = null) {
		if (obj != null)
			obj.SetActive (false);
		gameObject.SetActive (true);
		// initialisation of Sliders and InputFields
		starSlider.GetComponent<Slider> ().value = (float)(nbStarGenerateMap-minStar) / (float)(maxStar - minStar);
		planetSlider.GetComponent<Slider> ().value = (float)(nbPlanetMax-minPlanet) / (float)(maxPlanet - minPlanet);
		starInput.GetComponent<InputField> ().text = "" + nbStarGenerateMap;
		planetInput.GetComponent<InputField> ().text = "" + nbPlanetMax;

	}

	// Sliders Update when Inputs have changed
	public void NGISliderUpdate () {
		int nbstar, nbplanet;

		if (int.TryParse(starInput.GetComponent<InputField> ().text,out nbstar)) {
			if (nbstar < minStar)
				nbstar = minStar;
			else if (nbstar > maxStar)
				nbstar = maxStar;
		
			nbStarGenerateMap = nbstar;
			starSlider.GetComponent<Slider> ().value= (float)(nbStarGenerateMap-minStar) / (float)(maxStar - minStar);
		}
		if (int.TryParse(planetInput.GetComponent<InputField> ().text,out nbplanet)) {
			if (nbplanet < minPlanet)
				nbplanet = minPlanet;
			else if (nbplanet > maxPlanet)
				nbplanet = maxPlanet;
			nbPlanetMax = nbplanet;
			planetSlider.GetComponent<Slider> ().value = (float)(nbPlanetMax-minPlanet) / (float)(maxPlanet - minPlanet);
		}
	}

	// Inputs Update when Sliders have changed
	public void NGIInputUpdate () {
		nbStarGenerateMap = (int)(starSlider.GetComponent <Slider> ().value * (float)(maxStar - minStar)) + minStar;
		nbPlanetMax = (int)(planetSlider.GetComponent <Slider> ().value * (float)(maxPlanet - minPlanet)) + minPlanet;
		starInput.GetComponent<InputField> ().text = "" + nbStarGenerateMap;
		planetInput.GetComponent<InputField> ().text = "" + nbPlanetMax;

	}

	// Map Generation
	public void Generate () {
		gameObject.SetActive (false);
		gameCore.GetComponent<GameCore> ().mapGeneration.Invoke ();
	}
}
