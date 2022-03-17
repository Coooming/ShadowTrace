using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShitCode : Pickable
{
    public Pickable WhatSupMan;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    override public void BeInteracted(InteractController controller)
    {
        if (totalKilled)
        {
            Destroy(WhatSupMan.transform.parent.gameObject);
            //transform.parent.gameObject.SetActive(false);
        }
        else
        {
            for (int i = 0; i < WhatSupMan.transform.parent.childCount; ++i)
            {
                if (WhatSupMan.transform.parent.GetChild(i).gameObject.name != "Trigger")
                    WhatSupMan.transform.parent.GetChild(i).gameObject.SetActive(false);
            }
            WhatSupMan.transform.parent.GetComponent<Collider>().enabled = false;
        }
        controller.AddPick(PickType);
        if (WhatSupMan.GetComponentInParent<Placable>())
        {
            WhatSupMan.GetComponentInParent<Placable>().placed = false;
        }
    }
}
