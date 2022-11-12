using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerWeaponChange : MonoBehaviour
{
    private WeaponManager mangWeapons;
    private int indexPreviousWeapons;
    public Transform pivotR;

    // Start is called before the first frame update
    void Start()
    {
        mangWeapons = GameObject.Find("WeaponManager").GetComponent<WeaponManager>();
        GameObject tempDefaultWeapon = mangWeapons.weapons[0];
        Instantiate(tempDefaultWeapon, pivotR);
        indexPreviousWeapons = 0;
    }

    public void ChangeWeapon(int weaponIndex)
    {
        if(weaponIndex != indexPreviousWeapons)
        {
            Destroy(pivotR.GetChild(0).gameObject);
            GameObject tempWeapon = mangWeapons.weapons[weaponIndex];
            Instantiate(tempWeapon, pivotR);

            indexPreviousWeapons = weaponIndex;
        }
    }
}
