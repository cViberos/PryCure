using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoginConfig : MonoBehaviour{
    
    Animator CameraObject;

    [Header("Escena a Cargar")]
    [Tooltip("Es el nombre de la escena que se cargará si todo esta OK")]
    public string NombreEscena = "";

    [Header("Paneles")]
    [Tooltip("El panel UI que muestra los graficos de Logeo")]
    public GameObject LienzoLogeo;
    [Tooltip("El panel UI que muestra los servidores disponibles")]
    public GameObject LienzoServidor;
    [Tooltip("El panel UI que contiene a la ventana MENSAJE")]
    public GameObject LienzoMensaje;
    [Tooltip("El panel UI que contiene a la ventana RECUPERACION")]
    public GameObject LienzoRecuperador;
    [Tooltip("El panel UI que contiene a la ventana CREACION")]
    public GameObject LienzoCreador;

    //Botones relacionados con el inicio de sesion
    [Header("Inicio de Sesion")]
    public InputField DatoUsuario;
    [Tooltip("Es un input para tener la clave de acceso")]
    public InputField DatoClave;

    [Header("Ajustes de Inicio")]
    [Tooltip("Es un toggle usado para determinar si se recuerda el nombre de usuario")]
    public Toggle CuentaRecord;
    [Tooltip("Es un toggle usado para poder mutear o desmutear la musica")]
    public Toggle MuteMusicLog;

    void Start() {
        //CameraObject = transform.GetComponent<Animator>(); 
        if (PlayerPrefs.GetInt("MusicLogMute") == 1){
            MuteMusicLog.isOn = true;            
        } else{
            MuteMusicLog.isOn = false;
        }
        if (PlayerPrefs.GetString("NombreCuenta") != "")
        {
            CuentaRecord.isOn = true;
            DatoUsuario.text = PlayerPrefs.GetString("NombreCuenta");
        }
    }

    public void Iniciar (){
        if ((DatoClave.text != "")&&(DatoUsuario.text != "")){
            //Si inicia correctamente preguntamos si esta activado el toggle para recordar el nombre de usuario si es asi entonces guardamos el nombre
            if (CuentaRecord.isOn == true){
                PlayerPrefs.SetString("NombreCuenta", DatoUsuario.text);  
            }else{
                PlayerPrefs.SetString("NombreCuenta", "");
            }
            //Cargamos la escena siguiente que viene ser el launcher
            SceneManager.LoadScene(NombreEscena, LoadSceneMode.Single);
        }
    }
    public void SalirMsj (){
        LienzoMensaje.gameObject.SetActive(true);
    }
    public void  SalirYes (){
		Application.Quit();
	}
	public void  SalirNo (){
		LienzoMensaje.gameObject.SetActive(false);
	}
    public void MusicLogMuteador (){
        if (MuteMusicLog.isOn == true){
          PlayerPrefs.SetInt("MusicLogMute", 1);  
        }else{
           PlayerPrefs.SetInt("MusicLogMute", 0); 
        }
    }

    public void CrearCuenta(){
        LienzoLogeo.gameObject.SetActive(false);
        LienzoCreador.gameObject.SetActive(true);
    }
    public void RecupCuenta(){
        LienzoLogeo.gameObject.SetActive(false);
        LienzoRecuperador.gameObject.SetActive(true);
    }
    public void VolverLogeo(GameObject LienzoUsado){
        LienzoUsado.gameObject.SetActive(false);
        LienzoLogeo.gameObject.SetActive(true);
    }
}
