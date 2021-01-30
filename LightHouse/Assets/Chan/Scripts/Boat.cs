using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BoatType
{
    None
}

public class Boat : MonoBehaviour
{
    private const float minDistance = 0.005f;

    private IEnumerator _coroutine;

    private BoatType boatType;

    [SerializeField]
    private float _speed = 0.01f;

    private void OnEnable()
    {
        switch (boatType)
        {

        }
    }

    public void SetDestination(Vector2 destination)
    {
        if(_coroutine != null)
        {
            StopCoroutine(_coroutine);
            _coroutine = null;
        }

        _coroutine = BoatMoveCoroutine(destination);
        StartCoroutine(_coroutine);
    }

    private IEnumerator BoatMoveCoroutine(Vector2 destination)
    {
        float sqr = ((Vector2)transform.position - destination).sqrMagnitude;

        while(sqr > minDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, destination, _speed);
            sqr = ((Vector2)transform.position - destination).sqrMagnitude;
            yield return null;
        }

        transform.position = destination;
    }

    private void BreakBoat()
    {
        ObjectPoolManager.instance.ReturnBoat(this);
        InGameManager.instance.DecreaseHP(1);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Obstacle"))
        {
            BreakBoat();
        }
    }
}
