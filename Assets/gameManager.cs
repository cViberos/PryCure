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
    //GameObject newCopy;
    bool allUsed = false;
    public GameObject selectedTile;
    private RaycastHit hit;
    public GameObject[,] matrixDisp;
    void Start()
    {
        sizeX = generador.GetComponent<tileGenerator>().sizeX;
        sizeY = generador.GetComponent<tileGenerator>().sizeY;

        matrixDisp = new GameObject[sizeX, sizeY];

        int k = 0;
        for (int i = 0; i < sizeY; i++)
        {

            for (int j = 0; j < sizeX; j++)
            {


                matrixDisp[i,j] = Instantiate(disponibleTile, new Vector3(j, -i, -0.2f), Quaternion.identity);
                matrixDisp[i, j].SetActive(true);
                matrixDisp[i, j].GetComponent<tileData>().posX = j;
                matrixDisp[i, j].GetComponent<tileData>().posY = i;

                if (NoDisponibleArray[k] == true)
                {
                    matrixDisp[i, j].GetComponent<SpriteRenderer>().material.SetColor("_Color", Color.red);
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

            if (Input.GetMouseButtonDown(0))
            {

                if (hit.transform.name == "TILE(Clone)")
                {
                    int posX = hit.transform.gameObject.GetComponent<tileData>().posX;
                    int posY = hit.transform.gameObject.GetComponent<tileData>().posY;

                    sizeX = generador.GetComponent<tileGenerator>().sizeX;
                    sizeY = generador.GetComponent<tileGenerator>().sizeY;

                    int k = 0;
                    for (int i = 0; i < sizeY; i++)
                    {
                        
                        for (int j = 0; j < sizeX; j++)
                        {
                            if (i == posY && j == posX)
                            {
                                NoDisponibleArray[k] = true;
                                matrixDisp[i, j].GetComponent<SpriteRenderer>().material.SetColor("_Color", Color.red);
                            }
                            else
                            {
                                k += 1;
                            }
                        }
                        
                    }
                    
                    


                }

                
            }
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
