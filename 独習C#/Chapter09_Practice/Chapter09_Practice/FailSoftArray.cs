// Lengthプロパティを自動実装するプロパティに変更

using Chapter09_Practice;
using System;

class FailSoftArray : IFailSoft
{
    int[] array; // 配列への参照 

    public bool ErrFlag; // 直前の操作の結果を表すフラグ

    // 自動実装するプロパティ、実質的に読み取り専用
    public int Length { get; private set; }

    // サイズを指定して配列を作る 
    public FailSoftArray(int size)
    {
        array = new int[size];
        Length = size;
    }

    // FailSoftArrayオブジェクトのためのインデクサ
    public int this[int index]
    {
        // getアクセサ 
        get
        {
            if (IsWithinRange(index))
            {
                ErrFlag = false;
                return array[index];
            }
            else
            {
                ErrFlag = true;
                return 0;
            }
        }

        // setアクセサ
        set
        {
            if (IsWithinRange(index))
            {
                array[index] = value;
                ErrFlag = false;
            }
            else ErrFlag = true;
        }
    }

    // インデックスが配列の上限・下限の範囲内ならtrueを返す
    private bool IsWithinRange(int index)
    {
        if (index >= 0 & index < Length) return true;
        return false;
    }
}
