using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    public Text scoreText;
    private int damageCount;

    private void Update()
    {
        if (damageCount == 8)

        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
            Application.LoadLevel("End");

        }
    }

    public void UpdateDamageUI()
    {
        damageCount += 1;
      //  scoreText.text = "Timer: " + (int)damageCount;

        /* if ((int)damageCount == 5)
         {
             SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
         }*/
        scoreText.text = "Score: " + damageCount.ToString();

        if (damageCount == 8)

        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
            Application.LoadLevel("End");

        }
    }
}
