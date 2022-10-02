using System;
using System.Collections;
using System.Collections.Generic;

class Collider{

    public Collider(){}
    
    public bool isPosed(Piece piece,List<List<SquareColor>> colors){
            if (piece.cord1[0]==21||piece.cord2[0]==21||piece.cord3[0]==21||piece.cord4[0]==21){
                return true;
            }else{
                if (isColliding(piece.cord1, piece, "down",colors)){
                    return true;
                }
                if (isColliding(piece.cord2, piece, "down",colors)){
                    return true;
                }
                if (isColliding(piece.cord3, piece, "down",colors)){
                    return true;
                }
                if (isColliding(piece.cord4, piece, "down",colors)){
                    return true;
                }
            }
            
            return false;
        }

        public bool isCollidingLeft(Piece piece, List<List<SquareColor>> colors){
            if (piece.cord1[1]==0||piece.cord2[1]==0||piece.cord3[1]==0||piece.cord4[1]==0){
                return true;
            }else{
                if (isColliding(piece.cord1, piece, "left",colors)){
                    return true;
                }
                if (isColliding(piece.cord2, piece, "left",colors)){
                    return true;
                }
                if (isColliding(piece.cord3, piece, "left",colors)){
                    return true;
                }
                if (isColliding(piece.cord4, piece, "left",colors)){
                    return true;
                }
            }
            
            return false;
        }

        public bool isCollidingRight(Piece piece, List<List<SquareColor>> colors){
            if (piece.cord1[1]==9||piece.cord2[1]==9||piece.cord3[1]==9||piece.cord4[1]==9){
                return true;
            }else{
                if (isColliding(piece.cord1, piece, "right",colors)){
                    return true;
                }
                if (isColliding(piece.cord2, piece, "right",colors)){
                    return true;
                }
                if (isColliding(piece.cord3, piece, "right",colors)){
                    return true;
                }
                if (isColliding(piece.cord4, piece, "right",colors)){
                    return true;
                }
            }
            
            return false;
        }

        public bool isColliding(List<int> cord, Piece piece, string direction, List<List<SquareColor>> colors){
           int indexOfCord = 0;
           int numOfMoves= 0;
           int indexOfCordNoMove= 0;
           switch (direction) {
            case "left":
                indexOfCord = 1;
                numOfMoves = -1;
                indexOfCordNoMove = 0;
                if (colors[cord[0]][cord[1]-1] == SquareColor.TRANSPARENT || colors[cord[0]][cord[1]-1] == SquareColor.PREVIEW){
                    return false;
                }
                break;
            case "right":
                indexOfCord = 1;
                numOfMoves = 1;
                indexOfCordNoMove = 0;
                if (colors[cord[0]][cord[1]+1] == SquareColor.TRANSPARENT|| colors[cord[0]][cord[1]+1] == SquareColor.PREVIEW)
                {
                    return false;
                }
                break;
            case "down":
                indexOfCord = 0;
                numOfMoves = 1;
                indexOfCordNoMove = 1;
                if (colors[cord[0]+1][cord[1]] == SquareColor.TRANSPARENT||colors[cord[0]+1][cord[1]] == SquareColor.PREVIEW)
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
}