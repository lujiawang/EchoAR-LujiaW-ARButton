using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ModelSelection : MonoBehaviour
{
    
    [SerializeField]
    private Transform EchoRoot;
    
    public GameObject[] models;

    public int index;
    private bool initialized;
    
    private static ModelSelection instance;
    private void Awake() {
        DontDestroyOnLoad(this.gameObject);  

        if (instance == null) {
            instance = this;
        } else {
            Destroy(this.gameObject);
        }  
    }


    // Start is called before the first frame update
    void Start()
    {        
        initialized = false;
        index = 0;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!initialized && EchoRoot.transform.childCount > 0){
            int totalCount = EchoRoot.transform.childCount;
            models = new GameObject[totalCount];
            for(int i = 0; i < totalCount; i++){
                models[i] = EchoRoot.transform.GetChild(i).gameObject;
                models[i].GetComponentInChildren<Renderer>().enabled = false;
            }
            initialized = true;
            
            index = 0;
            InitialModel();
        }
    }

    private void InitialModel(){
        models[index].GetComponentInChildren<Renderer>().enabled = true;
    }

    public void Right()
    {
        models[index].GetComponentInChildren<Renderer>().enabled = false;
        index = (index + 1) % models.Length;
        InitialModel();
    }

    public void Left()
    {
        models[index].GetComponentInChildren<Renderer>().enabled = false;
        index = (index + models.Length - 1) % models.Length;
        InitialModel();
    }

    public void Select()
    {
        RemoteTransformations behav = models[index].GetComponent<RemoteTransformations>();
        behav.Spinning = false;

        models[index].transform.rotation = new Quaternion(0, 180f, 0, 0);

        SceneManager.LoadScene("Virtual Button");

    }

}
