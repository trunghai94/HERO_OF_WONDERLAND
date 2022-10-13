using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 1f;
    [SerializeField]
    private float jump = 0;

    private Transform cam;
    private float gravity = 9.81f;
    private float verticalVelocity = 10f;
    private CharacterController characterController;
    private Animator animator;

    
    public bool isSprint;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
        cam = Camera.main.transform;
    }

    // Update is called once per frame
    void Update()
    {
        CharacterMove();
        CharacterSkill();
    }

    private void CharacterMove()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        isSprint = Input.GetKey(KeyCode.LeftShift);
        float sprint = isSprint ? 3f : 1f;
        animator.SetBool("isSprint", isSprint);

        Vector3 moveDirection = new Vector3(horizontalInput, 0, verticalInput);
        animator.SetFloat("InputX", horizontalInput);
        animator.SetFloat("InputY", verticalInput);

        if (characterController.isGrounded)
        {
            animator.SetBool("isJump", false);
            if (Input.GetAxis("Jump") > 0)
            {
                verticalVelocity = jump;
                animator.SetBool("isJump", true);
            }
        }
        else
        {
            verticalVelocity -= gravity * Time.deltaTime;
        }

        moveDirection = cam.TransformDirection(moveDirection);
        moveDirection = new Vector3(moveDirection.x * moveSpeed * sprint, verticalVelocity, moveDirection.z * moveSpeed * sprint);
        characterController.Move(moveDirection * Time.deltaTime);
    }

    private void CharacterSkill()
    {
        if (characterController.isGrounded && Input.GetKeyDown(KeyCode.Q))
        {
            animator.SetTrigger("SwordAir");
            SwordAttack.instance.SwordAirAttack();
        }
        if (characterController.isGrounded && Input.GetKeyDown(KeyCode.E))
        {
            SpawnShield.instance.spawnShied();
        }
    }
}
