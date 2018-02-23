using System;
using System.Collections;
using System.Diagnostics;
using System.Text.RegularExpressions;

namespace SET_Parser
{
    public class SET_Parser
    {
        public static double preProcessTime;
        public static double searchTime;

        //for test finding operation
        public static string[] Contents_of_givenLayout_Tags_TESTER(string html_content, string pattern, bool cut_sub_blocks)
        {
            pattern = pattern.Replace(" ", ".");
            pattern = pattern.Replace(":", ".");
            pattern = pattern.Replace("(", ".");
            pattern = pattern.Replace(")", ".");
            pattern = pattern.Replace("?", ".");
            pattern = pattern.Replace("*", ".");

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            Hashtable _tags_in_HTML = filtergivenHTMLtag_TESTER(html_content, pattern);
            string[] _content = null;
            string s_tag = pattern.Replace(".", " ");
            string e_tag = find_EndTag(s_tag);
            int elementsize = 0;
            foreach (DictionaryEntry d in _tags_in_HTML)
            {
                string _tag = (string)d.Key;
                int _cnt = (int)d.Value;

                _content = GrabbingofHTMLTags(html_content, _tag, _cnt);
                string temp = "";
                for (int i = 0; i < _content.Length; i++)
                {
                    string t_content = _content[i];
                    //if (cut_sub_blocks)
                    //{
                    //    t_content = HTML.trimDIV(t_content);
                    //    t_content = HTML.trimTD(t_content);
                    //    _content[i] = t_content;
                    //}

                    temp = temp + t_content;

                    //başlagıç ve bitiş etiketi tekrar yazılıyor.
                    _content[i] = s_tag + _content[i] + e_tag;
                }

                elementsize = elementsize + temp.Length;
            }

            //başlangıç etiketini tekrar yapıştır.
            stopwatch.Stop();
            searchTime = stopwatch.Elapsed.TotalMilliseconds;

            return _content;
        }

        //word count for a given word in a given text
        private static int CountofStartingTag(string Text, string tag)
        {
            int words;
            Regex reg = new Regex(@tag);
            MatchCollection mc = reg.Matches(Text);
            if (mc.Count > 0)
                words = mc.Count;
            else
                words = 0;

            return words;
        }

        //end tag for a given tag
        private static string find_EndTag(string _tag)
        {
            int end = _tag.IndexOf(" ", StringComparison.Ordinal);
            if (end == -1)
                end = _tag.IndexOf(">", StringComparison.Ordinal);

            string _result = _tag;
            if (end != -1)
            {
                _result = _tag.Substring(0, end) + ">";
                _result = _result.Replace("<", "</");
            }

            return _result;
        }

        //end tag for a given tag
        private static string find_StartTag(string _tag)
        {
            int end = _tag.IndexOf(" ", StringComparison.Ordinal);
            if (end == -1)
                end = _tag.IndexOf(">", StringComparison.Ordinal);

            string _result = _tag;
            if (end != -1)
            {
                _result = _tag.Substring(0, end);
            }

            return _result;
        }

        //Tag'a ait bilgileri getiren fonksiyon
        //birden fazla sonuç varsa gösterebiliyor
        //nested özelliği regular expression sağlanamıyor. Bu fonksiyon sayesinde nested tapıda çözümleniyor.
        private static string[] GrabbingofHTMLTags(string _text, string _tag, int countofTag)
        {
            string[] _resultArray = new string[countofTag];

            string _endtag = find_EndTag(_tag);
            string _starttag = find_StartTag(_tag);

            int k = 0;
            for (int i = 0; i < countofTag; i++)
            {
                k = _text.IndexOf(_tag, k, StringComparison.Ordinal);
                if (k == -1) break;
                string str1 = "";
                if (k != -1)
                {
                    string str2 = _text.Substring(k);
                    str1 = _text.Substring(k);

                    k = k + _tag.Length;
                    //div içini ararken en son nerede kaldığımızı tutan etiket.
                    int l = str2.IndexOf(_endtag, StringComparison.Ordinal);
                    if (l != -1)
                        str1 = str2.Substring(0, l + _endtag.Length);
                    else
                        str1 = str2;

                    int start_position = l + _endtag.Length;
                    while (CountofStartingTag(str1, _starttag) != CountofStartingTag(str1, _endtag))
                    {
                        l = str2.IndexOf(_endtag, start_position, StringComparison.Ordinal);

                        if (l == -1)
                            break;

                        str1 = str2.Substring(0, l + _endtag.Length);

                        start_position = l + _endtag.Length;
                    }
                }//if 1
                else
                    str1 = "";

                //extract only content
                if (str1 != "")
                {
                    if (str1.Length - _tag.Length > 0)
                    {
                        str1 = str1.Substring(_tag.Length, str1.Length - _tag.Length - _endtag.Length);
                        str1 = str1.Trim();
                        _resultArray[i] = str1;
                    }
                }
            }//for

            return _resultArray;
        }//end function

        //find patterns in html
        public static Hashtable filteringHTMLtags(string html_content, string pattern, Hashtable _tags)
        {
            Regex exp = new Regex(pattern, RegexOptions.IgnoreCase | RegexOptions.Multiline | RegexOptions.Singleline | RegexOptions.IgnorePatternWhitespace);

            MatchCollection matchList = exp.Matches(html_content);

            for (int i = 0; i < matchList.Count; i++)
            {
                Match match = matchList[i];
                string _str = match.Groups[0].Value;
                if (_str.Length > pattern.Length - 3)
                {
                    if (!_tags.ContainsKey(_str))
                        _tags.Add(_str, 1);
                    else
                        _tags[_str] = (int)_tags[_str] + 1;
                }
            }

            return _tags;
        }

        //find patterns in html
        private static Hashtable filteringHTMLtags_TESTER(string html_content, string pattern, Hashtable _tags)
        {
            Regex exp = new Regex(pattern, RegexOptions.IgnoreCase | RegexOptions.Singleline | RegexOptions.IgnorePatternWhitespace);

            MatchCollection matchList = exp.Matches(html_content);

            for (int i = 0; i < matchList.Count; i++)
            {
                Match match = matchList[i];

                if (!_tags.ContainsKey(matchList[i].ToString()))
                    _tags.Add(matchList[i].ToString(), 1);
                else
                    _tags[matchList[i].ToString()] = (int)_tags[matchList[i].ToString()] + 1;
            }

            return _tags;
        }

        //for a given tag
        private static Hashtable filtergivenHTMLtag_TESTER(string html_content, string pattern)
        {
            Hashtable _tags = new Hashtable();

            _tags = filteringHTMLtags_TESTER(html_content, pattern, _tags);

            return _tags;
        }

        public static int CountStringOccurrences(string text, string pattern)
        {
            // Loop through all instances of the string 'text'.
            int count = 0;
            int i = 0;
            while ((i = text.IndexOf(pattern, i, StringComparison.Ordinal)) != -1)
            {
                i += pattern.Length;
                count++;
            }
            return count;
        }

        public static string String_Decimal_Clear(string temp)
        {
            return Regex.Replace(temp, @"[\d-]", " ");
        }
    }
}
