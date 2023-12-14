using System;
using System.Collections;

namespace MainApp {

    interface INameAndCopy {
        string Name { get; set; }
        object DeepCopy();
    }

    class Person : INameAndCopy {
        private string _Name;
        private string _LastName;
        private DateTime _Date;

        public Person(string name, string lastname, DateTime date) {
            _Name = name;
            _LastName = lastname;
            _Date = date;
        }

        public Person() {
            _Name = "Martin";
            _LastName = "Alderson";
        }

        public DateTime Date {
            get { return _Date; }
            set { _Date = value; }
        }

        public string LastName {
            get { return _LastName; }
            set { _LastName = value; }
        }

        public string Name {
            get { return _Name; }
            set { _Name = value; }
        }

        public virtual string ToString() {
            return _Name;
        }

        public virtual string ToShortString() {
            return _LastName + _Name;
        }

        public object DeepCopy() {
            return new Person(_Name, _LastName, _Date);
        }
    }

    class Paper : INameAndCopy {
        public string PublishName;
        public Person Author;
        public DateTime PublishDate;

        public Paper(string pbName, Person author, DateTime pbDate) {
            PublishName = pbName;
            Author = author;
            PublishDate = pbDate;
        }

        public Paper() {
            PublishName = "Publishment name";
        }

        public override string ToString() {
            return PublishName;
        }

        public object DeepCopy() {
            return new Paper(PublishName, (Person)Author.DeepCopy(), PublishDate);
        }
    }

    class ResearchTeam : INameAndCopy, IEnumerable {
        private string _Topic;
        private string _Organization;
        private int _Number;
        private TimeFrame _Duration;
        private List<Paper> _papers;

        public ResearchTeam(string topic, string org, int num, TimeFrame frame) {
            _Topic = topic;
            _Organization = org;
            _Number = num;
            _Duration = frame;
            _papers = new List<Paper>();
        }

        public ResearchTeam() {
            _Topic = "Malwares";
            _Organization = "OpenAi";
            _Number = 123;
            _Duration = TimeFrame.Long;
            _papers = new List<Paper>();
            ShowFields();
        }

        public void ShowFields() {
            Console.WriteLine(_Topic);
            Console.WriteLine(_Organization);
            Console.WriteLine(_Number);
            Console.WriteLine(_Duration);
        }

        public bool this[TimeFrame input] {
            get => _Duration == input;
        }

        public void AddPaper(Paper newPaper) {
            _papers.Add(newPaper);
        }

        public Paper LastPaper {
            get { return _papers.Count == 0 ? null : _papers[_papers.Count - 1]; }
        }

        public object DeepCopy() {
            ResearchTeam copy = new ResearchTeam(_Topic, _Organization, _Number, _Duration);
            foreach (var paper in _papers) {
                copy._papers.Add((Paper)paper.DeepCopy());
            }
            return copy;
        }

        public IEnumerator GetEnumerator() {
            return new ResearchTeamEnumerator(this);
        }

        public IEnumerable GetPersonsMoreThanOnePublication() {
            foreach (var paper in _papers) {
                if (paper.Author != null && _papers.Count(p => p.Author == paper.Author) > 1) {
                    yield return paper.Author;
                }
            }
        }

        public IEnumerable GetRecentPapers() {
            foreach (var paper in _papers) {
                if ((DateTime.Now - paper.PublishDate).TotalDays <= 365) {
                    yield return paper;
                }
            }
        }
    }

    class ResearchTeamEnumerator : IEnumerator {
        private ResearchTeam _team;
        private int _index;

        public ResearchTeamEnumerator(ResearchTeam team) {
            _team = team;
            _index = -1;
        }

        public object Current {
            get { return _team._papers[_index]; }
        }

        public bool MoveNext() {
            _index++;
            return _index < _team._papers.Count;
        }

        public void Reset() {
            _index = -1;
        }
    }

    class Solution {
        static void Main() {
            // 1
            ResearchTeam team1 = new ResearchTeam("Topic1", "Org1", 1, TimeFrame.Year);
            ResearchTeam team2 = new ResearchTeam("Topic1", "Org1", 1, TimeFrame.Year);

            Console.WriteLine($"Reference Equality: {ReferenceEquals(team1, team2)}"); // false
            Console.WriteLine($"Object Equality: {team1.Equals(team2)}"); // false

            // 2
            try {
                team1.Number = -1;
            }
            catch (ArgumentException ex) {
                Console.WriteLine($"Exception: {ex.Message}");
            }

            // 3
            Console.WriteLine($"Long Duration: {team1[TimeFrame.Long]}"); // false

            // 4
            Paper paper1 = new Paper("Paper1", new Person("Author1", "Last1", DateTime.Now), DateTime.Now);
            Paper paper2 = new Paper("Paper2", new Person("Author2", "Last2", DateTime.Now), DateTime.Now);

            team1.AddPaper(paper1);
            team1.AddPaper(paper2);

            Console.WriteLine($"Last Paper: {team1.LastPaper}");

            // 5
            ResearchTeam teamCopy = (ResearchTeam)team1.DeepCopy();
            team1.LastPaper.PublishName = "Modified Paper";
            Console.WriteLine($"Original Team: {team1.LastPaper}");
            Console.WriteLine($"Copied Team: {teamCopy.LastPaper}");

            // 6
            Console.WriteLine("Persons with More than One Publication:");
            foreach (Person person in team1.GetPersonsMoreThanOnePublication()) {
                Console.WriteLine(person.ToShortString());
            }

            // 7
            Console.WriteLine("Recent Papers:");
            foreach (Paper paper in team1.GetRecentPapers()) {
                Console.WriteLine(paper.PublishName);
            }

            // 8
            Console.WriteLine("Team Members with Publications:");
            foreach (Person person in team1) {
                Console.WriteLine(person.ToShortString());
            }

            // 9
            Console.WriteLine("Team Members with More than One Publication:");
            foreach (Person person in team1.GetPersonsMoreThanOnePublication()) {
                Console.WriteLine(person.ToShortString());
            }

            // 10
            Console.WriteLine("Recent Papers:");
            foreach (Paper paper in team1.GetRecentPapers()) {
                Console.WriteLine(paper.PublishName);
            }
        }
    }
}
