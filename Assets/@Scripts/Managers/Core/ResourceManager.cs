using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using System;
using Object = UnityEngine.Object;

public class ResourceManager 
{
    Dictionary<string, UnityEngine.Object> _resources = new Dictionary<string, UnityEngine.Object>();
    //리소스들을 메모리에 보관할 창고

    public T Load<T>(string key) where T : Object 
    {
        if (_resources.TryGetValue(key, out Object resource)) //리소스 저장소에서 리소스 찾기
            return resource as T;

        return null;
    }

    public GameObject Instantiate(string key, Transform parent = null, bool pooling  = false)
    {
        GameObject prefab = Load<GameObject>(key); //로드가 성공하면 해당 오브젝트 프리펩을 만든다
        if(prefab == null)
        {
            Debug.Log($"Failed Prefab! {key}");
            return null;
        }

        GameObject go = Object.Instantiate(prefab, parent); //만든 프리펩을 생성한다
        go.name = prefab.name;
        return go;
    }

    public void Destroy(GameObject go)
    {
        if (go == null)
            return;

        Object.Destroy(go);
    }


    #region 어드레서블
    public void LoadAsync<T>(string key, Action<T> callback = null) where T : UnityEngine.Object //로드가 완료되면 결과 리소스를 콜백함수로 전달
    {
        if(_resources.TryGetValue(key, out Object resource))
        {
            callback?.Invoke(resource as T);
            return;
        }

        var asyncOperations = Addressables.LoadAssetAsync<T>(key); //비동기 방식 시작
// AsyncOperationHandle<T> asyncOperations
        //완료되면 호출될 함수를 입력하되 결과값을 받을 AsyncOperationHandle<T> op객체를 하나 만들어줘서 람다식으로 풀이
        asyncOperations.Completed += (op) => 
        {
            _resources.Add(key, op.Result); //op.Result는 asyncOperations의 결과값으로 해석해도 됨
            callback?.Invoke(op.Result);
        };
    }

    public void LoadAAllAsync<T>(string label, Action<string, int, int> callback = null) where T : UnityEngine.Object //콜백함수 매개변수 인자 3개(자율적으로 설정)
    {
        var opHandle = Addressables.LoadResourceLocationsAsync(label, typeof(T));
        //해당 label에 있는 리소스들을 전부 로드하고 이벤트 핸들러 생성

        opHandle.Completed += (op) =>
        //완료되면 op.result은 전부 로드한 리소스들을 리스트화시킨 것
        {
            int loadCount = 0;
            int totalCount = op.Result.Count;

            foreach(var result in op.Result)
            {
                LoadAsync<T>(result.PrimaryKey, (obj) => //콜백함수의 인자가 T이기에 T obj 객체 생성
                {
                    loadCount++;
                    callback?.Invoke(result.PrimaryKey, loadCount, totalCount); //콜백함수는 매개변수가 string int int 이기에 3개 설정
                });
            }
        };
    }
    #endregion
}
