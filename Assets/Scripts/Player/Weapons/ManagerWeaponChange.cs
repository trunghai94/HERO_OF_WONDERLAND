using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerWeaponChange : MonoBehaviour
{
    private WeaponManager mangWeapons;
    private int indexPreviousWeapons;
    public GameObject swordEffects;
    public GameObject shieldEffects;
    public Transform pivotR;
    public Transform pivotL;
    public Transform Effects;

    // Start is called before the first frame update
    void Start()
    {
        mangWeapons = GameObject.Find("WeaponsManager").GetComponent<WeaponManager>();
        GameObject tempDefaultSwords = mangWeapons.swords[0];
        Instantiate(tempDefaultSwords, pivotR);

        GameObject tempDefaultShields = mangWeapons.shields[0];
        Instantiate(tempDefaultShields, pivotL);

        indexPreviousWeapons = 0;
    }

    public void ChangeWeapon(int weaponIndex)
    {
        if(weaponIndex != indexPreviousWeapons)
        {
            Destroy(pivotR.GetChild(0).gameObject);
            var fxSwords = Instantiate(swordEffects, pivotR);
            Destroy(fxSwords, 1f);
            StartCoroutine(ChangeSwords(weaponIndex));

            Destroy(pivotL.GetChild(0).gameObject);
            var fxShields = Instantiate(shieldEffects,Effects);
            Destroy(fxShields, 1f);
            StartCoroutine(ChangeShields(weaponIndex));

            indexPreviousWeapons = weaponIndex;
            AudioManager.Instance.PlayEffect("SwordAndShied");
        }
    }

    IEnumerator ChangeSwords(int weaponIndex)
    {
        yield return new WaitForSeconds(0.5f);
        GameObject tempWeaponR = mangWeapons.swords[weaponIndex];
        Instantiate(tempWeaponR, pivotR);
    }

    IEnumerator ChangeShields(int weaponIndex)
    {
        yield return new WaitForSeconds(0.5f);
        GameObject tempWeaponL = mangWeapons.shields[weaponIndex];
        Instantiate(tempWeaponL, pivotL);
    }
}
