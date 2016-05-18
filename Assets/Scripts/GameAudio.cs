using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using System.Collections;

public class GameAudio : MonoBehaviour {

	public AudioMixer MixerMain;
	public CameraController Camera;

	public AudioMixerSnapshot ActiveSnapshot;


	void Start () {
		MixerMain.FindSnapshot ("mute").TransitionTo (0);
	}
    
    // Update is called once per frame
    void Update () {    
		mixMusic();
        applyFx();
	}
	    
    private void mixMusic(string SnapshotName, float TransitionTime=2)
    {               
		if (!ActiveSnapshot || (ActiveSnapshot.name != SnapshotName)) {
			ActiveSnapshot = MixerMain.FindSnapshot (SnapshotName);	
		
			if (ActiveSnapshot) 
				ActiveSnapshot.TransitionTo (TransitionTime);		
		}
	}

    private void applyFx()
    {
        if (Input.GetMouseButtonDown(0))
            GameObject.Find("onclick").GetComponent<AudioSource>().Play(0);
    }

    private void mixMusic()
    {
        //each track volume = f(AudioTrackBehaviour)
        GameObject.Find("DebugLine6").GetComponent<Text>().text = Camera.altitude.ToString();
        //Track1: busy
        MixerMain.SetFloat("bells_volume", GameObject.Find("bells").GetComponent<AudioTrackBehaviour>().GetVolume(Camera.altitude));
        MixerMain.SetFloat("bass_fx_volume", GameObject.Find("bassfx").GetComponent<AudioTrackBehaviour>().GetVolume(Camera.altitude));
        MixerMain.SetFloat("drum_trad_volume", GameObject.Find("drumtrad").GetComponent<AudioTrackBehaviour>().GetVolume(Camera.altitude));
        MixerMain.SetFloat("bass_massive_volume", GameObject.Find("bass-massive").GetComponent<AudioTrackBehaviour>().GetVolume(Camera.altitude));
        MixerMain.SetFloat("bass_melody_volume", GameObject.Find("bass-melody").GetComponent<AudioTrackBehaviour>().GetVolume(Camera.altitude));

        //Track2: Planos
        MixerMain.SetFloat("brass_volume", GameObject.Find("brass").GetComponent<AudioTrackBehaviour>().GetVolume(Camera.altitude));
        MixerMain.SetFloat("drums_volume", GameObject.Find("drums").GetComponent<AudioTrackBehaviour>().GetVolume(Camera.altitude));
        MixerMain.SetFloat("heartbeat_volume", GameObject.Find("heartbeat").GetComponent<AudioTrackBehaviour>().GetVolume(Camera.altitude));
        MixerMain.SetFloat("lonely_molecule_volume", GameObject.Find("lonely_molecule").GetComponent<AudioTrackBehaviour>().GetVolume(Camera.altitude));
        MixerMain.SetFloat("napelec_volume", GameObject.Find("napelec").GetComponent<AudioTrackBehaviour>().GetVolume(Camera.altitude));
        MixerMain.SetFloat("planos_bass_volume", GameObject.Find("planos_bass").GetComponent<AudioTrackBehaviour>().GetVolume(Camera.altitude));
        MixerMain.SetFloat("planos_bells_volume", GameObject.Find("planos_bells").GetComponent<AudioTrackBehaviour>().GetVolume(Camera.altitude));

    }
}
