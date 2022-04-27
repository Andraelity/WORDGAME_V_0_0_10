using UnityEngine;
using UnityEngine.SceneManagement;
using EZCameraShake;

using readDataFile;

public class ShakeCamaraRunning : MonoBehaviour 
{
    Vector3 posInf = new Vector3(0.25f, 0.25f, 0.25f);
    Vector3 rotInf = new Vector3(1, 1, 1); 
    public float magn = 1, rough = 1, fadeIn = 0.1f, fadeOut = 2f;

    bool modValues;
    bool showList;

    CameraShakeInstance shake;


	void Update()
    {

        if (ScriptCommunication.boolType_state_CamaraShake == true)
        {   

            ScriptCommunication.boolType_state_CamaraShake = false;

            CameraShakeInstance c = CameraShaker.Instance.ShakeOnce(magn, rough, fadeIn, fadeOut);
            c.PositionInfluence = posInf;
            c.RotationInfluence = rotInf;
        }
	}
}
