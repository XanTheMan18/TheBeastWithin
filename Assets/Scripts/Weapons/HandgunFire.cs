using UnityEngine;

public class HandgunFire : MonoBehaviour
{
    [SerializeField] AudioSource Gunfire;
    
    void Update()
    {
        if (Input.GetMouseButton(0)) 
        {
            Gunfire.Play();
        }
    }
}
