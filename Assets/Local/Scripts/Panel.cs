using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Panel : MonoBehaviour
{
    [SerializeField] private bool IcanSpawnVillage;
    [SerializeField] private GameObject Деревня;
    [SerializeField] private LayerMask PanelsLayer;
    [SerializeField] private Vector2 MyRange;

    private void Start() 
    {
        if(IcanSpawnVillage == true)
        {
            int rand = Random.Range(0, 100);
            if(rand <= 4)
            {
                Collider2D[] Coll = Physics2D.OverlapBoxAll(transform.position, MyRange, PanelsLayer);
                for(int i = 0; i < Coll.Length; i++)
                {
                    GameObject Panels = GameObject.Find(Coll[i].name);
                    Panel Script = Panels.GetComponent("Panel") as Panel;
                    if(Script != null)
                    {
                        Script.IcanSpawnVillage = false;
                    }
                }
                Instantiate(Деревня, transform.position, transform.rotation);
            }
        }
    }
}
