using System;
using System.Diagnostics;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GridDisplay : MonoBehaviour
{

    // Hauteur de la grille en nombre de cases
    public int height = 22;

    // Largeur de la grille en nombre de cases
    public int width = 10;


    // Cette fonction se lance au lancement du jeu, avant le premier affichage.
    public static void Initialize()
    {

        // créé les varibles nesséssaire au fonctionnement du jeu

        Piece piece = new Piece(1);
        piece.color = SquareColor.TRANSPARENT;

        GameManager gameManager = new GameManager();

        // possede les stats du jeu (score, niveau, vitesses)
        GameStat gameStat = new GameStat();

        // création de la grille

        List<List<SquareColor>> colors = new List<List<SquareColor>>();
        for (int j = 0; j < 22; j++)
        {
            List<SquareColor> row = new List<SquareColor>();
            for (int i = 0; i < 10; i++)
            {
                row.Add(SquareColor.TRANSPARENT);
            }
            colors.Add(row);
        }

        // action si la piece est posé

        void PiecePosed()
        {   
            gameStat = gameManager.BreakLine(colors, gameStat); //destruction de la grille
            SetScore(gameStat.score);
            SetLevel(gameStat.level);
            if (gameStat.speed / 100 > 0.01)
            {
                SetTickTime((float)gameStat.speed / 100);
            }
            else
            {
                SetTickTime(0.01f);
            }

            piece = gameManager.GeneratePiece();
            if (gameManager.IsgameOver(piece, colors))
            {
                TriggerGameOver();
            }

            gameManager.SetPieceColors(piece, colors);
        }

        // SetTickFunction définition
        piece = gameManager.GeneratePiece();
        gameManager.SetPieceColors(piece, colors);


        //action a chaque tick
        SetTickFunction(() =>
        {
            if (gameManager.collider.IsColliding(piece, colors, new List<int> { 1, 0 },piece))
            {
                PiecePosed();
            }
            else
            {
                gameManager.moveSystem.DownPiece(piece, colors);
            }
            _grid.SetColors(colors); // actualise la grille

        });

        // lien vert la fonction pour déplacer la piece a gauche

        SetMoveLeftFunction(() =>
        {
            gameManager.moveSystem.LeftPiece(piece, colors);
            // gameManager.moveSystem.Preview(piece, colors);
            SetColors(colors); // actualise la grille
        });

        // lien vert la fonction pour déplacer la piece a droite
        SetMoveRightFunction(() =>
        {
            gameManager.moveSystem.RightPiece(piece, colors);
            // gameManager.moveSystem.Preview(piece, colors);
            SetColors(colors); // actualise la grille
            });
        SetRushFunction(()=>{  
            gameStat = gameManager.moveSystem.RushPiece(piece,colors,gameStat);
            PiecePosed();
            SetColors(colors); // actualise la grille
        });
        SetRotateFunction(() => {
            gameManager.RemovePieceColors(piece, colors);
            piece.Turn(colors, new List<int> { 0, 0 });
            gameManager.SetPieceColors(piece, colors);
            // gameManager.moveSystem.Preview(piece, colors);
            SetColors(colors); // actualise la grille
        });

        //placer le tick a 0.01s 
        SetTickTime(1f);

        // /!\ Ceci est la seule fonction du fichier que vous avez besoin de compléter, le reste se trouvant dans vos propres classes!  

    }

    // Paramètre la fonction devant être appelée à chaque tick. 
    // C'est ici que le gros de la logique temporelle de votre jeu aura lieu!
    // Cette fonction peut être une méthode d'une autre classe
    // et doit renvoyer void, et ne prendre aucun argument.
    public static void SetTickFunction(TickFunction function)
    {
        _grid.Tick = function;
    }

    // Paramètre la fonction devant être appelée lorsqu'on appuie sur la barre d'espace 
    // pour faire tourner la pièce dans le sens horaire.
    // Cette fonction peut être une méthode d'une autre classe
    // et doit renvoyer void, et ne prendre aucun argument.
    public static void SetRotateFunction(RotateFunction function)
    {
        _grid.Rotate = function;
    }

    // Paramètre la fonction devant être appelée lorsqu'on appuie sur la flèche de gauche 
    // pour bouger la pièce vers la gauche.
    // Cette fonction peut être une méthode d'une autre classe
    // et doit renvoyer void, et ne prendre aucun argument.
    public static void SetMoveLeftFunction(MoveFunction function)
    {
        _grid.MoveLeft = function;
    }

    // Paramètre la fonction devant être appelée lorsqu'on appuie sur la flèche de droite 
    // pour bouger la pièce vers la droite.
    // Cette fonction peut être une méthode d'une autre classe
    // et doit renvoyer void, et ne prendre aucun argument.
    public static void SetMoveRightFunction(MoveFunction function)
    {
        _grid.MoveRight = function;
    }

    // Paramètre la fonction devant être appelée lorsqu'on appuie sur la barre d'espace
    // pour faire descendre la pièce tout en bas.
    // Cette fonction peut être une méthode d'une autre classe
    // et doit renvoyer void, et ne prendre aucun argument.
    public static void SetRushFunction(RushFunction function)
    {
        _grid.Rush = function;
    }

    // Modifie l'intervale de rendu du jeu. A modifier pour modifier la difficulté en cours de partie.
    public static void SetTickTime(float seconds)
    {
        _grid.tick = seconds;
    }

    // Modifie toutes les couleurs de chaque case de la grille.
    // Cette fonction doit prendre en argument un tableau de LIGNES, de haut vers le bas, contenant 
    // des couleurs de case allant de gauche vers la droite.
    // Vous appellerez a priori cette fonction une fois par TickFunction, une fois le nouvel état de la grille
    // calculé.
    public static void SetColors(List<List<SquareColor>> colors)
    {
        _grid.SetColors(colors);
    }

    // Modifie visuellement le score de l'utilisateur en bas à droite.
    public static void SetScore(int score)
    {
        _grid.SetScore(score);
    }

    // Modifie visuellement le niveau de l'utilisateur en bas à droite.
    public static void SetLevel(int level)
    {
        _grid.SetLevel(level);
    }

    // Déclenche visuellement le GameOver et arrête le jeu.
    public static void TriggerGameOver()
    {
        _grid.TriggerGameOver();
    }





    /// Les lignes au delà de celle-ci ne vous concernent pas.

    private static _GridDisplay _grid = null;
    void Awake()
    {
        _grid = GameObject.FindObjectOfType<_GridDisplay>();
        _grid.height = height;
        _grid.width = width;
    }

    void Start()
    {

        Initialize();
    }

}


