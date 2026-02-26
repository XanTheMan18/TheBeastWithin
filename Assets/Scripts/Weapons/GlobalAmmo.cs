using UnityEngine;

public class GlobalAmmo : MonoBehaviour
{
    public static int handgunAmmoCount = 10;
    [SerializeField] GameObject ammoCounter;
    void Update()
    {
        ammoCounter.GetComponent<TMPro.TMP_Text>().text = "" + handgunAmmoCount;
    }
}
