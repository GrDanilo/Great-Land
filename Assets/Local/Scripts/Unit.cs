using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    public int MyTeam;

    [Header("Статы")]
    [SerializeField] public float MyHealth;
    [HideInInspector]public float Health;
    [SerializeField] public float MyDamage;
    [HideInInspector]public float Damage;
    [SerializeField] public float MyProtection;
    [HideInInspector]public float Protection;
    [SerializeField] public float MySpeed;

    private void Start() 
    {
        Synchronization();
    }

    private void FixedUpdate() 
    {
        if(Health <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void Synchronization()
    {
        Health = MyHealth;
        Damage = MyDamage;
        Protection = MyProtection;
    }
}
