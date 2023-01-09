using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FondoScript : MonoBehaviour
{
    // Start is called before the first frame update

    public float MovSpeed = 1f;

    public float Offset;

    private Vector2 Position0;

    private float Position1;
    void Start()
    {
        Position0 = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Position1 = Mathf.Repeat (Time.time * MovSpeed, Offset);

        transform.position = Position0 + Vector2.right * Position1;
    }
}
