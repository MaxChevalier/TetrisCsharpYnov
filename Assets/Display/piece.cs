using System;
using System.Collections;
using System.Collections.Generic;

public class Piece {
    public List<int> cord1 = new List<int>();
    public List<int> cord2 = new List<int>();
    public List<int> cord3 = new List<int>();
    public List<int> cord4 = new List<int>();
    public SquareColor color = SquareColor.TRANSPARENT;

    Random rand = new Random();

    public Piece(){
        int random = rand.Next(1, 8);
        switch (random){
            case 1:
            //    [][][][]
                cord1 = new List<int> { 0, 3 };
                cord2 = new List<int> { 0, 4 };
                cord3 = new List<int> { 0, 5 };
                cord4 = new List<int> { 0, 6 };
                color = SquareColor.LIGHT_BLUE;
                break;
            case 2:
            //    [][][]
            //      []
                cord1 = new List<int> { 0, 3 };
                cord2 = new List<int> { 0, 4 };
                cord3 = new List<int> { 0, 5 };
                cord4 = new List<int> { 1, 4 };
                color = SquareColor.DEEP_BLUE;
                break;
            case 3:
            //    [][][]
            //    []
                cord1 = new List<int> { 0, 3 };
                cord2 = new List<int> { 0, 4 };
                cord3 = new List<int> { 0, 5 };
                cord4 = new List<int> { 1, 3 };
                color = SquareColor.GREEN;
                break;
            case 4:
            //    [][]
            //    [][]
                cord1 = new List<int> { 0, 4 };
                cord2 = new List<int> { 0, 5 };
                cord3 = new List<int> { 1, 4 };
                cord4 = new List<int> { 1, 5 };
                color = SquareColor.ORANGE;
                break;
            case 5:
            //    [][]
            //      [][]
                cord1 = new List<int> { 0, 3 };
                cord2 = new List<int> { 0, 4 };
                cord3 = new List<int> { 1, 4 };
                cord4 = new List<int> { 1, 5 };
                color = SquareColor.PURPLE;
                break;
            case 6:
            //      [][]
            //    [][]
                cord1 = new List<int> { 1, 3 };
                cord2 = new List<int> { 1, 4 };
                cord3 = new List<int> { 0, 4 };
                cord4 = new List<int> { 0, 5 };
                color = SquareColor.YELLOW;
                break;
            case 7:
            //    [][][]
            //        []
                cord1 = new List<int> { 0, 3 };
                cord2 = new List<int> { 0, 4 };
                cord3 = new List<int> { 0, 5 };
                cord4 = new List<int> { 1, 5 };
                color = SquareColor.RED;
                break;

        }
    }
}