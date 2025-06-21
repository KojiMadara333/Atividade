using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (GameManager.instance.HasAllCollectibles())
            {
                SceneManager.LoadScene("Victory");
            }

            else
            {
                Debug.Log("NEED 7 KEYS");
            }
        }
    }
}
