using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextController : MonoBehaviour
{
    // Start is called before the first frame update

    public Text text;
    public int contador;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        text.text = contador.ToString();
    }
}
