﻿using System.Collections;
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
    public GameObject JuegaHumano;
    public GameObject JuegaVirus;
    void Start()
    {
        sizeX = generador.GetComponent<tileGenerator>().sizeX;
        sizeY = generador.GetComponent<tileGenerator>().sizeY;

        int k = 0;
        for (int i = 0; i < sizeY; i++)
        {

            for (int j = 0; j < sizeX; j++)
            {

                newCopy = Instantiate(disponibleTile, new Vector3(j, -i, -0.2f), Quaternion.identity);
                newCopy.SetActive(true);
                if (NoDisponibleArray[k] == true)
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
        if (turn % 2 == 0)
        {
            JuegaHumano.SetActive(true);
            JuegaVirus.SetActive(false);

        }
        else
        {
            JuegaHumano.SetActive(false);
            JuegaVirus.SetActive(true);
        }
        




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
                                hit.transform.gameObject.GetComponent<MeshRenderer>().material.SetColor("_Color", UnityEngine.Color.red);
                            }
                            else
                            {
                                k += 1;
                            }
                        }
                        
                    }
                    
                    


                }
                turn++;

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
