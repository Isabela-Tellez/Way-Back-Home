using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DieController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Reiniciar()
    {
        SceneManager.LoadScene("Nivel 1º");
    }

    public void Quit()
    {
        SceneManager.LoadScene("MenuInical");
    }

    public void LevelMenu()
    {
        print("Menu Niveles");
    }
}
