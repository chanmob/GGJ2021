using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_InGameMainUI : MonoBehaviour
{
    public GameObject heartParent;

    private Image[] heart;

    private void Start()
    {
        heart = heartParent.GetComponentsInChildren<Image>();
    }

    public void RefreshHeartImage(int idx)
    {
        heart[idx].gameObject.SetActive(false);
    }
}
