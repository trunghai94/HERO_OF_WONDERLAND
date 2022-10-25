using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 5f;
    [SerializeField]
    private float jump = 0;

    private Transform cam;
    private float gravity = 9.81f;
    private float verticalVelocity = 10f;
    private CharacterController characterController;
    private Animator animator;
    private float Sprint = 1f;
    private bool Delay = false;

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
        if(isSprint == true)
        {
            if(Delay == false)
            {
                Sprint = 4f;
                StartCoroutine(DelaySprint());
            }
            else
            {
                isSprint = false;
                Sprint = 1f;
                StartCoroutine(PlaySprint());
            }
        }
        else
        {
            Sprint = 1f;
        }
        //float sprint = isSprint ? 3f : 1f;
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
        moveDirection = new Vector3(moveDirection.x * moveSpeed * Sprint, verticalVelocity, moveDirection.z * moveSpeed * Sprint);
        characterController.Move(moveDirection * Time.deltaTime);
    }

    private void CharacterSkill()
    {
        if (characterController.isGrounded && Input.GetKeyDown(KeyCode.Q))
        {
            moveSpeed = 0f;
            animator.SetTrigger("SwordAir");
            SwordAttack.instance.SwordAirAttack();
            StartCoroutine(DelayMove());
        }
        if (characterController.isGrounded && Input.GetKeyDown(KeyCode.E))
        {
            SpawnShield.instance.spawnShied();
        }
        if (characterController.isGrounded && Input.GetKeyDown(KeyCode.R))
        {
            animator.SetTrigger("Tornado");
            SwordAttack.instance.TornadoAttack();
            StartCoroutine(DelayMove());
        }
    }

    IEnumerator DelaySprint()
    {
        yield return new WaitForSeconds(3f);
        Delay = true;
    }

    IEnumerator PlaySprint()
    {
        yield return new WaitForSeconds(5f);
        Delay = false;
    }

    IEnumerator DelayMove()
    {
        yield return new WaitForSeconds(3f);
        moveSpeed = 5f;
    }
}
