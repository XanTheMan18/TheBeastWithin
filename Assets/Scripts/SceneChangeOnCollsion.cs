using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChangeOnCollision : MonoBehaviour
{
    [SerializeField] private string targetSceneName= "Dungeon";
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
        }
        else
        {
            ChangeScene();
        }

        if (destroyObjectOnTrigger)
        {
            Destroy(gameObject);
        }
    }

    private void ChangeScene()
    {
        if (!string.IsNullOrEmpty(targetSceneName))
        {
            SceneManager.LoadScene(targetSceneName);
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