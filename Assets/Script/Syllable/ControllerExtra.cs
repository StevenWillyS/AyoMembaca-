using UnityEngine;
using UnityEngine.UI;

public class ControllerExtra : Controller {
    private string[] word = new string[26];

    // Use this for initialization
    void Start () {
        sound = GetComponent<AudioSource>();
        word[0] = "A     I     U     E     O";
        word[1] = "BA    BI    BU    BE    BO";
        word[2] = "CA    CI    CU    CE    CO";
        word[3] = "DA    DI    DU    DE    DO";
        word[4] = "E";
        word[5] = "FA    FI    FU    FE    FO";
        word[6] = "GA    GI    GU    GE    GO";
        word[7] = "HA    HI    HU    HE    HO";
        word[8] = "I";
        word[9] = "JA    JI    JU    JE    JO";
        word[10] = "KA    KI    KU    KE    KO";
        word[11] = "LA    LI    LU    LE    LO";
        word[12] = "MA    MI    MU    ME    MO";
        word[13] = "NA    NI    NU    NE    NO";
        word[14] = "O";
        word[15] = "PA    PI    PU    PE    PO";
        word[16] = "QA    QI    QU    QE    QO";
        word[17] = "RA    RI    RU    RE    RO";
        word[18] = "SA    SI    SU    SE    SO";
        word[19] = "TA    TI    TU    TE    TO";
        word[20] = "U";
        word[21] = "VA    VI    VU    VE    VO";
        word[22] = "WA    WI    WU    WE    WO";
        word[23] = "XA    XI    XU    XE    XO";
        word[24] = "YA    YI    YU    YE    YO";
        word[25] = "ZA    ZI    ZU    ZE    ZO";
    }
    public void changeUI(string target)
    {
        char letter = target[0];
        int i = letter-65;
        abc.text = word[i];
        sound.clip = voice[i];
        ui.sprite = mysprite[i];
        desc.text = desk[i];
    }
}
