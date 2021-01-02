using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScreenLoading : MonoBehaviour
{
    [Header("Загружаемая сцена")]
    public int SceneID;
    [Header("Индикаторы загрузки")]
    public Image Load_Bar;
    public Text Load_Text;


    void Start()
    {
        StartCoroutine(AsyncLoad());
    }

    IEnumerator AsyncLoad()
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(SceneID);
        while (!operation.isDone)
        {
            float progress = operation.progress / 0.9f;
            Load_Bar.fillAmount = progress;
            Load_Text.text = string.Format("{0:0}%", progress);
            yield return null;
        }
    }
}
