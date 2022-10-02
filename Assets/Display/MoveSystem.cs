using System;
using System.Collections;
using System.Collections.Generic;

// classe pour le mouvement des pièces
class MoveSystem
{
    //private Piece PreviewPiece = new Piece(new List<int>(){0,0},new List<int>(){0,0},new List<int>(){0,0},new List<int>(){0,0},SquareColor.TRANSPARENT);
    
    //recuperation des collision et du gameManager
    private Collider collider;
    private GameManager gameManager;

    //constructeur pour generer une instance de collider
    public MoveSystem()
    {
        collider = new Collider();
    }

    //constructeur
    public MoveSystem(Collider collider, GameManager gameManager)
    {
        this.collider = collider;
        this.gameManager = gameManager;
    }

    // fonction pour faire descendre la pièce en bas en un mouvement
    public void rushPiece(Piece piece, List<List<SquareColor>> colors, PiecePosed PiecePosed)
    {
        // tant que la pièce peut descendre on la fait descendre
        while (!collider.isPosed(piece,colors))
        {
            DownPiece(piece,colors);
        }
        PiecePosed();
    }

    // fonction pour faire bouger la pièce vers la gauche
    public void leftPiece(Piece piece, List<List<SquareColor>> colors)
    {
        // on verifie que la pièce peut bouger vers la gauche

        if (!collider.isCollidingLeft(piece,colors))
        {
            // on enleve un pixel de coordonnée x a chaque pixel de la pièce
            gameManager.RemovePieceColors(piece,colors);
            foreach (List<int> cord in new List<int>[] {piece.cord1, piece.cord2, piece.cord3, piece.cord4})
            {
                cord[1]--;
            }
            gameManager.SetPieceColors(piece,colors);
        }
    }

    // fonction pour faire bouger la pièce vers la droite
    public void rightPiece(Piece piece, List<List<SquareColor>> colors)
    {
        // on verifie que la pièce peut bouger vers la droite
        if (!collider.isCollidingRight(piece,colors))
        {
            // on ajoute un pixel de coordonnée x a chaque pixel de la pièce
            gameManager.RemovePieceColors(piece,colors);
            foreach (List<int> cord in new List<int>[] {piece.cord1, piece.cord2, piece.cord3, piece.cord4})
            {
                cord[1]++;
            }
            gameManager.SetPieceColors(piece,colors);
        }
    }

    // fonction pour faire bouger la pièce vers le bas
    public void DownPiece(Piece piece, List<List<SquareColor>> colors)
    {
        //on ajoute un pixel de coordonnée y a chaque pixel de la pièce 
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