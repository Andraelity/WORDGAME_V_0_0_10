using System.Collections;
using System.Collections.Generic;
using System;
using System.IO;

using UnityEngine;
using UnityEngine.SceneManagement;

using C0CS_WordGame;


namespace CS_classObject
{

public class rowContainer
{

    public List<string> listOfWords;
    public List<int> listOfPosition;
    public float speed;
    public float ratioTime;
    public int Yaxis;
    public bool stateAdd;
    public int countWord;
    public int seed;    


    public bool stateFind = false;

    public rowContainer()
    {

    }

    public rowContainer(float componentSpeed, float componentRatioTime, int componentYaxis, int componentSeed)
    {

        this.listOfWords = new List<string>();
        this.listOfPosition = new List<int>();
        this.speed = componentSpeed;
        this.ratioTime = componentRatioTime;
        this.Yaxis = componentYaxis;
        this.stateAdd = true;
        this.countWord = 0;
        this.seed = componentSeed;

    }

    public rowContainer(rowContainer obj)
    {

        this.listOfWords = obj.listOfWords;
        this.listOfPosition = obj.listOfPosition;
        this.speed = obj.speed;
        this.ratioTime = obj.ratioTime;
        this.Yaxis = obj.Yaxis;
        this.stateAdd = obj.stateAdd;
        this.countWord = obj.countWord;
        this.seed = obj.seed;
    }

    public void addWord()
    {

        float timeRowContainer = Time.realtimeSinceStartup;

        System.Random aleatorioElemento = new System.Random((int) (timeRowContainer * timeRowContainer) * this.seed);

        int sizeList = C0CS_WordGame_V_0_0_10.listOfString_CopyShuffle.Count;

        string newWord = C0CS_WordGame_V_0_0_10.listOfString_CopyShuffle[aleatorioElemento.Next(0,sizeList)];

        // Debug.Log(newWord);

        this.listOfWords.Add(newWord);
        this.listOfPosition.Add(0);

        this.countWord++;

        // Debug.Log("COUNTWORD");
        // Debug.Log(this.countWord);
    }

    public void addWordRandom()
    {

        float timeRowContainer = Time.realtimeSinceStartup;

        System.Random aleatorioElemento = new System.Random((int) (timeRowContainer * timeRowContainer) * this.seed);

        int sizeList = C0CS_WordGame_V_0_0_10.listOfString_CopyShuffle.Count;


        // Debug.Log(newWord);
        



        byte byteType_position = (byte)aleatorioElemento.Next(0,50);

        if(byteType_position < 28)
        {

            string newWord = C0CS_WordGame_V_0_0_10.listOfString_CopyShuffle[aleatorioElemento.Next(0,sizeList)];

            this.listOfWords.Add(newWord);
            this.listOfPosition.Add(byteType_position);
            this.countWord++;

        }
        else
        {

            string newWord = C0CS_WordGame_V_0_0_10.listOfString_CopyShuffle[aleatorioElemento.Next(0,sizeList)];

            this.listOfWords.Add(newWord);
            this.listOfPosition.Add(byteType_position);
            this.countWord++;
            
            newWord = C0CS_WordGame_V_0_0_10.listOfString_CopyShuffle[aleatorioElemento.Next(0,sizeList)];            

            byteType_position -= 28;


            this.listOfWords.Add(newWord);
            this.listOfPosition.Add(byteType_position);
            this.countWord++;
        }


        // Debug.Log("COUNTWORD");
        // Debug.Log(this.countWord);
    }


    public int countOfWords()
    {
        return this.listOfWords.Count;
    }    


    public void test28()
    {
        
        if(stateAdd == true)
        {

            for(int i = 0; i < countWord; ++i)
            {
    
                if(this.listOfPosition[i] == 28)
                {
                    
                    stateAdd = false;

                    this.addWord();


                }                
                                
                   
            }


        }

        for(int i = 0; i < countWord; ++i)
        {
    
            if(this.listOfPosition[i] == 29)
            {
            
                stateAdd = true;
            
            }                

        }

    }


    public void test70()
    {

        for(int i = 0; i < countWord; ++i)
        {

            if(this.listOfPosition[i] == 70)
            {
                
                this.listOfPosition.RemoveAt(i);
                this.listOfWords.RemoveAt(i);
                this.countWord--;
            }                            
               
        }

    }

    public List<int> findWordLPY(string word)
    {

        // Input
        string containerWord = word;

        List<int> containerListOfInt = new List<int>();

        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////
        //  ALGORYTHM
        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////


        for(int i = 0; i < countWord; ++i)
        {

            if(this.listOfWords[i] == containerWord)
            {
                containerListOfInt.Add(containerWord.Length);
                containerListOfInt.Add(listOfPosition[i]);
                containerListOfInt.Add(this.Yaxis);

                listOfWords.RemoveAt(i);
                listOfPosition.RemoveAt(i);

                this.setStateFind_true();
                countWord--;
                break;
            }

        }


        return containerListOfInt;
    
    }

    public void setStateFind_false()
    {

        this.stateFind = false;

    }
    
    public void setStateFind_true()
    {

        this.stateFind = true;

    }

    public void printWholeObject()
    {

        for(int i = 0 ; i < listOfWords.Count; ++i)
        {
            Debug.Log(listOfWords[i]);
    
        }
        
        for(int i = 0 ; i < listOfPosition.Count; ++i)
        {
            Debug.Log(listOfPosition[i].ToString());
    
        }
    
        Debug.Log(speed);
        Debug.Log(ratioTime);
        Debug.Log(Yaxis);
        Debug.Log(stateAdd);
        Debug.Log(countWord);
        Debug.Log(seed);    
        Debug.Log(stateFind);

    }

}

}
