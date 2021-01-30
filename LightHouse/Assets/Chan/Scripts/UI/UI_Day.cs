using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Day : MonoBehaviour
{
    [SerializeField]
    private Text _text_day;

    private void OnEnable()
    {
        Invoke("CloseUI", 1f);
    }
    
    public void SetText(int day)
    {
        _text_day.text = "Day " + day;
    }

    private void CloseUI()
    {
        gameObject.SetActive(false);
    }
}
