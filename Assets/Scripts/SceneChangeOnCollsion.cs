using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChangeOnCollision : MonoBehaviour
{
    [SerializeField] private string targetSceneName;
    [SerializeField] private bool destroyObjectOnTrigger = false;
    [SerializeField] private float delayBeforeSceneChange = 0f;
    
    public bool isPlayerInteracting { get; private set; } = false;
    private bool hasTriggered = false;

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Player"))
        {
            isPlayerInteracting = true;
            Debug.Log($"Player started interacting with {name}");

            if (!hasTriggered)
            {
                hasTriggered = true;
                TriggerSceneChange();
            }
            ResetTrigger();
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.CompareTag("Player"))
        {
            isPlayerInteracting = false;
            Debug.Log($"Player stopped interacting with {name}");
        }
    }

    private void TriggerSceneChange()
    {
        if (delayBeforeSceneChange > 0)
        {
            Invoke(nameof(ChangeScene), delayBeforeSceneChange);
            Debug.Log($"1st if");
        }
        else
        {
            ChangeScene();
            Debug.Log($"2nd if");
        }

        if (destroyObjectOnTrigger)
        {
            Destroy(gameObject);
            Debug.Log($"Destroy");
        }
    }

    private void ChangeScene()
    {
        if (!string.IsNullOrEmpty(targetSceneName))
        {
            SceneManager.LoadScene(targetSceneName);
            Debug.Log($"Load Failed");
        }
        else
        {
            Debug.LogWarning("Target scene name is not set!");
        }
    }

    // Optional: Reset trigger for testing
    public void ResetTrigger()
    {
        hasTriggered = false;
    }
}