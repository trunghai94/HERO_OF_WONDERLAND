using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class XPstat : MonoBehaviour
{
    //EnemyStat enemy;

    public int level;
    public float currentXP;
    public float requireXP;
    private PlayerStats player;

    private float lerpTimer;
    private float delayTimer;

    public Image frontXPBar;
    public Image backXPBar;
    [Header("Mutilplier")]
    [Range(1f, 300f)]
    public float additionMutiplier = 300f;
    [Range(2f, 4f)]
    public float powerMutiplier = 2f;
    [Range(7f, 14f)]
    public float divisionMutiplier = 7f;
    public float XP;
    public TMP_Text textlV;

    public void Start()
    {
        //enemy = GetComponent<EnemyStat>();
        if (frontXPBar == null) frontXPBar = MainUIManager.Instance.frontXPBar;
        if (backXPBar == null) backXPBar = MainUIManager.Instance.backXPBar;
        if (textlV == null) textlV = MainUIManager.Instance.textLv;
        frontXPBar.fillAmount = currentXP / requireXP;
        backXPBar.fillAmount = currentXP / requireXP;
        requireXP = CaculatorXP();
        player=GetComponent<PlayerStats>();
        player.level = level;
    }

    public void Update()
    {
        UpdateUIXP();
        if (currentXP >= requireXP)
        {
            LevelUp();
            player.caculatorStats(level);
            player.regen(player.maxHeath);
            player.level = level;
        }

        if (Input.GetKeyDown(KeyCode.O))
        {
            GainXPFlatRate(XP);
        }
        textlV.text = level.ToString();
    }

    public void UpdateUIXP()
    {
        float xpFaction = currentXP / requireXP;
        float FXP = frontXPBar.fillAmount;
        if (FXP < xpFaction)
        {
            delayTimer += Time.deltaTime;
            backXPBar.fillAmount = xpFaction;
            if (delayTimer > 3f)
            {
                lerpTimer += Time.deltaTime;
                float percentComplete = lerpTimer / 4f;
                frontXPBar.fillAmount = Mathf.Lerp(FXP, backXPBar.fillAmount, percentComplete);
            }
        }
    }

    public void GainXPFlatRate(float xpGained)
    {
        currentXP += xpGained;
        lerpTimer = 0f;
    }

    public void GainXPScalatable(float xpGained, int passedLevel)
    {
        if (passedLevel < level)
        {
            float multiplier = 1f + (level - passedLevel) * 0.1f;
            currentXP += xpGained * multiplier;
        }
        else
        {
            currentXP += xpGained;
        }
        lerpTimer = 0f;
        delayTimer = 0f;
    }

    public void LevelUp()
    {
        level++;
        frontXPBar.fillAmount = 0f;
        backXPBar.fillAmount = 0f;
        currentXP = Mathf.RoundToInt(currentXP - requireXP);
        requireXP = CaculatorXP();
    }

    private int CaculatorXP()
    {
        int solveForRequireXP = 0;
        for (int levelCycle = 1; levelCycle <= level; levelCycle++)
        {
            solveForRequireXP += (int)Mathf.Floor(levelCycle + additionMutiplier * Mathf.Pow(powerMutiplier, levelCycle / divisionMutiplier));
        }
        return solveForRequireXP / 4;
    }
    public float CaculatorXPgain(int enemylvl)
    {
        XP = 1 * Mathf.Pow(enemylvl,2) - (1 * enemylvl);
        return XP / level;
    }
}