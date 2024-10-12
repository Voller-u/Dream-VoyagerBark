using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using UnityEngine;

public class Tools
{
    /// <summary>
    /// 加密数据
    /// </summary>
    /// <param name="toE">需要加密的数据内容</param>
    /// <returns></returns>
    public static string Encrypt(string toE)
    {
        byte[] keyArray = UTF8Encoding.UTF8.GetBytes("Kiana.Mei.Bronya.Seele.Theresa..");
        RijndaelManaged rDel = new RijndaelManaged();
        rDel.Key = keyArray;
        rDel.Mode = CipherMode.ECB;
        rDel.Padding = PaddingMode.PKCS7;
        ICryptoTransform cTransform = rDel.CreateEncryptor();

        byte[] toEncryptArray = UTF8Encoding.UTF8.GetBytes(toE);
        byte[] resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);

        return Convert.ToBase64String(resultArray, 0, resultArray.Length);
    }

    /// <summary>
    /// 解密数据
    /// </summary>
    /// <param name="toD">需要解密的数据内容</param>
    /// <returns></returns>
    public static string Decrypt(string toD)
    {
        byte[] keyArray = UTF8Encoding.UTF8.GetBytes("Kiana.Mei.Bronya.Seele.Theresa..");

        RijndaelManaged rDel = new RijndaelManaged();
        rDel.Key = keyArray;
        rDel.Mode = CipherMode.ECB;
        rDel.Padding = PaddingMode.PKCS7;
        ICryptoTransform cTransform = rDel.CreateDecryptor();

        byte[] toEncryptArray = Convert.FromBase64String(toD);
        byte[] resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);

        return UTF8Encoding.UTF8.GetString(resultArray);
    }

    //洗牌
    public static void Shuffle<T>(List<T> array)
    {
        int n = array.Count;

        for (int i = 0; i < n; i++)
        {

            int r = i + UnityEngine.Random.Range(0, n - i);

            T t = array[r];

            array[r] = array[i];

            array[i] = t;

        }
    }

    public static void Shuffle<T>(T[] array)
    {
        int n = array.Length;

        for (int i = 0; i < n; i++)
        {

            int r = i + UnityEngine.Random.Range(0, n - i);

            T t = array[r];

            array[r] = array[i];

            array[i] = t;

        }
    }

    //带权重随机
    static public int GetRandomWeightedIndex(List<float> weights)
    {

        // Get the total sum of all the weights.
        float weightSum = 0;
        for (int i = 0; i < weights.Count; ++i)
            weightSum += weights[i];

        // Step through all the possibilities, one by one, checking to see if each one is selected.

        int index = 0;

        int lastIndex = weights.Count - 1;

        while (index < lastIndex)
        {
            // Do a probability check with a likelihood of weights[index] / weightSum.
            if (UnityEngine.Random.Range(0, weightSum) < weights[index])
                return index;

            // Remove the currunt item from the sum of total untested weights and try again.

            weightSum -= weights[index++];

        }

        // No other item was selected, so return very last index.
        return index;
    }
}
