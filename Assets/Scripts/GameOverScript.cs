using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScript : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI GameOverReason;
    [SerializeField]
    AudioClip WinSound, LossSound;
    private void Start()
    {
        AudioSource Audio = GetComponent<AudioSource>(); 
        if (GameManager.DidWin)
        {
           GameOverReason.text = "Congratulations on completing the game!\nWe hope you enjoyed the game!";
            Audio.clip = WinSound;
        }
        else
        {
            GameOverReason.text = "You Ran out of Cards!\nWe hope you enjoyed the game!";
            Audio.clip = LossSound;
        }
        Audio.Play();
    }
    public void GoToMainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
