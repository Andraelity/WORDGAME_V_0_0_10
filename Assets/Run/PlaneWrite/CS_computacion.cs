using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// using C0CS_WordGame;
using readDataFromUI;



namespace computacion
{

public class ScriptComputacion: MonoBehaviour
{

    public const int CHARACTERWIDTH = 34;
    public const int CHARACTERWIDTH_size14 = 12;
    public const int CHARACTERWIDTH_size22 = 17;
    
    // bool afterAppostrophe = false;
    
    // bool shiftKey = false;
    
    // int appostrophe = 0;
    

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




//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
// MEMORY POINTER
//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////


    public static void loadBufferPointerPosition(ref ComputeShader computacion, int _kernelforLoadPointerPosition)
    {

        computacion.Dispatch(_kernelforLoadPointerPosition, 44, 1, 1);        

    }



    public static void paintPointerPosition( ref ComputeBuffer bufferColorPointer,ref ComputeShader computacion , int _kernelforPrintPointer, int Xaxis, int Yaxis, int seed)
    {


        int _PositionScreenX_Pointer = Xaxis;
        int _PositionScreenY_Pointer = Yaxis;


        computacion.SetInt("_PositionScreenX_Pointer", _PositionScreenX_Pointer);
        computacion.SetInt("_PositionScreenY_Pointer", _PositionScreenY_Pointer);


        System.Random aleatorioNumber = new System.Random(seed);


        int _arrayColor0 = aleatorioNumber.Next(0,255);

        
        int _arrayColor1 = aleatorioNumber.Next(0,255);

        
        int _arrayColor2 = aleatorioNumber.Next(0,255);
        
        float[] colorData = {_arrayColor0, _arrayColor1, _arrayColor2};

        bufferColorPointer.SetData(colorData, 0, 0, 3 );


        computacion.Dispatch(_kernelforPrintPointer, 44, 1, 1);        


    }


    public static void paintPointerPositionBlack(ref ComputeShader computacion, int _kernelforPrintPointerBlack, int Xaxis, int Yaxis)
    {


        int _PositionScreenX_PointerBlack = Xaxis;
        int _PositionScreenY_PointerBlack = Yaxis;

        computacion.SetInt("_PositionScreenX_PointerBlack", _PositionScreenX_PointerBlack);
        computacion.SetInt("_PositionScreenY_PointerBlack", _PositionScreenY_PointerBlack);

        computacion.Dispatch(_kernelforPrintPointerBlack, 44, 1, 1);        


    }


//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
// MEMORY POINTER
//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////



///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
// MEMORY OF characters TEXTURE 36 SIZE
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////


    public static void loadBufferTexturePosition(ref ComputeShader computacion, int _kernelforLoadTextureCharacterPosition)
    {
    
        computacion.Dispatch(_kernelforLoadTextureCharacterPosition, 392, 1, 1);
    
    }
    
    public static void loadBufferTextureAlphabet(ref ComputeBuffer bufferTextureAlphabetColor)
    {
    
        string fileTextureAlphabet = "TextureOfCharactersColor";
        
        float[] arrayTextureAlphabetColor = new float[175616];
        //positions[1692800];
        uint numOfImagePixel = 43904;
        
        readDataColorTextureCharacters(fileTextureAlphabet, ref arrayTextureAlphabetColor, numOfImagePixel);
        
        bufferTextureAlphabetColor.SetData(arrayTextureAlphabetColor);
    
    }

    public static void paintAlphabetFromTextureWriteTextField(ref ComputeShader computacion, int _kernelforPrintTilesAlphabetWriteTextField)
    {

        computacion.Dispatch(_kernelforPrintTilesAlphabetWriteTextField, 392, 1,1);

    }

    public static void paintAlphabetFromTextureIndividualWriteTextField(ref ComputeShader computacion, int _kernelforPrintTilesAlphabetIndividualWriteTextField, int Xaxis, int Yaxis, int Xtile, int Ytile)
    {

        int _PositionScreenXWriteTextField = Xaxis;        
        int _PositionScreenYWriteTextField = Yaxis;
        
        int _PositionTileXWriteTextField = Xtile;        
        int _PositionTileYWriteTextField = Ytile;                
        

        computacion.SetInt("_PositionScreenXWriteTextField", _PositionScreenXWriteTextField);
        computacion.SetInt("_PositionScreenYWriteTextField", _PositionScreenYWriteTextField);

        computacion.SetInt("_PositionTileXWriteTextField", _PositionTileXWriteTextField);
        computacion.SetInt("_PositionTileYWriteTextField", _PositionTileYWriteTextField);

        computacion.Dispatch(_kernelforPrintTilesAlphabetIndividualWriteTextField, 56, 1,1);

    }


    public static void paintAlphabetFromTexture(ref ComputeShader computacion, int _kernelforPrintTilesAlphabet)
    {

        computacion.Dispatch(_kernelforPrintTilesAlphabet, 392, 1,1);

    }


    public static void paintAlphabetFromTextureIndividual(ref ComputeShader computacion, int _kernelforPrintTilesAlphabetIndividual, int Xaxis, int Yaxis, int Xtile, int Ytile)
    {

        int _PositionScreenX = Xaxis;        
        int _PositionScreenY = Yaxis;
        
        int _PositionTileX = Xtile;        
        int _PositionTileY = Ytile;                
        

        computacion.SetInt("_PositionScreenX", _PositionScreenX);
        computacion.SetInt("_PositionScreenY", _PositionScreenY);

        computacion.SetInt("_PositionTileX", _PositionTileX);
        computacion.SetInt("_PositionTileY", _PositionTileY);

        computacion.Dispatch(_kernelforPrintTilesAlphabetIndividual, 56, 1,1);

    }


    //forLoadTextureNumberPosition
    public static void loadBufferTextureNumber(ref ComputeBuffer bufferTextureNumberColor)
    {

        string fileTextureNumber = "TextureOfNumbersColor";
        
        float[] arrayTextureNumberColor = new float[175616];
        //positions[1692800];

        uint numOfImagePixel = 43904;
        
        readDataColorTextureCharacters(fileTextureNumber, ref arrayTextureNumberColor, numOfImagePixel);

        bufferTextureNumberColor.SetData(arrayTextureNumberColor);

    }




    public static void paintNumberFromTextureIndividualWriteTextField(ref ComputeShader computacion, int _kernelforPrintTilesNumberIndividualWriteTextField, int Xaxis, int Yaxis, int Xtile, int Ytile)
    {

        int _PositionScreenXWriteTextField = Xaxis;
        int _PositionScreenYWriteTextField = Yaxis;
        
        int _PositionTileXWriteTextField = Xtile;        
        int _PositionTileYWriteTextField = Ytile;                
        

        computacion.SetInt("_PositionScreenNumberXWriteTextField", _PositionScreenXWriteTextField);
        computacion.SetInt("_PositionScreenNumberYWriteTextField", _PositionScreenYWriteTextField);

        computacion.SetInt("_PositionTileNumberXWriteTextField", _PositionTileXWriteTextField);
        computacion.SetInt("_PositionTileNumberYWriteTextField", _PositionTileYWriteTextField);

        computacion.Dispatch(_kernelforPrintTilesNumberIndividualWriteTextField, 56, 1,1);

    }




    public static void paintNumberFromTextureIndividual(ref ComputeShader computacion, int _kernelforPrintTilesNumberIndividual, int Xaxis, int Yaxis, int Xtile, int Ytile)
    {

        int _PositionScreenX = Xaxis;
        int _PositionScreenY = Yaxis;
        
        int _PositionTileX = Xtile;        
        int _PositionTileY = Ytile;                
        

        computacion.SetInt("_PositionScreenNumberX", _PositionScreenX);
        computacion.SetInt("_PositionScreenNumberY", _PositionScreenY);

        computacion.SetInt("_PositionTileNumberX", _PositionTileX);
        computacion.SetInt("_PositionTileNumberY", _PositionTileY);

        computacion.Dispatch(_kernelforPrintTilesNumberIndividual, 56, 1,1);

    }




    public static void loadBufferTexturePortuguese(ref ComputeBuffer bufferTexturePortugueseColor)
    {

        string fileTexturePortuguese = "TextureOfPortugueseColor";
        
        float[] arrayTexturePortugueseColor = new float[152768];
        //positions[1692800];

        uint numOfImagePixel = 38192;
        
        readDataColorTextureCharacters(fileTexturePortuguese, ref arrayTexturePortugueseColor, numOfImagePixel);

        bufferTexturePortugueseColor.SetData(arrayTexturePortugueseColor);

    }





    public static void paintPortugueseFromTextureIndividualWriteTextField(ref ComputeShader computacion, int _kernelforPrintTilesPortugueseIndividualWriteTextField, int Xaxis, int Yaxis, int Xtile, int Ytile)
    {

        int _PositionScreenXWriteTextField = Xaxis;        
        int _PositionScreenYWriteTextField = Yaxis;
        
        int _PositionTileXWriteTextField = Xtile;        
        int _PositionTileYWriteTextField = Ytile;                
        

        computacion.SetInt("_PositionScreenPortugueseXWriteTextField", _PositionScreenXWriteTextField);
        computacion.SetInt("_PositionScreenPortugueseYWriteTextField", _PositionScreenYWriteTextField);

        computacion.SetInt("_PositionTilePortugueseXWriteTextField", _PositionTileXWriteTextField);
        computacion.SetInt("_PositionTilePortugueseYWriteTextField", _PositionTileYWriteTextField);

        computacion.Dispatch(_kernelforPrintTilesPortugueseIndividualWriteTextField, 44, 1,1);

    }





    public static void paintPortugueseFromTextureIndividual(ref ComputeShader computacion, int _kernelforPrintTilesPortugueseIndividual, int Xaxis, int Yaxis, int Xtile, int Ytile)
    {

        int _PositionScreenX = Xaxis;        
        int _PositionScreenY = Yaxis;
        
        int _PositionTileX = Xtile;        
        int _PositionTileY = Ytile;                
        

        computacion.SetInt("_PositionScreenPortugueseX", _PositionScreenX);
        computacion.SetInt("_PositionScreenPortugueseY", _PositionScreenY);

        computacion.SetInt("_PositionTilePortugueseX", _PositionTileX);
        computacion.SetInt("_PositionTilePortugueseY", _PositionTileY);

        computacion.Dispatch(_kernelforPrintTilesPortugueseIndividual, 44, 1,1);

    }


///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
// MEMORY OF characters TEXTURE 36 SIZE
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////



    public static void paintWordPosition(ref ComputeShader computacion, int _kernelforPrintTilesAlphabetIndividual, int _kernelforPrintTilesNumberIndividual, int _kernelforPrintTilesPortugueseIndividual, int Xaxis, int Yaxis, string manageString)
    {

        // Input
        int _PositionTranslateX = Xaxis; 
        int _PositionTranslateY = Yaxis;

        string inputString = manageString;


        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        // ALGORITHM
        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////


        for(int i = 0; i < inputString.Length; ++i) 
        {

            string characterToPaint = inputString[i].ToString();

            if(characterToPaint == "A")
            {
                paintAlphabetFromTextureIndividual(ref computacion, _kernelforPrintTilesAlphabetIndividual, _PositionTranslateX, _PositionTranslateY, 0, 0);
                _PositionTranslateX -= CHARACTERWIDTH;
            }

            if(characterToPaint == "B")
            {
                paintAlphabetFromTextureIndividual(ref computacion, _kernelforPrintTilesAlphabetIndividual, _PositionTranslateX, _PositionTranslateY, 1, 0);
                _PositionTranslateX -= CHARACTERWIDTH;
            }

            if(characterToPaint == "C")
            {
                paintAlphabetFromTextureIndividual(ref computacion, _kernelforPrintTilesAlphabetIndividual, _PositionTranslateX, _PositionTranslateY, 2, 0);
                _PositionTranslateX -= CHARACTERWIDTH;
            }

            if(characterToPaint == "D")
            {
                paintAlphabetFromTextureIndividual(ref computacion, _kernelforPrintTilesAlphabetIndividual, _PositionTranslateX, _PositionTranslateY, 3, 0);
                _PositionTranslateX -= CHARACTERWIDTH;
            }

            if(characterToPaint == "E")
            {
                paintAlphabetFromTextureIndividual(ref computacion, _kernelforPrintTilesAlphabetIndividual, _PositionTranslateX, _PositionTranslateY, 0, 1);
                _PositionTranslateX -= CHARACTERWIDTH;
            }

            if(characterToPaint == "F")
            {
                paintAlphabetFromTextureIndividual(ref computacion, _kernelforPrintTilesAlphabetIndividual, _PositionTranslateX, _PositionTranslateY, 1, 1);
                _PositionTranslateX -= CHARACTERWIDTH;
            }

            if(characterToPaint == "G")
            {
                paintAlphabetFromTextureIndividual(ref computacion, _kernelforPrintTilesAlphabetIndividual, _PositionTranslateX, _PositionTranslateY, 2, 1);
                _PositionTranslateX -= CHARACTERWIDTH;
            }

            if(characterToPaint == "H")
            {
                paintAlphabetFromTextureIndividual(ref computacion, _kernelforPrintTilesAlphabetIndividual, _PositionTranslateX, _PositionTranslateY, 3, 1);
                _PositionTranslateX -= CHARACTERWIDTH;
            }

            if(characterToPaint == "I")
            {
                paintAlphabetFromTextureIndividual(ref computacion, _kernelforPrintTilesAlphabetIndividual, _PositionTranslateX, _PositionTranslateY, 0, 2);
                _PositionTranslateX -= CHARACTERWIDTH;
            }

            if(characterToPaint == "J")
            {
                paintAlphabetFromTextureIndividual(ref computacion, _kernelforPrintTilesAlphabetIndividual, _PositionTranslateX, _PositionTranslateY, 1, 2);
                _PositionTranslateX -= CHARACTERWIDTH;
            }

            if(characterToPaint == "K")
            {
                paintAlphabetFromTextureIndividual(ref computacion, _kernelforPrintTilesAlphabetIndividual, _PositionTranslateX, _PositionTranslateY, 2, 2);
                _PositionTranslateX -= CHARACTERWIDTH;
            }

            if(characterToPaint == "L")
            {
                paintAlphabetFromTextureIndividual(ref computacion, _kernelforPrintTilesAlphabetIndividual, _PositionTranslateX, _PositionTranslateY, 3, 2);
                _PositionTranslateX -= CHARACTERWIDTH;
            }

            if(characterToPaint == "M")
            {
                paintAlphabetFromTextureIndividual(ref computacion, _kernelforPrintTilesAlphabetIndividual, _PositionTranslateX, _PositionTranslateY, 0, 3);
                _PositionTranslateX -= CHARACTERWIDTH;
            }

            if(characterToPaint == "N")
            {
                paintAlphabetFromTextureIndividual(ref computacion, _kernelforPrintTilesAlphabetIndividual, _PositionTranslateX, _PositionTranslateY, 1, 3);
                _PositionTranslateX -= CHARACTERWIDTH;
            }

            if(characterToPaint == "O")
            {
                paintAlphabetFromTextureIndividual(ref computacion, _kernelforPrintTilesAlphabetIndividual, _PositionTranslateX, _PositionTranslateY, 2, 3);
                _PositionTranslateX -= CHARACTERWIDTH;
            }

            if(characterToPaint == "P")
            {
                paintAlphabetFromTextureIndividual(ref computacion, _kernelforPrintTilesAlphabetIndividual, _PositionTranslateX, _PositionTranslateY, 3, 3);
                _PositionTranslateX -= CHARACTERWIDTH;
            }

            if(characterToPaint == "Q")
            {
                paintAlphabetFromTextureIndividual(ref computacion, _kernelforPrintTilesAlphabetIndividual, _PositionTranslateX, _PositionTranslateY, 0, 4);
                _PositionTranslateX -= CHARACTERWIDTH;
            }

            if(characterToPaint == "R")
            {
                paintAlphabetFromTextureIndividual(ref computacion, _kernelforPrintTilesAlphabetIndividual, _PositionTranslateX, _PositionTranslateY, 1, 4);
                _PositionTranslateX -= CHARACTERWIDTH;
            }

            if(characterToPaint == "S")
            {
                paintAlphabetFromTextureIndividual(ref computacion, _kernelforPrintTilesAlphabetIndividual, _PositionTranslateX, _PositionTranslateY, 2, 4);
                _PositionTranslateX -= CHARACTERWIDTH;
            }

            if(characterToPaint == "T")
            {
                paintAlphabetFromTextureIndividual(ref computacion, _kernelforPrintTilesAlphabetIndividual, _PositionTranslateX, _PositionTranslateY, 3, 4);
                _PositionTranslateX -= CHARACTERWIDTH;
            }

            if(characterToPaint == "U")
                {
                paintAlphabetFromTextureIndividual(ref computacion, _kernelforPrintTilesAlphabetIndividual, _PositionTranslateX, _PositionTranslateY, 0, 5);
                _PositionTranslateX -= CHARACTERWIDTH;
            }

            if(characterToPaint == "V")
            {
                paintAlphabetFromTextureIndividual(ref computacion, _kernelforPrintTilesAlphabetIndividual, _PositionTranslateX, _PositionTranslateY, 1, 5);
                _PositionTranslateX -= CHARACTERWIDTH;
            }

            if(characterToPaint == "W")
            {
                paintAlphabetFromTextureIndividual(ref computacion, _kernelforPrintTilesAlphabetIndividual, _PositionTranslateX, _PositionTranslateY, 2, 5);
                _PositionTranslateX -= CHARACTERWIDTH;
            }

            if(characterToPaint == "X")
            {
                paintAlphabetFromTextureIndividual(ref computacion, _kernelforPrintTilesAlphabetIndividual, _PositionTranslateX, _PositionTranslateY, 3, 5);
                _PositionTranslateX -= CHARACTERWIDTH;
            }

            if(characterToPaint == "Y")
            {
                paintAlphabetFromTextureIndividual(ref computacion, _kernelforPrintTilesAlphabetIndividual, _PositionTranslateX, _PositionTranslateY, 0, 6);
                _PositionTranslateX -= CHARACTERWIDTH;
            }

            if(characterToPaint == "Z")
            {
                paintAlphabetFromTextureIndividual(ref computacion, _kernelforPrintTilesAlphabetIndividual, _PositionTranslateX, _PositionTranslateY, 1, 6);
                _PositionTranslateX -= CHARACTERWIDTH;
            }

            if(characterToPaint == " ")
            {
                paintAlphabetFromTextureIndividual(ref computacion, _kernelforPrintTilesAlphabetIndividual, _PositionTranslateX, _PositionTranslateY, 2, 6);
                _PositionTranslateX -= CHARACTERWIDTH;
            }

            /////////////////////////////////////////////////////////////////////////////////////////
            // Texture of numbers and italian
            /////////////////////////////////////////////////////////////////////////////////////////


            if(MethodExtend.keyboardLanguage == 0)
            {

    
                if(characterToPaint == "0")
                {
                    paintNumberFromTextureIndividual(ref computacion, _kernelforPrintTilesNumberIndividual, _PositionTranslateX, _PositionTranslateY, 0, 0);
                    _PositionTranslateX -= CHARACTERWIDTH;
                }
    
                if(characterToPaint == "1")
                {
                    paintNumberFromTextureIndividual(ref computacion, _kernelforPrintTilesNumberIndividual, _PositionTranslateX, _PositionTranslateY, 1, 0);
                    _PositionTranslateX -= CHARACTERWIDTH;
                }
    
                if(characterToPaint == "2")
                {
                    paintNumberFromTextureIndividual(ref computacion, _kernelforPrintTilesNumberIndividual, _PositionTranslateX, _PositionTranslateY, 2, 0);
                    _PositionTranslateX -= CHARACTERWIDTH;
                }
    
                if(characterToPaint == "3")
                {
                    paintNumberFromTextureIndividual(ref computacion, _kernelforPrintTilesNumberIndividual, _PositionTranslateX, _PositionTranslateY, 3, 0);
                    _PositionTranslateX -= CHARACTERWIDTH;
                }
    
                if(characterToPaint == "4")
                {
                    paintNumberFromTextureIndividual(ref computacion, _kernelforPrintTilesNumberIndividual, _PositionTranslateX, _PositionTranslateY, 0, 1);
                    _PositionTranslateX -= CHARACTERWIDTH;
                }
    
                if(characterToPaint == "5")
                {
                    paintNumberFromTextureIndividual(ref computacion, _kernelforPrintTilesNumberIndividual, _PositionTranslateX, _PositionTranslateY, 1, 1);
                    _PositionTranslateX -= CHARACTERWIDTH;
                }
    
                if(characterToPaint == "6")
                {
                    paintNumberFromTextureIndividual(ref computacion, _kernelforPrintTilesNumberIndividual, _PositionTranslateX, _PositionTranslateY, 2, 1);
                    _PositionTranslateX -= CHARACTERWIDTH;
                }
    
                if(characterToPaint == "7")
                {
                    paintNumberFromTextureIndividual(ref computacion, _kernelforPrintTilesNumberIndividual, _PositionTranslateX, _PositionTranslateY, 3, 1);
                    _PositionTranslateX -= CHARACTERWIDTH;
                }
    
                if(characterToPaint == "8")
                {
                    paintNumberFromTextureIndividual(ref computacion, _kernelforPrintTilesNumberIndividual, _PositionTranslateX, _PositionTranslateY, 0, 2);
                    _PositionTranslateX -= CHARACTERWIDTH;
                }
    
                if(characterToPaint == "9")
                {
                    paintNumberFromTextureIndividual(ref computacion, _kernelforPrintTilesNumberIndividual, _PositionTranslateX, _PositionTranslateY, 1, 2);
                    _PositionTranslateX -= CHARACTERWIDTH;
                }
    
                if(characterToPaint == "À")
                {
                    paintNumberFromTextureIndividual(ref computacion, _kernelforPrintTilesNumberIndividual, _PositionTranslateX, _PositionTranslateY, 2, 2);
                    _PositionTranslateX -= CHARACTERWIDTH;
                }
    
                if(characterToPaint == "È")
                {
                    paintNumberFromTextureIndividual(ref computacion, _kernelforPrintTilesNumberIndividual, _PositionTranslateX, _PositionTranslateY, 3, 2);
                    _PositionTranslateX -= CHARACTERWIDTH;
                }
    
                if(characterToPaint == "É")
                {
                    paintNumberFromTextureIndividual(ref computacion, _kernelforPrintTilesNumberIndividual, _PositionTranslateX, _PositionTranslateY, 0, 3);
                    _PositionTranslateX -= CHARACTERWIDTH;
                }
    
                if(characterToPaint == "Ì")
                {
                    paintNumberFromTextureIndividual(ref computacion, _kernelforPrintTilesNumberIndividual, _PositionTranslateX, _PositionTranslateY, 1, 3);
                    _PositionTranslateX -= CHARACTERWIDTH;
                }
    
                if(characterToPaint == "Ò")
                {
                    paintNumberFromTextureIndividual(ref computacion, _kernelforPrintTilesNumberIndividual, _PositionTranslateX, _PositionTranslateY, 2, 3);
                    _PositionTranslateX -= CHARACTERWIDTH;
                }
    
                if(characterToPaint == "Ù")
                {
                    paintNumberFromTextureIndividual(ref computacion, _kernelforPrintTilesNumberIndividual, _PositionTranslateX, _PositionTranslateY, 3, 3);
                    _PositionTranslateX -= CHARACTERWIDTH;
                }
    
                if(characterToPaint == "’")
                {
                    paintNumberFromTextureIndividual(ref computacion, _kernelforPrintTilesNumberIndividual, _PositionTranslateX, _PositionTranslateY, 0, 4);
                    _PositionTranslateX -= CHARACTERWIDTH;
                }
                if(characterToPaint == "‘")
                {
                    paintNumberFromTextureIndividual(ref computacion, _kernelforPrintTilesNumberIndividual, _PositionTranslateX, _PositionTranslateY, 1, 4);
                    _PositionTranslateX -= CHARACTERWIDTH;
                }

    
            }

            if(MethodExtend.keyboardLanguage == 1)
            {

                if(characterToPaint == "Á")
                {
                    paintPortugueseFromTextureIndividual(ref computacion, _kernelforPrintTilesPortugueseIndividual, _PositionTranslateX, _PositionTranslateY, 0, 0);
                    _PositionTranslateX -= CHARACTERWIDTH;
                }
            
                if(characterToPaint == "À")
                {
                    paintPortugueseFromTextureIndividual(ref computacion, _kernelforPrintTilesPortugueseIndividual, _PositionTranslateX, _PositionTranslateY, 1, 0);
                    _PositionTranslateX -= CHARACTERWIDTH;
                }
            
                if(characterToPaint == "Â")
                {
                    paintPortugueseFromTextureIndividual(ref computacion, _kernelforPrintTilesPortugueseIndividual, _PositionTranslateX, _PositionTranslateY, 2, 0);
                    _PositionTranslateX -= CHARACTERWIDTH;
                }

                if(characterToPaint == "Ã")
                {
                    paintPortugueseFromTextureIndividual(ref computacion, _kernelforPrintTilesPortugueseIndividual, _PositionTranslateX, _PositionTranslateY, 0, 1);
                    _PositionTranslateX -= CHARACTERWIDTH;
                }
            
                if(characterToPaint == "Ä")
                {
                    paintPortugueseFromTextureIndividual(ref computacion, _kernelforPrintTilesPortugueseIndividual, _PositionTranslateX, _PositionTranslateY, 3, 0);
                    _PositionTranslateX -= CHARACTERWIDTH;
                }
            
                if(characterToPaint == "Ç")
                {
                    paintPortugueseFromTextureIndividual(ref computacion, _kernelforPrintTilesPortugueseIndividual, _PositionTranslateX, _PositionTranslateY, 1, 1);
                    _PositionTranslateX -= CHARACTERWIDTH;
                }
    
                if(characterToPaint == "É")
                {
                    paintPortugueseFromTextureIndividual(ref computacion, _kernelforPrintTilesPortugueseIndividual, _PositionTranslateX, _PositionTranslateY, 2, 1);
                    _PositionTranslateX -= CHARACTERWIDTH;
                }
            
                if(characterToPaint == "È")
                {
                    paintPortugueseFromTextureIndividual(ref computacion, _kernelforPrintTilesPortugueseIndividual, _PositionTranslateX, _PositionTranslateY, 3, 1);
                    _PositionTranslateX -= CHARACTERWIDTH;
                }
            
                if(characterToPaint == "Ê")
                {
                    paintPortugueseFromTextureIndividual(ref computacion, _kernelforPrintTilesPortugueseIndividual, _PositionTranslateX, _PositionTranslateY, 0, 2);
                    _PositionTranslateX -= CHARACTERWIDTH;
                }

                if(characterToPaint == "Ë")
                {
                    paintPortugueseFromTextureIndividual(ref computacion, _kernelforPrintTilesPortugueseIndividual, _PositionTranslateX, _PositionTranslateY, 1, 2);
                    _PositionTranslateX -= CHARACTERWIDTH;
                }    

                if(characterToPaint == "Í")
                {
                    paintPortugueseFromTextureIndividual(ref computacion, _kernelforPrintTilesPortugueseIndividual, _PositionTranslateX, _PositionTranslateY, 2, 2);
                    _PositionTranslateX -= CHARACTERWIDTH;
                }
            
                if(characterToPaint == "Ì")
                {
                    paintPortugueseFromTextureIndividual(ref computacion, _kernelforPrintTilesPortugueseIndividual, _PositionTranslateX, _PositionTranslateY, 3, 2);
                    _PositionTranslateX -= CHARACTERWIDTH;
                }
            
                if(characterToPaint == "Î")
                {
                    paintPortugueseFromTextureIndividual(ref computacion, _kernelforPrintTilesPortugueseIndividual, _PositionTranslateX, _PositionTranslateY, 0, 3);
                    _PositionTranslateX -= CHARACTERWIDTH;
                }

                if(characterToPaint == "Ï")
                {
                    paintPortugueseFromTextureIndividual(ref computacion, _kernelforPrintTilesPortugueseIndividual, _PositionTranslateX, _PositionTranslateY, 1, 3);
                    _PositionTranslateX -= CHARACTERWIDTH;
                }    

                if(characterToPaint == "Ó")
                {
                    paintPortugueseFromTextureIndividual(ref computacion, _kernelforPrintTilesPortugueseIndividual, _PositionTranslateX, _PositionTranslateY, 2, 3);
                    _PositionTranslateX -= CHARACTERWIDTH;
                }
            
                if(characterToPaint == "Ò")
                {
                    paintPortugueseFromTextureIndividual(ref computacion, _kernelforPrintTilesPortugueseIndividual, _PositionTranslateX, _PositionTranslateY, 3, 3);
                    _PositionTranslateX -= CHARACTERWIDTH;
                }
        
                if(characterToPaint == "Õ")
                {
                    paintPortugueseFromTextureIndividual(ref computacion, _kernelforPrintTilesPortugueseIndividual, _PositionTranslateX, _PositionTranslateY, 2, 4);
                    _PositionTranslateX -= CHARACTERWIDTH;
                }

                if(characterToPaint == "Ô")
                {
                    paintPortugueseFromTextureIndividual(ref computacion, _kernelforPrintTilesPortugueseIndividual, _PositionTranslateX, _PositionTranslateY, 0, 4);
                    _PositionTranslateX -= CHARACTERWIDTH;
                }    

                if(characterToPaint == "Ö")
                {
                    paintPortugueseFromTextureIndividual(ref computacion, _kernelforPrintTilesPortugueseIndividual, _PositionTranslateX, _PositionTranslateY, 1, 4);
                    _PositionTranslateX -= CHARACTERWIDTH;
                }    

                if(characterToPaint == "Ú")
                {
                    paintPortugueseFromTextureIndividual(ref computacion, _kernelforPrintTilesPortugueseIndividual, _PositionTranslateX, _PositionTranslateY, 1, 4);
                    _PositionTranslateX -= CHARACTERWIDTH;
                }
            
                if(characterToPaint == "Ù")
                {
                    paintPortugueseFromTextureIndividual(ref computacion, _kernelforPrintTilesPortugueseIndividual, _PositionTranslateX, _PositionTranslateY, 0, 5);
                    _PositionTranslateX -= CHARACTERWIDTH;
                }
            
                if(characterToPaint == "Û")
                {
                    paintPortugueseFromTextureIndividual(ref computacion, _kernelforPrintTilesPortugueseIndividual, _PositionTranslateX, _PositionTranslateY, 1, 5);
                    _PositionTranslateX -= CHARACTERWIDTH;
                }

                if(characterToPaint == "Ü")
                {
                    paintPortugueseFromTextureIndividual(ref computacion, _kernelforPrintTilesPortugueseIndividual, _PositionTranslateX, _PositionTranslateY, 2, 5);
                    _PositionTranslateX -= CHARACTERWIDTH;
                }    

            }

        }

    }    





    public static void paintWordPositionWriteTextField(ref ComputeShader computacion, int _kernelforPrintTilesAlphabetIndividualWriteTextField, int _kernelforPrintTilesNumberIndividualWriteTextField, int _kernelforPrintTilesPortugueseIndividualWriteTextField, int Xaxis, int Yaxis, string manageString)
    {


        int _PositionTranslateX = Xaxis; 
        int _PositionTranslateY = Yaxis;


        string inputString = manageString;


        for(int i = 0; i < inputString.Length; ++i) 
        {

            string characterToPaint = inputString[i].ToString();

            if(characterToPaint == "A")
            {
                paintAlphabetFromTextureIndividualWriteTextField(ref computacion, _kernelforPrintTilesAlphabetIndividualWriteTextField, _PositionTranslateX, _PositionTranslateY, 0, 0);
                _PositionTranslateX -= CHARACTERWIDTH;
            }

            if(characterToPaint == "B")
            {
                paintAlphabetFromTextureIndividualWriteTextField(ref computacion, _kernelforPrintTilesAlphabetIndividualWriteTextField, _PositionTranslateX, _PositionTranslateY, 1, 0);
                _PositionTranslateX -= CHARACTERWIDTH;
            }

            if(characterToPaint == "C")
            {
                paintAlphabetFromTextureIndividualWriteTextField(ref computacion, _kernelforPrintTilesAlphabetIndividualWriteTextField, _PositionTranslateX, _PositionTranslateY, 2, 0);
                _PositionTranslateX -= CHARACTERWIDTH;
            }

            if(characterToPaint == "D")
            {
                paintAlphabetFromTextureIndividualWriteTextField(ref computacion, _kernelforPrintTilesAlphabetIndividualWriteTextField, _PositionTranslateX, _PositionTranslateY, 3, 0);
                _PositionTranslateX -= CHARACTERWIDTH;
            }

            if(characterToPaint == "E")
            {
                paintAlphabetFromTextureIndividualWriteTextField(ref computacion, _kernelforPrintTilesAlphabetIndividualWriteTextField, _PositionTranslateX, _PositionTranslateY, 0, 1);
                _PositionTranslateX -= CHARACTERWIDTH;
            }

            if(characterToPaint == "F")
            {
                paintAlphabetFromTextureIndividualWriteTextField(ref computacion, _kernelforPrintTilesAlphabetIndividualWriteTextField, _PositionTranslateX, _PositionTranslateY, 1, 1);
                _PositionTranslateX -= CHARACTERWIDTH;
            }

            if(characterToPaint == "G")
            {
                paintAlphabetFromTextureIndividualWriteTextField(ref computacion, _kernelforPrintTilesAlphabetIndividualWriteTextField, _PositionTranslateX, _PositionTranslateY, 2, 1);
                _PositionTranslateX -= CHARACTERWIDTH;
            }

            if(characterToPaint == "H")
            {
                paintAlphabetFromTextureIndividualWriteTextField(ref computacion, _kernelforPrintTilesAlphabetIndividualWriteTextField, _PositionTranslateX, _PositionTranslateY, 3, 1);
                _PositionTranslateX -= CHARACTERWIDTH;
            }

            if(characterToPaint == "I")
            {
                paintAlphabetFromTextureIndividualWriteTextField(ref computacion, _kernelforPrintTilesAlphabetIndividualWriteTextField, _PositionTranslateX, _PositionTranslateY, 0, 2);
                _PositionTranslateX -= CHARACTERWIDTH;
            }

            if(characterToPaint == "J")
            {
                paintAlphabetFromTextureIndividualWriteTextField(ref computacion, _kernelforPrintTilesAlphabetIndividualWriteTextField, _PositionTranslateX, _PositionTranslateY, 1, 2);
                _PositionTranslateX -= CHARACTERWIDTH;
            }

            if(characterToPaint == "K")
            {
                paintAlphabetFromTextureIndividualWriteTextField(ref computacion, _kernelforPrintTilesAlphabetIndividualWriteTextField, _PositionTranslateX, _PositionTranslateY, 2, 2);
                _PositionTranslateX -= CHARACTERWIDTH;
            }

            if(characterToPaint == "L")
            {
                paintAlphabetFromTextureIndividualWriteTextField(ref computacion, _kernelforPrintTilesAlphabetIndividualWriteTextField, _PositionTranslateX, _PositionTranslateY, 3, 2);
                _PositionTranslateX -= CHARACTERWIDTH;
            }

            if(characterToPaint == "M")
            {
                paintAlphabetFromTextureIndividualWriteTextField(ref computacion, _kernelforPrintTilesAlphabetIndividualWriteTextField, _PositionTranslateX, _PositionTranslateY, 0, 3);
                _PositionTranslateX -= CHARACTERWIDTH;
            }

            if(characterToPaint == "N")
            {
                paintAlphabetFromTextureIndividualWriteTextField(ref computacion, _kernelforPrintTilesAlphabetIndividualWriteTextField, _PositionTranslateX, _PositionTranslateY, 1, 3);
                _PositionTranslateX -= CHARACTERWIDTH;
            }

            if(characterToPaint == "O")
            {
                paintAlphabetFromTextureIndividualWriteTextField(ref computacion, _kernelforPrintTilesAlphabetIndividualWriteTextField, _PositionTranslateX, _PositionTranslateY, 2, 3);
                _PositionTranslateX -= CHARACTERWIDTH;
            }

            if(characterToPaint == "P")
            {
                paintAlphabetFromTextureIndividualWriteTextField(ref computacion, _kernelforPrintTilesAlphabetIndividualWriteTextField, _PositionTranslateX, _PositionTranslateY, 3, 3);
                _PositionTranslateX -= CHARACTERWIDTH;
            }

            if(characterToPaint == "Q")
            {
                paintAlphabetFromTextureIndividualWriteTextField(ref computacion, _kernelforPrintTilesAlphabetIndividualWriteTextField, _PositionTranslateX, _PositionTranslateY, 0, 4);
                _PositionTranslateX -= CHARACTERWIDTH;
            }

            if(characterToPaint == "R")
            {
                paintAlphabetFromTextureIndividualWriteTextField(ref computacion, _kernelforPrintTilesAlphabetIndividualWriteTextField, _PositionTranslateX, _PositionTranslateY, 1, 4);
                _PositionTranslateX -= CHARACTERWIDTH;
            }

            if(characterToPaint == "S")
            {
                paintAlphabetFromTextureIndividualWriteTextField(ref computacion, _kernelforPrintTilesAlphabetIndividualWriteTextField, _PositionTranslateX, _PositionTranslateY, 2, 4);
                _PositionTranslateX -= CHARACTERWIDTH;
            }

            if(characterToPaint == "T")
            {
                paintAlphabetFromTextureIndividualWriteTextField(ref computacion, _kernelforPrintTilesAlphabetIndividualWriteTextField, _PositionTranslateX, _PositionTranslateY, 3, 4);
                _PositionTranslateX -= CHARACTERWIDTH;
            }

            if(characterToPaint == "U")
                {
                paintAlphabetFromTextureIndividualWriteTextField(ref computacion, _kernelforPrintTilesAlphabetIndividualWriteTextField, _PositionTranslateX, _PositionTranslateY, 0, 5);
                _PositionTranslateX -= CHARACTERWIDTH;
            }

            if(characterToPaint == "V")
            {
                paintAlphabetFromTextureIndividualWriteTextField(ref computacion, _kernelforPrintTilesAlphabetIndividualWriteTextField, _PositionTranslateX, _PositionTranslateY, 1, 5);
                _PositionTranslateX -= CHARACTERWIDTH;
            }

            if(characterToPaint == "W")
            {
                paintAlphabetFromTextureIndividualWriteTextField(ref computacion, _kernelforPrintTilesAlphabetIndividualWriteTextField, _PositionTranslateX, _PositionTranslateY, 2, 5);
                _PositionTranslateX -= CHARACTERWIDTH;
            }

            if(characterToPaint == "X")
            {
                paintAlphabetFromTextureIndividualWriteTextField(ref computacion, _kernelforPrintTilesAlphabetIndividualWriteTextField, _PositionTranslateX, _PositionTranslateY, 3, 5);
                _PositionTranslateX -= CHARACTERWIDTH;
            }

            if(characterToPaint == "Y")
            {
                paintAlphabetFromTextureIndividualWriteTextField(ref computacion, _kernelforPrintTilesAlphabetIndividualWriteTextField, _PositionTranslateX, _PositionTranslateY, 0, 6);
                _PositionTranslateX -= CHARACTERWIDTH;
            }

            if(characterToPaint == "Z")
            {
                paintAlphabetFromTextureIndividualWriteTextField(ref computacion, _kernelforPrintTilesAlphabetIndividualWriteTextField, _PositionTranslateX, _PositionTranslateY, 1, 6);
                _PositionTranslateX -= CHARACTERWIDTH;
            }

            if(characterToPaint == " ")
            {
                paintAlphabetFromTextureIndividualWriteTextField(ref computacion, _kernelforPrintTilesAlphabetIndividualWriteTextField, _PositionTranslateX, _PositionTranslateY, 2, 6);
                _PositionTranslateX -= CHARACTERWIDTH;
            }

            /////////////////////////////////////////////////////////////////////////////////////////
            // Texture of numbers and italian
            /////////////////////////////////////////////////////////////////////////////////////////


            if(MethodExtend.keyboardLanguage == 0)
            {

    
                if(characterToPaint == "0")
                {
                    paintNumberFromTextureIndividualWriteTextField(ref computacion, _kernelforPrintTilesNumberIndividualWriteTextField, _PositionTranslateX, _PositionTranslateY, 0, 0);
                    _PositionTranslateX -= CHARACTERWIDTH;
                }
    
                if(characterToPaint == "1")
                {
                    paintNumberFromTextureIndividualWriteTextField(ref computacion, _kernelforPrintTilesNumberIndividualWriteTextField, _PositionTranslateX, _PositionTranslateY, 1, 0);
                    _PositionTranslateX -= CHARACTERWIDTH;
                }
    
                if(characterToPaint == "2")
                {
                    paintNumberFromTextureIndividualWriteTextField(ref computacion, _kernelforPrintTilesNumberIndividualWriteTextField, _PositionTranslateX, _PositionTranslateY, 2, 0);
                    _PositionTranslateX -= CHARACTERWIDTH;
                }
    
                if(characterToPaint == "3")
                {
                    paintNumberFromTextureIndividualWriteTextField(ref computacion, _kernelforPrintTilesNumberIndividualWriteTextField, _PositionTranslateX, _PositionTranslateY, 3, 0);
                    _PositionTranslateX -= CHARACTERWIDTH;
                }
    
                if(characterToPaint == "4")
                {
                    paintNumberFromTextureIndividualWriteTextField(ref computacion, _kernelforPrintTilesNumberIndividualWriteTextField, _PositionTranslateX, _PositionTranslateY, 0, 1);
                    _PositionTranslateX -= CHARACTERWIDTH;
                }
    
                if(characterToPaint == "5")
                {
                    paintNumberFromTextureIndividualWriteTextField(ref computacion, _kernelforPrintTilesNumberIndividualWriteTextField, _PositionTranslateX, _PositionTranslateY, 1, 1);
                    _PositionTranslateX -= CHARACTERWIDTH;
                }
    
                if(characterToPaint == "6")
                {
                    paintNumberFromTextureIndividualWriteTextField(ref computacion, _kernelforPrintTilesNumberIndividualWriteTextField, _PositionTranslateX, _PositionTranslateY, 2, 1);
                    _PositionTranslateX -= CHARACTERWIDTH;
                }
    
                if(characterToPaint == "7")
                {
                    paintNumberFromTextureIndividualWriteTextField(ref computacion, _kernelforPrintTilesNumberIndividualWriteTextField, _PositionTranslateX, _PositionTranslateY, 3, 1);
                    _PositionTranslateX -= CHARACTERWIDTH;
                }
    
                if(characterToPaint == "8")
                {
                    paintNumberFromTextureIndividualWriteTextField(ref computacion, _kernelforPrintTilesNumberIndividualWriteTextField, _PositionTranslateX, _PositionTranslateY, 0, 2);
                    _PositionTranslateX -= CHARACTERWIDTH;
                }
    
                if(characterToPaint == "9")
                {
                    paintNumberFromTextureIndividualWriteTextField(ref computacion, _kernelforPrintTilesNumberIndividualWriteTextField, _PositionTranslateX, _PositionTranslateY, 1, 2);
                    _PositionTranslateX -= CHARACTERWIDTH;
                }
    
                if(characterToPaint == "À")
                {
                    paintNumberFromTextureIndividualWriteTextField(ref computacion, _kernelforPrintTilesNumberIndividualWriteTextField, _PositionTranslateX, _PositionTranslateY, 2, 2);
                    _PositionTranslateX -= CHARACTERWIDTH;
                }
    
                if(characterToPaint == "È")
                {
                    paintNumberFromTextureIndividualWriteTextField(ref computacion, _kernelforPrintTilesNumberIndividualWriteTextField, _PositionTranslateX, _PositionTranslateY, 3, 2);
                    _PositionTranslateX -= CHARACTERWIDTH;
                }
    
                if(characterToPaint == "É")
                {
                    paintNumberFromTextureIndividualWriteTextField(ref computacion, _kernelforPrintTilesNumberIndividualWriteTextField, _PositionTranslateX, _PositionTranslateY, 0, 3);
                    _PositionTranslateX -= CHARACTERWIDTH;
                }
    
                if(characterToPaint == "Ì")
                {
                    paintNumberFromTextureIndividualWriteTextField(ref computacion, _kernelforPrintTilesNumberIndividualWriteTextField, _PositionTranslateX, _PositionTranslateY, 1, 3);
                    _PositionTranslateX -= CHARACTERWIDTH;
                }
    
                if(characterToPaint == "Ò")
                {
                    paintNumberFromTextureIndividualWriteTextField(ref computacion, _kernelforPrintTilesNumberIndividualWriteTextField, _PositionTranslateX, _PositionTranslateY, 2, 3);
                    _PositionTranslateX -= CHARACTERWIDTH;
                }
    
                if(characterToPaint == "Ù")
                {
                    paintNumberFromTextureIndividualWriteTextField(ref computacion, _kernelforPrintTilesNumberIndividualWriteTextField, _PositionTranslateX, _PositionTranslateY, 3, 3);
                    _PositionTranslateX -= CHARACTERWIDTH;
                }
    
                if(characterToPaint == "’")
                {
                    paintNumberFromTextureIndividualWriteTextField(ref computacion, _kernelforPrintTilesNumberIndividualWriteTextField, _PositionTranslateX, _PositionTranslateY, 0, 4);
                    _PositionTranslateX -= CHARACTERWIDTH;
                }
                if(characterToPaint == "‘")
                {
                    paintNumberFromTextureIndividualWriteTextField(ref computacion, _kernelforPrintTilesNumberIndividualWriteTextField, _PositionTranslateX, _PositionTranslateY, 1, 4);
                    _PositionTranslateX -= CHARACTERWIDTH;
                }

    
            }

            if(MethodExtend.keyboardLanguage == 1)
            {

                if(characterToPaint == "Á")
                {
                    paintPortugueseFromTextureIndividualWriteTextField(ref computacion, _kernelforPrintTilesPortugueseIndividualWriteTextField, _PositionTranslateX, _PositionTranslateY, 0, 0);
                    _PositionTranslateX -= CHARACTERWIDTH;
                }
            
                if(characterToPaint == "À")
                {
                    paintPortugueseFromTextureIndividualWriteTextField(ref computacion, _kernelforPrintTilesPortugueseIndividualWriteTextField, _PositionTranslateX, _PositionTranslateY, 1, 0);
                    _PositionTranslateX -= CHARACTERWIDTH;
                }
            
                if(characterToPaint == "Â")
                {
                    paintPortugueseFromTextureIndividualWriteTextField(ref computacion, _kernelforPrintTilesPortugueseIndividualWriteTextField, _PositionTranslateX, _PositionTranslateY, 2, 0);
                    _PositionTranslateX -= CHARACTERWIDTH;
                }

                if(characterToPaint == "Ã")
                {
                    paintPortugueseFromTextureIndividualWriteTextField(ref computacion, _kernelforPrintTilesPortugueseIndividualWriteTextField, _PositionTranslateX, _PositionTranslateY, 0, 1);
                    _PositionTranslateX -= CHARACTERWIDTH;
                }
            
                if(characterToPaint == "Ä")
                {
                    paintPortugueseFromTextureIndividualWriteTextField(ref computacion, _kernelforPrintTilesPortugueseIndividualWriteTextField, _PositionTranslateX, _PositionTranslateY, 3, 0);
                    _PositionTranslateX -= CHARACTERWIDTH;
                }
            
                if(characterToPaint == "Ç")
                {
                    paintPortugueseFromTextureIndividualWriteTextField(ref computacion, _kernelforPrintTilesPortugueseIndividualWriteTextField, _PositionTranslateX, _PositionTranslateY, 1, 1);
                    _PositionTranslateX -= CHARACTERWIDTH;
                }
    
                if(characterToPaint == "É")
                {
                    paintPortugueseFromTextureIndividualWriteTextField(ref computacion, _kernelforPrintTilesPortugueseIndividualWriteTextField, _PositionTranslateX, _PositionTranslateY, 2, 1);
                    _PositionTranslateX -= CHARACTERWIDTH;
                }
            
                if(characterToPaint == "È")
                {
                    paintPortugueseFromTextureIndividualWriteTextField(ref computacion, _kernelforPrintTilesPortugueseIndividualWriteTextField, _PositionTranslateX, _PositionTranslateY, 3, 1);
                    _PositionTranslateX -= CHARACTERWIDTH;
                }
            
                if(characterToPaint == "Ê")
                {
                    paintPortugueseFromTextureIndividualWriteTextField(ref computacion, _kernelforPrintTilesPortugueseIndividualWriteTextField, _PositionTranslateX, _PositionTranslateY, 0, 2);
                    _PositionTranslateX -= CHARACTERWIDTH;
                }

                if(characterToPaint == "Ë")
                {
                    paintPortugueseFromTextureIndividualWriteTextField(ref computacion, _kernelforPrintTilesPortugueseIndividualWriteTextField, _PositionTranslateX, _PositionTranslateY, 1, 2);
                    _PositionTranslateX -= CHARACTERWIDTH;
                }    

                if(characterToPaint == "Í")
                {
                    paintPortugueseFromTextureIndividualWriteTextField(ref computacion, _kernelforPrintTilesPortugueseIndividualWriteTextField, _PositionTranslateX, _PositionTranslateY, 2, 2);
                    _PositionTranslateX -= CHARACTERWIDTH;
                }
            
                if(characterToPaint == "Ì")
                {
                    paintPortugueseFromTextureIndividualWriteTextField(ref computacion, _kernelforPrintTilesPortugueseIndividualWriteTextField, _PositionTranslateX, _PositionTranslateY, 3, 2);
                    _PositionTranslateX -= CHARACTERWIDTH;
                }
            
                if(characterToPaint == "Î")
                {
                    paintPortugueseFromTextureIndividualWriteTextField(ref computacion, _kernelforPrintTilesPortugueseIndividualWriteTextField, _PositionTranslateX, _PositionTranslateY, 0, 3);
                    _PositionTranslateX -= CHARACTERWIDTH;
                }

                if(characterToPaint == "Ï")
                {
                    paintPortugueseFromTextureIndividualWriteTextField(ref computacion, _kernelforPrintTilesPortugueseIndividualWriteTextField, _PositionTranslateX, _PositionTranslateY, 1, 3);
                    _PositionTranslateX -= CHARACTERWIDTH;
                }    

                if(characterToPaint == "Ó")
                {
                    paintPortugueseFromTextureIndividualWriteTextField(ref computacion, _kernelforPrintTilesPortugueseIndividualWriteTextField, _PositionTranslateX, _PositionTranslateY, 2, 3);
                    _PositionTranslateX -= CHARACTERWIDTH;
                }
            
                if(characterToPaint == "Ò")
                {
                    paintPortugueseFromTextureIndividualWriteTextField(ref computacion, _kernelforPrintTilesPortugueseIndividualWriteTextField, _PositionTranslateX, _PositionTranslateY, 3, 3);
                    _PositionTranslateX -= CHARACTERWIDTH;
                }
        
                if(characterToPaint == "Õ")
                {
                    paintPortugueseFromTextureIndividualWriteTextField(ref computacion, _kernelforPrintTilesPortugueseIndividualWriteTextField, _PositionTranslateX, _PositionTranslateY, 2, 4);
                    _PositionTranslateX -= CHARACTERWIDTH;
                }

                if(characterToPaint == "Ô")
                {
                    paintPortugueseFromTextureIndividualWriteTextField(ref computacion, _kernelforPrintTilesPortugueseIndividualWriteTextField, _PositionTranslateX, _PositionTranslateY, 0, 4);
                    _PositionTranslateX -= CHARACTERWIDTH;
                }    

                if(characterToPaint == "Ö")
                {
                    paintPortugueseFromTextureIndividualWriteTextField(ref computacion, _kernelforPrintTilesPortugueseIndividualWriteTextField, _PositionTranslateX, _PositionTranslateY, 1, 4);
                    _PositionTranslateX -= CHARACTERWIDTH;
                }    

                if(characterToPaint == "Ú")
                {
                    paintPortugueseFromTextureIndividualWriteTextField(ref computacion, _kernelforPrintTilesPortugueseIndividualWriteTextField, _PositionTranslateX, _PositionTranslateY, 1, 4);
                    _PositionTranslateX -= CHARACTERWIDTH;
                }
            
                if(characterToPaint == "Ù")
                {
                    paintPortugueseFromTextureIndividualWriteTextField(ref computacion, _kernelforPrintTilesPortugueseIndividualWriteTextField, _PositionTranslateX, _PositionTranslateY, 0, 5);
                    _PositionTranslateX -= CHARACTERWIDTH;
                }
            
                if(characterToPaint == "Û")
                {
                    paintPortugueseFromTextureIndividualWriteTextField(ref computacion, _kernelforPrintTilesPortugueseIndividualWriteTextField, _PositionTranslateX, _PositionTranslateY, 1, 5);
                    _PositionTranslateX -= CHARACTERWIDTH;
                }

                if(characterToPaint == "Ü")
                {
                    paintPortugueseFromTextureIndividualWriteTextField(ref computacion, _kernelforPrintTilesPortugueseIndividualWriteTextField, _PositionTranslateX, _PositionTranslateY, 2, 5);
                    _PositionTranslateX -= CHARACTERWIDTH;
                }    

            }

        }

    }    

//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
// MEMORY character TEXTURE 22 SIZE
//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

    public static void loadBufferTexturePosition_size22(ref ComputeShader computacion, int _kernelforLoadTextureCharacterPosition_size22)
    {
        
        computacion.Dispatch(_kernelforLoadTextureCharacterPosition_size22, 238, 1, 1);

    }
    

    public static void loadBufferTextureAlphabet_size22(ref ComputeBuffer bufferTextureAlphabetColor_size22)
    {

        string fileTextureAlphabet = "TransparentTextureOfCharacters-size22Color";
        
        float[] arrayTextureAlphabetColor = new float[64736];
        //positions[1692800];
        uint numOfImagePixel = 16184;

        readDataColorTextureCharacters(fileTextureAlphabet, ref arrayTextureAlphabetColor, numOfImagePixel);

        bufferTextureAlphabetColor_size22.SetData(arrayTextureAlphabetColor);

    }

    public static void paintAlphabetFromTextureWriteTextField_size22(ref ComputeShader computacion, int _kernelforPrintTilesAlphabetWriteTextField_size22)
    {

        computacion.Dispatch(_kernelforPrintTilesAlphabetWriteTextField_size22, 238, 1,1);

    }


    public static void paintAlphabetFromTextureIndividualWriteTextField_size22(ref ComputeShader computacion, int _kernelforPrintTilesAlphabetIndividualWriteTextField_size22, int Xaxis, int Yaxis, int Xtile, int Ytile)
    {

        int _PositionScreenXWriteTextField = Xaxis;        
        int _PositionScreenYWriteTextField = Yaxis;
        
        int _PositionTileXWriteTextField = Xtile;        
        int _PositionTileYWriteTextField = Ytile;                
        

        computacion.SetInt("_PositionScreenXWriteTextField_size22", _PositionScreenXWriteTextField);
        computacion.SetInt("_PositionScreenYWriteTextField_size22", _PositionScreenYWriteTextField);

        computacion.SetInt("_PositionTileXWriteTextField_size22", _PositionTileXWriteTextField);
        computacion.SetInt("_PositionTileYWriteTextField_size22", _PositionTileYWriteTextField);

        computacion.Dispatch(_kernelforPrintTilesAlphabetIndividualWriteTextField_size22, 34, 1,1);

    }





    public static void paintAlphabetFromTexture_size22(ref ComputeShader computacion, int _kernelforPrintTilesAlphabet_size22)
    {

        computacion.Dispatch(_kernelforPrintTilesAlphabet_size22, 238, 1,1);

    }





    public static void paintAlphabetFromTextureIndividual_size22(ref ComputeShader computacion, int _kernelforPrintTilesAlphabetIndividual_size22, int Xaxis, int Yaxis, int Xtile, int Ytile)
    {

        int _PositionScreenX = Xaxis;        
        int _PositionScreenY = Yaxis;
        
        int _PositionTileX = Xtile;        
        int _PositionTileY = Ytile;                
        

        computacion.SetInt("_PositionScreenX_size22", _PositionScreenX);
        computacion.SetInt("_PositionScreenY_size22", _PositionScreenY);

        computacion.SetInt("_PositionTileX_size22", _PositionTileX);
        computacion.SetInt("_PositionTileY_size22", _PositionTileY);

        computacion.Dispatch(_kernelforPrintTilesAlphabetIndividual_size22, 34, 1,1);

    }





    public static void loadBufferTextureNumber_size22(ref ComputeBuffer bufferTextureNumberColor_size22)
    {

        string fileTextureNumber = "TransparentTextureOfNumbers-size22Color";
        
        float[] arrayTextureNumberColor = new float[64736];

        uint numOfImagePixel = 16184;
        
        readDataColorTextureCharacters(fileTextureNumber, ref arrayTextureNumberColor, numOfImagePixel);

        bufferTextureNumberColor_size22.SetData(arrayTextureNumberColor);

    }




    public static void paintNumberFromTextureIndividualWriteTextField_size22(ref ComputeShader computacion, int _kernelforPrintTilesNumberIndividualWriteTextField_size22, int Xaxis, int Yaxis, int Xtile, int Ytile)
    {

        int _PositionScreenXWriteTextField = Xaxis;
        int _PositionScreenYWriteTextField = Yaxis;
        
        int _PositionTileXWriteTextField = Xtile;        
        int _PositionTileYWriteTextField = Ytile;                
        

        computacion.SetInt("_PositionScreenNumberXWriteTextField_size22", _PositionScreenXWriteTextField);
        computacion.SetInt("_PositionScreenNumberYWriteTextField_size22", _PositionScreenYWriteTextField);

        computacion.SetInt("_PositionTileNumberXWriteTextField_size22", _PositionTileXWriteTextField);
        computacion.SetInt("_PositionTileNumberYWriteTextField_size22", _PositionTileYWriteTextField);

        computacion.Dispatch(_kernelforPrintTilesNumberIndividualWriteTextField_size22, 34, 1,1);

    }




    public static void paintNumberFromTextureIndividual_size22(ref ComputeShader computacion, int _kernelforPrintTilesNumberIndividual_size22, int Xaxis, int Yaxis, int Xtile, int Ytile)
    {

        int _PositionScreenX = Xaxis;
        int _PositionScreenY = Yaxis;
        
        int _PositionTileX = Xtile;        
        int _PositionTileY = Ytile;                
        

        computacion.SetInt("_PositionScreenNumberX_size22", _PositionScreenX);
        computacion.SetInt("_PositionScreenNumberY_size22", _PositionScreenY);

        computacion.SetInt("_PositionTileNumberX_size22", _PositionTileX);
        computacion.SetInt("_PositionTileNumberY_size22", _PositionTileY);

        computacion.Dispatch(_kernelforPrintTilesNumberIndividual_size22, 34, 1,1);

    }





    public static void loadBufferTexturePortuguese_size22(ref ComputeBuffer bufferTexturePortugueseColor_size22)
    {

        string fileTexturePortuguese = "TransparentTextureOfPortuguese-size22Color";
        
        float[] arrayTexturePortugueseColor = new float[64736];
        //positions[1692800];

        uint numOfImagePixel = 16184;
        
        readDataColorTextureCharacters(fileTexturePortuguese, ref arrayTexturePortugueseColor, numOfImagePixel);

        bufferTexturePortugueseColor_size22.SetData(arrayTexturePortugueseColor);

    }





    public static void paintPortugueseFromTextureIndividualWriteTextField_size22(ref ComputeShader computacion, int _kernelforPrintTilesPortugueseIndividualWriteTextField_size22, int Xaxis, int Yaxis, int Xtile, int Ytile)
    {

        int _PositionScreenXWriteTextField = Xaxis;        
        int _PositionScreenYWriteTextField = Yaxis;
        
        int _PositionTileXWriteTextField = Xtile;        
        int _PositionTileYWriteTextField = Ytile;                
        

        computacion.SetInt("_PositionScreenPortugueseXWriteTextField_size22", _PositionScreenXWriteTextField);
        computacion.SetInt("_PositionScreenPortugueseYWriteTextField_size22", _PositionScreenYWriteTextField);

        computacion.SetInt("_PositionTilePortugueseXWriteTextField_size22", _PositionTileXWriteTextField);
        computacion.SetInt("_PositionTilePortugueseYWriteTextField_size22", _PositionTileYWriteTextField);

        computacion.Dispatch(_kernelforPrintTilesPortugueseIndividualWriteTextField_size22, 34, 1,1);

    }


    public static void paintPortugueseFromTextureIndividual_size22(ref ComputeShader computacion, int _kernelforPrintTilesPortugueseIndividual_size22, int Xaxis, int Yaxis, int Xtile, int Ytile)
    {

        int _PositionScreenX = Xaxis;        
        int _PositionScreenY = Yaxis;
        
        int _PositionTileX = Xtile;        
        int _PositionTileY = Ytile;                
        

        computacion.SetInt("_PositionScreenPortugueseX_size22", _PositionScreenX);
        computacion.SetInt("_PositionScreenPortugueseY_size22", _PositionScreenY);

        computacion.SetInt("_PositionTilePortugueseX_size22", _PositionTileX);
        computacion.SetInt("_PositionTilePortugueseY_size22", _PositionTileY);

        computacion.Dispatch(_kernelforPrintTilesPortugueseIndividual_size22, 34, 1,1);

    }







    public static void paintWordPositionWriteTextField_size22(ref ComputeShader computacion, int _kernelforPrintTilesAlphabetIndividualWriteTextField_size22, int _kernelforPrintTilesNumberIndividualWriteTextField_size22, int _kernelforPrintTilesPortugueseIndividualWriteTextField_size22, int Xaxis, int Yaxis, string manageString)
    {

        // System.Random random = new System.Random();
        // int _PositionTranslateX = 965; 
        // int _PositionTranslateY = 20;



        int _PositionTranslateX = Xaxis; 
        int _PositionTranslateY = Yaxis;


        string inputString = manageString;


        for(int i = 0; i < inputString.Length; ++i) 
        {

            string characterToPaint = inputString[i].ToString();

            if(characterToPaint == "A")
            {
                paintAlphabetFromTextureIndividualWriteTextField_size22(ref computacion, _kernelforPrintTilesAlphabetIndividualWriteTextField_size22, _PositionTranslateX, _PositionTranslateY, 0, 0);
                _PositionTranslateX -= CHARACTERWIDTH_size22;
            }

            if(characterToPaint == "B")
            {
                paintAlphabetFromTextureIndividualWriteTextField_size22(ref computacion, _kernelforPrintTilesAlphabetIndividualWriteTextField_size22, _PositionTranslateX, _PositionTranslateY, 1, 0);
                _PositionTranslateX -= CHARACTERWIDTH_size22;
            }

            if(characterToPaint == "C")
            {
                paintAlphabetFromTextureIndividualWriteTextField_size22(ref computacion, _kernelforPrintTilesAlphabetIndividualWriteTextField_size22, _PositionTranslateX, _PositionTranslateY, 2, 0);
                _PositionTranslateX -= CHARACTERWIDTH_size22;
            }

            if(characterToPaint == "D")
            {
                paintAlphabetFromTextureIndividualWriteTextField_size22(ref computacion, _kernelforPrintTilesAlphabetIndividualWriteTextField_size22, _PositionTranslateX, _PositionTranslateY, 3, 0);
                _PositionTranslateX -= CHARACTERWIDTH_size22;
            }

            if(characterToPaint == "E")
            {
                paintAlphabetFromTextureIndividualWriteTextField_size22(ref computacion, _kernelforPrintTilesAlphabetIndividualWriteTextField_size22, _PositionTranslateX, _PositionTranslateY, 0, 1);
                _PositionTranslateX -= CHARACTERWIDTH_size22;
            }

            if(characterToPaint == "F")
            {
                paintAlphabetFromTextureIndividualWriteTextField_size22(ref computacion, _kernelforPrintTilesAlphabetIndividualWriteTextField_size22, _PositionTranslateX, _PositionTranslateY, 1, 1);
                _PositionTranslateX -= CHARACTERWIDTH_size22;
            }

            if(characterToPaint == "G")
            {
                paintAlphabetFromTextureIndividualWriteTextField_size22(ref computacion, _kernelforPrintTilesAlphabetIndividualWriteTextField_size22, _PositionTranslateX, _PositionTranslateY, 2, 1);
                _PositionTranslateX -= CHARACTERWIDTH_size22;
            }

            if(characterToPaint == "H")
            {
                paintAlphabetFromTextureIndividualWriteTextField_size22(ref computacion, _kernelforPrintTilesAlphabetIndividualWriteTextField_size22, _PositionTranslateX, _PositionTranslateY, 3, 1);
                _PositionTranslateX -= CHARACTERWIDTH_size22;
            }

            if(characterToPaint == "I")
            {
                paintAlphabetFromTextureIndividualWriteTextField_size22(ref computacion, _kernelforPrintTilesAlphabetIndividualWriteTextField_size22, _PositionTranslateX, _PositionTranslateY, 0, 2);
                _PositionTranslateX -= CHARACTERWIDTH_size22;
            }

            if(characterToPaint == "J")
            {
                paintAlphabetFromTextureIndividualWriteTextField_size22(ref computacion, _kernelforPrintTilesAlphabetIndividualWriteTextField_size22, _PositionTranslateX, _PositionTranslateY, 1, 2);
                _PositionTranslateX -= CHARACTERWIDTH_size22;
            }

            if(characterToPaint == "K")
            {
                paintAlphabetFromTextureIndividualWriteTextField_size22(ref computacion, _kernelforPrintTilesAlphabetIndividualWriteTextField_size22, _PositionTranslateX, _PositionTranslateY, 2, 2);
                _PositionTranslateX -= CHARACTERWIDTH_size22;
            }

            if(characterToPaint == "L")
            {
                paintAlphabetFromTextureIndividualWriteTextField_size22(ref computacion, _kernelforPrintTilesAlphabetIndividualWriteTextField_size22, _PositionTranslateX, _PositionTranslateY, 3, 2);
                _PositionTranslateX -= CHARACTERWIDTH_size22;
            }

            if(characterToPaint == "M")
            {
                paintAlphabetFromTextureIndividualWriteTextField_size22(ref computacion, _kernelforPrintTilesAlphabetIndividualWriteTextField_size22, _PositionTranslateX, _PositionTranslateY, 0, 3);
                _PositionTranslateX -= CHARACTERWIDTH_size22;
            }

            if(characterToPaint == "N")
            {
                paintAlphabetFromTextureIndividualWriteTextField_size22(ref computacion, _kernelforPrintTilesAlphabetIndividualWriteTextField_size22, _PositionTranslateX, _PositionTranslateY, 1, 3);
                _PositionTranslateX -= CHARACTERWIDTH_size22;
            }

            if(characterToPaint == "O")
            {
                paintAlphabetFromTextureIndividualWriteTextField_size22(ref computacion, _kernelforPrintTilesAlphabetIndividualWriteTextField_size22, _PositionTranslateX, _PositionTranslateY, 2, 3);
                _PositionTranslateX -= CHARACTERWIDTH_size22;
            }

            if(characterToPaint == "P")
            {
                paintAlphabetFromTextureIndividualWriteTextField_size22(ref computacion, _kernelforPrintTilesAlphabetIndividualWriteTextField_size22, _PositionTranslateX, _PositionTranslateY, 3, 3);
                _PositionTranslateX -= CHARACTERWIDTH_size22;
            }

            if(characterToPaint == "Q")
            {
                paintAlphabetFromTextureIndividualWriteTextField_size22(ref computacion, _kernelforPrintTilesAlphabetIndividualWriteTextField_size22, _PositionTranslateX, _PositionTranslateY, 0, 4);
                _PositionTranslateX -= CHARACTERWIDTH_size22;
            }

            if(characterToPaint == "R")
            {
                paintAlphabetFromTextureIndividualWriteTextField_size22(ref computacion, _kernelforPrintTilesAlphabetIndividualWriteTextField_size22, _PositionTranslateX, _PositionTranslateY, 1, 4);
                _PositionTranslateX -= CHARACTERWIDTH_size22;
            }

            if(characterToPaint == "S")
            {
                paintAlphabetFromTextureIndividualWriteTextField_size22(ref computacion, _kernelforPrintTilesAlphabetIndividualWriteTextField_size22, _PositionTranslateX, _PositionTranslateY, 2, 4);
                _PositionTranslateX -= CHARACTERWIDTH_size22;
            }

            if(characterToPaint == "T")
            {
                paintAlphabetFromTextureIndividualWriteTextField_size22(ref computacion, _kernelforPrintTilesAlphabetIndividualWriteTextField_size22, _PositionTranslateX, _PositionTranslateY, 3, 4);
                _PositionTranslateX -= CHARACTERWIDTH_size22;
            }

            if(characterToPaint == "U")
            {
                paintAlphabetFromTextureIndividualWriteTextField_size22(ref computacion, _kernelforPrintTilesAlphabetIndividualWriteTextField_size22, _PositionTranslateX, _PositionTranslateY, 0, 5);
                _PositionTranslateX -= CHARACTERWIDTH_size22;
            }

            if(characterToPaint == "V")
            {
                paintAlphabetFromTextureIndividualWriteTextField_size22(ref computacion, _kernelforPrintTilesAlphabetIndividualWriteTextField_size22, _PositionTranslateX, _PositionTranslateY, 1, 5);
                _PositionTranslateX -= CHARACTERWIDTH_size22;
            }

            if(characterToPaint == "W")
            {
                paintAlphabetFromTextureIndividualWriteTextField_size22(ref computacion, _kernelforPrintTilesAlphabetIndividualWriteTextField_size22, _PositionTranslateX, _PositionTranslateY, 2, 5);
                _PositionTranslateX -= CHARACTERWIDTH_size22;
            }

            if(characterToPaint == "X")
            {
                paintAlphabetFromTextureIndividualWriteTextField_size22(ref computacion, _kernelforPrintTilesAlphabetIndividualWriteTextField_size22, _PositionTranslateX, _PositionTranslateY, 3, 5);
                _PositionTranslateX -= CHARACTERWIDTH_size22;
            }

            if(characterToPaint == "Y")
            {
                paintAlphabetFromTextureIndividualWriteTextField_size22(ref computacion, _kernelforPrintTilesAlphabetIndividualWriteTextField_size22, _PositionTranslateX, _PositionTranslateY, 0, 6);
                _PositionTranslateX -= CHARACTERWIDTH_size22;
            }

            if(characterToPaint == "Z")
            {
                paintAlphabetFromTextureIndividualWriteTextField_size22(ref computacion, _kernelforPrintTilesAlphabetIndividualWriteTextField_size22, _PositionTranslateX, _PositionTranslateY, 1, 6);
                _PositionTranslateX -= CHARACTERWIDTH_size22;
            }

            if(characterToPaint == " ")
            {
                paintAlphabetFromTextureIndividualWriteTextField_size22(ref computacion, _kernelforPrintTilesAlphabetIndividualWriteTextField_size22, _PositionTranslateX, _PositionTranslateY, 2, 6);
                _PositionTranslateX -= CHARACTERWIDTH_size22;
            }

            /////////////////////////////////////////////////////////////////////////////////////////
            // Texture of numbers and italian
            /////////////////////////////////////////////////////////////////////////////////////////


            if(MethodExtend.keyboardLanguage == 0)
            {

    
                if(characterToPaint == "0")
                {
                    paintNumberFromTextureIndividualWriteTextField_size22(ref computacion, _kernelforPrintTilesNumberIndividualWriteTextField_size22, _PositionTranslateX, _PositionTranslateY, 0, 0);
                    _PositionTranslateX -= CHARACTERWIDTH_size22;
                }
    
                if(characterToPaint == "1")
                {
                    paintNumberFromTextureIndividualWriteTextField_size22(ref computacion, _kernelforPrintTilesNumberIndividualWriteTextField_size22, _PositionTranslateX, _PositionTranslateY, 1, 0);
                    _PositionTranslateX -= CHARACTERWIDTH_size22;
                }
    
                if(characterToPaint == "2")
                {
                    paintNumberFromTextureIndividualWriteTextField_size22(ref computacion, _kernelforPrintTilesNumberIndividualWriteTextField_size22, _PositionTranslateX, _PositionTranslateY, 2, 0);
                    _PositionTranslateX -= CHARACTERWIDTH_size22;
                }
    
                if(characterToPaint == "3")
                {
                    paintNumberFromTextureIndividualWriteTextField_size22(ref computacion, _kernelforPrintTilesNumberIndividualWriteTextField_size22, _PositionTranslateX, _PositionTranslateY, 3, 0);
                    _PositionTranslateX -= CHARACTERWIDTH_size22;
                }
    
                if(characterToPaint == "4")
                {
                    paintNumberFromTextureIndividualWriteTextField_size22(ref computacion, _kernelforPrintTilesNumberIndividualWriteTextField_size22, _PositionTranslateX, _PositionTranslateY, 0, 1);
                    _PositionTranslateX -= CHARACTERWIDTH_size22;
                }
    
                if(characterToPaint == "5")
                {
                    paintNumberFromTextureIndividualWriteTextField_size22(ref computacion, _kernelforPrintTilesNumberIndividualWriteTextField_size22, _PositionTranslateX, _PositionTranslateY, 1, 1);
                    _PositionTranslateX -= CHARACTERWIDTH_size22;
                }
    
                if(characterToPaint == "6")
                {
                    paintNumberFromTextureIndividualWriteTextField_size22(ref computacion, _kernelforPrintTilesNumberIndividualWriteTextField_size22, _PositionTranslateX, _PositionTranslateY, 2, 1);
                    _PositionTranslateX -= CHARACTERWIDTH_size22;
                }
    
                if(characterToPaint == "7")
                {
                    paintNumberFromTextureIndividualWriteTextField_size22(ref computacion, _kernelforPrintTilesNumberIndividualWriteTextField_size22, _PositionTranslateX, _PositionTranslateY, 3, 1);
                    _PositionTranslateX -= CHARACTERWIDTH_size22;
                }
    
                if(characterToPaint == "8")
                {
                    paintNumberFromTextureIndividualWriteTextField_size22(ref computacion, _kernelforPrintTilesNumberIndividualWriteTextField_size22, _PositionTranslateX, _PositionTranslateY, 0, 2);
                    _PositionTranslateX -= CHARACTERWIDTH_size22;
                }
    
                if(characterToPaint == "9")
                {
                    paintNumberFromTextureIndividualWriteTextField_size22(ref computacion, _kernelforPrintTilesNumberIndividualWriteTextField_size22, _PositionTranslateX, _PositionTranslateY, 1, 2);
                    _PositionTranslateX -= CHARACTERWIDTH_size22;
                }
    
                if(characterToPaint == "À")
                {
                    paintNumberFromTextureIndividualWriteTextField_size22(ref computacion, _kernelforPrintTilesNumberIndividualWriteTextField_size22, _PositionTranslateX, _PositionTranslateY, 2, 2);
                    _PositionTranslateX -= CHARACTERWIDTH_size22;
                }
    
                if(characterToPaint == "È")
                {
                    paintNumberFromTextureIndividualWriteTextField_size22(ref computacion, _kernelforPrintTilesNumberIndividualWriteTextField_size22, _PositionTranslateX, _PositionTranslateY, 3, 2);
                    _PositionTranslateX -= CHARACTERWIDTH_size22;
                }
    
                if(characterToPaint == "É")
                {
                    paintNumberFromTextureIndividualWriteTextField_size22(ref computacion, _kernelforPrintTilesNumberIndividualWriteTextField_size22, _PositionTranslateX, _PositionTranslateY, 0, 3);
                    _PositionTranslateX -= CHARACTERWIDTH_size22;
                }
    
                if(characterToPaint == "Ì")
                {
                    paintNumberFromTextureIndividualWriteTextField_size22(ref computacion, _kernelforPrintTilesNumberIndividualWriteTextField_size22, _PositionTranslateX, _PositionTranslateY, 1, 3);
                    _PositionTranslateX -= CHARACTERWIDTH_size22;
                }
    
                if(characterToPaint == "Ò")
                {
                    paintNumberFromTextureIndividualWriteTextField_size22(ref computacion, _kernelforPrintTilesNumberIndividualWriteTextField_size22, _PositionTranslateX, _PositionTranslateY, 2, 3);
                    _PositionTranslateX -= CHARACTERWIDTH_size22;
                }
    
                if(characterToPaint == "Ù")
                {
                    paintNumberFromTextureIndividualWriteTextField_size22(ref computacion, _kernelforPrintTilesNumberIndividualWriteTextField_size22, _PositionTranslateX, _PositionTranslateY, 3, 3);
                    _PositionTranslateX -= CHARACTERWIDTH_size22;
                }
    
                if(characterToPaint == "’")
                {
                    paintNumberFromTextureIndividualWriteTextField_size22(ref computacion, _kernelforPrintTilesNumberIndividualWriteTextField_size22, _PositionTranslateX, _PositionTranslateY, 0, 4);
                    _PositionTranslateX -= CHARACTERWIDTH_size22;
                }

                if(characterToPaint == "‘")
                {
                    paintNumberFromTextureIndividualWriteTextField_size22(ref computacion, _kernelforPrintTilesNumberIndividualWriteTextField_size22, _PositionTranslateX, _PositionTranslateY, 1, 4);
                    _PositionTranslateX -= CHARACTERWIDTH_size22;
                }

                if(characterToPaint == "?")
                {
                    paintNumberFromTextureIndividualWriteTextField_size22(ref computacion, _kernelforPrintTilesNumberIndividualWriteTextField_size22, _PositionTranslateX, _PositionTranslateY, 2, 4);
                    _PositionTranslateX -= CHARACTERWIDTH_size22;
                }

                if(characterToPaint == "!")
                {
                    paintNumberFromTextureIndividualWriteTextField_size22(ref computacion, _kernelforPrintTilesNumberIndividualWriteTextField_size22, _PositionTranslateX, _PositionTranslateY, 3, 4);
                    _PositionTranslateX -= CHARACTERWIDTH_size22;
                }

                if(characterToPaint == ",")
                {
                    paintNumberFromTextureIndividualWriteTextField_size22(ref computacion, _kernelforPrintTilesNumberIndividualWriteTextField_size22, _PositionTranslateX, _PositionTranslateY, 0, 5);
                    _PositionTranslateX -= CHARACTERWIDTH_size22;
                }

                if(characterToPaint == ".")
                {
                    paintNumberFromTextureIndividualWriteTextField_size22(ref computacion, _kernelforPrintTilesNumberIndividualWriteTextField_size22, _PositionTranslateX, _PositionTranslateY, 1, 5);
                    _PositionTranslateX -= CHARACTERWIDTH_size22;
                }

                if(characterToPaint == ":")
                {
                    paintNumberFromTextureIndividualWriteTextField_size22(ref computacion, _kernelforPrintTilesNumberIndividualWriteTextField_size22, _PositionTranslateX, _PositionTranslateY, 2, 5);
                    _PositionTranslateX -= CHARACTERWIDTH_size22;
                }

                if(characterToPaint == ";")
                {
                    paintNumberFromTextureIndividualWriteTextField_size22(ref computacion, _kernelforPrintTilesNumberIndividualWriteTextField_size22, _PositionTranslateX, _PositionTranslateY, 3, 5);
                    _PositionTranslateX -= CHARACTERWIDTH_size22;
                }

            }

            if(MethodExtend.keyboardLanguage == 1)
            {

                if(characterToPaint == "Á")
                {
                    paintPortugueseFromTextureIndividualWriteTextField_size22(ref computacion, _kernelforPrintTilesPortugueseIndividualWriteTextField_size22, _PositionTranslateX, _PositionTranslateY, 0, 0);
                    _PositionTranslateX -= CHARACTERWIDTH_size22;
                }
            
                if(characterToPaint == "À")
                {
                    paintPortugueseFromTextureIndividualWriteTextField_size22(ref computacion, _kernelforPrintTilesPortugueseIndividualWriteTextField_size22, _PositionTranslateX, _PositionTranslateY, 1, 0);
                    _PositionTranslateX -= CHARACTERWIDTH_size22;
                }
            
                if(characterToPaint == "Â")
                {
                    paintPortugueseFromTextureIndividualWriteTextField_size22(ref computacion, _kernelforPrintTilesPortugueseIndividualWriteTextField_size22, _PositionTranslateX, _PositionTranslateY, 2, 0);
                    _PositionTranslateX -= CHARACTERWIDTH_size22;
                }

                if(characterToPaint == "Ã")
                {
                    paintPortugueseFromTextureIndividualWriteTextField_size22(ref computacion, _kernelforPrintTilesPortugueseIndividualWriteTextField_size22, _PositionTranslateX, _PositionTranslateY, 0, 1);
                    _PositionTranslateX -= CHARACTERWIDTH_size22;
                }
            
                if(characterToPaint == "Ä")
                {
                    paintPortugueseFromTextureIndividualWriteTextField_size22(ref computacion, _kernelforPrintTilesPortugueseIndividualWriteTextField_size22, _PositionTranslateX, _PositionTranslateY, 3, 0);
                    _PositionTranslateX -= CHARACTERWIDTH_size22;
                }
            
                if(characterToPaint == "Ç")
                {
                    paintPortugueseFromTextureIndividualWriteTextField_size22(ref computacion, _kernelforPrintTilesPortugueseIndividualWriteTextField_size22, _PositionTranslateX, _PositionTranslateY, 1, 1);
                    _PositionTranslateX -= CHARACTERWIDTH_size22;
                }
    
                if(characterToPaint == "É")
                {
                    paintPortugueseFromTextureIndividualWriteTextField_size22(ref computacion, _kernelforPrintTilesPortugueseIndividualWriteTextField_size22, _PositionTranslateX, _PositionTranslateY, 2, 1);
                    _PositionTranslateX -= CHARACTERWIDTH_size22;
                }
            
                if(characterToPaint == "È")
                {
                    paintPortugueseFromTextureIndividualWriteTextField_size22(ref computacion, _kernelforPrintTilesPortugueseIndividualWriteTextField_size22, _PositionTranslateX, _PositionTranslateY, 3, 1);
                    _PositionTranslateX -= CHARACTERWIDTH_size22;
                }
            
                if(characterToPaint == "Ê")
                {
                    paintPortugueseFromTextureIndividualWriteTextField_size22(ref computacion, _kernelforPrintTilesPortugueseIndividualWriteTextField_size22, _PositionTranslateX, _PositionTranslateY, 0, 2);
                    _PositionTranslateX -= CHARACTERWIDTH_size22;
                }

                if(characterToPaint == "Ë")
                {
                    paintPortugueseFromTextureIndividualWriteTextField_size22(ref computacion, _kernelforPrintTilesPortugueseIndividualWriteTextField_size22, _PositionTranslateX, _PositionTranslateY, 1, 2);
                    _PositionTranslateX -= CHARACTERWIDTH_size22;
                }    

                if(characterToPaint == "Í")
                {
                    paintPortugueseFromTextureIndividualWriteTextField_size22(ref computacion, _kernelforPrintTilesPortugueseIndividualWriteTextField_size22, _PositionTranslateX, _PositionTranslateY, 2, 2);
                    _PositionTranslateX -= CHARACTERWIDTH_size22;
                }
            
                if(characterToPaint == "Ì")
                {
                    paintPortugueseFromTextureIndividualWriteTextField_size22(ref computacion, _kernelforPrintTilesPortugueseIndividualWriteTextField_size22, _PositionTranslateX, _PositionTranslateY, 3, 2);
                    _PositionTranslateX -= CHARACTERWIDTH_size22;
                }
            
                if(characterToPaint == "Î")
                {
                    paintPortugueseFromTextureIndividualWriteTextField_size22(ref computacion, _kernelforPrintTilesPortugueseIndividualWriteTextField_size22, _PositionTranslateX, _PositionTranslateY, 0, 3);
                    _PositionTranslateX -= CHARACTERWIDTH_size22;
                }

                if(characterToPaint == "Ï")
                {
                    paintPortugueseFromTextureIndividualWriteTextField_size22(ref computacion, _kernelforPrintTilesPortugueseIndividualWriteTextField_size22, _PositionTranslateX, _PositionTranslateY, 1, 3);
                    _PositionTranslateX -= CHARACTERWIDTH_size22;
                }    

                if(characterToPaint == "Ó")
                {
                    paintPortugueseFromTextureIndividualWriteTextField_size22(ref computacion, _kernelforPrintTilesPortugueseIndividualWriteTextField_size22, _PositionTranslateX, _PositionTranslateY, 2, 3);
                    _PositionTranslateX -= CHARACTERWIDTH_size22;
                }
            
                if(characterToPaint == "Ò")
                {
                    paintPortugueseFromTextureIndividualWriteTextField_size22(ref computacion, _kernelforPrintTilesPortugueseIndividualWriteTextField_size22, _PositionTranslateX, _PositionTranslateY, 3, 3);
                    _PositionTranslateX -= CHARACTERWIDTH_size22;
                }
        
                if(characterToPaint == "Õ")
                {
                    paintPortugueseFromTextureIndividualWriteTextField_size22(ref computacion, _kernelforPrintTilesPortugueseIndividualWriteTextField_size22, _PositionTranslateX, _PositionTranslateY, 2, 4);
                    _PositionTranslateX -= CHARACTERWIDTH_size22;
                }

                if(characterToPaint == "Ô")
                {
                    paintPortugueseFromTextureIndividualWriteTextField_size22(ref computacion, _kernelforPrintTilesPortugueseIndividualWriteTextField_size22, _PositionTranslateX, _PositionTranslateY, 0, 4);
                    _PositionTranslateX -= CHARACTERWIDTH_size22;
                }    

                if(characterToPaint == "Ö")
                {
                    paintPortugueseFromTextureIndividualWriteTextField_size22(ref computacion, _kernelforPrintTilesPortugueseIndividualWriteTextField_size22, _PositionTranslateX, _PositionTranslateY, 1, 4);
                    _PositionTranslateX -= CHARACTERWIDTH_size22;
                }    

                if(characterToPaint == "Ú")
                {
                    paintPortugueseFromTextureIndividualWriteTextField_size22(ref computacion, _kernelforPrintTilesPortugueseIndividualWriteTextField_size22, _PositionTranslateX, _PositionTranslateY, 1, 4);
                    _PositionTranslateX -= CHARACTERWIDTH_size22;
                }
            
                if(characterToPaint == "Ù")
                {
                    paintPortugueseFromTextureIndividualWriteTextField_size22(ref computacion, _kernelforPrintTilesPortugueseIndividualWriteTextField_size22, _PositionTranslateX, _PositionTranslateY, 0, 5);
                    _PositionTranslateX -= CHARACTERWIDTH_size22;
                }
            
                if(characterToPaint == "Û")
                {
                    paintPortugueseFromTextureIndividualWriteTextField_size22(ref computacion, _kernelforPrintTilesPortugueseIndividualWriteTextField_size22, _PositionTranslateX, _PositionTranslateY, 1, 5);
                    _PositionTranslateX -= CHARACTERWIDTH_size22;
                }

                if(characterToPaint == "Ü")
                {
                    paintPortugueseFromTextureIndividualWriteTextField_size22(ref computacion, _kernelforPrintTilesPortugueseIndividualWriteTextField_size22, _PositionTranslateX, _PositionTranslateY, 2, 5);
                    _PositionTranslateX -= CHARACTERWIDTH_size22;
                }    

            }

        }

    }    



    public static void paintWordPosition_size22(ref ComputeShader computacion, int _kernelforPrintTilesAlphabetIndividual_size22, int _kernelforPrintTilesNumberIndividual_size22, int _kernelforPrintTilesPortugueseIndividual_size22, int Xaxis, int Yaxis, string manageString)
    {

        // System.Random random = new System.Random();
        // int _PositionTranslateX = 965; 
        // int _PositionTranslateY = 20;



        int _PositionTranslateX = Xaxis; 
        int _PositionTranslateY = Yaxis;


        string inputString = manageString;


        for(int i = 0; i < inputString.Length; ++i) 
        {

            string characterToPaint = inputString[i].ToString();

            if(characterToPaint == "A")
            {
                paintAlphabetFromTextureIndividual_size22(ref computacion, _kernelforPrintTilesAlphabetIndividual_size22, _PositionTranslateX, _PositionTranslateY, 0, 0);
                _PositionTranslateX -= CHARACTERWIDTH_size22;
            }

            if(characterToPaint == "B")
            {
                paintAlphabetFromTextureIndividual_size22(ref computacion, _kernelforPrintTilesAlphabetIndividual_size22, _PositionTranslateX, _PositionTranslateY, 1, 0);
                _PositionTranslateX -= CHARACTERWIDTH_size22;
            }

            if(characterToPaint == "C")
            {
                paintAlphabetFromTextureIndividual_size22(ref computacion, _kernelforPrintTilesAlphabetIndividual_size22, _PositionTranslateX, _PositionTranslateY, 2, 0);
                _PositionTranslateX -= CHARACTERWIDTH_size22;
            }

            if(characterToPaint == "D")
            {
                paintAlphabetFromTextureIndividual_size22(ref computacion, _kernelforPrintTilesAlphabetIndividual_size22, _PositionTranslateX, _PositionTranslateY, 3, 0);
                _PositionTranslateX -= CHARACTERWIDTH_size22;
            }

            if(characterToPaint == "E")
            {
                paintAlphabetFromTextureIndividual_size22(ref computacion, _kernelforPrintTilesAlphabetIndividual_size22, _PositionTranslateX, _PositionTranslateY, 0, 1);
                _PositionTranslateX -= CHARACTERWIDTH_size22;
            }

            if(characterToPaint == "F")
            {
                paintAlphabetFromTextureIndividual_size22(ref computacion, _kernelforPrintTilesAlphabetIndividual_size22, _PositionTranslateX, _PositionTranslateY, 1, 1);
                _PositionTranslateX -= CHARACTERWIDTH_size22;
            }

            if(characterToPaint == "G")
            {
                paintAlphabetFromTextureIndividual_size22(ref computacion, _kernelforPrintTilesAlphabetIndividual_size22, _PositionTranslateX, _PositionTranslateY, 2, 1);
                _PositionTranslateX -= CHARACTERWIDTH_size22;
            }

            if(characterToPaint == "H")
            {
                paintAlphabetFromTextureIndividual_size22(ref computacion, _kernelforPrintTilesAlphabetIndividual_size22, _PositionTranslateX, _PositionTranslateY, 3, 1);
                _PositionTranslateX -= CHARACTERWIDTH_size22;
            }

            if(characterToPaint == "I")
            {
                paintAlphabetFromTextureIndividual_size22(ref computacion, _kernelforPrintTilesAlphabetIndividual_size22, _PositionTranslateX, _PositionTranslateY, 0, 2);
                _PositionTranslateX -= CHARACTERWIDTH_size22;
            }

            if(characterToPaint == "J")
            {
                paintAlphabetFromTextureIndividual_size22(ref computacion, _kernelforPrintTilesAlphabetIndividual_size22, _PositionTranslateX, _PositionTranslateY, 1, 2);
                _PositionTranslateX -= CHARACTERWIDTH_size22;
            }

            if(characterToPaint == "K")
            {
                paintAlphabetFromTextureIndividual_size22(ref computacion, _kernelforPrintTilesAlphabetIndividual_size22, _PositionTranslateX, _PositionTranslateY, 2, 2);
                _PositionTranslateX -= CHARACTERWIDTH_size22;
            }

            if(characterToPaint == "L")
            {
                paintAlphabetFromTextureIndividual_size22(ref computacion, _kernelforPrintTilesAlphabetIndividual_size22, _PositionTranslateX, _PositionTranslateY, 3, 2);
                _PositionTranslateX -= CHARACTERWIDTH_size22;
            }

            if(characterToPaint == "M")
            {
                paintAlphabetFromTextureIndividual_size22(ref computacion, _kernelforPrintTilesAlphabetIndividual_size22, _PositionTranslateX, _PositionTranslateY, 0, 3);
                _PositionTranslateX -= CHARACTERWIDTH_size22;
            }

            if(characterToPaint == "N")
            {
                paintAlphabetFromTextureIndividual_size22(ref computacion, _kernelforPrintTilesAlphabetIndividual_size22, _PositionTranslateX, _PositionTranslateY, 1, 3);
                _PositionTranslateX -= CHARACTERWIDTH_size22;
            }

            if(characterToPaint == "O")
            {
                paintAlphabetFromTextureIndividual_size22(ref computacion, _kernelforPrintTilesAlphabetIndividual_size22, _PositionTranslateX, _PositionTranslateY, 2, 3);
                _PositionTranslateX -= CHARACTERWIDTH_size22;
            }

            if(characterToPaint == "P")
            {
                paintAlphabetFromTextureIndividual_size22(ref computacion, _kernelforPrintTilesAlphabetIndividual_size22, _PositionTranslateX, _PositionTranslateY, 3, 3);
                _PositionTranslateX -= CHARACTERWIDTH_size22;
            }

            if(characterToPaint == "Q")
            {
                paintAlphabetFromTextureIndividual_size22(ref computacion, _kernelforPrintTilesAlphabetIndividual_size22, _PositionTranslateX, _PositionTranslateY, 0, 4);
                _PositionTranslateX -= CHARACTERWIDTH_size22;
            }

            if(characterToPaint == "R")
            {
                paintAlphabetFromTextureIndividual_size22(ref computacion, _kernelforPrintTilesAlphabetIndividual_size22, _PositionTranslateX, _PositionTranslateY, 1, 4);
                _PositionTranslateX -= CHARACTERWIDTH_size22;
            }

            if(characterToPaint == "S")
            {
                paintAlphabetFromTextureIndividual_size22(ref computacion, _kernelforPrintTilesAlphabetIndividual_size22, _PositionTranslateX, _PositionTranslateY, 2, 4);
                _PositionTranslateX -= CHARACTERWIDTH_size22;
            }

            if(characterToPaint == "T")
            {
                paintAlphabetFromTextureIndividual_size22(ref computacion, _kernelforPrintTilesAlphabetIndividual_size22, _PositionTranslateX, _PositionTranslateY, 3, 4);
                _PositionTranslateX -= CHARACTERWIDTH_size22;
            }

            if(characterToPaint == "U")
            {
                paintAlphabetFromTextureIndividual_size22(ref computacion, _kernelforPrintTilesAlphabetIndividual_size22, _PositionTranslateX, _PositionTranslateY, 0, 5);
                _PositionTranslateX -= CHARACTERWIDTH_size22;
            }

            if(characterToPaint == "V")
            {
                paintAlphabetFromTextureIndividual_size22(ref computacion, _kernelforPrintTilesAlphabetIndividual_size22, _PositionTranslateX, _PositionTranslateY, 1, 5);
                _PositionTranslateX -= CHARACTERWIDTH_size22;
            }

            if(characterToPaint == "W")
            {
                paintAlphabetFromTextureIndividual_size22(ref computacion, _kernelforPrintTilesAlphabetIndividual_size22, _PositionTranslateX, _PositionTranslateY, 2, 5);
                _PositionTranslateX -= CHARACTERWIDTH_size22;
            }

            if(characterToPaint == "X")
            {
                paintAlphabetFromTextureIndividual_size22(ref computacion, _kernelforPrintTilesAlphabetIndividual_size22, _PositionTranslateX, _PositionTranslateY, 3, 5);
                _PositionTranslateX -= CHARACTERWIDTH_size22;
            }

            if(characterToPaint == "Y")
            {
                paintAlphabetFromTextureIndividual_size22(ref computacion, _kernelforPrintTilesAlphabetIndividual_size22, _PositionTranslateX, _PositionTranslateY, 0, 6);
                _PositionTranslateX -= CHARACTERWIDTH_size22;
            }

            if(characterToPaint == "Z")
            {
                paintAlphabetFromTextureIndividual_size22(ref computacion, _kernelforPrintTilesAlphabetIndividual_size22, _PositionTranslateX, _PositionTranslateY, 1, 6);
                _PositionTranslateX -= CHARACTERWIDTH_size22;
            }

            if(characterToPaint == " ")
            {
                paintAlphabetFromTextureIndividual_size22(ref computacion, _kernelforPrintTilesAlphabetIndividual_size22, _PositionTranslateX, _PositionTranslateY, 2, 6);
                _PositionTranslateX -= CHARACTERWIDTH_size22;
            }

            /////////////////////////////////////////////////////////////////////////////////////////
            // Texture of numbers and italian
            /////////////////////////////////////////////////////////////////////////////////////////


            if(MethodExtend.keyboardLanguage == 0)
            {

    
                if(characterToPaint == "0")
                {
                    paintNumberFromTextureIndividual_size22(ref computacion, _kernelforPrintTilesNumberIndividual_size22, _PositionTranslateX, _PositionTranslateY, 0, 0);
                    _PositionTranslateX -= CHARACTERWIDTH_size22;
                }
    
                if(characterToPaint == "1")
                {
                    paintNumberFromTextureIndividual_size22(ref computacion, _kernelforPrintTilesNumberIndividual_size22, _PositionTranslateX, _PositionTranslateY, 1, 0);
                    _PositionTranslateX -= CHARACTERWIDTH_size22;
                }
    
                if(characterToPaint == "2")
                {
                    paintNumberFromTextureIndividual_size22(ref computacion, _kernelforPrintTilesNumberIndividual_size22, _PositionTranslateX, _PositionTranslateY, 2, 0);
                    _PositionTranslateX -= CHARACTERWIDTH_size22;
                }
    
                if(characterToPaint == "3")
                {
                    paintNumberFromTextureIndividual_size22(ref computacion, _kernelforPrintTilesNumberIndividual_size22, _PositionTranslateX, _PositionTranslateY, 3, 0);
                    _PositionTranslateX -= CHARACTERWIDTH_size22;
                }
    
                if(characterToPaint == "4")
                {
                    paintNumberFromTextureIndividual_size22(ref computacion, _kernelforPrintTilesNumberIndividual_size22, _PositionTranslateX, _PositionTranslateY, 0, 1);
                    _PositionTranslateX -= CHARACTERWIDTH_size22;
                }
    
                if(characterToPaint == "5")
                {
                    paintNumberFromTextureIndividual_size22(ref computacion, _kernelforPrintTilesNumberIndividual_size22, _PositionTranslateX, _PositionTranslateY, 1, 1);
                    _PositionTranslateX -= CHARACTERWIDTH_size22;
                }
    
                if(characterToPaint == "6")
                {
                    paintNumberFromTextureIndividual_size22(ref computacion, _kernelforPrintTilesNumberIndividual_size22, _PositionTranslateX, _PositionTranslateY, 2, 1);
                    _PositionTranslateX -= CHARACTERWIDTH_size22;
                }
    
                if(characterToPaint == "7")
                {
                    paintNumberFromTextureIndividual_size22(ref computacion, _kernelforPrintTilesNumberIndividual_size22, _PositionTranslateX, _PositionTranslateY, 3, 1);
                    _PositionTranslateX -= CHARACTERWIDTH_size22;
                }
    
                if(characterToPaint == "8")
                {
                    paintNumberFromTextureIndividual_size22(ref computacion, _kernelforPrintTilesNumberIndividual_size22, _PositionTranslateX, _PositionTranslateY, 0, 2);
                    _PositionTranslateX -= CHARACTERWIDTH_size22;
                }
    
                if(characterToPaint == "9")
                {
                    paintNumberFromTextureIndividual_size22(ref computacion, _kernelforPrintTilesNumberIndividual_size22, _PositionTranslateX, _PositionTranslateY, 1, 2);
                    _PositionTranslateX -= CHARACTERWIDTH_size22;
                }
    
                if(characterToPaint == "À")
                {
                    paintNumberFromTextureIndividual_size22(ref computacion, _kernelforPrintTilesNumberIndividual_size22, _PositionTranslateX, _PositionTranslateY, 2, 2);
                    _PositionTranslateX -= CHARACTERWIDTH_size22;
                }
    
                if(characterToPaint == "È")
                {
                    paintNumberFromTextureIndividual_size22(ref computacion, _kernelforPrintTilesNumberIndividual_size22, _PositionTranslateX, _PositionTranslateY, 3, 2);
                    _PositionTranslateX -= CHARACTERWIDTH_size22;
                }
    
                if(characterToPaint == "É")
                {
                    paintNumberFromTextureIndividual_size22(ref computacion, _kernelforPrintTilesNumberIndividual_size22, _PositionTranslateX, _PositionTranslateY, 0, 3);
                    _PositionTranslateX -= CHARACTERWIDTH_size22;
                }
    
                if(characterToPaint == "Ì")
                {
                    paintNumberFromTextureIndividual_size22(ref computacion, _kernelforPrintTilesNumberIndividual_size22, _PositionTranslateX, _PositionTranslateY, 1, 3);
                    _PositionTranslateX -= CHARACTERWIDTH_size22;
                }
    
                if(characterToPaint == "Ò")
                {
                    paintNumberFromTextureIndividual_size22(ref computacion, _kernelforPrintTilesNumberIndividual_size22, _PositionTranslateX, _PositionTranslateY, 2, 3);
                    _PositionTranslateX -= CHARACTERWIDTH_size22;
                }
    
                if(characterToPaint == "Ù")
                {
                    paintNumberFromTextureIndividual_size22(ref computacion, _kernelforPrintTilesNumberIndividual_size22, _PositionTranslateX, _PositionTranslateY, 3, 3);
                    _PositionTranslateX -= CHARACTERWIDTH_size22;
                }
    
                if(characterToPaint == "’")
                {
                    paintNumberFromTextureIndividual_size22(ref computacion, _kernelforPrintTilesNumberIndividual_size22, _PositionTranslateX, _PositionTranslateY, 0, 4);
                    _PositionTranslateX -= CHARACTERWIDTH_size22;
                }

                if(characterToPaint == "‘")
                {
                    paintNumberFromTextureIndividual_size22(ref computacion, _kernelforPrintTilesNumberIndividual_size22, _PositionTranslateX, _PositionTranslateY, 1, 4);
                    _PositionTranslateX -= CHARACTERWIDTH_size22;
                }

                if(characterToPaint == "?")
                {
                    paintNumberFromTextureIndividual_size22(ref computacion, _kernelforPrintTilesNumberIndividual_size22, _PositionTranslateX, _PositionTranslateY, 2, 4);
                    _PositionTranslateX -= CHARACTERWIDTH_size22;
                }

                if(characterToPaint == "!")
                {
                    paintNumberFromTextureIndividual_size22(ref computacion, _kernelforPrintTilesNumberIndividual_size22, _PositionTranslateX, _PositionTranslateY, 3, 4);
                    _PositionTranslateX -= CHARACTERWIDTH_size22;
                }

                if(characterToPaint == ",")
                {
                    paintNumberFromTextureIndividual_size22(ref computacion, _kernelforPrintTilesNumberIndividual_size22, _PositionTranslateX, _PositionTranslateY, 0, 5);
                    _PositionTranslateX -= CHARACTERWIDTH_size22;
                }

                if(characterToPaint == ".")
                {
                    paintNumberFromTextureIndividual_size22(ref computacion, _kernelforPrintTilesNumberIndividual_size22, _PositionTranslateX, _PositionTranslateY, 1, 5);
                    _PositionTranslateX -= CHARACTERWIDTH_size22;
                }

                if(characterToPaint == ":")
                {
                    paintNumberFromTextureIndividual_size22(ref computacion, _kernelforPrintTilesNumberIndividual_size22, _PositionTranslateX, _PositionTranslateY, 2, 5);
                    _PositionTranslateX -= CHARACTERWIDTH_size22;
                }

                if(characterToPaint == ";")
                {
                    paintNumberFromTextureIndividual_size22(ref computacion, _kernelforPrintTilesNumberIndividual_size22, _PositionTranslateX, _PositionTranslateY, 3, 5);
                    _PositionTranslateX -= CHARACTERWIDTH_size22;
                }

            }

            if(MethodExtend.keyboardLanguage == 1)
            {

                if(characterToPaint == "Á")
                {
                    paintPortugueseFromTextureIndividual_size22(ref computacion,_kernelforPrintTilesPortugueseIndividual_size22, _PositionTranslateX, _PositionTranslateY, 0, 0);
                    _PositionTranslateX -= CHARACTERWIDTH_size22;
                }
            
                if(characterToPaint == "À")
                {
                    paintPortugueseFromTextureIndividual_size22(ref computacion,_kernelforPrintTilesPortugueseIndividual_size22, _PositionTranslateX, _PositionTranslateY, 1, 0);
                    _PositionTranslateX -= CHARACTERWIDTH_size22;
                }
            
                if(characterToPaint == "Â")
                {
                    paintPortugueseFromTextureIndividual_size22(ref computacion,_kernelforPrintTilesPortugueseIndividual_size22, _PositionTranslateX, _PositionTranslateY, 2, 0);
                    _PositionTranslateX -= CHARACTERWIDTH_size22;
                }

                if(characterToPaint == "Ã")
                {
                    paintPortugueseFromTextureIndividual_size22(ref computacion,_kernelforPrintTilesPortugueseIndividual_size22, _PositionTranslateX, _PositionTranslateY, 0, 1);
                    _PositionTranslateX -= CHARACTERWIDTH_size22;
                }
            
                if(characterToPaint == "Ä")
                {
                    paintPortugueseFromTextureIndividual_size22(ref computacion,_kernelforPrintTilesPortugueseIndividual_size22, _PositionTranslateX, _PositionTranslateY, 3, 0);
                    _PositionTranslateX -= CHARACTERWIDTH_size22;
                }
            
                if(characterToPaint == "Ç")
                {
                    paintPortugueseFromTextureIndividual_size22(ref computacion,_kernelforPrintTilesPortugueseIndividual_size22, _PositionTranslateX, _PositionTranslateY, 1, 1);
                    _PositionTranslateX -= CHARACTERWIDTH_size22;
                }
    
                if(characterToPaint == "É")
                {
                    paintPortugueseFromTextureIndividual_size22(ref computacion,_kernelforPrintTilesPortugueseIndividual_size22, _PositionTranslateX, _PositionTranslateY, 2, 1);
                    _PositionTranslateX -= CHARACTERWIDTH_size22;
                }
            
                if(characterToPaint == "È")
                {
                    paintPortugueseFromTextureIndividual_size22(ref computacion,_kernelforPrintTilesPortugueseIndividual_size22, _PositionTranslateX, _PositionTranslateY, 3, 1);
                    _PositionTranslateX -= CHARACTERWIDTH_size22;
                }
            
                if(characterToPaint == "Ê")
                {
                    paintPortugueseFromTextureIndividual_size22(ref computacion,_kernelforPrintTilesPortugueseIndividual_size22, _PositionTranslateX, _PositionTranslateY, 0, 2);
                    _PositionTranslateX -= CHARACTERWIDTH_size22;
                }

                if(characterToPaint == "Ë")
                {
                    paintPortugueseFromTextureIndividual_size22(ref computacion,_kernelforPrintTilesPortugueseIndividual_size22, _PositionTranslateX, _PositionTranslateY, 1, 2);
                    _PositionTranslateX -= CHARACTERWIDTH_size22;
                }    

                if(characterToPaint == "Í")
                {
                    paintPortugueseFromTextureIndividual_size22(ref computacion,_kernelforPrintTilesPortugueseIndividual_size22, _PositionTranslateX, _PositionTranslateY, 2, 2);
                    _PositionTranslateX -= CHARACTERWIDTH_size22;
                }
            
                if(characterToPaint == "Ì")
                {
                    paintPortugueseFromTextureIndividual_size22(ref computacion,_kernelforPrintTilesPortugueseIndividual_size22, _PositionTranslateX, _PositionTranslateY, 3, 2);
                    _PositionTranslateX -= CHARACTERWIDTH_size22;
                }
            
                if(characterToPaint == "Î")
                {
                    paintPortugueseFromTextureIndividual_size22(ref computacion,_kernelforPrintTilesPortugueseIndividual_size22, _PositionTranslateX, _PositionTranslateY, 0, 3);
                    _PositionTranslateX -= CHARACTERWIDTH_size22;
                }

                if(characterToPaint == "Ï")
                {
                    paintPortugueseFromTextureIndividual_size22(ref computacion,_kernelforPrintTilesPortugueseIndividual_size22, _PositionTranslateX, _PositionTranslateY, 1, 3);
                    _PositionTranslateX -= CHARACTERWIDTH_size22;
                }    

                if(characterToPaint == "Ó")
                {
                    paintPortugueseFromTextureIndividual_size22(ref computacion,_kernelforPrintTilesPortugueseIndividual_size22, _PositionTranslateX, _PositionTranslateY, 2, 3);
                    _PositionTranslateX -= CHARACTERWIDTH_size22;
                }
            
                if(characterToPaint == "Ò")
                {
                    paintPortugueseFromTextureIndividual_size22(ref computacion,_kernelforPrintTilesPortugueseIndividual_size22, _PositionTranslateX, _PositionTranslateY, 3, 3);
                    _PositionTranslateX -= CHARACTERWIDTH_size22;
                }
        
                if(characterToPaint == "Õ")
                {
                    paintPortugueseFromTextureIndividual_size22(ref computacion,_kernelforPrintTilesPortugueseIndividual_size22, _PositionTranslateX, _PositionTranslateY, 2, 4);
                    _PositionTranslateX -= CHARACTERWIDTH_size22;
                }

                if(characterToPaint == "Ô")
                {
                    paintPortugueseFromTextureIndividual_size22(ref computacion,_kernelforPrintTilesPortugueseIndividual_size22, _PositionTranslateX, _PositionTranslateY, 0, 4);
                    _PositionTranslateX -= CHARACTERWIDTH_size22;
                }    

                if(characterToPaint == "Ö")
                {
                    paintPortugueseFromTextureIndividual_size22(ref computacion,_kernelforPrintTilesPortugueseIndividual_size22, _PositionTranslateX, _PositionTranslateY, 1, 4);
                    _PositionTranslateX -= CHARACTERWIDTH_size22;
                }    

                if(characterToPaint == "Ú")
                {
                    paintPortugueseFromTextureIndividual_size22(ref computacion,_kernelforPrintTilesPortugueseIndividual_size22, _PositionTranslateX, _PositionTranslateY, 1, 4);
                    _PositionTranslateX -= CHARACTERWIDTH_size22;
                }
            
                if(characterToPaint == "Ù")
                {
                    paintPortugueseFromTextureIndividual_size22(ref computacion,_kernelforPrintTilesPortugueseIndividual_size22, _PositionTranslateX, _PositionTranslateY, 0, 5);
                    _PositionTranslateX -= CHARACTERWIDTH_size22;
                }
            
                if(characterToPaint == "Û")
                {
                    paintPortugueseFromTextureIndividual_size22(ref computacion,_kernelforPrintTilesPortugueseIndividual_size22, _PositionTranslateX, _PositionTranslateY, 1, 5);
                    _PositionTranslateX -= CHARACTERWIDTH_size22;
                }

                if(characterToPaint == "Ü")
                {
                    paintPortugueseFromTextureIndividual_size22(ref computacion,_kernelforPrintTilesPortugueseIndividual_size22, _PositionTranslateX, _PositionTranslateY, 2, 5);
                    _PositionTranslateX -= CHARACTERWIDTH_size22;
                }    

            }

        }

    }    













//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
// MEMORY character TEXTURE 22 SIZE
//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////






    public const int constPositionPointerX = 1949;
    public const int constPositionPointerY = 945;

    public static int PositionPointerX = 1949;
    public static int PositionPointerY = 945;

    public static bool activeKeaboard = false;
    public static bool activeMiniGame = false;
    public static bool activateControl = false;

    public static string StringTextField = "";

    public static int _XaxisWord22 = 1900;
    public static int _YaxisWord22 = 500;

    public const int _XaxisTextFieldBegin = 1940;
    public const int _YaxisTextFieldBegin = 935;

    public static int _XaxisTextField = _XaxisTextFieldBegin;
    public static int _YaxisTextField = _YaxisTextFieldBegin;

    public static bool shiftKey = false;
    public static bool afterAppostrophe = false;
    public static int appostrophe = 0;
    



    public static void getKeyBoardInput(ref ComputeShader computacion, ref ComputeBuffer bufferColorPointer, int _kernelforPrintPointerBlack, int _kernelforPrintPointer,
                        
                            int _kernelforPrintTilesPortugueseIndividualWriteTextField, int _kernelforPrintTilesAlphabetIndividualWriteTextField, int _kernelforPrintTilesNumberIndividualWriteTextField, int timeNow)
    {

        //////////////////////////////////////////////////////////////////////////
        // PORTUGUESE CHARACTERS
        //////////////////////////////////////////////////////////////////////////
            
                                  //A Á À Ã Â Ä       
            int[] getAppostrophe = {0,1,2,3,4,5};    

            if(afterAppostrophe == true)
            {
                afterAppostrophe = false;
                appostrophe = 0;
            }        
            
            if( Input.GetKey(KeyCode.RightShift) || Input.GetKey(KeyCode.LeftShift))
            {
            
                shiftKey = true;
            
            }
            else
            {
            
                shiftKey = false;
            
            }


            if(MethodExtend.keyboardLanguage == 1)
            {
                
                if(Input.GetKeyUp(KeyCode.LeftBracket) && shiftKey == false)
                {

                    appostrophe = 1;

                }
                
                if(Input.GetKeyUp(KeyCode.LeftBracket) && shiftKey == true)
                {

                    appostrophe = 2;

                }                

                if(Input.GetKeyUp(KeyCode.Quote) && shiftKey == false)
                {

                    appostrophe = 3;

                }
                
                if(Input.GetKeyUp(KeyCode.Quote) && shiftKey == true)
                {

                    appostrophe = 4;

                }                

                if(Input.GetKeyUp(KeyCode.Alpha6) && shiftKey == true)
                {

                    appostrophe = 5;

                }                




                if(Input.GetKeyUp(KeyCode.A) && appostrophe == 1 )
                {
    
                    int _PositionX = _XaxisTextField;
                    int _PositionY = _YaxisTextField;

                    paintPointerPositionBlack(ref computacion, _kernelforPrintPointerBlack, PositionPointerX, PositionPointerY); 
                    PositionPointerX -= 34;
                    paintPointerPosition(ref bufferColorPointer, ref computacion, _kernelforPrintPointer, PositionPointerX, PositionPointerY,(int) timeNow); 
    
                    ///////////////////////////////////
                    // Paint letter
                    ///////////////////////////////////        
                    paintPortugueseFromTextureIndividualWriteTextField(ref computacion, _kernelforPrintTilesPortugueseIndividualWriteTextField, _PositionX, _PositionY, 0, 0);
                    ///////////////////////////////////
                    // Paint letter
                    ///////////////////////////////////
    
    
                    _XaxisTextField -= CHARACTERWIDTH;
                    StringTextField += "Á";
                    afterAppostrophe = true;

    
                }
            
                if(Input.GetKeyUp(KeyCode.A) && appostrophe == 2)
                {
    
                    int _PositionX = _XaxisTextField;
                    int _PositionY = _YaxisTextField;

                    paintPointerPositionBlack(ref computacion, _kernelforPrintPointerBlack, PositionPointerX, PositionPointerY); 
                    PositionPointerX -= 34;
                    paintPointerPosition(ref bufferColorPointer, ref computacion, _kernelforPrintPointer, PositionPointerX, PositionPointerY,(int) timeNow); 
    
                    ///////////////////////////////////
                    // Paint letter
                    ///////////////////////////////////        
                    paintPortugueseFromTextureIndividualWriteTextField(ref computacion, _kernelforPrintTilesPortugueseIndividualWriteTextField, _PositionX, _PositionY, 1, 0);
                    ///////////////////////////////////
                    // Paint letter
                    ///////////////////////////////////
    
    
                    _XaxisTextField -= CHARACTERWIDTH;
                    StringTextField += "À";
                    afterAppostrophe = true;

    
                }
            
                if(Input.GetKeyUp(KeyCode.A) && appostrophe == 4)
                {
    
                    int _PositionX = _XaxisTextField;
                    int _PositionY = _YaxisTextField;

                    paintPointerPositionBlack(ref computacion, _kernelforPrintPointerBlack, PositionPointerX, PositionPointerY); 
                    PositionPointerX -= 34;
                    paintPointerPosition(ref bufferColorPointer, ref computacion, _kernelforPrintPointer, PositionPointerX, PositionPointerY,(int) timeNow); 
    
                    ///////////////////////////////////
                    // Paint letter
                    ///////////////////////////////////        
                    paintPortugueseFromTextureIndividualWriteTextField(ref computacion, _kernelforPrintTilesPortugueseIndividualWriteTextField, _PositionX, _PositionY, 2, 0);
                    ///////////////////////////////////
                    // Paint letter
                    ///////////////////////////////////
    
    
                    _XaxisTextField -= CHARACTERWIDTH;
                    StringTextField += "Â";
                    afterAppostrophe = true;

    
                }

                if(Input.GetKeyUp(KeyCode.A) && appostrophe == 3)
                {
    
                    int _PositionX = _XaxisTextField;
                    int _PositionY = _YaxisTextField;

                    paintPointerPositionBlack(ref computacion, _kernelforPrintPointerBlack, PositionPointerX, PositionPointerY); 
                    PositionPointerX -= 34;
                    paintPointerPosition(ref bufferColorPointer, ref computacion, _kernelforPrintPointer, PositionPointerX, PositionPointerY,(int) timeNow); 
    
                    ///////////////////////////////////
                    // Paint letter
                    ///////////////////////////////////        
                    paintPortugueseFromTextureIndividualWriteTextField(ref computacion, _kernelforPrintTilesPortugueseIndividualWriteTextField, _PositionX, _PositionY, 0, 1);
                    ///////////////////////////////////
                    // Paint letter
                    ///////////////////////////////////
    
    
                    _XaxisTextField -= CHARACTERWIDTH;
                    StringTextField += "Ã";
                    afterAppostrophe = true;

    
                }

                if(Input.GetKeyUp(KeyCode.A) && appostrophe == 5)
                {
    
                    int _PositionX = _XaxisTextField;
                    int _PositionY = _YaxisTextField;

                    paintPointerPositionBlack(ref computacion, _kernelforPrintPointerBlack, PositionPointerX, PositionPointerY); 
                    PositionPointerX -= 34;
                    paintPointerPosition(ref bufferColorPointer, ref computacion, _kernelforPrintPointer, PositionPointerX, PositionPointerY,(int) timeNow); 
    
                    ///////////////////////////////////
                    // Paint letter
                    ///////////////////////////////////        
                    paintPortugueseFromTextureIndividualWriteTextField(ref computacion, _kernelforPrintTilesPortugueseIndividualWriteTextField, _PositionX, _PositionY, 3, 0);
                    ///////////////////////////////////
                    // Paint letter
                    ///////////////////////////////////
    
    
                    _XaxisTextField -= CHARACTERWIDTH;
                    StringTextField += "Ä";
                    afterAppostrophe = true;

    
                }
            
                if(Input.GetKeyUp(KeyCode.Semicolon))
                {
    
                    int _PositionX = _XaxisTextField;
                    int _PositionY = _YaxisTextField;

                    paintPointerPositionBlack(ref computacion, _kernelforPrintPointerBlack, PositionPointerX, PositionPointerY); 
                    PositionPointerX -= 34;
                    paintPointerPosition(ref bufferColorPointer, ref computacion, _kernelforPrintPointer, PositionPointerX, PositionPointerY,(int) timeNow); 
    
                    ///////////////////////////////////
                    // Paint letter
                    ///////////////////////////////////        
                    paintPortugueseFromTextureIndividualWriteTextField(ref computacion, _kernelforPrintTilesPortugueseIndividualWriteTextField, _PositionX, _PositionY, 1, 1);
                    ///////////////////////////////////
                    // Paint letter
                    ///////////////////////////////////
    
    
                    _XaxisTextField -= CHARACTERWIDTH;
                    StringTextField += "Ç";
                    afterAppostrophe = true;

    
                }
    
                if(Input.GetKeyUp(KeyCode.E) && appostrophe == 1 )
                {
    
                    int _PositionX = _XaxisTextField;
                    int _PositionY = _YaxisTextField;

                    paintPointerPositionBlack(ref computacion, _kernelforPrintPointerBlack, PositionPointerX, PositionPointerY); 
                    PositionPointerX -= 34;
                    paintPointerPosition(ref bufferColorPointer, ref computacion, _kernelforPrintPointer, PositionPointerX, PositionPointerY,(int) timeNow); 
    
                    ///////////////////////////////////
                    // Paint letter
                    ///////////////////////////////////        
                    paintPortugueseFromTextureIndividualWriteTextField(ref computacion, _kernelforPrintTilesPortugueseIndividualWriteTextField, _PositionX, _PositionY, 2, 1);
                    ///////////////////////////////////
                    // Paint letter
                    ///////////////////////////////////
    
    
                    _XaxisTextField -= CHARACTERWIDTH;
                    StringTextField += "É";
                    afterAppostrophe = true;

    
                }
            
                if(Input.GetKeyUp(KeyCode.E) && appostrophe == 2)
                {
    
                    int _PositionX = _XaxisTextField;
                    int _PositionY = _YaxisTextField;

                    paintPointerPositionBlack(ref computacion, _kernelforPrintPointerBlack, PositionPointerX, PositionPointerY); 
                    PositionPointerX -= 34;
                    paintPointerPosition(ref bufferColorPointer, ref computacion, _kernelforPrintPointer, PositionPointerX, PositionPointerY,(int) timeNow); 
    
                    ///////////////////////////////////
                    // Paint letter
                    ///////////////////////////////////        
                    paintPortugueseFromTextureIndividualWriteTextField(ref computacion, _kernelforPrintTilesPortugueseIndividualWriteTextField, _PositionX, _PositionY, 3, 1);
                    ///////////////////////////////////
                    // Paint letter
                    ///////////////////////////////////
    
    
                    _XaxisTextField -= CHARACTERWIDTH;
                    StringTextField += "È";
                    afterAppostrophe = true;

    
                }
            
                if(Input.GetKeyUp(KeyCode.E) && appostrophe == 4)
                {
    
                    int _PositionX = _XaxisTextField;
                    int _PositionY = _YaxisTextField;

                    paintPointerPositionBlack(ref computacion, _kernelforPrintPointerBlack, PositionPointerX, PositionPointerY); 
                    PositionPointerX -= 34;
                    paintPointerPosition(ref bufferColorPointer, ref computacion, _kernelforPrintPointer, PositionPointerX, PositionPointerY,(int) timeNow); 
    
                    ///////////////////////////////////
                    // Paint letter
                    ///////////////////////////////////        
                    paintPortugueseFromTextureIndividualWriteTextField(ref computacion, _kernelforPrintTilesPortugueseIndividualWriteTextField, _PositionX, _PositionY, 0, 2);
                    ///////////////////////////////////
                    // Paint letter
                    ///////////////////////////////////
    
    
                    _XaxisTextField -= CHARACTERWIDTH;
                    StringTextField += "Ê";
                    afterAppostrophe = true;

    
                }

                if(Input.GetKeyUp(KeyCode.E) && appostrophe == 3)
                {
    
                    int _PositionX = _XaxisTextField;
                    int _PositionY = _YaxisTextField;

                    paintPointerPositionBlack(ref computacion, _kernelforPrintPointerBlack, PositionPointerX, PositionPointerY); 
                    PositionPointerX -= 34;
                    paintPointerPosition(ref bufferColorPointer, ref computacion, _kernelforPrintPointer, PositionPointerX, PositionPointerY,(int) timeNow); 
    
                    ///////////////////////////////////
                    // Paint letter
                    ///////////////////////////////////        
                    paintPortugueseFromTextureIndividualWriteTextField(ref computacion, _kernelforPrintTilesPortugueseIndividualWriteTextField, _PositionX, _PositionY, 0, 2);
                    ///////////////////////////////////
                    // Paint letter
                    ///////////////////////////////////
    
    
                    _XaxisTextField -= CHARACTERWIDTH;
                    StringTextField += "Ê";
                    afterAppostrophe = true;

    
                }    

                if(Input.GetKeyUp(KeyCode.E) && appostrophe == 5)
                {
    
                    int _PositionX = _XaxisTextField;
                    int _PositionY = _YaxisTextField;

                    paintPointerPositionBlack(ref computacion, _kernelforPrintPointerBlack, PositionPointerX, PositionPointerY); 
                    PositionPointerX -= 34;
                    paintPointerPosition(ref bufferColorPointer, ref computacion, _kernelforPrintPointer, PositionPointerX, PositionPointerY,(int) timeNow); 
    
                    ///////////////////////////////////
                    // Paint letter
                    ///////////////////////////////////        
                    paintPortugueseFromTextureIndividualWriteTextField(ref computacion, _kernelforPrintTilesPortugueseIndividualWriteTextField, _PositionX, _PositionY, 1, 2);
                    ///////////////////////////////////
                    // Paint letter
                    ///////////////////////////////////
    
    
                    _XaxisTextField -= CHARACTERWIDTH;
                    StringTextField += "Ë";
                    afterAppostrophe = true;

    
                }    

                if(Input.GetKeyUp(KeyCode.I) && appostrophe == 1 )
                {
    
                    int _PositionX = _XaxisTextField;
                    int _PositionY = _YaxisTextField;

                    paintPointerPositionBlack(ref computacion, _kernelforPrintPointerBlack, PositionPointerX, PositionPointerY); 
                    PositionPointerX -= 34;
                    paintPointerPosition(ref bufferColorPointer, ref computacion, _kernelforPrintPointer, PositionPointerX, PositionPointerY,(int) timeNow); 
    
                    ///////////////////////////////////
                    // Paint letter
                    ///////////////////////////////////        
                    paintPortugueseFromTextureIndividualWriteTextField(ref computacion, _kernelforPrintTilesPortugueseIndividualWriteTextField, _PositionX, _PositionY, 2, 2);
                    ///////////////////////////////////
                    // Paint letter
                    ///////////////////////////////////
    
    
                    _XaxisTextField -= CHARACTERWIDTH;
                    StringTextField += "Í";
                    afterAppostrophe = true;

    
                }
            
                if(Input.GetKeyUp(KeyCode.I) && appostrophe == 2)
                {
    
                    int _PositionX = _XaxisTextField;
                    int _PositionY = _YaxisTextField;

                    paintPointerPositionBlack(ref computacion, _kernelforPrintPointerBlack, PositionPointerX, PositionPointerY); 
                    PositionPointerX -= 34;
                    paintPointerPosition(ref bufferColorPointer, ref computacion, _kernelforPrintPointer, PositionPointerX, PositionPointerY,(int) timeNow); 
    
                    ///////////////////////////////////
                    // Paint letter
                    ///////////////////////////////////        
                    paintPortugueseFromTextureIndividualWriteTextField(ref computacion, _kernelforPrintTilesPortugueseIndividualWriteTextField, _PositionX, _PositionY, 3, 2);
                    ///////////////////////////////////
                    // Paint letter
                    ///////////////////////////////////
    
    
                    _XaxisTextField -= CHARACTERWIDTH;
                    StringTextField += "Ì";
                    afterAppostrophe = true;

    
                }
            
                if(Input.GetKeyUp(KeyCode.I) && appostrophe == 4)
                {
    
                    int _PositionX = _XaxisTextField;
                    int _PositionY = _YaxisTextField;

                    paintPointerPositionBlack(ref computacion, _kernelforPrintPointerBlack, PositionPointerX, PositionPointerY); 
                    PositionPointerX -= 34;
                    paintPointerPosition(ref bufferColorPointer, ref computacion, _kernelforPrintPointer, PositionPointerX, PositionPointerY,(int) timeNow); 
    
                    ///////////////////////////////////
                    // Paint letter
                    ///////////////////////////////////        
                    paintPortugueseFromTextureIndividualWriteTextField(ref computacion, _kernelforPrintTilesPortugueseIndividualWriteTextField, _PositionX, _PositionY, 0, 3);
                    ///////////////////////////////////
                    // Paint letter
                    ///////////////////////////////////
    
    
                    _XaxisTextField -= CHARACTERWIDTH;
                    StringTextField += "Î";
                    afterAppostrophe = true;

    
                }

                if(Input.GetKeyUp(KeyCode.I) && appostrophe == 3)
                {
    
                    int _PositionX = _XaxisTextField;
                    int _PositionY = _YaxisTextField;

                    paintPointerPositionBlack(ref computacion, _kernelforPrintPointerBlack, PositionPointerX, PositionPointerY); 
                    PositionPointerX -= 34;
                    paintPointerPosition(ref bufferColorPointer, ref computacion, _kernelforPrintPointer, PositionPointerX, PositionPointerY,(int) timeNow); 
    
                    ///////////////////////////////////
                    // Paint letter
                    ///////////////////////////////////        
                    paintPortugueseFromTextureIndividualWriteTextField(ref computacion, _kernelforPrintTilesPortugueseIndividualWriteTextField, _PositionX, _PositionY, 0, 3);
                    ///////////////////////////////////
                    // Paint letter
                    ///////////////////////////////////
    
    
                    _XaxisTextField -= CHARACTERWIDTH;
                    StringTextField += "Î";
                    afterAppostrophe = true;

    
                }    

                if(Input.GetKeyUp(KeyCode.I) && appostrophe == 5)
                {
    
                    int _PositionX = _XaxisTextField;
                    int _PositionY = _YaxisTextField;

                    paintPointerPositionBlack(ref computacion, _kernelforPrintPointerBlack, PositionPointerX, PositionPointerY); 
                    PositionPointerX -= 34;
                    paintPointerPosition(ref bufferColorPointer, ref computacion, _kernelforPrintPointer, PositionPointerX, PositionPointerY,(int) timeNow); 
    
                    ///////////////////////////////////
                    // Paint letter
                    ///////////////////////////////////        
                    paintPortugueseFromTextureIndividualWriteTextField(ref computacion, _kernelforPrintTilesPortugueseIndividualWriteTextField, _PositionX, _PositionY, 1, 3);
                    ///////////////////////////////////
                    // Paint letter
                    ///////////////////////////////////
    
    
                    _XaxisTextField -= CHARACTERWIDTH;
                    StringTextField += "Ï";
                    afterAppostrophe = true;

    
                }    

                if(Input.GetKeyUp(KeyCode.O) && appostrophe == 1 )
                {
    
                    int _PositionX = _XaxisTextField;
                    int _PositionY = _YaxisTextField;

                    paintPointerPositionBlack(ref computacion, _kernelforPrintPointerBlack, PositionPointerX, PositionPointerY); 
                    PositionPointerX -= 34;
                    paintPointerPosition(ref bufferColorPointer, ref computacion, _kernelforPrintPointer, PositionPointerX, PositionPointerY,(int) timeNow); 
    
                    ///////////////////////////////////
                    // Paint letter
                    ///////////////////////////////////        
                    paintPortugueseFromTextureIndividualWriteTextField(ref computacion, _kernelforPrintTilesPortugueseIndividualWriteTextField, _PositionX, _PositionY, 2, 3);
                    ///////////////////////////////////
                    // Paint letter
                    ///////////////////////////////////
    
    
                    _XaxisTextField -= CHARACTERWIDTH;
                    StringTextField += "Ó";
                    afterAppostrophe = true;

    
                }
            
                if(Input.GetKeyUp(KeyCode.O) && appostrophe == 2)
                {
    
                    int _PositionX = _XaxisTextField;
                    int _PositionY = _YaxisTextField;

                    paintPointerPositionBlack(ref computacion, _kernelforPrintPointerBlack, PositionPointerX, PositionPointerY); 
                    PositionPointerX -= 34;
                    paintPointerPosition(ref bufferColorPointer, ref computacion, _kernelforPrintPointer, PositionPointerX, PositionPointerY,(int) timeNow); 
    
                    ///////////////////////////////////
                    // Paint letter
                    ///////////////////////////////////        
                    paintPortugueseFromTextureIndividualWriteTextField(ref computacion, _kernelforPrintTilesPortugueseIndividualWriteTextField, _PositionX, _PositionY, 3, 3);
                    ///////////////////////////////////
                    // Paint letter
                    ///////////////////////////////////
    
    
                    _XaxisTextField -= CHARACTERWIDTH;
                    StringTextField += "Ò";
                    afterAppostrophe = true;

    
                }
            
                if(Input.GetKeyUp(KeyCode.O) && appostrophe == 4)
                {
    
                    int _PositionX = _XaxisTextField;
                    int _PositionY = _YaxisTextField;

                    paintPointerPositionBlack(ref computacion, _kernelforPrintPointerBlack, PositionPointerX, PositionPointerY); 
                    PositionPointerX -= 34;
                    paintPointerPosition(ref bufferColorPointer, ref computacion, _kernelforPrintPointer, PositionPointerX, PositionPointerY,(int) timeNow); 
    
                    ///////////////////////////////////
                    // Paint letter
                    ///////////////////////////////////        
                    paintPortugueseFromTextureIndividualWriteTextField(ref computacion, _kernelforPrintTilesPortugueseIndividualWriteTextField, _PositionX, _PositionY, 2, 4);
                    ///////////////////////////////////
                    // Paint letter
                    ///////////////////////////////////
    
    
                    _XaxisTextField -= CHARACTERWIDTH;
                    StringTextField += "Õ";
                    afterAppostrophe = true;

    
                }

                if(Input.GetKeyUp(KeyCode.O) && appostrophe == 3)
                {
    
                    int _PositionX = _XaxisTextField;
                    int _PositionY = _YaxisTextField;

                    paintPointerPositionBlack(ref computacion, _kernelforPrintPointerBlack, PositionPointerX, PositionPointerY); 
                    PositionPointerX -= 34;
                    paintPointerPosition(ref bufferColorPointer, ref computacion, _kernelforPrintPointer, PositionPointerX, PositionPointerY,(int) timeNow); 
    
                    ///////////////////////////////////
                    // Paint letter
                    ///////////////////////////////////        
                    paintPortugueseFromTextureIndividualWriteTextField(ref computacion, _kernelforPrintTilesPortugueseIndividualWriteTextField, _PositionX, _PositionY, 0, 4);
                    ///////////////////////////////////
                    // Paint letter
                    ///////////////////////////////////
    
    
                    _XaxisTextField -= CHARACTERWIDTH;
                    StringTextField += "Ô";
                    afterAppostrophe = true;

    
                }    

                if(Input.GetKeyUp(KeyCode.O) && appostrophe == 5)
                {
    
                    int _PositionX = _XaxisTextField;
                    int _PositionY = _YaxisTextField;

                    paintPointerPositionBlack(ref computacion, _kernelforPrintPointerBlack, PositionPointerX, PositionPointerY); 
                    PositionPointerX -= 34;
                    paintPointerPosition(ref bufferColorPointer, ref computacion, _kernelforPrintPointer, PositionPointerX, PositionPointerY,(int) timeNow); 
    
                    ///////////////////////////////////
                    // Paint letter
                    ///////////////////////////////////        
                    paintPortugueseFromTextureIndividualWriteTextField(ref computacion, _kernelforPrintTilesPortugueseIndividualWriteTextField, _PositionX, _PositionY, 1, 4);
                    ///////////////////////////////////
                    // Paint letter
                    ///////////////////////////////////
    
    
                    _XaxisTextField -= CHARACTERWIDTH;
                    StringTextField += "Ö";
                    afterAppostrophe = true;

    
                }    

                if(Input.GetKeyUp(KeyCode.U) && appostrophe == 1 )
                {
    
                    int _PositionX = _XaxisTextField;
                    int _PositionY = _YaxisTextField;

                    paintPointerPositionBlack(ref computacion, _kernelforPrintPointerBlack, PositionPointerX, PositionPointerY); 
                    PositionPointerX -= 34;
                    paintPointerPosition(ref bufferColorPointer, ref computacion, _kernelforPrintPointer, PositionPointerX, PositionPointerY,(int) timeNow); 
    
                    ///////////////////////////////////
                    // Paint letter
                    ///////////////////////////////////        
                    paintPortugueseFromTextureIndividualWriteTextField(ref computacion, _kernelforPrintTilesPortugueseIndividualWriteTextField, _PositionX, _PositionY, 1, 4);
                    ///////////////////////////////////
                    // Paint letter
                    ///////////////////////////////////
    
    
                    _XaxisTextField -= CHARACTERWIDTH;
                    StringTextField += "Ú";
                    afterAppostrophe = true;

    
                }
            
                if(Input.GetKeyUp(KeyCode.U) && appostrophe == 2)
                {
    
                    int _PositionX = _XaxisTextField;
                    int _PositionY = _YaxisTextField;

                    paintPointerPositionBlack(ref computacion, _kernelforPrintPointerBlack, PositionPointerX, PositionPointerY); 
                    PositionPointerX -= 34;
                    paintPointerPosition(ref bufferColorPointer, ref computacion, _kernelforPrintPointer, PositionPointerX, PositionPointerY,(int) timeNow); 
    
                    ///////////////////////////////////
                    // Paint letter
                    ///////////////////////////////////        
                    paintPortugueseFromTextureIndividualWriteTextField(ref computacion, _kernelforPrintTilesPortugueseIndividualWriteTextField, _PositionX, _PositionY, 0, 5);
                    ///////////////////////////////////
                    // Paint letter
                    ///////////////////////////////////
    
    
                    _XaxisTextField -= CHARACTERWIDTH;
                    StringTextField += "Ù";
                    afterAppostrophe = true;

    
                }            

                if(Input.GetKeyUp(KeyCode.U) && appostrophe == 4)
                {
    
                    int _PositionX = _XaxisTextField;
                    int _PositionY = _YaxisTextField;

                    paintPointerPositionBlack(ref computacion, _kernelforPrintPointerBlack, PositionPointerX, PositionPointerY); 
                    PositionPointerX -= 34;
                    paintPointerPosition(ref bufferColorPointer, ref computacion, _kernelforPrintPointer, PositionPointerX, PositionPointerY,(int) timeNow); 
    
                    ///////////////////////////////////
                    // Paint letter
                    ///////////////////////////////////        
                    paintPortugueseFromTextureIndividualWriteTextField(ref computacion, _kernelforPrintTilesPortugueseIndividualWriteTextField, _PositionX, _PositionY, 1, 5);
                    ///////////////////////////////////
                    // Paint letter
                    ///////////////////////////////////
    
    
                    _XaxisTextField -= CHARACTERWIDTH;
                    StringTextField += "Û";
                    afterAppostrophe = true;

    
                }

                if(Input.GetKeyUp(KeyCode.U) && appostrophe == 3)
                {
    
                    int _PositionX = _XaxisTextField;
                    int _PositionY = _YaxisTextField;

                    paintPointerPositionBlack(ref computacion, _kernelforPrintPointerBlack, PositionPointerX, PositionPointerY); 
                    PositionPointerX -= 34;
                    paintPointerPosition(ref bufferColorPointer, ref computacion, _kernelforPrintPointer, PositionPointerX, PositionPointerY,(int) timeNow); 
    
                    ///////////////////////////////////
                    // Paint letter
                    ///////////////////////////////////        
                    paintPortugueseFromTextureIndividualWriteTextField(ref computacion, _kernelforPrintTilesPortugueseIndividualWriteTextField, _PositionX, _PositionY, 1, 5);
                    ///////////////////////////////////
                    // Paint letter
                    ///////////////////////////////////
    
    
                    _XaxisTextField -= CHARACTERWIDTH;
                    StringTextField += "Û";
                    afterAppostrophe = true;

    
                }    

                if(Input.GetKeyUp(KeyCode.U) && appostrophe == 5)
                {
    
                    int _PositionX = _XaxisTextField;
                    int _PositionY = _YaxisTextField;

                    paintPointerPositionBlack(ref computacion, _kernelforPrintPointerBlack, PositionPointerX, PositionPointerY); 
                    PositionPointerX -= 34;
                    paintPointerPosition(ref bufferColorPointer, ref computacion, _kernelforPrintPointer, PositionPointerX, PositionPointerY,(int) timeNow); 
    
                    ///////////////////////////////////
                    // Paint letter
                    ///////////////////////////////////        
                    paintPortugueseFromTextureIndividualWriteTextField(ref computacion, _kernelforPrintTilesPortugueseIndividualWriteTextField, _PositionX, _PositionY, 2, 5);
                    ///////////////////////////////////
                    // Paint letter
                    ///////////////////////////////////
    
    
                    _XaxisTextField -= CHARACTERWIDTH;
                    StringTextField += "Ü";
                    afterAppostrophe = true;

    
                }    

            
            }
            


            if(Input.GetKeyUp(KeyCode.A) && appostrophe == 0)
            {
                int _PositionX = _XaxisTextField;
                int _PositionY = _YaxisTextField;

        
                paintPointerPositionBlack(ref computacion, _kernelforPrintPointerBlack, PositionPointerX, PositionPointerY); 
                PositionPointerX -= 34;
                paintPointerPosition(ref bufferColorPointer, ref computacion, _kernelforPrintPointer, PositionPointerX, PositionPointerY,(int) timeNow); 


                ///////////////////////////////////
                // Paint letter
                ///////////////////////////////////        
                paintAlphabetFromTextureIndividualWriteTextField(ref computacion, _kernelforPrintTilesAlphabetIndividualWriteTextField, _PositionX, _PositionY,0,0);
                ///////////////////////////////////
                // Paint letter
                ///////////////////////////////////


                _XaxisTextField -= CHARACTERWIDTH;
                StringTextField += "A";

            }



            if(Input.GetKeyUp(KeyCode.B))
            {
                int _PositionX = _XaxisTextField;
                int _PositionY = _YaxisTextField;

                paintPointerPositionBlack(ref computacion, _kernelforPrintPointerBlack, PositionPointerX, PositionPointerY); 
                PositionPointerX -= 34;
                paintPointerPosition(ref bufferColorPointer, ref computacion, _kernelforPrintPointer, PositionPointerX, PositionPointerY,(int) timeNow); 

                ///////////////////////////////////
                // Paint letter
                ///////////////////////////////////        
                paintAlphabetFromTextureIndividualWriteTextField(ref computacion, _kernelforPrintTilesAlphabetIndividualWriteTextField, _PositionX, _PositionY,1,0);
                ///////////////////////////////////
                // Paint letter
                ///////////////////////////////////


                _XaxisTextField -= CHARACTERWIDTH;
                StringTextField += "B";

            }



            if(Input.GetKeyUp(KeyCode.C))
            {
                int _PositionX = _XaxisTextField;
                int _PositionY = _YaxisTextField;

                paintPointerPositionBlack(ref computacion, _kernelforPrintPointerBlack, PositionPointerX, PositionPointerY); 
                PositionPointerX -= 34;
                paintPointerPosition(ref bufferColorPointer, ref computacion, _kernelforPrintPointer, PositionPointerX, PositionPointerY,(int) timeNow); 

                ///////////////////////////////////
                // Paint letter
                ///////////////////////////////////        
                paintAlphabetFromTextureIndividualWriteTextField(ref computacion, _kernelforPrintTilesAlphabetIndividualWriteTextField, _PositionX, _PositionY,2,0);
                ///////////////////////////////////
                // Paint letter
                ///////////////////////////////////


                _XaxisTextField -= CHARACTERWIDTH;
                StringTextField += "C";

            }



            if(Input.GetKeyUp(KeyCode.D))
            {
                int _PositionX = _XaxisTextField;
                int _PositionY = _YaxisTextField;

                paintPointerPositionBlack(ref computacion, _kernelforPrintPointerBlack, PositionPointerX, PositionPointerY); 
                PositionPointerX -= 34;
                paintPointerPosition(ref bufferColorPointer, ref computacion, _kernelforPrintPointer, PositionPointerX, PositionPointerY,(int) timeNow); 

                ///////////////////////////////////
                // Paint letter
                ///////////////////////////////////        
                paintAlphabetFromTextureIndividualWriteTextField(ref computacion, _kernelforPrintTilesAlphabetIndividualWriteTextField, _PositionX, _PositionY,3,0);
                ///////////////////////////////////
                // Paint letter
                ///////////////////////////////////


                _XaxisTextField -= CHARACTERWIDTH;
                StringTextField += "D";

            }



            if(Input.GetKeyUp(KeyCode.E) && appostrophe == 0)
            {
                int _PositionX = _XaxisTextField;
                int _PositionY = _YaxisTextField;

                paintPointerPositionBlack(ref computacion, _kernelforPrintPointerBlack, PositionPointerX, PositionPointerY); 
                PositionPointerX -= 34;
                paintPointerPosition(ref bufferColorPointer, ref computacion, _kernelforPrintPointer, PositionPointerX, PositionPointerY,(int) timeNow); 

                ///////////////////////////////////
                // Paint letter
                ///////////////////////////////////        
                paintAlphabetFromTextureIndividualWriteTextField(ref computacion, _kernelforPrintTilesAlphabetIndividualWriteTextField, _PositionX, _PositionY,0,1);
                ///////////////////////////////////
                // Paint letter
                ///////////////////////////////////


                _XaxisTextField -= CHARACTERWIDTH;
                StringTextField += "E";

            }



            if(Input.GetKeyUp(KeyCode.F))
            {
                int _PositionX = _XaxisTextField;
                int _PositionY = _YaxisTextField;

                paintPointerPositionBlack(ref computacion, _kernelforPrintPointerBlack, PositionPointerX, PositionPointerY); 
                PositionPointerX -= 34;
                paintPointerPosition(ref bufferColorPointer, ref computacion, _kernelforPrintPointer, PositionPointerX, PositionPointerY,(int) timeNow); 

                ///////////////////////////////////
                // Paint letter
                ///////////////////////////////////        
                paintAlphabetFromTextureIndividualWriteTextField(ref computacion, _kernelforPrintTilesAlphabetIndividualWriteTextField, _PositionX, _PositionY,1,1);
                ///////////////////////////////////
                // Paint letter
                ///////////////////////////////////


                _XaxisTextField -= CHARACTERWIDTH;
                StringTextField += "F";

            }



            if(Input.GetKeyUp(KeyCode.G))
            {
                int _PositionX = _XaxisTextField;
                int _PositionY = _YaxisTextField;

                paintPointerPositionBlack(ref computacion, _kernelforPrintPointerBlack, PositionPointerX, PositionPointerY); 
                PositionPointerX -= 34;
                paintPointerPosition(ref bufferColorPointer, ref computacion, _kernelforPrintPointer, PositionPointerX, PositionPointerY,(int) timeNow); 

                ///////////////////////////////////
                // Paint letter
                ///////////////////////////////////        
                paintAlphabetFromTextureIndividualWriteTextField(ref computacion, _kernelforPrintTilesAlphabetIndividualWriteTextField, _PositionX, _PositionY,2,1);
                ///////////////////////////////////
                // Paint letter
                ///////////////////////////////////


                _XaxisTextField -= CHARACTERWIDTH;
                StringTextField += "G";

            }



            if(Input.GetKeyUp(KeyCode.H))
            {
                int _PositionX = _XaxisTextField;
                int _PositionY = _YaxisTextField;


                paintPointerPositionBlack(ref computacion, _kernelforPrintPointerBlack, PositionPointerX, PositionPointerY); 
                PositionPointerX -= 34;
                paintPointerPosition(ref bufferColorPointer, ref computacion, _kernelforPrintPointer, PositionPointerX, PositionPointerY,(int) timeNow); 

                ///////////////////////////////////
                // Paint letter
                ///////////////////////////////////        
                paintAlphabetFromTextureIndividualWriteTextField(ref computacion, _kernelforPrintTilesAlphabetIndividualWriteTextField, _PositionX, _PositionY,3,1);
                ///////////////////////////////////
                // Paint letter
                ///////////////////////////////////


                _XaxisTextField -= CHARACTERWIDTH;
                StringTextField += "H";

            }



            if(Input.GetKeyUp(KeyCode.I) && appostrophe == 0)
            {
                int _PositionX = _XaxisTextField;
                int _PositionY = _YaxisTextField;

                paintPointerPositionBlack(ref computacion, _kernelforPrintPointerBlack, PositionPointerX, PositionPointerY); 
                PositionPointerX -= 34;
                paintPointerPosition(ref bufferColorPointer, ref computacion, _kernelforPrintPointer, PositionPointerX, PositionPointerY,(int) timeNow); 

                ///////////////////////////////////
                // Paint letter
                ///////////////////////////////////        
                paintAlphabetFromTextureIndividualWriteTextField(ref computacion, _kernelforPrintTilesAlphabetIndividualWriteTextField, _PositionX, _PositionY,0,2);
                ///////////////////////////////////
                // Paint letter
                ///////////////////////////////////


                _XaxisTextField -= CHARACTERWIDTH;
                StringTextField += "I";

            }



            if(Input.GetKeyUp(KeyCode.J))
            {
                int _PositionX = _XaxisTextField;
                int _PositionY = _YaxisTextField;

                paintPointerPositionBlack(ref computacion, _kernelforPrintPointerBlack, PositionPointerX, PositionPointerY); 
                PositionPointerX -= 34;
                paintPointerPosition(ref bufferColorPointer, ref computacion, _kernelforPrintPointer, PositionPointerX, PositionPointerY,(int) timeNow); 

                ///////////////////////////////////
                // Paint letter
                ///////////////////////////////////        
                paintAlphabetFromTextureIndividualWriteTextField(ref computacion, _kernelforPrintTilesAlphabetIndividualWriteTextField, _PositionX, _PositionY,1,2);
                ///////////////////////////////////
                // Paint letter
                ///////////////////////////////////


                _XaxisTextField -= CHARACTERWIDTH;
                StringTextField += "J";

            }



            if(Input.GetKeyUp(KeyCode.K))
            {
                int _PositionX = _XaxisTextField;
                int _PositionY = _YaxisTextField;

                paintPointerPositionBlack(ref computacion, _kernelforPrintPointerBlack, PositionPointerX, PositionPointerY); 
                PositionPointerX -= 34;
                paintPointerPosition(ref bufferColorPointer, ref computacion, _kernelforPrintPointer, PositionPointerX, PositionPointerY,(int) timeNow); 

                ///////////////////////////////////
                // Paint letter
                ///////////////////////////////////        
                paintAlphabetFromTextureIndividualWriteTextField(ref computacion, _kernelforPrintTilesAlphabetIndividualWriteTextField, _PositionX, _PositionY,2,2);
                ///////////////////////////////////
                // Paint letter
                ///////////////////////////////////


                _XaxisTextField -= CHARACTERWIDTH;
                StringTextField += "K";

            }



            if(Input.GetKeyUp(KeyCode.L))
            {
                int _PositionX = _XaxisTextField;
                int _PositionY = _YaxisTextField;

                paintPointerPositionBlack(ref computacion, _kernelforPrintPointerBlack, PositionPointerX, PositionPointerY); 
                PositionPointerX -= 34;
                paintPointerPosition(ref bufferColorPointer, ref computacion, _kernelforPrintPointer, PositionPointerX, PositionPointerY,(int) timeNow); 

                ///////////////////////////////////
                // Paint letter
                ///////////////////////////////////        
                paintAlphabetFromTextureIndividualWriteTextField(ref computacion, _kernelforPrintTilesAlphabetIndividualWriteTextField, _PositionX, _PositionY,3,2);
                ///////////////////////////////////
                // Paint letter
                ///////////////////////////////////


                _XaxisTextField -= CHARACTERWIDTH;
                StringTextField += "L";

            }



            if(Input.GetKeyUp(KeyCode.M))
            {
                int _PositionX = _XaxisTextField;
                int _PositionY = _YaxisTextField;

                paintPointerPositionBlack(ref computacion, _kernelforPrintPointerBlack, PositionPointerX, PositionPointerY); 
                PositionPointerX -= 34;
                paintPointerPosition(ref bufferColorPointer, ref computacion, _kernelforPrintPointer, PositionPointerX, PositionPointerY,(int) timeNow); 

                ///////////////////////////////////
                // Paint letter
                ///////////////////////////////////        
                paintAlphabetFromTextureIndividualWriteTextField(ref computacion, _kernelforPrintTilesAlphabetIndividualWriteTextField, _PositionX, _PositionY,0,3);
                ///////////////////////////////////
                // Paint letter
                ///////////////////////////////////


                _XaxisTextField -= CHARACTERWIDTH;
                StringTextField += "M";

            }



            if(Input.GetKeyUp(KeyCode.N))
            {
                int _PositionX = _XaxisTextField;
                int _PositionY = _YaxisTextField;

                paintPointerPositionBlack(ref computacion, _kernelforPrintPointerBlack, PositionPointerX, PositionPointerY); 
                PositionPointerX -= 34;
                paintPointerPosition(ref bufferColorPointer, ref computacion, _kernelforPrintPointer, PositionPointerX, PositionPointerY,(int) timeNow); 

                ///////////////////////////////////
                // Paint letter
                ///////////////////////////////////        
                paintAlphabetFromTextureIndividualWriteTextField(ref computacion, _kernelforPrintTilesAlphabetIndividualWriteTextField, _PositionX, _PositionY,1,3);
                ///////////////////////////////////
                // Paint letter
                ///////////////////////////////////


                _XaxisTextField -= CHARACTERWIDTH;
                StringTextField += "N";

            }



            if(Input.GetKeyUp(KeyCode.O) && appostrophe == 0)
            {
                int _PositionX = _XaxisTextField;
                int _PositionY = _YaxisTextField;

                paintPointerPositionBlack(ref computacion, _kernelforPrintPointerBlack, PositionPointerX, PositionPointerY); 
                PositionPointerX -= 34;
                paintPointerPosition(ref bufferColorPointer, ref computacion, _kernelforPrintPointer, PositionPointerX, PositionPointerY,(int) timeNow); 

                ///////////////////////////////////
                // Paint letter
                ///////////////////////////////////        
                paintAlphabetFromTextureIndividualWriteTextField(ref computacion, _kernelforPrintTilesAlphabetIndividualWriteTextField, _PositionX, _PositionY,2,3);
                ///////////////////////////////////
                // Paint letter
                ///////////////////////////////////


                _XaxisTextField -= CHARACTERWIDTH;
                StringTextField += "O";

            }



            if(Input.GetKeyUp(KeyCode.P))
            {
                int _PositionX = _XaxisTextField;
                int _PositionY = _YaxisTextField;

                paintPointerPositionBlack(ref computacion, _kernelforPrintPointerBlack, PositionPointerX, PositionPointerY); 
                PositionPointerX -= 34;
                paintPointerPosition(ref bufferColorPointer, ref computacion, _kernelforPrintPointer, PositionPointerX, PositionPointerY,(int) timeNow); 

                ///////////////////////////////////
                // Paint letter
                ///////////////////////////////////        
                paintAlphabetFromTextureIndividualWriteTextField(ref computacion, _kernelforPrintTilesAlphabetIndividualWriteTextField, _PositionX, _PositionY,3,3);
                ///////////////////////////////////
                // Paint letter
                ///////////////////////////////////


                _XaxisTextField -= CHARACTERWIDTH;
                StringTextField += "P";

            }



            if(Input.GetKeyUp(KeyCode.Q))
            {
                int _PositionX = _XaxisTextField;
                int _PositionY = _YaxisTextField;

                paintPointerPositionBlack(ref computacion, _kernelforPrintPointerBlack, PositionPointerX, PositionPointerY); 
                PositionPointerX -= 34;
                paintPointerPosition(ref bufferColorPointer, ref computacion, _kernelforPrintPointer, PositionPointerX, PositionPointerY,(int) timeNow); 

                ///////////////////////////////////
                // Paint letter
                ///////////////////////////////////        
                paintAlphabetFromTextureIndividualWriteTextField(ref computacion, _kernelforPrintTilesAlphabetIndividualWriteTextField, _PositionX, _PositionY,0,4);
                ///////////////////////////////////
                // Paint letter
                ///////////////////////////////////


                _XaxisTextField -= CHARACTERWIDTH;
                StringTextField += "Q";

            }



            if(Input.GetKeyUp(KeyCode.R))
            {
                int _PositionX = _XaxisTextField;
                int _PositionY = _YaxisTextField;

                paintPointerPositionBlack(ref computacion, _kernelforPrintPointerBlack, PositionPointerX, PositionPointerY); 
                PositionPointerX -= 34;
                paintPointerPosition(ref bufferColorPointer, ref computacion, _kernelforPrintPointer, PositionPointerX, PositionPointerY,(int) timeNow); 

                ///////////////////////////////////
                // Paint letter
                ///////////////////////////////////        
                paintAlphabetFromTextureIndividualWriteTextField(ref computacion, _kernelforPrintTilesAlphabetIndividualWriteTextField, _PositionX, _PositionY,1,4);
                ///////////////////////////////////
                // Paint letter
                ///////////////////////////////////


                _XaxisTextField -= CHARACTERWIDTH;
                StringTextField += "R";

            }



            if(Input.GetKeyUp(KeyCode.S))
            {
                int _PositionX = _XaxisTextField;
                int _PositionY = _YaxisTextField;

                paintPointerPositionBlack(ref computacion, _kernelforPrintPointerBlack, PositionPointerX, PositionPointerY); 
                PositionPointerX -= 34;
                paintPointerPosition(ref bufferColorPointer, ref computacion, _kernelforPrintPointer, PositionPointerX, PositionPointerY,(int) timeNow); 

                ///////////////////////////////////
                // Paint letter
                ///////////////////////////////////        
                paintAlphabetFromTextureIndividualWriteTextField(ref computacion, _kernelforPrintTilesAlphabetIndividualWriteTextField, _PositionX, _PositionY,2,4);
                ///////////////////////////////////
                // Paint letter
                ///////////////////////////////////


                _XaxisTextField -= CHARACTERWIDTH;
                StringTextField += "S";

            }



            if(Input.GetKeyUp(KeyCode.T))
            {
                int _PositionX = _XaxisTextField;
                int _PositionY = _YaxisTextField;

                paintPointerPositionBlack(ref computacion, _kernelforPrintPointerBlack, PositionPointerX, PositionPointerY); 
                PositionPointerX -= 34;
                paintPointerPosition(ref bufferColorPointer, ref computacion, _kernelforPrintPointer, PositionPointerX, PositionPointerY,(int) timeNow); 

                ///////////////////////////////////
                // Paint letter
                ///////////////////////////////////        
                paintAlphabetFromTextureIndividualWriteTextField(ref computacion, _kernelforPrintTilesAlphabetIndividualWriteTextField, _PositionX, _PositionY,3,4);
                ///////////////////////////////////
                // Paint letter
                ///////////////////////////////////


                _XaxisTextField -= CHARACTERWIDTH;
                StringTextField += "T";

            }



            if(Input.GetKeyUp(KeyCode.U))
            {
                int _PositionX = _XaxisTextField;
                int _PositionY = _YaxisTextField;

                paintPointerPositionBlack(ref computacion, _kernelforPrintPointerBlack, PositionPointerX, PositionPointerY); 
                PositionPointerX -= 34;
                paintPointerPosition(ref bufferColorPointer, ref computacion, _kernelforPrintPointer, PositionPointerX, PositionPointerY,(int) timeNow); 

                ///////////////////////////////////
                // Paint letter
                ///////////////////////////////////        
                paintAlphabetFromTextureIndividualWriteTextField(ref computacion, _kernelforPrintTilesAlphabetIndividualWriteTextField, _PositionX, _PositionY,0,5);
                ///////////////////////////////////
                // Paint letter
                ///////////////////////////////////


                _XaxisTextField -= CHARACTERWIDTH;
                StringTextField += "U";

            }



            if(Input.GetKeyUp(KeyCode.V))
            {
                int _PositionX = _XaxisTextField;
                int _PositionY = _YaxisTextField;

                paintPointerPositionBlack(ref computacion, _kernelforPrintPointerBlack, PositionPointerX, PositionPointerY); 
                PositionPointerX -= 34;
                paintPointerPosition(ref bufferColorPointer, ref computacion, _kernelforPrintPointer, PositionPointerX, PositionPointerY,(int) timeNow); 

                ///////////////////////////////////
                // Paint letter
                ///////////////////////////////////        
                paintAlphabetFromTextureIndividualWriteTextField(ref computacion, _kernelforPrintTilesAlphabetIndividualWriteTextField, _PositionX, _PositionY,1,5);
                ///////////////////////////////////
                // Paint letter
                ///////////////////////////////////


                _XaxisTextField -= CHARACTERWIDTH;
                StringTextField += "V";

            }


            if(Input.GetKeyUp(KeyCode.W))
            {
                int _PositionX = _XaxisTextField;
                int _PositionY = _YaxisTextField;

                paintPointerPositionBlack(ref computacion, _kernelforPrintPointerBlack, PositionPointerX, PositionPointerY); 
                PositionPointerX -= 34;
                paintPointerPosition(ref bufferColorPointer, ref computacion, _kernelforPrintPointer, PositionPointerX, PositionPointerY,(int) timeNow); 

                ///////////////////////////////////
                // Paint letter
                ///////////////////////////////////        
                paintAlphabetFromTextureIndividualWriteTextField(ref computacion, _kernelforPrintTilesAlphabetIndividualWriteTextField, _PositionX, _PositionY,2,5);
                ///////////////////////////////////
                // Paint letter
                ///////////////////////////////////


                _XaxisTextField -= CHARACTERWIDTH;
                StringTextField += "W";

            }



            if(Input.GetKeyUp(KeyCode.X))
            {
                int _PositionX = _XaxisTextField;
                int _PositionY = _YaxisTextField;

                paintPointerPositionBlack(ref computacion, _kernelforPrintPointerBlack, PositionPointerX, PositionPointerY); 
                PositionPointerX -= 34;
                paintPointerPosition(ref bufferColorPointer, ref computacion, _kernelforPrintPointer, PositionPointerX, PositionPointerY,(int) timeNow); 

                ///////////////////////////////////
                // Paint letter
                ///////////////////////////////////        
                paintAlphabetFromTextureIndividualWriteTextField(ref computacion, _kernelforPrintTilesAlphabetIndividualWriteTextField, _PositionX, _PositionY,3,5);
                ///////////////////////////////////
                // Paint letter
                ///////////////////////////////////


                _XaxisTextField -= CHARACTERWIDTH;
                StringTextField += "X";

            }



            if(Input.GetKeyUp(KeyCode.Y))
            {
                int _PositionX = _XaxisTextField;
                int _PositionY = _YaxisTextField;

                paintPointerPositionBlack(ref computacion, _kernelforPrintPointerBlack, PositionPointerX, PositionPointerY); 
                PositionPointerX -= 34;
                paintPointerPosition(ref bufferColorPointer, ref computacion, _kernelforPrintPointer, PositionPointerX, PositionPointerY,(int) timeNow); 

                ///////////////////////////////////
                // Paint letter
                ///////////////////////////////////        
                paintAlphabetFromTextureIndividualWriteTextField(ref computacion, _kernelforPrintTilesAlphabetIndividualWriteTextField, _PositionX, _PositionY,0,6);
                ///////////////////////////////////
                // Paint letter
                ///////////////////////////////////


                _XaxisTextField -= CHARACTERWIDTH;
                StringTextField += "Y";

            }



            if(Input.GetKeyUp(KeyCode.Z))
            {
                int _PositionX = _XaxisTextField;
                int _PositionY = _YaxisTextField;

                paintPointerPositionBlack(ref computacion, _kernelforPrintPointerBlack, PositionPointerX, PositionPointerY); 
                PositionPointerX -= 34;
                paintPointerPosition(ref bufferColorPointer, ref computacion, _kernelforPrintPointer, PositionPointerX, PositionPointerY,(int) timeNow); 

                ///////////////////////////////////
                // Paint letter
                ///////////////////////////////////        
                paintAlphabetFromTextureIndividualWriteTextField(ref computacion, _kernelforPrintTilesAlphabetIndividualWriteTextField, _PositionX, _PositionY,1,6);
                ///////////////////////////////////
                // Paint letter
                ///////////////////////////////////


                _XaxisTextField -= CHARACTERWIDTH;
                StringTextField += "Z";

            }

            if(Input.GetKeyUp(KeyCode.Space))
            {
                int _PositionX = _XaxisTextField;
                int _PositionY = _YaxisTextField;

                paintPointerPositionBlack(ref computacion, _kernelforPrintPointerBlack, PositionPointerX, PositionPointerY); 
                PositionPointerX -= 34;
                paintPointerPosition(ref bufferColorPointer, ref computacion, _kernelforPrintPointer, PositionPointerX, PositionPointerY,(int) timeNow); 

                ///////////////////////////////////
                // Paint letter
                ///////////////////////////////////        
                paintAlphabetFromTextureIndividualWriteTextField(ref computacion, _kernelforPrintTilesAlphabetIndividualWriteTextField, _PositionX, _PositionY,2,6);
                ///////////////////////////////////
                // Paint letter
                ///////////////////////////////////


                _XaxisTextField -= CHARACTERWIDTH;
                StringTextField += " ";

            }


            ///////////////////////////////////////////////////////////
            // INPUT CHARACTERS OF ITALIAN AND NUMBERS
            ///////////////////////////////////////////////////////////


            if(MethodExtend.keyboardLanguage == 0)
            {

                if(Input.GetKeyUp(KeyCode.Alpha1) && shiftKey == false)
                {
    
                    int _PositionX = _XaxisTextField;
                    int _PositionY = _YaxisTextField;

                    paintPointerPositionBlack(ref computacion, _kernelforPrintPointerBlack, PositionPointerX, PositionPointerY); 
                    PositionPointerX -= 34;
                    paintPointerPosition(ref bufferColorPointer, ref computacion, _kernelforPrintPointer, PositionPointerX, PositionPointerY,(int) timeNow); 
    
                    ///////////////////////////////////
                    // Paint letter
                    ///////////////////////////////////        
                    paintNumberFromTextureIndividualWriteTextField(ref computacion, _kernelforPrintTilesNumberIndividualWriteTextField, _PositionX, _PositionY,1,0);
                    ///////////////////////////////////
                    // Paint letter
                    ///////////////////////////////////
    
    
                    _XaxisTextField -= CHARACTERWIDTH;
                    StringTextField += "1";
    
                }
    
                
                if(Input.GetKeyUp(KeyCode.Quote))
                {
                    int _PositionX = _XaxisTextField;
                    int _PositionY = _YaxisTextField;

                    paintPointerPositionBlack(ref computacion, _kernelforPrintPointerBlack, PositionPointerX, PositionPointerY); 
                    PositionPointerX -= 34;
                    paintPointerPosition(ref bufferColorPointer, ref computacion, _kernelforPrintPointer, PositionPointerX, PositionPointerY,(int) timeNow); 
    
                    ///////////////////////////////////
                    // Paint letter
                    ///////////////////////////////////        
                    paintNumberFromTextureIndividualWriteTextField(ref computacion, _kernelforPrintTilesNumberIndividualWriteTextField, _PositionX, _PositionY, 2, 2);
                    ///////////////////////////////////
                    // Paint letter
                    ///////////////////////////////////
    
    
                    _XaxisTextField -= CHARACTERWIDTH;
                    StringTextField += "À";
    
                }
    
    
    
                if(Input.GetKeyUp(KeyCode.LeftBracket) && shiftKey == false)
                {
                    int _PositionX = _XaxisTextField;
                    int _PositionY = _YaxisTextField;

                    paintPointerPositionBlack(ref computacion, _kernelforPrintPointerBlack, PositionPointerX, PositionPointerY); 
                    PositionPointerX -= 34;
                    paintPointerPosition(ref bufferColorPointer, ref computacion, _kernelforPrintPointer, PositionPointerX, PositionPointerY,(int) timeNow); 
    
                    ///////////////////////////////////
                    // Paint letter
                    ///////////////////////////////////        
                    paintNumberFromTextureIndividualWriteTextField(ref computacion, _kernelforPrintTilesNumberIndividualWriteTextField, _PositionX, _PositionY, 3, 2);
                    ///////////////////////////////////
                    // Paint letter
                    ///////////////////////////////////
    
    
                    _XaxisTextField -= CHARACTERWIDTH;
                    StringTextField += "È";
    
                }
    
    
                if(Input.GetKeyUp(KeyCode.LeftBracket) && shiftKey == true)
                {
                    int _PositionX = _XaxisTextField;
                    int _PositionY = _YaxisTextField;

                    paintPointerPositionBlack(ref computacion, _kernelforPrintPointerBlack, PositionPointerX, PositionPointerY); 
                    PositionPointerX -= 34;
                    paintPointerPosition(ref bufferColorPointer, ref computacion, _kernelforPrintPointer, PositionPointerX, PositionPointerY,(int) timeNow); 
    
                    ///////////////////////////////////
                    // Paint letter
                    ///////////////////////////////////        
                    paintNumberFromTextureIndividualWriteTextField(ref computacion, _kernelforPrintTilesNumberIndividualWriteTextField, _PositionX, _PositionY, 0, 3);
                    ///////////////////////////////////
                    // Paint letter
                    ///////////////////////////////////
    
    
                    _XaxisTextField -= CHARACTERWIDTH;
                    StringTextField += "É";
    
                }
    
    
    
                if(Input.GetKeyUp(KeyCode.RightBracket))
                {
                    int _PositionX = _XaxisTextField;
                    int _PositionY = _YaxisTextField;

                    paintPointerPositionBlack(ref computacion, _kernelforPrintPointerBlack, PositionPointerX, PositionPointerY); 
                    PositionPointerX -= 34;
                    paintPointerPosition(ref bufferColorPointer, ref computacion, _kernelforPrintPointer, PositionPointerX, PositionPointerY,(int) timeNow); 
    
                    ///////////////////////////////////
                    // Paint letter
                    ///////////////////////////////////        
                    paintNumberFromTextureIndividualWriteTextField(ref computacion, _kernelforPrintTilesNumberIndividualWriteTextField, _PositionX, _PositionY, 1, 3);
                    ///////////////////////////////////
                    // Paint letter
                    ///////////////////////////////////
    
    
                    _XaxisTextField -= CHARACTERWIDTH;
                    StringTextField += "Ì";
                    Debug.Log("Ì");
    
                }
    
    
    
                if(Input.GetKeyUp(KeyCode.Semicolon))
                {
                    int _PositionX = _XaxisTextField;
                    int _PositionY = _YaxisTextField;

                    paintPointerPositionBlack(ref computacion, _kernelforPrintPointerBlack, PositionPointerX, PositionPointerY); 
                    PositionPointerX -= 34;
                    paintPointerPosition(ref bufferColorPointer, ref computacion, _kernelforPrintPointer, PositionPointerX, PositionPointerY,(int) timeNow); 
    
                    ///////////////////////////////////
                    // Paint letter
                    ///////////////////////////////////        
                    paintNumberFromTextureIndividualWriteTextField(ref computacion, _kernelforPrintTilesNumberIndividualWriteTextField, _PositionX, _PositionY, 2, 3);
                    ///////////////////////////////////
                    // Paint letter
                    ///////////////////////////////////
    
    
                    _XaxisTextField -= CHARACTERWIDTH;
                    StringTextField += "Ò";
    
                }
    
    
    
                if(Input.GetKeyUp(KeyCode.Backslash))
                {
                    int _PositionX = _XaxisTextField;
                    int _PositionY = _YaxisTextField;

                    paintPointerPositionBlack(ref computacion, _kernelforPrintPointerBlack, PositionPointerX, PositionPointerY); 
                    PositionPointerX -= 34;
                    paintPointerPosition(ref bufferColorPointer, ref computacion, _kernelforPrintPointer, PositionPointerX, PositionPointerY,(int) timeNow); 
    
                    ///////////////////////////////////
                    // Paint letter
                    ///////////////////////////////////        
                    paintNumberFromTextureIndividualWriteTextField(ref computacion, _kernelforPrintTilesNumberIndividualWriteTextField, _PositionX, _PositionY, 3, 3);
                    ///////////////////////////////////
                    // Paint letter
                    ///////////////////////////////////
    
    
                    _XaxisTextField -= CHARACTERWIDTH;
                    StringTextField += "Ù";
    
                }
    
            
                if(Input.GetKeyUp(KeyCode.Minus) && shiftKey == false )
                {
                    int _PositionX = _XaxisTextField;
                    int _PositionY = _YaxisTextField;

                    paintPointerPositionBlack(ref computacion, _kernelforPrintPointerBlack, PositionPointerX, PositionPointerY); 
                    PositionPointerX -= 34;
                    paintPointerPosition(ref bufferColorPointer, ref computacion, _kernelforPrintPointer, PositionPointerX, PositionPointerY,(int) timeNow); 
    
                    ///////////////////////////////////
                    // Paint letter
                    ///////////////////////////////////        
                    paintNumberFromTextureIndividualWriteTextField(ref computacion, _kernelforPrintTilesNumberIndividualWriteTextField, _PositionX, _PositionY, 0, 4);
                    ///////////////////////////////////
                    // Paint letter
                    ///////////////////////////////////
    
    
                    _XaxisTextField -= CHARACTERWIDTH;
                    StringTextField += "’";
    
                }
    
    
                if(Input.GetKeyUp(KeyCode.Minus) && shiftKey == true)
                {
                    int _PositionX = _XaxisTextField;
                    int _PositionY = _YaxisTextField;

                    paintPointerPositionBlack(ref computacion, _kernelforPrintPointerBlack, PositionPointerX, PositionPointerY); 
                    PositionPointerX -= 34;
                    paintPointerPosition(ref bufferColorPointer, ref computacion, _kernelforPrintPointer, PositionPointerX, PositionPointerY,(int) timeNow); 
    
                    ///////////////////////////////////
                    // Paint letter
                    ///////////////////////////////////        
                    paintNumberFromTextureIndividualWriteTextField(ref computacion, _kernelforPrintTilesNumberIndividualWriteTextField, _PositionX, _PositionY, 1, 4);
                    ///////////////////////////////////
                    // Paint letter
                    ///////////////////////////////////
    
    
                    _XaxisTextField -= CHARACTERWIDTH;
                    StringTextField += "‘";
    
                }    

                if(Input.GetKeyUp(KeyCode.Slash) && shiftKey == true)
                {
                    int _PositionX = _XaxisTextField;
                    int _PositionY = _YaxisTextField;

                    paintPointerPositionBlack(ref computacion, _kernelforPrintPointerBlack, PositionPointerX, PositionPointerY); 
                    PositionPointerX -= 34;
                    paintPointerPosition(ref bufferColorPointer, ref computacion, _kernelforPrintPointer, PositionPointerX, PositionPointerY,(int) timeNow); 
    
                    ///////////////////////////////////
                    // Paint letter
                    ///////////////////////////////////        
                    paintNumberFromTextureIndividualWriteTextField(ref computacion, _kernelforPrintTilesNumberIndividualWriteTextField, _PositionX, _PositionY, 2, 4);
                    ///////////////////////////////////
                    // Paint letter
                    ///////////////////////////////////
    
    
                    _XaxisTextField -= CHARACTERWIDTH;
                    StringTextField += "?";
    
                }    

                if(Input.GetKeyUp(KeyCode.Alpha1) && shiftKey == true)
                {
                    int _PositionX = _XaxisTextField;
                    int _PositionY = _YaxisTextField;

                    paintPointerPositionBlack(ref computacion, _kernelforPrintPointerBlack, PositionPointerX, PositionPointerY); 
                    PositionPointerX -= 34;
                    paintPointerPosition(ref bufferColorPointer, ref computacion, _kernelforPrintPointer, PositionPointerX, PositionPointerY,(int) timeNow); 
    
                    ///////////////////////////////////
                    // Paint letter
                    ///////////////////////////////////        
                    paintNumberFromTextureIndividualWriteTextField(ref computacion, _kernelforPrintTilesNumberIndividualWriteTextField, _PositionX, _PositionY, 3, 4);
                    ///////////////////////////////////
                    // Paint letter
                    ///////////////////////////////////
    
    
                    _XaxisTextField -= CHARACTERWIDTH;
                    StringTextField += "!";
    
                }    

                if(Input.GetKeyUp(KeyCode.Comma) && shiftKey == false)
                {
                    int _PositionX = _XaxisTextField;
                    int _PositionY = _YaxisTextField;

                    paintPointerPositionBlack(ref computacion, _kernelforPrintPointerBlack, PositionPointerX, PositionPointerY); 
                    PositionPointerX -= 34;
                    paintPointerPosition(ref bufferColorPointer, ref computacion, _kernelforPrintPointer, PositionPointerX, PositionPointerY,(int) timeNow); 
    
                    ///////////////////////////////////
                    // Paint letter
                    ///////////////////////////////////        
                    paintNumberFromTextureIndividualWriteTextField(ref computacion, _kernelforPrintTilesNumberIndividualWriteTextField, _PositionX, _PositionY, 0, 5);
                    ///////////////////////////////////
                    // Paint letter
                    ///////////////////////////////////
    
    
                    _XaxisTextField -= CHARACTERWIDTH;
                    StringTextField += ",";
    
                }


                if(Input.GetKeyUp(KeyCode.Period) && shiftKey == false)
                {
                    int _PositionX = _XaxisTextField;
                    int _PositionY = _YaxisTextField;

                    paintPointerPositionBlack(ref computacion, _kernelforPrintPointerBlack, PositionPointerX, PositionPointerY); 
                    PositionPointerX -= 34;
                    paintPointerPosition(ref bufferColorPointer, ref computacion, _kernelforPrintPointer, PositionPointerX, PositionPointerY,(int) timeNow); 
    
                    ///////////////////////////////////
                    // Paint letter
                    ///////////////////////////////////        
                    paintNumberFromTextureIndividualWriteTextField(ref computacion, _kernelforPrintTilesNumberIndividualWriteTextField, _PositionX, _PositionY, 1, 5);
                    ///////////////////////////////////
                    // Paint letter
                    ///////////////////////////////////
    
    
                    _XaxisTextField -= CHARACTERWIDTH;
                    StringTextField += ".";
    
                }



                if(Input.GetKeyUp(KeyCode.Period) && shiftKey == true)
                {
                    
                    int _PositionX = _XaxisTextField;
                    int _PositionY = _YaxisTextField;

                    paintPointerPositionBlack(ref computacion, _kernelforPrintPointerBlack, PositionPointerX, PositionPointerY); 
                    PositionPointerX -= 34;
                    paintPointerPosition(ref bufferColorPointer, ref computacion, _kernelforPrintPointer, PositionPointerX, PositionPointerY,(int) timeNow); 
    
                    ///////////////////////////////////
                    // Paint letter
                    ///////////////////////////////////        
                    paintNumberFromTextureIndividualWriteTextField(ref computacion, _kernelforPrintTilesNumberIndividualWriteTextField, _PositionX, _PositionY, 2, 5);
                    ///////////////////////////////////
                    // Paint letter
                    ///////////////////////////////////
    
    
                    _XaxisTextField -= CHARACTERWIDTH;
                    StringTextField += ":";
    
                }

                if(Input.GetKeyUp(KeyCode.Comma) && shiftKey == true)
                {

                    int _PositionX = _XaxisTextField;
                    int _PositionY = _YaxisTextField;

                    paintPointerPositionBlack(ref computacion, _kernelforPrintPointerBlack, PositionPointerX, PositionPointerY); 
                    PositionPointerX -= 34;
                    paintPointerPosition(ref bufferColorPointer, ref computacion, _kernelforPrintPointer, PositionPointerX, PositionPointerY,(int) timeNow); 
    
                    ///////////////////////////////////
                    // Paint letter
                    ///////////////////////////////////        
                    paintNumberFromTextureIndividualWriteTextField(ref computacion, _kernelforPrintTilesNumberIndividualWriteTextField, _PositionX, _PositionY, 3, 5);
                    ///////////////////////////////////
                    // Paint letter
                    ///////////////////////////////////
    
    
                    _XaxisTextField -= CHARACTERWIDTH;
                    StringTextField += ";";
    
                }

            }

    }





}

}






