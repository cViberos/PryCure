using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class AvionSpawn : MonoBehaviour
{

    public GameObject[] avionetas;
    
    private Vector2 RandomPos;
    private bool spawn = true;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        int position = Random.Range(0, 4);

        if (spawn == true)
        {
            if (position == 0)
            {
                spawn = false;
                RandomPos.x = 9.5f;
                RandomPos.y = Random.Range(-7.5f, -0.43f);
                Instantiate(avionetas[position], new Vector3(RandomPos.x, RandomPos.y, -0.6f), transform.rotation);

                StartCoroutine("Wait");

            }

            else if (position == 1)
            {
                spawn = false;
                RandomPos.x = -6.3f;
                RandomPos.y = Random.Range(-7.5f, -0.43f);
                Instantiate(avionetas[position], new Vector3(RandomPos.x, RandomPos.y, -0.6f), transform.rotation);

                StartCoroutine("Wait");

            }
            if (position == 2)
            {
                spawn = false;
                RandomPos.y = 0.5f;
                RandomPos.x = Random.Range(-1.5f, 4.7f);
                Instantiate(avionetas[position], new Vector3(RandomPos.x, RandomPos.y, -0.6f), transform.rotation);

                StartCoroutine("Wait");
            }
            if (position == 3)
            {
                spawn = false;
                RandomPos.y = -8.0f;
                RandomPos.x = Random.Range(-1.5f, 4.7f);
                Instantiate(avionetas[position], new Vector3(RandomPos.x, RandomPos.y, -0.6f), transform.rotation);

                StartCoroutine("Wait");
            }


        }
    }


    private void StartDelay()
    {
       
        spawn = true;
    }

    IEnumerator Wait()
    {
        
        yield return new WaitForSecondsRealtime(5.0f);
        StartDelay();
    }
}

  