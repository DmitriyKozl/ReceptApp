using VideoplayerProject.Domain;
using VideoplayerProject.Domain.Models;

namespace Test {
    internal class Program {
        static void Main(string[] args) {
            try {
                Timestamp t1 = new Timestamp("01:15", "01:30");
                Console.WriteLine("check");
                Timestamp t4 = new Timestamp("02:15", "06:30");
                Console.WriteLine("check");

                Timestamp t3 = new Timestamp("01:15", "01:00");
            } catch(Exception ex) {
                Console.WriteLine(ex.Message);
            }
        }
    }
}