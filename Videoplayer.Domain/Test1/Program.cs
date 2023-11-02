using VideoplayerProject.Domain.Models;
using VideoplayerProject.Domain.Exceptions;

namespace Test1 {
    internal class Program {
        static void Main(string[] args) {
            //string name = "";
            string name = "    ";

            Recipe recipe = new(name, 4, "test", new TimeSpan(0, 0, 30));
        }
    }
}