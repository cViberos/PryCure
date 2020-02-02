using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameManager : MonoBehaviour
{
    public int poblacionJ1, poblacionJ2;
    public int turn;
    public GameObject generador;
    public int sizeX, sizeY;
    public GameObject disponibleTile;
    public bool[] NoDisponibleArray;
    //GameObject newCopy;
    //bool allUsed = false;
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

    //public GameObject Humano;
    //public GameObject Virus;
    public Canvas canvas;

    void Start()
    {
        canvas.gameObject.SetActive(true);

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
        //print("Es el turno:" + turn);

        LayerMask layerMask = ~(1 << 9);
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        // Etapa de Seleccion
        if  (turn <= 16)
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
 
                                    if(NoDisponibleArray[k]==false)
                                    {
                                        NoDisponibleArray[k] = true;
                                        matrixDisp[i, j].GetComponent<SpriteRenderer>().material.SetColor("_Color", Color.red);

                                        takeTurn();

                                        if (turn % 2 == 0)
                                        {
                                            if (turn == 0)
                                            {
                                                Instantiate(prefabVirus[0], new Vector3(posX + 0.5f, -posY + 0.97f, -0.6f), prefabVirus[0].transform.rotation);//Cambiar cuando cambien los modelos
                                            }
                                            cartelJuegaHumano.SetActive(true);
                                            cartelJuegaVirus.SetActive(false);
                                            tilesJugador1[cantTilesJ1] = matrixDisp[i, j];
                                            cantTilesJ1++;
                                        }
                                        else
                                        {
                                            if (turn == 1)
                                                
                                            {
                                                Instantiate(prefabSalud[0], new Vector3(posX - 0.4f, -posY - 0.4f, -0.6f), prefabSalud[0].transform.rotation);//Cambiar cuando cambien los modelos
                                            }
                                            cartelJuegaHumano.SetActive(false);
                                            cartelJuegaVirus.SetActive(true);
                                            tilesJugador2[cantTilesJ2] = matrixDisp[i, j];
                                            cantTilesJ2++;
                                        }

                                            /*if (turn % 2 == 0)
                                            {
                                                // Anula los clicks invalidos.
                                                //if (posX != 0 && posX != 5 && posY != 0 && posY != 5 && NoDisponibleArray[k] == false)
                                                //{
                                                if(turn == 0)
                                                    {
                                                        Instantiate(prefabVirus[0], new Vector3(posX + 0.5f, -posY + 0.97f, -0.6f), prefabVirus[0].transform.rotation);//Cambiar cuando cambien los modelos
                                                    }

                                                    NoDisponibleArray[k] = true;
                                                    matrixDisp[i, j].GetComponent<SpriteRenderer>().material.SetColor("_Color", Color.red);
                                                    cartelJuegaHumano.SetActive(true);
                                                    cartelJuegaVirus.SetActive(false);
                                                    tilesJugador1[cantTilesJ1] = matrixDisp[i, j];
                                                    cantTilesJ1++;
                                                    turn++;
                                                //}


                                            }
                                            else
                                            {
                                                if (turn == 1)
                                                    Instantiate(prefabSalud[0], new Vector3(posX -0.4f, -posY -0.4f, -0.6f), prefabSalud[0].transform.rotation);//Cambiar cuando cambien los modelos
                                                {
                                                    NoDisponibleArray[k] = true;
                                                    matrixDisp[i, j].GetComponent<SpriteRenderer>().material.SetColor("_Color", Color.red);
                                                    cartelJuegaHumano.SetActive(false);
                                                    cartelJuegaVirus.SetActive(true);
                                                    tilesJugador2[cantTilesJ2] = matrixDisp[i, j];
                                                    cantTilesJ2++;
                                                    turn++;
                                                }
                                            }*/
                                        }
                                    else
                                    {
                                        print("casilla ocupada!");
                                    }
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

        }
        //Fin Etapa Elegir Casillas
        //Inicio de Juego
        else
        {
            //Humano.gameObject.GetComponent<ManagerHumano>().poblacion+=  CalcularPoblacion(tilesJugador1, Humano);

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

    public void takeTurn()
    {
        turn++;
        print("Es el turno:" + turn);
        print("Poblacion Jugador 1 :" + poblacionJ1);
        print("Poblacion Jugador 2 :" + poblacionJ2);

    }

    //No funciona..."GameObject[] player" probablemente
    public int CalcularPoblacion(GameObject[] player,GameObject HV)
      {

        int poblacion = 0;
          for(int index =0; index < player.Length;index++)
          {
            Debug.Log("Index" + index);
            
              int posx = player[index].gameObject.GetComponent<tileData>().posX;
              int posy = player[index].gameObject.GetComponent<tileData>().posY;

            Collider[] hitColliders = Physics.OverlapSphere(new Vector3(posx, posy, -0.1f), 10.0f);

            if (hitColliders.Length >= 1)

            {
                Debug.Log("Found");
                for (int count = 0; count < hitColliders.Length; count++)
                {
                    if (hitColliders[count].gameObject.CompareTag("Playa"))
                        poblacion += 300;
                    if (hitColliders[count].gameObject.CompareTag("Llanura"))
                        poblacion += 800;
                    if (hitColliders[count].gameObject.CompareTag("Montana"))
                        poblacion += 1200;
 }
            }


        }
        return poblacion;
      }

}