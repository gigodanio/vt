using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class AudioTrackBehaviour : MonoBehaviour {

    public float p1Volume;
    public float p1Altitude;

    public float p2Volume;
    public float p2Altitude;

	void Start () {
        	
	}
	

	void Update () {
	
	}

    public float GetVolume(float altitude)
    {
        float res = 0;

        if (altitude <= p1Altitude)
            res = p1Volume;
        else if (altitude >= p2Altitude)
            res = p2Volume;
        else
        {
            //Calculer la pente y=ax+b

            float pente = 0;
            if ((p2Altitude - p1Altitude) != 0)
                pente = (p2Volume - p1Volume) / (p2Altitude - p1Altitude);


            res = p1Volume + pente * (altitude - p1Altitude);

            GameObject.Find ("AudioDebugInfos").GetComponent <Text>().text = "pente: " + pente;
			GameObject.Find ("AudioDebugInfos").GetComponent <Text>().text = "p1Volume: " + p1Volume;
        }

		GameObject.Find ("AudioDebugInfos").GetComponent <Text>().text = altitude + " " + res;

        return res;
    }
}
