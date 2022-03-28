using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    public static Manager instance;

    [Header("Manager")]
    public SoundManager soundManager;
    public InvenManager invenManager;
    public QuestManager questManager;
    public SettingManager settingManager;

    private void Awake()
    {
        if (instance != this)
            instance = this;
    }
}
