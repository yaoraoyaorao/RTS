/*-----------------------------------------------
 // 作    者：RCY
 // 文 件 名：LoadScene
 // 创建日期：2022/3/2 9:34:02
 // 功能描述：场景加载
 // 修改日期：
 // 修改描述：
-----------------------------------------------*/

using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class LoadSceneSetting:Singleton<LoadSceneSetting>
{
    public void LoadScene(string sceneName,UnityAction action = null)
    {
        SceneManager.LoadScene(sceneName);
        action?.Invoke();
    }


    public void LoadSceneAsync(string sceneName,UnityAction action = null)
    {
        //开启协程
        MonoManager.Instance.StartCoroutine(ReallyLoadSceneAsync(sceneName, action));
    }

    private IEnumerator ReallyLoadSceneAsync(string scene, UnityAction action = null)
    {
        AsyncOperation ao = SceneManager.LoadSceneAsync(scene);
        while (!ao.isDone)
        {
            //进度条
            EventManager.Instance.EventTrigger<float>("Loading", ao.progress);
            yield return ao.progress;
            
        }
        action?.Invoke();
    }
}
