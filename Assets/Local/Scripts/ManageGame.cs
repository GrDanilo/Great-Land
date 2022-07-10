using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManageGame : MonoBehaviour
{
    [SerializeField] private List<GameObject> Tribes;
    [SerializeField] private int NowTribe;
    private Tribe NowTribeScript;
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
            NowTribeScript = Tribes[NowTribe - 1].GetComponent("Tribe") as Tribe;
            NowTribeScript.NextMove();
            /*GameObject[] News = GameObject.FindGameObjectsWithTag("TribeObject");
            for(int i = 0; i < News.Length; i++)
            {
                News[i].SetActive(false);
            }
            Tribes[NowTribe - 1].SetActive(false);*/
        }
        Instantiate(TribeObjects[TribeID], WorldPos[rand].transform.position, WorldPos[rand].transform.rotation);
        Instantiate(City[TribeID], WorldPos[rand].transform.position, WorldPos[rand].transform.rotation);
        GameObject New = GameObject.FindWithTag("GameController");
        Tribes.Add(New);
        NowTribe = Tribes.Count;
    }

    public void NextTribe()
    {
        if(NowTribe < Tribes.Count)
        {
            /*GameObject[] New = GameObject.FindGameObjectsWithTag("TribeObject");
            for(int i = 0; i < New.Length; i++)
            {
                New[i].SetActive(false);
            }
            Tribes[NowTribe - 1].SetActive(false);
            NowTribe += 1;
            Tribes[NowTribe - 1].SetActive(true);*/
            NowTribeScript = Tribes[NowTribe - 1].GetComponent("Tribe") as Tribe;
            NowTribeScript.NextMove();
            NowTribe += 1;
            Tribes[NowTribe - 1].SetActive(true);
            NowTribeScript = Tribes[NowTribe - 1].GetComponent("Tribe") as Tribe;
            NowTribeScript.NewMove();
        }
        else
        {
            /*GameObject[] New = GameObject.FindGameObjectsWithTag("TribeObject");
            for(int i = 0; i < New.Length; i++)
            {
                New[i].SetActive(false);
            }
            Tribes[NowTribe - 1].SetActive(false);
            NowTribe = 1;
            Tribes[NowTribe - 1].SetActive(true);*/
            NowTribeScript = Tribes[NowTribe - 1].GetComponent("Tribe") as Tribe;
            NowTribeScript.NextMove();
            NowTribe = 1;
            Tribes[NowTribe - 1].SetActive(true);
            NowTribeScript = Tribes[NowTribe - 1].GetComponent("Tribe") as Tribe;
            NowTribeScript.NewMove();
        }
    }
}
