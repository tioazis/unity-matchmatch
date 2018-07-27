using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class GameController23 : MonoBehaviour
{

    [SerializeField]
    private Sprite bgImage;
    public List<Button> btns = new List<Button>();

    public Sprite[] puzzles;

    public List<Sprite> gamePuzzles = new List<Sprite>();

    private bool tebak1, tebak2, tebak3;

    private int hitungtebakan;
    public int hitungtebakanbenar;
    public int gametebak;

    private int indekstebak1, indekstebak2, indekstebak3;

    private string namatebakan1, namatebakan2, namatebakan3;

    //Timer
    // public float Waktu;
    //public Text TimerText;
    // public bool itungin;

    //untuk scoring
    // public float SisaWaktu;
    public float KartuBenar;
    bool special = false;
    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        puzzles = Resources.LoadAll<Sprite>("Sprites/Icon");
        Debug.Log("reloaded");
    }
    void Start()
    {
        //Waktu = 60;
        //itungin = false;
        GameObject panelGame = GameObject.Find("Canvas").transform.FindChild("Panel").gameObject;
        //TimerText = panelGame.transform.FindChild("Text").GetComponent<Text>();

        GetButton();
        AddListeners();
        AddGamePuzzles3();
        AddGamePuzzles2();

        Shuffle(gamePuzzles);
        gametebak = gamePuzzles.Count / 3;
    }

    void Update()
    {
        KartuBenar = hitungtebakanbenar + 1;


        /* 
        if (itungin == true )
         {
            Waktu -= Time.deltaTime;
             TimerText.text = Waktu.ToString("f0");
             Debug.Log("mulai menghitug");
         }*/

        /*if (Waktu <= 0)
        {
            Debug.Log("game selesai");
            itungin = false;
            Application.LoadLevel("Result Scene");
            Debug.Log(SisaWaktu + " " + KartuBenar);
        }*/
    }

    void GetButton()
    {
        GameObject[] objects = GameObject.FindGameObjectsWithTag("PuzzleButton");

        for (int i = 0; i < objects.Length; i++)
        {
            btns.Add(objects[i].GetComponent<Button>());
            btns[i].image.sprite = bgImage;
        }
    }
    void AddGamePuzzles3()
    {
        int looper = 9;
        int index = 0;//

        for (int i = 0; i < looper; i++)
        {
            if (index == looper / 3)
            {
                index = 0;
            }
            gamePuzzles.Add(puzzles[index]);
            index++;
        }
    }

    void AddGamePuzzles2()
    {
        int looper = 15;
        int index = 4; //

        for (int i = 9; i < looper; i++)
        {
            if (index == looper / 2)
            {
                index = 4;
            }
            gamePuzzles.Add(puzzles[index]);
            
            index++;
        }
    }

    void AddListeners()
    {
        foreach (Button btn in btns)
        {
            btn.onClick.AddListener(() => PickAPuzzle());

        }
    }
    public void PickAPuzzle()
    {
        string name = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name;
        Debug.Log("Clicked" + name);

        if (!tebak1)
        {
            tebak1 = true;

            indekstebak1 = int.Parse(UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name);

            namatebakan1 = gamePuzzles[indekstebak1].name;

            btns[indekstebak1].image.sprite = gamePuzzles[indekstebak1];

            // itungin = true; // ketika klik pertama langsung mulai menghitung

        //if(tebak1 == "rpg01")


        }
        else if (!tebak2)
        {
            tebak2 = true;

            indekstebak2 = int.Parse(UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name);

            namatebakan2 = gamePuzzles[indekstebak2].name;

            btns[indekstebak2].image.sprite = gamePuzzles[indekstebak2];
        }
        else if (!tebak3)
        {
            tebak3 = true;

            indekstebak3 = int.Parse(UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name);

            namatebakan3 = gamePuzzles[indekstebak3].name;

            btns[indekstebak3].image.sprite = gamePuzzles[indekstebak3];

            hitungtebakan++;
            /*
            if (namatebakan1 == namatebakan2 && namatebakan3 == namatebakan2)
            {
                Debug.Log("sama coy !");
            }
            else
            {
                Debug.Log("beda coy !");
            }
            */
            StartCoroutine(CekYangSama());
        }
    }

    IEnumerator CekYangSama()
    {
        yield return new WaitForSeconds(1f);
        if (namatebakan1 == namatebakan2 && namatebakan2 == namatebakan3)
        {
            yield return new WaitForSeconds(.5f);
            btns[indekstebak1].interactable = false;
            btns[indekstebak2].interactable = false;
            btns[indekstebak3].interactable = false;

            btns[indekstebak1].image.color = new Color(0, 0, 0, 0);
            btns[indekstebak2].image.color = new Color(0, 0, 0, 0);
            btns[indekstebak3].image.color = new Color(0, 0, 0, 0);

            // Waktu += 3;//jika benar waktu akan bertambah 3 point

            PengecekanGameSelesai();
        }
        else
        {
            yield return new WaitForSeconds(.5f);

            btns[indekstebak1].image.sprite = bgImage;
            btns[indekstebak2].image.sprite = bgImage;
            btns[indekstebak3].image.sprite = bgImage;
        }

        yield return new WaitForSeconds(.5f);

        tebak1 = tebak2 = tebak3 = false;
    }

    void PengecekanGameSelesai()
    {
        hitungtebakanbenar++;

        if (hitungtebakanbenar == gametebak)
        {
            Debug.Log("game selesai");
            // itungin = false;
            //SisaWaktu = Waktu;
            Application.LoadLevel("Result Scene");
            MenerimaSkorAkhir();
            KartuBenar = hitungtebakanbenar;
        }

        /*    else if (Waktu <= 0)
            {
                Debug.Log("game selesai");
                itungin = false;
                Application.LoadLevel("Result Scene");
                KartuBenar = hitungtebakanbenar;
            }*/
    }

    void Shuffle(List<Sprite> list)
    {
        for (int i = 0; i < list.Count; i++)
        {
            Sprite temp = list[i];
            int acakindeks = Random.Range(0, list.Count);
            list[i] = list[acakindeks];
            list[acakindeks] = temp;


        }
    }

    public void MenerimaSkorAkhir()
    {
        //  PlayerPrefs.SetFloat("SkorWaktu", SisaWaktu);
        PlayerPrefs.SetFloat("SkorKartu", KartuBenar);
    }
}
