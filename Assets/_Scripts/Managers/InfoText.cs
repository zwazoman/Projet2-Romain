using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InfoText : MonoBehaviour
{
    //singleton
    private static InfoText instance;

    public static InfoText Instance
    {
        get
        {
            if (instance == null)
            {
                GameObject go = new GameObject("Info Text");
                instance = go.AddComponent<InfoText>();
            }
            return instance;
        }
    }

    private void Awake()
    {
        instance = this;
    }


    [SerializeField] TMP_Text _infoText;

    public void Write(string text, bool autoErase = false)
    {
        _infoText.text = text;
        if (autoErase) StartCoroutine(AutoErase());
    }

    IEnumerator AutoErase()
    {
        yield return new WaitForSecondsRealtime(2);
        Erase();
    }

    public void Erase()
    {
        _infoText.text = "";
    }

}
