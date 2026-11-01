namespace AdvancedCsharp003
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Exercise 1: Student Grade Manager

            // Q1: Create a collection with these grades:
            // 85, 92, 78, 95, 88, 70, 100, 65

            #region Q1 - Create Grades Collection
            List<int> studentGrade = new() { 85, 92, 78, 95, 88, 70, 100, 65 };
            #endregion

            // Q2: Print the collection, Count, first and last grade

            #region Q2 - Print Collection Information
            studentGrade.ForEach((int grade) => Console.WriteLine($"Grade={grade}"));
            Console.WriteLine(studentGrade.Count);
            Console.WriteLine(studentGrade.First());
            Console.WriteLine(studentGrade.Last());
            #endregion

            // Q3: Sort the grades ascending, then print

            #region Q3 - Sort Grades Ascending

            studentGrade.Sort();
            Console.WriteLine("---Grades after sorting :----");
            studentGrade.ForEach((int grade) => Console.WriteLine($"Grade={grade}"));

            #endregion

            // Q4: Get the first grade above 90

            #region Q4 - First Grade Above 90

            Console.WriteLine($"First Grade Above 90 = {studentGrade.First((grade) => grade > 90)}");

            #endregion

            // Q5: Get all grades below 75 (failing grades)

            #region Q5 - Get Failing Grades
            List<int> FailingGrades = studentGrade.FindAll((grade) => grade < 75);

            #endregion

            // Q6: Remove all failing grades (below 75)

            #region Q6 - Remove Failing Grades

            studentGrade.RemoveAll((grade) => grade < 75);


            #endregion

            // Q7: Check if any grade equals 100

            #region Q7 - Check Grade 100
            Console.WriteLine($"if any grade equals 100? {studentGrade.Contains(100)}");
            #endregion

            // Q8: Create a List<string> where each grade becomes "Grade: X"

            #region Q8 - Convert Grades to Strings
            List<string> GradesAsText = studentGrade.ConvertAll((int grade) => { return $"Grade: {grade}"; });

            #endregion

            #endregion


            #region Exercise 2: Leaderboard

            // Q1: Add players:
            // 500 = "Ahmed", 200 = "Sara", 800 = "Ali", 350 = "Mona"

            #region Q1 - Add Players
            SortedDictionary<int, string> Players = new(new Dictionary<int, string> { { 500, "Ahmed" }, { 200, "Sara" }, { 800, "Ali" }, { 350, "Mona" } });
            #endregion

            // Q2: Print all entries (automatically sorted by score)

            #region Q2 - Print Sorted Leaderboard
            Console.WriteLine("---Players List: ---");
            foreach (var player in Players)
            {
                Console.WriteLine($"{player.Key}-{player.Value}");
            }
            #endregion

            // Q3: Access the first key and first value

            #region Q3 - First Key and First Value
            Console.WriteLine($"First player Name is {Players.First().Value} has score:{Players.First().Key}");
            #endregion

            // Q4: Check if score 500 exists

            #region Q4 - Check Score 500
            Console.WriteLine($"if eny player has score 500 {Players.Keys.Contains(500)}");
            #endregion

            // Q5: Safely get the player with score 999

            #region Q5 - Get Player with Score 999
            string? playerValue = "";
            bool isScore = Players.TryGetValue(999, out playerValue);
            #endregion

            // Q6: Remove the player with score 200 and print the updated list

            #region Q6 - Remove Player
            Players.Remove(200);
            Console.WriteLine("----Players list after updating----");
            foreach (var player in Players)
            {
                Console.WriteLine($"{player.Key}-{player.Value}");
            }
            #endregion

            #endregion


            #region Exercise 3: Phone Book

            // Q1: Create a collection with 4 contacts (name -> phone number)

            #region Q1 - Create Phone Book
            Dictionary<string, string> PhoneBook = new(StringComparer.OrdinalIgnoreCase) { { "ahmed", "01005154892" }, { "marwa", "01105287642" }, { "ayman", "01055689294" }, { "mona", "01004564689" } };
            #endregion

            // Q2: Add a new contact using [] syntax (add or update)

            #region Q2 - Add Contact Using Indexer
            PhoneBook["arwa"] = "01055154892";
            #endregion

            // Q3: Try adding a duplicate using .Add()
            // Catch the exception and print the error

            #region Q3 - Duplicate Contact Using Add
            try
            {
                PhoneBook.Add("AYMAN", "01055689294");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            #endregion

            // Q4: Try adding a duplicate using .TryAdd()
            // Print whether it succeeded

            #region Q4 - Duplicate Contact Using TryAdd

            Console.WriteLine(PhoneBook.TryAdd("Arwa", "01055154892"));
            #endregion

            // Q5: Search for a contact that doesn't exist

            #region Q5 - Search for Missing Contact

            Console.WriteLine(PhoneBook.ContainsKey("salwa"));
            #endregion

            // Q6: Get a contact with a fallback of "Not Found"

            #region Q6 - Get Contact with Fallback

            Console.WriteLine(PhoneBook.GetValueOrDefault("salwa", "Not Found"));
            #endregion

            // Q7: Print all Keys on one line, then all Values on another line
            Console.WriteLine("\n===================");
            #region Q7 - Print Keys and Values
            Console.WriteLine(string.Join(" , ", PhoneBook.Keys));
            Console.WriteLine(string.Join(" , ", PhoneBook.Values));

            #endregion

            #endregion

            Console.WriteLine("============================");
            #region Exercise 4: Unique Email Validator

            // Q1: Create a HashSet<string> with a case-insensitive comparer:
            // new HashSet<string>(StringComparer.OrdinalIgnoreCase)

            #region Q1 - Create Case-Insensitive HashSet
            HashSet<string> emailAddress = new(StringComparer.OrdinalIgnoreCase);
            #endregion

            // Q2: Add these emails:
            // "ahmed@test.com", "AHMED@test.com"
            // "sara@test.com", "Sara@Test.Com"

            #region Q2 - Add Emails
            emailAddress.Add("ahmed@test.com");
            emailAddress.Add("AHMED@test.com");
            emailAddress.Add("sara@test.com");
            emailAddress.Add("Sara@Test.Com");
            #endregion

            // Q3: Print Count
            // How many emails are actually stored? Explain why.

            #region Q3 - Count Unique Emails
            Console.WriteLine($"Number of Elemenys in Phone addrss collection :{emailAddress.Count}");
            //No.sorted=2 because because HashSet stores only unique elements.
            // StringComparer.OrdinalIgnoreCase ignores differences
            // between uppercase and lowercase letters,
            // so emails that differ only in letter case are considered duplicates.
            #endregion

            // Q4: Create two sets:
            // Set A = {1, 2, 3, 4, 5}
            // Set B = {4, 5, 6, 7, 8}
            #region Q4 - Create Sets A and B
            HashSet<int> SetA = [1, 2, 3, 4, 5];
            HashSet<int> SetB = [4, 5, 6, 7, 8];
            #endregion

            // Q5: Print the result of UnionWith, IntersectWith, ExceptWith

            #region Q5 - Set Operations
            HashSet<int> Union1 = new(SetA);
            Console.WriteLine("============================");
            Union1.UnionWith(SetB);
            foreach (var item in Union1)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("============================");
            var Union2 = new HashSet<int>(SetB);
            Union2.IntersectWith(SetA);
            foreach (var item in Union2)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("============================");
            var Union3 = new HashSet<int>(SetA);
            Union3.ExceptWith(SetB);
            foreach (var item in Union3)
            {
                Console.WriteLine(item);
            }
            #endregion

            // Q6: Use IsSubsetOf to check if {1, 2} is a subset of Set A

            #region Q6 - Check Subset
            Console.WriteLine("============================");
            HashSet<int> temp = [1, 2];
            Console.WriteLine(temp.IsSubsetOf(SetA));
            #endregion

            #endregion


            #region Exercise 5: Print Queue Simulator

            // Create a Queue<string> and enqueue 5 documents:
            // "Report.pdf", "Invoice.pdf", "Letter.docx"
            // "Resume.pdf", "Photo.jpg"

            #region Setup - Create Print Queue
            Queue<string> Simulator = new();
            Simulator.Enqueue("Report.pdf");
            Simulator.Enqueue("Invoice.pdf");
            Simulator.Enqueue("Letter.docx");
            Simulator.Enqueue("Resume.pdf");
            Simulator.Enqueue("Photo.jpg");

            #endregion

            // Q1: Print the queue contents and Count

            #region Q1 - Print Queue and Count
            Console.WriteLine("============================");
            foreach (var item in Simulator)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine($"Simulator collection count is : {Simulator.Count}");
            #endregion

            // Q2: Use Peek to see which document will print next
            // Without removing it
            Console.WriteLine("============================");
            #region Q2 - Peek Next Document
            Console.WriteLine(Simulator.Peek());
            #endregion

            // Q3: Process the queue using Dequeue
            // Print "Printing: [name]" for each document
            Console.WriteLine("============================");
            #region Q3 - Process Print Queue
            Console.WriteLine($"Printing:{Simulator.Peek()}");
            Simulator.Dequeue();
            Console.WriteLine($"Printing:{Simulator.Peek()}");
            Simulator.Dequeue();
            Console.WriteLine($"Printing:{Simulator.Peek()}");
            Simulator.Dequeue();
            Console.WriteLine($"Printing:{Simulator.Peek()}");
            Simulator.Dequeue();
            Console.WriteLine($"Printing:{Simulator.Peek()}");
            Simulator.Dequeue();
            #endregion

            // Q4: Try TryDequeue on the now-empty queue

            #region Q4 - TryDequeue Empty Queue
            Console.WriteLine(Simulator.TryDequeue(out string? p));
            // What happens? return false 
            #endregion

            #endregion


            #region Exercise 6: Browser History (Undo)

            // Create a Stack<string> for browser history

            // Q1: Push 5 URLs:
            // "google.com", "github.com", "stackoverflow.com"
            // "youtube.com", "claude.ai"

            #region Q1 - Create Browser History
            Stack<string> browserHistory = new();
            browserHistory.Push("google.com");
            browserHistory.Push("github.com");
            browserHistory.Push("stackoverflow.com");
            browserHistory.Push("youtube.com");
            browserHistory.Push("claude.ai");
            #endregion

            // Q2: Use Peek to see the current page (top of stack)
            Console.WriteLine("===================================");
            #region Q2 - Peek Current Page
            Console.WriteLine(browserHistory.Peek());
            #endregion

            // Q3: Press "back" 3 times using Pop
            // Print each page you leave
            Console.WriteLine("===================================");
            #region Q3 - Go Back Three Times
            Console.WriteLine(browserHistory.Pop());
            Console.WriteLine(browserHistory.Pop());
            Console.WriteLine(browserHistory.Pop());
            #endregion

            // Q4: Print the current page after going back
            Console.WriteLine("===================================");
            #region Q4 - Print Current Page
            Console.WriteLine(browserHistory.Peek());
            #endregion

            // Q5: Try TryPop on an empty stack
            // What happens?return False
            Console.WriteLine("===================================");
            #region Q5 - TryPop Empty Stack
            browserHistory.Clear();
            Console.WriteLine(browserHistory.TryPop(out string? value));
            #endregion

            #endregion
        }

    }
}