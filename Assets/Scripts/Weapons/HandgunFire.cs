using UnityEngine;
using System.Collections;

public class HandgunFire : MonoBehaviour
{
    [SerializeField] AudioSource Gunfire;
    [SerializeField] GameObject handgun;
    [SerializeField] bool canFire = true;
    void Update()
    {
        if (Input.GetMouseButton(0)) 
        {
            if(canFire == true)
            {
                canFire = false;
                StartCoroutine(FiringGun());
            }
        }
    }

    IEnumerator FiringGun()
    {
        Gunfire.Play();
        handgun.GetComponent<Animator>().Play("HandgunFire");
        yield return new WaitForSeconds(0.3f);
        handgun.GetComponent<Animator>().Play("New State");
        yield return new WaitForSeconds(0.1f);
        canFire = true;
    }
}
