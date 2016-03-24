using UnityEngine;
using UnityEngine.Audio;
using System.Collections;

public class GameAudio : MonoBehaviour {

	public AudioMixer MixerMain;
	public CameraController Camera;

	void Start () {
		
	}
    
    // Update is called once per frame
    void Update () {

        //part 1: Mix Music = f(camera.altitude)
        mixMusic();

        //todo: part 2: play fx .....        
	}

    private void mixMusic()
    {        
        if (Camera)
        {
            MixerMain.SetFloat("bells_volume", GameObject.Find("bells").GetComponent<AudioTrackBehaviour>().GetVolume(Camera.altitude));
            MixerMain.SetFloat("bass_fx_volume", GameObject.Find("bassfx").GetComponent<AudioTrackBehaviour>().GetVolume(Camera.altitude));
            MixerMain.SetFloat("drum_trad_volume", GameObject.Find("drumtrad").GetComponent<AudioTrackBehaviour>().GetVolume(Camera.altitude));
            MixerMain.SetFloat("bass_massive_volume", GameObject.Find("bass-massive").GetComponent<AudioTrackBehaviour>().GetVolume(Camera.altitude));
            MixerMain.SetFloat("bass_melody_volume", GameObject.Find("bass-melody").GetComponent<AudioTrackBehaviour>().GetVolume(Camera.altitude));
        }
    }
}
