
[System.Serializable]
public class PuzzleQuestion{
    public string word { get; set; }
    public string[] answer { get; set; }
    public string missingWord { get; set; }
    //public Sprite image;
    public string img { get; set; }
    public bool asked { get; set; }
    public PuzzleQuestion(string w, string mw, string[] a, string im)
    {
        word = w;
        answer = a;
        missingWord = mw;
        img = im;
    }
    public PuzzleQuestion()
    {

    }
}
