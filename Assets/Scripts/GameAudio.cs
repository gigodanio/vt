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

        //part 1: Mix Music = f(camera.altitude)
		if (Camera) {
			//switch (Camera.altitude)
			//Camera.altitude
			if (Camera.altitude <= 1)
				mixMusic("drumbass");
			else if (Camera.altitude <= 8)
				mixMusic("drumbassfx");
			else
				mixMusic("drumbells", 0);
		}
		else
			mixMusic("drumbassfx");


		GameObject.Find ("DebugLine6").GetComponent <Text> ().text = Camera.altitude.ToString();
		GameObject.Find ("DebugLine7").GetComponent <Text>().text = ActiveSnapshot.name;

        //todo: part 2: play fx .....        
	}
	    
    private void mixMusic(string SnapshotName, float TransitionTime=2)
    {               
	    if (!ActiveSnapshot || (ActiveSnapshot.name != SnapshotName)) {
			ActiveSnapshot = MixerMain.FindSnapshot (SnapshotName);	
		
			if (ActiveSnapshot) 
				ActiveSnapshot.TransitionTo (TransitionTime);		
		}

    }
}
