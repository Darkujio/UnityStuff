using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;

//[ExecuteInEditMode]
public class MainScript : MonoBehaviour
{
    [SerializeField]
    [Range(0,6)]
    private int Slot1_1;
    [SerializeField]
    [Range(0,6)]
    private int Slot1_2;
    [SerializeField]
    [Range(0,6)]
    private int Slot1_3;
    [SerializeField]
    [Range(0,6)]
    private int Slot1_4;

    [Space(30)]
    [SerializeField]
    [Range(0,6)]
    private int Slot2_1;
    [SerializeField]
    [Range(0,6)]
    private int Slot2_2;
    [SerializeField]
    [Range(0,6)]
    private int Slot2_3;
    [SerializeField]
    [Range(0,6)]
    private int Slot2_4;
    
    [Space(30)]
    [SerializeField]
    [Range(0,6)]
    private int Slot3_1;
    [SerializeField]
    [Range(0,6)]
    private int Slot3_2;
    [SerializeField]
    [Range(0,6)]
    private int Slot3_3;
    [SerializeField]
    [Range(0,6)]
    private int Slot3_4;
    
    [Space(30)]
    [SerializeField]
    [Range(0,6)]
    private int Slot4_1;
    [SerializeField]
    [Range(0,6)]
    private int Slot4_2;
    [SerializeField]
    [Range(0,6)]
    private int Slot4_3;
    [SerializeField]
    [Range(0,6)]
    private int Slot4_4;
    
    [Space(30)]
    [SerializeField]
    [Range(0,6)]
    private int Slot5_1;
    [SerializeField]
    [Range(0,6)]
    private int Slot5_2;
    [SerializeField]
    [Range(0,6)]
    private int Slot5_3;
    [SerializeField]
    [Range(0,6)]
    private int Slot5_4;
    
    //[Space(30)]
    //[SerializeField]
    [Range(0,6)]
    private int Slot6_1;
    //[SerializeField]
    [Range(0,6)]
    private int Slot6_2;
    //[SerializeField]
    [Range(0,6)]
    private int Slot6_3;
    //[SerializeField]
    [Range(0,6)]
    private int Slot6_4;
    
    //[Space(30)]
    //[SerializeField]
    [Range(0,6)]
    private int Slot7_1;
    //[SerializeField]
    [Range(0,6)]
    private int Slot7_2;
    //[SerializeField]
    [Range(0,6)]
    private int Slot7_3;
    //[SerializeField]
    [Range(0,6)]
    private int Slot7_4;
    
    //[Space(30)]
    //[SerializeField]
    [Range(0,6)]
    private int Slot8_1;
    //[SerializeField]
    [Range(0,6)]
    private int Slot8_2;
    //[SerializeField]
    [Range(0,6)]
    private int Slot8_3;
    //[SerializeField]
    [Range(0,6)]
    private int Slot8_4;



    private GameObject FoodSlot1_1;
    private GameObject FoodSlot1_2;
    private GameObject FoodSlot1_3;
    private GameObject FoodSlot1_4;

    private GameObject FoodSlot2_1;
    private GameObject FoodSlot2_2;
    private GameObject FoodSlot2_3;
    private GameObject FoodSlot2_4;

    private GameObject FoodSlot3_1;
    private GameObject FoodSlot3_2;
    private GameObject FoodSlot3_3;
    private GameObject FoodSlot3_4;

    private GameObject FoodSlot4_1;
    private GameObject FoodSlot4_2;
    private GameObject FoodSlot4_3;
    private GameObject FoodSlot4_4;

    private GameObject FoodSlot5_1;
    private GameObject FoodSlot5_2;
    private GameObject FoodSlot5_3;
    private GameObject FoodSlot5_4;

    private GameObject FoodSlot6_1;
    private GameObject FoodSlot6_2;
    private GameObject FoodSlot6_3;
    private GameObject FoodSlot6_4;

    private GameObject FoodSlot7_1;
    private GameObject FoodSlot7_2;
    private GameObject FoodSlot7_3;
    private GameObject FoodSlot7_4;

    private GameObject FoodSlot8_1;
    private GameObject FoodSlot8_2;
    private GameObject FoodSlot8_3;
    private GameObject FoodSlot8_4;

    private GameObject FoodSlot;
    private Animator anim;

    private int[,] BoxList = new int[8,4];
    private int[,] BoxList1Back = new int[8,4];
    private int[,] BoxList2Back = new int[8,4];
    private int[,] BoxList3Back = new int[8,4];
    private int[,] BoxList4Back = new int[8,4];
    private int[,] BoxList5Back = new int[8,4];

    private int RewindCount = 5;

    private bool FirstClick = true;
    private int FromBox;
    private int ToBox;
    public SpriteRenderer Rewinder;

    //private InterstitialAd interstitial;

    private void Start()
    {
        FoodSlot1_1 = GameObject.Find("FoodSlot1_1");
        BoxList[0,0] = Slot1_1;
        FoodSlot1_1.SendMessage("ChangeFruit",BoxList[0,0]);

        FoodSlot1_2 = GameObject.Find("FoodSlot1_2");
        BoxList[0,1] = Slot1_2;
        FoodSlot1_2.SendMessage("ChangeFruit",BoxList[0,1]);

        FoodSlot1_3 = GameObject.Find("FoodSlot1_3");
        BoxList[0,2] = Slot1_3;
        FoodSlot1_3.SendMessage("ChangeFruit",BoxList[0,2]);

        FoodSlot1_4 = GameObject.Find("FoodSlot1_4");
        BoxList[0,3] = Slot1_4;
        FoodSlot1_4.SendMessage("ChangeFruit",BoxList[0,3]);


        FoodSlot2_1 = GameObject.Find("FoodSlot2_1");
        BoxList[1,0] = Slot2_1;
        FoodSlot2_1.SendMessage("ChangeFruit",BoxList[1,0]);

        FoodSlot2_2 = GameObject.Find("FoodSlot2_2");
        BoxList[1,1] = Slot2_2;
        FoodSlot2_2.SendMessage("ChangeFruit",BoxList[1,1]);

        FoodSlot2_3 = GameObject.Find("FoodSlot2_3");
        BoxList[1,2] = Slot2_3;
        FoodSlot2_3.SendMessage("ChangeFruit",BoxList[1,2]);

        FoodSlot2_4 = GameObject.Find("FoodSlot2_4");
        BoxList[1,3] = Slot2_4;
        FoodSlot2_4.SendMessage("ChangeFruit",BoxList[1,3]);


        FoodSlot3_1 = GameObject.Find("FoodSlot3_1");
        BoxList[2,0] = Slot3_1;
        FoodSlot3_1.SendMessage("ChangeFruit",BoxList[2,0]);

        FoodSlot3_2 = GameObject.Find("FoodSlot3_2");
        BoxList[2,1] = Slot3_2;
        FoodSlot3_2.SendMessage("ChangeFruit",BoxList[2,1]);

        FoodSlot3_3 = GameObject.Find("FoodSlot3_3");
        BoxList[2,2] = Slot3_3;
        FoodSlot3_3.SendMessage("ChangeFruit",BoxList[2,2]);

        FoodSlot3_4 = GameObject.Find("FoodSlot3_4");
        BoxList[2,3] = Slot3_4;
        FoodSlot3_4.SendMessage("ChangeFruit",BoxList[2,3]);


        FoodSlot4_1 = GameObject.Find("FoodSlot4_1");
        BoxList[3,0] = Slot4_1;
        FoodSlot4_1.SendMessage("ChangeFruit",BoxList[3,0]);

        FoodSlot4_2 = GameObject.Find("FoodSlot4_2");
        BoxList[3,1] = Slot4_2;
        FoodSlot4_2.SendMessage("ChangeFruit",BoxList[3,1]);

        FoodSlot4_3 = GameObject.Find("FoodSlot4_3");
        BoxList[3,2] = Slot4_3;
        FoodSlot4_3.SendMessage("ChangeFruit",BoxList[3,2]);

        FoodSlot4_4 = GameObject.Find("FoodSlot4_4");
        BoxList[3,3] = Slot4_4;
        FoodSlot4_4.SendMessage("ChangeFruit",BoxList[3,3]);


        FoodSlot5_1 = GameObject.Find("FoodSlot5_1");
        BoxList[4,0] = Slot5_1;
        FoodSlot5_1.SendMessage("ChangeFruit",BoxList[4,0]);

        FoodSlot5_2 = GameObject.Find("FoodSlot5_2");
        BoxList[4,1] = Slot5_2;
        FoodSlot5_2.SendMessage("ChangeFruit",BoxList[4,1]);

        FoodSlot5_3 = GameObject.Find("FoodSlot5_3");
        BoxList[4,2] = Slot5_3;
        FoodSlot5_3.SendMessage("ChangeFruit",BoxList[4,2]);

        FoodSlot5_4 = GameObject.Find("FoodSlot5_4");
        BoxList[4,3] = Slot5_4;
        FoodSlot5_4.SendMessage("ChangeFruit",BoxList[4,3]);


        FoodSlot6_1 = GameObject.Find("FoodSlot6_1");
        BoxList[5,0] = Slot6_1;
        FoodSlot6_1.SendMessage("ChangeFruit",BoxList[5,0]);

        FoodSlot6_2 = GameObject.Find("FoodSlot6_2");
        BoxList[5,1] = Slot6_2;
        FoodSlot6_2.SendMessage("ChangeFruit",BoxList[5,1]);

        FoodSlot6_3 = GameObject.Find("FoodSlot6_3");
        BoxList[5,2] = Slot6_3;
        FoodSlot6_3.SendMessage("ChangeFruit",BoxList[5,2]);

        FoodSlot6_4 = GameObject.Find("FoodSlot6_4");
        BoxList[5,3] = Slot6_4;
        FoodSlot6_4.SendMessage("ChangeFruit",BoxList[5,3]);


        FoodSlot7_1 = GameObject.Find("FoodSlot7_1");
        BoxList[6,0] = Slot7_1;
        FoodSlot7_1.SendMessage("ChangeFruit",BoxList[6,0]);

        FoodSlot7_2 = GameObject.Find("FoodSlot7_2");
        BoxList[6,1] = Slot7_2;
        FoodSlot7_2.SendMessage("ChangeFruit",BoxList[6,1]);

        FoodSlot7_3 = GameObject.Find("FoodSlot7_3");
        BoxList[6,2] = Slot7_3;
        FoodSlot7_3.SendMessage("ChangeFruit",BoxList[6,2]);

        FoodSlot7_4 = GameObject.Find("FoodSlot7_4");
        BoxList[6,3] = Slot7_4;
        FoodSlot7_4.SendMessage("ChangeFruit",BoxList[6,3]);


        FoodSlot8_1 = GameObject.Find("FoodSlot8_1");
        BoxList[7,0] = Slot8_1;
        FoodSlot8_1.SendMessage("ChangeFruit",BoxList[7,0]);

        FoodSlot8_2 = GameObject.Find("FoodSlot8_2");
        BoxList[7,1] = Slot8_2;
        FoodSlot8_2.SendMessage("ChangeFruit",BoxList[7,1]);

        FoodSlot8_3 = GameObject.Find("FoodSlot8_3");
        BoxList[7,2] = Slot8_3;
        FoodSlot8_3.SendMessage("ChangeFruit",BoxList[7,2]);

        FoodSlot8_4 = GameObject.Find("FoodSlot8_4");
        BoxList[7,3] = Slot8_4;
        FoodSlot8_4.SendMessage("ChangeFruit",BoxList[7,3]);

        foreach (int value1 in Enumerable.Range(0, 7))
            {
                foreach (int value2 in Enumerable.Range(0, 3))
                {
                    BoxList5Back[value1,value2] = Convert.ToInt32(BoxList[value1,value2]);
                    BoxList4Back[value1,value2] = Convert.ToInt32(BoxList[value1,value2]);
                    BoxList3Back[value1,value2] = Convert.ToInt32(BoxList[value1,value2]);
                    BoxList2Back[value1,value2] = Convert.ToInt32(BoxList[value1,value2]);
                    BoxList1Back[value1,value2] = Convert.ToInt32(BoxList[value1,value2]);
                }
            }
    }

    private void UpadateVisual()
    {
        FoodSlot1_1.SendMessage("ChangeFruit",BoxList[0,0]);

        FoodSlot1_2.SendMessage("ChangeFruit",BoxList[0,1]);

        FoodSlot1_3.SendMessage("ChangeFruit",BoxList[0,2]);

        FoodSlot1_4.SendMessage("ChangeFruit",BoxList[0,3]);

        
        FoodSlot2_1.SendMessage("ChangeFruit",BoxList[1,0]);

        FoodSlot2_2.SendMessage("ChangeFruit",BoxList[1,1]);

        FoodSlot2_3.SendMessage("ChangeFruit",BoxList[1,2]);

        FoodSlot2_4.SendMessage("ChangeFruit",BoxList[1,3]);


        FoodSlot3_1.SendMessage("ChangeFruit",BoxList[2,0]);

        FoodSlot3_2.SendMessage("ChangeFruit",BoxList[2,1]);

        FoodSlot3_3.SendMessage("ChangeFruit",BoxList[2,2]);

        FoodSlot3_4.SendMessage("ChangeFruit",BoxList[2,3]);


        FoodSlot4_1.SendMessage("ChangeFruit",BoxList[3,0]);

        FoodSlot4_2.SendMessage("ChangeFruit",BoxList[3,1]);

        FoodSlot4_3.SendMessage("ChangeFruit",BoxList[3,2]);

        FoodSlot4_4.SendMessage("ChangeFruit",BoxList[3,3]);


        FoodSlot5_1.SendMessage("ChangeFruit",BoxList[4,0]);

        FoodSlot5_2.SendMessage("ChangeFruit",BoxList[4,1]);

        FoodSlot5_3.SendMessage("ChangeFruit",BoxList[4,2]);

        FoodSlot5_4.SendMessage("ChangeFruit",BoxList[4,3]);


        FoodSlot6_1.SendMessage("ChangeFruit",BoxList[5,0]);

        FoodSlot6_2.SendMessage("ChangeFruit",BoxList[5,1]);

        FoodSlot6_3.SendMessage("ChangeFruit",BoxList[5,2]);

        FoodSlot6_4.SendMessage("ChangeFruit",BoxList[5,3]);


        FoodSlot7_1.SendMessage("ChangeFruit",BoxList[6,0]);

        FoodSlot7_2.SendMessage("ChangeFruit",BoxList[6,1]);

        FoodSlot7_3.SendMessage("ChangeFruit",BoxList[6,2]);

        FoodSlot7_4.SendMessage("ChangeFruit",BoxList[6,3]);


        FoodSlot8_1.SendMessage("ChangeFruit",BoxList[7,0]);

        FoodSlot8_2.SendMessage("ChangeFruit",BoxList[7,1]);

        FoodSlot8_3.SendMessage("ChangeFruit",BoxList[7,2]);

        FoodSlot8_4.SendMessage("ChangeFruit",BoxList[7,3]);
    }

    //Animation Cycle
    private void Animate(int BoxNumber, int SlotNumber)
    {
        FoodSlot = GameObject.Find($"FoodSlot{BoxNumber+1}_{SlotNumber+1}");
        anim = FoodSlot.GetComponent<Animator>();
        anim.Play("AnimationWork", -1);
    }

    private void UnAnimate(int BoxNumber, int SlotNumber)
    {
        FoodSlot = GameObject.Find($"FoodSlot{BoxNumber+1}_{SlotNumber+1}");
        anim = FoodSlot.GetComponent<Animator>();
        anim.Play("AnimationStatic", -1);
    }
    //Animation Cycle End

    public void ClickHandling(int BoxNumber)
    {
        //FirstClick(FromTarget)
        if (FirstClick)
        {
            if (BoxList[BoxNumber,0] != 0)
            {
                FromBox = BoxNumber;
                FirstClick = !FirstClick;
                int CurrentNumber = 0;
                int x = 3;
                while (CurrentNumber == 0 && x>-1)
                {
                    CurrentNumber = BoxList[BoxNumber,x];
                    x -= 1;
                }
                x+=1;
                Animate(BoxNumber,x);
            }
        }



        //SecondClick(ToTarget)
        else 
        {
            if (BoxList[BoxNumber,0] == 0)
            {
                ToBox = BoxNumber;
                FirstClick = !FirstClick;
                int CurrentSenderNumber = 0;
                int y = 3;
                while (CurrentSenderNumber == 0 && y>-1)
                {
                    CurrentSenderNumber = BoxList[FromBox,y];
                    y -= 1;
                }
                y+=1;
                UnAnimate(FromBox,y);
                Swap_Place(FromBox,ToBox);
            }
            else
            {
                //Get Last Item In Target
                int CurrentNumber = 0;
                int x = 3;
                while (CurrentNumber == 0 && x>-1)
                {
                    CurrentNumber = BoxList[BoxNumber,x];
                    x -= 1;
                }
                x+=1;

                //Get Last Item In Sender
                int CurrentSenderNumber = 0;
                int y = 3;
                while (CurrentSenderNumber == 0 && y>-1)
                {
                    CurrentSenderNumber = BoxList[FromBox,y];
                    y -= 1;
                }
                y+=1;

                //Check If Target And Sender are equal and send reqest for translocation
                if (CurrentNumber == CurrentSenderNumber && x!=3)
                {
                    ToBox = BoxNumber;
                    UnAnimate(FromBox,y);
                    Swap_Place(FromBox,ToBox);
                    FirstClick = !FirstClick;
                }
                else 
                {
                    print("WrongBox");
                    UnAnimate(FromBox,y);
                    FirstClick = !FirstClick;
                }
            }
        }
    }

    private void Swap_Place(int FoodBoxFrom, int FoodBoxTo)
    {
        UnDoSetup();
        //Delete From Sender
        int SendedFruit;
        int x = 3;
        while (BoxList[FoodBoxFrom,x] == 0)
        {
            x-=1;
        }
        SendedFruit = BoxList[FoodBoxFrom,x];
        BoxList[FoodBoxFrom,x] = 0;

        //Add to Target
        if (BoxList[FoodBoxTo,0] != 0)
        {
            x = 3;
            while (BoxList[FoodBoxTo,x] == 0)
            {
                x-=1;
            }
            x += 1;
            BoxList[FoodBoxTo,x] = SendedFruit;
        }
        else
        {
            BoxList[FoodBoxTo,0] = SendedFruit;
        }
        CompleteCheck(FoodBoxTo);
        UpadateVisual();
    }

    private void UnDoSetup()
    {
        if (RewindCount == 5)
        {
            foreach (int value1 in Enumerable.Range(0, 7))
            {
                foreach (int value2 in Enumerable.Range(0, 3))
                {
                    BoxList5Back[value1,value2] = Convert.ToInt32(BoxList4Back[value1,value2]);
                    BoxList4Back[value1,value2] = Convert.ToInt32(BoxList3Back[value1,value2]);
                    BoxList3Back[value1,value2] = Convert.ToInt32(BoxList2Back[value1,value2]);
                    BoxList2Back[value1,value2] = Convert.ToInt32(BoxList1Back[value1,value2]);
                    BoxList1Back[value1,value2] = Convert.ToInt32(BoxList[value1,value2]);
                }
            }
        }
        else if (RewindCount == 4)
        {
            foreach (int value1 in Enumerable.Range(0, 7))
            {
                foreach (int value2 in Enumerable.Range(0, 3))
                {
                    BoxList5Back[value1,value2] = Convert.ToInt32(BoxList4Back[value1,value2]);
                    BoxList4Back[value1,value2] = Convert.ToInt32(BoxList3Back[value1,value2]);
                    BoxList3Back[value1,value2] = Convert.ToInt32(BoxList2Back[value1,value2]);
                    BoxList2Back[value1,value2] = Convert.ToInt32(BoxList[value1,value2]);
                }
            }
        }
        else if (RewindCount == 3)
        {
            foreach (int value1 in Enumerable.Range(0, 7))
            {
                foreach (int value2 in Enumerable.Range(0, 3))
                {
                    BoxList5Back[value1,value2] = Convert.ToInt32(BoxList4Back[value1,value2]);
                    BoxList4Back[value1,value2] = Convert.ToInt32(BoxList3Back[value1,value2]);
                    BoxList3Back[value1,value2] = Convert.ToInt32(BoxList[value1,value2]);
                }
            }
        }
        else if (RewindCount == 2)
        {
            foreach (int value1 in Enumerable.Range(0, 7))
            {
                foreach (int value2 in Enumerable.Range(0, 3))
                {
                    BoxList5Back[value1,value2] = Convert.ToInt32(BoxList4Back[value1,value2]);
                    BoxList4Back[value1,value2] = Convert.ToInt32(BoxList[value1,value2]);
                }
            }
        }
        else if (RewindCount == 2)
        {
            foreach (int value1 in Enumerable.Range(0, 7))
            {
                foreach (int value2 in Enumerable.Range(0, 3))
                {
                    BoxList5Back[value1,value2] = Convert.ToInt32(BoxList[value1,value2]);
                }
            }
        }

    }

    public void UnDo()
    {
        print("here");
        if (RewindCount == 5)
        {
            BoxList = BoxList1Back;
            UpadateVisual();
            RewindCount -= 1;
        }
        else if (RewindCount == 4)
        {
            BoxList = BoxList2Back;
            UpadateVisual();
            RewindCount -= 1;
        }
        else if (RewindCount == 3)
        {
            BoxList = BoxList3Back;
            UpadateVisual();
            RewindCount -= 1;
        }
        else if (RewindCount == 2)
        {
            BoxList = BoxList4Back;
            UpadateVisual();
            RewindCount -= 1;
        }
        else if (RewindCount == 1)
        {
            BoxList = BoxList5Back;
            UpadateVisual();
            RewindCount -= 1;
            Rewinder.color = new Color(0.5f, 0.5f, 0.5f, 1);
        }
    }

    private void CompleteCheck(int FoodBoxTo)
    {
        if (BoxList[FoodBoxTo,0] == BoxList[FoodBoxTo,1] && BoxList[FoodBoxTo,1] == BoxList[FoodBoxTo,2] && BoxList[FoodBoxTo,2] == BoxList[FoodBoxTo,3] && BoxList[FoodBoxTo,3] != 0)
        {
            foreach (int value1 in Enumerable.Range(0, 7))
            {
                foreach (int value2 in Enumerable.Range(0, 3))
                {
                    BoxList5Back[value1,value2] = Convert.ToInt32(BoxList[value1,value2]);
                    BoxList4Back[value1,value2] = Convert.ToInt32(BoxList[value1,value2]);
                    BoxList3Back[value1,value2] = Convert.ToInt32(BoxList[value1,value2]);
                    BoxList2Back[value1,value2] = Convert.ToInt32(BoxList[value1,value2]);
                    BoxList1Back[value1,value2] = Convert.ToInt32(BoxList[value1,value2]);
                }
            }
            if (FoodBoxTo == 0)
            {
                FoodSlot1_1.GetComponent<Renderer>().enabled = false;
                FoodSlot1_2.GetComponent<Renderer>().enabled = false;
                FoodSlot1_3.GetComponent<Renderer>().enabled = false;
                FoodSlot1_4.GetComponent<Renderer>().enabled = false;
                GameObject BoxSlot1 = GameObject.Find("BoxSlot1");
                BoxSlot1.SetActive(false);
            }
            else if (FoodBoxTo == 1)
            {
                FoodSlot2_1.GetComponent<Renderer>().enabled = false;
                FoodSlot2_2.GetComponent<Renderer>().enabled = false;
                FoodSlot2_3.GetComponent<Renderer>().enabled = false;
                FoodSlot2_4.GetComponent<Renderer>().enabled = false;
                GameObject BoxSlot2 = GameObject.Find("BoxSlot2");
                BoxSlot2.SetActive(false);
            }
            else if (FoodBoxTo == 2)
            {
                FoodSlot3_1.GetComponent<Renderer>().enabled = false;
                FoodSlot3_2.GetComponent<Renderer>().enabled = false;
                FoodSlot3_3.GetComponent<Renderer>().enabled = false;
                FoodSlot3_4.GetComponent<Renderer>().enabled = false;
                GameObject BoxSlot3 = GameObject.Find("BoxSlot3");
                BoxSlot3.SetActive(false);
            }
            else if (FoodBoxTo == 3)
            {
                FoodSlot4_1.GetComponent<Renderer>().enabled = false;
                FoodSlot4_2.GetComponent<Renderer>().enabled = false;
                FoodSlot4_3.GetComponent<Renderer>().enabled = false;
                FoodSlot4_4.GetComponent<Renderer>().enabled = false;
                GameObject BoxSlot4 = GameObject.Find("BoxSlot4");
                BoxSlot4.SetActive(false);
            }
            else if (FoodBoxTo == 4)
            {
                FoodSlot5_1.GetComponent<Renderer>().enabled = false;
                FoodSlot5_2.GetComponent<Renderer>().enabled = false;
                FoodSlot5_3.GetComponent<Renderer>().enabled = false;
                FoodSlot5_4.GetComponent<Renderer>().enabled = false;
                GameObject BoxSlot5 = GameObject.Find("BoxSlot5");
                BoxSlot5.SetActive(false);
            }
            else if (FoodBoxTo == 5)
            {
                FoodSlot6_1.GetComponent<Renderer>().enabled = false;
                FoodSlot6_2.GetComponent<Renderer>().enabled = false;
                FoodSlot6_3.GetComponent<Renderer>().enabled = false;
                FoodSlot6_4.GetComponent<Renderer>().enabled = false;
                GameObject BoxSlot6 = GameObject.Find("BoxSlot6");
                BoxSlot6.SetActive(false);
            }
            else if (FoodBoxTo == 6)
            {
                FoodSlot7_1.GetComponent<Renderer>().enabled = false;
                FoodSlot7_2.GetComponent<Renderer>().enabled = false;
                FoodSlot7_3.GetComponent<Renderer>().enabled = false;
                FoodSlot7_4.GetComponent<Renderer>().enabled = false;
                GameObject BoxSlot7 = GameObject.Find("BoxSlot7");
                BoxSlot7.SetActive(false);
            }
            else if (FoodBoxTo == 7)
            {
                FoodSlot8_1.GetComponent<Renderer>().enabled = false;
                FoodSlot8_2.GetComponent<Renderer>().enabled = false;
                FoodSlot8_3.GetComponent<Renderer>().enabled = false;
                FoodSlot8_4.GetComponent<Renderer>().enabled = false;
                GameObject BoxSlot8 = GameObject.Find("BoxSlot8");
                BoxSlot8.SetActive(false);
            }
        }
        int FullCounter = 0;
        foreach (int value1 in Enumerable.Range(0, 8))
        {
            if (BoxList[value1,0] == BoxList[value1,1] && BoxList[value1,1] == BoxList[value1,2] && BoxList[value1,2] == BoxList[value1,3]) FullCounter +=1;
        }
        if (FullCounter == 8)
        {
            GameObject handler = GameObject.Find("NextOrMenu");
            handler.SetActive(true);
            //CHECK PLAYER PREFS on unity if forget
            PlayerPrefs.SetInt("PassedLevels", 1);
        }
    }
}

