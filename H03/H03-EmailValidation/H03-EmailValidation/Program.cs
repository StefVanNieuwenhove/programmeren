
using System.Text.RegularExpressions;
using H03_EmailValidation;

Console.Write("Email: ");
string email = Console.ReadLine();

// regex expression match for email validation
Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");

try {
    if (regex.IsMatch(email)) {
        Console.WriteLine("Email is valid");
    } else {
        throw new EmailValidationException("Email is not valid");
    }
} catch (EmailValidationException e) {
    throw new EmailValidationException(e.Message);
}