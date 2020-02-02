using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tileGenerator : MonoBehaviour
{
    // Start is called before the first frame update
    
    public int sizeX, sizeY;
    public GameObject copy;
    GameObject newCopy;
    void Start()
    {
        
       for (int i = 0; i<sizeY ; i++)
        {
            for (int j = 0 ; j<sizeX ; j++)
            {
                newCopy = Instantiate(copy,new Vector3(j * copy.transform.localScale.x , -i * copy.transform.localScale.y,0),Quaternion.identity);
                newCopy.GetComponent<MeshRenderer>().material.SetColor("_Color", UnityEngine.Random.ColorHSV());
                newCopy.GetComponent<tileData>().posX = j;
                newCopy.GetComponent<tileData>().posY = i;
            }
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
