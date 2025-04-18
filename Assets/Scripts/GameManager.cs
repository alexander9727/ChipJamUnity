using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public TextMeshProUGUI CardCountText;
    [SerializeField]
    int MaxCardsInLevel;
    int CardsSpawned = -1;
    public static bool DidWin;

    private void Start()
    {
        Instance = this;
        OnSpawnCard();
        DidWin = false;
    }

    public void OnSpawnCard()
    {
        CardsSpawned++;
        CardCountText.text = $"{CardsSpawned}/{MaxCardsInLevel}";
        if(CardsSpawned >= MaxCardsInLevel)
        {
            GameOver();
        }
    }
    public void GameOver()
    {
        DidWin = false;
        LoadNextScene();
    }
    public void GameComplete()
    {
        DidWin = true;
        LoadNextScene();
    }
    void LoadNextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

}
