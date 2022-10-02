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
            foreach (List<int> cord in new List<int>[] {piece.cord1, piece.cord2, piece.cord3, piece.cord4})
            {
                cord[1]--;
            }
            gameManager.SetPieceColors(piece,colors);
        }
    }

    public void rightPiece(Piece piece, List<List<SquareColor>> colors)
    {
        if (!collider.isCollidingRight(piece,colors))
        {
            gameManager.RemovePieceColors(piece,colors);
            foreach (List<int> cord in new List<int>[] {piece.cord1, piece.cord2, piece.cord3, piece.cord4})
            {
                cord[1]++;
            }
            gameManager.SetPieceColors(piece,colors);
        }
    }

    public void DownPiece(Piece piece, List<List<SquareColor>> colors)
    {
        
        gameManager.RemovePieceColors(piece,colors);
        foreach (List<int> cord in new List<int>[] {piece.cord1, piece.cord2, piece.cord3, piece.cord4})
        {
            cord[0]++;
        }
        gameManager.SetPieceColors(piece,colors);
    }

    // recherche for a preview function
    
    //preview est une fonction qui permet de voir ou la piece va tomber
    // public void Preview(Piece piece, List<List<SquareColor>> colors)
    // {
    //     gameManager.RemovePieceColors(PreviewPiece,colors);
    //     PreviewPiece = new Piece(piece.cord1,piece.cord2,piece.cord3,piece.cord4,SquareColor.PREVIEW);
    //     List<List<int>> previewListeCord = new List<List<int>>(){PreviewPiece.cord1,PreviewPiece.cord2,PreviewPiece.cord3,PreviewPiece.cord4};
    //     List<List<int>> pieceListeCord = new List<List<int>>(){piece.cord1,piece.cord2,piece.cord3,piece.cord4};

    //     bool isNextPrewiewPosed(){
    //         foreach (List<int> cord in previewListeCord)
    //         {
    //             bool isOnPiece = false;
    //             foreach (List<int> cord2 in pieceListeCord)
    //             {
    //                 if (cord[0]+1 == cord2[0] && cord[1] == cord2[1])
    //                 {
    //                     isOnPiece = true;
    //                 }
    //             }
    //             if (!isOnPiece && colors[cord[0]+1][cord[1]] != SquareColor.TRANSPARENT)
    //             {
    //                 return true;
    //             }
    //         }
    //         return false;
            
    //     }

    //     while (!isNextPrewiewPosed())
    //     {
    //         gameManager.RemovePieceColors(PreviewPiece,colors);
    //         PreviewPiece.cord1[0] = PreviewPiece.cord1[0] + 1;
    //         PreviewPiece.cord2[0] = PreviewPiece.cord2[0] + 1;
    //         PreviewPiece.cord3[0] = PreviewPiece.cord3[0] + 1;
    //         PreviewPiece.cord4[0] = PreviewPiece.cord4[0] + 1;
            
    //         foreach (List<int> cord in previewListeCord)
    //         {
    //             cord[0] = cord[0] + 1;
    //             foreach (List<int> cord2 in pieceListeCord)
    //             {
    //                 if (cord[0] == cord2[0] && cord[1] == cord2[1])
    //                 {
    //                     colors[cord[0]][cord[1]] = SquareColor.PREVIEW;
    //                 }
    //             }
    //         }
    //     }
    // }
}