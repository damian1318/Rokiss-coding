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
    public static GameManager Game { get { return Instance?._game; } } //전역 인스턴스Game //?.란 NULL 체크
    public static ObjectManager Object { get { return Instance?._object; } } //전역 인스턴스Object
    public static PoolManager Pool { get { return Instance?._pool; } } //전역 인스턴스 Pool
    #endregion

    #region Core
    DataManager _data = new DataManager();
    ResourceManager _resource = new ResourceManager();
    SceneManager _scene = new SceneManager();
    SoundManager _sound = new SoundManager();
    UIManager _ui = new UIManager();
    public static DataManager Data { get { return Instance?._data; } } //전역 인스턴스 Data
    public static ResourceManager Resource { get { return Instance?._resource; } } //전역 인스턴스 Resource
    public static SceneManager Scene { get { return Instance?._scene; } } //전역 인스턴스 Scene
    public static SoundManager Sound { get { return Instance?._sound; } } //전역 인스턴스 Sound
    public static UIManager UI { get { return Instance?._ui; } } //전역 인스턴스 UI
    #endregion
    public static Managers Instance
    {
        get
        {
            if(s_init == false) //매니저 인스턴스를 처음 생성할때
            {
                s_init = true;

                GameObject go = GameObject.Find("@Managers");
                if(go == null)
                {
                    go = new GameObject() { name = "@Managers" };
                    go.AddComponent<Managers>();
                }

                DontDestroyOnLoad(go); //삭제하지 말고 그냥 들고 있어라
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
