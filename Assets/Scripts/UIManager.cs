using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    private string newName;
    public Text bestScoreLabel;
    void Start()
    {
        int score = DataPersistence.Instance.highScore;
        string name = DataPersistence.Instance.highScoreName;
        bestScoreLabel.text = "Best Score: " + name + " : " + score;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GetName(string input)
    {
        newName = input;
        Debug.Log(newName);
        DataPersistence.Instance.currentName = newName;
    }

    public void StartClicked()
    {
        SceneManager.LoadScene(1);
    }

    public void QuitClicked()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}
