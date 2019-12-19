namespace LoginForm.Source.Views.BehaviorsTabViews.Models
{
    public class Person
    {
        public string Name { get; set; }

        public int Age { get; private set; }

        public Person() { }

        public Person(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }
    }
}
