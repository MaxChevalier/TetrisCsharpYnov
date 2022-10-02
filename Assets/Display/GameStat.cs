//classe pour regroupé les statistiques de jeu
class GameStat
{

    //les statistique represente le score du joueur, le niveau ou le joueur est et la vitesse de la piece
    public int score;
    public double speed;
    public int level;


    //constructeur avec les veleur par defaut
    public GameStat(){
        score = 0;
        speed = 100;
        level = 1;
    }


    //constructeur avec les valeurs en parametre
    public GameStat(int score, int level,double speed)
    {
        this.score = score;
        this.speed = speed;
        this.level = level;
    }
}