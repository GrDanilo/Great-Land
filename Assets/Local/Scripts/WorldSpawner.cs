using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] WorldElements;
    [SerializeField] private Transform[] WorldPoints;
    [SerializeField] private GameObject[] WorldPointObjects;
    [SerializeField] private GameObject Village;

    void Start()
    {
        int rand = Random.Range(0, 6);
        for(int num = 0; num < WorldPoints.Length; num++)
        {
            if(rand == 0)
            {
                rand = Random.Range(0, 2);
            }
            else if(rand == 1)
            {
                rand = Random.Range(0, 3);
            }
            else if(rand == 2)
            {
                rand = Random.Range(1, 4);
            }
            else if(rand == 3)
            {
                rand = Random.Range(2, 5);
            }
            else if(rand == 4)
            {
                rand = Random.Range(3, 6);
            }
            else if(rand == 5)
            {
                rand = Random.Range(3, 5);
            }
            
            Instantiate(WorldElements[rand], WorldPoints[num].position, WorldPoints[num].rotation);

            if(rand == 2)
            {
                int rands = Random.Range(0, 10);
                if(rands == 0)
                {
                    Instantiate(Village, WorldPoints[num].position, WorldPoints[num].rotation);
                }
            }
            else if(rand == 3)
            {
                int rands = Random.Range(0, 10);
                if(rands == 0)
                {
                    Instantiate(Village, WorldPoints[num].position, WorldPoints[num].rotation);
                }
            }

            Destroy(WorldPointObjects[num]);
        }
    }
}
