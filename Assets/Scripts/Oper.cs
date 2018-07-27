using UnityEngine;
using System.Collections;

public class Oper : MonoBehaviour {
    public float HasilOperSkor;
    public float HasilOperWaktu;

    GameController YangDioper;
    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);

    }


	// Use this for initialization
	void Start () {
        YangDioper = GameObject.Find("GameController").GetComponent<GameController>();
    }
	
	// Update is called once per frame
	void Update () {
        HasilOperSkor = YangDioper.hitungtebakanbenar;
        HasilOperWaktu = YangDioper.KartuBenar;
        Debug.Log("tersimpan" + HasilOperWaktu + HasilOperSkor);
    }
}
