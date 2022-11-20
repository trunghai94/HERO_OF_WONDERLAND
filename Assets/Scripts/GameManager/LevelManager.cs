using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;



public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance;
    [SerializeField] private GameObject _LoaderCanvas;
    [SerializeField] private Slider _progreeBar;
    
    private float _target;

    void Awake()
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


    public async void LoadScene(string SceneName)
    {
        _target = 0;
        _progreeBar.value = 0;
        var scene = SceneManager.LoadSceneAsync(SceneName);
        //scene.allowSceneActivation = false;

        _LoaderCanvas.SetActive(true);

        do
        {
            await System.Threading.Tasks.Task.Delay(100);
            _target = scene.progress;
           
        } while (scene.progress < 0.9f);

        await System.Threading.Tasks.Task.Delay(1000);
        //scene.allowSceneActivation = true;
        StartCoroutine(DelayLoadding(scene.progress));
    }
    // Update is called once per frame
    void Update()
    {
        _progreeBar.value = Mathf.MoveTowards(_progreeBar.value, _target, 3 * Time.deltaTime);
    }
    IEnumerator DelayLoadding(float time)
    {
        yield return new WaitForSeconds(time);
        _LoaderCanvas.SetActive(false);
    }
}
