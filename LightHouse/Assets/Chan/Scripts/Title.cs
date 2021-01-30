using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Title : MonoBehaviour
{
    private float elapsedtime = 0;
    [SerializeField]
    private float waitTime;

    private void Start()
    {
        StartCoroutine(TitleCoroutine());
    }

    private IEnumerator TitleCoroutine()
    {
        Vector3 startPos = new Vector3(0, 13.5f, -10);
        Vector3 endPos = new Vector3(0, -13.5f, -10);

        while(elapsedtime < waitTime)
        {
            transform.position = Vector3.Lerp(startPos, endPos, elapsedtime / waitTime);
            elapsedtime += Time.deltaTime;
            yield return null;
        }

        transform.position = endPos;
    }

    public void LoadInGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("InGame");
    }
}
