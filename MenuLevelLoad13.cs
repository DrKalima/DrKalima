using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuLevelLoad : MonoBehaviour
{
    public Button startJourny;
    public Button exitGame;
    
    // Start is called before the first frame update
    void Start()
    {
        Button btn = startJourny.GetComponent<Button>();
        btn.onClick.AddListener(goToFirstLevel);

        Button buttn = exitGame.GetComponent<Button>();
        buttn.onClick.AddListener(exit);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void goToFirstLevel()
    {
        SceneManager.LoadScene("Introduction", LoadSceneMode.Single);
    }
    private void exit()
    {
        Application.Quit();
    }
}
