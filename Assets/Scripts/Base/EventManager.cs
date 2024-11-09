using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
public class EventManager : BaseManager<EventManager>
{
    public event UnityAction OnSceneLoadEvent;
    public event UnityAction<string> OnSceneLoadEvent2;
    public void LoadScene(string sceneName)
    {
        OnSceneLoadEvent?.Invoke();
        OnSceneLoadEvent2?.Invoke(sceneName);
        SceneManager.LoadScene(sceneName);
    }
    public void LoadScene(int sceneBuildIndex)
    {
        SceneManager.LoadScene(sceneBuildIndex);
        OnSceneLoadEvent?.Invoke();
    }

    public event UnityAction<Role> OnPropertyChangeEvent;
    public void OnPropertyChange(Role role)
    {
        OnPropertyChangeEvent?.Invoke(role);
    }

    public event UnityAction OnDestroySaveEvent;
    public void OnDestroySave()
    {
        OnDestroySaveEvent?.Invoke();
    }

    /// <summary>
    /// �ɾ����ʱ���õ��¼�
    /// </summary>
    public event UnityAction<Achievement> OnAchievementCompletedEvent;
    public void OnAchievementCompleted(Achievement achievement)
    {
        OnAchievementCompletedEvent?.Invoke(achievement);
    }

    /// <summary>
    /// ��ý��ʱ���õ��¼�
    /// </summary>
    public event UnityAction<int> OnGoldObtainEvent;
    public void OnGoldObtain(int obtainNum)
    {
        Debug.Log("��ý���¼�����");
        OnGoldObtainEvent?.Invoke(obtainNum);
    }

    public event UnityAction<Card> OnCardPlayEvent;
    public void OnCardPlay(Card card)
    {
        OnCardPlayEvent?.Invoke(card);
    }

    public event UnityAction OnSpecialPowerConsumeEvent;
    public void OnSpecialPowerConsume()
    {
        OnSpecialPowerConsumeEvent?.Invoke();
    }
}
