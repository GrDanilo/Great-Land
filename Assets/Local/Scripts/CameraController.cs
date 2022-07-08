using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Camera camera;
    [SerializeField] private GameObject ObjectSlider;
    [SerializeField] private Slider slider;
    private float fill;

    private Vector2 startPos;

    public ControllType Type;
    public enum ControllType
    {
        Сенсор,
        Компьютер
    }

    private void Start() 
    {
        if(Type == ControllType.Компьютер)
        {
            ObjectSlider.SetActive(false);
        }
    }

    void FixedUpdate()
    {
        if(Input.GetMouseButtonDown(0))
        {
            startPos = camera.ScreenToWorldPoint(Input.mousePosition);
        }
        else if(Input.GetMouseButton(0))
        {
            float posX = camera.ScreenToWorldPoint(Input.mousePosition).x - startPos.x;
            float posY = camera.ScreenToWorldPoint(Input.mousePosition).y - startPos.y;
            transform.position = new Vector3(Mathf.Clamp(transform.position.x - posX, -15, 15), Mathf.Clamp(transform.position.y - posY, -15, 15), transform.position.z);
        }

        if(Type == ControllType.Сенсор)
        {
            fill = slider.value;

            if(fill == 0)
            {
                camera.orthographicSize = 0.05f;
            }
            else
            {
                camera.orthographicSize = fill * 5;
            }
        }
        else if(Type == ControllType.Компьютер)
        {
            camera.orthographicSize = Mathf.Clamp(camera.orthographicSize - Input.GetAxis("Mouse ScrollWheel") * 3, 1, 10);
        }
    }
}
