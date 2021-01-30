using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatController : MonoBehaviour
{
    public Boat selectedBoat;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            RaycastHit2D[] hits = Physics2D.RaycastAll(pos, Vector2.zero, Mathf.Infinity, 1 << LayerMask.NameToLayer("Raycast"));

            int len = hits.Length;

            if(len > 0)
            {
                for (int i = 0; i < len; i++)
                {
                    if (hits[i].collider.CompareTag("Boat"))
                    {
                        selectedBoat = hits[i].collider.GetComponent<Boat>();
                        return;
                    }
                }

                if (selectedBoat != null)
                {
                    selectedBoat.SetDestination(Camera.main.ScreenToWorldPoint(Input.mousePosition));
                }
            }
        }
    }
}
