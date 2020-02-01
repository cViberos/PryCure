using UnityEngine;
using UnityEngine.UI;

public class ImputClave : MonoBehaviour{
    public Image IcoVisible;
    public Image IcoNoVisible;
    public void BotonClave(){
        //Preguntamos si mostrar la contrasenia
        if (GetComponent<InputField>().contentType == InputField.ContentType.Password)
        {
            GetComponent<InputField>().contentType = InputField.ContentType.Standard;
            IcoNoVisible.gameObject.SetActive(true);
            IcoVisible.gameObject.SetActive(false);
        }else{
            GetComponent<InputField>().contentType = InputField.ContentType.Password;
            IcoNoVisible.gameObject.SetActive(false);
            IcoVisible.gameObject.SetActive(true);
        }
        GetComponent<InputField>().Select();
        GetComponent<InputField>().ActivateInputField();
    }
}
