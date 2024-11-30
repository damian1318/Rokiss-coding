using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Managers : MonoBehaviour
{

    static Managers s_instance;
    static bool s_init = false;

    #region Contents
    GameManager _game = new GameManager();
    ObjectManager _object = new ObjectManager();
    PoolManager _pool = new PoolManager();
    public static GameManager Game { get { return Instance?._game; } } //���� �ν��Ͻ�Game //?.�� NULL üũ
    public static ObjectManager Object { get { return Instance?._object; } } //���� �ν��Ͻ�Object
    public static PoolManager Pool { get { return Instance?._pool; } } //���� �ν��Ͻ� Pool
    #endregion

    #region Core
    DataManager _data = new DataManager();
    ResourceManager _resource = new ResourceManager();
    SceneManager _scene = new SceneManager();
    SoundManager _sound = new SoundManager();
    UIManager _ui = new UIManager();
    public static DataManager Data { get { return Instance?._data; } } //���� �ν��Ͻ� Data
    public static ResourceManager Resource { get { return Instance?._resource; } } //���� �ν��Ͻ� Resource
    public static SceneManager Scene { get { return Instance?._scene; } } //���� �ν��Ͻ� Scene
    public static SoundManager Sound { get { return Instance?._sound; } } //���� �ν��Ͻ� Sound
    public static UIManager UI { get { return Instance?._ui; } } //���� �ν��Ͻ� UI
    #endregion
    public static Managers Instance
    {
        get
        {
            if(s_init == false) //�Ŵ��� �ν��Ͻ��� ó�� �����Ҷ�
            {
                s_init = true;

                GameObject go = GameObject.Find("@Managers");
                if(go == null)
                {
                    go = new GameObject() { name = "@Managers" };
                    go.AddComponent<Managers>();
                }

                DontDestroyOnLoad(go); //�������� ���� �׳� ��� �־��
                s_instance = go.GetComponent<Managers>();
            }
            return s_instance;
        }
    }
    void Start()
    {
        
    }
    void Update()
    {
        
    }
}
