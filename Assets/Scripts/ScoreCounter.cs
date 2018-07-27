using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;


public class ScoreCounter : MonoBehaviour {

    GameController AmbilScoreData;

    public Text TextScoreWaktu;
    public Text TextScoreKartu;
    public Text TextSkorTotal;
    private float ScoreAkhir;
    private float WaktuSisa;
    private float KartuHabis;

    void Awake()
    {
        print(PlayerPrefs.GetFloat("SkorWaktu"));
        WaktuSisa = (int)PlayerPrefs.GetFloat("SkorWaktu");
        print("Hasil Akhir Waktu : " + WaktuSisa);
        TextScoreWaktu.text = " "+ WaktuSisa;

        KartuHabis = (int)PlayerPrefs.GetFloat("SkorKartu");
        print("kartu yang habis : " + (KartuHabis));
        TextScoreKartu.text = " " + KartuHabis;

        ScoreAkhir = (KartuHabis * 500) + (ScoreAkhir * 10);
        
        TextSkorTotal.text = " " + ScoreAkhir;
    }
    void Start() {
        GameObject Panel = GameObject.Find("Canvas").transform.FindChild("Panel").gameObject;
        TextSkorTotal = Panel.transform.FindChild("9999").GetComponent<Text>();
        TextScoreKartu = Panel.transform.FindChild("00").GetComponent<Text>();
        
    }

}