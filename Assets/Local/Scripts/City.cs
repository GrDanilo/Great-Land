using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class City : MonoBehaviour
{
    [SerializeField] private Transform MyPosition;
    private float UnitCost;
    private Tribe TribeScript;

    private void Start() 
    {
        GameObject tribe = GameObject.FindWithTag("GameController");
        TribeScript = tribe.GetComponent("Tribe") as Tribe;
    }

    public void UnitsDonate(float Cost)
    {
        UnitCost = Cost;
    }
    public void SpawnUnit(GameObject Unit)
    {
        if(TribeScript.Деньги >= UnitCost)
        {
            Instantiate(Unit, MyPosition.position, MyPosition.rotation);
            TribeScript.Деньги -= UnitCost;
            TribeScript.Synchronization();
        }
    }
}
