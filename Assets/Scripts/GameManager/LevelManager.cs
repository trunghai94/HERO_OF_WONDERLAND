using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance;

    [SerializeField] private GameObject _loaderCanvas;
    [SerializeField] private Slider _progreeBar;
    private float _target;


    private void Awake()
    {
        if(Instance==null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        
    }
    public async void LoaderScene(string sceneName)
    {
        _target = 0;
        _progreeBar.value = 0;
        var scene = SceneManager.LoadSceneAsync(sceneName);
        //scene.allowSceneActivation = false;
        _loaderCanvas.SetActive(true);
        do
        {
            await System.Threading.Tasks.Task.Delay(100);
            _target = scene.progress;

        } while (scene.progress < 0.9f);

        await System.Threading.Tasks.Task.Delay(1000);
        //scene.allowSceneActivation = true;
        _loaderCanvas.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        _progreeBar.value = Mathf.MoveTowards(_progreeBar.value, _target, 3 * Time.deltaTime);
    }
}
