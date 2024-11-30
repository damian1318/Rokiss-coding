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
    //���ҽ����� �޸𸮿� ������ â��

    public T Load<T>(string key) where T : Object 
    {
        if (_resources.TryGetValue(key, out Object resource)) //���ҽ� ����ҿ��� ���ҽ� ã��
            return resource as T;

        return null;
    }

    public GameObject Instantiate(string key, Transform parent = null, bool pooling  = false)
    {
        GameObject prefab = Load<GameObject>(key); //�ε尡 �����ϸ� �ش� ������Ʈ �������� �����
        if(prefab == null)
        {
            Debug.Log($"Failed Prefab! {key}");
            return null;
        }

        GameObject go = Object.Instantiate(prefab, parent); //���� �������� �����Ѵ�
        go.name = prefab.name;
        return go;
    }

    public void Destroy(GameObject go)
    {
        if (go == null)
            return;

        Object.Destroy(go);
    }


    #region ��巹����
    public void LoadAsync<T>(string key, Action<T> callback = null) where T : UnityEngine.Object //�ε尡 �Ϸ�Ǹ� ��� ���ҽ��� �ݹ��Լ��� ����
    {
        if(_resources.TryGetValue(key, out Object resource))
        {
            callback?.Invoke(resource as T);
            return;
        }

        var asyncOperations = Addressables.LoadAssetAsync<T>(key); //�񵿱� ��� ����
// AsyncOperationHandle<T> asyncOperations
        //�Ϸ�Ǹ� ȣ��� �Լ��� �Է��ϵ� ������� ���� AsyncOperationHandle<T> op��ü�� �ϳ� ������༭ ���ٽ����� Ǯ��
        asyncOperations.Completed += (op) => 
        {
            _resources.Add(key, op.Result); //op.Result�� asyncOperations�� ��������� �ؼ��ص� ��
            callback?.Invoke(op.Result);
        };
    }

    public void LoadAAllAsync<T>(string label, Action<string, int, int> callback = null) where T : UnityEngine.Object //�ݹ��Լ� �Ű����� ���� 3��(���������� ����)
    {
        var opHandle = Addressables.LoadResourceLocationsAsync(label, typeof(T));
        //�ش� label�� �ִ� ���ҽ����� ���� �ε��ϰ� �̺�Ʈ �ڵ鷯 ����

        opHandle.Completed += (op) =>
        //�Ϸ�Ǹ� op.result�� ���� �ε��� ���ҽ����� ����Ʈȭ��Ų ��
        {
            int loadCount = 0;
            int totalCount = op.Result.Count;

            foreach(var result in op.Result)
            {
                LoadAsync<T>(result.PrimaryKey, (obj) => //�ݹ��Լ��� ���ڰ� T�̱⿡ T obj ��ü ����
                {
                    loadCount++;
                    callback?.Invoke(result.PrimaryKey, loadCount, totalCount); //�ݹ��Լ��� �Ű������� string int int �̱⿡ 3�� ����
                });
            }
        };
    }
    #endregion
}
