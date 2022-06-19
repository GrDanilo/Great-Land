using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class City : MonoBehaviour
{
    [SerializeField] private Transform MyPosition;
    private float UnitCost;
    private Tribe TribeScript;

    public void UnitsDonate(float Cost)
    {
        UnitCost = Cost;
        Debug.Log("Цена установлена");
    }
    public void SpawnUnit(GameObject Unit)
    {
        Debug.Log("Проверка на деньги");
        if(TribeScript.Деньги >= UnitCost)
        {
            Debug.Log("Спавн юнита");
            Instantiate(Unit, MyPosition.position, MyPosition.rotation);
            Debug.Log("Юнит заспавнен");
            TribeScript.Деньги -= UnitCost;
            Debug.Log("Деньги отобраны");
        }
    }
}
