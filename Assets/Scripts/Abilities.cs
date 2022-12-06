using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Abilities : MonoBehaviour
{
    private MeshTrailTut MeshTrail;
    private bool Delay = false;
    private float manaperlevel;
    private float manaskill1, manaskill2, manaskill3, manaskill4, manaskill5;

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

        //Clocking(false);
    }

    // Update is called once per frame
    void Update()
    {
        manaperlevel = playerManager.instance.Player.GetComponent<PlayerStats>().level;
        manaskill1 = 7 + ( 1 * manaperlevel / 10);
        manaskill2 = 3 + (2 * manaperlevel / 10);
        manaskill3 = 12 +(3 * manaperlevel / 10);
        manaskill4 = 15 +(5 * manaperlevel / 10);
        manaskill5 = 19 + (8* manaperlevel / 10);
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
            Debug.Log("a0");
        }     
    }

    void Abilities1()
    {
        if(MainUIManager.Instance.backBlockImg == true)
        {
            blockImg1.gameObject.SetActive(true);
        }
        if (playerManager.instance.Player.GetComponent<PlayerStats>().level >= 3)
        {
            blockImg1.gameObject.SetActive(false);
            if (PlayerMovement.instance.characterController.isGrounded && Input.GetKeyDown(KeyCode.Q) && isCooldown1 == false && playerManager.instance.Player.GetComponent<PlayerStats>().currentMana>=manaskill1)
            {
                playerManager.instance.Player.GetComponent<PlayerStats>().useMP (manaskill1);
                SwordAttack.instance.TornadoAttack();
                PlayerMovement.instance.moveSpeed = 0f;
                PlayerMovement.instance.animator.SetTrigger("Tornado");
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
        if (MainUIManager.Instance.backBlockImg == true)
        {
            blockImg2.gameObject.SetActive(true);
        }
        if (playerManager.instance.Player.GetComponent<PlayerStats>().level >= 6)
        {
            blockImg2.gameObject.SetActive(false);
            if (Input.GetKeyDown(KeyCode.E) && isCooldown2 == false && playerManager.instance.Player.GetComponent<PlayerStats>().currentMana >= manaskill2)
            {
                playerManager.instance.Player.GetComponent<PlayerStats>().useMP(manaskill2);
                SpawnShield.instance.spawnShied();
                playerManager.instance.Player.GetComponent<PlayerStats>().armor += 100f;
                isCooldown2 = true;
                abilitiesImage2.fillAmount = 1;
            }

            if (isCooldown2)
            {
                abilitiesImage2.fillAmount -= 1 / cooldown2 * Time.deltaTime;
                if (abilitiesImage2.fillAmount <= 0)
                {
                    playerManager.instance.Player.GetComponent<PlayerStats>().armor -= 100f;
                    abilitiesImage2.fillAmount = 0f;
                    isCooldown2 = false;
                }
            }
        }
    }

    void Abilities3()
    {
        if (MainUIManager.Instance.backBlockImg == true)
        {
            blockImg3.gameObject.SetActive(true);
        }
        if (playerManager.instance.Player.GetComponent<PlayerStats>().level >= 12)
        {
            blockImg3.gameObject.SetActive(false);
            if (PlayerMovement.instance.characterController.isGrounded && Input.GetKeyDown(KeyCode.R) && isCooldown3 == false && playerManager.instance.Player.GetComponent<PlayerStats>().currentMana >= manaskill3)
            {
                playerManager.instance.Player.GetComponent<PlayerStats>().useMP(manaskill3);
                SwordAttack.instance.WaveFireAttack();
                PlayerMovement.instance.moveSpeed = 0f;
                PlayerMovement.instance.animator.SetTrigger("Wave");
                isCooldown3 = true;
                abilitiesImage3.fillAmount = 1;
                StartCoroutine(DelayMove(2.5f));
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
        if (MainUIManager.Instance.backBlockImg == true)
        {
            blockImg4.gameObject.SetActive(true);
        }
        if (playerManager.instance.Player.GetComponent<PlayerStats>().level >= 17)
        {
            blockImg4.gameObject.SetActive(false);
            if (PlayerMovement.instance.characterController.isGrounded && Input.GetKeyDown(KeyCode.T) && isCooldown4 == false && playerManager.instance.Player.GetComponent<PlayerStats>().currentMana >= manaskill4)
            {
                playerManager.instance.Player.GetComponent<PlayerStats>().useMP(manaskill4);
                SwordAttack.instance.BirdLightAttack();
                PlayerMovement.instance.moveSpeed = 0f;
                PlayerMovement.instance.animator.SetTrigger("BirdLight");
                isCooldown4 = true;
                abilitiesImage4.fillAmount = 1;
                StartCoroutine(DelayMove(1f));
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
        if (MainUIManager.Instance.backBlockImg == true)
        {
            blockImg5.gameObject.SetActive(true);
        }
        if (playerManager.instance.Player.GetComponent<PlayerStats>().level >= 20)
        {
            blockImg5.gameObject.SetActive(false);
            if (PlayerMovement.instance.characterController.isGrounded && Input.GetKeyDown(KeyCode.F) && isCooldown5 == false && playerManager.instance.Player.GetComponent<PlayerStats>().currentMana >= manaskill5)
            {
                playerManager.instance.Player.GetComponent<PlayerStats>().useMP(manaskill5);
                SwordAttack.instance.SwordAirAttack();
                PlayerMovement.instance.moveSpeed = 0f;
                PlayerMovement.instance.animator.SetTrigger("SwordAir");
                isCooldown5 = true;
                abilitiesImage5.fillAmount = 1;
                StartCoroutine(DelayMove(3f));
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
