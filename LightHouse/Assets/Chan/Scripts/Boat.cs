using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boat : MonoBehaviour
{
    private const float minDistance = 0.005f;

    private IEnumerator coroutine;

    [SerializeField]
    private float speed = 0.01f;

    public void SetDestination(Vector2 destination)
    {
        if(coroutine != null)
        {
            StopCoroutine(coroutine);
            coroutine = null;
        }

        coroutine = BoatMoveCoroutine(destination);
        StartCoroutine(coroutine);
    }

    private IEnumerator BoatMoveCoroutine(Vector2 destination)
    {
        float sqr = ((Vector2)transform.position - destination).sqrMagnitude;

        while(sqr > minDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, destination, speed);
            sqr = ((Vector2)transform.position - destination).sqrMagnitude;
            yield return null;
        }

        transform.position = destination;
    }
}
