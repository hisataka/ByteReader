using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ByteReaderSample
{
    class Program
    {
        static void Main(string[] args)
        {
            byte[] data = { 0x01, 0x00, 0x00, 0x10, 0x02, 0x00, 0x01, 0x00 };
            Int32[] int32Data;

            // 元データを表示
            Console.Write("Data:");
            for (int i = 0; i < data.Length; i++)
            {
                Console.Write(data[i] + " ");
            }
            Console.Write("\n");

            // int32配列に変換する
            int32Data = ByteReader.convertByte2Int32(data);
            
            Console.Write("Int32Data:");
            for(int i = 0; i < int32Data.Length; i ++) {
                Console.Write(int32Data[i] + " ");
            }
            Console.Write("\n");
        }
    }
}
