using System;
using System.Collections;
using System.Collections.Generic;

class MoveSystem
{


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
        gameManager.RemovePieceColors(piece,colors);
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
}