using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractController : MonoBehaviour
{
    List<InteractiveDef.PickableType> pickables = new List<InteractiveDef.PickableType>();
    // Start is called before the first frame update

    Interactable itemToBeInteracted;

    public bool isShadow = false;
    bool toDoInteract = false;

    bool framelock = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!isShadow && Input.GetKeyUp(Control.interactKey))
        {
            toDoInteract = true;
        }
        framelock = false;
    }

    private void LateUpdate()
    {
        if (itemToBeInteracted && toDoInteract)
        {
            if ((!isShadow && GetControl().CanInteract()) || isShadow)
            {
                itemToBeInteracted.BeInteracted(this);
                itemToBeInteracted = null;
            }
        }
        toDoInteract = false;

        float deadLocalY = isShadow ? 11.0f : 12.0f;
        if (transform.localPosition.y < deadLocalY)
        {
            GameObject.Find("TrackDrawer").GetComponent<Track>().BackupTrack();
            LevelManager.Instance().Retry(false);
        }
    }

    public Control GetControl()
    {
        return GameObject.Find("GameManager").GetComponent<Control>();
    }

    private void OnTriggerStay(Collider other)
    {
        if (framelock)
        {
            return;
        }
        Placable item = other.GetComponentInParent<Placable>();
        if (item && !item.Placed())
        {
            itemToBeInteracted = item;
            return;
        }
        Pickable item2 = other.GetComponentInParent<Pickable>();
        if (item2)
        {
            itemToBeInteracted = item2;
            return;
        }
        framelock = true;
    }

    public void DoInteract()
    {
        toDoInteract = true;
    }

    public bool ContainPick(InteractiveDef.PickableType type)
    {
        return pickables.Contains(type);
    }

    public void RemovePick(InteractiveDef.PickableType type)
    {
        pickables.Remove(type);
    }

    public void AddPick(InteractiveDef.PickableType type)
    {
        pickables.Add(type);
    }
}
