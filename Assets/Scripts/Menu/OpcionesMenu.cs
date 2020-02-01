using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpcionesMenu : MonoBehaviour
{
    [Header("Configuracion de Video")]
    public Button PantallaCompletaSi;
    public Button PantallaCompletaNo;
    public Button BotonSalir;
    
    [Header("Configuracion de Audio")]
    public Toggle VolumenMusicMute;

    private void Awake (){
        if (Screen.fullScreen == false)
        {
            PantallaCompletaSi.gameObject.SetActive(false);
            PantallaCompletaNo.gameObject.SetActive(true);
            BotonSalir.gameObject.SetActive(false);
        }
    }
    
    public void AutoResolucion (){
        string resolOriginal;
        string resolBuscado;
        Resolution[] resolutions = Screen.resolutions;
        
        resolOriginal = Screen.currentResolution.ToString();
        // Busca en la lista de resoluciones
        foreach (var res in resolutions)
        {
            resolBuscado = res.width + " x " + res.height + " @ " + res.refreshRate+"Hz";
            if (resolBuscado == resolOriginal){
              Screen.SetResolution(res.width,res.height,true,res.refreshRate);  
            }
        }
    }
    public void FullScreen (){
		//Screen.fullScreen = !Screen.fullScreen;
		if(Screen.fullScreen == false){
            PantallaCompletaSi.gameObject.SetActive(true);
            PantallaCompletaNo.gameObject.SetActive(false);
            BotonSalir.gameObject.SetActive(true);
            AutoResolucion();
		}
		else if(Screen.fullScreen == true){
			PantallaCompletaSi.gameObject.SetActive(false);
            PantallaCompletaNo.gameObject.SetActive(true);
            BotonSalir.gameObject.SetActive(false);
            Screen.SetResolution(1024,600,false,60);
        }
	}
    public void MusicMutear (){
        if (VolumenMusicMute.isOn == true)
        {
          PlayerPrefs.SetInt("MusicMute", 1);  
        }else{
           PlayerPrefs.SetInt("MusicMute", 0); 
        }
    }
}

