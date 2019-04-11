using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour {

    public Text loadText;
    public Button startBtn;
    public Button quitBtn;

    // Use this for initialization
    void Start()
    {
        Cursor.visible = true;
        loadText.text = "";

        startBtn.onClick.AddListener(StartGame);
        quitBtn.onClick.AddListener(QuitGame);
    }
    
    void StartGame()
    {
        StartCoroutine(Load());
    }

    IEnumerator Load()
    {
        loadText.text = "Loading . . .";
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene("Main");
    }

    void QuitGame()
    {
        Application.Quit();
    }
}
