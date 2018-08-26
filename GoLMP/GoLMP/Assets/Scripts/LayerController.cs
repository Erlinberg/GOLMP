//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class LayerController : MonoBehaviour {
//    public int LayerNum;

//    private int Layer = 0;

//    private int S;

//    private int z_b;

//    private int z_f_f = 0;

//    private void PlusLayer()
//    {
//        if (Layer < LayerNum)
//        {
//            S = (Layer + 1) * 2;
//            z_b = LayerNum - Layer - 1;
//            for (int z = 0; z < S*S; z++)
//            {
//                GetComponent<GlobalGod>().SellArray[z*z_b + z_f_f] 
//                z_f_f++;
//                for (int y = 0; y < GetComponent<GlobalGod>().FieldSize; y++)
//                {
//                    for (int x = 0; x < GetComponent<GlobalGod>().FieldSize; x++)
//                    {

//                    }
//                }
//            }
//            Layer++;
//        }
//    }
//}
