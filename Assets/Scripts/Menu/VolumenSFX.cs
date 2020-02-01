using UnityEngine;
using System.Collections;

public class VolumenSFX : MonoBehaviour
{
    public void Start (){
	    // Recordar el nivel de volumen de la última vez
		GetComponent<AudioSource>().volume = PlayerPrefs.GetFloat("MusicVolume");
    }

	public void UpdateVolume (){
		GetComponent<AudioSource>().volume = PlayerPrefs.GetFloat("MusicVolume");
	}
}
