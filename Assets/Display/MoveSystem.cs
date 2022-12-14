using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// classe pour le mouvement des pièces
class MoveSystem
{
    // private Piece PreviewPiece = new Piece(new List<int>(){0,0},new List<int>(){0,0},new List<int>(){0,0},new List<int>(){0,0},SquareColor.TRANSPARENT);
    
    //recuperation des collision et du gameManager
    private Collider collider;
    private GameManager gameManager;
    private GameStat gameStat;

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
    public GameStat RushPiece(Piece piece, List<List<SquareColor>> colors, GameStat gameStat)
    {
        // tant que la pièce peut descendre on la fait descendre
        while (!collider.IsColliding(piece,colors,new List<int>(){1,0},piece))
        {
            DownPiece(piece,colors);
            gameStat.score += gameStat.level;
        }
        return gameStat;
    }

    // fonction pour faire bouger la pièce vers la gauche
    public void LeftPiece(Piece piece, List<List<SquareColor>> colors)
    {
        // on verifie que la pièce peut bouger vers la gauche

        if (!collider.IsColliding(piece,colors,new List<int>(){0,-1},piece))
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
    public void RightPiece(Piece piece, List<List<SquareColor>> colors)
    {
        // on verifie que la pièce peut bouger vers la droite
        if (!collider.IsColliding(piece,colors,new List<int>(){0,1},piece))
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

    //     while (!collider.IsColliding(PreviewPiece,colors,new List<int>(){1,0},piece))
    //     {
    //         UnityEngine.Debug.Log("preview");
    //         foreach (List<int> cord in previewListeCord)
    //         {
    //             cord[0]++;
    //         }
    //     }
    //     foreach (List<int> cord in previewListeCord)
    //     {
    //         foreach (List<int> cord2 in pieceListeCord)
    //         {
    //             if (cord[0] == cord2[0] && cord[1] == cord2[1])
    //             {
    //                 colors[cord[0]][cord[1]] = SquareColor.PREVIEW;
    //             }
    //         }
    //     }
    // }
}