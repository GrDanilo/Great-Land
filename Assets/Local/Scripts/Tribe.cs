using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tribe : MonoBehaviour
{
    [Header("Ресурсы")]
    public float Деньги;
    public float Население;
    public float Еда;
    public Text ТекстДенег;
    public Text ТекстНаселения;
    public Text ТекстЕды;

    [Header("Племя")]
    [SerializeField] private MyTribe myTribe;
    [SerializeField] private List<GameObject> MyTribeObjects;

    [Header("Города")]
    private List<GameObject> Citys;

    private enum MyTribe
    {
        Империя,
        СОС
    }

    private void Start() 
    {
        Synchronization();
        GameObject[] New = GameObject.FindGameObjectsWithTag("TribeObject");
        for(int i = 0; i < New.Length; i++)
        {
            MyTribeObjects.Add(New[i]);
        }
    }

    public void Synchronization()
    {
        ТекстДенег.text = ": " + Деньги;
        ТекстНаселения.text = ": " + Население;
        ТекстЕды.text = ": " + Еда;
    }

    public void NextMove()
    {
        GameObject[] New = GameObject.FindGameObjectsWithTag("TribeObject");
        for(int i = 0; i < New.Length; i++)
        {
            MyTribeObjects.Add(New[i]);
        }
        for(int i = 0; i < MyTribeObjects.Count; i++)
        {
            MyTribeObjects[i].SetActive(false);
        }
        gameObject.SetActive(false);
    }
    public void NewMove()
    {
        GameObject[] New = GameObject.FindGameObjectsWithTag("TribeObject");
        for(int i = 0; i < New.Length; i++)
        {
            MyTribeObjects.Add(New[i]);
        }
        for(int i = 0; i < MyTribeObjects.Count; i++)
        {
            if(MyTribeObjects[i] != null)
            {
                MyTribeObjects[i].SetActive(true);
            }
        }
    }
}
