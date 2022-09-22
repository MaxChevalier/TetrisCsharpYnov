

public class piece {
    List<int> cord1 = new List<int>();
    List<int> cord2 = new List<int>();
    List<int> cord3 = new List<int>();
    List<int> cord4 = new List<int>();

    Random rand = new Random();

    public piece(){
        int random = rand.Next(1, 8);
        switch (random){
            case 1:
            //    [][][][]
                cord1 = new List<int> { 3, 0 };
                cord2 = new List<int> { 4, 0 };
                cord3 = new List<int> { 5, 0 };
                cord4 = new List<int> { 6, 0 };
                break;
            case 2:
            //    [][][]
            //      []
                cord1 = new List<int> { 3, 0 };
                cord2 = new List<int> { 4, 0 };
                cord3 = new List<int> { 5, 0 };
                cord4 = new List<int> { 4, 1 };
                break;
            case 3:
            //    [][][]
            //    []
                cord1 = new List<int> { 3, 0 };
                cord2 = new List<int> { 4, 0 };
                cord3 = new List<int> { 5, 0 };
                cord4 = new List<int> { 3, 1 };
                break;
            case 4:
            //    [][]
            //    [][]
                cord1 = new List<int> { 4, 0 };
                cord2 = new List<int> { 5, 0 };
                cord3 = new List<int> { 4, 1 };
                cord4 = new List<int> { 5, 1 };
                break;
            case 5:
            //    [][]
            //      [][]
                cord1 = new List<int> { 3, 0 };
                cord2 = new List<int> { 4, 0 };
                cord3 = new List<int> { 4, 1 };
                cord4 = new List<int> { 5, 1 };
                break;
            case 6:
            //      [][]
            //    [][]
                cord1 = new List<int> { 3, 1 };
                cord2 = new List<int> { 4, 1 };
                cord3 = new List<int> { 4, 0 };
                cord4 = new List<int> { 5, 0 };
                break;
            case 7:
            //    [][][]
            //        []
                cord1 = new List<int> { 3, 0 };
                cord2 = new List<int> { 4, 0 };
                cord3 = new List<int> { 5, 0 };
                cord4 = new List<int> { 5, 1 };
                break;

        }
    }
}