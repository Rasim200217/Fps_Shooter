using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMotor : MonoBehaviour
{
   private CharacterController _characterController;
   private Vector3 _playerVelocity;
   
   public float speed = 5f;
   public float gravity = -9.8f;
   public float jumpHeight = 3f;
   public float crouchTimer = 5f;

   private bool _isGrounded;
   private bool _lerpCrouch;
   private bool _crouching;
   private bool _sprinting;
   

   private void Start()
   {
      _characterController = GetComponent<CharacterController>();
   }

   private void Update()
   {
      _isGrounded = _characterController.isGrounded;
      
      if (_lerpCrouch)
      {
         crouchTimer += Time.deltaTime;
         float p = crouchTimer / 1;
         p *= p;
         if (_crouching)
            _characterController.height = Mathf.Lerp(_characterController.height, 1, p);
         else
            _characterController.height = Mathf.Lerp(_characterController.height, 2, p);

         if (p > 1)
         {
            _lerpCrouch = false;
            crouchTimer = 0f;
         }

      }
   }

   //получить входные данные для нашего InputManager.cs и применить их к нашему контроллеру персонажей
   public void ProcessMove(Vector2 input)
   {
      Vector3 moveDirection = Vector3.zero;
      moveDirection.x = input.x;
      moveDirection.z = input.y;
      _characterController.Move(transform.TransformDirection(moveDirection) * speed * Time.deltaTime);
      _playerVelocity.y += gravity * Time.deltaTime;
      if (_isGrounded && _playerVelocity.y < 0)
         _playerVelocity.y = -2f;
      _characterController.Move(_playerVelocity * Time.deltaTime);
      Debug.Log(_playerVelocity.y);
   }

   public void Jump()
   {
      if (_isGrounded)
      {
         _playerVelocity.y = Mathf.Sqrt(jumpHeight * -3.0f * gravity);
      }
   }

   public void Crouch()
   {
      _crouching = !_crouching;
      crouchTimer = 0;
      _lerpCrouch = true;
   }

   public void Sprint()
   {
      _sprinting = !_sprinting;
      if(_sprinting)
         speed = 8;
      else
         speed = 5;
   }
}
