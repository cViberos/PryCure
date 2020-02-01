using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EstadoPersonaje : MonoBehaviour
{
    // Cuando muere el personaje
    public void Muerte()
    {
        SceneManager.LoadScene("GameOver");
    }
}
