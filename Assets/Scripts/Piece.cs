using UnityEngine;

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

      
        }





