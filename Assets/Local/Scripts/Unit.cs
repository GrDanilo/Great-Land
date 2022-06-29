using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    public int MyTeam;

    [Header("Статы")]
    [SerializeField] private float MyHealth;
    private float Health;
    [SerializeField] private float MyDamage;
    private float Damage;
    [SerializeField] private float MyProtection;
    private float protection;
    [SerializeField] private float MySpeed;

    public void Go(Transform GoTo)
    {
        //transform.position = new Vector3(Mathf.Lerp(transform.position.x, GoTo.position.x, MySpeed * Time.deltaTime), Mathf.Lerp(transform.position.y, GoTo.position.y, MySpeed * Time.deltaTime), transform.position.z);
        transform.position = GoTo.position;
    }
}
