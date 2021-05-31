using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class InputSaving : MonoBehaviour {

    public static string APIKey;
    
    [SerializeField]
    private Text input;

    private void Awake() {
        DontDestroyOnLoad(this);
    }

    public void SaveKey(){
        APIKey = input.text;

        SceneManager.LoadScene("CharacterSelection");
    }
}