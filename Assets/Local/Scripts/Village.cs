using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Village : MonoBehaviour
{
    private string WhatUnit;
    private Unit UnitSctipt;
    private GameObject Unit;
    [SerializeField] private GameObject CaptureButton;
    [SerializeField] private GameObject[] Citys;

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.CompareTag("City"))
        {
            Destroy(gameObject);
        }

        if(other.CompareTag("Player"))
        {
            CaptureButton.SetActive(true);
            WhatUnit = other.name;
        }
    }
    private void OnTriggerExit2D(Collider2D other) 
    {
        if(other.CompareTag("Player"))
        {
            CaptureButton.SetActive(false);
        }
    }

    public void Capture()
    {
        Unit = GameObject.Find(WhatUnit);
        UnitSctipt = Unit.GetComponent("Unit") as Unit;
        Instantiate(Citys[UnitSctipt.MyTeam], transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
