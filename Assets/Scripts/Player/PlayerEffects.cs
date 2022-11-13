using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEffects : MonoBehaviour
{
    public static PlayerEffects instance;
    public GameObject fxLevelUp;

    private int currentLevel;
    private int levelUp = 1;

    private void Start()
    {
        instance = this;
    }

    private void Update()
    {
        currentLevel = playerManager.instance.Player.GetComponent<PlayerStats>().level;
        if (currentLevel == levelUp)
        {
            LevelUpEffect();
        }
    }

    public void LevelUpEffect()
    {
        var fxLevel = Instantiate(fxLevelUp, this.transform) as GameObject;
        fxLevel.transform.SetParent(this.transform);
        Destroy(fxLevel, 1f);
        levelUp = currentLevel + 1;
    }
}
