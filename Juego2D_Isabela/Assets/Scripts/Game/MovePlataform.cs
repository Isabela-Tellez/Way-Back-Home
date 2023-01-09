using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlataform : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject obj;

    public Transform PuntoA;
    public Transform PuntoB;

    public float Vel;

    public Vector3 Move;

    void Start()
    {
        Move = PuntoB.position;
    }

    // Update is called once per frame
    void Update()
    {
        obj.transform.position = Vector3.MoveTowards(obj.transform.position, Move, Vel * Time.deltaTime);

        if (obj.transform.position == PuntoB.position)
        {
            Move = PuntoA.position;
        }

        if (obj.transform.position == PuntoA.position)
        {
            Move = PuntoB.position;
        }
    }
}
