using UnityEngine;
using UnityEngine.SceneManagement;

public class GetModel : MonoBehaviour
{

    private GameObject echoParent;
    private GameObject[] models;

    [SerializeField]    
    AudioClip[] barks;
    public AudioClip currentBark;

    private void Awake()
    {
        echoParent = GameObject.FindGameObjectWithTag("echo");
        if (echoParent != null)
        {
            echoParent.transform.SetParent(this.transform);
            //echoParent.transform.localScale = new Vector3(10f, 10f, 10f);
            //echoParent.transform.localPosition = new Vector3(0f, 0f, -2f);
        }
    }

    public void SetModels()
    {
        ModelSelection ms = echoParent.GetComponent<ModelSelection>();
        models = ms.models;

        currentBark = barks[ms.index];

        for (int i = 0; i < models.Length; i++)
        {
            if (i != ms.index)
                models[i].GetComponentInChildren<Renderer>().enabled = false;
            else
                models[i].GetComponentInChildren<Renderer>().enabled = true;

        }
    }

    public void ReSelect(){
        SceneManager.LoadScene("CharacterSelection");
    }
    public void Quitapp(){
        Application.Quit();
    }
}