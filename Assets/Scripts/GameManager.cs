using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
   public static GameManager instance;

    public Text itemCounterText;
    public int totalCollectibles = 7;

    private int currentCollectibles = 0;

    public bool HasAllCollectibles()
    {
        return currentCollectibles >= totalCollectibles;
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void AddCollectible()
    {
        currentCollectibles++;
        UpdateUI();

        
    }
    void UpdateUI()
    {
        itemCounterText.text = "KEYS: " + currentCollectibles + "/" + totalCollectibles;
    }
    
}


