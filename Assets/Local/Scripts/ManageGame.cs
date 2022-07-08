using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManageGame : MonoBehaviour
{
    [SerializeField] private List<GameObject> Tribes;
    [SerializeField] private int NowTribe;
    //private Tribe NowTribeScript;
    [SerializeField] private GameObject[] TribeObjects;
    [SerializeField] private GameObject[] City;
    private GameObject[] WorldPos;

    public void NewTribe(int TribeID)
    {
        WorldPos = GameObject.FindGameObjectsWithTag("Земля");
        int rand = Random.Range(0, WorldPos.Length);
        NowTribe = Tribes.Count;
        if(NowTribe > 0)
        {
            Tribes[NowTribe - 1].SetActive(false);
        }
        Instantiate(TribeObjects[TribeID], WorldPos[rand].transform.position, WorldPos[rand].transform.rotation);
        Instantiate(City[TribeID], WorldPos[rand].transform.position, WorldPos[rand].transform.rotation);
        //NowTribeScript = Tribes[NowTribe - 1].GetComponent("Tribe") as Tribe;
        //NowTribeScript.NextMove();
        GameObject New = GameObject.FindWithTag("GameController");
        Tribes.Add(New);
    }

    public void NextTribe()
    {
        if(NowTribe < Tribes.Count)
        {
            Tribes[NowTribe - 1].SetActive(false);
            NowTribe += 1;
            Tribes[NowTribe - 1].SetActive(true);
        }
        else
        {
            Tribes[NowTribe - 1].SetActive(false);
            NowTribe = 1;
            Tribes[NowTribe - 1].SetActive(true);
        }
    }
}
