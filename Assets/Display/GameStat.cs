class GameStat
{
    public int score;
    public double speed;
    public int level;

    public GameStat(){
        score = 0;
        speed = 100;
        level = 1;
    }
    public GameStat(int score, int level,double speed)
    {
        this.score = score;
        this.speed = speed;
        this.level = level;
    }
}