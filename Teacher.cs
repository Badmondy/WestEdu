namespace WestEdu;

class Teacher : IPerson<Teacher>
{

    public Guid TeacherId { get; set; }

    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? SocialSecurityNumber { get; set; }

    public ContactInfo ContactInformation {get;set;} = new ContactInfo();
    public AddressInfo AddressInformation {get; set; } = new AddressInfo();

    public IPerson<Teacher> Find()
    {
        throw new NotImplementedException();
    }

    public List<Teacher> ListAll()
    {
        throw new NotImplementedException();
    }
}

