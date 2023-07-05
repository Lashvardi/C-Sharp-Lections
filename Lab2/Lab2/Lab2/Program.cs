// C#-ის არითმეტიკული და ლოგიკური ოპერაციები

int num1 = 10;
int num2 = 20;

// არითმეტიკული ოპერატორები

Console.WriteLine(num1 + num2); // 30
Console.WriteLine(num1 - num2); // -10
Console.WriteLine(num1 * num2); // 200
Console.WriteLine(num1 / num2); // 0

// ნაშთით გაყოფა
Console.WriteLine(num2 % num1); // 0

// ზრდის და შემცირების ოპერატორები


num1++; // num1 = num1 + 1;
Console.WriteLine(num1); // 11

num2--; // num2 = num2 - 1;
Console.WriteLine(num2); // 19

// მინიჭების ოპერატორები

num1 += 5; // num1 = num1 + 5;
Console.WriteLine(num1); // 16

num2 -= 5; // num2 = num2 - 5;
Console.WriteLine(num2); // 14

num1 *= 2; // num1 = num1 * 2;
Console.WriteLine(num1); // 32

num2 /= 2; // num2 = num2 / 2;
Console.WriteLine(num2); // 7

// შედარების ოპერატორები

Console.WriteLine(num1 == num2); // False
Console.WriteLine(num1 != num2); // True
Console.WriteLine(num1 > num2); // True
Console.WriteLine(num1 < num2); // False
Console.WriteLine(num1 >= num2); // True
Console.WriteLine(num1 <= num2); // False

// If Statement

// if C#-ში გამოიყენება რაღაც პირობა/პირობების შესამოწმებლად.
// შემდგომ მიღებული შედეგის მიხედვით რაღაც ლოგიკის ასამოქმედებლად.

// მაგ:

// If-ის ერთ პირობიანი მაგალითი
if(num1 + 15 == num2)
{
    Console.WriteLine("num1 + 15 Equals to num2");
}
else
{
    Console.WriteLine("num1 + 15 Is not equals to num2");
}

// C# - ში გვაქვს სხვადასხვა ლოგიკური ოპერატორები

// && (And) (და) მოითხოვს რომ ყველა პირობა იყოს შესრულებული
// || (Or) (ან) მოითხოვს რომ ერთი პირობა იყოს შესრულებული
// ! (Not) (არა) მოითხოვს რომ პირობა არ იყოს შესრულებული

// მაგ:

string userRole = "Moderator";
string userToken = "QGJJQR13GJJQQQ";

string validToken = "QGJJQR13GJJQQQ";

if(userRole == "Admin" && userToken == validToken)
{
    Console.WriteLine("Access Granted To Super Secret Area");
}
else
{
    Console.WriteLine("Access Denied");
}

// მაგალითი 2
if(userRole == "Admin" || userToken == validToken)
{
    Console.WriteLine("Access Granted To Super Secret Area");
}
else
{
    Console.WriteLine("Access Denied");
}

// მაგალითი 3
if(!(userRole == "Admin" || userToken == validToken))
{
    Console.WriteLine("Access Granted To Super Secret Area");
}
else
{
    Console.WriteLine("Access Denied");
}

// Else If
string username = "admin";
string password = "password";

Console.Write("Enter your username: ");
string enteredUsername = Console.ReadLine();

Console.Write("Enter your password: ");
string enteredPassword = Console.ReadLine();

if (enteredUsername == username && enteredPassword == password)
{
    Console.WriteLine("Login successful! Welcome, admin.");
}
else if (enteredUsername == username)
{
    Console.WriteLine("Incorrect password. Please try again.");
}
else if (enteredPassword == password)
{
    Console.WriteLine("Incorrect username. Please try again.");
}
else
{
    Console.WriteLine("Incorrect username and password combination. Please try again.");
}

// Switch Statement
Console.WriteLine("Enter a number between 1 and 5:");
int number = int.Parse(Console.ReadLine());

switch (number)
{
    case 1:
        Console.WriteLine("You entered number 1.");
        break;
    case 2:
        Console.WriteLine("You entered number 2.");
        break;
    case 3:
        Console.WriteLine("You entered number 3.");
        break;
    case 4:
        Console.WriteLine("You entered number 4.");
        break;
    case 5:
        Console.WriteLine("You entered number 5.");
        break;
    default:
        Console.WriteLine("Invalid number.");
        break;
}

// საკლასო დავალება დაწერეთ პროგრამა Switch-ით
// სადაც მომხმარეელი შეიყვანს კვირის დღეს
// პროგრამამ უნდა დააბრუნოს ეს დღე სამუშაო დღეა თუ არა
