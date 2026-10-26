using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class DoorExit : MonoBehaviour
{
    [SerializeField] private int sceneIndex = 1;
    [SerializeField] private GameObject prompt;

    private bool playerNearby;

    private void Start()
    {
        if (prompt != null)
        {
            prompt.SetActive(false);
        }
    }

    private void Update()
    {
        if (playerNearby && Keyboard.current != null && Keyboard.current.eKey.wasPressedThisFrame)
        {
            SceneManager.LoadScene(sceneIndex);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerNearby = true;

            if (prompt != null)
            {
                prompt.SetActive(true);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerNearby = false;

            if (prompt != null)
            {
                prompt.SetActive(false);
            }
        }
    }
}
