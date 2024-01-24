namespace Assignment2_WebServerAppDev.Interfaces
{
    public interface ISpeech
    {
        void Talk();
    }

    public class Dog : ISpeech
    {
        public void Talk()
        {
            Console.WriteLine("Woof");
        }
    }

    public class Cat : ISpeech
    {
        public void Talk()
        {
            Console.WriteLine("Meow");
        }
    }
}
