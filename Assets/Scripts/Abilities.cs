using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Abilities : MonoBehaviour
{
    private MeshTrailTut MeshTrail;
    private bool Delay = false;

    [Header("Abilities 0")]
    public Image abilitiesImage0;
    public float cooldown0 = 5f;
    public bool isCooldown0 = false;

    [Header("Abilities 1")]
    public Image abilitiesImage1;
    public Image blockImg1;
    public float cooldown1 = 15f;
    public bool isCooldown1 = false;

    [Header("Abilities 2")]
    public Image abilitiesImage2;
    public Image blockImg2;
    public float cooldown2 = 10f;
    public bool isCooldown2 = false;

    [Header("Abilities 3")]
    public Image abilitiesImage3;
    public Image blockImg3;
    public float cooldown3 = 8f;
    public bool isCooldown3 = false;

    [Header("Abilities 4")]
    public Image abilitiesImage4;
    public Image blockImg4;
    public float cooldown4 = 9f;
    public bool isCooldown4 = false;

    [Header("Abilities 5")]
    public Image abilitiesImage5;
    public Image blockImg5;
    public float cooldown5 = 8f;
    public bool isCooldown5 = false;

    // Start is called before the first frame update
    void Start()
    {
        MeshTrail = GetComponent<MeshTrailTut>();
        LoadImage();
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
        if(PlayerMovement.instance.characterController.isGrounded && isCooldown0 == false)
        {
            if(Delay == false)
            {
                if(PlayerMovement.instance.isSprint == true)
                {
                    PlayerMovement.instance.Sprint = 4f;
                    StartCoroutine(DelaySprint(3f));
                    abilitiesImage0.fillAmount = 1;
                }
                else PlayerMovement.instance.Sprint = 1f;

            }
        }
       
        if (isCooldown0 && Delay == true)
        {
            MeshTrail.enabled = false;
            PlayerMovement.instance.isSprint = false;
            PlayerMovement.instance.Sprint = 1f;
            abilitiesImage0.fillAmount -= 1 / cooldown0 * Time.deltaTime;
            if (abilitiesImage0.fillAmount <= 0)
            {
                abilitiesImage0.fillAmount = 0f;
                isCooldown0 = false;
                Delay = false;
                MeshTrail.enabled = true;
            }
        }
    }

    void Abilities1()
    {
        if(playerManager.instance.Player.GetComponent<PlayerStats>().level >= 5)
        {
            blockImg1.GetComponent<Image>().enabled = false;
            blockImg1.GetComponentInChildren<TMP_Text>().enabled = false;
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
    }

    void Abilities2()
    {
        if(playerManager.instance.Player.GetComponent<PlayerStats>().level >= 10)
        {
            blockImg2.GetComponent<Image>().enabled = false;
            blockImg2.GetComponentInChildren<TMP_Text>().enabled = false;
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
    }

    void Abilities3()
    {
        if (playerManager.instance.Player.GetComponent<PlayerStats>().level >= 15)
        {
            blockImg3.GetComponent<Image>().enabled = false;
            blockImg3.GetComponentInChildren<TMP_Text>().enabled = false;
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
    }

    void Abilities4()
    {
        if (playerManager.instance.Player.GetComponent<PlayerStats>().level >= 20)
        {
            blockImg4.GetComponent<Image>().enabled = false;
            blockImg4.GetComponentInChildren<TMP_Text>().enabled = false;
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
    }

    void Abilities5()
    {
        if (playerManager.instance.Player.GetComponent<PlayerStats>().level >= 25)
        {
            blockImg5.GetComponent<Image>().enabled = false;
            blockImg5.GetComponentInChildren<TMP_Text>().enabled = false;
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
    void LoadImage()
    {
        Debug.Log("heel");
        if(abilitiesImage0 == null) abilitiesImage0 = MainUIManager.Instance.skillImg[0];
        if (abilitiesImage1 == null) abilitiesImage1 = MainUIManager.Instance.skillImg[1];
        if (abilitiesImage2 == null) abilitiesImage2 = MainUIManager.Instance.skillImg[2];
        if (abilitiesImage3 == null) abilitiesImage3 = MainUIManager.Instance.skillImg[3];
        if (abilitiesImage4 == null) abilitiesImage4 = MainUIManager.Instance.skillImg[4];
        if (abilitiesImage5 == null) abilitiesImage5 = MainUIManager.Instance.skillImg[5];

        if (blockImg1 == null) blockImg1 = MainUIManager.Instance.blockSkillImg[0];
        if (blockImg2 == null) blockImg2 = MainUIManager.Instance.blockSkillImg[1];
        if (blockImg3 == null) blockImg3 = MainUIManager.Instance.blockSkillImg[2];
        if (blockImg4 == null) blockImg4 = MainUIManager.Instance.blockSkillImg[3];
        if (blockImg5 == null) blockImg5 = MainUIManager.Instance.blockSkillImg[4];
    }

}
