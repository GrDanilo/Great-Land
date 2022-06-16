using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManageGame : MonoBehaviour
{
    [SerializeField] private List<GameObject> Tribes;
    [SerializeField] private int NowTribe;
    [SerializeField] private GameObject[] TribeObjects;
    [SerializeField] private GameObject[] City;
    private GameObject[] WorldPos;

    public void NewTribe(int TribeID)
    {
        WorldPos = GameObject.FindGameObjectsWithTag("Земля");
        int rand = Random.Range(0, WorldPos.Length);
        Instantiate(TribeObjects[TribeID], WorldPos[rand].transform.position, WorldPos[rand].transform.rotation);
        Instantiate(City[TribeID], WorldPos[rand].transform.position, WorldPos[rand].transform.rotation);
        NowTribe += 1;
        Tribes.Add(TribeObjects[NowTribe]);
    }

    public void NextTribe()
    {
        if(NowTribe <= Tribes.Count)
        {
            Tribes[NowTribe].SetActive(false);
            NowTribe += 1;
            Tribes[NowTribe].SetActive(true);
        }
        else
        {
            Tribes[NowTribe].SetActive(false);
            NowTribe = 0;
            Tribes[NowTribe].SetActive(true);
        }
    }
}
