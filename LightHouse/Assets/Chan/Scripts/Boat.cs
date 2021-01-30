using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BoatType
{
    None,
    Red,
    Blue,
    Yellow
}

public class Boat : MonoBehaviour
{
    private const float minDistance = 0.005f;

    private IEnumerator _coroutine;

    private BoatType boatType;

    [SerializeField]
    private float _speed = 0.01f;

    private AudioSource audioSource;

    public AudioClip[] clips;

    public SpriteRenderer flag;

    public Sprite[] flagSprites;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnEnable()
    {
        switch (boatType)
        {
            case BoatType.Red:
                flag.sprite = flagSprites[0];
                break;
            case BoatType.Blue:
                flag.sprite = flagSprites[1];
                break;
            case BoatType.Yellow:
                flag.sprite = flagSprites[2];
                break;
        }
    }

    public void SetBoatType(BoatType type)
    {
        boatType = type;
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
        audioSource.clip = clips[0];
        audioSource.Play();
        InGameManager.instance.DecreaseHP(1);
        ObjectPoolManager.instance.ReturnBoat(this);
    }

    private void ArriveIsland()
    {
        InGameManager.instance.arrivedBoatCount++;
        InGameManager.instance.boatCount--;
        audioSource.clip = clips[1];
        audioSource.Play();
        ObjectPoolManager.instance.ReturnBoat(this);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Obstacle"))
        {
            BreakBoat();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        switch (boatType)
        {
            case BoatType.Red:
                if (collision.gameObject.CompareTag("Island_Red"))
                {
                    ArriveIsland();
                }
                break;
            case BoatType.Yellow:
                if (collision.gameObject.CompareTag("Island_Yellow"))
                {
                    ArriveIsland();
                }
                break;
            case BoatType.Blue:
                if (collision.gameObject.CompareTag("Island_Blue"))
                {
                    ArriveIsland();
                }
                break;
        }
    }
}
