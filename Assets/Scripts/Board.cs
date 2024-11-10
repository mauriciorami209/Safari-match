using System;
using UnityEngine;


public class Board : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public int width;
    public int heigth;
    private float offsetcam = 0.5f;
    public GameObject tileObject;

    public float cameraSizeOffset;
    public float cameraVerticalOffset;

    public GameObject[] availablePieces;
    
    void Start()
    {
        SetupBoard();
        PositionCamera();
        SetupPieces();
        
    }

   

    private void SetupPieces()
    {
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < heigth; y++)
            {
                var selectedPiece = availablePieces[UnityEngine.Random.Range(0, availablePieces.Length)];
                var o = Instantiate(selectedPiece, new Vector3(x, y, -5), Quaternion.identity);
                o.transform.parent = transform;
                o.GetComponent<Piece>()?.Setup(x, y, this);
            }
        }
    }

    private void PositionCamera()
    {
        float newPosX = (float)width / 2;
        float newPosY = (float)heigth / 2;
        Camera.main.transform.position = new Vector3(newPosX - offsetcam, newPosY - offsetcam + cameraVerticalOffset, -10f);
        float horizontal = width + 1;
        float vertical = (heigth / 2) + 1;
        Camera.main.orthographicSize = horizontal > vertical ? horizontal + cameraSizeOffset : vertical;

    }

    private void SetupBoard()
    {
        for (int x=0; x<width; x++)
        {
            for (int y=0; y< heigth; y++)
            {
                var o = Instantiate(tileObject, new Vector3(x, y, -5), Quaternion.identity);
                o.transform.parent = transform;
                o.GetComponent<Tile>()?.Setup(x, y, this);
            }
        }
    }

   


}
