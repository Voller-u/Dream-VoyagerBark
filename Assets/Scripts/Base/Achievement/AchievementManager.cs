using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

/// <summary>
/// �ɾ�ϵͳ
/// </summary>
public class AchievementManager : MonoBehaviour
{
    [SerializeField]
    private AchievementCenter achievementCenter;

    public string path = Application.streamingAssetsPath + "/Achievement/achievement";
    private void Awake()
    {
        
        DontDestroyOnLoad(gameObject);

        Init();

        for (int i=0;i<achievementCenter.achievementList.Count;i++)
        {
            achievementCenter.achievementList[i].AchievementListener();
        }

        EventManager.Instance.OnDestroySaveEvent +=()=> Tools.SaveClass<AchievementCenter>(achievementCenter, path);
    }

    public void Init()
    {
        try
        {
            achievementCenter = Tools.ReadClass<AchievementCenter>(path);
        }
        catch(FileNotFoundException)
        {
            Debug.Log("�ļ������ڣ����´����ɾ�");
            InitAchievements();
        }
    }

    public void InitAchievements()
    {
        achievementCenter.achievementList.Add(
            new GoldAchievement(
                "�ó��Ľ��",
                "�ۼƻ��114514���",
                114514,
                0
            ));
    }
    private void OnApplicationQuit()
    {
        
    }
}
