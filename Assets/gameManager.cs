using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameManager : MonoBehaviour
{
    public int turn;
    public GameObject generador;
    int sizeX, sizeY;
    public GameObject disponibleTile;
    public bool[] NoDisponibleArray;
    GameObject newCopy;
    bool allUsed = false;
    public GameObject selectedTile;
    private RaycastHit hit;
    void Start()
    {
        sizeX = generador.GetComponent<tileGenerator>().sizeX;
        sizeY = generador.GetComponent<tileGenerator>().sizeY;
        int k = 0;
        for (int i = 0; i < sizeY; i++)
        {
            
            for (int j = 0; j < sizeX; j++)
            {
                
                newCopy = Instantiate(disponibleTile, new Vector3(j , -i , -0.2f), Quaternion.identity);
                newCopy.SetActive(true);
                if(NoDisponibleArray[k]==true)
                {
                    newCopy.GetComponent<SpriteRenderer>().material.SetColor("_Color", Color.red);
                }
                k += 1;
            }
            
        }

    }

    // Update is called once per frame
    void Update()
    {

        print("Es el turno:" + turn);

        LayerMask layerMask = ~(1 << 9);
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit, 100f, layerMask))
        {
            Vector3 pos = new Vector3(hit.point.x, hit.point.y, 0);
            transform.position = pos;
            selectedTile.transform.position = new Vector3((int)pos.x, (int)pos.y, 0.1f);
        }

        if (allUsed == false)
            for (int i = 0; i < NoDisponibleArray.Length; i++)
            {
                allUsed = true;

                if ( NoDisponibleArray[i] != true)
                {
                    allUsed = false;
                }
            }
        
    }
}
