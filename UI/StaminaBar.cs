
// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using UnityEngine.UI;

// public class StaminaBar : MonoBehaviour
// {
//     public Slider staminaSlider;

//     public float maxStamina = 100;
//     private float currentStamina;

//     private float regenerateStaminaTime = 0.10f;
//     private float regenerateAmount = 2;
//     private float losingStaminaTime = 0.10f;

//     private Coroutine myCoroutineLosing;
    
//     private Coroutine myCoroutineRegenerate;

//     void Start()
//     {
//         currentStamina = maxStamina;
//         staminaSlider.maxValue = maxStamina;
//         staminaSlider.value = maxStamina;
//     }

//     public void UseStamina(float amount)
//     {
//         if (currentStamina - amount > 0)
//         {

//           if (myCoroutineLosing != null )
//           {
//    StopCoroutine(myCoroutineLosing);

//           }
//             StartCoroutine(LosingStaminaCoroutine(amount));
//             if (myCoroutineRegenerate!= null)
//             {
//               StopCoroutine(myCoroutineRegenerate);
//             }
//             myCoroutineRegenerate=StartCoroutine(RegenerateStaminaCoroutine());
//         }
//         else
//         {
//             Debug.Log("¡No tenemos Stamina!");
//             FindObjectOfType<PlayerMovement>().isSprinting = false;
//         }
//     }

//     private IEnumerator LosingStaminaCoroutine(float amount)
//     {
//         while (currentStamina >= 0)
//         {
//             currentStamina -= amount;
//             staminaSlider.value = currentStamina;
//             yield return new WaitForSeconds(losingStaminaTime);
//         }
//  myCoroutineLosing=null;
//         FindObjectOfType<PlayerMovement>().isSprinting = false;
//     }

//     private IEnumerator RegenerateStaminaCoroutine()
//     {
//         yield return new WaitForSeconds(1);
//         while (currentStamina < maxStamina)
//         {
//             currentStamina += regenerateAmount;
//             staminaSlider.value = currentStamina;
//             yield return new WaitForSeconds(regenerateStaminaTime);
//         }
//         myCoroutineRegenerate = null;
//     }
// }

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StaminaBar : MonoBehaviour
{
    public Slider staminaSlider;

    public float maxStamina = 100;
    private float currentStamina;

    public float staminaDecreasePerSecond = 2f;
    public float staminaIncreasePerSecond = 1f;

    private Coroutine decreasingCoroutine;
    private Coroutine increasingCoroutine;

    private void Start()
    {
        currentStamina = maxStamina;
        staminaSlider.maxValue = maxStamina;
        staminaSlider.value = maxStamina;
    }

    public void UseStamina(float amount)
    {
        if (currentStamina >= amount)
        {
            if (decreasingCoroutine != null)
            {
                StopCoroutine(decreasingCoroutine);
            }
            decreasingCoroutine = StartCoroutine(DecreaseStaminaCoroutine(amount));

            if (increasingCoroutine != null)
            {
                StopCoroutine(increasingCoroutine);
            }
            increasingCoroutine = StartCoroutine(IncreaseStaminaCoroutine());
        }
        else
        {
            Debug.Log("¡No tenemos Stamina!");
            FindObjectOfType<PlayerMovement>().isSprinting = false;
        }
    }

    private IEnumerator DecreaseStaminaCoroutine(float amount)
    {
        float decreasePerFrame = staminaDecreasePerSecond * Time.deltaTime;
        while (currentStamina >= 0)
        {
            currentStamina -= decreasePerFrame * amount;
            staminaSlider.value = currentStamina;
            yield return null;
        }
        currentStamina = 0;
        staminaSlider.value = currentStamina;
        FindObjectOfType<PlayerMovement>().isSprinting = false;
    }

    private IEnumerator IncreaseStaminaCoroutine()
    {
        float increasePerFrame = staminaIncreasePerSecond * Time.deltaTime;
        while (currentStamina < maxStamina)
        {
            currentStamina += increasePerFrame;
            staminaSlider.value = currentStamina;
            yield return null;
        }
        currentStamina = maxStamina;
        staminaSlider.value = currentStamina;
    }
}