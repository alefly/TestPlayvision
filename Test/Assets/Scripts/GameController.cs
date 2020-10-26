using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class GameController : MonoBehaviour
{
    public Button buttonRestart;

    void Start()
    {
        buttonRestart.onClick.AddListener(Reload);
        buttonRestart.GetComponentInChildren<Text>().text = "Начать бесконечную игру сначала";
    }

    public void Reload()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
