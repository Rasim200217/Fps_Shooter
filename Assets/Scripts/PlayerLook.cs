using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    public Camera camera;
    private float xRotation = 0f;

    public float xSensitivity = 30f;
    public float ySensitivity = 30f;

    public void ProcessLook(Vector2 input)
    {
        float mouseX = input.x;
        float mouseY = input.y;
        //рассчитать вращение камеры для взгляда вверх и вниз
        xRotation -= (mouseY * Time.deltaTime) * ySensitivity;
        xRotation = Mathf.Clamp(xRotation, -80f, 80f);
        //примените это к нашему преобразованию камеры
        camera.transform.localRotation = Quaternion.Euler(xRotation, 0,0);
        //поверните игрока, чтобы посмотреть влево и вправо
        transform.Rotate(Vector2.up * (mouseX * Time.deltaTime) * xSensitivity);
    }
}
