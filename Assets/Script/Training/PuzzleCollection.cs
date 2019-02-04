using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Xml.Serialization;
using System.Linq;

public class PuzzleCollection {
    private List<PuzzleQuestion> myPuzzle = new List<PuzzleQuestion>();
	// Use this for initialization
	public void init() {
        if (!File.Exists("Puzzle.xml"))
        {
            writeInitialPuzzle();
        }
        loadPuzzle();
	}

    private void loadPuzzle()
    {
        XmlSerializer serializer = new XmlSerializer(typeof(List<PuzzleQuestion>));
        using (StreamReader streamReader = new StreamReader("Puzzle.xml"))
        {
            myPuzzle = (List<PuzzleQuestion>)serializer.Deserialize(streamReader);
        }
    }

    private void writeInitialPuzzle()
    {
        myPuzzle.Add(new PuzzleQuestion ("A P E L", "A ", new string[] { "A ", "E ", "U ", "I " }, "Learning/ABC/apel"));
        myPuzzle.Add(new PuzzleQuestion ("A P E L ", "P E L ", new string[] { "P E L", "B E L", "D O H", "L A K" }, "Learning/ABC/apel"));
        myPuzzle.Add(new PuzzleQuestion ("B O L A", "B O ", new string[] { "K U ", "B A ", "B O ", "G U " }, "Learning/ABC/bola"));
        myPuzzle.Add(new PuzzleQuestion ("C E R I", "C E ", new string[] { "D E ", "D A  ", "C E ", "R I " }, "Learning/ABC/ceri"));
        myPuzzle.Add(new PuzzleQuestion ("D O M B A", "D O M ", new string[] { "D O M ", "B A M ", "D A  M ", "T A M " }, "Learning/ABC/domba"));
        myPuzzle.Add(new PuzzleQuestion("E L A N G", "E ", new string[] { "E ", "A ", "O ", "U " }, "Learning/ABC/elang"));
        myPuzzle.Add(new PuzzleQuestion("F O T O", "F O ", new string[] { "D O ", "F A ", "F O ", "T A " }, "Learning/ABC/foto"));
        myPuzzle.Add(new PuzzleQuestion("G A J A H", "G A ", new string[] { "D O ", "B A ", "D A ", "G A " }, "Learning/ABC/gajah"));
        myPuzzle.Add(new PuzzleQuestion("H A R I M A U", "H A ", new string[] { "R I ", "B A ", "H A ", "T A " }, "Learning/ABC/harimau"));
        myPuzzle.Add(new PuzzleQuestion("I K A N", "I ", new string[] { "E ", "A ", "O ", "I " }, "Learning/ABC/ikan"));
        myPuzzle.Add(new PuzzleQuestion("J E R A P A H", "R A ", new string[] { "R A ", "J A ", "R O ", "J I " }, "Learning/ABC/jerapah"));
        myPuzzle.Add(new PuzzleQuestion("K A N C I N G", "K A N ", new string[] { "K A N ", "P A N ", "K O R ", "R U N " }, "Learning/ABC/kancing"));
        myPuzzle.Add(new PuzzleQuestion("L A M P U ", "P U ", new string[] { "P A ", "D A ", "P U ", "D U " }, "Learning/ABC/lampu"));
        myPuzzle.Add(new PuzzleQuestion("N A S I", "N A ", new string[] { "D A ", "K A ", "R O ", "N A " }, "Learning/ABC/Nasi"));
        myPuzzle.Add(new PuzzleQuestion("O B A T", "B A ", new string[] { "B A ", "J A ", "R A ", "J I " }, "Learning/ABC/Obat"));
        myPuzzle.Add(new PuzzleQuestion("P E N S I L", "P E ", new string[] { "P E ", "P I ", "P O ", "P U " }, "Learning/ABC/Pensil"));
        myPuzzle.Add(new PuzzleQuestion("Q U R A N", "R A ", new string[] { "B A ", "R U ", "R A ", "B I " }, "Learning/ABC/quran"));
        myPuzzle.Add(new PuzzleQuestion("R O T I", "R O ", new string[] { "F O ", "R O ", "J A ", "T U " }, "Learning/ABC/Roti"));
        myPuzzle.Add(new PuzzleQuestion("S E N D O K", "E ", new string[] { "E ", "A ", "O ", "I " }, "Learning/ABC/Sendok"));
        myPuzzle.Add(new PuzzleQuestion("T O P I ", "P I ", new string[] { "P A ", "P U ", "P O ", "P I " }, "Learning/ABC/Topi"));
        myPuzzle.Add(new PuzzleQuestion("U A N G", "U ", new string[] { "E ", "U ", "O ", "I " }, "Learning/ABC/Uang"));
        myPuzzle.Add(new PuzzleQuestion("V E S P A ", "P A ", new string[] { "P E ", "Y A ", "P O ", "P A " }, "Learning/ABC/Vespa"));
        myPuzzle.Add(new PuzzleQuestion("W E K E R", "W E ", new string[] { "W E ", "W A ", "W O ", "W I " }, "Learning/ABC/Weker"));
        myPuzzle.Add(new PuzzleQuestion("X - R A Y ", "R A Y ", new string[] { "G U Y ", "D A N ", "T O P ", "R A Y " }, "Learning/ABC/X-Ray"));
        myPuzzle.Add(new PuzzleQuestion("Y O Y O", "Y O ", new string[] { "Y E ", "Y A ", "Y O ", "Y I " }, "Learning/ABC/Yoyo"));
        myPuzzle.Add(new PuzzleQuestion("Z E B R A", "Z E B ", new string[] { "Z E B ", "Z A B ", "Z O B ", "Z I B " }, "Learning/ABC/Zebra"));
        XmlSerializer serializer = new XmlSerializer(typeof(List<PuzzleQuestion>));
        using (StreamWriter streamWriter = new StreamWriter("Puzzle.xml"))
        {
            serializer.Serialize(streamWriter, myPuzzle);
        }
    }

    public void addQuestion(string word,string missingWord, string[] answer, string image)
    {
        loadPuzzle();
        myPuzzle.Add(new PuzzleQuestion(word, missingWord, answer, image));
        XmlSerializer serializer = new XmlSerializer(typeof(List<PuzzleQuestion>));
        using (StreamWriter streamWriter = new StreamWriter("Puzzle.xml"))
        {
            serializer.Serialize(streamWriter, myPuzzle);
        }
    }
    public PuzzleQuestion GetQuestion()
    {
        ResetQuestionsIfAllHaveBeenAsked();
        PuzzleQuestion unAsked;
        unAsked = myPuzzle.Where(t=>t.asked==false).OrderBy(t => Random.Range(0, 100)).FirstOrDefault();
        return unAsked;
    }
    public PuzzleQuestion GetQuestion(PuzzleQuestion dup)
    {
        ResetQuestionsIfAllHaveBeenAsked();
        PuzzleQuestion unAsked;
        unAsked = myPuzzle.Where(t => t.img != dup.img).OrderBy(t => Random.Range(0, 100)).FirstOrDefault();
        return unAsked;
    }
    public PuzzleQuestion GetQuestion(PuzzleQuestion dup, PuzzleQuestion dup2)
    {
        ResetQuestionsIfAllHaveBeenAsked();
        PuzzleQuestion unAsked;
        unAsked = myPuzzle.Where(t => t.img != dup.img).Where(t => t.img != dup2.img).OrderBy(t => Random.Range(0, 100)).FirstOrDefault();
        return unAsked;
    }
    public PuzzleQuestion[] GetRandom3()
    {
        PuzzleQuestion[] random = new PuzzleQuestion[3];
        random[0] = GetQuestion();
        random[0].asked = true;
        random[1] = GetQuestion(random[0]);
        random[2] = GetQuestion(random[0],random[1]);
        return random;
    }
    private void ResetQuestionsIfAllHaveBeenAsked()
    {
        if (myPuzzle.Any(t => t.asked == false) == false)
        {
            ResetQuestions();
        }
    }

    private void ResetQuestions()
    {
        foreach (var question in myPuzzle)
            question.asked = false;
    }
}
