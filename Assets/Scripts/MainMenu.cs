using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class MainMenu : MonoBehaviour
{

    [SerializeField] TMP_InputField nombreTxt;
    [SerializeField] TextMeshProUGUI recordActual;


    private void Start()
    {
        if(GameManager.Instance.player != null)
        {
            nombreTxt.text = GameManager.Instance.player;
            recordActual.text = "Actual Record: " + GameManager.Instance.record.name + " - " + GameManager.Instance.record.score;
        }
    }

    public void NewStart()
    {

        if(nombreTxt.text != "")
        {
            GameManager.Instance.player = nombreTxt.text;
            SceneManager.LoadScene(1);
        }
        else
        {
            nombreTxt.placeholder.color = Color.red;
        }
        
    }

    public void Exit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}
