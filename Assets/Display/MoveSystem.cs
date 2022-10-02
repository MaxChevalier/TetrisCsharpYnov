using System;
using System.Collections;
using System.Collections.Generic;

class MoveSystem
{

    private Piece PreviewPiece = new Piece(new List<int>(){0,0},new List<int>(){0,0},new List<int>(){0,0},new List<int>(){0,0},SquareColor.TRANSPARENT);
    private Collider collider;
    private GameManager gameManager;

    public MoveSystem()
    {
        collider = new Collider();
    }

    public MoveSystem(Collider collider, GameManager gameManager)
    {
        this.collider = collider;
        this.gameManager = gameManager;
    }

    public void rushPiece(Piece piece, List<List<SquareColor>> colors, PiecePosed PiecePosed)
    {
        while (!collider.isPosed(piece,colors))
        {
            DownPiece(piece,colors);
        }
        PiecePosed();
    }

    public void leftPiece(Piece piece, List<List<SquareColor>> colors)
    {
        if (!collider.isCollidingLeft(piece,colors))
        {
            gameManager.RemovePieceColors(piece,colors);
            piece.cord1[1] = piece.cord1[1] - 1;
            piece.cord2[1] = piece.cord2[1] - 1;
            piece.cord3[1] = piece.cord3[1] - 1;
            piece.cord4[1] = piece.cord4[1] - 1;
            gameManager.SetPieceColors(piece,colors);
        }
    }

    public void rightPiece(Piece piece, List<List<SquareColor>> colors)
    {
        if (!collider.isCollidingRight(piece,colors))
        {
            gameManager.RemovePieceColors(piece,colors);
            piece.cord1[1] = piece.cord1[1] + 1;
            piece.cord2[1] = piece.cord2[1] + 1;
            piece.cord3[1] = piece.cord3[1] + 1;
            piece.cord4[1] = piece.cord4[1] + 1;
            gameManager.SetPieceColors(piece,colors);
        }
    }

    public void DownPiece(Piece piece, List<List<SquareColor>> colors)
    {
        
        gameManager.RemovePieceColors(piece,colors);
        piece.cord1[0] = piece.cord1[0] + 1;
        piece.cord2[0] = piece.cord2[0] + 1;
        piece.cord3[0] = piece.cord3[0] + 1;
        piece.cord4[0] = piece.cord4[0] + 1;
        gameManager.SetPieceColors(piece,colors);
    }
    //preview est une fonction qui permet de voir ou la piece va tomber
    // public void Preview(Piece piece, List<List<SquareColor>> colors)
    // {
    //     gameManager.RemovePieceColors(PreviewPiece,colors);
    //     PreviewPiece = new Piece(piece.cord1,piece.cord2,piece.cord3,piece.cord4,SquareColor.PREVIEW);
    //     // previewListeCord = new List<List<int>>(){PreviewPiece.cord1,PreviewPiece.cord2,PreviewPiece.cord3,PreviewPiece.cord4};
    //     // pieceListeCord = new List<List<int>>(){piece.cord1,piece.cord2,piece.cord3,piece.cord4};

    //     while ()
    //     {        
    //         UnityEngine.Debug.Log("test");
    //         gameManager.RemovePieceColors(PreviewPiece,colors);
    //         PreviewPiece.cord1[0] = PreviewPiece.cord1[0] + 1;
    //         PreviewPiece.cord2[0] = PreviewPiece.cord2[0] + 1;
    //         PreviewPiece.cord3[0] = PreviewPiece.cord3[0] + 1;
    //         PreviewPiece.cord4[0] = PreviewPiece.cord4[0] + 1;
    //         if(colors[PreviewPiece.cord1[0]][PreviewPiece.cord1[1]] == SquareColor.TRANSPARENT && !(PreviewPiece.cord1[0] == piece.cord1[0] && PreviewPiece.cord1[1] == piece.cord1[1]) && !(PreviewPiece.cord1[0] == piece.cord2[0] && PreviewPiece.cord1[1] == piece.cord2[1]) && !(PreviewPiece.cord1[0] == piece.cord3[0] && PreviewPiece.cord1[1] == piece.cord3[1]) && !(PreviewPiece.cord1[0] == piece.cord4[0] && PreviewPiece.cord1[1] == piece.cord4[1]))
    //         {
    //             UnityEngine.Debug.Log("1");
    //             colors[PreviewPiece.cord1[0]][PreviewPiece.cord1[1]] = SquareColor.PREVIEW;
    //         }
    //         if(colors[PreviewPiece.cord2[0]][PreviewPiece.cord2[1]] == SquareColor.TRANSPARENT && !(PreviewPiece.cord2[0] == piece.cord1[0] && PreviewPiece.cord2[1] == piece.cord1[1]) && !(PreviewPiece.cord2[0] == piece.cord2[0] && PreviewPiece.cord2[1] == piece.cord2[1]) && !(PreviewPiece.cord2[0] == piece.cord3[0] && PreviewPiece.cord2[1] == piece.cord3[1]) && !(PreviewPiece.cord2[0] == piece.cord4[0] && PreviewPiece.cord2[1] == piece.cord4[1]))
    //         {
    //             UnityEngine.Debug.Log("2");
    //             colors[PreviewPiece.cord2[0]][PreviewPiece.cord2[1]] = SquareColor.PREVIEW;
    //         }
    //         if(colors[PreviewPiece.cord3[0]][PreviewPiece.cord3[1]] == SquareColor.TRANSPARENT && !(PreviewPiece.cord3[0] == piece.cord1[0] && PreviewPiece.cord3[1] == piece.cord1[1]) && !(PreviewPiece.cord3[0] == piece.cord2[0] && PreviewPiece.cord3[1] == piece.cord2[1]) && !(PreviewPiece.cord3[0] == piece.cord3[0] && PreviewPiece.cord3[1] == piece.cord3[1]) && !(PreviewPiece.cord3[0] == piece.cord4[0] && PreviewPiece.cord3[1] == piece.cord4[1]))
    //         {
    //             UnityEngine.Debug.Log("3");
    //             colors[PreviewPiece.cord3[0]][PreviewPiece.cord3[1]] = SquareColor.PREVIEW;
    //         }
    //         if(colors[PreviewPiece.cord4[0]][PreviewPiece.cord4[1]] == SquareColor.TRANSPARENT && !(PreviewPiece.cord4[0] == piece.cord1[0] && PreviewPiece.cord4[1] == piece.cord1[1]) && !(PreviewPiece.cord4[0] == piece.cord2[0] && PreviewPiece.cord4[1] == piece.cord2[1]) && !(PreviewPiece.cord4[0] == piece.cord3[0] && PreviewPiece.cord4[1] == piece.cord3[1]) && !(PreviewPiece.cord4[0] == piece.cord4[0] && PreviewPiece.cord4[1] == piece.cord4[1]))
    //         {
    //             UnityEngine.Debug.Log("4");
    //             colors[PreviewPiece.cord4[0]][PreviewPiece.cord4[1]] = SquareColor.PREVIEW;
    //         }
    //     }
    // }
}