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
    public static void Initialize(){
        Piece piece = new Piece(1);
        piece.color = SquareColor.TRANSPARENT;
        int score = 0;
        int lvl = 1;
        int lines = 0;
        double speed = 100;
        List<int> paque = new List<int>(){};

        // TODO : Complétez cette fonction de manière à appeler le code qui initialise votre jeu.
        
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

        

        bool isColliding(List<int> cord, Piece piece, string direction){
           int indexOfCord = 0;
           int numOfMoves= 0;
           int indexOfCordNoMove= 0;
           switch (direction) {
            case "left":
                indexOfCord = 1;
                numOfMoves = -1;
                indexOfCordNoMove = 0;
                if (colors[cord[0]][cord[1]-1] == SquareColor.TRANSPARENT)
                {
                    return false;
                }
                break;
            case "right":
                indexOfCord = 1;
                numOfMoves = 1;
                indexOfCordNoMove = 0;
                if (colors[cord[0]][cord[1]+1] == SquareColor.TRANSPARENT)
                {
                    return false;
                }
                break;
            case "down":
                indexOfCord = 0;
                numOfMoves = 1;
                indexOfCordNoMove = 1;
                if (colors[cord[0]+1][cord[1]] == SquareColor.TRANSPARENT)
                {
                    return false;
                }
                break;
           }
                if ((cord[indexOfCordNoMove]==piece.cord1[indexOfCordNoMove]&&cord[indexOfCord]+numOfMoves==piece.cord1[indexOfCord])||
                (cord[indexOfCordNoMove]==piece.cord2[indexOfCordNoMove]&&cord[indexOfCord]+numOfMoves==piece.cord2[indexOfCord])||
                (cord[indexOfCordNoMove]==piece.cord3[indexOfCordNoMove]&&cord[indexOfCord]+numOfMoves==piece.cord3[indexOfCord])||
                (cord[indexOfCordNoMove]==piece.cord4[indexOfCordNoMove]&&cord[indexOfCord]+numOfMoves==piece.cord4[indexOfCord])) 
                {
                    return false;
                }
            
            return true;
        }

        bool isCollidingRight(){
            if (piece.cord1[1]==9||piece.cord2[1]==9||piece.cord3[1]==9||piece.cord4[1]==9){
                return true;
            }else{
                if (isColliding(piece.cord1, piece, "right")){
                    return true;
                }
                if (isColliding(piece.cord2, piece, "right")){
                    return true;
                }
                if (isColliding(piece.cord3, piece, "right")){
                    return true;
                }
                if (isColliding(piece.cord4, piece, "right")){
                    return true;
                }
            }
            
            return false;
        }

        bool isCollidingLeft(){
            if (piece.cord1[1]==0||piece.cord2[1]==0||piece.cord3[1]==0||piece.cord4[1]==0){
                return true;
            }else{
                if (isColliding(piece.cord1, piece, "left")){
                    return true;
                }
                if (isColliding(piece.cord2, piece, "left")){
                    return true;
                }
                if (isColliding(piece.cord3, piece, "left")){
                    return true;
                }
                if (isColliding(piece.cord4, piece, "left")){
                    return true;
                }
            }
            
            return false;
        }

        bool isPosed(){
            if (piece.cord1[0]==21||piece.cord2[0]==21||piece.cord3[0]==21||piece.cord4[0]==21){
                return true;
            }else{
                if (isColliding(piece.cord1, piece, "down")){
                    return true;
                }
                if (isColliding(piece.cord2, piece, "down")){
                    return true;
                }
                if (isColliding(piece.cord3, piece, "down")){
                    return true;
                }
                if (isColliding(piece.cord4, piece, "down")){
                    return true;
                }
            }
            
            return false;
        }
        
        

        void SetPieceColors() {
            colors[piece.cord1[0]][piece.cord1[1]] = piece.color;
            colors[piece.cord2[0]][piece.cord2[1]] = piece.color;
            colors[piece.cord3[0]][piece.cord3[1]] = piece.color;
            colors[piece.cord4[0]][piece.cord4[1]] = piece.color;
        }

        SetPieceColors();

        void RemovePieceColors() {
            colors[piece.cord1[0]][piece.cord1[1]] = SquareColor.TRANSPARENT;
            colors[piece.cord2[0]][piece.cord2[1]] = SquareColor.TRANSPARENT;
            colors[piece.cord3[0]][piece.cord3[1]] = SquareColor.TRANSPARENT;
            colors[piece.cord4[0]][piece.cord4[1]] = SquareColor.TRANSPARENT;
        }

        void DownPiece() {
            RemovePieceColors();
            piece.cord1[0] = piece.cord1[0] + 1;
            piece.cord2[0] = piece.cord2[0] + 1;
            piece.cord3[0] = piece.cord3[0] + 1;
            piece.cord4[0] = piece.cord4[0] + 1;
            SetPieceColors();
        }

        void rightPiece() {
            if (!isCollidingRight()){
                RemovePieceColors();
                piece.cord1[1] = piece.cord1[1] + 1;
                piece.cord2[1] = piece.cord2[1] + 1;
                piece.cord3[1] = piece.cord3[1] + 1;
                piece.cord4[1] = piece.cord4[1] + 1;
                SetPieceColors();
            }
        }

        void leftPiece() {
            if (!isCollidingLeft()){
                RemovePieceColors();
                piece.cord1[1] = piece.cord1[1] - 1;
                piece.cord2[1] = piece.cord2[1] - 1;
                piece.cord3[1] = piece.cord3[1] - 1;
                piece.cord4[1] = piece.cord4[1] - 1;
                SetPieceColors();
            }
        }

        void rushPiece() {
            for (int i = 0; i < 22; i++){
                if (isPosed()){
                    Score();
                    generatePiece();
                    gameOver();
                    SetPieceColors();
                    return;
                }
                else{
                    DownPiece();
                }
                _grid.SetColors(colors);
            }
        }

        void gameOver(){
            if (colors[piece.cord1[0]][piece.cord1[1]] != SquareColor.TRANSPARENT || colors[piece.cord2[0]][piece.cord2[1]] != SquareColor.TRANSPARENT || colors[piece.cord3[0]][piece.cord3[1]] != SquareColor.TRANSPARENT || colors[piece.cord4[0]][piece.cord4[1]] != SquareColor.TRANSPARENT){
                TriggerGameOver();
            }
            
        }

        
        //if gameover true pas de nouvelle piece
        void Score(){
            int nbligne = 0;
            // la fonction supprime les lignes pleines et les lignes au dessus descendent
            // si plusieur ligne son supprmé on ajoute le nombre de ligne supprimé multiplié par 10 au score
            for(int i = 0; i < 22; i++){
                bool isFull = true;
                for(int j = 0; j < 10; j++){
                    if (colors[i][j] == SquareColor.TRANSPARENT){
                        isFull = false;
                    }
                }
                if (isFull){
                    nbligne++;
                    lines+=1;
                    lvl = ((int)lines/10)+1;
                    speed = 100-(Math.Pow(lvl,1.5f)*1.5f);
                    for(int k = i; k > 0; k--){
                        for(int l = 0; l < 10; l++){
                            colors[k][l] = colors[k-1][l];

                        }
                    }
                } 
            }
            if(nbligne > 1){
                    score += (int)(((nbligne*100)+((Math.Pow(nbligne,2)/2)*10))*lvl);
            }
            else if(nbligne == 1){
                score += 100*lvl;
            }
            
            SetScore(score);

        }

        void generatePiece(){
            if(paque.Count == 0){
                
                paque = new List<int>(){1,2,3,4,5,6,7};
                var count = paque.Count;
                var last = count - 1;
                for (var i = 0; i < last; ++i) {
                    var r = UnityEngine.Random.Range(i, count);
                    var tmp = paque[i];
                    paque[i] = paque[r];
                    paque[r] = tmp;
                    
                }
                
            }
            piece = new Piece(paque[0]);

            paque.RemoveAt(0);


        }
        generatePiece();
        


        
        // _grid.Rotate = turnPiece;
        int actualTickUpdate = 0;

        // TODO : Appelez SetTickFunction en lui passant en argument une fonction ne prenant pas d'argument et renvoyant Void.
        //        Cette fonction sera exécutée à chaque tick du jeu, c'est à dire, initialement, toutes les secondes.
        //        Vous pouvez utiliser toutes les méthodes statiques ci-dessous pour mettre à jour l'état du jeu.

        SetTickFunction(() => {
            if (actualTickUpdate >= speed) {
                if (isPosed()){
                    Score();
                    generatePiece();
                    gameOver();
                    SetPieceColors();
                }
                else{
                    DownPiece();
                }
                actualTickUpdate = 0;
            }
            else {
                actualTickUpdate++;
            }
            _grid.SetColors(colors);
            
        });

        // TODO : Appelez SetMoveLeftFunction, SetMoveRightFunction, SetRotateFunction, SetRushFunction pour enregistrer
        //        quelle fonction sera appelée lorsqu'on appuie sur les flèches directionnelles gauche, droite, la barre d'espace
        //        et la flèche du bas du clavier.

        SetMoveLeftFunction(leftPiece);
        SetMoveRightFunction(rightPiece);
        SetRushFunction(rushPiece);
        SetRotateFunction(() => {
            RemovePieceColors();
            piece.turn(colors);
            SetPieceColors();
        });

        

        // /!\ Ceci est la seule fonction du fichier que vous avez besoin de compléter, le reste se trouvant dans vos propres classes!  
        
    }

    // Paramètre la fonction devant être appelée à chaque tick. 
    // C'est ici que le gros de la logique temporelle de votre jeu aura lieu!
    // Cette fonction peut être une méthode d'une autre classe
    // et doit renvoyer void, et ne prendre aucun argument.
    public static void SetTickFunction(TickFunction function){
        _grid.Tick = function;
    }

    // Paramètre la fonction devant être appelée lorsqu'on appuie sur la barre d'espace 
    // pour faire tourner la pièce dans le sens horaire.
    // Cette fonction peut être une méthode d'une autre classe
    // et doit renvoyer void, et ne prendre aucun argument.
    public static void SetRotateFunction(RotateFunction function){
        _grid.Rotate = function;
    }

    // Paramètre la fonction devant être appelée lorsqu'on appuie sur la flèche de gauche 
    // pour bouger la pièce vers la gauche.
    // Cette fonction peut être une méthode d'une autre classe
    // et doit renvoyer void, et ne prendre aucun argument.
    public static void SetMoveLeftFunction(MoveFunction function){
        _grid.MoveLeft = function;
    }

    // Paramètre la fonction devant être appelée lorsqu'on appuie sur la flèche de droite 
    // pour bouger la pièce vers la droite.
    // Cette fonction peut être une méthode d'une autre classe
    // et doit renvoyer void, et ne prendre aucun argument.
    public static void SetMoveRightFunction(MoveFunction function){
        _grid.MoveRight = function;
    }

    // Paramètre la fonction devant être appelée lorsqu'on appuie sur la barre d'espace
    // pour faire descendre la pièce tout en bas.
    // Cette fonction peut être une méthode d'une autre classe
    // et doit renvoyer void, et ne prendre aucun argument.
    public static void SetRushFunction(RushFunction function){
        _grid.Rush = function;
    }

    // Modifie l'intervale de rendu du jeu. A modifier pour modifier la difficulté en cours de partie.
    public static void SetTickTime(float seconds){
        _grid.tick = seconds;
    }

    // Modifie toutes les couleurs de chaque case de la grille.
    // Cette fonction doit prendre en argument un tableau de LIGNES, de haut vers le bas, contenant 
    // des couleurs de case allant de gauche vers la droite.
    // Vous appellerez a priori cette fonction une fois par TickFunction, une fois le nouvel état de la grille
    // calculé.
    public static void SetColors(List<List<SquareColor>> colors){
        _grid.SetColors(colors);
    }

    // Modifie visuellement le score de l'utilisateur en bas à droite.
    public static void SetScore(int score){
        _grid.SetScore(score);
    }
    // Déclenche visuellement le GameOver et arrête le jeu.
    public static void TriggerGameOver(){
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

    void Start(){

        Initialize();
    }
    
}


