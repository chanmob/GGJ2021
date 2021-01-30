using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class InGameManager : Singleton<InGameManager>
{
    private const float minDistance = 0.5f;

    private const float dayTime = 3f;

    [SerializeField]
    private Light2D globalLight;

    [SerializeField]
    private Color dayColor;
    [SerializeField]
    private Color nightColor;

    [SerializeField]
    private Transform[] spawnTransform;

    private int hp = 5;
    private int day = 1;

    public int boatCount = 0;
    public int arrivedBoatCount = 0;


    private bool isDay = false;
    private bool timeOff = false;

    float duration = 5f;
    float smoothness = 0.02f;

    private float time = 0;


    private void Start()
    {
        if (isDay)
        {
            globalLight.color = dayColor;
        }
        else
        {
            globalLight.color = nightColor;
        }

        StartCoroutine(DayCoroutine());
        StartCoroutine(CreateBoatCoroutine());
    }

    public void DecreaseHP(int damage)
    {
        hp -= damage;
        InGameUIManager.instance.ui_InGameMainUI.RefreshHeartImage(hp);
    }

    public void SetGlobalLightColor(bool isDay)
    {
        if (isDay)
        {
            globalLight.color = dayColor;
        }
        else
        {
            globalLight.color = nightColor;
        }
    }

    private void Update()
    {
        if (!timeOff)
        {
            time += Time.deltaTime;
            InGameUIManager.instance.ui_InGameMainUI.SetTimeText(dayTime - time);
        }
        else
        {
            InGameUIManager.instance.ui_InGameMainUI.SetTimeText(0);
        }
    }

    private IEnumerator DayCoroutine()
    {
        for (int i = 0; i < 4; i++)
        {
            Boat boat = ObjectPoolManager.instance.GetBoat();
            boat.transform.position = GetTransform().position;
            boat.gameObject.SetActive(true);
            boatCount++;
        }

        while (true)
        {
            if(!isDay)
                yield return new WaitForSeconds(dayTime);

            timeOff = true;
            Color startColor;
            Color targetColor;

            if(!isDay)
            {
                startColor = nightColor;
                targetColor = dayColor;
            }
            else
            {
                startColor = dayColor;
                targetColor = nightColor;
            }

            float progress = 0;
            float increment = smoothness / duration;
            while (progress < 1)
            {
                globalLight.color = Color.Lerp(startColor, targetColor, progress);
                progress += increment;
                yield return new WaitForSeconds(smoothness);
            }

            time = 0;
            isDay = !isDay;

            if (isDay)
            {
                day++;
                InGameUIManager.instance.ui_InGameMainUI.SetDayText(day);
                InGameUIManager.instance.ui_Day.SetText(day);
                InGameUIManager.instance.ui_Day.gameObject.SetActive(true);
            }
            else
            {
                timeOff = false;
            }
        }
    }

    private IEnumerator CreateBoatCoroutine()
    {
        while (true)
        {
            yield return new WaitUntil(() => boatCount < 4);
            yield return new WaitForSeconds(4f);

            Boat boat = ObjectPoolManager.instance.GetBoat();
            boat.transform.position = GetTransform().position;
            boat.gameObject.SetActive(true);
            boatCount++;
        }
    }

    public Transform GetTransform()
    {
        int len = spawnTransform.Length;

        int randomIdx = Random.Range(0, len);

        GameObject[] boats = GameObject.FindGameObjectsWithTag("Boat");
        int boatLen = boats.Length;

        bool ok = false;

        while (ok == false)
        {
            for (int i = 0; i < boatLen; ++i)
            {
                float diff = Vector2.Distance(spawnTransform[randomIdx].position, boats[i].transform.position);

                if (diff < minDistance)
                {
                    randomIdx = Random.Range(0, len);
                    i = -1;
                }
            }

            ok = true;
        }

        return spawnTransform[randomIdx];
    }
}
