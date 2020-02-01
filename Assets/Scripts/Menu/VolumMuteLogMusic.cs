using System.Collections;
using UnityEngine;

public class VolumMuteLogMusic : MonoBehaviour
{
    public void Start (){
	    // Recordar si el volumen del Login fue muteado la última vez
        if (PlayerPrefs.GetInt("MusicLogMute") == 0)
        {
          GetComponent<AudioSource>().mute = false;  
        }else{
            GetComponent<AudioSource>().mute = true;
        }
    }

	public void UpdateVolumeMuteLog (){
		if (PlayerPrefs.GetInt("MusicLogMute") == 0)
        {
          GetComponent<AudioSource>().mute = false;  
        }else{
            GetComponent<AudioSource>().mute = true;
        }
	}
}
