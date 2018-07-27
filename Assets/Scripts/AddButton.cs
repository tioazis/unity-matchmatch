using UnityEngine;
using System.Collections;

public class AddButton : MonoBehaviour {

    [SerializeField]
    private Transform puzzlefield;

    [SerializeField]
    private GameObject btn;
   

    void Awake()
    {
        for (int i=0 ; i<15; i++ ) 
        {
            GameObject button = Instantiate(btn);
            button.name = "" +i;
            button.transform.SetParent(puzzlefield,false);

        }

    }
    

}
