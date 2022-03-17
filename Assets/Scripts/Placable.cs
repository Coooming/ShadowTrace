using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Placable : Interactable
{
    public bool placed = false;
    public InteractiveDef.PickableType PlaceType;
    // Start is called before the first frame update
    void Start()
    {
        if (GetComponentInChildren<Renderer>())
        {
            GetComponentInChildren<Renderer>().enabled = false;
        }
        if (GetComponent<Collider>())
        {
            GetComponent<Collider>().enabled = false;
        }
    }

    public virtual bool Placed()
    {
        return placed;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    override public void BeInteracted(InteractController controller) 
    {
        //pick
        if (controller)
        {
            HandlePlacing(controller);
        }
    }

    public virtual void HandlePlacing(InteractController controller)
    {
        if (placed)
        {
            return;
        }
        if (!controller.ContainPick(PlaceType))
        {
            return;
        }
        controller.RemovePick(PlaceType);

        for (int i = 0; i < transform.childCount; ++i)
        {
            transform.GetChild(i).gameObject.SetActive(true);
        }
        GetComponent<Collider>().enabled = true;

        GetComponentInChildren<Renderer>().enabled = true;
        if (GetComponent<Collider>())
        {
            placed = true;
            GetComponent<Collider>().enabled = true;
            if (GetComponentInChildren<Pickable>())
            {
                GetComponentInChildren<Pickable>().enabled = true;
            }
        }
    }
}
