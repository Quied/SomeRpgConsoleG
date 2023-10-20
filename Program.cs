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
    
    }


    class Entry {

        static void Main(){
            Entry entry = new Entry();
        }

    }

}
