
using System.Security.Cryptography;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwitch : MonoBehaviour
{
  
public GameObject[] weapons;

public int selectedWeapon = 0;




    void Start()
    {
        
    }

   
    void Update()
    {
int previusWeapon = selectedWeapon;

        if (Input.GetAxis("Mouse ScrollWheel")>0)
        {
            if(selectedWeapon>= weapons.Length-1)
            {
                selectedWeapon = 0;
            }else 
            {
                selectedWeapon++;
            }
        }
        
    

    if (Input.GetAxis("Mouse ScrollWheel")<0)

    
        {
            if(selectedWeapon<= 0)
            {
                selectedWeapon = weapons.Length-1;
            }else 
            {
                selectedWeapon--;
            }
        }

        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            selectedWeapon =0;
        }

        if(Input.GetKeyDown(KeyCode.Alpha2) && weapons.Length>=2)
        {
            selectedWeapon =1;
        }

         if(Input.GetKeyDown(KeyCode.Alpha3) && weapons.Length>=3)
        {
            selectedWeapon =2;
        }


        if (previusWeapon != selectedWeapon )
        {
            SelectWeapon();
        }
      }   
    

    void SelectWeapon()
    {

        int i=0;
        foreach(Transform weapon in transform)
            {
              if (weapon.gameObject.layer==LayerMask.NameToLayer("Weapon"))
              {
                   if (i==selectedWeapon)
                   {
                    weapon.gameObject.SetActive(true);
                   }
                   else {
                    weapon.gameObject.SetActive(false);
                   }
                   i++;
              }
            }
        }



    }

