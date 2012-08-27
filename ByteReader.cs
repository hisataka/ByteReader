using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ByteReaderSample
{
    /// <summary>
    /// バイト配列読み出し用のクラス
    /// </summary>
    public class ByteReader
    {
        public ByteReader()
        {
        }

        /// <summary>
        /// 不足しているbitの処理モード
        /// </summary>
        /// <remarks>
        /// Cut  : 不足している箇所は無視する
        /// Zero : 不足しているbitを0埋めする
        /// End  : 不足しているbitがある時はnullを返す
        /// </remarks>
        public enum Mode { Cut, Zero, End };

        /// <summary>
        /// バイト配列をInt32の配列に変換する
        /// 不足しているbitは0埋めする
        /// </summary>
        /// <param name="byteData">変換元データ</param>
        /// <returns>変換後の値</returns>
        public static Int32[] convertByte2Int32(byte[] byteData)
        {
            return convertByte2Int32(byteData, Mode.Zero);
        }

        /// <summary>
        /// バイト配列をInt32の配列に変換する
        /// </summary>
        /// <param name="byteData">変換元データ</param>
        /// <param name="mode">不足しているbitの処理モードを指定する</param>
        /// <returns>
        /// 変換後の値
        /// modeにEndを指定したしており、不足bitが存在する場合はnullを返す
        /// </returns>
        public static Int32[] convertByte2Int32(byte[] byteData, Mode mode)
        {
            // 一応サイズを取る
            int size = sizeof(Int32);

            int byteLength = byteData.Length;
            int intLength = byteLength / size;

            // 不足bitがあるかを調べておく
            bool hasMod = (byteLength % size != 0);

            int count;
            Int32[] ret;

            if (hasMod)// 不足bitがある
            {
                if (mode == Mode.Cut)// 切り捨てモードである
                {
                    ret = new Int32[intLength];
                }
                else if (mode == Mode.End)// 不足bitの存在を許さない
                {
                    // nullを返す
                    return null;
                }
                else
                {
                    ret = new Int32[intLength + 1];
                }
            }
            else
            {
                ret = new Int32[intLength];
            }

            // バイト列を順次Int32に変換する
            for (count = 0; count < intLength; count++)
            {
                ret[count] = BitConverter.ToInt32(byteData, count * size);
            }

            //不足bitが存在し、切り捨てモードでなければ処理をする
            if (mode != Mode.Cut && hasMod)
            {
                // 一応サイズ分の配列にしておく
                byte[] tmpB = new byte[size];
                // 0埋めしておく
                for (int i = 0; i < size; i++)
                {
                    tmpB[i] = 0x00;
                }

                // 不足bit分をコピーする
                for (int i = 0; i < size && count * size + i < byteData.Length; i++)
                {
                    tmpB[i] = byteData[count * size + i];
                }

                // バイト列をInt32に変換する
                ret[count] = BitConverter.ToInt32(tmpB, 0);
            }

            //結果を返す
            return ret;
        }
    }
}
