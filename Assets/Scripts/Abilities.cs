using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Abilities : MonoBehaviour
{
    private bool Delay = false;

    [Header("Abilities 0")]
    public Image abilitiesImage0;
    public float cooldown0 = 5f;
    public bool isCooldown0 = false;

    [Header("Abilities 1")]
    public Image abilitiesImage1;
    public float cooldown1 = 15f;
    public bool isCooldown1 = false;

    [Header("Abilities 2")]
    public Image abilitiesImage2;
    public float cooldown2 = 10f;
    public bool isCooldown2 = false;

    [Header("Abilities 3")]
    public Image abilitiesImage3;
    public float cooldown3 = 8f;
    public bool isCooldown3 = false;

    [Header("Abilities 4")]
    public Image abilitiesImage4;
    public float cooldown4 = 9f;
    public bool isCooldown4 = false;

    [Header("Abilities 5")]
    public Image abilitiesImage5;
    public float cooldown5 = 8f;
    public bool isCooldown5 = false;
    public LoadImage load;
    // Start is called before the first frame update
    void Start()
    {

        load = FindObjectOfType<LoadImage>();
        LoadImage(load);
        abilitiesImage0.fillAmount = 0f;
        abilitiesImage1.fillAmount = 0f;
        abilitiesImage2.fillAmount = 0f;
        abilitiesImage3.fillAmount = 0f;
        abilitiesImage4.fillAmount = 0f;
        abilitiesImage5.fillAmount = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        Abilities0();
        Abilities1();
        Abilities2();
        Abilities3();
        Abilities4();
        Abilities5();
    }

    void Abilities0()
    {
        if(PlayerMovement.instance.characterController.isGrounded && PlayerMovement.instance.isSprint == true && isCooldown0 == false)
        {
            if(Delay == false)
            {
                PlayerMovement.instance.Sprint = 4f;
                StartCoroutine(DelaySprint(3f));
                abilitiesImage0.fillAmount = 1;
            }
        }
       
        if (isCooldown0 && Delay == true)
        {
            PlayerMovement.instance.isSprint = false;
            PlayerMovement.instance.Sprint = 1f;
            abilitiesImage0.fillAmount -= 1 / cooldown0 * Time.deltaTime;
            if (abilitiesImage0.fillAmount <= 0)
            {
                abilitiesImage0.fillAmount = 0f;
                isCooldown0 = false;
                Delay = false;
            }
        }
    }

    void Abilities1()
    {
        if (PlayerMovement.instance.characterController.isGrounded && Input.GetKeyDown(KeyCode.Q) && isCooldown1 == false)
        {
            SwordAttack.instance.SwordAirAttack();
            PlayerMovement.instance.moveSpeed = 0f;
            PlayerMovement.instance.animator.SetTrigger("SwordAir");
            isCooldown1 = true;
            abilitiesImage1.fillAmount = 1;
            StartCoroutine(DelayMove(3f));
        }

        if (isCooldown1)
        {
            abilitiesImage1.fillAmount -= 1 / cooldown1 * Time.deltaTime;
            if (abilitiesImage1.fillAmount <= 0)
            {
                abilitiesImage1.fillAmount = 0f;
                isCooldown1 = false;
            }
        }
    }

    void Abilities2()
    {
        if (Input.GetKeyDown(KeyCode.E) && isCooldown2 == false)
        {
            SpawnShield.instance.spawnShied();
            playerManager.instance.Player.GetComponent<PlayerStats>().armor += 10f;
            isCooldown2 = true;
            abilitiesImage2.fillAmount = 1;
        }

        if (isCooldown2)
        {
            abilitiesImage2.fillAmount -= 1 / cooldown2 * Time.deltaTime;
            if (abilitiesImage2.fillAmount <= 0)
            {
                playerManager.instance.Player.GetComponent<PlayerStats>().armor -= 10f;
                abilitiesImage2.fillAmount = 0f;
                isCooldown2 = false;
            }
        }
    }

    void Abilities3()
    {
        if (PlayerMovement.instance.characterController.isGrounded && Input.GetKeyDown(KeyCode.R) && isCooldown3 == false)
        {
            SwordAttack.instance.TornadoAttack();
            PlayerMovement.instance.moveSpeed = 0f;
            PlayerMovement.instance.animator.SetTrigger("Tornado");
            isCooldown3 = true;
            abilitiesImage3.fillAmount = 1;
            StartCoroutine(DelayMove(3f));
        }

        if (isCooldown3)
        {
            abilitiesImage3.fillAmount -= 1 / cooldown3 * Time.deltaTime;
            if (abilitiesImage3.fillAmount <= 0)
            {
                abilitiesImage3.fillAmount = 0f;
                isCooldown3 = false;
            }
        }
    }

    void Abilities4()
    {
        if (PlayerMovement.instance.characterController.isGrounded && Input.GetKeyDown(KeyCode.T) && isCooldown4 == false)
        {
            SwordAttack.instance.WaveFireAttack();
            PlayerMovement.instance.moveSpeed = 0f;
            PlayerMovement.instance.animator.SetTrigger("Wave");
            isCooldown4 = true;
            abilitiesImage4.fillAmount = 1;
            StartCoroutine(DelayMove(2.5f));
        }

        if (isCooldown4)
        {
            abilitiesImage4.fillAmount -= 1 / cooldown4 * Time.deltaTime;
            if (abilitiesImage4.fillAmount <= 0)
            {
                abilitiesImage4.fillAmount = 0f;
                isCooldown4 = false;
            }
        }
    }

    void Abilities5()
    {
        if (PlayerMovement.instance.characterController.isGrounded && Input.GetKeyDown(KeyCode.F) && isCooldown5 == false)
        {
            SwordAttack.instance.BirdLightAttack();
            PlayerMovement.instance.moveSpeed = 0f;
            PlayerMovement.instance.animator.SetTrigger("BirdLight");
            isCooldown5 = true;
            abilitiesImage5.fillAmount = 1;
            StartCoroutine(DelayMove(1f));
        }

        if (isCooldown5)
        {
            abilitiesImage5.fillAmount -= 1 / cooldown5 * Time.deltaTime;
            if (abilitiesImage5.fillAmount <= 0)
            {
                abilitiesImage5.fillAmount = 0f;
                isCooldown5 = false;
            }
        }
    }

    IEnumerator DelayMove(float delay)
    {
        yield return new WaitForSeconds(delay);
        PlayerMovement.instance.moveSpeed = 5f;
    }

    IEnumerator DelaySprint(float delay)
    {
        yield return new WaitForSeconds(delay);
        isCooldown0 = true;
        Delay = true;
    }
    public void LoadImage(LoadImage loadImage)
    {
        Debug.Log("Hello");
        abilitiesImage0 = loadImage.images[0];
        abilitiesImage1 = loadImage.images[1];
        abilitiesImage2 = loadImage.images[2];
        abilitiesImage3 = loadImage.images[3];
        abilitiesImage4 = loadImage.images[4];
        abilitiesImage5 = loadImage.images[5];
    }

}
