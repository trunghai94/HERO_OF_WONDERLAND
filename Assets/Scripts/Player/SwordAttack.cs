using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordAttack : MonoBehaviour
{
    public static SwordAttack instance;
    public float delayToDestroy = 5;
    public GameObject waveAttack;
    public GameObject birdLightAttack;
    public GameObject tornadoAttack;
    public GameObject swordAttack;
    public GameObject swordAirAttack;
    public Transform StartTornado;
    public Transform StartWave;
    private bool useSkill = false;
    

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    public void TornadoAttack()
    {
        var tornadoVfx = Instantiate(tornadoAttack, StartTornado.transform) as GameObject;
        tornadoVfx.transform.SetParent(StartTornado.transform);
        Destroy(tornadoVfx, delayToDestroy);
    }
    public void SwordAirAttack()
    {
        var swordAirVfx = Instantiate(swordAirAttack,this.transform) as GameObject;
        swordAirVfx.transform.SetParent(this.transform);
        StartCoroutine(swordAttackDelay());
        Destroy(swordAirVfx, delayToDestroy);
    }

    public void WaveFireAttack()
    {
        if (useSkill) return;
        StartCoroutine(WaveFireDelay());
        useSkill = true;
    }

    public void BirdLightAttack()
    {
        var birdLightVfx = Instantiate(birdLightAttack, StartTornado.transform) as GameObject;
        birdLightVfx.transform.SetParent(StartTornado.transform);
        Destroy(birdLightVfx, delayToDestroy);
    }

    IEnumerator swordAttackDelay()
    {
        yield return new WaitForSeconds(3f);
        var swordVfx = Instantiate(swordAttack, this.transform) as GameObject;
        swordVfx.transform.SetParent(this.transform);
        Destroy(swordVfx, delayToDestroy);
    }

    IEnumerator WaveFireDelay()
    {
        yield return new WaitForSeconds(2.5f);
        var waveVfx = Instantiate(waveAttack);
        waveVfx.transform.position = StartWave.transform.position;
        waveVfx.transform.rotation = this.transform.rotation;
        useSkill = false;
        Destroy(waveVfx, delayToDestroy);
    }
}
