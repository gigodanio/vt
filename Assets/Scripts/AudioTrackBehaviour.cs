using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class AudioTrackBehaviour : MonoBehaviour {

	[Range(0.6f, 10.0f)]
	public float p1Altitude;
	[Range(-4.0f, 0)]
    public float p1Volume;

	[Range(0.6f, 10.0f)]
	public float p2Altitude;
	[Range(-4.0f, 0)]
	public float p2Volume;
	
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
        }
	
        return res;
    }
}
