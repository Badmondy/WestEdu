namespace WestEdu;

class Student : IPerson<Student>{

    public Guid StudentId { get; set; }   
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? SocialSecurityNumber { get; set; }

    
    public ContactInfo ContactInformation {get;set;} = new ContactInfo();
    public AddressInfo AddressInformation {get; set; } = new AddressInfo();

    public IPerson<Student> Find()
    {
        throw new NotImplementedException();
    }

    public List<Student> ListAll()
    {
        throw new NotImplementedException();
    }
}