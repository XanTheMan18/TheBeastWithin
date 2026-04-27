using UnityEngine;
using System.Collections;

public class RaycastEnemyDestroyer : MonoBehaviour
{
    [SerializeField] private float rayDistance = 100f;
    [SerializeField] private LayerMask enemyLayer;
    [SerializeField] private KeyCode shootKey = KeyCode.Mouse0;
    [SerializeField] bool canFire = true;

    private Camera mainCamera;

    private void Start()
    {
        mainCamera = Camera.main;
    }

    private void Update()
    {
        if (canFire == true)
        {
            if (Input.GetKeyDown(shootKey))
            {
                CastRayAndDestroyEnemy();
            }
        }   
    }

    private void CastRayAndDestroyEnemy()
    {
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, rayDistance, enemyLayer))
        {
            Debug.Log($"Hit: {hit.collider.gameObject.name}");
            Destroy(hit.collider.gameObject);
        }
        else
        {
            Debug.Log("No enemy hit");
        }
    }
}