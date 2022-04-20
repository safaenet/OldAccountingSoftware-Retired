using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SafaShop
{
    class cEncrypt
    {
        int[] arrChar = {32,33,34,35,36,37,38,39,40,41,42,43,44,45,46,47,48,49,50,51,52,53,54,55,56
                            ,57,58,59,60,61,62,63,64,65,66,67,68,69,70,71,72,73,74,75,76,77,78,79,80
                            ,81,82,83,84,85,86,87,88,89,90,91,92,93,94,95,96,97,98,99,100,101,102,103
                            ,104,105,106,107,108,109,110,111,112,113,114,115,116,117,118,119,120,121
                            ,122,123,124,125,126,127 };
        string[] arrEncrypt = { "AGMP","AGMQ","AGNP","AGNQ","AHMP","AHMQ","AHNP","AHNQ","AIMP","AIMQ","AINP"
                                  ,"AINQ","AJMP","AJMQ","AJNP","AJNQ","AKMP","AKMQ","AKNP","AKNQ","BGMP","BGMQ"
                                  ,"BGNP","BGNQ","BHMP","BHMQ","BHNP","BHNQ","BIMP","BIMQ","BINP","BINQ","BJMP"
                                  ,"BJMQ","BJNP","BJNQ","BKMP","BKMQ","BKNP","BKNQ","CGMP","CGMQ","CGNP","CGNQ"
                                  ,"CHMP","CHMQ","CHNP","CHNQ","CIMP","CIMQ","CINP","CINQ","CJMP","CJMQ","CJNP"
                                  ,"CJNQ","CKMP","CKMQ","CKNP","CKNQ","DGMP","DGMQ","DGNP","DGNQ","DHMP","DHMQ"
                                  ,"DHNP","DHNQ","DIMP","DIMQ","DINP","DINQ","DJMP","DJMQ","DJNP","DJNQ","DKMP"
                                  ,"DKMQ","DKNP","DKNQ","EGMP","EGMQ","EGNP","EGNQ","EHMP","EHMQ","EHNP","EHNQ"
                                  ,"EIMP","EIMQ","EINP","EINQ","EJMP","EJMQ","EJNP","EJNQ","EKMP","EKMQ","EKNP"
                                  ,"EKNQ" };
        //private void generate()
        //{
        //    arrChar.Clear();
        //    arrEncrypt.Clear();
        //    int j = 0;
        //    for (int i = 32; i < 128; i++)
        //    {
        //        arrChar.Add(i);
        //        j++;
        //    }
        //    j = 0;
        //    for (int n = 33; n < 38; n++)
        //    {
        //        for (int m = 39; m < 44; m++)
        //        {
        //            for (int o = 123; o < 125; o++)
        //            {
        //                for (int p = 91; p < 93; p++)
        //                {
        //                    arrEncrypt.Add(Convert.ToChar(n).ToString()
        //                        + Convert.ToChar(m).ToString()
        //                        + Convert.ToChar(o).ToString()
        //                        + Convert.ToChar(p).ToString());
        //                    j++;
        //                }
        //            }
        //        }
        //    }
        //}
        public string encode(string strIn)
        {

            string encrypt = "";
            string str = strIn.Trim();

            for (int i = 0; i < str.Length; i++)
            {
                for (int j = 0; j < arrChar.Length; j++)
                {
                    Int16 int16 = (Int16)str[i];
                    if (int16 == Convert.ToUInt16(arrChar[j]))
                    {
                        encrypt += arrEncrypt[j].ToString();
                        break;
                    }
                }
            }
            return encrypt;
        }

        public string decode(string strIn)
        {
            string decrypt = "";
            string str = strIn.Trim();
            for (int i = 0; i < (str.Length / 4); i++)
            {
                string s = str.Substring((i) * 4, 4);
                for (int j = 0; j < arrEncrypt.Length; j++)
                {
                    if (s == arrEncrypt[j].ToString())
                    {
                        decrypt += Convert.ToChar(arrChar[j]).ToString();
                    }
                }
            }
            return decrypt;
        }
    }
}
