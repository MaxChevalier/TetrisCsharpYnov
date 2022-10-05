using System;
using System.Collections;
using System.Collections.Generic;

// classe pour les pièces
public class Piece
{
    // coordonnées des pixel de la pièce
    public List<int> cord1 = new List<int>();
    public List<int> cord2 = new List<int>();
    public List<int> cord3 = new List<int>();
    public List<int> cord4 = new List<int>();
    // couleur de la pièce

    int id;
    public SquareColor color;


    // possibilité formes de pièces
    public Piece(int nbtPiece)
    {
        switch (nbtPiece)
        {
            case 1:
                //    [][][][]
                cord1 = new List<int> { 0, 3 };
                cord2 = new List<int> { 0, 4 };
                cord3 = new List<int> { 0, 5 };
                cord4 = new List<int> { 0, 6 };
                color = SquareColor.LIGHT_BLUE;
                id=1;
                break;
            case 2:
                //    [][][]
                //      []
                cord1 = new List<int> { 0, 3 };
                cord2 = new List<int> { 0, 4 };
                cord3 = new List<int> { 0, 5 };
                cord4 = new List<int> { 1, 4 };
                color = SquareColor.DEEP_BLUE;
                id=2;
                break;
            case 3:
                //    [][][]
                //    []
                cord1 = new List<int> { 0, 3 };
                cord2 = new List<int> { 0, 4 };
                cord3 = new List<int> { 0, 5 };
                cord4 = new List<int> { 1, 3 };
                color = SquareColor.GREEN;
                id=3;
                break;
            case 4:
                //    [][]
                //    [][]
                cord1 = new List<int> { 0, 4 };
                cord2 = new List<int> { 0, 5 };
                cord3 = new List<int> { 1, 4 };
                cord4 = new List<int> { 1, 5 };
                color = SquareColor.ORANGE;
                id=4;
                break;
            case 5:
                //    [][]
                //      [][]
                cord1 = new List<int> { 0, 3 };
                cord2 = new List<int> { 0, 4 };
                cord3 = new List<int> { 1, 4 };
                cord4 = new List<int> { 1, 5 };
                color = SquareColor.PURPLE;
                id=5;
                break;
            case 6:
                //      [][]
                //    [][]
                cord1 = new List<int> { 1, 3 };
                cord2 = new List<int> { 1, 4 };
                cord3 = new List<int> { 0, 4 };
                cord4 = new List<int> { 0, 5 };
                color = SquareColor.YELLOW;
                id=6;
                break;
            case 7:
                //    [][][]
                //        []
                cord1 = new List<int> { 0, 3 };
                cord2 = new List<int> { 0, 4 };
                cord3 = new List<int> { 0, 5 };
                cord4 = new List<int> { 1, 5 };
                color = SquareColor.RED;
                id=7;
                break;


        }
    }



    public Piece(List<int> _cord1, List<int> _cord2, List<int> _cord3, List<int> _cord4, SquareColor _color)
    {
        cord1 = _cord1;
        cord2 = _cord2;
        cord3 = _cord3;
        cord4 = _cord4;
        color = _color;
    }

    //fonction pour tourner la pièce

    public void Turn(List<List<SquareColor>> colors, List<int> modif)
    {
        if (id != 4)
        {
            int minCordY = 22;
            int maxCordY = 0;
            int minCordX = 10;
            int maxCordX = 0;
            // on cherche les coordonnées min et max de la pièce
            foreach (List<int> cord in new List<List<int>> { cord1, cord2, cord3, cord4 })
            {
                if (cord[0] < minCordY)
                {
                    minCordY = cord[0];
                }
                if (cord[0] > maxCordY)
                {
                    maxCordY = cord[0];
                }
                if (cord[1] < minCordX)
                {
                    minCordX = cord[1];
                }
                if (cord[1] > maxCordX)
                {
                    maxCordX = cord[1];
                }
            }
            float midCordY = (minCordY + maxCordY) / 2;
            float midCordX = (minCordX + maxCordX) / 2;
            List<List<int>> newCords = new List<List<int>>();
            // on tourne les coordonnées de la pièce
            foreach (List<int> cord in new List<List<int>> { cord1, cord2, cord3, cord4 })
            {
                int newCordY = (int)(midCordY + (cord[1] - midCordX)) + modif[0];
                int newCordX = (int)(midCordX - (cord[0] - midCordY)) + modif[1];
                if (newCordY < 0 || newCordY > 21 || newCordX < 0 || newCordX > 9 || colors[newCordY][newCordX] != SquareColor.TRANSPARENT)
                {
                    if (modif[1] == 0 && modif[0] == 0)
                    {
                        Turn(colors, new List<int> { 0, 1 });
                        return;
                    }
                    else if (modif[1] == 1)
                    {
                        Turn(colors, new List<int> { 0, -1 });
                        return;
                    }
                    else if (modif[1] == -1)
                    {
                        Turn(colors, new List<int> { 0, 2 });
                        return;
                    }
                    else if (modif[1] == 2)
                    {
                        Turn(colors, new List<int> { -1, 0 });
                        return;
                    }
                    else if (modif[0] == -1)
                    {
                        Turn(colors, new List<int> { 1, 0 });
                        return;
                    }
                    else
                    {
                        return;
                    }
                }
                newCords.Add(new List<int> { newCordY, newCordX });
            }
            // on applique les nouvelles coordonnées
            cord1 = newCords[0];
            cord2 = newCords[1];
            cord3 = newCords[2];
            cord4 = newCords[3];
        }
    }
}