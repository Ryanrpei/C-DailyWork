using System;
using System.Collections;
using System.IO;
using System.Linq;

namespace TextClassify
{
    class Program
    {
        static void Main(string[] args)
        {
             
            string[] InputData = File.ReadAllLines(@"C:\Users\hwy6823\Desktop\TestMining\jobtitle.csv");
            Hashtable Sml = new Hashtable();
            String Strcom="";
            //1. trim the space
            //2. convert to low case
            int doci = 1;
            foreach (string e in InputData)
            {
               
                string[] tmps = e.Split(new char[3] { ' ', '-' ,'/'});
                foreach(string ee in tmps)
                {
                    if (ee != " ")
                    {
                        string e1 = ee.ToLower().Trim();
                        int FreqCount = 1;
                        if (Sml.ContainsKey(e1))
                            ((int[])Sml[e1])[2] = ((int[])Sml[e1])[2] + 1;
                        else
                            Sml.Add(e1, new int[3] { doci, 1, FreqCount });
                    }
                }
                int ix = 1;
                foreach (string ee in tmps)
                {
                    int FreqCount = 1;
                    Strcom = ee.ToLower().Trim();
                    for (int i=ix; i<tmps.Length; i+=1)
                    {
                        if (tmps[i] != " ")
                        {
                            Strcom = string.Concat(Strcom, " ", tmps[i].ToLower().Trim());
                            string ee1 = Strcom.Trim();
                            if (Sml.ContainsKey(ee1))
                                ((int[])Sml[ee1])[2] = ((int[])Sml[ee1])[2] + 1;

                            else
                                // here record down the category nature of frequency.
                                Sml.Add(ee1, new int[3] { doci, i, FreqCount });
                        }
                    }
                    ix += 1;
               


                }
                doci += 1;
            }
            var a=  Sml.Cast<DictionaryEntry>().OrderBy(entry =>((int[]) entry.Value)[2]).ToList();
            Console.WriteLine(Sml.Count);
            Console.WriteLine(String.Format("key is {0} , Vallue is {1}",a[0].Key,a[0].Value));
            Console.WriteLine(String.Format("key is {0} , Vallue is {1}", a[a.Count-1].Key, a[a.Count-1].Value));
            Console.WriteLine(Sml.Count);
            string o = String.Format("{0} ,{1}\n", a[0].Key, a[0].Value);
            for (int i = 1; i < a.Count; i += 1)
            o=o+ String.Format("{0} ,{1},{2},{3}\n", a[i].Key, ((int[])a[i].Value)[0], ((int[])a[i].Value)[1],((int[]) a[i].Value)[2]);
          //  File.WriteAllText(@"C:\Users\hwy6823\Desktop\TestMining\output.csv", );
            File.WriteAllText(@"C:\Users\hwy6823\Desktop\TestMining\output.csv", o);
            
        }
    }
}
