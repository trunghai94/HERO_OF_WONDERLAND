using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerMovement : MonoBehaviour
{
    public static PlayerMovement instance;
    [SerializeField]
    private float moveSpeed = 0f;
    [SerializeField]
    private float jump = 0f;

    private Transform cam;
    private float gravity = 9.81f;
    private float verticalVelocity = 10f;
    private CharacterController characterController;
    private ManagerWeaponChange mngrWeaponChange;
    private CharacterAiming aiming;
    private Animator animator;
    private PlayerStats stat;
    private float Sprint = 1f;
    private bool Delay = false;
    private bool ShiedDelay = true;
    private bool SwordAirDelay = true;
    private bool TornadoDelay = true;
    private bool WaveDelay = true;
    private bool BirdLightDelay = true;

    public int indexWeapons = 0;
    public bool isSprint;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
        mngrWeaponChange = GetComponent<ManagerWeaponChange>();
        aiming = GetComponent<CharacterAiming>();
        animator = GetComponent<Animator>();
        stat = GetComponent<PlayerStats>();
        cam = Camera.main.transform;
        animator.fireEvents = false;
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        CharacterMove();
        CharacterSkill();
        ChangeWeapons();
    }

    private void CharacterMove()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        Vector3 moveDirection = new Vector3(horizontalInput, 0, verticalInput);
        animator.SetFloat("InputX", horizontalInput);
        animator.SetFloat("InputY", verticalInput);

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

        if (characterController.isGrounded)
        {
            animator.SetBool("isJump", false);
            if (Input.GetAxis("Jump") != 0)
            {
                verticalVelocity = jump;
                animator.SetBool("isJump", true);
            }
        }
        else
        {
            verticalVelocity -= gravity * Time.deltaTime;
        }
        
        if (stat.currentHeath <= 0)
        {
            aiming.enabled = false;
            moveSpeed = 0f;
        }

        moveDirection = cam.TransformDirection(moveDirection);
        moveDirection = new Vector3(moveDirection.x * moveSpeed * Sprint, verticalVelocity, moveDirection.z * moveSpeed * Sprint);
        characterController.Move(moveDirection * Time.deltaTime);
    }

    private void ChangeWeapons()
    {
        mngrWeaponChange.ChangeWeapon(indexWeapons);
        if(playerManager.instance.Player.GetComponent<PlayerStats>().level == 5)
        {
            mngrWeaponChange.ChangeWeapon(indexWeapons = 1);
        }
        if (playerManager.instance.Player.GetComponent<PlayerStats>().level == 10)
        {
            mngrWeaponChange.ChangeWeapon(indexWeapons = 2);
        }
        if (playerManager.instance.Player.GetComponent<PlayerStats>().level == 15)
        {
            mngrWeaponChange.ChangeWeapon(indexWeapons = 3);
        }
    }

    private void CharacterSkill()
    {
        if (characterController.isGrounded && Input.GetKeyDown(KeyCode.Q))
        {
            if(SwordAirDelay == true)
            {
                SwordAirDelay = false;
                moveSpeed = 0f;
                animator.SetTrigger("SwordAir");
                SwordAttack.instance.SwordAirAttack();
                StartCoroutine(DelayMove(3f));
            }
        }
        if (characterController.isGrounded && Input.GetKeyDown(KeyCode.E))
        {
            if(ShiedDelay == true)
            {
                ShiedDelay = false;
                SpawnShield.instance.spawnShied();
                playerManager.instance.Player.GetComponent<PlayerStats>().armor += 10f;
                StartCoroutine(RemoveArmor());
            }
        }
        if (characterController.isGrounded && Input.GetKeyDown(KeyCode.R))
        {
            if(TornadoDelay == true)
            {
                TornadoDelay = false;
                moveSpeed = 0f;
                animator.SetTrigger("Tornado");
                SwordAttack.instance.TornadoAttack();
                StartCoroutine(DelayMove(3f));
            }
        }
        if (characterController.isGrounded && Input.GetKeyDown(KeyCode.T))
        {
            if(WaveDelay == true)
            {
                WaveDelay = false;
                moveSpeed = 0f;
                animator.SetTrigger("Wave");
                SwordAttack.instance.WaveFireAttack();
                StartCoroutine(DelayMove(3.5f));
            }
        }
        if (characterController.isGrounded && Input.GetKeyDown(KeyCode.F))
        {
            if(BirdLightDelay == true)
            {
                BirdLightDelay = false;
                moveSpeed = 0f;
                animator.SetTrigger("BirdLight");
                SwordAttack.instance.BirdLightAttack();
                StartCoroutine(DelayMove(1f));
            }
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

    IEnumerator DelayMove(float delay)
    {
        yield return new WaitForSeconds(delay);
        moveSpeed = 5f;
        if(SwordAirDelay == false)
        {
            StartCoroutine(DelaySwordAir(8f));
        }
        if(TornadoDelay == false)
        {
            StartCoroutine(DelayTornado(5f));
        }
        if(WaveDelay == false)
        {
            StartCoroutine(DelayWave(6f));
        }
        if(BirdLightDelay == false)
        {
            StartCoroutine(DelayBirdLight(7f));
        }
    }

    IEnumerator DelayShied()
    {
        yield return new WaitForSeconds(5f);
        ShiedDelay = true;
    }

    IEnumerator DelaySwordAir(float delay)
    {
        yield return new WaitForSeconds(delay);
        SwordAirDelay = true;
    }

    IEnumerator DelayTornado(float delay)
    {
        yield return new WaitForSeconds(delay);
        TornadoDelay = true;
    }

    IEnumerator DelayWave(float delay)
    {
        yield return new WaitForSeconds(delay);
        WaveDelay = true;
    }

    IEnumerator DelayBirdLight(float delay)
    {
        yield return new WaitForSeconds(delay);
        BirdLightDelay = true;
    }
    IEnumerator RemoveArmor()
    {
        yield return new WaitForSeconds(6f);
        playerManager.instance.Player.GetComponent<PlayerStats>().armor -= 10f;
        StartCoroutine(DelayShied());
    }
}
