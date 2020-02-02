using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tileData : MonoBehaviour
{
    public int posX, posY;
    public int poblacion;
    public int tipo; // Tipo 1: PLaya, Tipo 2:LLanura, Tipo 3: Montaña;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Playa"))
            tipo = 1;
        if (collision.gameObject.CompareTag("Llanura"))
            tipo = 2;
        if (collision.gameObject.CompareTag("Montana"))
            tipo = 3;
        
    }
}
