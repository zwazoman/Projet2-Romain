using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.SceneManagement;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    //singleton
    private static GameManager instance;

    public static GameManager Instance
    {
        get
        {
            if (instance == null)
            {
                GameObject go = new GameObject("Game Manager");
                instance = go.AddComponent<GameManager>();
            }
            return instance;
        }
    }

    [SerializeField] float _timeBeforeRestart = 2f;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        InfoText.Instance.Write("Bonne chance Romain ;)", true);
    }

    public void RestartLevel(string text) => StartCoroutine(Restart(text));

    IEnumerator Restart(string text)
    {
        Time.timeScale = 0;
        InfoText.Instance.Write(text);
        yield return new WaitForSecondsRealtime(_timeBeforeRestart);
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

}
