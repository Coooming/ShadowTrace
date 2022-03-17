using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinPoint : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Shadow")
        {
            TransmittedData.lastCharacterTrack = null;
            TransmittedData.lastShadowTrack = null;
            LevelManager.Instance().NextLevel();
        }
    }
}
