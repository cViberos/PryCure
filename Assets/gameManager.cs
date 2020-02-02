using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameManager : MonoBehaviour
{
    public int turn;
    public GameObject generador;
    public int sizeX, sizeY;
    public GameObject disponibleTile;
    public bool[] NoDisponibleArray;
    //GameObject newCopy;
    bool allUsed = false;
    public GameObject selectedTile;
    private RaycastHit hit;
    public GameObject[,] matrixDisp;
    public GameObject[] tilesJugador1;
    private int cantTilesJ1 = 0;
    public GameObject[] tilesJugador2;
    private int cantTilesJ2 = 0;
    public GameObject cartelJuegaHumano;
    public GameObject cartelJuegaVirus;


    //Prefabs Virus y Hospitales
    public GameObject[] prefabVirus;
    public GameObject[] prefabSalud;

    public int recursosHumanos;
    public int recursosVirus;

    void Start()
    {
        recursosHumanos = 0;
        recursosVirus = 0;
        sizeX = generador.GetComponent<tileGenerator>().sizeX;
        sizeY = generador.GetComponent<tileGenerator>().sizeY;

        matrixDisp = new GameObject[sizeX, sizeY];

        tilesJugador1 = new GameObject[sizeX * sizeY];
        tilesJugador2 = new GameObject[sizeX * sizeY];

        int k = 0;
        for (int i = 0; i < sizeY; i++)
        {

            for (int j = 0; j < sizeX; j++)
            {


                matrixDisp[i, j] = Instantiate(disponibleTile, new Vector3(j, -i, -0.2f), Quaternion.identity);
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

        if (turn <= 16)
        {
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
                                    /* NoDisponibleArray[k] = true;
                                     matrixDisp[i, j].GetComponent<SpriteRenderer>().material.SetColor("_Color", Color.red);*/
                                    if (turn % 2 == 0)
                                    {
                                        // Anula los clicks invalidos.
                                        if (posX != 0 && posX != 5 && posY != 0 && posY != 5 && NoDisponibleArray[k] == false)
                                        {
                                            if(turn == 0)
                                            {
                                                Instantiate(prefabVirus[0], new Vector3(posX + 0.5f, -posY + 0.97f, -0.6f), prefabVirus[0].transform.rotation);
                                            }
                                            NoDisponibleArray[k] = true;
                                            matrixDisp[i, j].GetComponent<SpriteRenderer>().material.SetColor("_Color", Color.red);
                                            cartelJuegaHumano.SetActive(true);
                                            cartelJuegaVirus.SetActive(false);
                                            tilesJugador1[cantTilesJ1] = matrixDisp[i, j];
                                            cantTilesJ1++;
                                            turn++;
                                        }


                                    }
                                    else
                                    {
                                        if (turn == 1)
                                            Instantiate(prefabSalud[0], new Vector3(posX -0.4f, -posY -0.4f, -0.6f), prefabSalud[0].transform.rotation);
                                        {
                                            NoDisponibleArray[k] = true;
                                            matrixDisp[i, j].GetComponent<SpriteRenderer>().material.SetColor("_Color", Color.red);
                                            cartelJuegaHumano.SetActive(false);
                                            cartelJuegaVirus.SetActive(true);
                                            tilesJugador2[cantTilesJ2] = matrixDisp[i, j];
                                            cantTilesJ2++;
                                            turn++;
                                        }



                                    }
                                }
                                else
                                {
                                    k += 1;
                                }
                            }
                        }

                        if (allUsed == false)
                        {
                            for (int i = 0; i < NoDisponibleArray.Length; i++)
                            {
                                allUsed = true;

                                if (NoDisponibleArray[i] == true)
                                {
                                    allUsed = false;
                                }
                            }
                        }
                        else
                        {
                            print("lleno");
                        }
                    }


                }

            }

        }
        else
        {
            if (Physics.Raycast(ray, out hit, 100f, layerMask))
            {
                if (Input.GetMouseButtonDown(0))
                {
                    if (hit.transform.name == "TILE(Clone)")
                    {
                        int posX = hit.transform.gameObject.GetComponent<tileData>().posX;
                        int posY = hit.transform.gameObject.GetComponent<tileData>().posY;



                    }
                    
                }
            }


        }
    }
}