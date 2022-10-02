using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void PiecePosed();

class GameManager
{

    public MoveSystem moveSystem;
    public Collider collider;

    private int score = 0;
    private int lvl = 1;
    private int lines = 0;
    private List<int> paque = new List<int>(){};

    public GameManager()
    {
        collider = new Collider();
        moveSystem = new MoveSystem(collider, this);
    }

    public Piece generatePiece()
    {
        if (paque.Count == 0)
        {

            paque = new List<int>() { 1, 2, 3, 4, 5, 6, 7 };
            var count = paque.Count;
            var last = count - 1;
            for (var i = 0; i < last; ++i)
            {
                var r = UnityEngine.Random.Range(i, count);
                var tmp = paque[i];
                paque[i] = paque[r];
                paque[r] = tmp;
            }

        }
        int nbtPiece = paque[0];
        paque.RemoveAt(0);
        return new Piece(nbtPiece);
    }

    public int Score(List<List<SquareColor>> colors, double speed)
    {
        int nbligne = 0;
        // la fonction supprime les lignes pleines et les lignes au dessus descendent
        // si plusieur ligne son supprmé on ajoute le nombre de ligne supprimé multiplié par 10 au score
        for (int i = 0; i < 22; i++)
        {
            bool isFull = true;
            for (int j = 0; j < 10; j++)
            {
                if (colors[i][j] == SquareColor.TRANSPARENT)
                {
                    isFull = false;
                }
            }
            if (isFull)
            {
                nbligne++;
                lines += 1;
                lvl = ((int)lines / 10) + 1;
                speed = 100 - (Math.Pow(lvl, 1.5f) * 1.5f);
                for (int k = i; k > 0; k--)
                {
                    for (int l = 0; l < 10; l++)
                    {
                        colors[k][l] = colors[k - 1][l];

                    }
                }
            }
        }
        if (nbligne >0){
            AudioSource breakLineSound = GameObject.Find("BreakLineSound").GetComponent<AudioSource>();
            breakLineSound.PlayOneShot(breakLineSound.clip);
        }
        if (nbligne > 1)
        {
            
            
            score += (int)(((nbligne * 100) + ((Math.Pow(nbligne, 2) / 2) * 10)) * lvl);
        }
        else if (nbligne == 1)
        {
            score += 100 * lvl;
        }
        return score;
    }

    public void RemovePieceColors(Piece piece, List<List<SquareColor>> colors)
    {
        if(colors[piece.cord1[0]][piece.cord1[1]] == piece.color){
            colors[piece.cord1[0]][piece.cord1[1]] = SquareColor.TRANSPARENT;
        }
        if(colors[piece.cord2[0]][piece.cord2[1]] == piece.color){
            colors[piece.cord2[0]][piece.cord2[1]] = SquareColor.TRANSPARENT;
        }
        if(colors[piece.cord3[0]][piece.cord3[1]] == piece.color){
            colors[piece.cord3[0]][piece.cord3[1]] = SquareColor.TRANSPARENT;
        }
        if(colors[piece.cord4[0]][piece.cord4[1]] == piece.color){
            colors[piece.cord4[0]][piece.cord4[1]] = SquareColor.TRANSPARENT;
        }
        
    }

    public bool isgameOver(Piece piece, List<List<SquareColor>> colors)
    {
        if (colors[piece.cord1[0]][piece.cord1[1]] != SquareColor.TRANSPARENT || colors[piece.cord2[0]][piece.cord2[1]] != SquareColor.TRANSPARENT || colors[piece.cord3[0]][piece.cord3[1]] != SquareColor.TRANSPARENT || colors[piece.cord4[0]][piece.cord4[1]] != SquareColor.TRANSPARENT)
        {
            return true;
        }
        return false;

    }
    public void SetPieceColors(Piece piece, List<List<SquareColor>> colors)
    {
        if(colors[piece.cord1[0]][piece.cord1[1]] == SquareColor.TRANSPARENT || colors[piece.cord1[0]][piece.cord1[1]] == SquareColor.PREVIEW){
            colors[piece.cord1[0]][piece.cord1[1]] = piece.color;
        }
        if(colors[piece.cord2[0]][piece.cord2[1]] == SquareColor.TRANSPARENT || colors[piece.cord2[0]][piece.cord2[1]] == SquareColor.PREVIEW){
            colors[piece.cord2[0]][piece.cord2[1]] = piece.color;
        }
        if(colors[piece.cord3[0]][piece.cord3[1]] == SquareColor.TRANSPARENT || colors[piece.cord3[0]][piece.cord3[1]] == SquareColor.PREVIEW){
            colors[piece.cord3[0]][piece.cord3[1]] = piece.color;
        }
        if(colors[piece.cord4[0]][piece.cord4[1]] == SquareColor.TRANSPARENT || colors[piece.cord4[0]][piece.cord4[1]] == SquareColor.PREVIEW){
            colors[piece.cord4[0]][piece.cord4[1]] = piece.color;
        }
    }
}