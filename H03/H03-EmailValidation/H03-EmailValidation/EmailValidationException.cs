namespace H03_EmailValidation; 

public class EmailValidationException : Exception {

    public EmailValidationException(string message) : base(message) { }

    public EmailValidationException(string message, Exception innerException) : base(message, innerException) { }

    public EmailValidationException() { }

    public EmailValidationException(string message, string[] errors) : base(message) {
        Errors = errors;
    }

    public string[] Errors { get; set; }
    
}