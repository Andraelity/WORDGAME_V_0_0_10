using System.Collections;
using System.Collections.Generic;
using System;
using System.IO;

using UnityEngine;
using UnityEngine.SceneManagement;

using computacion;
using readDataFromUI;
using readDataFile;

using CS_classObject;


namespace C0CS_WordGame
{


public class C0CS_WordGame_V_0_0_10 : MonoBehaviour
{


    private int HEIGHT = 1000;
    private int WIDTH  = 2000;
    
    private int HEIGHTlargeMemory = 3000;
    private int WIDTHlargeMemory  = 6000;
    

    private float time;

    public float timeNow;
    public float updateInterval = 0.5F;
    private double lastInterval;
    private int frames;
    private float fps;
    
    public const int CHARACTERWIDTH = 34;
    public const int CHARACTERWIDTH_size14 = 12;
    public const int CHARACTERWIDTH_size22 = 17;

    private float changeInterval;



    Renderer render;
    Material material_PlaneWriteTextField;

    public GameObject object_PlaneWrite;
    Material material_PlaneWrite;

    public ComputeShader computacion;


    ComputeBuffer bufferImageColor;
    ComputeBuffer bufferImageColorWriteTextField;
    ComputeBuffer bufferLargeMemory;

    ComputeBuffer bufferTextureTransparentPositionX;
    ComputeBuffer bufferTextureTransparentPositionY;

    ComputeBuffer bufferTextureBigPositionX;
    ComputeBuffer bufferTextureBigPositionY;


    ComputeBuffer bufferTextureCharacterPositionX;
    ComputeBuffer bufferTextureCharacterPositionY;

    ComputeBuffer bufferTextureAlphabetColor;
    ComputeBuffer bufferTextureNumberColor;
    ComputeBuffer bufferTexturePortugueseColor;


    ComputeBuffer bufferTextureCharacterPositionX_size14;
    ComputeBuffer bufferTextureCharacterPositionY_size14;
    
    ComputeBuffer bufferTextureAlphabetColor_size14;
    ComputeBuffer bufferTextureNumberColor_size14;
    ComputeBuffer bufferTexturePortugueseColor_size14;


    ComputeBuffer bufferTextureCharacterPositionX_size22;
    ComputeBuffer bufferTextureCharacterPositionY_size22;
    
    ComputeBuffer bufferTextureAlphabetColor_size22;
    ComputeBuffer bufferTextureNumberColor_size22;
    ComputeBuffer bufferTexturePortugueseColor_size22;

    ComputeBuffer bufferPointerPositionX;
    ComputeBuffer bufferPointerPositionY;


    ComputeBuffer bufferColorPointer;

    ComputeBuffer bufferHorizontalPositionX;
    ComputeBuffer bufferHorizontalPositionY;

    ComputeBuffer bufferVerticalPositionX;
    ComputeBuffer bufferVerticalPositionY;




    static int _kernelforLoadImageColor;
    static int _kernelforLoadImageColorWriteTextField;

    static int _kernelforLoadTextureBig;
    static int _kernelforPrintTextureBig;

    static int _kernelforLoadTextureTransparent;
    static int _kernelforPrintTextureTransparent;



    static int _kernelforLoadTextureCharacterPosition;

    static int _kernelforPrintTilesAlphabetWriteTextField;

    static int _kernelforPrintTilesAlphabetIndividualWriteTextField;
    static int _kernelforPrintTilesNumberIndividualWriteTextField;
    static int _kernelforPrintTilesPortugueseIndividualWriteTextField;

    static int _kernelforPrintTilesAlphabet;

    static int _kernelforPrintTilesAlphabetIndividual;
    static int _kernelforPrintTilesNumberIndividual;
    static int _kernelforPrintTilesPortugueseIndividual;

    
    static int _kernelforLoadTextureCharacterPosition_size14;

    static int _kernelforPrintTilesAlphabet_size14;

    static int _kernelforPrintTilesAlphabetIndividual_size14;
    static int _kernelforPrintTilesNumberIndividual_size14;
    static int _kernelforPrintTilesPortugueseIndividual_size14;



    static int _kernelforLoadTextureCharacterPosition_size22;


    static int _kernelforPrintTilesAlphabetWriteTextField_size22;

    static int _kernelforPrintTilesAlphabetIndividualWriteTextField_size22;
    static int _kernelforPrintTilesNumberIndividualWriteTextField_size22;
    static int _kernelforPrintTilesPortugueseIndividualWriteTextField_size22;


    static int _kernelforPrintTilesAlphabet_size22;

    static int _kernelforPrintTilesAlphabetIndividual_size22;
    static int _kernelforPrintTilesNumberIndividual_size22;
    static int _kernelforPrintTilesPortugueseIndividual_size22;


    static int _kernelforLoadPointerPosition;

    static int _kernelforPrintPointer;

    static int _kernelforPrintPointerBlack;


    static int _kernelforLoadHorizontalPosition;
    static int _kernelforPrintHorizontal;
    static int _kernelforPrintHorizontalBlack;


    static int _kernelforLoadVerticalPosition;
    static int _kernelforPrintVertical;
    static int _kernelforPrintVerticalBlack;



//////////////////////////////////////////////////////////////////////////////////////////////////
// TEXTFIELD AND PRINT WORDS CONST AND VARIABLES
//////////////////////////////////////////////////////////////////////////////////////////////////



    const int constPositionPointerX = 1949;
    const int constPositionPointerY = 945;

    int PositionPointerX = 1949;
    int PositionPointerY = 945;

    bool activeKeaboard = false;
    bool activeMiniGame = false;
    bool activateControl = false;


    static string StringTextField = "";

    int _XaxisWord22 = 1900;
    int _YaxisWord22 = 500;


    const int _XaxisTextFieldBegin = 1940;
    const int _YaxisTextFieldBegin = 935;

    int _XaxisTextField = _XaxisTextFieldBegin;
    int _YaxisTextField = _YaxisTextFieldBegin;

    bool shiftKey = false;

    bool afterAppostrophe = false;
    int appostrophe = 0;
    

    bool wordCheck0 = false;
    bool CheckBool = true;
    bool CheckBool1 = false;


//////////////////////////////////////////////////////////////////////////////////////////////////
// TEXTFIELD AND PRINT WORDS CONST AND VARIABLES
//////////////////////////////////////////////////////////////////////////////////////////////////
    
    public ParticleSystem particle_Rigth0;
    public ParticleSystem particle_Rigth1;

    public ParticleSystem particle_Smoke0;
    public ParticleSystem particle_Smoke1;

    public ParticleSystem particle_Wrong;

    public ParticleSystem particle_Answer;
    Vector3 Vector3Type_position_Answer ;



    void OnGUI()
    {

        GUILayout.Label("" + fps.ToString("f2"));

    }



    void Start()
    {

        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        /// MAIN OBJECTS
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        
        render = GetComponent<Renderer>();

        material_PlaneWriteTextField = render.material;

        material_PlaneWrite = object_PlaneWrite.GetComponent<Renderer>().material; 
 
    
        computacion.SetInt("_WIDTH", WIDTH);
        computacion.SetInt("_WIDTHlargeMemory", WIDTHlargeMemory);



        material_PlaneWriteTextField.SetInt("_WIDTH", WIDTH);
        material_PlaneWriteTextField.SetInt("_HEIGHT", HEIGHT);

        material_PlaneWrite.SetInt("_WIDTH", WIDTH);
        material_PlaneWrite.SetInt("_HEIGHT", HEIGHT);

     
        bufferLargeMemory = new ComputeBuffer(HEIGHTlargeMemory * WIDTHlargeMemory, 16);

        bufferImageColor = new ComputeBuffer(HEIGHT * WIDTH, 16);

        bufferImageColorWriteTextField = new ComputeBuffer(HEIGHT * WIDTH, 16);


        material_PlaneWrite.SetBuffer("bufferImageColor", bufferImageColor);
        material_PlaneWriteTextField.SetBuffer("bufferImageColorWriteTextField", bufferImageColorWriteTextField);


        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        /// MAIN OBJECTS
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////


        _kernelforLoadImageColor = computacion.FindKernel("forLoadImageColor");


        _kernelforLoadTextureTransparent = computacion.FindKernel("forLoadTextureTransparent");
        _kernelforPrintTextureTransparent = computacion.FindKernel("forPrintTextureTransparent");

        _kernelforLoadTextureBig = computacion.FindKernel("forLoadTextureBig");
        _kernelforPrintTextureBig = computacion.FindKernel("forPrintTextureBig");


        _kernelforLoadTextureCharacterPosition = computacion.FindKernel("forLoadTextureCharacterPosition");


        _kernelforPrintTilesAlphabetWriteTextField = computacion.FindKernel("forPrintTilesAlphabetWriteTextField");
 
        _kernelforPrintTilesAlphabetIndividualWriteTextField = computacion.FindKernel("forPrintTilesAlphabetIndividualWriteTextField");
        _kernelforPrintTilesNumberIndividualWriteTextField = computacion.FindKernel("forPrintTilesNumberIndividualWriteTextField");
        _kernelforPrintTilesPortugueseIndividualWriteTextField = computacion.FindKernel("forPrintTilesPortugueseIndividualWriteTextField");


        _kernelforPrintTilesAlphabet = computacion.FindKernel("forPrintTilesAlphabet");

        _kernelforPrintTilesAlphabetIndividual = computacion.FindKernel("forPrintTilesAlphabetIndividual");
        _kernelforPrintTilesNumberIndividual = computacion.FindKernel("forPrintTilesNumberIndividual");
        _kernelforPrintTilesPortugueseIndividual = computacion.FindKernel("forPrintTilesPortugueseIndividual");



        _kernelforLoadTextureCharacterPosition_size14  = computacion.FindKernel("forLoadTextureCharacterPosition_size14");

        _kernelforPrintTilesAlphabet_size14 = computacion.FindKernel("forPrintTilesAlphabet_size14");

        _kernelforPrintTilesAlphabetIndividual_size14 = computacion.FindKernel("forPrintTilesAlphabetIndividual_size14");
        _kernelforPrintTilesNumberIndividual_size14 = computacion.FindKernel("forPrintTilesNumberIndividual_size14");
        _kernelforPrintTilesPortugueseIndividual_size14 = computacion.FindKernel("forPrintTilesPortugueseIndividual_size14");



        _kernelforLoadTextureCharacterPosition_size22  = computacion.FindKernel("forLoadTextureCharacterPosition_size22");


        _kernelforPrintTilesAlphabetWriteTextField_size22 = computacion.FindKernel("forPrintTilesAlphabetWriteTextField_size22");

        _kernelforPrintTilesAlphabetIndividualWriteTextField_size22 = computacion.FindKernel("forPrintTilesAlphabetIndividualWriteTextField_size22");
        _kernelforPrintTilesNumberIndividualWriteTextField_size22 = computacion.FindKernel("forPrintTilesNumberIndividualWriteTextField_size22");
        _kernelforPrintTilesPortugueseIndividualWriteTextField_size22 = computacion.FindKernel("forPrintTilesPortugueseIndividualWriteTextField_size22");


        _kernelforPrintTilesAlphabet_size22 = computacion.FindKernel("forPrintTilesAlphabet_size22");

        _kernelforPrintTilesAlphabetIndividual_size22 = computacion.FindKernel("forPrintTilesAlphabetIndividual_size22");
        _kernelforPrintTilesNumberIndividual_size22 = computacion.FindKernel("forPrintTilesNumberIndividual_size22");
        _kernelforPrintTilesPortugueseIndividual_size22 = computacion.FindKernel("forPrintTilesPortugueseIndividual_size22");



        _kernelforLoadPointerPosition = computacion.FindKernel("forLoadPointerPosition");

        _kernelforPrintPointer = computacion.FindKernel("forPrintPointer");
        _kernelforPrintPointerBlack = computacion.FindKernel("forPrintPointerBlack");


        _kernelforLoadHorizontalPosition = computacion.FindKernel("forLoadHorizontalPosition");
        _kernelforPrintHorizontal = computacion.FindKernel("forPrintHorizontal");
        _kernelforPrintHorizontalBlack = computacion.FindKernel("forPrintHorizontalBlack");

        _kernelforLoadVerticalPosition = computacion.FindKernel("forLoadVerticalPosition");
        _kernelforPrintVertical = computacion.FindKernel("forPrintVertical");
        _kernelforPrintVerticalBlack = computacion.FindKernel("forPrintVerticalBlack");





        bufferTextureTransparentPositionX = new ComputeBuffer(1000000, 4);
        bufferTextureTransparentPositionY = new ComputeBuffer(1000000, 4);

        bufferTextureBigPositionX = new ComputeBuffer(HEIGHT * WIDTH, 4);
        bufferTextureBigPositionY = new ComputeBuffer(HEIGHT * WIDTH, 4);


        bufferTextureCharacterPositionX = new ComputeBuffer(43904, 4);
        bufferTextureCharacterPositionY = new ComputeBuffer(43904, 4);

        bufferTextureAlphabetColor = new ComputeBuffer(175616, 4); 
        
        bufferTextureNumberColor = new ComputeBuffer(175616, 4); 

        bufferTexturePortugueseColor = new ComputeBuffer(175616, 4); 


        bufferTextureCharacterPositionX_size14 = new ComputeBuffer(6468, 4);
        bufferTextureCharacterPositionY_size14 = new ComputeBuffer(6468, 4);

        bufferTextureAlphabetColor_size14 = new ComputeBuffer(25872, 4); 
        
        bufferTextureNumberColor_size14 = new ComputeBuffer(25872, 4); 

        bufferTexturePortugueseColor_size14 = new ComputeBuffer(25872, 4); 



        bufferTextureCharacterPositionX_size22 = new ComputeBuffer(16184, 4);
        bufferTextureCharacterPositionY_size22 = new ComputeBuffer(16184, 4);

        bufferTextureAlphabetColor_size22 = new ComputeBuffer(64736, 4); 
        
        bufferTextureNumberColor_size22 = new ComputeBuffer(64736, 4); 

        bufferTexturePortugueseColor_size22 = new ComputeBuffer(64736, 4); 


        bufferPointerPositionX = new ComputeBuffer(440, 4);
        bufferPointerPositionY = new ComputeBuffer(440, 4);

        bufferColorPointer = new ComputeBuffer(3, 4);

        
        bufferHorizontalPositionX = new ComputeBuffer(280, 4);
        bufferHorizontalPositionY = new ComputeBuffer(280, 4);

        bufferVerticalPositionX = new ComputeBuffer(280, 4);
        bufferVerticalPositionY = new ComputeBuffer(280, 4);



        computacion.SetBuffer(_kernelforLoadImageColor, "bufferImageColor", bufferImageColor);
        computacion.SetBuffer(_kernelforLoadImageColor, "bufferLargeMemory", bufferLargeMemory);

        computacion.SetBuffer(_kernelforLoadTextureBig, "bufferTextureBigPositionX",bufferTextureBigPositionX);
        computacion.SetBuffer(_kernelforLoadTextureBig, "bufferTextureBigPositionY",bufferTextureBigPositionY);

        computacion.SetBuffer(_kernelforPrintTextureBig,"bufferLargeMemory", bufferLargeMemory);
        computacion.SetBuffer(_kernelforPrintTextureBig,"bufferTextureBigPositionX",bufferTextureBigPositionX);
        computacion.SetBuffer(_kernelforPrintTextureBig,"bufferTextureBigPositionY",bufferTextureBigPositionY);

        computacion.SetBuffer(_kernelforLoadTextureTransparent,"bufferTextureTransparentPositionX", bufferTextureTransparentPositionX);
        computacion.SetBuffer(_kernelforLoadTextureTransparent,"bufferTextureTransparentPositionY", bufferTextureTransparentPositionY);

        computacion.SetBuffer(_kernelforPrintTextureTransparent,"bufferImageColor", bufferImageColor);
        computacion.SetBuffer(_kernelforPrintTextureTransparent,"bufferTextureTransparentPositionX", bufferTextureTransparentPositionX);
        computacion.SetBuffer(_kernelforPrintTextureTransparent,"bufferTextureTransparentPositionY", bufferTextureTransparentPositionY);



        computacion.SetBuffer(_kernelforLoadTextureCharacterPosition, "bufferTextureCharacterPositionX", bufferTextureCharacterPositionX);
        computacion.SetBuffer(_kernelforLoadTextureCharacterPosition, "bufferTextureCharacterPositionY", bufferTextureCharacterPositionY);


        computacion.SetBuffer(_kernelforPrintTilesAlphabetWriteTextField, "bufferImageColorWriteTextField", bufferImageColorWriteTextField);
        computacion.SetBuffer(_kernelforPrintTilesAlphabetWriteTextField, "bufferTextureCharacterPositionX", bufferTextureCharacterPositionX);
        computacion.SetBuffer(_kernelforPrintTilesAlphabetWriteTextField, "bufferTextureCharacterPositionY", bufferTextureCharacterPositionY);
        computacion.SetBuffer(_kernelforPrintTilesAlphabetWriteTextField, "bufferTextureAlphabetColor", bufferTextureAlphabetColor);
 
        computacion.SetBuffer(_kernelforPrintTilesAlphabetIndividualWriteTextField, "bufferImageColorWriteTextField", bufferImageColorWriteTextField);
        computacion.SetBuffer(_kernelforPrintTilesAlphabetIndividualWriteTextField, "bufferTextureCharacterPositionX", bufferTextureCharacterPositionX);
        computacion.SetBuffer(_kernelforPrintTilesAlphabetIndividualWriteTextField, "bufferTextureCharacterPositionY", bufferTextureCharacterPositionY);
        computacion.SetBuffer(_kernelforPrintTilesAlphabetIndividualWriteTextField, "bufferTextureAlphabetColor", bufferTextureAlphabetColor);
         
        computacion.SetBuffer(_kernelforPrintTilesNumberIndividualWriteTextField, "bufferImageColorWriteTextField", bufferImageColorWriteTextField);
        computacion.SetBuffer(_kernelforPrintTilesNumberIndividualWriteTextField, "bufferTextureCharacterPositionX", bufferTextureCharacterPositionX);
        computacion.SetBuffer(_kernelforPrintTilesNumberIndividualWriteTextField, "bufferTextureCharacterPositionY", bufferTextureCharacterPositionY);
        computacion.SetBuffer(_kernelforPrintTilesNumberIndividualWriteTextField, "bufferTextureNumberColor", bufferTextureNumberColor);

        computacion.SetBuffer(_kernelforPrintTilesPortugueseIndividualWriteTextField, "bufferImageColorWriteTextField", bufferImageColorWriteTextField);
        computacion.SetBuffer(_kernelforPrintTilesPortugueseIndividualWriteTextField, "bufferTextureCharacterPositionX", bufferTextureCharacterPositionX);
        computacion.SetBuffer(_kernelforPrintTilesPortugueseIndividualWriteTextField, "bufferTextureCharacterPositionY", bufferTextureCharacterPositionY);
        computacion.SetBuffer(_kernelforPrintTilesPortugueseIndividualWriteTextField, "bufferTexturePortugueseColor", bufferTexturePortugueseColor);



        computacion.SetBuffer(_kernelforPrintTilesAlphabet,"bufferLargeMemory", bufferLargeMemory);
        computacion.SetBuffer(_kernelforPrintTilesAlphabet,"bufferTextureCharacterPositionX", bufferTextureCharacterPositionX);
        computacion.SetBuffer(_kernelforPrintTilesAlphabet,"bufferTextureCharacterPositionY", bufferTextureCharacterPositionY);
        computacion.SetBuffer(_kernelforPrintTilesAlphabet,"bufferTextureAlphabetColor", bufferTextureAlphabetColor);

        computacion.SetBuffer(_kernelforPrintTilesAlphabetIndividual,"bufferLargeMemory", bufferLargeMemory);
        computacion.SetBuffer(_kernelforPrintTilesAlphabetIndividual,"bufferTextureCharacterPositionX", bufferTextureCharacterPositionX);
        computacion.SetBuffer(_kernelforPrintTilesAlphabetIndividual,"bufferTextureCharacterPositionY", bufferTextureCharacterPositionY);
        computacion.SetBuffer(_kernelforPrintTilesAlphabetIndividual,"bufferTextureAlphabetColor", bufferTextureAlphabetColor);
        
        computacion.SetBuffer(_kernelforPrintTilesNumberIndividual, "bufferLargeMemory", bufferLargeMemory);
        computacion.SetBuffer(_kernelforPrintTilesNumberIndividual, "bufferTextureCharacterPositionX", bufferTextureCharacterPositionX);
        computacion.SetBuffer(_kernelforPrintTilesNumberIndividual, "bufferTextureCharacterPositionY", bufferTextureCharacterPositionY);
        computacion.SetBuffer(_kernelforPrintTilesNumberIndividual, "bufferTextureNumberColor", bufferTextureNumberColor);

        computacion.SetBuffer(_kernelforPrintTilesPortugueseIndividual, "bufferLargeMemory", bufferLargeMemory);
        computacion.SetBuffer(_kernelforPrintTilesPortugueseIndividual, "bufferTextureCharacterPositionX", bufferTextureCharacterPositionX);
        computacion.SetBuffer(_kernelforPrintTilesPortugueseIndividual, "bufferTextureCharacterPositionY", bufferTextureCharacterPositionY);
        computacion.SetBuffer(_kernelforPrintTilesPortugueseIndividual, "bufferTexturePortugueseColor", bufferTexturePortugueseColor);



        computacion.SetBuffer(_kernelforLoadTextureCharacterPosition_size14, "bufferTextureCharacterPositionX_size14", bufferTextureCharacterPositionX_size14);
        computacion.SetBuffer(_kernelforLoadTextureCharacterPosition_size14, "bufferTextureCharacterPositionY_size14", bufferTextureCharacterPositionY_size14);

        computacion.SetBuffer(_kernelforPrintTilesAlphabet_size14,"bufferLargeMemory", bufferLargeMemory);
        computacion.SetBuffer(_kernelforPrintTilesAlphabet_size14,"bufferTextureCharacterPositionX_size14", bufferTextureCharacterPositionX_size14);
        computacion.SetBuffer(_kernelforPrintTilesAlphabet_size14,"bufferTextureCharacterPositionY_size14", bufferTextureCharacterPositionY_size14);
        computacion.SetBuffer(_kernelforPrintTilesAlphabet_size14,"bufferTextureAlphabetColor_size14", bufferTextureAlphabetColor_size14);

        computacion.SetBuffer(_kernelforPrintTilesAlphabetIndividual_size14,"bufferLargeMemory", bufferLargeMemory);
        computacion.SetBuffer(_kernelforPrintTilesAlphabetIndividual_size14,"bufferTextureCharacterPositionX_size14", bufferTextureCharacterPositionX_size14);
        computacion.SetBuffer(_kernelforPrintTilesAlphabetIndividual_size14,"bufferTextureCharacterPositionY_size14", bufferTextureCharacterPositionY_size14);
        computacion.SetBuffer(_kernelforPrintTilesAlphabetIndividual_size14,"bufferTextureAlphabetColor_size14", bufferTextureAlphabetColor_size14);

        computacion.SetBuffer(_kernelforPrintTilesNumberIndividual_size14, "bufferLargeMemory", bufferLargeMemory);
        computacion.SetBuffer(_kernelforPrintTilesNumberIndividual_size14, "bufferTextureCharacterPositionX_size14", bufferTextureCharacterPositionX_size14);
        computacion.SetBuffer(_kernelforPrintTilesNumberIndividual_size14, "bufferTextureCharacterPositionY_size14", bufferTextureCharacterPositionY_size14);
        computacion.SetBuffer(_kernelforPrintTilesNumberIndividual_size14, "bufferTextureNumberColor_size14", bufferTextureNumberColor_size14);

        computacion.SetBuffer(_kernelforPrintTilesPortugueseIndividual_size14, "bufferLargeMemory", bufferLargeMemory);
        computacion.SetBuffer(_kernelforPrintTilesPortugueseIndividual_size14, "bufferTextureCharacterPositionX_size14", bufferTextureCharacterPositionX_size14);
        computacion.SetBuffer(_kernelforPrintTilesPortugueseIndividual_size14, "bufferTextureCharacterPositionY_size14", bufferTextureCharacterPositionY_size14);
        computacion.SetBuffer(_kernelforPrintTilesPortugueseIndividual_size14, "bufferTexturePortugueseColor_size14", bufferTexturePortugueseColor_size14);



        computacion.SetBuffer(_kernelforLoadTextureCharacterPosition_size22, "bufferTextureCharacterPositionX_size22", bufferTextureCharacterPositionX_size22);
        computacion.SetBuffer(_kernelforLoadTextureCharacterPosition_size22, "bufferTextureCharacterPositionY_size22", bufferTextureCharacterPositionY_size22);


        computacion.SetBuffer(_kernelforPrintTilesAlphabetWriteTextField_size22, "bufferImageColorWriteTextField", bufferImageColorWriteTextField);
        computacion.SetBuffer(_kernelforPrintTilesAlphabetWriteTextField_size22, "bufferTextureCharacterPositionX_size22", bufferTextureCharacterPositionX_size22);
        computacion.SetBuffer(_kernelforPrintTilesAlphabetWriteTextField_size22, "bufferTextureCharacterPositionY_size22", bufferTextureCharacterPositionY_size22);
        computacion.SetBuffer(_kernelforPrintTilesAlphabetWriteTextField_size22, "bufferTextureAlphabetColor_size22", bufferTextureAlphabetColor_size22);

        computacion.SetBuffer(_kernelforPrintTilesAlphabetIndividualWriteTextField_size22, "bufferImageColorWriteTextField", bufferImageColorWriteTextField);
        computacion.SetBuffer(_kernelforPrintTilesAlphabetIndividualWriteTextField_size22, "bufferTextureCharacterPositionX_size22", bufferTextureCharacterPositionX_size22);
        computacion.SetBuffer(_kernelforPrintTilesAlphabetIndividualWriteTextField_size22, "bufferTextureCharacterPositionY_size22", bufferTextureCharacterPositionY_size22);
        computacion.SetBuffer(_kernelforPrintTilesAlphabetIndividualWriteTextField_size22, "bufferTextureAlphabetColor_size22", bufferTextureAlphabetColor_size22);

        computacion.SetBuffer(_kernelforPrintTilesNumberIndividualWriteTextField_size22, "bufferImageColorWriteTextField", bufferImageColorWriteTextField);
        computacion.SetBuffer(_kernelforPrintTilesNumberIndividualWriteTextField_size22, "bufferTextureCharacterPositionX_size22", bufferTextureCharacterPositionX_size22);
        computacion.SetBuffer(_kernelforPrintTilesNumberIndividualWriteTextField_size22, "bufferTextureCharacterPositionY_size22", bufferTextureCharacterPositionY_size22);
        computacion.SetBuffer(_kernelforPrintTilesNumberIndividualWriteTextField_size22, "bufferTextureNumberColor_size22", bufferTextureNumberColor_size22);

        computacion.SetBuffer(_kernelforPrintTilesPortugueseIndividualWriteTextField_size22, "bufferImageColorWriteTextField", bufferImageColorWriteTextField);
        computacion.SetBuffer(_kernelforPrintTilesPortugueseIndividualWriteTextField_size22, "bufferTextureCharacterPositionX_size22", bufferTextureCharacterPositionX_size22);
        computacion.SetBuffer(_kernelforPrintTilesPortugueseIndividualWriteTextField_size22, "bufferTextureCharacterPositionY_size22", bufferTextureCharacterPositionY_size22);
        computacion.SetBuffer(_kernelforPrintTilesPortugueseIndividualWriteTextField_size22, "bufferTexturePortugueseColor_size22", bufferTexturePortugueseColor_size22);


        computacion.SetBuffer(_kernelforPrintTilesAlphabet_size22, "bufferLargeMemory", bufferLargeMemory);
        computacion.SetBuffer(_kernelforPrintTilesAlphabet_size22, "bufferTextureCharacterPositionX_size22", bufferTextureCharacterPositionX_size22);
        computacion.SetBuffer(_kernelforPrintTilesAlphabet_size22, "bufferTextureCharacterPositionY_size22", bufferTextureCharacterPositionY_size22);
        computacion.SetBuffer(_kernelforPrintTilesAlphabet_size22, "bufferTextureAlphabetColor_size22", bufferTextureAlphabetColor_size22);

        computacion.SetBuffer(_kernelforPrintTilesAlphabetIndividual_size22, "bufferLargeMemory", bufferLargeMemory);
        computacion.SetBuffer(_kernelforPrintTilesAlphabetIndividual_size22, "bufferTextureCharacterPositionX_size22", bufferTextureCharacterPositionX_size22);
        computacion.SetBuffer(_kernelforPrintTilesAlphabetIndividual_size22, "bufferTextureCharacterPositionY_size22", bufferTextureCharacterPositionY_size22);
        computacion.SetBuffer(_kernelforPrintTilesAlphabetIndividual_size22, "bufferTextureAlphabetColor_size22", bufferTextureAlphabetColor_size22);

        computacion.SetBuffer(_kernelforPrintTilesNumberIndividual_size22, "bufferLargeMemory", bufferLargeMemory);
        computacion.SetBuffer(_kernelforPrintTilesNumberIndividual_size22, "bufferTextureCharacterPositionX_size22", bufferTextureCharacterPositionX_size22);
        computacion.SetBuffer(_kernelforPrintTilesNumberIndividual_size22, "bufferTextureCharacterPositionY_size22", bufferTextureCharacterPositionY_size22);
        computacion.SetBuffer(_kernelforPrintTilesNumberIndividual_size22, "bufferTextureNumberColor_size22", bufferTextureNumberColor_size22);

        computacion.SetBuffer(_kernelforPrintTilesPortugueseIndividual_size22, "bufferLargeMemory", bufferLargeMemory);
        computacion.SetBuffer(_kernelforPrintTilesPortugueseIndividual_size22, "bufferTextureCharacterPositionX_size22", bufferTextureCharacterPositionX_size22);
        computacion.SetBuffer(_kernelforPrintTilesPortugueseIndividual_size22, "bufferTextureCharacterPositionY_size22", bufferTextureCharacterPositionY_size22);
        computacion.SetBuffer(_kernelforPrintTilesPortugueseIndividual_size22, "bufferTexturePortugueseColor_size22", bufferTexturePortugueseColor_size22);




        computacion.SetBuffer(_kernelforLoadPointerPosition, "bufferPointerPositionX", bufferPointerPositionX);
        computacion.SetBuffer(_kernelforLoadPointerPosition, "bufferPointerPositionY", bufferPointerPositionY);

        computacion.SetBuffer(_kernelforPrintPointer, "bufferImageColorWriteTextField", bufferImageColorWriteTextField);
        computacion.SetBuffer(_kernelforPrintPointer, "bufferPointerPositionX", bufferPointerPositionX);
        computacion.SetBuffer(_kernelforPrintPointer, "bufferPointerPositionY", bufferPointerPositionY);
        computacion.SetBuffer(_kernelforPrintPointer, "bufferColorPointer", bufferColorPointer);

        computacion.SetBuffer(_kernelforPrintPointerBlack, "bufferImageColorWriteTextField", bufferImageColorWriteTextField);
        computacion.SetBuffer(_kernelforPrintPointerBlack, "bufferPointerPositionX", bufferPointerPositionX);
        computacion.SetBuffer(_kernelforPrintPointerBlack, "bufferPointerPositionY", bufferPointerPositionY);




        computacion.SetBuffer(_kernelforLoadHorizontalPosition, "bufferHorizontalPositionX", bufferHorizontalPositionX);
        computacion.SetBuffer(_kernelforLoadHorizontalPosition, "bufferHorizontalPositionY", bufferHorizontalPositionY);

        computacion.SetBuffer(_kernelforPrintHorizontal, "bufferLargeMemory", bufferLargeMemory);
        computacion.SetBuffer(_kernelforPrintHorizontal, "bufferHorizontalPositionX", bufferHorizontalPositionX);
        computacion.SetBuffer(_kernelforPrintHorizontal, "bufferHorizontalPositionY", bufferHorizontalPositionY);

        computacion.SetBuffer(_kernelforPrintHorizontalBlack, "bufferLargeMemory", bufferLargeMemory);
        computacion.SetBuffer(_kernelforPrintHorizontalBlack, "bufferHorizontalPositionX", bufferHorizontalPositionX);
        computacion.SetBuffer(_kernelforPrintHorizontalBlack, "bufferHorizontalPositionY", bufferHorizontalPositionY);


        computacion.SetBuffer(_kernelforLoadVerticalPosition, "bufferVerticalPositionX", bufferVerticalPositionX);
        computacion.SetBuffer(_kernelforLoadVerticalPosition, "bufferVerticalPositionY", bufferVerticalPositionY);

        computacion.SetBuffer(_kernelforPrintVertical, "bufferLargeMemory", bufferLargeMemory);
        computacion.SetBuffer(_kernelforPrintVertical, "bufferVerticalPositionX", bufferVerticalPositionX);
        computacion.SetBuffer(_kernelforPrintVertical, "bufferVerticalPositionY", bufferVerticalPositionY);

        computacion.SetBuffer(_kernelforPrintVerticalBlack, "bufferLargeMemory", bufferLargeMemory);
        computacion.SetBuffer(_kernelforPrintVerticalBlack, "bufferVerticalPositionX", bufferVerticalPositionX);
        computacion.SetBuffer(_kernelforPrintVerticalBlack, "bufferVerticalPositionY", bufferVerticalPositionY);


        // WriteString("readFileExample", "this is a string");
    }



    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    // PLANE SQUARE 
    // PLANE SQUARE 
    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////


    string[] tuplaWords = new string[2];

    byte ZeroAndOneforTuplaWords = 0;

    bool bool_changeKeyboardReception = false;

    bool runMiniGame = false;

    
    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    // PLANE SQUARE 
    // PLANE SQUARE 
    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////



    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    // START OF MINIGAME
    // START OF MINIGAME
    // START OF MINIGAME
    // START OF MINIGAME
    // START OF MINIGAME
    // START OF MINIGAME
    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////


    bool boolType_state_activateGame = false;

    List<string> listOfString_OneLanguage = new List<string>();
    List<string> listOfString_TwoLanguage = new List<string>();

    public static List<string> listOfString_CopyShuffle = new List<string>();
 

    int position = 0;

    float velocity = 10/7f;
    float ratioTimeChange = 0;
    bool bool_activate = false;


    List<rowContainer> listOfRowContainer = new List<rowContainer>();


    rowContainer rowElement0 = new rowContainer();
    
    rowContainer rowElement1 = new rowContainer();

    rowContainer rowElement2 = new rowContainer();

    rowContainer rowElement3 = new rowContainer();

    rowContainer rowElement4 = new rowContainer();
    
    rowContainer rowElement5 = new rowContainer();

    rowContainer rowElement6 = new rowContainer();

    rowContainer rowElement7 = new rowContainer();

    rowContainer rowElement8 = new rowContainer();

    rowContainer rowElement9 = new rowContainer();


    string StringCheckWithBlocke = "";

    List<int> containerToManipuleData = new List<int>();

   
    bool stateCheck = false;
    bool state_unPaintWholeWordElement = false;
    bool boolType_state_ParticleWrong = false;


    int count_words = 0;
    bool stateMiniGame = false;
    byte activateInsideMiniGame = 0;

    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    // START OF MINIGAME
    // START OF MINIGAME
    // START OF MINIGAME
    // START OF MINIGAME
    // START OF MINIGAME
    // START OF MINIGAME
    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    

    
    /////////////////////////////////////////////////////////////////////////////////////////////////////////
    //  UPDATE UPDATE UPDATE UPDATE UPDATE UPDATE UPDATE UPDATE UPDATE UPDATE UPDATE UPDATE UPDATE UPDATE  //
    /////////////////////////////////////////////////////////////////////////////////////////////////////////

    // Update is called once per frame
    void Update()
    {   

        ++frames;

        timeNow = Time.realtimeSinceStartup;

        // Debug.Log(timeNow);

        if (timeNow > lastInterval + updateInterval)
        {

            fps = (float)(frames / (timeNow - lastInterval));
            frames = 0;
            lastInterval = timeNow;

        }  



        if(MethodExtend.readFromButton == 1 && activeMiniGame == false)
        {


            ScriptComputacion.loadBufferTexturePosition(ref computacion, _kernelforLoadTextureCharacterPosition);

            ScriptComputacion.loadBufferTextureAlphabet(ref bufferTextureAlphabetColor);

            ScriptComputacion.loadBufferTextureNumber(ref bufferTextureNumberColor);

            ScriptComputacion.loadBufferTexturePortuguese(ref bufferTexturePortugueseColor);



            loadBufferTexturePosition_size14();

            loadBufferTextureAlphabet_size14();

            loadBufferTextureNumber_size14();

            loadBufferTexturePortuguese_size14();



            ScriptComputacion.loadBufferTexturePosition_size22(ref computacion, _kernelforLoadTextureCharacterPosition_size22);

            ScriptComputacion.loadBufferTextureAlphabet_size22(ref bufferTextureAlphabetColor_size22);
            
            ScriptComputacion.loadBufferTextureNumber_size22(ref bufferTextureNumberColor_size22);
            
            ScriptComputacion.loadBufferTexturePortuguese_size22(ref bufferTexturePortugueseColor_size22);



            ScriptComputacion.loadBufferPointerPosition(ref computacion, _kernelforLoadPointerPosition);
    
            ScriptComputacion.paintPointerPosition( ref bufferColorPointer, ref computacion, _kernelforPrintPointer, PositionPointerX, PositionPointerY, (int) timeNow);    



            loadBufferHorizontalPosition();

            loadBufferVerticalPosition();

            //////////////////////////////////////////
            // READ FILE
            /////////////////////////////////////////

            ScriptComputacion.activeKeaboard = !ScriptComputacion.activeKeaboard;        


            string fileName_words0 = "";

            string fileName_words1 = "";

            if(MethodExtend.fileName_words0 == "")
            {

                fileName_words0 = "ITALIAN/ITALIAN1/1000EnglishMOST_1";

                fileName_words1 = "ITALIAN/ITALIAN1/1000ItalianMOST_1";

            }

            else
            {

                fileName_words0 = MethodExtend.fileName_words0;

                fileName_words1 = MethodExtend.fileName_words1;

            }

            //////////////////////////////////////////
            // READ FILE
            /////////////////////////////////////////


            /////////////////////////////////////////////////////////////////////////////////////////////////////
            /// READ DATA WORDS
            /////////////////////////////////////////////////////////////////////////////////////////////////////


            listOfString_OneLanguage = loadWord(fileName_words0);
            listOfString_TwoLanguage = loadWord(fileName_words1);

            listOfString_CopyShuffle = new List<string>(listOfString_TwoLanguage);

            listOfString_CopyShuffle = makeListRandom(listOfString_CopyShuffle);


            //////////////////////////////////////////////////////////////////////////////////////////////////////
            /// READ DATA WORDS 
            //////////////////////////////////////////////////////////////////////////////////////////////////////


            activeMiniGame = !activeMiniGame;

            paintWordPositionWriteTextField_size22(700, 920, "PRESS ‘‘ESC’’ KEY TO MENU");
            paintWordPositionWriteTextField_size22(700, 970, "PRESS ‘‘ESC’’ KEY TO MENU");

            Vector3Type_position_Answer = new Vector3(particle_Answer.transform.position.x, particle_Answer.transform.position.y, particle_Answer.transform.position.z);

            // paintWordPosition(1000, 500, "CAPISCE O NO CAPISCE");

            // paintListOfWord_size22();

            // paintListOfWord();
            // paintString_translate("THISISALONGSTRING", 1);
            
            boolType_state_activateGame = true;    
        }






        if(boolType_state_activateGame == true)
        {
            
            boolType_state_activateGame = false;      
            // paintVerticalPositionBlack(1000,100);
            Debug.Log("");
            Debug.Log("");

            bool_activate = true;           
    
            rowElement0 = new rowContainer(Float_Speed(7324897), Float_empty(), 0, 7324897);
            rowElement1 = new rowContainer(Float_Speed(4134134), Float_empty(), 1, 4134134);
            rowElement2 = new rowContainer(Float_Speed(375415), Float_empty(), 2, 375415);
            rowElement3 = new rowContainer(Float_Speed(3413415), Float_empty(), 3, 3413415);
            rowElement4 = new rowContainer(Float_Speed(3512415), Float_empty(), 4, 3512415);
            rowElement5 = new rowContainer(Float_Speed(374515), Float_empty(), 5, 374515);
            rowElement6 = new rowContainer(Float_Speed(157415), Float_empty(), 6, 157415);
            rowElement7 = new rowContainer(Float_Speed(3567415), Float_empty(), 7, 3567415);
            rowElement8 = new rowContainer(Float_Speed(3741235), Float_empty(), 8, 3741235);
            rowElement9 = new rowContainer(Float_Speed(134415), Float_empty(), 9, 134415);


            rowElement0.addWord();
            rowElement1.addWord();
            rowElement2.addWord();
            rowElement3.addWord();
            rowElement4.addWord();
            rowElement5.addWord();
            rowElement6.addWord();
            rowElement7.addWord();
            rowElement8.addWord();
            rowElement9.addWord();


            // listOfRowContainer.Add(rowElement0);
            // listOfRowContainer.Add(rowElement1);
            // listOfRowContainer.Add(rowElement2);
            // listOfRowContainer.Add(rowElement3);
            // listOfRowContainer.Add(rowElement4);
            // listOfRowContainer.Add(rowElement5);
            // listOfRowContainer.Add(rowElement6);
            // listOfRowContainer.Add(rowElement7);
            // listOfRowContainer.Add(rowElement8);
            // listOfRowContainer.Add(rowElement9);


            // Debug.Log(rowElement0.listOfWords[0]);
            // Debug.Log(rowElement0.listOfPosition[0]);
            // Debug.Log(rowElement0.speed);
            // Debug.Log(rowElement0.ratioTime);
            // Debug.Log(rowElement0.Yaxis);
            // Debug.Log(rowElement0.stateAdd);
            // Debug.Log(rowElement0.countWord);
            // Debug.Log(rowElement0.countWord);

        }



        if(bool_activate == true)
        {

            rowElement0 = paintWord_row(rowElement0, timeNow);
            rowElement1 = paintWord_row(rowElement1, timeNow);
            rowElement2 = paintWord_row(rowElement2, timeNow);
            rowElement3 = paintWord_row(rowElement3, timeNow);
            rowElement4 = paintWord_row(rowElement4, timeNow);
            rowElement5 = paintWord_row(rowElement5, timeNow);
            rowElement6 = paintWord_row(rowElement6, timeNow);
            rowElement7 = paintWord_row(rowElement7, timeNow);
            rowElement8 = paintWord_row(rowElement8, timeNow);
            rowElement9 = paintWord_row(rowElement9, timeNow);
            
            rowElement0.test28();
            rowElement1.test28();
            rowElement2.test28();
            rowElement3.test28();
            rowElement4.test28();
            rowElement5.test28();
            rowElement6.test28();
            rowElement7.test28();
            rowElement8.test28();
            rowElement9.test28();
            
            rowElement0.test70();
            rowElement1.test70();
            rowElement2.test70();
            rowElement3.test70();
            rowElement4.test70();
            rowElement5.test70();
            rowElement6.test70();
            rowElement7.test70();
            rowElement8.test70();
            rowElement9.test70();

            listOfRowContainer.Clear();

            listOfRowContainer.Add(rowElement0);
            listOfRowContainer.Add(rowElement1);
            listOfRowContainer.Add(rowElement2);
            listOfRowContainer.Add(rowElement3);
            listOfRowContainer.Add(rowElement4);
            listOfRowContainer.Add(rowElement5);
            listOfRowContainer.Add(rowElement6);
            listOfRowContainer.Add(rowElement7);
            listOfRowContainer.Add(rowElement8);
            listOfRowContainer.Add(rowElement9);


            if(stateCheck == true)
            {

                for(int i = 0; i < listOfRowContainer.Count; ++i)
                {
                
                    containerToManipuleData = listOfRowContainer[i].findWordLPY(StringCheckWithBlocke);
                                
                    // Debug.Log("////////////////////////////");
                    // listOfRowContainer[0].printWholeObject();

                    if(listOfRowContainer[i].stateFind)
                    {
                
                        stateCheck = false;
    
                    }

                    if(stateCheck == false)
                    {
                        state_unPaintWholeWordElement = true;
                        break;

                    }
                
                }

                if(stateCheck == true)
                {
                    boolType_state_ParticleWrong = true;
                    stateCheck = false;
                }

                rowElement0 = listOfRowContainer[0];
                rowElement1 = listOfRowContainer[1];
                rowElement2 = listOfRowContainer[2];
                rowElement3 = listOfRowContainer[3];
                rowElement4 = listOfRowContainer[4];
                rowElement5 = listOfRowContainer[5];
                rowElement6 = listOfRowContainer[6];
                rowElement7 = listOfRowContainer[7];
                rowElement8 = listOfRowContainer[8];
                rowElement9 = listOfRowContainer[9];
            

            }

            if(state_unPaintWholeWordElement == false && boolType_state_ParticleWrong == true)
            {

                ScriptCommunication.boolType_state_CamaraShake = true;

                boolType_state_ParticleWrong = false;

                particle_Wrong.Play(true);

            }

            if(state_unPaintWholeWordElement == true)
            {
                state_unPaintWholeWordElement = false;
                // ScriptCommunication.activatePrefabRedStar = true;
                Function_PlayParticleRight(ref particle_Rigth0, ref particle_Rigth1);
                count_words++;
                
                Debug.Log("Write words");
                Debug.Log(count_words);                
                
                unpaint_WholeWordElement(containerToManipuleData[0], containerToManipuleData[1], containerToManipuleData[2]);

            }


            if(count_words == 4)
            {
    
                List<string> listOfString_tupla = find_TupleWord(StringCheckWithBlocke, listOfString_TwoLanguage, listOfString_OneLanguage);

                tuplaWords[0] = listOfString_tupla[0];
                tuplaWords[1] = listOfString_tupla[1];

                if(stateMiniGame == false)
                {
                    
                    activateInsideMiniGame = 1;
                    stateMiniGame = !stateMiniGame;

                }
                else
                {
                    activateInsideMiniGame = 2;
                    stateMiniGame = !stateMiniGame;

                }

                count_words = 0;
                stateCheck = false;
                bool_changeKeyboardReception = !bool_changeKeyboardReception;

            }

            byte byteType_countWordInList = 0;

            for(byte i = 0; i < listOfRowContainer.Count; ++i )
            {

                byteType_countWordInList += (byte)listOfRowContainer[i].countWord;

            }

            if(byteType_countWordInList == 0)
            {

                rowElement0.addWordRandom();
                rowElement1.addWordRandom();
                rowElement2.addWordRandom();
                rowElement3.addWordRandom();
                rowElement4.addWordRandom();
                rowElement5.addWordRandom();
                rowElement6.addWordRandom();
                rowElement7.addWordRandom();
                rowElement8.addWordRandom();
                rowElement9.addWordRandom();
            
            }


            // Debug.Log("////////////////////////////////////////////");
            
            // for(int i = 0 ; i < rowElement0.countWord; ++i)
            // {
                
            //     Debug.Log(rowElement0.listOfWords[i]);

            // }
            
            // for(int i = 0 ; i < rowElement0.countWord; ++i)
            // {
                
            //     Debug.Log(rowElement0.listOfPosition[i]);

            // }
            
            // // Debug.Log(rowElement.listOfWords[0]);
            // // Debug.Log(rowElement.listOfPosition[0]);
            // Debug.Log(rowElement0.speed);
            // Debug.Log(rowElement0.ratioTime);
            // Debug.Log(rowElement0.Yaxis);
            // Debug.Log(rowElement0.stateAdd);
            // Debug.Log(rowElement0.countWord);

        }


        ////////////////////////////////////////////////////////////////////////////////////////////
        // MiniGame Plane Square
        ////////////////////////////////////////////////////////////////////////////////////////////


        function_testMiniGameState(ref stateCheck, ref bool_changeKeyboardReception);

        // function_setTupleString("CAPISCE", "UNDERSTAND");


        if(activateInsideMiniGame == 1)
        {

            function_correctAnswer(tuplaWords[0], tuplaWords[1]);
            activateInsideMiniGame = 0;

        }

        if(activateInsideMiniGame == 2)
        {

            function_wrongAnswer(tuplaWords[0], tuplaWords[1]);
            activateInsideMiniGame = 0;

        }
        

        StringTextField = ScriptComputacion.StringTextField;


        if(bool_changeKeyboardReception == true)
        {

            function_testTextFieldSecondMiniGame();

        }
        
        ////////////////////////////////////////////////////////////////////////////////////////////
        // MiniGame Plane Square
        ////////////////////////////////////////////////////////////////////////////////////////////
        
        if(bool_changeKeyboardReception == false)
        {

            if(Input.GetKeyUp(KeyCode.Return))
            {

                Debug.Log(StringTextField);

                StringCheckWithBlocke = StringTextField;
                stateCheck = true;
                firstCheck("flafhfhq");    
    
                ScriptComputacion.paintPointerPositionBlack(ref computacion, _kernelforPrintPointerBlack, PositionPointerX, PositionPointerY); 
                
                ScriptComputacion.paintPointerPosition(ref bufferColorPointer, ref computacion, _kernelforPrintPointer, constPositionPointerX, constPositionPointerY,(int) timeNow); 
    
                PositionPointerX = constPositionPointerX;
                PositionPointerY = constPositionPointerY;
                ScriptComputacion.PositionPointerX = ScriptComputacion.constPositionPointerX;
                ScriptComputacion._XaxisTextField = ScriptComputacion._XaxisTextFieldBegin; 
                
                ScriptComputacion.StringTextField = "";


            }
            

        }



        if(ScriptComputacion.activeKeaboard == true && ScriptComputacion.StringTextField.Length <= 30)
        {

            getKeyBoardInput();            

        }


        if(Input.GetKeyUp(KeyCode.Escape))
        {

            ///////////////////////////////////////
            /// DATA FROM CANVAS
            ///////////////////////////////////////

            ScriptComputacion.activeKeaboard = false;
            ScriptComputacion.activeMiniGame = false;

            boolType_state_activateGame = false;

            MethodExtend.readFromButton = 0;

            ScriptComputacion.StringTextField = "";

            ///////////////////////////////////////
            /// DATA FROM CANVAS
            ///////////////////////////////////////

            LoadScene("MainScreen");

        }



        if(Input.GetKeyUp(KeyCode.F4))
        {

            ScriptComputacion.paintNumberFromTextureIndividual(ref computacion, _kernelforPrintTilesNumberIndividual, _XaxisWord22, _YaxisWord22 + 200, 1, 3);

            paintWordPosition_size22(_XaxisWord22, _YaxisWord22+100, "HOLÌ");

        }   


        runTextField();

        loadImageColor();

    }


/////////////////////////////////////////////////////////////////////////////////////////////////////////
//  UPDATE UPDATE UPDATE UPDATE UPDATE UPDATE UPDATE UPDATE UPDATE UPDATE UPDATE UPDATE UPDATE UPDATE  //
/////////////////////////////////////////////////////////////////////////////////////////////////////////


///////////////////////////////////////////////////////////////////////////////////////////////////////////////
///////////////////////////////////////////////////////////////////////////////////////////////////////////////
///////////////////////////////////////////////////////////////////////////////////////////////////////////////
///////////////////////////////////////////////////////////////////////////////////////////////////////////////
///////////////////////////////////////////////////////////////////////////////////////////////////////////////
///////////////////////////////////////////////////////////////////////////////////////////////////////////////
///////////////////////////////////////////////////////////////////////////////////////////////////////////////
///////////////////////////////////////////////////////////////////////////////////////////////////////////////
///////////////////////////////////////////////////////////////////////////////////////////////////////////////
///////////////////////////////////////////////////////////////////////////////////////////////////////////////





    public rowContainer paintWord_row(rowContainer object_data, float paraTime)
    {

        // Input
        rowContainer container_object_data = new rowContainer(object_data);

        List<string> containerListOfWords = new List<string>(container_object_data.listOfWords); 
        List<int> containerListOfPosition = new List<int>(container_object_data.listOfPosition); 


        float containerRatioTime = container_object_data.ratioTime;
        float containerSpeed = container_object_data.speed;
        int containerYaxis = container_object_data.Yaxis;
        bool containerStateAdd = container_object_data.stateAdd;
        int containerCountWord = container_object_data.countWord;
        int containerSeed = container_object_data.seed;

        int containerCountWords = container_object_data.countOfWords();

        // Debug.Log("");
        // Debug.Log("");
        // Debug.Log("CONTAINERWORD");
        // Debug.Log(containerCountWord);
        // Debug.Log(containerCountWords);
        // Debug.Log("");
        // Debug.Log("");


        float containerParaTime = paraTime;

        rowContainer containerOutput = new rowContainer();

        bool flagIf = false;

        if(containerParaTime - containerRatioTime >= (containerSpeed/10))
        {
            for(int i = 0; i < containerCountWord; ++i)
            {
    
                string containerWord = containerListOfWords[i];
                int containerPosition = containerListOfPosition[i];
        
        
                ///////////////////////////////////////////////////////////////////////////////////////////////////////////////
                //  ALGORYTHM
                ///////////////////////////////////////////////////////////////////////////////////////////////////////////////
        
                            
                int position = containerPosition;
                int Yaxis = containerYaxis;
                containerRatioTime = containerParaTime;
                string cadenaRunning = containerWord;
    
                unpaintBoundWords(cadenaRunning.Length, position, Yaxis);
                paintString_translate(cadenaRunning, position, Yaxis);
                paintBoundWords(cadenaRunning.Length, position, Yaxis);    
                        
                position++;
                containerPosition = position;
                
                containerListOfPosition[i] = containerPosition;
                // paintListOfWord();
    
    
            }

        }

        containerOutput.listOfWords = containerListOfWords;
        containerOutput.listOfPosition = containerListOfPosition;
        containerOutput.ratioTime = containerRatioTime;
        containerOutput.speed = containerSpeed;
        containerOutput.Yaxis = containerYaxis;
        containerOutput.stateAdd = containerStateAdd;
        containerOutput.countWord = containerCountWord;
        containerOutput.seed = containerSeed;

        return containerOutput;

    }


    

    public List<string> listOfString_wordToPaint(List<string> stringOfWord)
    {

        // Input
        List<string> containerStringOfWord = new List<string>(stringOfWord);


        // Output
        List<string> containerOutput = new List<string>();

        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////
        //  ALGORYTHM
        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////

        float seed = Time.realtimeSinceStartup;

        for(int i = 0; i < 10; ++i)
        {

            containerOutput.Add(string_select(containerStringOfWord, (i + 3 )*(int) seed));            

        }

        for(int i = 0; i < 10; ++i)
        {

            Debug.Log(containerOutput[i]);
        }


        return containerOutput;

    }



    public List<string> find_TupleWord(string wordToSearch, List<string> listOfWords_wordLanguage, List<string> listOfWords_wordPosition)
    {

        //Input
        string containerWordToSearch = wordToSearch;
        
        List<string> containerlistOfWords_wordLanguage = new List<string>(listOfWords_wordLanguage);

        List<string> containerlistOfWords_wordPosition = new List<string>(listOfWords_wordPosition);

        //Output
        List<string> containerOutput = new List<string>();

        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////
        //  ALGORYTHM
        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////

        short findPosition = 0; 

        for(short i = 0; i < containerlistOfWords_wordLanguage.Count; ++i)
        {

            if(containerlistOfWords_wordLanguage[i] == containerWordToSearch)
            {

                findPosition = i;
                break;

            }             

        }


        containerOutput.Add(containerlistOfWords_wordLanguage[findPosition]);
        containerOutput.Add(containerlistOfWords_wordPosition[findPosition]);


        return  containerOutput;

    }

    public float Float_Speed(int seed)
    {

        // Output
        float containerOutput = 0;

        int containerSeed = seed;
        
        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////
        //  ALGORYTHM
        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////

        float timeFloat_speed = Time.realtimeSinceStartup;

        System.Random aleatorio = new System.Random((int)timeFloat_speed * 12873 * containerSeed);

    
        containerOutput = (float)aleatorio.Next(2,11);  


        return containerOutput;

    }


    public int Int_empty()
    {

        int containerOutput = 0;

        return containerOutput;

    }


    public float Float_empty()
    {

        float containerOutput = 0;

        return containerOutput;

    }



    public List<float> listOfFloat_Speed()
    {

        // Output
        List<float> containerOutput = new List<float>();

        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////
        //  ALGORYTHM
        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////

        System.Random aleatorio = new System.Random();

        for(int i = 0; i < 10; ++i)
        {
    
            containerOutput.Add((float)aleatorio.Next(2,11));  

        }

        return containerOutput;

    }


    
    public List<int> listOfInt_TenPositionYaxis()
    {

        // Output
        List<int> containerOutput = new List<int>();

        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////
        //  ALGORYTHM
        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////

        for(int i = 0; i < 10; ++i)
        {
            containerOutput.Add(i);
        }

        containerOutput = Shuffle_int(containerOutput);

        // for(int i = 0; i < containerOutput.Count; ++i)
        // {
        //     Debug.Log(containerOutput[i]);
        // }

        return containerOutput;

    }



    public void paintString_translate(string word, int position, int Yaxis)
    {

        // Input
        string containerWord = word;

        int containerPosition = position;

        int containerYaxis = Yaxis;


        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////
        //  ALGORYTHM
        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////


        string empytStringErase = "";

        for(int i = 0; i < containerWord.Length; ++i)
        {

            empytStringErase += " ";

        }

        paintWordPosition(1966 - (containerPosition - 1) * 34, 30 + containerYaxis * 90, empytStringErase);

        paintWordPosition(1966 - (containerPosition) * 34, 30 + containerYaxis * 90, containerWord);

    }


    public void unpaint_WholeWordElement(int lengthWord, int position, int Yaxis)
    {

        // Input

        int containerLengthWord = lengthWord;

        int containerPosition = position;

        int containerYaxis = Yaxis;

        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////
        //  ALGORYTHM
        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////

        unpaintBoundWords(containerLengthWord, containerPosition, containerYaxis);
        unpaintword(containerLengthWord, containerPosition, containerYaxis);


        particle_Answer.transform.position = Vector3Type_position_Answer;
        Vector3 variableAnswer = particle_Answer.transform.position;

        particle_Answer.transform.position = new Vector3(variableAnswer.x + 0.32f * containerPosition, variableAnswer.y - 0.9f * containerYaxis , variableAnswer.z);

        particle_Answer.Play(true);
         
        // particle_Answer.transform.position = copyVariableAnswer;

    }


    public void unpaintword( int lengthWord, int position, int Yaxis)
    {

        // Input
        int containerLengthWord = lengthWord;

        int containerPosition = position;

        int containerYaxis = Yaxis;

        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////
        //  ALGORYTHM
        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////

        string empytStringErase = "";

        for(int i = 0; i < containerLengthWord; ++i)
        {

            empytStringErase += " ";

        }


        paintWordPosition(1966 - (containerPosition - 1) * 34, 30 + containerYaxis * 90, empytStringErase);

    }



    public void paintBoundWords(int lengthWord, int position, int Yaxis)
    {

        // Input
        int containerLengthWord = lengthWord;

        int containerPosition = position;

        int containerYaxis = Yaxis;


        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////
        //  ALGORYTHM
        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////

        float timeColorBound = Time.realtimeSinceStartup;
        System.Random objeto_system  = new System.Random((int)timeColorBound * 4898 * containerYaxis);

        int aleatorio_numero = objeto_system.Next(0,8);

        paintHorizontalPosition(1960 - (containerPosition * 34), 30 + 49 + containerYaxis * 90, aleatorio_numero);
        paintVerticalPosition(2000 - (containerPosition * 34), 46 + containerYaxis * 90, aleatorio_numero);

        
        paintHorizontalPosition(1960 - (containerLengthWord - 1 ) * 34 - (containerPosition * 34), 30 + containerYaxis * 90, aleatorio_numero);
        paintVerticalPosition(1988 - (containerLengthWord) * 34 - (containerPosition * 34), 30 + containerYaxis * 90, aleatorio_numero);

    }


    public void unpaintBoundWords(int lengthWord, int position, int Yaxis)
    {

        // Input
        int containerLengthWord = lengthWord;

        int containerPosition = position;

        int containerYaxis = Yaxis;


        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////
        //  ALGORYTHM
        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////


        paintHorizontalPositionBlack(1960 - (containerPosition - 1 ) * 34, 30 + 49 + containerYaxis * 90);
        paintVerticalPositionBlack(2000 - (containerPosition - 1)* 34, 46 + containerYaxis * 90);

        paintHorizontalPositionBlack(1960 - (containerLengthWord - 1 ) * 34 - (containerPosition - 1 ) * 34, 30 + containerYaxis * 90);
        paintVerticalPositionBlack(1988 - (containerLengthWord) * 34 - (containerPosition - 1)* 34, 30 + containerYaxis * 90);

   
    }



    public string string_select(List<string> listOfString, int seed)
    {

        //Input
        List<string> containerListOfString = new List<string>(listOfString);

        //Output
        string containerOutput = "";

        //////////////////////////////////////////////////////////////////
        // ALGORITHM
        //////////////////////////////////////////////////////////////////

        System.Random aleatorio = new System.Random(seed);

        containerOutput = containerListOfString[aleatorio.Next(0, containerListOfString.Count)];

        return containerOutput;

    }


    public void paintListOfWord()
    {

        for(int i = 0; i < 11; ++i)
        {
            paintWordPosition(1800, 30 + i * 80, "LONGWORD");

        }

    }


    public void paintListOfWord_size22()
    {

        for(int i = 0; i < 20; ++i)
        {
            paintWordPosition_size22(1900, 20 + i * 40, "LONGWORD");

        }

    }

    
    public List<List<string>> selectWords(List<string> oneLanguage, List<string> twoLanguage)
    {
        // Input
        List<string> containerOneLanguage = new List<string>(oneLanguage);

        List<string> containerTwoLanguage = new List<string>(twoLanguage);

        // Output 
        List<List<string>> containerOutput = new List<List<string>>();
        
        /////////////////////////////////////////////////////////////////////////////////////
        /// ALGORITHM
        /////////////////////////////////////////////////////////////////////////////////////

        List<string> containerLanguageOne = new List<string>();

        List<string> containerLanguageTwo = new List<string>();


        containerOutput.Add(containerLanguageOne);
        containerOutput.Add(containerLanguageTwo);

        Int32 seed = System.DateTime.Now.Second;

        System.Random aleatorio = new System.Random(seed);

        // for(int i = 0; i < 10; ++i)

        int selectWords_count = 0;
        while(selectWords_count < 10)
        {
    
            int number = aleatorio.Next(0, containerOneLanguage.Count);
            

            string oneLanguageString = containerOneLanguage[number];

            string twoLanguageString = containerTwoLanguage[number];

            bool check = false;

            for(int i = 0; i < containerOutput[0].Count; ++i)
            {

                if(containerOutput[0][i] == oneLanguageString)
                {   
                    check = true;
                    break;
                }
            }

            if(check == true)
            {
                continue;
            }

            containerOutput[0].Add(oneLanguageString);

            containerOutput[1].Add(twoLanguageString);
            
            selectWords_count++;

        }


        return containerOutput;

    }




    public List<string> loadWord(string nameOfFile)
    {
    
        // Input
        string containerNameOfFile = nameOfFile;

        // Output
        List<string> containerOutput = new List<string>();
    
    
        /////////////////////////////////////////////////////////////
        // ALGORITHM
        /////////////////////////////////////////////////////////////


        TextAsset reader = Resources.Load<TextAsset>(nameOfFile);
        string lecturaDatos0 = reader.text;
        // reader.Close();
    
        
        string[] arrayWords = lecturaDatos0.Split('\n');
    
        for(int i = 0; i < arrayWords.Length; ++i)
        {
    
            string container = "";
    
            for(int j = 0; j < arrayWords[i].Length - 1; ++j)
            {
                container += arrayWords[i][j];
            }
    
            arrayWords[i] = container;
    
        }
        
        Array.Resize<string>(ref arrayWords, arrayWords.Length-1);
    
    
        for(int i = 0 ; i < arrayWords.Length; ++i)
        {
    
            containerOutput.Add(arrayWords[i]);
    
        }
    
    
        return containerOutput;
    
    }


    public List<string> makeListRandom(List<string> listOfListString)
    {

        // Input
        List<string> containerListOfString = new List<string>(listOfListString);

        // Output
        List<string> containerOutput = new List<string>();

        /////////////////////////////////////////////////////////////
        // ALGORITHM
        /////////////////////////////////////////////////////////////


        List<string> manageList = new List<string>();


        for(int k = 0; k < containerListOfString.Count; ++k)
        {
     
            manageList.Add(containerListOfString[k]);

        }


        // for(int i = 0 ; i < manageList.Count ; ++i)
        // {

        //     Debug.Log(manageList[i]);

        // }


        containerOutput = Shuffle(manageList);

        containerOutput = Shuffle(containerOutput);

        containerOutput = Shuffle(containerOutput);

        containerOutput = Shuffle(containerOutput);

        // for(int i = 0 ; i < manageList.Count ; ++i)
        // {

        //     Debug.Log( manageList[i] + "       " + containerOutput[i]);

        // }


        return containerOutput;

    }


    public List<string> Shuffle(List<string> listToShuffle)  
    {  

        //Input
        List<string> containerList = new List<string>(listToShuffle);

        //Ouput
        List<string> containerOutput = new List<string>();
        

        /////////////////////////////////////////////////////////////
        // ALGORITHM
        /////////////////////////////////////////////////////////////

     
        for (int i = 0; i < 100; i++)
        {
            
            System.Random aleatorio = new System.Random(i);
            System.Random aleatorio2 = new System.Random(i + 5175);

            int randomIndex = aleatorio.Next(0, containerList.Count);
            int randomIndex2 = aleatorio2.Next(0, containerList.Count);

            string variableString = containerList[randomIndex2];
            containerList[randomIndex2] = containerList[randomIndex];
            containerList[randomIndex] = variableString;

        }


        containerOutput = new List<string>(containerList);

        return containerOutput;


    }


    public List<int> Shuffle_int(List<int> listToShuffle)  
    {  

        //Input
        List<int> containerList = new List<int>(listToShuffle);

        //Ouput
        List<int> containerOutput = new List<int>();
        

        /////////////////////////////////////////////////////////////
        // ALGORITHM
        /////////////////////////////////////////////////////////////

     
        for (int i = 0; i < 100; i++)
        {
            
            System.Random aleatorio = new System.Random(i);
            System.Random aleatorio2 = new System.Random(i + 5175);

            int randomIndex = aleatorio.Next(0, containerList.Count);
            int randomIndex2 = aleatorio2.Next(0, containerList.Count);

            int variableString = containerList[randomIndex2];
            containerList[randomIndex2] = containerList[randomIndex];
            containerList[randomIndex] = variableString;

        }


        containerOutput = new List<int>(containerList);

        return containerOutput;


    }


    public static void WriteString(string nameOfFile, string stringToWrite)
    {

        string pathNew = @"D:\INTERNET\Wiki-Andresito-20-WORK\WordGame_V_0_0_9\Assets\Run\ReadFiles";
        // string pathNew = @"D:\INTERNET\Wiki-Andresito-20-WORK\WordGame_V_0_0_9\Assets\Run\ReadFilesD:\INTERNET\Wiki-Andresito-20-WORK\WordGame_V_0_0_9/Assets/Run/ReadFiles";
        string path = pathNew + "\\" + nameOfFile;
        //Write some text to the test.txt file
        StreamWriter writer = new StreamWriter(path);
        writer.WriteLine(stringToWrite);
        writer.Close();
        StreamReader reader = new StreamReader(path);
        //Print the text from the file
        Debug.Log(reader.ReadToEnd());
        reader.Close();
    }


    public static void Function_PlayParticleRight(ref ParticleSystem particle_0, ref ParticleSystem particle_1)
    {

        particle_0.Play(true);
        particle_1.Play(true);

    }

///////////////////////////////////////////////////////////////////////////////////////////////////////////////
///////////////////////////////////////////////////////////////////////////////////////////////////////////////
///////////////////////////////////////////////////////////////////////////////////////////////////////////////
///////////////////////////////////////////////////////////////////////////////////////////////////////////////
///////////////////////////////////////////////////////////////////////////////////////////////////////////////
///////////////////////////////////////////////////////////////////////////////////////////////////////////////
///////////////////////////////////////////////////////////////////////////////////////////////////////////////
///////////////////////////////////////////////////////////////////////////////////////////////////////////////
///////////////////////////////////////////////////////////////////////////////////////////////////////////////


////////////////////////////////////////////////////////////////////////////////////////////////////////////
//// PILOTING TEXFIELD
////////////////////////////////////////////////////////////////////////////////////////////////////////////


    public void runTextField()
    {


        
        if(Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.RightControl))
        {

            ScriptComputacion.activateControl = true;

        }

        if(ScriptComputacion.activeKeaboard == true && Input.GetKeyUp(KeyCode.Backspace) && ScriptComputacion.StringTextField.Length > 0)
        {

            string empty = "";
            
            for(int i = 0; i < ScriptComputacion.StringTextField.Length - 1 ; ++i)
            {

                empty += ScriptComputacion.StringTextField[i];

            }

            ScriptComputacion.StringTextField = empty;


            ScriptComputacion._XaxisTextField += ScriptComputacion.CHARACTERWIDTH; 


            int _PositionX = ScriptComputacion._XaxisTextField;
            int _PositionY = ScriptComputacion._YaxisTextField;


            ScriptComputacion.paintAlphabetFromTextureIndividualWriteTextField(ref computacion, _kernelforPrintTilesAlphabetIndividualWriteTextField, _PositionX, _PositionY,2,6);
            
            ScriptComputacion.paintPointerPositionBlack(ref computacion, _kernelforPrintPointerBlack, ScriptComputacion.PositionPointerX, ScriptComputacion.PositionPointerY); 
            ScriptComputacion.PositionPointerX += 34;
            ScriptComputacion.paintPointerPosition(ref bufferColorPointer, ref computacion, _kernelforPrintPointer, ScriptComputacion.PositionPointerX, ScriptComputacion.PositionPointerY,(int) timeNow); 


        }

        if(ScriptComputacion.activeKeaboard == true && ScriptComputacion.activateControl == true && Input.GetKeyUp(KeyCode.Backspace) && ScriptComputacion.StringTextField.Length > 0)
        {

            string empty = "";
            

            ScriptComputacion.StringTextField = empty;


            ScriptComputacion._XaxisTextField = ScriptComputacion._XaxisTextFieldBegin; 
            
            paintWordPositionWriteTextField(ScriptComputacion._XaxisTextFieldBegin, ScriptComputacion._YaxisTextFieldBegin, "                               ");


            ScriptComputacion.paintPointerPositionBlack(ref computacion, _kernelforPrintPointerBlack, ScriptComputacion.PositionPointerX, ScriptComputacion.PositionPointerY); 
            ScriptComputacion.PositionPointerX = ScriptComputacion.constPositionPointerX;
            ScriptComputacion.paintPointerPosition(ref bufferColorPointer, ref computacion, _kernelforPrintPointer, ScriptComputacion.PositionPointerX, ScriptComputacion.PositionPointerY, (int) timeNow); 

        }

        ScriptComputacion.activateControl = false;

    }




    public void firstCheck(string compare)
    {


        string operation_StringTextField = StringTextField;

        string operation_ScriptCommunication_StringTextField = compare;



        bool firstCheckBool = false;


        if( operation_StringTextField == operation_ScriptCommunication_StringTextField)
        {

            firstCheckBool = true;

        }


        if(firstCheckBool == true)
        {

            wordCheck0 = true;
            CheckBool = true;



            StringTextField = "";
            
            _XaxisTextField = _XaxisTextFieldBegin;

            paintWordPositionWriteTextField(_XaxisTextFieldBegin, _YaxisTextFieldBegin, "                               ");
                
        }
    
        
        if(firstCheckBool == false)
        {
            CheckBool = false;

            StringTextField = "";
            
            _XaxisTextField = _XaxisTextFieldBegin;

            paintWordPositionWriteTextField(_XaxisTextFieldBegin, _YaxisTextFieldBegin, "                               ");

        }
        

    }


    public void getKeyBoardInput()
    {

        ScriptComputacion.getKeyBoardInput(ref computacion, ref bufferColorPointer, _kernelforPrintPointerBlack, _kernelforPrintPointer,
                        
                            _kernelforPrintTilesPortugueseIndividualWriteTextField, _kernelforPrintTilesAlphabetIndividualWriteTextField, _kernelforPrintTilesNumberIndividualWriteTextField, (int) timeNow);
    }



////////////////////////////////////////////////////////////////////////////////////////////////////////////
//// PILOTING TEXFIELD
////////////////////////////////////////////////////////////////////////////////////////////////////////////



/////////////////////////////////////////////////////////////////////////////////////////////////////////
//  SCREEN MANAGE                                                                                      //
/////////////////////////////////////////////////////////////////////////////////////////////////////////



    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
    

    public void loadImageColor()
    {
     
        computacion.Dispatch(_kernelforLoadImageColor ,2000, 1000, 1);
    
    }    


    public void loadTextureBig()
    {

        computacion.Dispatch(_kernelforLoadTextureBig, 2000, 1000, 1);

    }


    public void paintTextureBig()
    {

        computacion.SetInt("_PositionBigX", 2000);
        computacion.SetInt("_PositionBigY", 1000);

        computacion.Dispatch(_kernelforPrintTextureBig , 2000 , 1000, 1);

    }


    public void loadTransparent()
    {
        computacion.Dispatch(_kernelforLoadTextureTransparent, 1000, 1, 1);
    }


    public void paintTransparent()
    {

        int _PositionTransparentX = 0;
        int _PositionTransparentY = 0;
        
        for(int i = 0; i < 1; ++i)
        {
            
            computacion.SetInt("_PositionTransparentX", _PositionTransparentX);
            computacion.SetInt("_PositionTransparentY", _PositionTransparentY);

            computacion.Dispatch(_kernelforPrintTextureTransparent,1000, 1, 1);
            _PositionTransparentX += 1000;                
        }

    }
        

/////////////////////////////////////////////////////////////////////////////////////////////////////////
//  SCREEN MANAGE                                                                                      //
/////////////////////////////////////////////////////////////////////////////////////////////////////////


///////////////////////////////////////////////////////////////////////////////////////////////////////////////
// MINI GAME PLANE SQUARE FUNCTIONS
///////////////////////////////////////////////////////////////////////////////////////////////////////////////


        public void function_testTextFieldSecondMiniGame()
        {

            if(Input.GetKeyUp(KeyCode.Return))
            {
        
                if(wordCheck0 == false)                        
                {

                    function_setStringTextField();                            
                    firstCheck(tuplaWords[ZeroAndOneforTuplaWords]);
    
                    if(wordCheck0 == true)
                    {   

                        function_setActiveWordInput();    

                        ZeroAndOneforTuplaWords = (ZeroAndOneforTuplaWords == 0)? (byte)1 : (byte)0;

                        CheckBool = true;
                        wordCheck0 = false;
                                         
                    }
                    
                    if(wordCheck0 == false && CheckBool == false)
                    {
    
                        ScriptCommunication.activatePrefabRedStar = true;
                        CheckBool = true;
    
                    }
    
                }
    
    
                ScriptComputacion.paintPointerPositionBlack(ref computacion, _kernelforPrintPointerBlack, PositionPointerX, PositionPointerY); 
                
                ScriptComputacion.paintPointerPosition(ref bufferColorPointer, ref computacion, _kernelforPrintPointer, constPositionPointerX, constPositionPointerY,(int) timeNow); 
    
                PositionPointerX = constPositionPointerX;
                PositionPointerY = constPositionPointerY;
        
                ScriptComputacion._XaxisTextField = ScriptComputacion._XaxisTextFieldBegin; 
    
                ScriptComputacion.PositionPointerX = ScriptComputacion.constPositionPointerX;
                ScriptComputacion.StringTextField = ""; 

            }

        }



        public void function_setTupleString(string oneLanguage, string twoLanguage)
        {

            tuplaWords[0] = oneLanguage;
            tuplaWords[1] = twoLanguage;

        }


        public void function_setStringTextField()
        {

            ScriptCommunication.StringTextField = StringTextField;    

        }
            

        public void function_setActiveWordInput()
        {

            ScriptCommunication.activateWordInput = true;

        }
            

        public void function_testMiniGameState(ref bool bool_stateCheck, ref bool bool_stateKeyboard)
        {
        
            // Input
            

            if(ScriptCommunication.endOfMiniGame == true)
            {  

                bool_stateKeyboard = !bool_stateKeyboard;

                bool_stateCheck = !bool_stateCheck;

                ScriptCommunication.endOfMiniGame = false; 
    
                object_PlaneWrite.SetActive(true);
    
            }

        }


        public void function_correctAnswer(string oneLanguage, string twoLanguage)
        {

            runMiniGame = false;

            ScriptCommunication.wordToPaintThree = true;
            ScriptCommunication.activateWordToPaint = true;
            ScriptCommunication.endOfMiniGame = false;

            ScriptCommunication.tuplaWords[0] = oneLanguage;
            ScriptCommunication.tuplaWords[1] = twoLanguage;


            //////////////////////////////////////////////////////////////
            //ANIMATION
            //////////////////////////////////////////////////////////////


            //////////////////////////////////////////////////////////////
            //ANIMATION
            //////////////////////////////////////////////////////////////
            

            object_PlaneWrite.SetActive(false);

        }


        public void function_wrongAnswer(string oneLanguage, string twoLanguage)
        {
            
            runMiniGame = false;

            ScriptCommunication.wordToPaintSix = true;
            ScriptCommunication.activateWordToPaint = true;
            ScriptCommunication.endOfMiniGame = false;

            ScriptCommunication.tuplaWords[0] = oneLanguage;
            ScriptCommunication.tuplaWords[1] = twoLanguage;

            //////////////////////////////////////////////////////////////
            //ANIMATION
            //////////////////////////////////////////////////////////////        

            particle_Smoke0.Play(true);
            particle_Smoke1.Play(true);

            //////////////////////////////////////////////////////////////
            //ANIMATION
            //////////////////////////////////////////////////////////////

            object_PlaneWrite.SetActive(false);

        }


///////////////////////////////////////////////////////////////////////////////////////////////////////////////
// MINI GAME PLANE SQUARE FUNCTIONS
///////////////////////////////////////////////////////////////////////////////////////////////////////////////


    public static void readDataColorTextureCharacters(string fileNameColor, ref float[] loadTextureCharacter, uint numOfImagePixel)
    {

        //IMAGEDATA
        //letterQPosition

        string fileName = fileNameColor;

        string path = fileName;

        //dataToLoadColor;

        //Read the text from directly from the test file
        TextAsset reader = Resources.Load<TextAsset>(path);

        string lecturaDatos = reader.text;

        //float[] dataToSet = new float[5456];
        // reader.Close();
 
        string lecturaString = "";

        int countDataToSet = 0;


        //38192
        for(int i = 0 ; i < numOfImagePixel; ++i)
        {

            for(int j = 0 ; j < 53; ++j )
            {

                if(j == 0) 
                {
                }
                else if(j % 13 == 0)
                {

                    loadTextureCharacter[countDataToSet] = float.Parse(lecturaString);

                    lecturaString = "";
                    countDataToSet ++;

                }
                else
                {
                    lecturaString += lecturaDatos[i * 54 + j];

                }

            }

        }

    }


////////////////////////////////////////////////////////////////////////////////////////////////
// MEMORY OF characters TEXTURE 36 SIZE
////////////////////////////////////////////////////////////////////////////////////////////////


    public void paintWordPosition(int Xaxis, int Yaxis, string manageString)
    {

        ScriptComputacion.paintWordPosition(ref computacion, _kernelforPrintTilesAlphabetIndividual, _kernelforPrintTilesNumberIndividual, _kernelforPrintTilesPortugueseIndividual, Xaxis, Yaxis, manageString);

    }


    public void paintWordPositionWriteTextField(int Xaxis, int Yaxis, string manageString)
    {

        ScriptComputacion.paintWordPositionWriteTextField(ref computacion, _kernelforPrintTilesAlphabetIndividualWriteTextField, _kernelforPrintTilesNumberIndividualWriteTextField, _kernelforPrintTilesPortugueseIndividualWriteTextField, Xaxis, Yaxis, manageString);

    }


////////////////////////////////////////////////////////////////////////////////////////////////
// MEMORY OF characters TEXTURE 36 SIZE
////////////////////////////////////////////////////////////////////////////////////////////////


//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
// MEMORY character TEXTURE 22 SIZE
//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////


    public void paintWordPositionWriteTextField_size22(int Xaxis, int Yaxis, string manageString)
    {
        ScriptComputacion.paintWordPositionWriteTextField_size22(ref computacion, _kernelforPrintTilesAlphabetIndividualWriteTextField_size22, _kernelforPrintTilesNumberIndividualWriteTextField_size22, _kernelforPrintTilesPortugueseIndividualWriteTextField_size22, Xaxis, Yaxis, manageString);
    }    



    public void paintWordPosition_size22(int Xaxis, int Yaxis, string manageString)
    {

        ScriptComputacion.paintWordPosition_size22(ref computacion, _kernelforPrintTilesAlphabetIndividual_size22, _kernelforPrintTilesNumberIndividual_size22, _kernelforPrintTilesPortugueseIndividual_size22, Xaxis, Yaxis, manageString);
    }    


//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
// MEMORY character TEXTURE 22 SIZE
//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////


//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
// MEMORY character TEXTURE 14 SIZE
//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////



    public void loadBufferTexturePosition_size14()
    {
        
        computacion.Dispatch(_kernelforLoadTextureCharacterPosition_size14, 147, 1, 1);

    }
    



    public void loadBufferTextureAlphabet_size14()
    {

        string fileTextureAlphabet = "TransparentTextureOfCharacters-size14Color";
        
        float[] arrayTextureAlphabetColor = new float[25872];
        //positions[1692800];
        uint numOfImagePixel = 6468;

        readDataColorTextureCharacters(fileTextureAlphabet, ref arrayTextureAlphabetColor, numOfImagePixel);

        bufferTextureAlphabetColor_size14.SetData(arrayTextureAlphabetColor);

    }





    public void paintAlphabetFromTexture_size14()
    {

        computacion.Dispatch(_kernelforPrintTilesAlphabet_size14, 147, 1,1);

    }





    public void paintAlphabetFromTextureIndividual_size14(int Xaxis, int Yaxis, int Xtile, int Ytile)
    {

        int _PositionScreenX = Xaxis;        
        int _PositionScreenY = Yaxis;
        
        int _PositionTileX = Xtile;        
        int _PositionTileY = Ytile;                
        

        computacion.SetInt("_PositionScreenX_size14", _PositionScreenX);
        computacion.SetInt("_PositionScreenY_size14", _PositionScreenY);

        computacion.SetInt("_PositionTileX_size14", _PositionTileX);
        computacion.SetInt("_PositionTileY_size14", _PositionTileY);

        computacion.Dispatch(_kernelforPrintTilesAlphabetIndividual_size14, 21, 1,1);

    }




    //forLoadTextureNumberPosition
    public void loadBufferTextureNumber_size14()
    {

        string fileTextureNumber = "TransparentTextureOfNumbers-size14Color";
        
        float[] arrayTextureNumberColor = new float[25872];
        //positions[1692800];

        uint numOfImagePixel = 6468;
        
        readDataColorTextureCharacters(fileTextureNumber, ref arrayTextureNumberColor, numOfImagePixel);

        bufferTextureNumberColor_size14.SetData(arrayTextureNumberColor);

    }





    public void paintNumberFromTextureIndividual_size14(int Xaxis, int Yaxis, int Xtile, int Ytile)
    {

        int _PositionScreenX = Xaxis;
        int _PositionScreenY = Yaxis;
        
        int _PositionTileX = Xtile;        
        int _PositionTileY = Ytile;                
        

        computacion.SetInt("_PositionScreenNumberX_size14", _PositionScreenX);
        computacion.SetInt("_PositionScreenNumberY_size14", _PositionScreenY);

        computacion.SetInt("_PositionTileNumberX_size14", _PositionTileX);
        computacion.SetInt("_PositionTileNumberY_size14", _PositionTileY);

        computacion.Dispatch(_kernelforPrintTilesNumberIndividual_size14, 21, 1,1);

    }




    //forLoadTextureNumberPosition
    public void loadBufferTexturePortuguese_size14()
    {

        string fileTexturePortuguese = "TransparentTextureOfPortuguese-size14Color";
        
        float[] arrayTexturePortugueseColor = new float[25872];
        //positions[1692800];

        uint numOfImagePixel = 6468;
        
        readDataColorTextureCharacters(fileTexturePortuguese, ref arrayTexturePortugueseColor, numOfImagePixel);

        bufferTexturePortugueseColor_size14.SetData(arrayTexturePortugueseColor);

    }





    public void paintPortugueseFromTextureIndividual_size14(int Xaxis, int Yaxis, int Xtile, int Ytile)
    {

        int _PositionScreenX = Xaxis;        
        int _PositionScreenY = Yaxis;
        
        int _PositionTileX = Xtile;        
        int _PositionTileY = Ytile;                
        

        computacion.SetInt("_PositionScreenPortugueseX_size14", _PositionScreenX);
        computacion.SetInt("_PositionScreenPortugueseY_size14", _PositionScreenY);

        computacion.SetInt("_PositionTilePortugueseX_size14", _PositionTileX);
        computacion.SetInt("_PositionTilePortugueseY_size14", _PositionTileY);

        computacion.Dispatch(_kernelforPrintTilesPortugueseIndividual_size14, 21, 1,1);

    }



//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
// MEMORY character TEXTURE 14 SIZE
//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////


//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
// MEMORY BOUNDS
//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////



    public void loadBufferHorizontalPosition()
    {

        computacion.Dispatch(_kernelforLoadHorizontalPosition, 7, 1, 1);        

    }

    
    public void loadBufferVerticalPosition()
    {

        computacion.Dispatch(_kernelforLoadVerticalPosition, 40, 1, 1);        

    }


    public void paintHorizontalPosition(int Xaxis, int Yaxis, int color)
    {

        int _PositionScreenX_Horizontal = Xaxis;
        int _PositionScreenY_Horizontal = Yaxis;
        int _PositionColorHorizontal = 4 * color;

        computacion.SetInt("_PositionScreenX_Horizontal", _PositionScreenX_Horizontal);
        computacion.SetInt("_PositionScreenY_Horizontal", _PositionScreenY_Horizontal);
        computacion.SetInt("_PositionColorHorizontal", _PositionColorHorizontal);

        computacion.Dispatch(_kernelforPrintHorizontal, 7, 1, 1);        

    }


    public void paintVerticalPosition(int Xaxis, int Yaxis, int color)
    {

        int _PositionScreenX_Vertical = Xaxis;
        int _PositionScreenY_Vertical = Yaxis;
        int _PositionColorVertical = 4 * color;


        computacion.SetInt("_PositionScreenX_Vertical", _PositionScreenX_Vertical);
        computacion.SetInt("_PositionScreenY_Vertical", _PositionScreenY_Vertical);
        computacion.SetInt("_PositionColorVertical", _PositionColorVertical);

        computacion.Dispatch(_kernelforPrintVertical, 40, 1, 1);        

    }


    public void paintHorizontalPositionBlack(int Xaxis, int Yaxis)
    {

        int _PositionScreenX_HorizontalBlack = Xaxis;
        int _PositionScreenY_HorizontalBlack = Yaxis;

        computacion.SetInt("_PositionScreenX_HorizontalBlack", _PositionScreenX_HorizontalBlack);
        computacion.SetInt("_PositionScreenY_HorizontalBlack", _PositionScreenY_HorizontalBlack);

        computacion.Dispatch(_kernelforPrintHorizontalBlack, 7, 1, 1);        

    }


    public void paintVerticalPositionBlack(int Xaxis, int Yaxis)
    {

        int _PositionScreenX_VerticalBlack = Xaxis;
        int _PositionScreenY_VerticalBlack = Yaxis;

        computacion.SetInt("_PositionScreenX_VerticalBlack", _PositionScreenX_VerticalBlack);
        computacion.SetInt("_PositionScreenY_VerticalBlack", _PositionScreenY_VerticalBlack);

        computacion.Dispatch(_kernelforPrintVerticalBlack, 40, 1, 1);        

    }



//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
// MEMORY BOUNDS
//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////


/////////////////////////////////////////////////////////////////////////////////////////////////////////
//   DESTROY DESTROY DESTROY DESTROY DESTROY DESTROY DESTROY DESTROY DESTROY DESTROY DESTROY DESTROY   //
/////////////////////////////////////////////////////////////////////////////////////////////////////////


    void OnDestroy()
    {   


        bufferImageColor.Release();
        bufferImageColor.Dispose();
        bufferImageColor = null;

        bufferLargeMemory.Release();
        bufferLargeMemory.Dispose();
        bufferLargeMemory = null;

        bufferImageColorWriteTextField.Release();
        bufferImageColorWriteTextField.Dispose();
        bufferImageColorWriteTextField = null;


        bufferTextureTransparentPositionX.Dispose();
        bufferTextureTransparentPositionX.Release();
        bufferTextureTransparentPositionX = null;

        bufferTextureTransparentPositionY.Dispose();
        bufferTextureTransparentPositionY.Release();
        bufferTextureTransparentPositionY = null;

        bufferTextureBigPositionX.Dispose();
        bufferTextureBigPositionX.Release();
        bufferTextureBigPositionX = null;

        bufferTextureBigPositionY.Dispose();
        bufferTextureBigPositionY.Release();
        bufferTextureBigPositionY = null;



        bufferTextureCharacterPositionX.Dispose();
        bufferTextureCharacterPositionX.Release();
        bufferTextureCharacterPositionX = null;

        bufferTextureCharacterPositionY.Dispose();
        bufferTextureCharacterPositionY.Release();
        bufferTextureCharacterPositionY = null;

        bufferTextureAlphabetColor.Dispose();
        bufferTextureAlphabetColor.Release();
        bufferTextureAlphabetColor = null;

        bufferTextureNumberColor.Dispose();
        bufferTextureNumberColor.Release();
        bufferTextureNumberColor = null;

        bufferTexturePortugueseColor.Dispose();
        bufferTexturePortugueseColor.Release();
        bufferTexturePortugueseColor = null;



        bufferTextureCharacterPositionX_size14.Dispose();
        bufferTextureCharacterPositionX_size14.Release();
        bufferTextureCharacterPositionX_size14 = null;

        bufferTextureCharacterPositionY_size14.Dispose();
        bufferTextureCharacterPositionY_size14.Release();
        bufferTextureCharacterPositionY_size14 = null;

        bufferTextureAlphabetColor_size14.Dispose();
        bufferTextureAlphabetColor_size14.Release();
        bufferTextureAlphabetColor_size14 = null;

        bufferTextureNumberColor_size14.Dispose();
        bufferTextureNumberColor_size14.Release();
        bufferTextureNumberColor_size14 = null;

        bufferTexturePortugueseColor_size14.Dispose();
        bufferTexturePortugueseColor_size14.Release();
        bufferTexturePortugueseColor_size14 = null;


        
        bufferTextureCharacterPositionX_size22.Dispose();
        bufferTextureCharacterPositionX_size22.Release();
        bufferTextureCharacterPositionX_size22 = null;

        bufferTextureCharacterPositionY_size22.Dispose();
        bufferTextureCharacterPositionY_size22.Release();
        bufferTextureCharacterPositionY_size22 = null;

        bufferTextureAlphabetColor_size22.Dispose();
        bufferTextureAlphabetColor_size22.Release();
        bufferTextureAlphabetColor_size22 = null;

        bufferTextureNumberColor_size22.Dispose();
        bufferTextureNumberColor_size22.Release();        
        bufferTextureNumberColor_size22 = null;

        bufferTexturePortugueseColor_size22.Dispose();
        bufferTexturePortugueseColor_size22.Release();
        bufferTexturePortugueseColor_size22 = null;



        bufferPointerPositionX.Dispose();
        bufferPointerPositionX.Release();
        bufferPointerPositionX = null;

        bufferPointerPositionY.Dispose();
        bufferPointerPositionY.Release();
        bufferPointerPositionY = null;

        bufferColorPointer.Dispose();
        bufferColorPointer.Release();
        bufferColorPointer = null;


        
        bufferHorizontalPositionX.Dispose();
        bufferHorizontalPositionX.Release();
        bufferHorizontalPositionX = null;
    
        bufferHorizontalPositionY.Dispose();
        bufferHorizontalPositionY.Release();
        bufferHorizontalPositionY = null;

        bufferVerticalPositionX.Dispose();
        bufferVerticalPositionX.Release();
        bufferVerticalPositionX = null;
    
        bufferVerticalPositionY.Dispose();
        bufferVerticalPositionY.Release();
        bufferVerticalPositionY = null;
    
    }

/////////////////////////////////////////////////////////////////////////////////////////////////////////
//   DESTROY DESTROY DESTROY DESTROY DESTROY DESTROY DESTROY DESTROY DESTROY DESTROY DESTROY DESTROY   //
/////////////////////////////////////////////////////////////////////////////////////////////////////////


}

}





