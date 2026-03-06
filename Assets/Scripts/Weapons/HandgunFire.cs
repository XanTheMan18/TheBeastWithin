using UnityEngine;
using System.Collections;

public class HandgunFire : MonoBehaviour
{
    [SerializeField] AudioSource Gunfire;
    [SerializeField] GameObject handgun;
    [SerializeField] bool canFire = true;
    [SerializeField] GameObject ExtraCross;
    [SerializeField] AudioSource emptyGunSound;
    void Update()
    {
        if (Input.GetMouseButton(0)) 
        {
            if(canFire == true)
            {
                if(GlobalAmmo.handgunAmmoCount == 0){
                    canFire = false;
                    StartCoroutine(EmptyGun());

                }
                else {
                     canFire = false;
                     StartCoroutine(FiringGun());
                }
            
               
            }
        }
    }

    IEnumerator FiringGun()
    {
        Gunfire.Play();
        ExtraCross.SetActive(true);
        GlobalAmmo.handgunAmmoCount -= 1;
        handgun.GetComponent<Animator>().Play("HandgunFire");
        yield return new WaitForSeconds(0.35f);
        handgun.GetComponent<Animator>().Play("New State");
        ExtraCross.SetActive(false);
        yield return new WaitForSeconds(0.1f);
        canFire = true;
    }
    IEnumerator EmptyGun()
    {
        emptyGunSound.Play();
        yield return new WaitForSeconds(0.6f);
        canFire = true;

    }
}
