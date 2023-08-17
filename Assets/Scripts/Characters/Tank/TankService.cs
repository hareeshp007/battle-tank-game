using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankService : MonoBehaviour
{
    public TankView tankView;
    // Start is called before the first frame update
    void Start()
    {
        GameStart();
    }
    public void GameStart()
    {
        TankModel model = new TankModel();
        TankController tankController=new TankController(model,tankView);
    }
}
