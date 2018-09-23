using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using UnityEngine;


public enum Commands
{
    NONE,
    FIRE,
    RELOAD,
    OUTOFAMMO,
    NEXTGUN,
    PREVIOUSGUN,
    SINGLE,
    AUTO
}

public static class FloatHelper {
    static Dictionary<Commands, byte[]> FloatCommands = new Dictionary<Commands, byte[]>
        {
            { Commands.NONE,            new byte[4] { (byte)0x00, (byte)0x00, (byte)0x80, (byte)0xbf } },
            { Commands.FIRE,            new byte[4] { (byte)0xcd, (byte)0xcc, (byte)0xcc, (byte)0x3d } },
            { Commands.RELOAD,          new byte[4] { (byte)0xcd, (byte)0xcc, (byte)0x4c, (byte)0x3e } },
            { Commands.OUTOFAMMO,       new byte[4] { (byte)0xcd, (byte)0xcc, (byte)0xcc, (byte)0x3e } },
            { Commands.NEXTGUN,         new byte[4] { (byte)0x9a, (byte)0x99, (byte)0x19, (byte)0x3f } },
            { Commands.PREVIOUSGUN,     new byte[4] { (byte)0x33, (byte)0x33, (byte)0x33, (byte)0x3f } },
            { Commands.SINGLE,          new byte[4] { (byte)0xcd, (byte)0xcc, (byte)0x4c, (byte)0x3f } },
            { Commands.AUTO,            new byte[4] { (byte)0x66, (byte)0x66, (byte)0x66, (byte)0x3f } },
        };

    
    public static float CommandTofloat(this float f, Commands argcomande)
    {
        return System.BitConverter.ToSingle(FloatCommands[argcomande], 0);
    }

    public static Commands FloatToCommand(this float f)
    {
        return (Commands)Mathf.FloorToInt(f*10);
    }

}


public class FloatBinner : MonoBehaviour {

    int startIndex = 0;
    byte[] mybyteArray;
	// Use this for initialization
    private void Awake()
    {

    }

    float RumbleSpeed = 0.0f;

    void SetVibration(float argfloat) {
        RumbleSpeed = argfloat;
    }

    float GetVibration() {
        return RumbleSpeed;
    }


 

    void Start () {
        //Debug.Log(CommandTofloat(Commands.FIRE));
        //Debug.Log(CommandTofloat(Commands.RELOAD));
        //Debug.Log(CommandTofloat(Commands.OUTOFAMMO));
        //Debug.Log(CommandTofloat(Commands.NEXTGUN));
        //Debug.Log(CommandTofloat(Commands.PREVIOUSGUN));
        //Debug.Log(CommandTofloat(Commands.SINGLE));
        //Debug.Log(CommandTofloat(Commands.AUTO));



        SetVibration(FloatHelper.CommandTofloat( 0.34f, Commands.FIRE));

        Debug.Log( GetVibration().FloatToCommand());
         




        //         00  00  80  BF .1
        //         CD CC  CC  3D .2
        //         CD CC  4C  3E .3
        //         CD CC  CC  3E .4
        //         00  00  00  3F .5
        //          9A  99  19  3F .6
        //         33  33  33  3F .7
        //         CD CC  4C  3F .8
        //         66  66  66  3F .9

        //  working();
        //Debug.Log("--1-------------");

        //FloatToBinary(1f);
        //Debug.Log("----------2-----");
        // Float_to_byteArray(0.1f);
        //Debug.Log("----------3-----");
        //Float_to_byteArray(0.2f);
        //Debug.Log("----------4-----");
        //Float_to_byteArray(0.4f);
        //Debug.Log("----------2-----");
        //Float_to_byteArray(0.5f);
        //Debug.Log("----------2-----");
        //Float_to_byteArray(0.6f);
        //Debug.Log("----------2-----");
        //Float_to_byteArray(0.7f);
        //Debug.Log("----------2-----");
        //Float_to_byteArray(0.8f);
        //Debug.Log("----------2-----");
        //Float_to_byteArray(0.9f);

        //decToHex();
        // JustDoit();
    }

    //make 4 bye array
    byte[] Batch_A = new byte[4];

    // byte OneByte = new byte();
    // show bytes in binary 
    // show bytes in hex
    // show float 


    // flip bit number
    // show bytes in binary 
    // show bytes in hex
    // show float 


    //

    //   0         1    2    3
    //"11110000-11110000-10101010-00000000"


    private void JustDoit(string arg4bytes) 
    {
        byte OneByte0 = new byte();
        byte OneByte1 = new byte();
        byte OneByte2 = new byte();
        byte OneByte3 = new byte();

        OneByte0 = SetBit(OneByte0, 0);
        OneByte0 = SetBit(OneByte0, 1);
        OneByte0 = SetBit(OneByte0, 2);
        OneByte0 = UnsetBit(OneByte0, 3);

        OneByte0 = SetBit(OneByte0, 4);
        OneByte0 = SetBit(OneByte0, 5);
        OneByte0 = UnsetBit(OneByte0, 6);
        OneByte0 = UnsetBit(OneByte0, 7);




        string HEXstr = Convert.ToString(OneByte0, 16);
        print(HEXstr);
        string BINstr = Convert.ToString(OneByte0, 2);
        print(BINstr);
    }






    bool IsBitSet(  byte b, int pos)
    {
        if (pos < 0 || pos > 7)
            throw new ArgumentOutOfRangeException("pos", "Index must be in the range of 0-7.");
        return (b & (1 << pos)) != 0;
    }

      byte SetBit(  byte b, int pos)
    {
        if (pos < 0 || pos > 7)
            throw new ArgumentOutOfRangeException("pos", "Index must be in the range of 0-7.");
        return (byte)(b | (1 << pos));
    }

      byte UnsetBit(  byte b, int pos)
    {
        if (pos < 0 || pos > 7)
            throw new ArgumentOutOfRangeException("pos", "Index must be in the range of 0-7.");
        return (byte)(b & ~(1 << pos));
    }















    void decToHex() {
        int value = 24;
        string binary = Convert.ToString(value, 2);
        print(binary);

        int myInt = 24;
        string myHex = myInt.ToString("X");  // Gives you hexadecimal
        print(myHex);
        int myNewInt = Convert.ToInt32(myHex, 16);  // Back to int again.
        print(myNewInt);
    }


    void working() {
        //  byte[] array = Enumerable.Repeat((byte)0xf0, 4).ToArray();
        // 80  D6  FC  3D  byte[] array = new byte[4] { (byte)0xf0, (byte)0xf0, (byte)0xf0, (byte)0xf0 };
        byte[] array = new byte[4] {
            (byte)0x80,
            (byte)0xd6,
            (byte)0xfc,
            (byte)0x3d };
        //string binStr = FloatToBinary(0.123456789f);
        float pi = 0.123456f;//0.987654321f;// 26535897932384626433832795028841971693993751058209749445923078164062862089986280348253421170679f;
        mybyteArray = BitConverter.GetBytes(pi); // new byte[4];

        float myFloat = System.BitConverter.ToSingle(array, startIndex);
        Debug.Log(myFloat + " " + mybyteArray.Length);
        Debug.Log(array[0].ToString());
        Debug.Log(array[1].ToString());
        Debug.Log(array[2].ToString());
        Debug.Log(array[3].ToString());

    }




    // 0.123456f -> 0 01111011 11111001101011010000000
    //  80  D6  FC  3D 
    string FloatToBinary(float f)
    {
        f *= -1f;
        StringBuilder sb = new StringBuilder();
        Byte[] ba = BitConverter.GetBytes(f);
        LoggerToFile.Instance.Write4BytesHEx(ba);
        foreach (Byte b in ba)
            for (int i = 0; i < 8; i++)
            {
                sb.Insert(0, ((b >> i) & 1) == 1 ? "1" : "0");
            }
        string s = sb.ToString();
        string r = s.Substring(0, 1) + " " + s.Substring(1, 8) + " " + s.Substring(9); //sign exponent mantissa
        Debug.Log(r);
        return r;
    }
    void Float_to_byteArray(float argfloat) {
        Byte[] ba = BitConverter.GetBytes(argfloat);
        LoggerToFile.Instance.Write4BytesHEx(ba);
        foreach (byte b in ba) {
            Debug.Log(b.ToString());
        }
    }
    // Update is called once per frame
    void Update () {
		
	}





    void Float_to_bin_4bytes()
    {
        // Write the float
        var f = 1.23456f;
        var ms = new MemoryStream();
        var writer = new StreamWriter(ms);
        writer.Write(f);
        writer.Flush();

        // Read 4 bytes to get the raw bytes (Ouch!)
        ms.Seek(0, SeekOrigin.Begin);
        var buffer = new char[4];
        var reader = new StreamReader(ms);
        reader.Read(buffer, 0, 4);
        for (int i = 0; i < 4; i++)
        {
            Debug.Log("{0:X2}" + (int)buffer[i]);
        }
        Debug.Log("");
        // This is what you actually read: human readable text
        for (int i = 0; i < buffer.Length; i++)
        {
            Debug.Log(buffer[i]);
        }


        // This is what the float really looks like in memory.
        var bytes = BitConverter.GetBytes(f);
        for (int i = 0; i < bytes.Length; i++)
        {
            Debug.Log("{0:X2}" + (int)bytes[i]);
        }
    }
}
