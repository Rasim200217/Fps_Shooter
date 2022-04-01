using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
   //сообщение, отображаемое игроку при просмотре интерактивного
   public string promptMessage;

   public void BaseInteract()
   {
      Interact();
   }

   protected virtual void Interact()
   {
      //у нас не будет никакого кода, написанного в этой функции
      //это шаблонная функция, которая будет переопределена нашим подклассом

   }
}
