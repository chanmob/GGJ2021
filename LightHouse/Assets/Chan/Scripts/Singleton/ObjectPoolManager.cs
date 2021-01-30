using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPoolManager : Singleton<ObjectPoolManager>
{
    [SerializeField]
    private Boat _boatPrefab;

    private Stack<Boat> _stack_Boat = new Stack<Boat>();


    public Boat GetBoat()
    {
        Boat newBoat = null;

        if (_stack_Boat.Count == 0)
            MakeBoat(1);

        newBoat = _stack_Boat.Pop();

        return newBoat;
    }

    public void ReturnBoat(Boat boat)
    {
        _stack_Boat.Push(boat);

        if (boat.gameObject.activeSelf)
            boat.gameObject.SetActive(false);
    }

    private void MakeBoat(int count)
    {
        for(int i = 0; i < count; i++)
        {
            Boat newBoat = Instantiate(_boatPrefab);
            newBoat.gameObject.SetActive(false);
            _stack_Boat.Push(newBoat);
        }
    }
}
