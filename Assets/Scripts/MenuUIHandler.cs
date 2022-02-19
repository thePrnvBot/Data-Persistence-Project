using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEditor;
using TMPro;

public class MenuUIHandler : MonoBehaviour
{
    public string userName;
    [SerializeField] private TextMeshProUGUI HighScoreDisplay;

    public void Start()
    {
        DataManager.Instance.LoadUserData();
        HighScoreDisplay.text = $"HighScore: {DataManager.Instance.Username} : {DataManager.Instance.HighScore}";
    }

    public void StartNew()
    {
        Debug.Log(userName);
        DataManager.Instance.CurrentPlayer = userName;
        SceneManager.LoadScene(1);
    }

    public void Exit()
    {
        #if UNITY_EDITOR
            EditorApplication.ExitPlaymode();
        #else
            Application.Quit();
        #endif
    }

    public void ReadStringInput(string s)
    {
        userName = s;
    }
}
