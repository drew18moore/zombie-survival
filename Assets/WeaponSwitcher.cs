using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class WeaponSwitcher : MonoBehaviour
{
    public GameObject[] guns;

    int totalWeapons;
    public int starterWeaponIndex;

    public int currentWeaponIndex;
    public GameObject currentWeapon;

    // Input
    [SerializeField] PlayerInput input;
    [SerializeField] InputAction scrollAction;

    void Start()
    {
        totalWeapons = transform.childCount;
        guns = new GameObject[totalWeapons];

        for (int i = 0; i < totalWeapons; i++)
        {
            guns[i] = transform.GetChild(i).gameObject;
            guns[i].SetActive(false);
            print(guns[i]);
        }
        currentWeapon = guns[starterWeaponIndex];
        currentWeapon.SetActive(true);

        scrollAction = input.actions["MouseScrollY"];
    }

    void Update()
    {
        if (scrollAction.ReadValue<float>() > 0)
        {
            // SCROLL UP (switch to next weapon)
            guns[currentWeaponIndex].SetActive(false);
            if (currentWeaponIndex > 0)
                currentWeaponIndex--;
            else
                currentWeaponIndex = totalWeapons - 1;
            guns[currentWeaponIndex].SetActive(true);
        }


        else if (scrollAction.ReadValue<float>() < 0)
        {
            // SCROLL DOWN (switch to previous weapon)
            guns[currentWeaponIndex].SetActive(false);
            if (currentWeaponIndex < totalWeapons - 1)
                currentWeaponIndex++;
            else
                currentWeaponIndex = 0;
            guns[currentWeaponIndex].SetActive(true);
        }
        print(currentWeaponIndex);
    }
}
