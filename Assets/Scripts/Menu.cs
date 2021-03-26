using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public Button Play_Button;
    public Button Quit_Button;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
   
    }
    
    public void Play_Game()
    {
        SceneManager.LoadScene(1);
    }

    public void Quit_Game()
    {
        Application.Quit();
    }

}
