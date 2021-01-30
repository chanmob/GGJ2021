using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_InGameMainUI : MonoBehaviour
{
    public GameObject heartParent;

    private Image[] heart;

    [SerializeField]
    private Text _text_Time;
    [SerializeField]
    private Text _text_Day;

    private void Start()
    {
        heart = heartParent.GetComponentsInChildren<Image>();
    }

    public void RefreshHeartImage(int idx)
    {
        heart[idx].gameObject.SetActive(false);
    }

    public void SetDayText(int day)
    {
        _text_Day.text = "Day " + day.ToString();
    }

    public void SetTimeText(float time)
    {
        int min = Mathf.FloorToInt(time / 60F);
        int sec = Mathf.FloorToInt(time % 60F);

        _text_Time.text = min + ":" + sec.ToString("00");
    }
}
