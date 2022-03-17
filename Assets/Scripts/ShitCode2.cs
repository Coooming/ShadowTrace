using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShitCode2 : Placable
{

    public override bool Placed()
    {
        return DelayNoMore.placed;
    }

    private void Update()
    {
        GetComponent<Collider>().enabled = DelayNoMore.GetComponent<Collider>().enabled;
    }
    public Placable DelayNoMore;
    public override void HandlePlacing(InteractController controller)
    {
        if (DelayNoMore.placed)
        {
            return;
        }
        if (!controller.ContainPick(PlaceType))
        {
            return;
        }
        controller.RemovePick(PlaceType);

        for (int i = 0; i < DelayNoMore.transform.childCount; ++i)
        {
            DelayNoMore.transform.GetChild(i).gameObject.SetActive(true);
        }
        DelayNoMore.GetComponent<Collider>().enabled = true;

        DelayNoMore.GetComponentInChildren<Renderer>().enabled = true;
        if (DelayNoMore.GetComponent<Collider>())
        {
            DelayNoMore.placed = true;
            DelayNoMore.GetComponent<Collider>().enabled = true;
            if (DelayNoMore.GetComponentInChildren<Pickable>())
            {
                DelayNoMore.GetComponentInChildren<Pickable>().enabled = true;
            }
        }
    }
}
