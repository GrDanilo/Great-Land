using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewWorldSpawn : MonoBehaviour
{
    [SerializeField] private GameObject Океан, Мелководье, Пустыня, Земля, Лес, Горы;
    private float sid, n, zoom = 10f;

    [SerializeField] private GameObject Деревня;

    void Start()
    {
        sid = Random.Range(0, 999999);
        for(int i = -15; i < 15; i++)
        {
            for(int j = -15; j < 15; j++)
            {
                n = Mathf.PerlinNoise((i + sid) / zoom, (j + sid) / zoom);

                if(n > 0 && n < 0.32)
                {
                    Quaternion rot = Quaternion.Euler(0, 0, 0);
                    Instantiate(Океан, new Vector2(i, j), rot);
                }
                else if(n > 0.32 && n < 0.4)
                {
                    Quaternion rot = Quaternion.Euler(0, 0, 0);
                    Instantiate(Мелководье, new Vector2(i, j), rot);
                }
                else if(n > 0.4 && n < 0.5)
                {
                    Quaternion rot = Quaternion.Euler(0, 0, 0);
                    Instantiate(Пустыня, new Vector2(i, j), rot);

                    int rand = Random.Range(0, 100);
                    if(rand < 5)
                    {
                        Instantiate(Деревня, new Vector2(i, j), rot);
                    }
                }
                else if(n > 0.5 && n < 0.7)
                {
                    Quaternion rot = Quaternion.Euler(0, 0, 0);
                    Instantiate(Земля, new Vector2(i, j), rot);

                    int rand = Random.Range(0, 100);
                    if(rand < 5)
                    {
                        Instantiate(Деревня, new Vector2(i, j), rot);
                    }
                }
                else if(n > 0.7 && n < 0.8)
                {
                    Quaternion rot = Quaternion.Euler(0, 0, 0);
                    Instantiate(Лес, new Vector2(i, j), rot);
                }
                else if(n > 0.8)
                {
                    Quaternion rot = Quaternion.Euler(0, 0, 0);
                    Instantiate(Горы, new Vector2(i, j), rot);
                }
            }
        }
    }
}
