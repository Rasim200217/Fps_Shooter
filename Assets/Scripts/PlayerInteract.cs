using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    private Camera _camera;

   [SerializeField] private float _distance = 3f;
   [SerializeField] private LayerMask _mask;
    private void Start()
    {
        _camera = GetComponent<PlayerLook>().camera;
    }

    private void Update()
    {
        //создать луч в центре камеры, направленный наружу
        Ray ray = new Ray(_camera.transform.position, _camera.transform.forward);
        RaycastHit hitInfo; // переменная для хранения информации о столкновении
        if (Physics.Raycast(ray, out hitInfo, _distance, _mask))
        {
            if (hitInfo.collider.GetComponent<Interactable>() != null)
            {
                Debug.Log(hitInfo.collider.GetComponent<Interactable>().promptMessage);
            }
        }
    }
}
