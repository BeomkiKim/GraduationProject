using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    [Header("Frame")]
    public GameObject questFrame;
    public GameObject bagFrame;
    public GameObject slotBox;

    public void openQuest()
    {
        bagFrame.SetActive(true);
    }
}
