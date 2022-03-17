using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Killer : MonoBehaviour
{
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.name == "Character" || other.gameObject.name == "Shadow")
        {
            GameObject.Find("TrackDrawer").GetComponent<Track>().BackupTrack();
            LevelManager.Instance().Retry(false);
        }
    }
}
