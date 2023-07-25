using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
   public float moveSpeed = 5f;

   public float rollBoost = 2f;
   private float rollTime;
   public float RollTime;
   private bool rollOnce = false;

   private Rigidbody2D rb;
   public Animator animator;
   public SpriteRenderer character;
      
   
   public Vector3 moveInput;

   public void Start()
   {
      animator = GetComponent<Animator>();
   }

   private void Update()
   {
      moveInput.x = Input.GetAxis("Horizontal");
      moveInput.y = Input.GetAxis("Vertical");
      transform.position += moveInput * moveSpeed * Time.deltaTime;

      animator.SetFloat("Speed", moveInput.sqrMagnitude);
      if (Input.GetKeyDown(KeyCode.Space) && rollTime <= 0)
      {
         animator.SetBool("Roll", true);
         moveSpeed += rollBoost;
         rollTime = RollTime;
         rollOnce = true;
      }

      if (rollTime <= 0 && rollOnce == true)
      {
         moveSpeed -= rollBoost;
         animator.SetBool("Roll", false);
         rollOnce = false;
      }
      else
      {
         rollTime -= Time.deltaTime;
      }

      if (moveInput.x != 0)
      {
         if (moveInput.x > 0)
            character.transform.localScale = new Vector3(1, 1, 1);
         else
            character.transform.localScale = new Vector3(-1, 1, 1);
      }
   }

}
