using System.Collections;
using UnityEngine;

public class VolumMuteMusic : MonoBehaviour{
    public void Start (){
	    // Recordar si el volumen fue muteado la última vez
        if (PlayerPrefs.GetInt("MusicMute") == 0)
        {
          GetComponent<AudioSource>().mute = false;  
        }else{
            GetComponent<AudioSource>().mute = true;
        }
    }

	public void UpdateVolume (){
		if (PlayerPrefs.GetInt("MusicMute") == 0)
        {
          GetComponent<AudioSource>().mute = false;  
        }else{
            GetComponent<AudioSource>().mute = true;
        }
	}

}
