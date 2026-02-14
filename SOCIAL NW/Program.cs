namespace SocialMedia
{

    class Person{

        public string  Name { get; set; }
        public List<Person> Friend = new List<Person>();
        public Person(string name)
        {
            Name = name;
        }
        public void AddFriend(Person friend)
        {
            if (!Friend.Contains(friend))
            {
                Friend.Add(friend);
                friend.Friend.Add(this);
            }
        }
    }

    class SocialNw
    {
        private List<Person> _members = new List<Person>();

        public void AddMember(Person member)
        {
            _members.Add(member);
        }

        public void ShowNw()
        {
            foreach (var member in _members)
            {
                Console.Write(member.Name + "->");
                List<string> f = new List<string>();
                foreach (var friend in member.Friend)
                {
                    f.Add(friend.Name);
                }
                Console.WriteLine($"{string.Join(",",f)}");
            }
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Person aman = new Person("Aman");
            Person bhaskar = new Person("Bhaskar");
            Person chetak = new Person("Chetan");
            Person divakar = new Person("Divakar");
            SocialNw soc = new SocialNw();
            soc.AddMember(aman);
            soc.AddMember(bhaskar);
            soc.AddMember(chetak);
            soc.AddMember(divakar);

            aman.AddFriend(bhaskar);
            bhaskar.AddFriend(chetak);
            bhaskar.AddFriend(divakar);
            divakar.AddFriend(aman);
            soc.ShowNw();




            
        }
    }
}
