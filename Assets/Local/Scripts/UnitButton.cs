using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitButton : MonoBehaviour
{
    [SerializeField] private GameObject ThisButton;
    public WhatIsButton WhatIDo;
    public enum WhatIsButton
    {
        Земля,
        Вода,
        Полёт,
        Атака
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
        }

        if(WhatIDo == WhatIsButton.Атака)
        {
            if (other.CompareTag("Player"))
            {
                ThisButton.SetActive(true);
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
