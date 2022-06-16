using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Village : MonoBehaviour
{
    [SerializeField] private GameObject CaptureButton;

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.CompareTag("City"))
        {
            Destroy(gameObject);
        }

        if(other.CompareTag("Player"))
        {
            CaptureButton.SetActive(true);
        }
    }
    private void OnTriggerExit2D(Collider2D other) 
    {
        if(other.CompareTag("Player"))
        {
            CaptureButton.SetActive(false);
        }
    }
}
