using UnityEngine;

public class HandgunFire : MonoBehaviour
{
    [SerializeField] AudioSource Gunfire;
    [SerializeField] GameObject handgun;
    void Update()
    {
        if (Input.GetMouseButton(0)) 
        {
            Gunfire.Play();
        }
    }

    IEnumerator FiringGun()
    {
        Gunfire.Play();
        handgun.GetComponant<Animator>().Play("HandgunFire");
    }
}
