using System;

namespace AppConsole {

    enum TimeFrame {
        Year, 
        TwoYears,
        Long,
    };

    class Person {}

    class Paper {
        
        Paper(){
            this.titleName = "Some title";
            this.author = null;
            this.publicationDate = new DateTime(2015,2,2);
        }

        Paper(string name, Person person, DateTime date) { 
            this.titleName = name;
            this.author = person;
            this.publicationDate = date;
        }

        public string titleName;
        public Person author;
        public DateTime publicationDate;
    }

    class ResearchTeam {
        private string researchTopic;
        private string Organization;
        private int number;
        private TimeFrame reseatchTime;
        // private Paper[];
        
        ResearchTeam(){
            this.researchTopic = "Some topic";
            this.Organization = "some org";
            this.number = 44;
            this.reseatchTime = new TimeFrame();  
        }

        ResearchTeam(string topic, string org, int number, TimeFrame team){
            this.researchTopic = topic;
            this.Organization = org;
            this.number = number;
            this.reseatchTime = team;
        }

    }


    class Entry {

        static void Main(){
            Entry entry = new Entry();
        }

    }

}
