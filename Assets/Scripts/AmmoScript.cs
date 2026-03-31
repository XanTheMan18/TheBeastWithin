using UnityEngine;

public class AmmoScript : MonoBehaviour
{
    [SerializeField] AudioSource AmmoPickup;
    
    void OnTriggerEnter(Collider other)
    {
        this.gameObject.GetComponent<BoxCollider>().enabled = false;
        AmmoPickup.Play();
        GlobalAmmo.handgunAmmoCount += 25;
        Destroy(gameObject);
    }
}
