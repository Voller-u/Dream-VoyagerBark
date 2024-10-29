using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
public class EventManager : BaseManager<EventManager>
{
    public event UnityAction OnSceneLoadEvent;
    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
        OnSceneLoadEvent?.Invoke();
    }
    public void LoadScene(int sceneBuildIndex)
    {
        SceneManager.LoadScene(sceneBuildIndex);
        OnSceneLoadEvent?.Invoke();
    }
}
