using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class InGameManager : Singleton<InGameManager>
{
    private const float minDistance = 0.5f;

    [SerializeField]
    private Light2D globalLight;

    [SerializeField]
    private Color dayColor;
    [SerializeField]
    private Color nightColor;

    [SerializeField]
    private Transform[] spawnTransform;

    private int hp = 5;

    public int boatCount = 0;

    private void Start()
    {
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
