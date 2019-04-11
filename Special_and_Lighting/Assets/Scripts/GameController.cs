using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

    public Text endGameText;

    //set game time to 1 and turn off mouse cursor
    private void Start()
    {
        Time.timeScale = 1;
        Cursor.visible = false;
        endGameText.text = "";
    }

    public void EndGame(string text)
    {
        endGameText.text = text;

        Time.timeScale = 0;
        StartCoroutine(Quit());
    }

    IEnumerator Quit()
    {
        Debug.Log("Quitting...");
        yield return new WaitForSecondsRealtime(3);
        SceneManager.LoadScene("MainMenu");
    }
}
