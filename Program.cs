using System;
using System.Collections.Generic;

namespace ConsoleApp {

    class EntryPoint{ 
        
        // 1
        public void arrayProcess(int size)
        {
            // SUM 
            var arr = new int[size];
            var segment = new ArraySegment<int>(arr);
            
            var rand = new Random();

            // calculate sum of array 
            for(int i = 0; i < size; i++){
                segment[i] = rand.Next(100);
                Console.Write("{0}  ", segment[i]);
            }

            int ans = 0;

            for(int i = 0; i < size; i++){
                if(i % 2 == 0) {
                    ans += segment[i];
                }    
            }

           Console.WriteLine("Array sum: {0}", ans);

            // WHAT
                        


            // SORT
             void Swap(ref int first, ref int second){
                int temp = first;
                first = second;
                second = first;
            }

                for(int i = 0; i < size; i++){
                    for(int j = 0; j < size - 1; j++){
                        if(segment[j] < segment[j + 1]){
                           // Swap(segment[j], segment[j + 1]);
                           
                            int temp = segment[j + 1];
                            segment[j + 1] = segment[j];
                            segment[j] = temp; 
                        }
                    }
                }

                Console.WriteLine("output array");
                
                for(int i = 0; i < size; i++){
                    Console.Write("{0} ", segment[i]);
                }
                Console.WriteLine(" ");
            
       }


        // 2.
        public void Matrix(int size) {
           int mass = new int

        }

        // 3.
        
        void deleteDouble(ref String word) {
            
        }

        public void getStr() {
            Console.WriteLine("Enter santence: ");
            string str = Console.ReadLine();    

            Console.WriteLine("input: {0}", str);

            string []words = str.Split(new[] {' ', '\t'});
            SortedDictionary<String, int> dict = new SortedDictionary<String, int>();

            foreach(string word in words) {
                dict.Add(word, 1);
            }
           
            Console.WriteLine("Dictionary: ");
            foreach(var entry in dict){
                Console.Write("Word: {0} ", entry.Key);
                Console.WriteLine("Amount: {0} ", entry.Value);
            }



            // for(int i = 0; i < )
        }

        // 4.
        public void four() {}
        
    }

    class App {  
        static void Main(){      

            EntryPoint point = new EntryPoint();
            point.arrayProcess(10);
            point.Matrix(10);

            point.getStr();
        }
    } 
}





