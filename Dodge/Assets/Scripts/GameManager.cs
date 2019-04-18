using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    public GameObject gameoverText;
    public Text timeText;
    public Text recordText;

    private float surviveTime;
    private bool isGameover;

    private void Start()
    {
        surviveTime = 0;
        isGameover = false;
    }

    private void Update()
    {
        if (!isGameover)
        {
            surviveTime += Time.deltaTime;
            timeText.text = string.Format("Time : {0}", (int)surviveTime);
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.R)) SceneManager.LoadScene("SampleScene");
        }
    }

    public void EndGame()
    {
        float bestTime = PlayerPrefs.GetFloat("BestTime");

        isGameover = true;
        gameoverText.SetActive(true);

        if (surviveTime > bestTime)
        {
            bestTime = surviveTime;
            PlayerPrefs.SetFloat("BestTime", bestTime);
        }
        recordText.text = string.Format("Best Time : {0}", (int)bestTime);
    }
}
