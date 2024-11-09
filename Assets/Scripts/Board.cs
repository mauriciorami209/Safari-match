using System;
using UnityEngine;

public class Board : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public int width;
    public int heitht;
    public GameObject tileObject;
    void Start()
    {
        SetupBoard();
        Debug.Log("inicia el programa");
    }

    private void SetupBoard()
    {
        Debug.Log("llama al metodo");
        for (int x=0; x<width; x++)
        {
            for (int y=0; y<heitht; y++)
            {
                var o = Instantiate(tileObject, new Vector3(x, y, -5), Quaternion.identity);
                o.transform.parent = transform;
                Debug.Log("cuadrito");
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
