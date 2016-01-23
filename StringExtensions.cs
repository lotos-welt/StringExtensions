/************************************************
StringExtensions.cs

Copyright (c) 2016 LotosLabo

This software is released under the MIT License.
http://opensource.org/licenses/mit-license.php
************************************************/

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/* 文字列操作クラス. */
public class StringExtensions : MonoBehaviour {

    /// <summary>
    /// 先頭に句読点などの記号が来ないように調整する.
    /// </summary>
    /// <param name="lineCount">最大表示行数.</param>
    /// <param name="text">文字列.</param>
    /// <returns>変換された文字列.</returns>
    public static string LineChenger(string text, int maxLineCount) {
        string result = string.Empty;
        //　最大行数から一文字少なく表示.
        int lineCount = maxLineCount - 1;

        //  先頭に来てはいけない文字.
        string checkString = "、,.。」・｝；？！?!";
        List<string> textList = new List<string>();

        // 全体文字数が最大行数を超えるとき.
        if (text.Length > lineCount) {
            // 全体文字数まで増やす.
            for (int index = 0; index < text.Length; index += lineCount) {
                // 全体文字数から最大行数分抜き出せた時.
                if (index < text.Length - lineCount) {
                    // 最大行数より一文字多く抜き取る.
                    string lineCountPlusText = text.Substring(index, lineCount + 1);
                    // 最大行数分抜き取る.
                    string lineCountText = text.Substring(index, lineCount);
                    // 一文字多く取得した文字列の一番最初の文字を取得.
                    string firstText = lineCountPlusText.Substring(lineCount, 1);
                    // 抜き出した文字が先頭に来てはいけない文字か判断.
                    if (0 <= checkString.IndexOf(firstText)) {
                        // 一文字多くリストに追加.
                        textList.Add(lineCountPlusText);
                        // 一文字多く取得したので、1追加.
                        index += 1;
                    } else {
                        // 最大行数分リストに追加.
                        textList.Add(lineCountText);
                    }
                } else {
                    // 残り文字数を取得.
                    int remainingTextCount = text.Length - index;
                    // 残り文字数を抜き出す.
                    string remainingText = text.Substring(index, remainingTextCount);
                    textList.Add(remainingText);
                }
            }
            for (int index = 0; index < textList.Count; ++index) {
                result += textList[index] + "\n";
            }
            return result;
        }
        return text;
    }

    /// <summary>
    /// 文字列内の改行文字を削除.
    /// </summary>
    /// <param name="text">文字列.</param>
    /// <returns>改行を削除した文字列を返す.</returns>
    public static string RemoveNewLine(string text) {
        return text.Replace("\r", "").Replace("\n", "");
    }

    /// <summary>
    /// 文字列内のタブ文字を削除.
    /// </summary>
    /// <param name="text">文字列.</param>
    /// <returns>タブを削除した文字列を返す.</returns>
    public static string RemoveTab(string text) {
        return text.Replace("\t", "");
    }

    /// <summary>
    /// 文字列内の半角スペース、全角スペースの削除.
    /// </summary>
    /// <param name="text">文字列.</param>
    /// <param name="type">半角か全角か(１半角、2全角)</param>
    /// <returns>スペースを削除した文字列を返す.</returns>
    public static string RemoveSpace(string text, int type) {
        string result = string.Empty;
        switch (type) {
            // 半角の時.
            case 1:
                result = text.Replace(" ", "");
                break;
            case 2:
                result = text.Replace("　", "");
                break;
            default:
                result = null;
                break;
        }
        return result;
    }

    /// <summary>
    /// 先頭文字に空白を挿入する.
    /// </summary>
    /// <param name="text">文字列.</param>
    /// <returns>空白を挿入した文字列を返す.</returns>
    public static string InsertOneSpace(string text) {
        return text.Insert(0, " ");
    }
}
