

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

        // властивість типу int з методами get і set 
        // для отримання інформації (get) і зміни (set) 
        // року народження в закритому полі типу DateTime,
        //  в якому зберігається дата народження.

    }

    class Paper {
        public string publish_name;
        public Person person;
        public System.DateTime publish_date;

        Paper(string pb_name, Person pers, System.DateTime pb_date){
            publish_name = pb_name;
            person = pers;
            publish_date = pb_date;
        }

        Paper(){
            publish_name = "Publishment name";
            // person = new Person;
            // publish_date = ''
        }

        public override virtual string ToString(){
            // return publish_name + 
        }

      class ResearchTeam {
        private string _Topic;
        private string _Organization;
        private int _Number;

        private TimeFrame _Duration;
        private Paper papers[];

        ResearchTeam(string topic, string org, int num, TimeFrame frame) {
            _Topic = topic;
            _Organization = org;
            _Number = num;
            _Duration = frame;
        }

        ResearchTeam(){
            Topic = "Malwares";
            _Organization = "OpenAi";
            _Number = 123;
            _Duration = TimeFrame.Long;
        }

      }


    }

    enum TimeFrame {
        Year = 0,
        TwoYear = 1,
        Long = 2,
    }


    class Solution {
        static void Main(){
            const int nrow = 10;
            const int ncol = 10;

            Person []data;
        }
    }
}