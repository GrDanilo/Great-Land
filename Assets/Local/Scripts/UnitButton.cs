using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitButton : MonoBehaviour //Пипец какой-то, а не скрипт!
{
    [SerializeField] private int MyUnitTeam;
    [SerializeField] private GameObject MyUnit;
    [SerializeField] private Unit MyUnitScript;

    private Vector3 FinalGo;
    private Vector3 PreFinalGo;

    private string WhatUnit;
    private Unit UnitScript;
    private GameObject Unit;

    [SerializeField] private GameObject ThisButton;
    [SerializeField] private GameObject[] AllButtons;
    public WhatIsButton WhatIDo;
    public enum WhatIsButton
    {
        Земля,
        Вода,
        Полёт,
        Атака
    }

    public void Attack(Transform GoTo)
    {
        FinalGo = GoTo.position;
        PreFinalGo = MyUnit.transform.position;

        MyUnitScript.Damage = MyUnitScript.MyDamage * (MyUnitScript.Health / MyUnitScript.MyHealth);
        MyUnitScript.Damage = Mathf.Round(MyUnitScript.Damage);
        MyUnitScript.Damage = Mathf.Clamp(MyUnitScript.Damage, 0, 99);
        UnitScript.Health -= MyUnitScript.Damage; Debug.Log("Урон = " + MyUnitScript.Damage);

        UnitScript.Damage = UnitScript.MyDamage * (((UnitScript.Health / UnitScript.MyHealth) * UnitScript.Protection) - MyUnitScript.Protection);
        UnitScript.Damage = Mathf.Round(UnitScript.Damage);
        UnitScript.Damage = Mathf.Clamp(UnitScript.Damage, 0, 99);
        if(UnitScript.Health > 0)
        {
            StartCoroutine(AttackCour(GoTo));
        }
        else
        {
            StartCoroutine(KillCour(GoTo));
        }
        MyUnitScript.Health -= UnitScript.Damage; Debug.Log("Возврат = " + UnitScript.Damage);
    }
    IEnumerator AttackCour(Transform GoTo)
    {
        while (MyUnit.transform.position.x != FinalGo.x || MyUnit.transform.position.y != FinalGo.y)
        {
            yield return new WaitForSeconds(Time.deltaTime);
            MyUnit.transform.position = Vector3.MoveTowards(MyUnit.transform.position, FinalGo, MyUnitScript.MySpeed * Time.deltaTime * 3);
        }
        while (MyUnit.transform.position.x != PreFinalGo.x || MyUnit.transform.position.y != PreFinalGo.y)
        {
            yield return new WaitForSeconds(Time.deltaTime);
            MyUnit.transform.position = Vector3.MoveTowards(MyUnit.transform.position, PreFinalGo, MyUnitScript.MySpeed * Time.deltaTime * 3);
        }
    }
    IEnumerator KillCour(Transform GoTo)
    {
        while (MyUnit.transform.position.x != FinalGo.x || MyUnit.transform.position.y != FinalGo.y)
        {
            yield return new WaitForSeconds(Time.deltaTime);
            MyUnit.transform.position = Vector3.MoveTowards(MyUnit.transform.position, FinalGo, MyUnitScript.MySpeed * Time.deltaTime * 3);
        }
    }

    public void Go(Transform GoTo)
    {
        FinalGo = GoTo.position;
        StartCoroutine(GoCour(GoTo));
    }
    IEnumerator GoCour(Transform GoTo)
    {
        while (MyUnit.transform.position.x != FinalGo.x || MyUnit.transform.position.y != FinalGo.y)
        {
            yield return new WaitForSeconds(Time.deltaTime);
            MyUnit.transform.position = Vector3.MoveTowards(MyUnit.transform.position, FinalGo, MyUnitScript.MySpeed * Time.deltaTime);
        }
    }

    private void OnTriggerStay2D(Collider2D other) 
    {
        if (other.CompareTag("Пустота"))
        {
            ThisButton.SetActive(false);
        }

        if(WhatIDo == WhatIsButton.Земля)
        {
            if (other.CompareTag("Океан"))
            {
                ThisButton.SetActive(false);
            }
            if (other.CompareTag("Мелководье"))
            {
                ThisButton.SetActive(false);
            }
            if (other.CompareTag("Пустыня"))
            {
                ThisButton.SetActive(true);
            }
            if (other.CompareTag("Земля"))
            {
                ThisButton.SetActive(true);
            }
            if (other.CompareTag("Лес"))
            {
                ThisButton.SetActive(true);
            }
            if (other.CompareTag("Горы"))
            {
                ThisButton.SetActive(true);
            }

            if (other.CompareTag("Player"))
            {
                ThisButton.SetActive(false);
            }
        }

        if(WhatIDo == WhatIsButton.Вода)
        {
            if (other.CompareTag("Океан"))
            {
                ThisButton.SetActive(true);
            }
            if (other.CompareTag("Мелководье"))
            {
                ThisButton.SetActive(true);
            }
            if (other.CompareTag("Пустыня"))
            {
                ThisButton.SetActive(false);
            }
            if (other.CompareTag("Земля"))
            {
                ThisButton.SetActive(false);
            }
            if (other.CompareTag("Лес"))
            {
                ThisButton.SetActive(false);
            }
            if (other.CompareTag("Горы"))
            {
                ThisButton.SetActive(false);
            }

            if (other.CompareTag("Player"))
            {
                ThisButton.SetActive(false);
            }
        }

        if(WhatIDo == WhatIsButton.Полёт)
        {
            if (other.CompareTag("Океан"))
            {
                ThisButton.SetActive(true);
            }
            if (other.CompareTag("Мелководье"))
            {
                ThisButton.SetActive(true);
            }
            if (other.CompareTag("Пустыня"))
            {
                ThisButton.SetActive(true);
            }
            if (other.CompareTag("Земля"))
            {
                ThisButton.SetActive(true);
            }
            if (other.CompareTag("Лес"))
            {
                ThisButton.SetActive(true);
            }
            if (other.CompareTag("Горы"))
            {
                ThisButton.SetActive(true);
            }

            if (other.CompareTag("Player"))
            {
                ThisButton.SetActive(false);
            }
        }

        if(WhatIDo == WhatIsButton.Атака)
        {
            if (other.CompareTag("Player"))
            {
                WhatUnit = other.name;
                Unit = GameObject.Find(WhatUnit);
                UnitScript = Unit.GetComponent("Unit") as Unit;

                if(MyUnitTeam != UnitScript.MyTeam)
                {
                    ThisButton.SetActive(true);
                }
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other) 
    {
        if (other.CompareTag("Пустота"))
        {
            ThisButton.SetActive(true);
        }

        if(WhatIDo == WhatIsButton.Атака)
        {
            if (other.CompareTag("Player"))
            {
                ThisButton.SetActive(false);
            }
        }
    }
}