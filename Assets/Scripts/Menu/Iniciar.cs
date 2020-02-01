using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Iniciar : MonoBehaviour
{
    [Header("Escena a Cargar")]
    [Tooltip("Es el nombre de la escena que se cargará si todo esta OK")]
    public string NombreEscena = "";
    public int Intento;

    //Cargamos la escena siguiente que viene ser el launcher
    public void Iniciando (){
        SceneManager.LoadScene(NombreEscena, LoadSceneMode.Single);
    }

    //Comando para salir del juego
    public void  Salir (){
		Application.Quit();
	}
}
