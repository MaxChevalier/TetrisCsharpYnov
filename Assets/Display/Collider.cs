using System;
using System.Collections;
using System.Collections.Generic;

class Collider
{

    public Collider() { }

    // test si la piece peut bouger en fonction de move
    public bool IsColliding(Piece piece, List<List<SquareColor>> colors, List<int> move)
    {
        foreach (List<int> cord in new List<List<int>> { piece.cord1, piece.cord2, piece.cord3, piece.cord4 })
        {
            // test si la piece est dans le tableau
            if (cord[0] + move[0] < 0 || cord[0] + move[0] > 21 || cord[1] + move[1] < 0 || cord[1] + move[1] > 9)
            {
                UnityEngine.Debug.Log("out of range");
                return true;
            }
            // test si la piece est sur une autre piece

            //test si le carré est sur lui-meme
            bool isSame = false;
            foreach (List<int> cord2 in new List<List<int>> { piece.cord1, piece.cord2, piece.cord3, piece.cord4 })
            {
                if (cord[0] + move[0] == cord2[0] && cord[1] + move[1] == cord2[1])
                {
                    isSame = true;
                }
            }

            // test si le carré est sur une autre piece
            if (!isSame && colors[cord[0] + move[0]][cord[1] + move[1]] != SquareColor.TRANSPARENT && colors[cord[0] + move[0]][cord[1] + move[1]] != SquareColor.PREVIEW)
            {
                UnityEngine.Debug.Log("Sur une autre piece");
                return true;
            }


        }
        return false;
    }
}