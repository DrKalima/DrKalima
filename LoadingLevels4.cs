using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadingLevels : MonoBehaviour
{
    public Button beginIntroductionLevel;    

    public bool sampleSceneBegin = false;
    void Start()
    {
        Button btn = beginIntroductionLevel.GetComponent<Button>();
        btn.onClick.AddListener(beginIntroductionLevelClicked);
    }
  
    void Update()
    {
        
    }

    private void beginIntroductionLevelClicked()
    {
        if (!sampleSceneBegin)
        {
            sampleSceneBegin = true;
            SceneManager.LoadScene("Puzzle 1", LoadSceneMode.Single);
        }
    }
}
