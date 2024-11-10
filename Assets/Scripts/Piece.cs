using UnityEngine;
using DG.Tweening;


public class Piece : MonoBehaviour
{


    public int x;
    public int y;
    public Board board;
    public enum type
    {
        elephant,
        giraffe,
        hippo,
        monkey,
        panda,
        parrot,
        penquin,
        pig,
        rabbit,
        snake

    };

    public type pieceType; 
    public void Setup(int x_, int y_,Board board_)
    {
        x = x_;
        y = y_;
        board = board_;
    }

    public void Move(int desX, int desY)
    {
        transform.DOMove(new Vector3(desX, desY, -5f), 0.25f).SetEase(Ease.InOutCubic).onComplete = () =>
         {
             x = desX;
             y = desY;
         };
    }
    [ContextMenu("Test Mov")]
    public void MoveTest()
    {
        Move(0, 0);
    }

      
        }





