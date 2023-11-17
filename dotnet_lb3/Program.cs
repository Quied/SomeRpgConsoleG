

using System.Collections.Generic;



namespace MainApp {

    class Person {
        private string _Name;
        private string _LastName;
        private System.DateTime _Date;

        Person(string name, string lastname, System.DateTime date)  {
            _Name = name;
            _LastName = lastname;
            _Date = date;
        }

        Person(){
            _Name = "Martin";
            _LastName = "Alderson";
            // _Date = ''
        }

        public System.DateTime Date {
            get { return _Date; }
            set { _Date = value; }
        }

        public string LastName { 
            get { return _LastName;  }
            set { _LastName = value; }
        }

        public string Name { 
            get { return _Name; }
            set{ _Name = value; }
        }

        public virtual string ToString(){
            return _Name; // ?
        }

        public virtual string ToShortString(){
            return _LastName + _Name;
        }

        // public virtual bool Equals(object obj){
        //     if(obj == null || GetType() != obj.GetType()){
        //         return false;
        //     }
        // }

        // public virtual int GetHashCode(){

        // }

        // властивість типу int з методами get і set 
        // для отримання інформації (get) і зміни (set) 
        // року народження в закритому полі типу DateTime,
        //  в якому зберігається дата народження.

    }

    class Paper {
        public string publish_name;
        public Person person;
        public System.DateTime publish_date;

        public Paper(string pb_name, Person pers, System.DateTime pb_date){
            publish_name = pb_name;
            person = pers;
            publish_date = pb_date;
        }

        public Paper(){
            publish_name = "Publishment name";
            // person = new Person;
            // publish_date = ''
        }

        public override string ToString(){
            // return publish_name + 
            return "123";
        }

    }

    class ResearchTeam {

        private string _Topic;
        private string _Organization;
        private int _Number;

        private TimeFrame _Duration;
        private Paper []_papers;

        ResearchTeam(string topic, string org, int num, TimeFrame frame) {
            _Topic = topic;
            _Organization = org;
            _Number = num;
            _Duration = frame;
        }

        public ResearchTeam(){
            _Topic = "Malwares";
            _Organization = "OpenAi";
            _Number = 123;
            _Duration = TimeFrame.Long;
            this._papers = new Paper[10];
            this.show_fields();
        }

        public void show_fields(){
            Console.WriteLine(this._Topic);
            Console.WriteLine(this._Organization);
            Console.WriteLine(this._Number);
            Console.WriteLine(this._Duration);
        }

        public bool this[TimeFrame input] {
            get => this._Duration == input;
        }

        public void addPapers(Paper NPaper){
            int arr_size = this._papers.Length;

            Paper[] NArray = new Paper[arr_size + 1];

            for(int i = 0; i < arr_size; i++){
                NArray[i] = this._papers[i];
            }

            NArray[arr_size] = NPaper;
            _papers = NArray;
        }

        public Paper getLast(){
            for (int i = this._papers.Length - 1; i >= 0; i--){
                if (this._papers[i] != null){
                    return this._papers[i]; 
                }
            }
            return null; 
        }

        public double calculateRunTime(){
            return 0.0;
        }

        // public override string ToString(){

        // }

        // public virtual string ToShortString(){

        // }

        public Paper paper {
            get { return this._papers.Length == 0 ? null : this._papers[this._papers.Length - 1]; }
        }

        // public object DeepCopy(ResearchTeam obj){
        //     using (var ms = new MemoryStream()){
        //         var formatter = new BinaryFormatter();
        //         formatter.Serialize(ms, obj);
        //         ms.Position = 0;

        //         return (T) formatter.Deserialize(ms);
        //     }
        // }

    }


    enum TimeFrame {
        Year = 0,
        TwoYear = 1,
        Long = 2,
    }

    // 4

    interface INameAndCopy {

    }

    // 5
    class TestCollections<T,E> {


        public List<T> list;
        public List<string> list_str;
        public Dictionary<T,E> dict;
        public Dictionary<string,E> dict_str;

        TestCollections(){

        }

        // static E getLenght(int){

        // }

        TestCollections(int lenght){

        }

    }



    class Solution {
        static void Main(){

            // 3 
            ResearchTeam RTeam = new ResearchTeam();
            Paper paper = new Paper();

            bool isMatch = RTeam[TimeFrame.Long];
            bool isMatch2 = RTeam[TimeFrame.Year];
            bool isMatch3 = RTeam[TimeFrame.TwoYear];

            Console.WriteLine("{0}, {1}, {2}", isMatch, isMatch2, isMatch3); // true false false

            RTeam.addPapers(paper);


            // 4


            // 5
        }
    }
}

