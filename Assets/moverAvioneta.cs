using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moverAvioneta : MonoBehaviour
{
    private int leftbound = 10;
    private float speed;
    
    // Start is called before the first frame update
    void Start()
    {
         speed = 5;
}

    // Update is called once per frame
    void Update()
    {
        speed = Random.Range(3f, 7f);
        if (gameObject.CompareTag("Derecha"))
            transform.Translate(Vector3.left * speed * Time.deltaTime);
        if (gameObject.CompareTag("Izquierda"))
            transform.Translate(Vector3.right * speed * Time.deltaTime);
        if (gameObject.CompareTag("Arriba"))
            transform.Translate(Vector3.down * speed * Time.deltaTime);
        if (gameObject.CompareTag("Abajo"))
            transform.Translate(Vector3.up * speed * Time.deltaTime);

        if (transform.position.x > leftbound || transform.position.x < -leftbound)
            Destroy(gameObject);

    }
}