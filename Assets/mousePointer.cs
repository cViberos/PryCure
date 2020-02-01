using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mousePointer : MonoBehaviour
{
    public GameObject selectedTile;
    private RaycastHit hit;
    public Camera camera;
    private Vector3 posCamera;
    public float posix;
    public float posiy;
    // Start is called before the first frame update
    void Start()
    {
         //posCamera =camera.transform.position ;
    }

    // Update is called once per frame
    void Update()
    {
        LayerMask layerMask = ~(1 << 9);
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit,100f,layerMask))
        {
            Vector3 pos = new Vector3(hit.point.x, hit.point.y, 0);
            transform.position = pos;
            //selectedTile.transform.position = new Vector3(pos.x, pos.y, 0.1f);
            
            posix=pos.x-(int)pos.x;
            posiy=System.Math.Abs (pos.y-(int)pos.y);

            if (posix >= 0.5f)
            {
                selectedTile.transform.position = new Vector3( (int)pos.x+2, (int)pos.y, 0.1f );
            }else
            {
                //selectedTile.transform.position = new Vector3( (int)pos.x+1, (int)pos.y, 0.1f );
            }

            if (posiy <= 0.5f)
            {
                selectedTile.transform.position = new Vector3( (int)pos.x, (int)pos.y, 0.1f );
            }else
            {
                selectedTile.transform.position = new Vector3( (int)pos.x, (int)pos.y-1, 0.1f );
            }

            if(posix > 0.5f){
                selectedTile.transform.position = new Vector3( (int)pos.x+1, (int)pos.y, 0.1f );
            }
            if (posiy > 0.5f){
                selectedTile.transform.position = new Vector3( (int)pos.x, (int)pos.y-1, 0.1f );
            }



            //selectedTile.transform.position = new Vector3( (int)pos.x, (int)pos.y, 0.1f );
            //camera.transform.position = posCamera + transform.position;
            //posCamera = camera.transform.position + new Vector3(8, 8, -3);
            //camera.transform.position = posCamera;



        }
        
    }
}
