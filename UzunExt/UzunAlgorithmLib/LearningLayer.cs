using System;
using System.Collections.Generic;
using System.Linq;

namespace UzunExtAlgorithmLib
{
    /*
     * LearningLayer detects the most appropriate minimum value which is returned for determining search point
     * For detection, Grubbs' test is used.
     * 
     * Grubbs' test: Detecting Outliers which are invalid data  
     * Reference: 
     *  Grubbs, Frank (February 1969). "Procedures for Detecting Outlying Observations in Samples". Technometrics. Technometrics, Vol. 11, No. 1. 11 (1): 1–21. JSTOR 1266761. doi:10.2307/1266761.
     *  Stefansky, W. (1972). "Rejecting Outliers in Factorial Designs". Technometrics. Technometrics, Vol. 14, No. 2. 14 (2): 469–479. JSTOR 1267436. doi:10.2307/1267436. 
     */

    public class LearningLayer
    {
        private List<double> _list;
        private int ratioL; //-1:learn1, -2:learn2, >= 0, -3: close
        private int innerTagL; //-1:learn, >= 0, -2: close
        private int repetitionL; //-1:learn, 1:fixed false; 2:fixed true, -2: close (false), -3: close (true)

        public int startingPos;
        public int innerTag;
        private int firstInnerTag;
        public bool repetition;
        //CriticalZ 5%
        double[] CriticalZ = { 1.15, 1.48, 1.71, 1.89, 2.02, 2.13, 2.21, 2.29, 2.34, 2.41, 2.46, 2.51, 2.55, 2.59, 2.62, 2.65, 2.68, 2.71, 2.73, 2.76, 2.78,
                               2.80, 2.82, 2.84, 2.86, 2.88, 2.89, 2.91, 2.92, 2.94, 2.95, 2.97, 2.98, 2.99, 3.00, 3.01, 3.03, 3.04, 3.13, 3.20, 3.26, 3.31,
                               3.35, 3.38, 3.42, 3.44, 3.47, 3.49 };
        
        public LearningLayer(int _rv, int _innerTag, int _repetition) {
            _list = new List<double>();
            ratioL = _rv;
            if (ratioL >= 0)
                startingPos = Convert.ToInt32(_rv);
            else
                startingPos = 0; //start learn from 0

            innerTagL = _innerTag;
            if (innerTagL >= 0)
                innerTag = _innerTag;
            else
                innerTag = -1;

            repetitionL = _repetition;
            repetition = false;
            if (repetitionL == 1)
                repetition = false;
            else if (repetitionL == 2)
                repetition = true;
            else if (repetitionL == -1)
                repetition = true;
            else if(repetitionL == -2)
                repetition = true;
            else if (repetitionL == -3)
                repetition = false;
        }

        public void Check_Values(int val, int len, int IT, int rep)
        {
            if (val >= 0) { //-1 means no pattern in source file
                if (ratioL == -1) //learn with position ratio
                {
                    double ratio = (double)val / len;
                    _list.Add(ratio);
                    startingPos = Convert.ToInt32(check_Val(_list) * len);
                }
                else if (ratioL == -2) //learn with position
                {
                    _list.Add(val);
                    startingPos = Convert.ToInt32(check_Val(_list));
                }
                //else fixed value
                else
                    _list.Add(val);

                //for learning innertag and repetion
                if (_list.Count <= 10)
                {
                    if(innerTagL == -1) //learn
                    {
                        innerTag = -1;
                        if (IT > 0)
                        {
                            if (_list.Count == 1)
                                firstInnerTag = IT;
                            else if (firstInnerTag != IT) //finish learning
                            {
                                innerTag = -1; //don't use, only one record enough for decision
                                innerTagL = 0; //finish learning but :(
                            }
                            else if (_list.Count == 10)
                            {
                                innerTag = IT;
                                innerTagL = 0; //finish learning :)
                            }
                                
                        }                     
                    }
                    
                    if(repetitionL == -1) //learn
                    {
                        if (rep > 1)//learn, only one record enough for decision
                        {
                            repetition = true;
                            repetitionL = 0; //finish learning but :(
                        } else if(_list.Count == 10)
                        {
                            repetition = false;
                            repetitionL = 0; //finish learning :)
                        } 
                    }
                }//if 10                 
            }
        }

        private double check_Val(List<double> _list)
        {
            double min = _list.Min();
            if (_list.Count > 5)
            {
                double mean = Calculate_Mean(_list);
                double SD = Calculate_SD(_list);
                if (SD == 0)//means all values equal
                    return _list[0];

                int pos = _list.Count - 3;
                if (pos >= 100) pos = 100; //use same Z score after 100

                min = _list[0];
                foreach (int value in _list)
                {
                    double G = Math.Abs(mean - value) / SD;
                    if (G < CriticalZ[pos])
                        if (min > value)
                            min = value;
                }
            }

            return min;
        }

        private double Calculate_Mean(List<double> _list)
        {
            double t = 0;
            foreach (double value in _list)
                t += value;

            return (double) t / _list.Count;
        }

        private double Calculate_SD(List<double> _list)
        {
            double mean = Calculate_Mean(_list);
            double t = 0;
            foreach (double value in _list)
                t += (mean - value) * (mean - value);

            return Math.Sqrt((double) t / (_list.Count - 1));
        }
    }
}
