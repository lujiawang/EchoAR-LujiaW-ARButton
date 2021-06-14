using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GetModel : MonoBehaviour
{

    private GameObject echoParent;
    private GameObject[] models;
    private int index;

    public Text ModelName;

    private ModelSelection ms;
    
    Transform target;

    private void Awake()
    {
        echoParent = GameObject.FindGameObjectWithTag("echo");
        if (echoParent != null)
        {
            echoParent.transform.SetParent(this.transform);
            //echoParent.transform.localScale = new Vector3(10f, 10f, 10f);
            echoParent.transform.localPosition = new Vector3(0f, 0f, 0f);
        }
    }

    public void SetModels()
    {
        if (ms == null){
            ms = echoParent.GetComponent<ModelSelection>();
            models = ms.models;
            index = ms.index;
            Debug.Log(index);
        }            
        

        //currentName = models[ms.index].name;

        for (int i = 0; i < models.Length; i++)
        {
            if (i != index)
                models[i].GetComponentInChildren<Renderer>().enabled = false;
            else
            {
                RemoteTransformations behav = models[index].GetComponent<RemoteTransformations>();
                behav.EchoPos = false;
                behav.EchoScale = false;

                models[i].transform.localPosition = new Vector3(0f, 0f, 0f);
                models[i].transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
                
                models[i].GetComponentInChildren<Renderer>().enabled = true;
                target = models[i].transform;
                ModelName.text = models[i].name;
            }

        }
    }


    public void DisappearModels(){
        for (int i = 0; i < models.Length; i++)
        {
            models[i].GetComponentInChildren<Renderer>().enabled = false;
            ModelName.text = "target not found";
        }
    }

    public void ReSelect()
    {
        SceneManager.LoadScene("CharacterSelection");
    }
    public void Quitapp()
    {
        Application.Quit();
    }


    public void OnDrawGizmosSelected()
    {
        if (target != null)
        {
            // Draws a blue line from this transform to the target
            Gizmos.color = Color.blue;
            Gizmos.DrawLine(transform.position, target.position);
        }
    }
}