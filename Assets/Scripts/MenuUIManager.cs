using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class MenuUIManager : MonoBehaviour
{

    [SerializeField] private TMP_InputField m_playerNameInput;
    [SerializeField] private TextMeshProUGUI m_bestScoreText;

    private void Start()
    {
        if (ScoreManager.Instance != null && ScoreManager.Instance.bestScorePlayerName != "")
        {
            m_bestScoreText.text = $"Best Score: {ScoreManager.Instance.bestScorePlayerName}: {ScoreManager.Instance.BestScore}";
            m_playerNameInput.text = ScoreManager.Instance.bestScorePlayerName;
        }
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
        ScoreManager.Instance.newPlayerName = m_playerNameInput.text;
    }

    public void QuitGame()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }

}
