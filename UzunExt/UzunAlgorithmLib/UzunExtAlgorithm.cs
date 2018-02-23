using System.Collections.Generic;
using System.Diagnostics;

namespace UzunExtAlgorithmLib
{
    /*
     * This algorithm takes only relevant element into account for extracting content of an element. In DOM, all elements take into consideration. 
     * 1. Search pattern (an element and its attributes), 2. calculate ending and starting element, 3. finally extract content of the element
     */
    public class UzunExtAlgorithm
    {
        public static int first_pos;
        public static int endTag;
        public static int repeat;

        public static List<string> Extract(string tagname, string source, int startIndex, int endtag_cnt, bool repeative, ESMAJ.SearchAlgoritms.SearchAlgorithm sa)
        {
            if (endtag_cnt == 0)
                endtag_cnt = 1;
            //startIndex : for speeding up searching
            //endtag_cnt : for preventing calculation of starting tag count (Ignore: ESMAJ.SearchAlgoritms.Count), 
            //This value should be determined carefully. If an error is made in the selection of this value, the result of extraction will be incorrect.

            string start_tn = start_tagname(tagname);
            string end_tn = end_tagname(tagname);
            List<string> list_sonuc = new List<string>();

            if (startIndex >= source.Length)
                return null;
            
            int start_ind = ESMAJ.SearchAlgoritms.Search(tagname, source, startIndex, sa); 

            if (start_ind == -1)
                start_ind = ESMAJ.SearchAlgoritms.Search(tagname, source, 0, sa);
            
            
            if (start_ind != -1) //Find end tag
            {
                first_pos = start_ind;
                //find substring 
                int end_ind = ESMAJ.SearchAlgoritms.Search(end_tn, source, start_ind, sa) - start_ind + end_tn.Length; 
                string result_tmp = "";
                int start_tag = 0;
                if (endtag_cnt > -1)
                    start_tag = endtag_cnt;

                int end_tag = 0;
                while (true)
                {
                    string sub_tmp = source.Substring(start_ind, end_ind);
                    result_tmp += sub_tmp;
                    if(endtag_cnt == -1)
                        start_tag += ESMAJ.SearchAlgoritms.Count(start_tn, sub_tmp, sa);
                    end_tag += 1;
                        //ESMAJ.SearchAlgoritms.Count(end_tn, sub_tmp, sa); 
                    if (start_tag != end_tag)
                    {
                        start_ind += end_ind;
                        end_ind = ESMAJ.SearchAlgoritms.Search(end_tn, source, start_ind, sa) - start_ind + end_tn.Length;
                        if (end_ind == -1)
                            break; //unexpected error
                    }
                    else
                    {
                        list_sonuc.Add(result_tmp);
                        if (!repeative) //don't search other tag names
                            break;
                        start_ind = ESMAJ.SearchAlgoritms.Search(tagname, source, start_ind + end_ind, sa);
                        if (start_ind == -1)
                            break;
                        end_ind = ESMAJ.SearchAlgoritms.Search(end_tn, source, start_ind, sa) - start_ind + end_tn.Length;
                        result_tmp = "";
                        if (endtag_cnt > -1)
                            start_tag = endtag_cnt;
                        else
                            start_tag = 0;
                        end_tag = 0;
                    }
                }

                endTag = end_tag;
                repeat = list_sonuc.Count;
                return list_sonuc;
            }
            else            
                return null;                
        } 

        #region Find and Create Tag
        //HTML find tag
        public static string start_tagname(string tagname)
        {
            if(tagname.Contains(" "))
                return tagname.Substring(0, tagname.IndexOf(" "));
            else 
                return tagname.Substring(0, tagname.IndexOf(">"));
        }

        //HTML create end tag
        public static string end_tagname(string tagname)
        {
            if (tagname.Contains(" "))
                return tagname[0] + "/" + tagname.Substring(1, tagname.IndexOf(" ") - 1) + ">";
            else
                return tagname[0] + "/" + tagname.Substring(1, tagname.IndexOf(">") - 1) + ">";
        }
        #endregion
    }
}
