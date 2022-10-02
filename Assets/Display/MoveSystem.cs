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
            piece.cord1[1] = piece.cord1[1] - 1;
            piece.cord2[1] = piece.cord2[1] - 1;
            piece.cord3[1] = piece.cord3[1] - 1;
            piece.cord4[1] = piece.cord4[1] - 1;
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
            piece.cord1[1] = piece.cord1[1] + 1;
            piece.cord2[1] = piece.cord2[1] + 1;
            piece.cord3[1] = piece.cord3[1] + 1;
            piece.cord4[1] = piece.cord4[1] + 1;
            gameManager.SetPieceColors(piece,colors);
        }
    }

    // fonction pour faire bouger la pièce vers le bas
    public void DownPiece(Piece piece, List<List<SquareColor>> colors)
    {
        //on ajoute un pixel de coordonnée y a chaque pixel de la pièce 
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