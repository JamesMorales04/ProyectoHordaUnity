using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character1Core : MonoBehaviour
{

    public HealthCommon healthCharacter;
    public ShootingCommon shootingCharacter;

    [SerializeField]
    private int shootingMode;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        shootingCharacter.ShootingMode(shootingMode);
    }


}
