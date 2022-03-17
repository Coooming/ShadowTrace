using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickable : Interactable
{
    public bool totalKilled = false;
    public InteractiveDef.PickableType PickType;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    override public void BeInteracted(InteractController controller) 
    {
        if (totalKilled)
        {
            Destroy(transform.parent.gameObject);
            //transform.parent.gameObject.SetActive(false);
        }
        else
        {
            for (int i = 0; i < transform.parent.childCount; ++i)
            {
                if (transform.parent.GetChild(i).gameObject.name != "Trigger")
                    transform.parent.GetChild(i).gameObject.SetActive(false);
            }
            transform.parent.GetComponent<Collider>().enabled = false;
        }
        controller.AddPick(PickType);
        if (GetComponentInParent<Placable>())
        {
            GetComponentInParent<Placable>().placed = false;
        }
    }
}
