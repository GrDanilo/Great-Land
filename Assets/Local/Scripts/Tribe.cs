using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tribe : MonoBehaviour
{
    [Header("Ресурсы")]
    public float Деньги;
    public float Население;
    public float Еда;
    public Text ТекстДенег;
    public Text ТекстНаселения;
    public Text ТекстЕды;

    [Header("Племя")]
    [SerializeField] private MyTribe myTribe;

    [Header("Города")]
    private List<GameObject> Citys;

    private enum MyTribe
    {
        Империя,
        СОС
    }

    public void Synchronization()
    {
        ТекстДенег.text = ": " + Деньги;
        ТекстНаселения.text = ": " + Население;
        ТекстЕды.text = ": " + Еда;
    }
}
