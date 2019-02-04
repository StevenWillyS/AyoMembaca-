using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Xml.Serialization;
using System.Linq;

public class NewCollection {
	private List<PuzzleQuestion> myPuzzle = new List<PuzzleQuestion>();
	// Use this for initialization
	public void init() {
		if (!File.Exists("Puzzle2.xml"))
		{
			writeInitialPuzzle();
		}
		loadPuzzle();
	}

	private void loadPuzzle()
	{
		XmlSerializer serializer = new XmlSerializer(typeof(List<PuzzleQuestion>));
		using (StreamReader streamReader = new StreamReader("Puzzle2.xml"))
		{
			myPuzzle = (List<PuzzleQuestion>)serializer.Deserialize(streamReader);
		}
	}

	private void writeInitialPuzzle()
	{	
		myPuzzle.Add(new PuzzleQuestion ("Bobi berlatih tinju", "tinju", new string[] { "tinju", "karate", "masak", "makan" }, "Learning/Syllable/2. b=bobi berlatih tinju"));
		myPuzzle.Add(new PuzzleQuestion ("Cicak mencari makan", "Cicak", new string[] { "Cicak", "Buaya", "Kucing", "Anjing" }, "Learning/Syllable/3. c=cicak mencari makan"));
		myPuzzle.Add(new PuzzleQuestion ("Cicak mencari makan", "makan", new string[] { "minum", "makan", "toilet", "rumah" }, "Learning/Syllable/3. c=cicak mencari makan"));
		myPuzzle.Add(new PuzzleQuestion ("Dini membeli balon", "balon", new string[] { "bunga", "tiket", "balon", "makan" }, "Learning/Syllable/4. d=dini membeli balon"));
		myPuzzle.Add(new PuzzleQuestion ("Dini membeli balon warna hijau", "hijau", new string[] { "hijau", "merah", "kuning", "biru" }, "Learning/Syllable/4. d=dini membeli balon"));
		myPuzzle.Add(new PuzzleQuestion ("Kapal feri sedang berlayar", "berlayar", new string[] { "menyelam", "terbang", "memancing", "berlayar" }, "Learning/Syllable/6. f=kapal feri sedang berlayar"));
		myPuzzle.Add(new PuzzleQuestion ("Kapal feri sedang berlayar", "Kapal feri", new string[] { "Kapal selam", "Pesawat", "Roket", "Kapal feri" }, "Learning/Syllable/6. f=kapal feri sedang berlayar"));
		myPuzzle.Add(new PuzzleQuestion ("Gerhana bulan di malam minggu", "bulan", new string[] { "bulan", "bintang", "matahari", "satelit" }, "Learning/Syllable/7. g=gerhana bulan di malam minggu"));
		myPuzzle.Add(new PuzzleQuestion ("Gerhana bulan di malam hari", "malam", new string[] { "sore", "pagi", "siang", "malam" }, "Learning/Syllable/7. g=gerhana bulan di malam minggu"));
		myPuzzle.Add(new PuzzleQuestion ("Kopi hangat milik ayah", "Kopi", new string[] { "Nasi", "Kentang", "Kopi", "Roti" }, "Learning/Syllable/8. h=kopi hangat milik ayah"));
		myPuzzle.Add(new PuzzleQuestion ("Jarum benang milik ibu", "Jarum", new string[] { "Sapu", "Tali", "Gunting", "Jarum" }, "Learning/Syllable/10. j=jarum benang milik ibu"));
		myPuzzle.Add(new PuzzleQuestion ("Kereta api jaman belanda", "Kereta api", new string[] { "Mobil", "Kereta api", "Kapal", "Pesawat" }, "Learning/Syllable/11. k=kereta api jaman belanda"));
		myPuzzle.Add(new PuzzleQuestion ("Sarang lebah madu", "lebah", new string[] { "lebah", "beruang", "kucing", "anjing" }, "Learning/Syllable/12. l=sarang lebah madu"));
		myPuzzle.Add(new PuzzleQuestion ("Mobil baru ayah", "Mobil", new string[] { "Mobil", "Kereta api", "Kapal", "Pesawat" }, "Learning/Syllable/13. m=mobil baru ayah"));
		myPuzzle.Add(new PuzzleQuestion ("Makan nasi menggunakan sumpit", "nasi", new string[] { "roti", "nasi", "daging", "ayam" }, "Learning/Syllable/14. orang jepang memakan NAsi menggunakan garpu"));
		myPuzzle.Add(new PuzzleQuestion ("Makan nasi menggunakan sumpit", "sumpit", new string[] { "sumpit", "sendok", "garpu", "tangan" }, "Learning/Syllable/14. orang jepang memakan NAsi menggunakan garpu"));
		myPuzzle.Add(new PuzzleQuestion ("Memaku menggunakan palu", "palu", new string[] { "gergaji", "obeng", "kunci", "palu" }, "Learning/Syllable/16. memaku menggunakan PAlu"));
		myPuzzle.Add(new PuzzleQuestion ("Pak Qori memakai topi", "topi", new string[] { "topi", "sandal", "sepatu", "dasi" }, "Learning/Syllable/17. pak QOri memakai topi"));
		myPuzzle.Add(new PuzzleQuestion ("Rumah Budi", "Rumah", new string[] { "Pesawat", "Kamar", "Rumah", "Mobil" }, "Learning/Syllable/18. RUmah budi"));
		myPuzzle.Add(new PuzzleQuestion ("Sapi makan rumput", "Sapi", new string[] { "Sapi", "Kambing", "Domba", "Singa" }, "Learning/Syllable/19. SApi makan rumput"));
		myPuzzle.Add(new PuzzleQuestion ("Sapi makan rumput", "rumput", new string[] { "nasi", "rumput", "sate", "soto" }, "Learning/Syllable/19. SApi makan rumput"));
		myPuzzle.Add(new PuzzleQuestion ("Andi memakai topeng", "topeng", new string[] { "topi", "topeng", "kacamata", "masker" }, "Learning/Syllable/20. andi memakai TOpeng"));
		myPuzzle.Add(new PuzzleQuestion ("Es krim rasa vanila", "Es krim", new string[] { "Es krim", "Puding", "Kue", "Buah" }, "Learning/Syllable/22. es krim rasa VAnila"));
		myPuzzle.Add(new PuzzleQuestion ("Es krim rasa vanila", "vanila", new string[] { "vanila", "cokelat", "durian", "stroberi" }, "Learning/Syllable/22. es krim rasa VAnila"));
		myPuzzle.Add(new PuzzleQuestion ("Jam weker menunjukkan pukul 5.35", "Jam weker", new string[] { "Jam weker", "Komputer", "Telepon", "Laptop" }, "Learning/Syllable/23. jam WEker menunjukan pukul 5.35"));
		myPuzzle.Add(new PuzzleQuestion ("Xavi bermain bola", "bola", new string[] { "basket", "kasti", "bola", "kelereng" }, "Learning/Syllable/24. XAvi bermain bola"));
		myPuzzle.Add(new PuzzleQuestion ("Roni memainkan yoyo", "yoyo", new string[] { "kelereng", "yoyo", "bola", "basket" }, "Learning/Syllable/25. roni memainkan YOyo"));
		myPuzzle.Add(new PuzzleQuestion ("Kehidupan di zaman es", "es", new string[] { "es", "batu", "kayu", "sekarang" }, "Learning/Syllable/26. mammoth tinggal di ZAman es"));
		myPuzzle.Add(new PuzzleQuestion("Ikan sedang berenang", "Ikan", new string[] { "Ikan", "Burung", "Tikus", "Ular" }, "Learning/ABC/ikan"));
		myPuzzle.Add(new PuzzleQuestion("Ikan sedang berenang", "berenang", new string[] { "berenang", "berlari", "berjalan", "tidur" }, "Learning/ABC/ikan"));
		myPuzzle.Add(new PuzzleQuestion("Saya suka apel", "apel", new string[] { "rambutan", "mangga", "apel", "durian" }, "Learning/ABC/apel"));
		XmlSerializer serializer = new XmlSerializer(typeof(List<PuzzleQuestion>));
		using (StreamWriter streamWriter = new StreamWriter("Puzzle2.xml"))
		{
			serializer.Serialize(streamWriter, myPuzzle);
		}
	}

	public void addQuestion(string word,string missingWord, string[] answer, string image)
	{
		loadPuzzle();
		myPuzzle.Add(new PuzzleQuestion(word, missingWord, answer, image));
		XmlSerializer serializer = new XmlSerializer(typeof(List<PuzzleQuestion>));
		using (StreamWriter streamWriter = new StreamWriter("Puzzle2.xml"))
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
