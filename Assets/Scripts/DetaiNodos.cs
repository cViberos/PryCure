using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DetaiNodos : MonoBehaviour
{
    public GameObject Panel;
    public Text Title;
    public Text Valores;
    private Animator anim;
    
    [Header("Informacion Mostrada:")]
    [Tooltip("Detalle de toda la informacion que se mostrara cuando se selecciona cada item")]
    public string Titulo;
    [TextArea]
    public string Detalles;

    void Start() {
        anim = Panel.GetComponent<Animator>();
    }
    void OnMouseEnter() {
        Title.text= Titulo;
        Valores.text= Detalles;
        Panel.SetActive(true); 
        anim.SetBool("LugarSelect", true); 
    }

    void OnMouseExit() {
       anim.SetBool("LugarSelect", false); 
    }
}
