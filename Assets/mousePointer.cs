using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mousePointer : MonoBehaviour
{
    public GameObject selectedTile;
    private RaycastHit hit;
    public Camera camera;
    private Vector3 posCamera;
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
            Vector3 pos = new Vector3(hit.point.x, 0, hit.point.z);
            transform.position = pos;
            selectedTile.transform.position = new Vector3( (int)pos.x, 0.1f, (int)pos.z );
            //camera.transform.position = posCamera + transform.position;
            //posCamera = camera.transform.position + new Vector3(8, 8, -3);
            //camera.transform.position = posCamera;

            

        }
        
    }
}
